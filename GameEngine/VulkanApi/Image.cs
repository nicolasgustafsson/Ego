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

    public VkRenderingAttachmentInfo GetAttachmentInfo(VkClearValue? aClear,  VkImageLayout aLayout = VkImageLayout.ColorAttachmentOptimal)
    {
        VkRenderingAttachmentInfo colorAttachment = new();

        colorAttachment.imageView = MyImageView.MyVkImageView;
        colorAttachment.imageLayout = aLayout;
        colorAttachment.loadOp = aClear == null ? VkAttachmentLoadOp.Load : VkAttachmentLoadOp.Clear;
        colorAttachment.storeOp = VkAttachmentStoreOp.Store;
        if (aClear.HasValue)
            colorAttachment.clearValue = aClear.Value;

        return colorAttachment;
    }
    
    public VkRenderingAttachmentInfo GetDepthAttachmentInfo(VkImageLayout layout = VkImageLayout.ColorAttachmentOptimal)
    {
        VkRenderingAttachmentInfo depthAttachment = new();
        depthAttachment.imageView = MyImageView.MyVkImageView;
        depthAttachment.imageLayout = layout;
        depthAttachment.loadOp = VkAttachmentLoadOp.Clear;
        depthAttachment.storeOp = VkAttachmentStoreOp.Store;
        depthAttachment.clearValue.depthStencil = new(0f, 0);

        return depthAttachment;
    }
    
    public VkRenderingInfo GetRenderingInfo(VkExtent2D renderExtent, VkRenderingAttachmentInfo colorAttachment, VkRenderingAttachmentInfo? depthAttachment)
    {
        VkRenderingInfo renderInfo = new();
        
        renderInfo.renderArea = new VkRect2D(new VkOffset2D ( 0, 0 ), renderExtent);
        renderInfo.layerCount = 1;
        renderInfo.colorAttachmentCount = 1;
        renderInfo.pColorAttachments = &colorAttachment;
        if (depthAttachment.HasValue)
        {
            VkRenderingAttachmentInfo depthAttachmentRealsies = depthAttachment.Value;
            renderInfo.pDepthAttachment = &depthAttachmentRealsies;
        }
        else
        {
            renderInfo.pDepthAttachment = null;
        }
        
        renderInfo.pStencilAttachment = null;

        return renderInfo;
    } 
}