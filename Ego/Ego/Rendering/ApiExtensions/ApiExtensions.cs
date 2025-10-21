using Vortice.Vulkan;
using VulkanApi;

namespace Rendering;

public static class ApiExtensions
{
    public static void BindIndexBuffer(this CommandBufferHandle aBuffer, GpuBuffer aIndexBuffer, VkIndexType aIndexType = VkIndexType.Uint32)
    {
        aBuffer.BindIndexBuffer(aIndexBuffer.MyInternalBuffer, aIndexType);
    }
    
    public static void WriteBuffer<T>(this DescriptorWriter aWriter, uint aBinding, GpuBuffer<T> aBuffer, ulong aOffset, VkDescriptorType aType) where T : unmanaged
    {
        aWriter.WriteBuffer(aBinding, aBuffer.MyInternalBuffer, aOffset, aType);
    }
}