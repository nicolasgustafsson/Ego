using System.Runtime.InteropServices;
using VulkanApi;
using Vortice.Vulkan;
using Semaphore = VulkanApi.Semaphore;

namespace Rendering;

public class FrameData : IGpuDestroyable
{
    public CommandBuffer CommandBuffer = null!;
    
    public Semaphore ImageAvailableSemaphore = null!;
    public Semaphore RenderFinishedSemaphore = null!;

    public Fence RenderFence = null!;

    public DeletionQueue DeletionQueue = new();

    public DescriptorAllocatorGrowable FrameDescriptors = new();
    
    public void Destroy()
    {
        DeletionQueue.Flush();
        CommandBuffer.Destroy();
        ImageAvailableSemaphore.Destroy();
        RenderFinishedSemaphore.Destroy();
        RenderFence.Destroy();
        FrameDescriptors.Destroy();
    }
}
