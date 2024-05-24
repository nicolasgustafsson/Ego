using Graphics;
using Vortice.Vulkan;
using Semaphore = Graphics.Semaphore;

namespace Rendering;

public class FrameData : IGpuDestroyable
{
    public CommandBuffer MyCommandBuffer = null!;
    
    public Semaphore MyImageAvailableSemaphore = null!;
    public Semaphore MyRenderFinishedSemaphore = null!;

    public Fence MyRenderFence = null!;

    public DeletionQueue MyDeletionQueue = new();
    
    public void Destroy()
    {
        MyCommandBuffer.Destroy();
        MyImageAvailableSemaphore.Destroy();
        MyRenderFinishedSemaphore.Destroy();
        MyRenderFence.Destroy();
    }
}