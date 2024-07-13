using System.Runtime.InteropServices;
using VulkanApi;
using Vortice.Vulkan;
using Semaphore = VulkanApi.Semaphore;

namespace Rendering;

public class FrameData : IGpuDestroyable
{
    public CommandBuffer MyCommandBuffer = null!;
    
    public Semaphore MyImageAvailableSemaphore = null!;
    public Semaphore MyRenderFinishedSemaphore = null!;

    public Fence MyRenderFence = null!;

    public DeletionQueue MyDeletionQueue = new();

    public DescriptorAllocatorGrowable MyFrameDescriptors = new();
    
    public void Destroy()
    {
        MyDeletionQueue.Flush();
        MyCommandBuffer.Destroy();
        MyImageAvailableSemaphore.Destroy();
        MyRenderFinishedSemaphore.Destroy();
        MyRenderFence.Destroy();
        MyFrameDescriptors.Destroy();
    }
}
