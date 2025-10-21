using Vortice.ShaderCompiler;
using Vortice.Vulkan;
using VulkanApi;

namespace Rendering;

public class GpuDataTransferer : IGpuDestroyable
{
    public static GpuDataTransferer Instance = null!;
    private TransferQueue TransferQueue = null!;

    private List<AllocatedRawBuffer> BufferPool = new();
    
    public GpuDataTransferer()
    {
        Instance = this;
        TransferQueue = new TransferQueue();
    }
    
    private void ImmediateSubmit(Action<CommandBufferHandle> aAction)
    {
        //[Perf] Is allocating a new command buffer every submit slow?
        CommandBuffer immediateCommandBuffer = new(TransferQueue, aTransient:true);
        using (var handle = immediateCommandBuffer.BeginRecording())
            aAction(handle);
        
        TransferQueue.Submit(immediateCommandBuffer, null);
    }
    
    public unsafe void TransferTextureImmediate<T>(Image aImage, Span<T> aData) where T : unmanaged
    {
        uint dataSize = (uint)(aData.Length * sizeof(T));
        var staging = TakeStagingBuffer(dataSize);
        
        Buffer.MemoryCopy(aData.GetPointerUnsafe(), staging.AllocationInfo.pMappedData, dataSize, dataSize);
        
        ImmediateSubmit(cmd =>
        {
            cmd.TransitionImage(aImage, VkImageLayout.TransferDstOptimal);

            cmd.CopyBufferToImage(staging, aImage, VkImageLayout.TransferDstOptimal);

            cmd.TransitionImage(aImage, VkImageLayout.ReadOnlyOptimal);
        });

        ReturnStagingBuffer(staging);
    }
    
    public unsafe void TransferDataImmediate<T>(GpuBuffer aBuffer, Span<T> aData) where T : unmanaged
    {
        uint dataSize = (uint)(aData.Length * sizeof(T));
        var staging = TakeStagingBuffer(dataSize);
        
        Buffer.MemoryCopy(aData.GetPointerUnsafe(), staging.AllocationInfo.pMappedData, dataSize, dataSize);
        
        ImmediateSubmit(cmd =>
        {
            cmd.CopyBufferToBuffer(staging, aBuffer.MyInternalBuffer, dataSize);
        });
        
        ReturnStagingBuffer(staging);
    }

    public void Destroy()
    {
        lock(BufferPool)
        {
            foreach(var buffer in BufferPool)
            {
                buffer.Destroy();
            }

            BufferPool.Clear();
        }
    }

    private AllocatedRawBuffer TakeStagingBuffer(uint aByteSize)
    {
        lock(BufferPool)
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
    }
    
    private void ReturnStagingBuffer(AllocatedRawBuffer aBuffer)
    {
        lock(BufferPool)
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
}