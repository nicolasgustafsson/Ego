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
    string BinaryPath = "C:\\Users\\Nicos\\Desktop\\Projects\\TestGame\\TestGame\\TestGame\\bin\\net9.0\\TestGame.dll";

    private SceneEditor SceneEditor;

    public override void Start()
    {
        Directory.SetCurrentDirectory("C:\\Users\\Nicos\\Desktop\\Projects\\TestGame\\TestGame\\TestGame\\bin\\net9.0\\");
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
        
        GameAssembly!.GetExportedTypes().FirstOrDefault(type => type.Name == "Serialization").GetMethod("SetAssembly").Invoke(null, new[]{GameAssembly});
        
        Log.Information($"Loaded Assembly {GameAssembly.FullName}");
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

            plugin.Reloaded += (_,_) => HotReload();
            
            MyPluginLoader = plugin;

            UpdateAssembly();
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
        }
    }

    private void HotReload()
    {
        Log.Information($"Hot Reload Started");
        Log.Information($"Destroying Scene...");
        SceneEditor.SerializeScene();
        UpdateAssembly();
        Log.Information($"Reload complete!");
        Log.Information($"Recreating Scene...");
        SceneEditor.DeserializeScene();
        Log.Information($"Scene reconstruction complete!");
        Log.Information($"Hot Reload Finished!");
    }
    private void FinalizeHotReload()
    {
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
        Type? gameTestType = GameAssembly!.GetExportedTypes().FirstOrDefault(type => type.Name == "TestNode");

        if (gameTestType != null)
        {
            Node instance = (Activator.CreateInstance(gameTestType) as Node)!;
                
            SceneEditor.AddChild(instance);
        }
    }
}
