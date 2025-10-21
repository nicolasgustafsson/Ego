using Vortice.ShaderCompiler;

namespace VulkanApi;

public unsafe class AllocatedRawBuffer : IGpuDestroyable
{
    public VkBuffer Buffer;
    public VmaAllocation Allocation;
    public VmaAllocationInfo AllocationInfo;

    public AllocatedRawBuffer(ulong aSize, VkBufferUsageFlags aBufferUsageFlags, VmaMemoryUsage aMemoryUsage)
    {
        VkBufferCreateInfo bufferCreateInfo = new();
        bufferCreateInfo.pNext = null;
        bufferCreateInfo.size = aSize;
        bufferCreateInfo.usage = aBufferUsageFlags;
        bufferCreateInfo.sharingMode = VkSharingMode.Concurrent;

        ReadOnlySpan<uint> queueFamilies = [GpuInstance.GraphicsFamily, GpuInstance.TransferFamily]; 
        bufferCreateInfo.pQueueFamilyIndices = queueFamilies.GetPointerUnsafe();
        bufferCreateInfo.queueFamilyIndexCount = (uint)queueFamilies.Length;

        VmaAllocationCreateInfo allocationInfo = new();
        allocationInfo.usage = aMemoryUsage;
        allocationInfo.flags = VmaAllocationCreateFlags.Mapped;

        Vma.vmaCreateBuffer(GlobalAllocator.VmaAllocator, &bufferCreateInfo, &allocationInfo, out Buffer, out Allocation, out AllocationInfo).CheckResult();
    }

    public void Destroy()
    {
        Vma.vmaDestroyBuffer(GlobalAllocator.VmaAllocator, Buffer, Allocation);
    }
    
    public ulong GetDeviceAddress()
    {
        VkBufferDeviceAddressInfo deviceAddressInfo = new();
        deviceAddressInfo.buffer = Buffer; 

        return VkApiDevice.vkGetBufferDeviceAddress(Device.VkDevice, &deviceAddressInfo);
    }
    
    public void Map(MemoryAllocator aAllocator, byte** aData)
    {
        Vma.vmaMapMemory(aAllocator.VmaAllocator, Allocation, (void**)aData).CheckResult();
    }
    
    public void UnMap(MemoryAllocator aAllocator)
    {
        Vma.vmaUnmapMemory(aAllocator.VmaAllocator, Allocation);
    }
}

public unsafe class AllocatedBuffer<T> : AllocatedRawBuffer where T : unmanaged
{
    public AllocatedBuffer(VkBufferUsageFlags aBufferUsageFlags, VmaMemoryUsage aMemoryUsage, uint aElementCount = 1) : base((ulong)sizeof(T) * aElementCount, aBufferUsageFlags, aMemoryUsage)
    {
        
    }
    
    public void SetWriteData(T aValue)
    {
        byte* mappedData = (byte*)AllocationInfo.pMappedData;
        Span<T> destination = new(mappedData, sizeof(T));
        destination[0] = aValue;
    }
    
    public void SetWriteData(Span<T> aValue, ulong aOffset = 0)
    {
        byte* mappedData = (byte*)AllocationInfo.pMappedData;
        Span<T> destination = new(mappedData + aOffset, aValue.Length);

        aValue.CopyTo(destination);
    }
}