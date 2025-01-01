using System.Diagnostics;
using Rendering;

namespace Ego;

public class RendererApi : Node
{
    public Renderer Renderer = null!;

    public List<MeshRenderData> MyRenderData = new();
    private Matrix4x4 myCameraView = new();
    
    public RendererApi(Window aWindow)
    {
        Renderer = new Renderer(aWindow);
    }
    
    public void WaitUntilIdle()
    {
        Renderer.WaitUntilIdle();
    }
    
    public void AddRenderData(MeshRenderData aRenderData)
    {
        MyRenderData.Add(aRenderData);
    }

    protected override void Update()
    {
        RenderFrame();
        MyRenderData.Clear();
    }
    
    public void RenderFrame()
    {
        Stopwatch watch = new();
        watch.Start();
        Renderer.SetRenderData(MyRenderData);
        Renderer.SetCameraView(myCameraView);
        Renderer.Render();
        
        Log.Information($"Time passed single frame = {watch.ElapsedMilliseconds}ms");
    }
    
    public void SetCameraView(Matrix4x4 aView)
    {
        lock(MyRenderData)
        {
            myCameraView = aView;
        }
    }
}