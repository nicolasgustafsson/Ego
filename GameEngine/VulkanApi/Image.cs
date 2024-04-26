namespace Graphics;

public unsafe class Image
{
    public VkImage MyVkImage;
    public ImageView MyImageView;
    public VmaAllocation MyAllocation;
    public VkExtent3D MyExtent;
    public VkFormat MyImageFormat;
    
    public Image(Device aDevice, MemoryAllocator aAllocator, VkFormat aFormat, VkImageUsageFlags aUsageFlags, VkExtent3D aExtent)
    {
        MyExtent = aExtent;
        MyImageFormat = aFormat;
        
        VkImageCreateInfo createInfo = new();
        createInfo.imageType = VkImageType.Image2D;
        createInfo.format = aFormat;
        createInfo.extent = aExtent;
        
        createInfo.mipLevels = 1;
        createInfo.arrayLayers = 1;
        
        createInfo.samples = VkSampleCountFlags.Count1;
        
        createInfo.tiling = VkImageTiling.Optimal;
        createInfo.usage = aUsageFlags;
        
        VmaAllocationCreateInfo allocationInfo = new();
        allocationInfo.usage = VmaMemoryUsage.GpuOnly;
        allocationInfo.requiredFlags = VkMemoryPropertyFlags.DeviceLocal;
        
        Vma.vmaCreateImage(aAllocator.myVmaAllocator, &createInfo, &allocationInfo, out MyVkImage, out MyAllocation, out VmaAllocationInfo allocInfo).CheckResult();

        MyImageView = new(aDevice, MyVkImage, aFormat);
    }
    
    public void Destroy(Device aDevice, MemoryAllocator aAllocator)
    {
        MyImageView.Destroy(aDevice);

        Vma.vmaDestroyImage(aAllocator.myVmaAllocator, MyVkImage, MyAllocation);
    }
}