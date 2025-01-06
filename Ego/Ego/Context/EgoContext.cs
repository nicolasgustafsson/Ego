using System.Diagnostics;
using Serilog.Core;

namespace Ego;

public class EgoContext : Node, IEgoContextProvider
{
    public new TimeKeeper Time { get; private set; } = null!;
    public new Window Window { get; private set; } = null!;
    public new Debug Debug { get; private set; } = null!;
    public new RendererApi RendererApi { get; private set; } = null!;
    public new AssetManager AssetManager { get; private set; } = null!;
    public new TreeInspector TreeInspector { get; private set; } = null!;
    public new MultithreadingManager MultithreadingManager { get; private set; } = null!;
    public new PerformanceMonitor PerformanceMonitor { get; private set; } = null!;
    
    public void Run<T>() where T : Node, new()
    {
        using Logger log = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        Log.Logger = log;
        
        MyContext = this;

        //Important that this is high up - it's Update will launch off any parallel tasks
        MultithreadingManager = AddChild(new MultithreadingManager());
        
        Time = AddChild(new TimeKeeper());
        Window = new Window("Game", new Vector2(1920, 1080));
        RendererApi = AddChild(new RendererApi(Window));
        Debug = AddChild(new Debug());
        AssetManager = AddChild(new AssetManager());
        TreeInspector = AddChild(new TreeInspector());
        PerformanceMonitor = AddChild(new PerformanceMonitor(180));

        while (!Window.IsClosing)
        {
            SingleFrame();
        }

        Destroy();
    }
    
    private void SingleFrame()
    {
        var trace = PerformanceMonitor.StartTrace();

        MultithreadingManager.UpdateSynchronous();

        Task work = MultithreadingManager.RunParallelTasks();

        UpdateInternal();

        trace.Trace("Update");
        
        work.Wait();
        
        Window.PollEvents();

        trace.Trace("Total");
    }
}