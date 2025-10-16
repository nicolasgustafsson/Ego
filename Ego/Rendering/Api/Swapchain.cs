namespace VulkanApi;

public unsafe class Swapchain : IGpuDestroyable
{
    public VkSwapchainKHR VkSwapchain;

    public VkFormat ImageFormat;
    public VkExtent2D Extents;
    public readonly List<VkImage> Images;

    public Swapchain(VkSurfaceFormatKHR WindowSurfaceFormat, VkPresentModeKHR aPresentMode, VkExtent2D aExtents, Surface aSurface)
    {
        Extents = aExtents;
        ImageFormat = WindowSurfaceFormat.format;

        var surfaceCapabilities = aSurface.SurfaceCapabilities;
        
        uint imageCount = (surfaceCapabilities.minImageCount + 1);
        if (surfaceCapabilities.maxImageCount > 0)
            imageCount = imageCount.AtMost(surfaceCapabilities.maxImageCount);

        VkSwapchainCreateInfoKHR createInfo = new();
        createInfo.minImageCount = imageCount;
        createInfo.imageFormat = WindowSurfaceFormat.format;
        createInfo.imageColorSpace = WindowSurfaceFormat.colorSpace;
        createInfo.presentMode = aPresentMode;
        createInfo.imageExtent = Extents;
        createInfo.imageArrayLayers = 1;
        createInfo.imageUsage = VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst;

        var families = GpuInstance.FindQueueFamilies(aSurface.VkSurface);
        bool differentFamiliesForPresentingAndRastering = families.presentFamily != families.graphicsFamily;
        
        createInfo.imageSharingMode = differentFamiliesForPresentingAndRastering ? VkSharingMode.Concurrent : VkSharingMode.Exclusive;
        createInfo.preTransform = surfaceCapabilities.currentTransform;
        createInfo.compositeAlpha = VkCompositeAlphaFlagsKHR.Opaque;
        createInfo.clipped = true;
        createInfo.oldSwapchain = VkSwapchainKHR.Null;
        createInfo.surface = aSurface.VkSurface;

        vkCreateSwapchainKHR(Device.VkDevice, &createInfo, null, out VkSwapchain).CheckResult();
        
        ReadOnlySpan<VkImage> images = vkGetSwapchainImagesKHR(Device.VkDevice, VkSwapchain);
        Images = images.ToArray().ToList();
    }
    
    public List<ImageView> CreateImageViews()
    {
        List<ImageView> views = new();
        foreach(var image in Images)
        {
            views.Add(new(image, ImageFormat, VkImageAspectFlags.Color){});
        }

        return views;
    }
    
    public void Destroy()
    {
        vkDestroySwapchainKHR(Device.VkDevice, VkSwapchain);
    }
}