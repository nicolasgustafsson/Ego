using Vortice.Vulkan;

namespace Rendering;

public partial class Renderer
{
    private readonly string[] ValidationLayers = ["VK_LAYER_KHRONOS_validation"];

    private VkFormat PreferredFormat = VkFormat.B8G8R8A8Unorm;
    private VkColorSpaceKHR PreferredColorSpace = VkColorSpaceKHR.SrgbNonLinear;
    public VkPresentModeKHR PreferredPresentMode { get; private set; } = VkPresentModeKHR.Mailbox;

    private const int FrameOverlap = 2;

    private readonly bool PrintExtensions = false;
}