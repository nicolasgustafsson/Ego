﻿using System.Diagnostics;
using System.Drawing;

namespace Editor;

[Node]
public partial class DotNetApi : Node
{
    private Process? WatchProcess;
    private CancellationTokenSource CancellationTokenSource = new();
    
    public void Watch(string aProjectPath)
    {
        CancellationTokenSource.Cancel();
        CancellationTokenSource = new();
        
        WatchProcess?.Kill();
        string currentDirectory = Directory.GetCurrentDirectory();
        
        //Could not specify with --project, so instead we set current directory. Likely I did something wrong.
        Directory.SetCurrentDirectory(aProjectPath);
        ProcessStartInfo startInfo = new();
        startInfo.FileName = "dotnet";
        
        //--no-restore speeds rebuilds up(1.45s -> 1.05s) at the cost of not handling dependencies. This means that if we add a nuget package we need to restart the editor right now.
        startInfo.Arguments = "watch build --no-restore"; 
        
        startInfo.RedirectStandardOutput = true;
        WatchProcess = Process.Start(startInfo);
        Directory.SetCurrentDirectory(currentDirectory);
        ReadWatchOutput(CancellationTokenSource.Token);
    }
    
    private async Task ReadWatchOutput(CancellationToken aToken)
    {
        while (!aToken.IsCancellationRequested)
        {
            while (WatchProcess == null)
                await Task.Delay(100, aToken);
            
            string? nextLine = await WatchProcess.StandardOutput.ReadLineAsync(aToken);
            if (nextLine != null)
                HandleWatchLog(nextLine);
        }
    }
    
    private void HandleWatchLog(string aLine)
    {
        if (aLine.Contains("Determining projects to restore..."))
        {
            Editor.Instance.TopMenu.SetColor(Color.Yellow, "Building...!");
        }
        if (aLine.Contains("Build succeeded."))
        {
            Editor.Instance.TopMenu.Flash(Color.LawnGreen, "Build succeeded!");
        }
        else if (aLine.Contains("Build FAILED."))
        {
            Editor.Instance.TopMenu.Flash(Color.Red, "Build failed!");
        }
        else
        {
            Log.Info($"{aLine}");
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        
        WatchProcess?.Kill();
    }
}
