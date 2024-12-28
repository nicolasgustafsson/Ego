using System.Diagnostics;

namespace Ego;

public class EgoContext : Node, IEgoContextProvider
{
    public new TimeKeeper Time { get; set; } = null!;
    public new Window Window { get; set; } = null!;
    public new Debug Debug { get; set; } = null!;
    public new RendererApi RendererApi { get; set; } = null!;
    public new AssetManager AssetManager { get; set; } = null!;
    public new TreeInspector TreeInspector { get; set; } = null!;
    
    public void Run()
    {
        using var log = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        Log.Logger = log;
        
        MyContext = this;
        
        Time = AddChild(new TimeKeeper());
        Window = new Window("Game", new Vector2(1920, 1080));
        RendererApi = AddChild(new RendererApi(Window));
        Debug = AddChild(new Debug());
        AssetManager = AddChild(new AssetManager());
        TreeInspector = AddChild(new TreeInspector());
        
        AddChild(new SinusoidalMovement()).AddChild(new Node3D()).AddChild(new MeshRenderer());
        
        for(int i = 0; i < 1000 * 100; i++)
        {
            //AddChild(new SinusoidalMovement()).AddChild(new Node3D()).AddChild(new MeshRenderer());
        }
        
        AddChild(new SinusoidalMovement()).AddChild(new Node3D()).AddChild(new MeshRenderer()).LocalPosition += new Vector3(2f, 2f, 0f);
        AddChild(new Camera()).LocalPosition += new Vector3(0f, 0f, -7.5f);

        Stopwatch watch = new();
        while (!Window.IsClosing)
        {
            watch.Restart();
            
            Task renderFrame = Task.Run(RendererApi.RenderFrame);

            UpdateInternal();

            Log.Information($"Time passed update = {watch.ElapsedMilliseconds}ms");
            
            renderFrame.Wait();
            
            Window.PollEvents();

            Log.Information($"Time passed total = {watch.ElapsedMilliseconds}ms");
        }

        Destroy();
    }
}