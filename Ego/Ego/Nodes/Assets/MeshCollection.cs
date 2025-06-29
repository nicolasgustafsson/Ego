using Ego;
using Rendering;

namespace Ego;

[Node(AllowAddingToScene = false)]
public partial class MeshCollection : Node, IFileAsset
{
    public List<MeshData> Meshes = null!;
    protected override string Name => FileName;

    private string FileName = "Unknown";
    
    public void LoadFrom(string aPath)
    {
        FileName = Path.GetFileNameWithoutExtension(aPath);

        Meshes = MeshData.LoadGltf(RendererApi.Renderer, aPath);
    }

    /*Task LoadFromAsync(string aPath)
    {
        
    }*/

    public override void OnDestroy()
    {
        base.OnDestroy();

        RendererApi.WaitUntilIdle();
        
        foreach(MeshData mesh in Meshes)
        {
            mesh.Destroy();
        }
    }
}