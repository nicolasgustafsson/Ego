using ImGuiNET;
using Rendering;
namespace Ego;

[Node]
public partial class MeshRenderer : Node3D
{
    public MeshRenderer()
    {
        
    }
    
    private string ModelPath = "Models/basicmesh.glb";
    private MeshCollection MeshCollection = null!;

    [Serialize] private int MeshIndex = 0;

    public override void Start()
    {
        base.Start();
        MeshCollection = AssetManager.GetAsset<MeshCollection>(ModelPath); 
    }

    protected override void Update()
    {
        RendererApi.RenderMesh(new(){MyMeshData = MeshCollection.Meshes[MeshIndex], WorldMatrix = WorldMatrix}); 
    }

    private void Inspect()
    {
        ImGui.SliderInt("Mesh Index", ref MeshIndex, 0, MeshCollection.Meshes.Count - 1);
    }
}