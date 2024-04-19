using Vortice.Vulkan;

namespace Rendering;

public partial class Renderer
{
    private readonly string[] ValidationLayers = new[]
    {
        "VK_LAYER_KHRONOS_validation"
    };
    
    private string[] Extensions => new[]
    {
        "VK_KHR_surface",
        GetSurfaceExtension(),
        "VK_EXT_debug_utils",
        "VK_KHR_swapchain",
    };

    private DisplayServer LinuxDisplayServer = DisplayServer.X11;

    private VkFormat PreferredFormat = VkFormat.B8G8R8A8Srgb;
    private VkColorSpaceKHR PreferredColorSpace = VkColorSpaceKHR.SrgbNonLinear;
    private VkPresentModeKHR PreferredPresentMode = VkPresentModeKHR.Mailbox;
}