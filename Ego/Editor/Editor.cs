using System.Data;
using System.Reflection;
using ImGuiNET;
using McMaster.NETCore.Plugins;

namespace Editor;

public class Editor : Node
{
    private Assembly GameAssembly;
    
    public override void Start()
    {
        base.Start();
        Debug.EDebug += DebugWindow;
        PluginLoader plugin = PluginLoader.CreateFromAssemblyFile(AppContext.BaseDirectory + "GameTest.dll");

        GameAssembly = plugin.LoadDefaultAssembly();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Debug.EDebug -= DebugWindow;
    }

    private void DebugWindow()
    {
        ImGui.Begin("Test");

        if (ImGui.Button("Print the thing"))
        {
            Type gameTestType = GameAssembly.GetExportedTypes().First(type => type.Name == "GameTest");
            
            if (gameTestType != null)
            {
                gameTestType.GetMethod("Yipee").Invoke(null, null);
            }
        }
        
        ImGui.End();
    }
}
