using Rendering;

namespace Ego;

public class RendererApi : Node
{
    public Action<List<MeshRenderData>> ERender = (_) => {};
    
    public RendererApi()
    {
        Program.Context.EUpdate += Update;
    }
    
    private void Update()
    {
        List<MeshRenderData> renderData = new();
        ERender(renderData);
        
        Program.Context.Renderer.SetRenderData(renderData);
    }
}