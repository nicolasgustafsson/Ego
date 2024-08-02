using ImGuiNET;
using Rendering;

namespace Ego;

public class MeshRenderer(string aModelPath = "Models/basicmesh.glb") : Node3D
{
    private MeshCollection Meshes = null!;

    private int MeshIndex = 0;

    public override void Start()
    {
        base.Start();
        Meshes = Context.Get<AssetManager>()!.GetAsset<MeshCollection>(aModelPath);
        
        Context.Get<RendererApi>()!.ERender += ERender;
    }

    public override void Inspect()
    {
        base.Inspect();
        ImGui.SliderInt("Mesh Index", ref MeshIndex, 0, Meshes.Meshes.Count - 1);
    }

    private void ERender(List<MeshRenderData> aRenderData)
    {
        aRenderData.Add(new() { Mesh = Meshes.Meshes[MeshIndex], WorldMatrix = WorldMatrix });
    }
}