using Ego.Nodes;
using Ego.Systems;
using Rendering;
using Debug = Ego.Systems.Debug;

namespace Ego;

public class EgoContext : Node
{
    public TimeKeeper Time = null!;
    public Window Window = null!;
    public Debug Debug = null!;
    public Renderer Renderer = null!;
    public RendererApi RendererApi = null!;

    public Action EUpdate = ()=>{};
    
    public void Run()
    {
        Time = AddChild(new TimeKeeper());
        Window = AddChild(new Window("Game", new Vector2(1920, 1080)));
        Renderer = AddChild(new Renderer(Window));
        Debug = AddChild(new Debug());
        RendererApi = AddChild(new RendererApi());
        
        AddChild(new SinusoidalMovement()).AddChild(new Node()).AddChild(new MeshRenderer());
        AddChild(new SinusoidalMovement()).AddChild(new Node()).AddChild(new MeshRenderer()).LocalPosition += new Vector3(2f, 2f, 0f);
        AddChild(new Camera());
        
        while (!Window.IsClosing)
        {
            EUpdate();

            Renderer.Render();
            Window.Update();
        }

        Destroy();
    }
}