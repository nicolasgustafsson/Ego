using System.Diagnostics;
using Rendering;

namespace Ego;

public class RendererApi : ParallelBranch<RendererApi>
{
    public Renderer Renderer = null!;

    public DoubleBuffer<RenderData> RenderData = new(new(), new());
    
    public RendererApi(Window aWindow)
    {
        Renderer = new Renderer(aWindow);
    }
    
    public void WaitUntilIdle()
    {
        Renderer.WaitUntilIdle();
    }
    
    public void RegisterMesh(MeshRenderData aRenderData)
    {
        RenderData.Producer.MeshRenders.Add(aRenderData);
    }

    protected override void Update()
    {
    }
    
    public void RenderFrame()
    {
        Stopwatch watch = new();
        watch.Start();

        Renderer.Render(RenderData.Consumer);
        
        Log.Information($"Time passed single frame = {watch.ElapsedMilliseconds}ms");
    }
    
    public void SetCameraView(Matrix4x4 aView)
    {
        RenderData.Producer.CameraView = aView;
    }

    public override void UpdateSynchronous()
    {
        RenderData.Swap();
        RenderData.Producer.MeshRenders.Clear();
    }

    public override void UpdateRoot()
    {
    }

    public override void UpdateBranch()
    {
        RenderFrame();
    }
}