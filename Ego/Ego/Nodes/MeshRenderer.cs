using ImGuiNET;
using Rendering;
namespace Ego;

public class MeshCollection : Node, IAsset
{
    public List<Mesh> Meshes = null!;
    protected override string Name => FileName;

    private string FileName = "Unknown";
    
    public void LoadFrom(string aPath)
    {
        FileName = Path.GetFileNameWithoutExtension(aPath);
        
        lock(RendererApi.MyRenderData)
        {
            Meshes = Mesh.LoadGltf(RendererApi.Renderer!, aPath);
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();

        RendererApi.WaitUntilIdle();
        
        foreach(var mesh in Meshes)
        {
            mesh.Destroy();
        }
    }
}

public class MeshRenderer(string aModelPath = "Models/basicmesh.glb") : Node3D
{
    private MeshCollection Meshes = null!;

    private int MeshIndex = 0;

    public override void Start()
    {
        base.Start();
        Meshes = AssetManager.GetAsset<MeshCollection>(aModelPath);
        
    }

    protected override void Update()
    {
        RendererApi.AddRenderData(new(){Mesh = Meshes.Meshes[MeshIndex], WorldMatrix = WorldMatrix});
    }


    public override void Inspect()
    {
        base.Inspect();
        ImGui.SliderInt("Mesh Index", ref MeshIndex, 0, Meshes.Meshes.Count - 1);
    }
}