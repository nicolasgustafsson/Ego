using Vortice.Vulkan;
using VulkanApi;

namespace Rendering;

public enum GpuBufferType
{
    Constant,    //For data that is constant. Vertex buffers for instance.
    Dynamic,     //Data that is expected to change often. Use for particles, lines, etc
    Uniform,     //Same as above, but gets preloaded into cache. Use for small data that will be used for all shader invocations. World Matrices, Material settings(dissolve amount), etc
    Index        //Index buffer.
}

public enum GpuBufferTransferType
{
    Direct,            //Immediately uploads directly to buffer - Simplest method, but slower access.
    Staging,           //Uses a staging buffer to upload to buffer
}

public abstract class GpuBuffer : IGpuDestroyable
{
    public AllocatedRawBuffer MyInternalBuffer = null!;
    public void Destroy()
    {
        MyInternalBuffer.Destroy();
    }
    
    public ulong GetDeviceAddress()
    {
        return MyInternalBuffer.GetDeviceAddress();
    }
}

public class GpuBuffer<T> : GpuBuffer where T : unmanaged
{
    public new AllocatedBuffer<T> MyInternalBuffer;
    
    public GpuBuffer(GpuBufferType aBufferType, GpuBufferTransferType aTransferType, uint aElementCount = 1)
    {
        VkBufferUsageFlags flags = VkBufferUsageFlags.None;
        VmaMemoryUsage memoryUsage = VmaMemoryUsage.Unknown;
        
        switch(aBufferType)
        {
            case GpuBufferType.Constant:
                flags = VkBufferUsageFlags.StorageBuffer | VkBufferUsageFlags.ShaderDeviceAddress | VkBufferUsageFlags.TransferDst;
                break;
            case GpuBufferType.Dynamic:
                flags = VkBufferUsageFlags.StorageBuffer | VkBufferUsageFlags.ShaderDeviceAddress;
                break;
            case GpuBufferType.Uniform:
                flags = VkBufferUsageFlags.UniformBuffer;
                break;
            case GpuBufferType.Index:
                flags = VkBufferUsageFlags.IndexBuffer |  VkBufferUsageFlags.TransferDst;
                break;
        }
        
        switch(aTransferType)
        {
            case GpuBufferTransferType.Direct:
                memoryUsage = VmaMemoryUsage.CpuToGpu;
                break;
            
            case GpuBufferTransferType.Staging:
                memoryUsage = VmaMemoryUsage.GpuOnly;
                break;
        }

        MyInternalBuffer = new(flags, memoryUsage, aElementCount);
        base.MyInternalBuffer = MyInternalBuffer;
    }
    
    public void SetData(T aValue)
    {
        MyInternalBuffer.SetWriteData(aValue);
    }
    
    public void SetData(Span<T> aValue, ulong aOffset = 0)
    {
        MyInternalBuffer.SetWriteData(aValue, aOffset);
    }
}


