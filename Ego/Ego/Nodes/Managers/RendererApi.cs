using System.Diagnostics;
using Rendering;

namespace Ego;

public class RendererApi : Node
{
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
    
    public void AddRenderData(MeshRenderData aRenderData)
    {
        MyRenderData.Add(aRenderData);
    }

    protected override void Update()
    {
        List<MeshRenderData> renderData = MyPreviousList;
        lock(MyPreviousList)
        {
            MyPreviousList = MyRenderData;
            MyRenderData = renderData;
        }
        MyRenderData.Clear();
        MyRenderData.EnsureCapacity(renderData.Count);
    }
    
    public void RenderFrame()
    {
        Stopwatch watch = new();
        watch.Start();
        lock(MyPreviousList)
        {
            Renderer.SetRenderData(MyPreviousList);
            Renderer.SetCameraView(myCameraView);
        }
        
        Renderer.Render();
        Console.WriteLine($"Time passed single frame = {watch.ElapsedMilliseconds}ms");
    }
    
    public void SetCameraView(Matrix4x4 aView)
    {
        lock(MyRenderData)
        {
            myCameraView = aView;
        }
    }
}