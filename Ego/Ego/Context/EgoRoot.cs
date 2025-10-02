using System.Diagnostics;
using Microsoft.Extensions.Logging;
using ZLogger;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Ego;

[Node(AllowAddingToScene = false)]
public partial class EgoRoot : Node
{
    public void Run<T>() where T : Node, new()
    {
        Run<T>(new());
    }
    
    private void CreateLogger()
    {
        var factory = LoggerFactory.Create(logging =>
        {
            logging.SetMinimumLevel(LogLevel.Trace);
            logging.AddZLoggerConsole();
        });

        Log = factory.CreateLogger("Ego");
    }
    
    public void Run<T>(EngineInitSettings aSettings, Action<T>? aSetup = null) where T : Node, new()
    {
        CreateLogger();
        MyContext = new();
        
        MyContext.NodeTypeDatabase = AddChild(new NodeTypeDatabase());

        //Important that this is high up - its Update will launch off any parallel tasks
        MyContext.MultithreadingManager = AddChild(new MultithreadingManager());
        
        MyContext.Time = AddChild(new TimeKeeper());
        MyContext.Window = new Window(aSettings.Name, aSettings.WindowSize);
        MyContext.RendererApi = AddChild(new RendererApi(Window, aSettings.RendererInitSettings));
        MyContext.Debug = AddChild(new Debug());
        MyContext.AssetManager = AddChild(new AssetManager());
        MyContext.TreeInspector = AddChild(new TreeInspector());
        MyContext.PerformanceMonitor = AddChild(new PerformanceMonitor());
        MyContext.MaterialBuilder = AddChild(new MaterialBuilder());
        
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
        
        //Nicos: Alleviates GC spikes - 20ms spikes in debug mode was what triggered me to do this, it might not be needed in release builds.
        //GC.Collect(0);
        
        trace.Trace("Manual GC collection");
        
        MultithreadingManager.UpdateSynchronous();

        Task work = MultithreadingManager.RunParallelTasks();
        
        trace.Trace("Multithreading");
        
        UpdateInternal();

        trace.Trace("Update");
        
        work.Wait();
        
        Window.PollEvents();

        trace.Trace("Total");
    }
}