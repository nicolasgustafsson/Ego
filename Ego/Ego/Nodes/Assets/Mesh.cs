using Rendering;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;
using VulkanApi;

namespace Ego;

public struct MeshInfo
{
    public List<UInt32> Indices;
    public List<Vertex> Vertices;
    public List<GeoSurface> Surfaces;

    public MeshInfo(List<uint> aIndices, List<Vertex> aVertices, List<GeoSurface> aSurfaces)
    {
        Indices = aIndices;
        Vertices = aVertices;
        Surfaces = aSurfaces;
    }
}

[Node(AllowAddingToScene = false)]
public partial class Mesh : Node, IFileAsset, IImportable
{
    //public List<MeshData> Meshes = null!;
    protected override string Name => FileName;

    private string FileName = "Unknown";
    private MeshInfo? MeshInfo;
    
    public void LoadFrom(string aPath)
    {
        /*
    }
        FileName = Path.GetFileNameWithoutExtension(aPath);

        Meshes = MeshData.LoadGltf(RendererApi.Renderer, aPath);*/
    }

    /*Task LoadFromAsync(string aPath)
    {
        
    }*/
    
    private void LoadFromMeshInfo()
    {
        
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public async Task Import(string aFile)
    {
        //don't block main thread
        await EgoTask.WorkerThread();
        
        
        #region a bunch of import code
        FileName = aFile;
        var model = ModelRoot.Load(aFile);

        if (model == null)
            return;

        int index = 0;

        List<UInt32> indices = new();
        List<Vertex> vertices = new();

        var mesh = model.LogicalMeshes.FirstOrDefault();

        if (mesh == null)
            return;
        
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
        #endregion

        await EgoTask.MainThread();

        MeshInfo = new(indices, vertices, surfaces);
        Log.Info($"Successfully imported mesh {aFile}!");
    }
}

