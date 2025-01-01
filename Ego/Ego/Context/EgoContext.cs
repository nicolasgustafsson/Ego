using System.Diagnostics;

namespace Ego;

public class EgoContext : Node, IEgoContextProvider
{
    public new TimeKeeper Time { get; private set; } = null!;
    public new Window Window { get; private set; } = null!;
    public new Debug Debug { get; private set; } = null!;
    public new ParallelBranch<RendererApi> RendererApi { get; private set; } = null!;
    public new AssetManager AssetManager { get; private set; } = null!;
    public new TreeInspector TreeInspector { get; private set; } = null!;
    public new MultithreadingManager MultithreadingManager { get; private set; } = null!;
    
    public void Run()
    {
        using var log = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        Log.Logger = log;
        
        MyContext = this;

        //Important that this is high up - it's Update will launch off any parallel tasks
        MultithreadingManager = AddChild(new MultithreadingManager());
        
        Time = AddChild(new TimeKeeper());
        Window = new Window("Game", new Vector2(1920, 1080));
        RendererApi = AddChild(new ParallelBranch<RendererApi>(new RendererApi(Window)));
        Debug = AddChild(new Debug());
        AssetManager = AddChild(new AssetManager());
        TreeInspector = AddChild(new TreeInspector());
        
        AddChild(new SinusoidalMovement()).AddChild(new Node3D()).AddChild(new MeshRenderer());
        
        for(int i = 0; i < 10 * 1; i++)
        {
            AddChild(new SinusoidalMovement()).AddChild(new Node3D()).AddChild(new MeshRenderer());
        }
        
        AddChild(new SinusoidalMovement()).AddChild(new Node3D()).AddChild(new MeshRenderer()).LocalPosition += new Vector3(2f, 2f, 0f);
        AddChild(new Camera()).LocalPosition += new Vector3(0f, 0f, -7.5f);

        while (!Window.IsClosing)
        {
            SingleFrame();
        }

        Destroy();
    }
    
    public void SingleFrame()
    {
        Stopwatch watch = new();
        
        watch.Restart();

        MultithreadingManager.HandleMessages();

        Task work = MultithreadingManager.RunParallelTasks();

        UpdateInternal();

        Log.Information($"Time passed update = {watch.ElapsedMilliseconds}ms");
        
        work.Wait();
        
        Window.PollEvents();

        Log.Information($"Time passed total = {watch.ElapsedMilliseconds}ms");
    }
}