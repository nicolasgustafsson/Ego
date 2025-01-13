using System.Data;
using System.Reflection;
using System.Runtime.Loader;
using ImGuiNET;
using McMaster.NETCore.Plugins;
using MessagePack;

namespace Editor;

public class Editor : Node
{
    public static Assembly? GameAssembly;
    private PluginLoader? MyPluginLoader;
    string BinaryPath = "C:\\Users\\Nicos\\Desktop\\Projects\\TestGame\\TestGame\\bin\\net9.0\\TestGame.dll";

    private SceneEditor SceneEditor = null!;
    private DotNetApi Api;
    
    private bool WantsHotReload = false;

    public override void Start()
    {
        Api = AddChild(new DotNetApi());
        
        Directory.SetCurrentDirectory("C:\\Users\\Nicos\\Desktop\\Projects\\TestGame\\TestGame\\bin\\net9.0\\");

        Api.Watch("C:\\Users\\Nicos\\Desktop\\Projects\\TestGame\\TestGame\\");
        
        base.Start();
        Debug.EDebug += DebugWindow;
        MessagePackSerializer.DefaultOptions = MessagePack.Resolvers.ContractlessStandardResolver.Options;
        
        LoadBinary(BinaryPath);
        
        SceneEditor = AddChild(new SceneEditor());
        CreateTestNode();

    }
    
    private void UpdateAssembly()
    {
        GameAssembly = MyPluginLoader!.LoadDefaultAssembly();
        
        Log.Information($"Loaded Assembly {GameAssembly.FullName}");

        NodeTypeDatabase.Build(GameAssembly);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Debug.EDebug -= DebugWindow;
        MyPluginLoader?.Dispose();
    }
    
    private void LoadBinary(string aBinaryPath)
    {
        try
        {
            PluginLoader plugin = PluginLoader.CreateFromAssemblyFile(aBinaryPath, config =>
            {
                config.PreferSharedTypes = true;
                config.IsUnloadable = true;
                config.EnableHotReload = true;
            });

            plugin.Reloaded += (_, _) => WantsHotReload = true;
            
            MyPluginLoader = plugin;

            UpdateAssembly();
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
        }
    }

    protected override void Update()
    {
        base.Update();
        if (WantsHotReload)
            HotReload();
    }

    private void HotReload()
    {
        WantsHotReload = false;
        Log.Information($"Hot Reload Started");
        Log.Information($"Destroying Scene...");
        SceneEditor.PrepareForHotReload();
        UpdateAssembly();
        Log.Information($"Assemblies Updated!");
        Log.Information($"Recreating Scene...");
        SceneEditor.ReinitializeAfterHotReload();
        Log.Information($"Scene reconstruction complete!");
        Log.Information($"Hot Reload Finished!");
    }

    private void DebugWindow()
    {
        ImGui.Begin("Test");

        bool hasLoadedGameBinary = MyPluginLoader != null;
        if (hasLoadedGameBinary)
            ImGui.BeginDisabled();
        
        if (ImGui.Button("Load Game Binary"))
        {
            LoadBinary(BinaryPath);
        }

        if (hasLoadedGameBinary)
            ImGui.EndDisabled();

        ImGui.SameLine();
        ImGui.PushID("Gamer");
        ImGui.InputText("", ref BinaryPath, 255);
        ImGui.PopID();

        if (!hasLoadedGameBinary)
            ImGui.BeginDisabled();
        
        if (ImGui.Button("Create the node"))
        {
            CreateTestNode();
        }

        if (!hasLoadedGameBinary)
            ImGui.EndDisabled();
        
        ImGui.End();
    }

    private void CreateTestNode()
    {
        Type? gameTestType = GameAssembly!.GetExportedTypes().FirstOrDefault(type => type.Name == "Root");

        if (gameTestType != null)
        {
            Node instance = (Activator.CreateInstance(gameTestType) as Node)!;
                
            SceneEditor.AddChild(instance);
        }
    }
}
