using System.Diagnostics;
using Serilog.Core;

namespace Ego;

[Node(AllowAddingToScene = false)]
public partial class EgoContext : Node, IEgoContextProvider
{
    public new TimeKeeper Time { get; private set; } = null!;
    public new Window Window { get; private set; } = null!;
    public new Debug Debug { get; private set; } = null!;
    public new RendererApi RendererApi { get; private set; } = null!;
    public new AssetManager AssetManager { get; private set; } = null!;
    public new TreeInspector TreeInspector { get; private set; } = null!;
    public new MultithreadingManager MultithreadingManager { get; private set; } = null!;
    public new PerformanceMonitor PerformanceMonitor { get; private set; } = null!;
    public new NodeTypeDatabase NodeTypeDatabase { get; private set; } = null!;

    private List<Func<LoggerConfiguration, LoggerConfiguration>> LoggerConfigHooks = new();
    private Logger? Logger = null;

    public void Run<T>() where T : Node, new()
    {
        Run<T>(new());
    }
    
    private void CreateLogger()
    {
        if (Logger != null)
            Logger.Dispose();

        LoggerConfiguration config = new LoggerConfiguration().WriteTo.Console().Enrich.FromLogContext();
        
        foreach(var hook in LoggerConfigHooks)
        {
            config = hook(config);
        }
        
        Logger = config.CreateLogger();
        
        Log.Logger = Logger;
    }
    
    public void AddLoggerConfigHook(Func<LoggerConfiguration, LoggerConfiguration> aLoggerConfigHook)
    {
        LoggerConfigHooks.Add(aLoggerConfigHook);

        CreateLogger();
    }
    
    public void Run<T>(EngineInitSettings aSettings, Action<T>? aSetup = null) where T : Node, new()
    {
        CreateLogger();
        MyContext = this;
        
        NodeTypeDatabase = AddChild(new NodeTypeDatabase());

        //Important that this is high up - it's Update will launch off any parallel tasks
        MultithreadingManager = AddChild(new MultithreadingManager());
        
        Time = AddChild(new TimeKeeper());
        Window = new Window(aSettings.Name, aSettings.WindowSize);
        RendererApi = AddChild(new RendererApi(Window, aSettings.RendererInitSettings));
        Debug = AddChild(new Debug());
        AssetManager = AddChild(new AssetManager());
        TreeInspector = AddChild(new TreeInspector());
        PerformanceMonitor = AddChild(new PerformanceMonitor());
        
        T childObject = AddChild(new T());

        if (aSetup != null)
            aSetup(childObject);

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