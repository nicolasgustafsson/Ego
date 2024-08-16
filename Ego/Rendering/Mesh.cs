using VulkanApi;
using ImageMagick;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;
using Utilities;
using Image = VulkanApi.Image;

namespace Rendering;

public struct GeoSurface
{
    public UInt32 StartIndex;
    public UInt32 Count;
}


public class Mesh : IGpuDestroyable
{
    public string Name;
    public List<GeoSurface> Surfaces;
    public MeshBuffers MeshBuffers;

    private Mesh(string aName, List<GeoSurface> WindowSurfaces, MeshBuffers aMeshBuffers)
    {
        Name = aName;
        Surfaces = WindowSurfaces;
        MeshBuffers = aMeshBuffers;
    }
    
    public void Destroy()
    {
        MeshBuffers.Destroy();
    }
    
    public static List<Mesh> LoadGltf(Renderer aRenderer, string aFilePath)
    {
        var model = ModelRoot.Load(aFilePath);
        
        if (model == null)
            return new();

        List<Mesh> meshes = new();

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
                IList<Vector2> uvs = primitive.GetVertexAccessor("TEXCOORD_0").AsVector2Array();
                IList<Vector4>? colors = primitive.GetVertexAccessor("COLOR_0") != null ? primitive.GetVertexAccessor("COLOR_0").AsVector4Array() : null;

                int vertexCount = positions.Count;
                
                GeoSurface newSurface = new();
                newSurface.StartIndex = (UInt32)indices.Count();
                newSurface.Count = (UInt32)primitiveIndices.Count;

                indices.AddRange(primitiveIndices);
                vertices.EnsureCapacity(vertexCount);
                
                for(int vertexIndex = 0; vertexIndex < vertexCount; vertexIndex++)
                {
                    const bool OverrideColors = true;
                    
                    vertices.Add(new Vertex()
                    {
                        Color = OverrideColors ? new Vector4(normals[vertexIndex], 1f) : colors is not null ? colors[vertexIndex] : Vector4.One, 
                        Normal = normals[vertexIndex], 
                        Position = positions[vertexIndex], 
                        Uv_X = uvs[vertexIndex].X, 
                        Uv_Y = uvs[vertexIndex].Y
                    });
                }

                surfaces.Add(newSurface);
            }

            meshes.Add(new Mesh(mesh.Name, surfaces, new MeshBuffers(aRenderer, GlobalAllocator, indices, vertices)));
            
        }
        return meshes;
    }
}
