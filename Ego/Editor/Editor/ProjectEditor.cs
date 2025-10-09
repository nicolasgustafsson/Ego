using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.Loader;
using ImGuiNET;
using MessagePack;

namespace Editor;

[Node]
public partial class ProjectEditor : Node
{
    public static ProjectEditor Instance = null!;
    
    public SceneEditor SceneEditor = null!;
    public DotNetApi DotNetApi = null!;
    public GameProjectAssemblyLoader GameProjectAssemblyLoader = null!;

    private string GameProjectDllPath = "";
    
    public ProjectEditor()
    {
        Instance = this;
    }

    public override void Start()
    {
        DotNetApi = AddChild(new DotNetApi());
        
        GameProjectAssemblyLoader = AddChild(new GameProjectAssemblyLoader());
        //SelectProject("../../ExampleProject/ExampleProject.csproj");
    }
    
    public void SelectProject(string aCsProj)
    {
        try
        {
            string absolutePath = Path.GetFullPath(aCsProj);
            string directory = Path.GetDirectoryName(absolutePath)! + "/";
            string projectName = Path.GetFileNameWithoutExtension(aCsProj);
            string dllName = projectName + ".dll";
            string workingDirectory = directory + "Binaries/";
            
            Directory.SetCurrentDirectory(workingDirectory);

            DotNetApi.Watch(directory);
            
            GameProjectDllPath = workingDirectory + dllName;
            GameProjectAssemblyLoader.SelectGameProjectDll(GameProjectDllPath);

            Window.SetTitle($"Editor: {projectName}");

            SceneEditor?.Destroy();
            SceneEditor = AddChild(new SceneEditor());

            Editor.Instance.LandingArea?.Destroy();
            Editor.Instance.LandingArea = null;
        }
        catch (Exception e)
        {
            Log.Error($"{e.ToString()}");
            Log.Error($"Could not load project! Make sure that the project path exists, project names and binaries match, and that output paths are set up correctly. See ExampleProject for an example on how to set things up.");
        }
    }
}
