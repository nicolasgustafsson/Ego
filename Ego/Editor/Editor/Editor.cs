using ImageMagick;
using MessagePack;
using NativeFileDialogs.Net;
using Rendering;
using Vortice.Vulkan;
using VulkanApi;

namespace Editor;

[Node]
public partial class Editor : Node
{
    private ProjectEditor ProjectEditor = null!;
    public LandingArea? LandingArea = null!;
    public TopMenu TopMenu = null!;

    public MeshRenderer MeshRenderer;
    private string EditorDirectory;

    public static Editor Instance;
    public override void Start()
    {
        EditorDirectory = Environment.CurrentDirectory;
        Instance = this;
        base.Start();
        
        MessagePackSerializer.DefaultOptions = MessagePack.Resolvers.ContractlessStandardResolver.Options;
        ProjectEditor = AddChild(new ProjectEditor());
        LandingArea = AddChild(new LandingArea());
        TopMenu = AddChild(new TopMenu());
    }
    
    public void SelectProject()
    {
        if (Nfd.OpenDialog(out string? outPath, new Dictionary<string, string>()
        {
            { "Project File", "csproj" },
        }) == NfdStatus.Ok && outPath != null)
        {
            ProjectEditor.Instance.SelectProject(outPath);
        }
    }
    
    public void Inspect()
    {
        DefaultInspect();
        
        if (Imgui.Button("Import Texture"))
        {
            if (Nfd.OpenDialog(out string? outPath, new Dictionary<string, string>()
            {
                { "Texture", "png" },
            }) == NfdStatus.Ok && outPath != null)
            {
                ImportCommand command = new(outPath);
                command.Do();
            }
        }
    }
}
