using Vortice.ShaderCompiler;
using Vortice.Vulkan;
using VulkanApi;

namespace Rendering;

public class GpuDataTransferer : IGpuDestroyable
{
    public static GpuDataTransferer Instance = null!;
    private TransferQueue TransferQueue = null!;

    private Fence ImmediateFence = null!;
    private CommandBuffer ImmediateCommandBuffer = null!;
    private List<AllocatedRawBuffer> BufferPool = new();
    
    public GpuDataTransferer()
    {
        Instance = this;
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
    
    //New API, need to handle thread safety
    public unsafe void TransferTextureImmediate<T>(Image aImage, Span<T> aData) where T : unmanaged
    {
        uint dataSize = (uint)(aData.Length * sizeof(T));
        var staging = TakeStagingBuffer(dataSize);
        
        Buffer.MemoryCopy(aData.GetPointerUnsafe(), staging.AllocationInfo.pMappedData, dataSize, dataSize);
        
        ImmediateSubmit(cmd =>
        {
            cmd.TransitionImage(aImage, VkImageLayout.TransferDstOptimal);

            VkBufferImageCopy copyRegion = new();
            copyRegion.bufferOffset = 0;
            copyRegion.bufferRowLength = 0;
            copyRegion.bufferImageHeight = 0;

            copyRegion.imageSubresource.aspectMask = VkImageAspectFlags.Color;
            copyRegion.imageSubresource.mipLevel = 0;
            copyRegion.imageSubresource.baseArrayLayer = 0;
            copyRegion.imageSubresource.layerCount = 1;
            copyRegion.imageExtent = aImage.Extent;

            vkCmdCopyBufferToImage(cmd.VkCommandBuffer, staging.Buffer, aImage.VkImage, VkImageLayout.TransferDstOptimal, 1, &copyRegion);

            cmd.TransitionImage(aImage, VkImageLayout.ReadOnlyOptimal);
        });

        ReturnStagingBuffer(staging);
    }
    
    //Use Memory<T>?
    /*public async Task TransferTextureAsync<T>(Image aImage, Span<T> aData) where T : unmanaged
    {
        GpuDataTransferer dataTransfer = await EgoTask.GpuDataTransfer();
        
    }*/

    public void Destroy()
    {
        ImmediateFence.Destroy();
        ImmediateCommandBuffer.Destroy();
    }

    public AllocatedRawBuffer TakeStagingBuffer(uint aByteSize)
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