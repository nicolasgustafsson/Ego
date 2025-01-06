using System.Diagnostics;
using ImGuiNET;
using Rendering;
using Vortice.Vulkan;

namespace Ego;

public class RendererApi : ParallelBranch<RendererApi>
{
    public Renderer Renderer = null!;

    public DoubleBuffer<RenderData> RenderData = new(new(), new());
    
    public RendererApi(Window aWindow, RendererInitSettings aRendererSettings)
    {
        Renderer = new Renderer(aWindow, aRendererSettings);
    }
    
    public void WaitUntilIdle()
    {
        Renderer.WaitUntilIdle();
    }
    
    public void RenderMesh(MeshRenderData aRenderData)
    {
        RenderData.Producer.MeshRenders.Add(aRenderData);
    }

    protected override void Update()
    {
    }

    private void RenderFrame()
    {
        PerformanceMonitor.PerformanceTracer tracer = PerformanceMonitor.StartTrace();

        Renderer.Render(RenderData.Consumer);
        
        tracer.Trace("Render");
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

    public override void Inspect()
    {
        base.Inspect();

        if (ImGui.BeginCombo("VSync", Renderer.PreferredPresentMode.ToString()))
        {
            foreach(var presentMode in (VkPresentModeKHR[])Enum.GetValues(typeof(VkPresentModeKHR)))
            {
                bool selected = presentMode == Renderer.PreferredPresentMode;
                if (ImGui.Selectable(presentMode.ToString()))
                {
                    SetPresentMode(presentMode);
                }
                if (selected)
                {
                    ImGui.SetItemDefaultFocus();
                }
            }
            ImGui.EndCombo();
        }
    }

    public void SetPresentMode(VkPresentModeKHR aPresentMode)
    {
        QueueMessage(_ => Renderer.SetPresentMode(aPresentMode));
    }
}