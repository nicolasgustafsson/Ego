namespace Graphics;

public unsafe class AllocatedRawBuffer : IGpuDestroyable
{
    public VkBuffer MyBuffer;
    public VmaAllocation MyAllocation;
    public VmaAllocationInfo MyAllocationInfo;

    public AllocatedRawBuffer(ulong aSize, VkBufferUsageFlags aBufferUsageFlags, VmaMemoryUsage aMemoryUsage)
    {
        VkBufferCreateInfo bufferCreateInfo = new();
        bufferCreateInfo.pNext = null;
        bufferCreateInfo.size = aSize;
        bufferCreateInfo.usage = aBufferUsageFlags;

        VmaAllocationCreateInfo allocationInfo = new();
        allocationInfo.usage = aMemoryUsage;
        allocationInfo.flags = VmaAllocationCreateFlags.Mapped;

        Vma.vmaCreateBuffer(GlobalAllocator.myVmaAllocator, &bufferCreateInfo, &allocationInfo, out MyBuffer, out MyAllocation, out MyAllocationInfo).CheckResult();
    }

    public void Destroy()
    {
        Vma.vmaDestroyBuffer(GlobalAllocator.myVmaAllocator, MyBuffer, MyAllocation);
    }
    
    public ulong GetDeviceAddress()
    {
        VkBufferDeviceAddressInfo deviceAddressInfo = new();
        deviceAddressInfo.buffer = MyBuffer;

        return vkGetBufferDeviceAddress(Device.MyVkDevice, &deviceAddressInfo);
    }
    
    public void Map(MemoryAllocator aAllocator, byte** aData)
    {
        Vma.vmaMapMemory(aAllocator.myVmaAllocator, MyAllocation, (void**)aData).CheckResult();
    }
    
    public void UnMap(MemoryAllocator aAllocator)
    {
        Vma.vmaUnmapMemory(aAllocator.myVmaAllocator, MyAllocation);
    }
}

public unsafe class AllocatedBuffer<T> : AllocatedRawBuffer where T : unmanaged
{
    public AllocatedBuffer(VkBufferUsageFlags aBufferUsageFlags, VmaMemoryUsage aMemoryUsage) : base((ulong)sizeof(T), aBufferUsageFlags, aMemoryUsage)
    {
        
    }
    
    public void SetWriteData(T aValue)
    {
        byte* mappedData = (byte*)MyAllocationInfo.pMappedData;
        Span<T> destination = new(mappedData, sizeof(T));
        destination[0] = aValue;
    }
}