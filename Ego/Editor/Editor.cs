using System.Data;
using System.Reflection;
using ImGuiNET;
using McMaster.NETCore.Plugins;

namespace Editor;

public class Editor : Node
{
    private Assembly GameAssembly;
    private PluginLoader MyPluginLoader;
    
    public override void Start()
    {
        base.Start();
        Debug.EDebug += DebugWindow;
        PluginLoader plugin = PluginLoader.CreateFromAssemblyFile(AppContext.BaseDirectory + "GameTest.dll", config =>
        {
            config.PreferSharedTypes = true;
            config.EnableHotReload = true;
        });

        plugin.Reloaded += (_, _) => 
        { 
            Log.Information("Yeah we're reloading");
            GameAssembly = plugin.LoadDefaultAssembly();
        };

        MyPluginLoader = plugin;

        GameAssembly = plugin.LoadDefaultAssembly();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Debug.EDebug -= DebugWindow;
        MyPluginLoader.Dispose();
    }

    private void DebugWindow()
    {
        ImGui.Begin("Test");

        if (ImGui.Button("Create the node"))
        {
            Type gameTestType = GameAssembly.GetExportedTypes().FirstOrDefault(type => type.Name == "TestNode");
            
            if (gameTestType != null)
            {
                Node instance = (Activator.CreateInstance(gameTestType) as Node)!;
                AddChild(instance);
            }
        }
        
        ImGui.End();
    }
}
