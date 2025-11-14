using System.Diagnostics;
using System.Numerics;
using Ego;
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
    public int? Index;
    
    public VkImageLayout CurrentLayout = VkImageLayout.Undefined;
    
    public Image(VkFormat aFormat, VkImageUsageFlags aUsageFlags, VkExtent3D aExtent, bool aMipMaps, bool aIsRenderTexture, VkSampleCountFlags aSamples = VkSampleCountFlags.Count1)
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
        
        createInfo.samples = aSamples;
        
        createInfo.tiling = VkImageTiling.Optimal;
        createInfo.usage = aUsageFlags;
        
        if (!aIsRenderTexture)
        {
            createInfo.sharingMode = VkSharingMode.Concurrent;
            ReadOnlySpan<uint> queueFamilies = [GpuInstance.GraphicsFamily, GpuInstance.TransferFamily]; 
            createInfo.pQueueFamilyIndices = queueFamilies.GetPointerUnsafe();
            createInfo.queueFamilyIndexCount = (uint)queueFamilies.Length;
        }

        VmaAllocationCreateInfo allocCreateInfo = new();
        allocCreateInfo.usage = VmaMemoryUsage.GpuOnly;
        allocCreateInfo.requiredFlags = VkMemoryPropertyFlags.DeviceLocal;
        
        Vma.vmaCreateImage(GlobalAllocator.VmaAllocator, &createInfo, &allocCreateInfo, out VkImage, out Allocation, out VmaAllocationInfo allocInfo).CheckResult();

        ImageView = new(VkImage, aFormat, (int)(aUsageFlags & VkImageUsageFlags.DepthStencilAttachment) != 0 ? VkImageAspectFlags.Depth : VkImageAspectFlags.Color, createInfo.mipLevels);

        if ((aUsageFlags & VkImageUsageFlags.Sampled) > 0)
            AddToRegistry();
    }
    
    public Image(Span<byte> aData, VkFormat aFormat, VkImageUsageFlags aUsageFlags, VkExtent3D aExtent, bool aMipMaps) : this(aFormat, aUsageFlags | VkImageUsageFlags.TransferDst, aExtent, aMipMaps, aIsRenderTexture: false)
    {
        GpuDataTransferer.Instance.TransferTextureImmediate(this, aData);
    }

    public Image(byte* aData, VkFormat aFormat, VkImageUsageFlags aUsageFlags, VkExtent3D aExtent, bool aMipMaps) : 
        this(new Span<byte>(aData, (int)(aExtent.width * aExtent.height * aExtent.depth * 4)), aFormat, aUsageFlags, aExtent, aMipMaps)
    {
    }
    
    //Todo: We should wait a few frames before actually destroying, so that the renderer will stop using it.
    public void Destroy()
    {
        ImageView.Destroy();

        Vma.vmaDestroyImage(GlobalAllocator.VmaAllocator, VkImage, Allocation);
        
        if (Index != null)
            ImageRegistry.RemoveImage(this);
    }
    
    public void AddToRegistry()
    {
        Index = ImageRegistry.AddImage(this);
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
    
    public VkRenderingInfo GetRenderingInfo(VkExtent2D renderExtent, VkRenderingAttachmentInfo colorAttachment)
    {
        VkRenderingInfo renderInfo = new();
        
        renderInfo.renderArea = new VkRect2D(new VkOffset2D ( 0, 0 ), renderExtent);
        renderInfo.layerCount = 1;
        renderInfo.colorAttachmentCount = 1;
        renderInfo.pColorAttachments = &colorAttachment;
        renderInfo.pDepthAttachment = null;
        
        renderInfo.pStencilAttachment = null;

        return renderInfo;
    }
}