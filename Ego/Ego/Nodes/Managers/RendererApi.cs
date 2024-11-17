using Rendering;

namespace Ego;

public class RendererApi : Node
{
    public Action<List<MeshRenderData>> ERender = (_) => {};
    public Renderer Renderer = null!;
    
    public RendererApi(Window aWindow)
    {
        Renderer = AddChild(new Renderer(aWindow));
    }
    
    public override void Start()
    {
    }

    public void Update()
    {
        List<MeshRenderData> renderData = new();
        ERender(renderData);
        Renderer.SetRenderData(renderData);
        Renderer.Render();
    }
}