using Graphics;
using Vortice.Vulkan;
using Semaphore = Graphics.Semaphore;

namespace Rendering;

public class FrameData
{
    public CommandBuffer MyCommandBuffer = null!;
    
    public Semaphore MyImageAvailableSemaphore = null!;
    public Semaphore MyRenderFinishedSemaphore = null!;

    public Fence MyRenderFence = null!;
}