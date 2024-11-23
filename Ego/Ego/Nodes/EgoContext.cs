using System.Diagnostics;
using Rendering;

namespace Ego;

public class EgoContext : Context
{
    public TimeKeeper Time = null!;
    public Window Window = null!;
    public Debug Debug = null!;
    public RendererApi RendererApi = null!;
    public AssetManager AssetManager = null!;
    public TreeInspector TreeInspector = null!;

    
    public void Run()
    {
        Time = AddChild(new TimeKeeper());
        Window = AddChild(new Window("Game", new Vector2(1920, 1080)));
        RendererApi = AddChild(new RendererApi(Window));
        Debug = AddChild(new Debug());
        AssetManager = AddChild(new AssetManager());
        TreeInspector = AddChild(new TreeInspector());
        
        AddChild(new SinusoidalMovement()).AddChild(new Node()).AddChild(new MeshRenderer());
        
        for(int i = 0; i < 1000 * 100; i++)
        {
            AddChild(new SinusoidalMovement()).AddChild(new Node()).AddChild(new MeshRenderer());
        }
        AddChild(new SinusoidalMovement()).AddChild(new Node()).AddChild(new MeshRenderer()).LocalPosition += new Vector3(2f, 2f, 0f);
        AddChild(new Camera()).LocalPosition += new Vector3(0f, 0f, -7.5f);

        Stopwatch watch = new();
        while (!Window.IsClosing)
        {
            watch.Restart();
            
            Task renderFrame = Task.Run(RendererApi.RenderFrame);
            
            EUpdate();

            RendererApi.Update();

            Console.WriteLine($"Time passed update = {watch.ElapsedMilliseconds}");
            
            renderFrame.Wait();
            
            Window.Update();

            Console.WriteLine($"Time passed total = {watch.ElapsedMilliseconds}");
        }

        Destroy();
    }
}