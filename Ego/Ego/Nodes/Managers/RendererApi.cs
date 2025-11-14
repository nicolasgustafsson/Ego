using System.Diagnostics;
using Rendering;
using Vortice.Vulkan;

namespace Ego;

[Node(AllowAddingToScene = false)]
public partial class RendererApi : ParallelBranch<RendererApi>
{
    public Renderer Renderer = null!;

    private DoubleBuffer<RenderData> RenderDataBuffer = new(new(), new());

    public RenderData RenderData => RenderDataBuffer.Producer;
    
    public RendererApi()
    {
        
    }
    public RendererApi(Window aWindow, RendererInitSettings aRendererSettings)
    {
        Renderer = new Renderer(aWindow, aRendererSettings);

        AddChild(Renderer);
    }
    
    public void WaitUntilIdle()
    {
        Renderer.WaitUntilIdle();
    }
    
    protected override void Update()
    {
    }

    private void RenderFrame()
    {
        Thread.CurrentThread.Name = "Renderer Thread";
        
        PerformanceMonitor.PerformanceTracer tracer = PerformanceMonitor.StartTrace();

        Renderer.Render(RenderDataBuffer.Consumer);

        MultithreadingManager.EgoSynchronizationContext.ExecuteRendererContinuations(Renderer);
        
        tracer.Trace("Render");
    }

    public override void UpdateSynchronous()
    {
        RenderDataBuffer.Swap();
        RenderDataBuffer.Producer.RenderRequests.Clear();
    }

    public override void UpdateRoot()
    {
    }

    public override void UpdateBranch()
    {
        RenderFrame();
    }

    public void Inspect()
    {
        VkPresentModeKHR currentPresentMode = Renderer.PreferredPresentMode;
        if (EmGui.Inspect("VSync", ref currentPresentMode))
        {
            SetPresentMode(currentPresentMode);
        }
    }

    public void SetPresentMode(VkPresentModeKHR aPresentMode)
    {
        QueueMessage(_ => Renderer.SetPresentMode(aPresentMode));
    }
}