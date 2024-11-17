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
        AddChild(new SinusoidalMovement()).AddChild(new Node()).AddChild(new MeshRenderer()).LocalPosition += new Vector3(2f, 2f, 0f);
        AddChild(new Camera()).LocalPosition += new Vector3(0f, 0f, -7.5f);
        
        while (!Window.IsClosing)
        {
            EUpdate();

            RendererApi.Update();
            Window.Update();
        }

        Destroy();
    }
}