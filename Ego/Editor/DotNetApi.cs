using System.Diagnostics;

namespace Editor;

[Node]
public partial class DotNetApi : Node
{
    private Process? WatchProcess;
    
    
    public void Watch(string aProjectPath)
    {
        WatchProcess?.Kill();
        string currentDirectory = Directory.GetCurrentDirectory();
        Directory.SetCurrentDirectory(aProjectPath);
        WatchProcess = Process.Start($"dotnet",  "watch build");// --project {aProjectPath}");
        Directory.SetCurrentDirectory(currentDirectory);
    }
    

    public override void OnDestroy()
    {
        base.OnDestroy();
        
        WatchProcess?.Kill();
    }
}
