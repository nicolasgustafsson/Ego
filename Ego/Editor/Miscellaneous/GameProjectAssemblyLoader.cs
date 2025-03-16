using System.Reflection;

namespace Editor;
using McMaster.NETCore.Plugins;

[Node]
public partial class GameProjectAssemblyLoader : Node
{
    public static Assembly? GameAssembly;
    private PluginLoader? MyPluginLoader;
    private bool WantsHotReload = false;
    
    private void UpdateAssembly()
    {
        GameAssembly = MyPluginLoader!.LoadDefaultAssembly();
        
        Log.Information($"Loaded Assembly {GameAssembly.FullName}");

        NodeTypeDatabase.Build(GameAssembly);
    }
    
    protected override void Update()
    {
        base.Update();
        /*if (WantsHotReload)
            HotReload();*/
    }

    private void HotReload()
    {
        WantsHotReload = false;

        Log.Information($"Hot Reload Started");
        Log.Information($"Destroying Scene...");
        ProjectEditor.Instance.SceneEditor.PrepareForHotReload();
        UpdateAssembly();
        Log.Information($"Assemblies Updated!");
        Log.Information($"Recreating Scene...");
        ProjectEditor.Instance.SceneEditor.ReinitializeAfterHotReload();
        Log.Information($"Scene reconstruction complete!");
        Log.Information($"Hot Reload Completed!");
    }
    
    public void SelectGameProjectDll(string aBinaryPath)
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

            if (MyPluginLoader != null)
                MyPluginLoader.Dispose();
            
            MyPluginLoader = plugin;

            UpdateAssembly();
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
        }
    }
    
    public override void OnDestroy()
    {
        base.OnDestroy();
        MyPluginLoader?.Dispose();
    }
}
