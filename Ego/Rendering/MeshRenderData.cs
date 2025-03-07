using Rendering.Materials;

namespace Rendering;

public struct MeshRenderData
{
    public MeshData MyMeshData;
    public Material Material;
    public Matrix4x4 WorldMatrix;
}