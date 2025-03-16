using Rendering;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;
using VulkanApi;

namespace Ego;

[Node(AllowAddingToScene = false)]
public partial class GltfRenderer : Node3D
{
    //When we import, this somehow needs to be saved as a assetdata. We don't want to duplicate mesh data everytime we instantiate a scene.
    private Dictionary<int, MeshData> Meshes = new();

    [Inspect] private string ModelPath = "";
    //Get a gltf file path, load it. Then create child nodes and renderers.
    //Later, this will become the import process. We do this, save it as a scene, then we reuse the scene elsewhere.

    public GltfRenderer()
    {
        
    }
    
    public GltfRenderer(string aModelPath)
    {
        ModelPath = aModelPath;
    }

    public override void Start()
    {
        base.Start();

        if (ModelPath == "")
            return;

        LoadModel(ModelPath);
    }

    private void LoadModel(string aModelPath)
    {
        LoadGltf(RendererApi.Renderer, aModelPath);
    }
    
    private void LoadGltf(Renderer aRenderer, string aFilePath)
    {
        var model = ModelRoot.Load(aFilePath);
        
        if (model == null)
            return;

        int index = 0;

        List<UInt32> indices = new();
        List<Vertex> vertices = new();

        foreach(var mesh in model.LogicalMeshes)
        {
            indices.Clear();
            vertices.Clear();

            List<GeoSurface> surfaces = new();

            foreach(var primitive in mesh.Primitives)
            {
                IntegerArray primitiveIndices = primitive.IndexAccessor.AsIndicesArray();
                IList<Vector3> positions = primitive.GetVertexAccessor("POSITION").AsVector3Array();
                IList<Vector3> normals = primitive.GetVertexAccessor("NORMAL").AsVector3Array();
                IList<Vector2>? uvs = primitive.GetVertexAccessor("TEXCOORD_0") != null ? primitive.GetVertexAccessor("TEXCOORD_0").AsVector2Array() : null;
                IList<Vector4>? colors = primitive.GetVertexAccessor("COLOR_0") != null ? primitive.GetVertexAccessor("COLOR_0").AsVector4Array() : null;

                int vertexCount = positions.Count;
                
                GeoSurface newSurface = new();
                newSurface.StartIndex = (UInt32)indices.Count();
                newSurface.Count = (UInt32)primitiveIndices.Count;

                indices.AddRange(primitiveIndices);
                vertices.EnsureCapacity(vertexCount);
                
                for(int vertexIndex = 0; vertexIndex < vertexCount; vertexIndex++)
                {
                    const bool OverrideColors = false;
                    
                    vertices.Add(new Vertex()
                    {
                        Color = OverrideColors ? new Vector4(normals[vertexIndex], 1f) : colors is not null ? colors[vertexIndex] : Vector4.One, 
                        Normal = normals[vertexIndex], 
                        Position = positions[vertexIndex], 
                        Uv_X = uvs is not null ? uvs[vertexIndex].X : 0f,  
                        Uv_Y = uvs is not null ? uvs[vertexIndex].Y : 0f
                    });
                }

                surfaces.Add(newSurface);
            }

            Meshes.Add(mesh.LogicalIndex, new MeshData(mesh.Name, surfaces, new MeshBuffers(aRenderer, MemoryAllocator.GlobalAllocator, indices, vertices)));
            index++;
        }
        
        foreach(var scene in model.LogicalScenes)
        {
            if (scene == null)
                continue;
            foreach(SharpGLTF.Schema2.Node? node in scene.VisualChildren)
            {
                InstantiateNode(this, node);
            }
        }
    }
    
    private void InstantiateNode(Node3D aParent, SharpGLTF.Schema2.Node? aNode)
    {
        if (aNode == null)
            return;

        Node3D newNode = null!;
        
        if (aNode.Mesh != null)
        {
            newNode = new MeshRenderer(Meshes[aNode.Mesh.LogicalIndex]);
        }
        else
        {
            newNode = new Node3D();
        }
        
        newNode.LocalPosition = aNode.LocalTransform.Translation;
        newNode.LocalScale = aNode.LocalTransform.Scale;
        newNode.LocalRotation = aNode.LocalTransform.Rotation;
        
        aParent.AddChild(newNode);
        
        foreach(var child in aNode.VisualChildren)
        {
            InstantiateNode(newNode, child);
        }
    }
}