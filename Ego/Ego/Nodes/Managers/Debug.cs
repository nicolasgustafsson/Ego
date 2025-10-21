using Rendering;
using VulkanApi;

namespace Ego;

[Node(AllowAddingToScene = false)]
public partial class Debug : Node
{
    private ImGuiDriver? ImGuiDriver = null!;

    public Action EDebug = () => {};
    
    public override void Start()
    {
        base.Start();

        ImGuiDriver = new ImGuiDriver(Window, VkApiInstance.Instance, GpuInstance.VkPhysicalDevice, Device.VkDevice, RendererApi.Renderer.RenderQueue.QueueFamilyIndex, RendererApi.Renderer.RenderQueue.VkQueue);
        RendererApi.Renderer.ERenderImgui += ImGuiDriver.Render;
    }

    protected override unsafe void Update()
    {
        if (ImGuiDriver == null)
            return;
        
        ImGuiDriver.Begin();
       
        Imgui.DockSpaceOverViewport(aFlags: ImGuiDockNodeFlags.PassthruCentralNode);

        Imgui.ShowDemoWindow();
        Imgui.ShowAboutWindow();

        EDebug();
        
        ImGuiDriver.End();
    }

    public override char GetIcon()
    {
        return (char)61832;
    }
}