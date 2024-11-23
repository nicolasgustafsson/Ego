using System.Diagnostics;
using Rendering;

namespace Ego;

public class RendererApi : Node
{
    public Action<List<MeshRenderData>> ERender = (_) => {};
    private Renderer Renderer = null!;

    public List<MeshRenderData> MyRenderData = new();
    public List<MeshRenderData> MyPreviousList = new();
    private Matrix4x4 myCameraView = new();
    private bool myWantsToDie = false;
    private bool myCanDie = false;
    
    public RendererApi(Window aWindow)
    {
        Renderer = AddChild(new Renderer(aWindow));
    }
    
    public override void Start()
    {
    }

    protected override void DestroyChildren()
    {
        lock(MyRenderData)
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
        lock(MyRenderData)
        {
            Renderer.WaitUntilIdle();
        }
    }

    private static bool firstTime = true;
    public void Update()
    {
        Stopwatch watch = new();
        watch.Start();
        List<MeshRenderData> renderData = MyPreviousList;

        int previousSize = renderData.Count;
        renderData.Clear();
        renderData.EnsureCapacity(previousSize);
        ERender(renderData);

        
        if (!firstTime)
            return;
        lock(MyRenderData)
        {
            MyPreviousList = MyRenderData;
            MyRenderData = renderData;
        }

        firstTime = false;
    }
    
    public void RenderFrame()
    {
        Stopwatch watch = new();
        watch.Start();
        lock(MyRenderData)
        {
            Renderer.SetRenderData(MyRenderData);
            Renderer.SetCameraView(myCameraView);
        }
        
        Renderer.Render();
        Console.WriteLine($"Time passed single frame = {watch.ElapsedMilliseconds}");
    }
    
    public void SetCameraView(Matrix4x4 aView)
    {
        lock(MyRenderData)
        {
            myCameraView = aView;
        }
    }
}