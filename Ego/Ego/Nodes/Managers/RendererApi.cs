using Rendering;

namespace Ego;

public class RendererApi : Node
{
    public Action<List<MeshRenderData>> ERender = (_) => {};
    private Renderer Renderer = null!;

    private List<MeshRenderData> myRenderData = new();
    private Matrix4x4 myCameraView = new();
    private bool myWantsToDie = false;
    private bool myCanDie = false;
    
    public RendererApi(Window aWindow)
    {
        Renderer = AddChild(new Renderer(aWindow));
    }
    
    public override void Start()
    {
        Task.Run(RenderMultithreaded);
    }

    protected override void DestroyChildren()
    {
        lock(myRenderData)
        {
            lock(Renderer.MainWindow)
            {
                base.DestroyChildren();
                myWantsToDie = true;
            }
        }
    }
    
    public void WaitUntilIdle()
    {
        lock(myRenderData)
        {
            Renderer.WaitUntilIdle();
        }
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
        while(!myWantsToDie)
        {
            lock(myRenderData)
            {
                Renderer.SetRenderData(myRenderData);
                Renderer.SetCameraView(myCameraView);
            }
            
            Renderer.Render();

            await Task.Yield();
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