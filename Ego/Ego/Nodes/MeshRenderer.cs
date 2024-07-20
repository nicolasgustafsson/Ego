using Rendering;

namespace Ego.Nodes;

public class MeshRenderer : Node3D
{
    private Mesh[] Meshes;
    public MeshRenderer()
    {
        Meshes = Mesh.LoadGltf(Program.Context.Renderer, "Models/basicmesh.glb").Skip(2).Take(1).ToArray();
        
        Program.Context.RendererApi.ERender += ERender;
    }

    private void ERender(List<MeshRenderData> aRenderData)
    {
        foreach(var mesh in Meshes)
        {
            aRenderData.Add(new() { Mesh = mesh, WorldMatrix = WorldMatrix });
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();

        foreach (var mesh in Meshes)
            mesh.Destroy();
    }
}