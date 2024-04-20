using Vortice.Vulkan;

namespace Rendering;

public class FrameData
{
    public VkCommandPool MyCommandPool;
    public VkCommandBuffer MyCommandBuffer;
    
    public VkSemaphore MyImageAvailableSemaphore;
    public VkSemaphore MyRenderFinishedSemaphore;

    public VkFence MyRenderFence;
}