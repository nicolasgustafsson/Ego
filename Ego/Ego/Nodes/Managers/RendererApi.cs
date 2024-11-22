using Rendering;

namespace Ego;

public class RendererApi : Node
{
    public Action<List<MeshRenderData>> ERender = (_) => {};
    private Renderer Renderer = null!;

    private List<MeshRenderData> myRenderData = new();
    private Matrix4x4 myCameraView = new();
    
    public RendererApi(Window aWindow)
    {
        Renderer = AddChild(new Renderer(aWindow));
    }
    
    public override void Start()
    {
        Task.Run(RenderMultithreaded);
    }

    public void Update()
    {
        List<MeshRenderData> renderData = new();
        ERender(renderData);

        lock(myRenderData)
        {
            myRenderData = renderData;
        }
    }
    
    public async Task RenderMultithreaded()
    {
        await Task.Delay(10);
        while(true)
        {
            lock(myRenderData)
            {
                Renderer.SetRenderData(myRenderData);
                Renderer.SetCameraView(myCameraView);
            }
            
            Renderer.Render();
        }
    }
    
    public void SetCameraView(Matrix4x4 aView)
    {
        lock(myRenderData)
        {
            myCameraView = aView;
        }
    }
}