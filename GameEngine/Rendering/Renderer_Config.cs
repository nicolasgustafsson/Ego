using Vortice.Vulkan;

namespace Rendering;

public partial class Renderer
{
    private readonly string[] ValidationLayers = ["VK_LAYER_KHRONOS_validation"];

    private VkFormat PreferredFormat = VkFormat.B8G8R8A8Unorm;
    private VkColorSpaceKHR PreferredColorSpace = VkColorSpaceKHR.SrgbNonLinear;
    private VkPresentModeKHR PreferredPresentMode = VkPresentModeKHR.Mailbox;

    //how many frames we are able to handle at once. Change to 3 to make it triple buffer maybe?
    private const int FrameOverlap = 2;

    private readonly bool PrintExtensions = false;
}