using Vortice.Vulkan;

namespace Rendering;

public partial class Renderer
{
    private readonly string[] ValidationLayers = new[]
    {
        "VK_LAYER_KHRONOS_validation"
    };
    
    private string[] InstanceExtensions => new[]
    {
        "VK_KHR_surface",
        GetSurfaceExtension(),
        "VK_EXT_debug_utils",
    };
    
    private string[] DeviceExtensions => new[]
    {
        "VK_KHR_swapchain",
        "VK_KHR_synchronization2",
    };

    private DisplayServer LinuxDisplayServer = DisplayServer.X11;

    private VkFormat PreferredFormat = VkFormat.B8G8R8A8Unorm;
    private VkColorSpaceKHR PreferredColorSpace = VkColorSpaceKHR.SrgbNonLinear;
    private VkPresentModeKHR PreferredPresentMode = VkPresentModeKHR.Fifo;

    //how many frames we are able to handle at once. Change to 3 to make it triple buffer maybe?
    private const int FrameOverlap = 2;

    private bool PrintExtensions = false;
}