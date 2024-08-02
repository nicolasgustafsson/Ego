using Rendering;

namespace Ego;

public class RendererApi : Node
{
    public Action<List<MeshRenderData>> ERender = (_) => {};
    
    public override void Start()
    {
        Context.EUpdate += Update;
    }
    
    private void Update()
    {
        List<MeshRenderData> renderData = new();
        ERender(renderData);
        
        Context.Get<Renderer>()!.SetRenderData(renderData);
    }
}