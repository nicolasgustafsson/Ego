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
        
        //Could not specify with --project, so instead we set current directory. Likely I did something wrong.
        Directory.SetCurrentDirectory(aProjectPath);
        WatchProcess = Process.Start($"dotnet",  "watch build");
        Directory.SetCurrentDirectory(currentDirectory);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        
        WatchProcess?.Kill();
    }
}
