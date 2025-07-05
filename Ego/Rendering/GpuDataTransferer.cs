using Vortice.Vulkan;
using VulkanApi;

namespace Rendering;

public class GpuDataTransferer : IGpuImmediateSubmit, IGpuDestroyable
{
    private TransferQueue TransferQueue = null!;

    private Fence ImmediateFence = null!;
    private CommandBuffer ImmediateCommandBuffer = null!;
    private bool firstTime = true;
    private List<AllocatedRawBuffer> BufferPool = new();
    
    public GpuDataTransferer()
    {
        TransferQueue = new TransferQueue();
        ImmediateFence = new();
        ImmediateCommandBuffer = new(TransferQueue);
    }
    
    public void ImmediateSubmit(Action<CommandBufferHandle> aAction)
    {
        ImmediateFence.Reset();

        using (var handle = ImmediateCommandBuffer.BeginRecording())
            aAction(handle);
        
        TransferQueue.Submit(ImmediateCommandBuffer, ImmediateFence);
        ImmediateFence.Wait();
    }

    public void Destroy()
    {
        ImmediateFence.Destroy();
        ImmediateCommandBuffer.Destroy();
    }

    public AllocatedRawBuffer GetStagingBuffer(uint aByteSize)
    {
        for (int i = 0; i < BufferPool.Count; i++)
        {
            if (BufferPool[i].AllocationInfo.size >= aByteSize)
            {
                var buffer = BufferPool[i];
                BufferPool.RemoveAt(i);
                return buffer;
            }
        }
        return new(aByteSize, VkBufferUsageFlags.TransferSrc, VmaMemoryUsage.CpuToGpu);
    }
    
    public void ReturnStagingBuffer(AllocatedRawBuffer aBuffer)
    {
        for(int i = 0; i < BufferPool.Count; i++)
        {
            if (BufferPool[i].AllocationInfo.size > aBuffer.AllocationInfo.size)
            {
                BufferPool.Insert(i, aBuffer);
                return;
            }
        }
        
        BufferPool.Add(aBuffer);
    }
}