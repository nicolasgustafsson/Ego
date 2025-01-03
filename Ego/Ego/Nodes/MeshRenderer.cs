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

        Meshes = Mesh.LoadGltf(RendererApi.Renderer, aPath);
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

public class MeshRenderer(string ModelPath = "Models/basicmesh.glb") : Node3D
{
    private MeshCollection MeshCollections = null!;

    private int MeshIndex = 0;

    public override void Start()
    {
        base.Start();
        MeshCollections = AssetManager.GetAsset<MeshCollection>(ModelPath);
        
    }

    protected override void Update()
    {
        RendererApi.RegisterMesh(new(){Mesh = MeshCollections.Meshes[MeshIndex], WorldMatrix = WorldMatrix});
    }

    public override void Inspect()
    {
        base.Inspect();
        ImGui.SliderInt("Mesh Index", ref MeshIndex, 0, MeshCollections.Meshes.Count - 1);
    }
}