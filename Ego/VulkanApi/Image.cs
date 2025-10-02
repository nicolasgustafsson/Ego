using System.Diagnostics;
using System.Numerics;
using Rendering;
using Vortice.ShaderCompiler;

namespace VulkanApi;

public unsafe class Image : IGpuDestroyable
{
    public VkImage VkImage;
    public ImageView ImageView;
    public VmaAllocation Allocation;
    public VkExtent3D Extent;
    public VkFormat ImageFormat;
    
    public VkImageLayout CurrentLayout = VkImageLayout.Undefined;
    
    public IntPtr GetHandle()
    {
        return (IntPtr)VkImage.Handle;
    }
    
    public Image(VkFormat aFormat, VkImageUsageFlags aUsageFlags, VkExtent3D aExtent, bool aMipMaps, bool aIsRenderTexture)
    {
        Stopwatch watch = new();
        Stopwatch totalWatch = new();
        watch.Start();
        if (aExtent.depth == 0)
        {
            Log.Error($"Depth should not be 0!");
        }
        Extent = aExtent;
        ImageFormat = aFormat;
        
        VkImageCreateInfo createInfo = new();
        createInfo.imageType = VkImageType.Image2D;
        createInfo.format = aFormat;
        createInfo.extent = aExtent;
        createInfo.mipLevels = 1;
        
        if (aMipMaps)
            createInfo.mipLevels = (uint)Math.Floor(Math.Log2(Math.Max(aExtent.width, aExtent.height))) + 1;
        
        createInfo.arrayLayers = 1;
        
        createInfo.samples = VkSampleCountFlags.Count1;
        
        createInfo.tiling = VkImageTiling.Optimal;
        createInfo.usage = aUsageFlags;
        
        if (!aIsRenderTexture)
        {
            createInfo.sharingMode = VkSharingMode.Concurrent;
            ReadOnlySpan<uint> queueFamilies = [GpuInstance.GraphicsFamily, GpuInstance.TransferFamily]; 
            createInfo.pQueueFamilyIndices = queueFamilies.GetPointer();
            createInfo.queueFamilyIndexCount = (uint)queueFamilies.Length;
        }

        VmaAllocationCreateInfo allocCreateInfo = new();
        allocCreateInfo.usage = VmaMemoryUsage.GpuOnly;
        allocCreateInfo.requiredFlags = VkMemoryPropertyFlags.DeviceLocal;
        
        Vma.vmaCreateImage(GlobalAllocator.VmaAllocator, &createInfo, &allocCreateInfo, out VkImage, out Allocation, out VmaAllocationInfo allocInfo).CheckResult();

        ImageView = new(VkImage, aFormat, (int)(aUsageFlags & VkImageUsageFlags.DepthStencilAttachment) != 0 ? VkImageAspectFlags.Depth : VkImageAspectFlags.Color, createInfo.mipLevels);

        ImageRegistry.PointersToImages.TryAdd((nint)VkImage.Handle, this);
    }
    
    public Image(IGpuImmediateSubmit aSubmit, byte[] aData, VkFormat aFormat, VkImageUsageFlags aUsageFlags, VkExtent3D aExtent, bool aMipMaps, AllocatedRawBuffer? aStagingBuffer = null)  
        : this(aSubmit, aData.AsSpan().GetPointerUnsafe(), aFormat, aUsageFlags, aExtent, aMipMaps, aStagingBuffer)
    {
        
    }
    public Image(IGpuImmediateSubmit aSubmit, byte* aData, VkFormat aFormat, VkImageUsageFlags aUsageFlags, VkExtent3D aExtent, bool aMipMaps, AllocatedRawBuffer? aStagingBuffer = null) : this(aFormat, aUsageFlags | VkImageUsageFlags.TransferDst, aExtent, aMipMaps, aIsRenderTexture: false)
    {
        ulong dataSize = aExtent.width * aExtent.height * aExtent.depth * 4;
        
        AllocatedRawBuffer staging = aStagingBuffer;
        if (staging == null)
            staging = new(dataSize, VkBufferUsageFlags.TransferSrc, VmaMemoryUsage.CpuToGpu);
        
        Buffer.MemoryCopy(aData, staging.AllocationInfo.pMappedData, dataSize, dataSize);
        
        aSubmit.ImmediateSubmit(cmd =>
        {
            cmd.TransitionImage(this, VkImageLayout.TransferDstOptimal);

            VkBufferImageCopy copyRegion = new();
            copyRegion.bufferOffset = 0;
            copyRegion.bufferRowLength = 0;
            copyRegion.bufferImageHeight = 0;

            copyRegion.imageSubresource.aspectMask = VkImageAspectFlags.Color;
            copyRegion.imageSubresource.mipLevel = 0;
            copyRegion.imageSubresource.baseArrayLayer = 0;
            copyRegion.imageSubresource.layerCount = 1;
            copyRegion.imageExtent = aExtent;

            vkCmdCopyBufferToImage(cmd.VkCommandBuffer, staging.Buffer, VkImage, VkImageLayout.TransferDstOptimal, 1, &copyRegion);

            cmd.TransitionImage(this, VkImageLayout.ReadOnlyOptimal);
        });
        
        if (aStagingBuffer == null)
            staging.Destroy();
    }
    
    private void UploadData()
    {
        
    }
    
    public void Destroy()
    {
        ImageView.Destroy();

        Vma.vmaDestroyImage(GlobalAllocator.VmaAllocator, VkImage, Allocation);
    }

    public VkRenderingAttachmentInfo GetAttachmentInfo(VkClearValue? aClear,  VkImageLayout aLayout = VkImageLayout.ColorAttachmentOptimal)
    {
        VkRenderingAttachmentInfo colorAttachment = new();

        colorAttachment.imageView = ImageView.VkImageView;
        colorAttachment.imageLayout = aLayout;
        colorAttachment.loadOp = aClear == null ? VkAttachmentLoadOp.Load : VkAttachmentLoadOp.Clear;
        colorAttachment.storeOp = VkAttachmentStoreOp.Store;
        if (aClear.HasValue)
            colorAttachment.clearValue = aClear.Value;

        return colorAttachment;
    }
    
    public VkRenderingAttachmentInfo GetDepthAttachmentInfo(VkImageLayout layout = VkImageLayout.DepthAttachmentOptimal)
    {
        VkRenderingAttachmentInfo depthAttachment = new();
        
        depthAttachment.imageView = ImageView.VkImageView;
        depthAttachment.imageLayout = layout;
        depthAttachment.loadOp = VkAttachmentLoadOp.Clear;
        depthAttachment.storeOp = VkAttachmentStoreOp.Store;
        depthAttachment.clearValue.depthStencil = new(0f, 0);

        return depthAttachment;
    }
    
    public VkRenderingInfo GetRenderingInfo(VkExtent2D renderExtent, VkRenderingAttachmentInfo colorAttachment, VkRenderingAttachmentInfo depthAttachment)
    {
        VkRenderingInfo renderInfo = new();
        
        renderInfo.renderArea = new VkRect2D(new VkOffset2D ( 0, 0 ), renderExtent);
        renderInfo.layerCount = 1;
        renderInfo.colorAttachmentCount = 1;
        renderInfo.pColorAttachments = &colorAttachment;
        renderInfo.pDepthAttachment = &depthAttachment;
        
        renderInfo.pStencilAttachment = null;

        return renderInfo;
    }
}