namespace Graphics;

public unsafe class Swapchain : IGpuDestroyable
{
    public VkSwapchainKHR MyVkSwapchain;

    public VkFormat MyImageFormat;
    public VkExtent2D MyExtents;
    public readonly List<VkImage> MyImages;

    public Swapchain(VkSurfaceFormatKHR WindowSurfaceFormat, VkPresentModeKHR aPresentMode, VkExtent2D aExtents, Surface aSurface)
    {
        MyExtents = aExtents;
        MyImageFormat = WindowSurfaceFormat.format;

        var surfaceCapabilities = aSurface.MySurfaceCapabilities;
        
        uint imageCount = (surfaceCapabilities.minImageCount + 1);
        if (surfaceCapabilities.maxImageCount > 0)
            imageCount = imageCount.AtMost(surfaceCapabilities.maxImageCount);

        VkSwapchainCreateInfoKHR createInfo = new();
        createInfo.minImageCount = imageCount;
        createInfo.imageFormat = WindowSurfaceFormat.format;
        createInfo.imageColorSpace = WindowSurfaceFormat.colorSpace;
        createInfo.presentMode = aPresentMode;
        createInfo.imageExtent = MyExtents;
        createInfo.imageArrayLayers = 1;
        createInfo.imageUsage = VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst;

        var families = GpuInstance.FindQueueFamilies(aSurface.MyVkSurface);
        bool differentFamiliesForPresentingAndRastering = families.presentFamily != families.graphicsFamily;
        
        createInfo.imageSharingMode = differentFamiliesForPresentingAndRastering ? VkSharingMode.Concurrent : VkSharingMode.Exclusive;
        createInfo.preTransform = surfaceCapabilities.currentTransform;
        createInfo.compositeAlpha = VkCompositeAlphaFlagsKHR.Opaque;
        createInfo.clipped = true;
        createInfo.oldSwapchain = VkSwapchainKHR.Null;
        createInfo.surface = aSurface.MyVkSurface;

        vkCreateSwapchainKHR(Device.MyVkDevice, &createInfo, null, out MyVkSwapchain).CheckResult();
        
        ReadOnlySpan<VkImage> images = vkGetSwapchainImagesKHR(Device.MyVkDevice, MyVkSwapchain);
        MyImages = images.ToArray().ToList();
    }
    
    public List<ImageView> CreateImageViews()
    {
        List<ImageView> views = new();
        foreach(var image in MyImages)
        {
            views.Add(new(image, MyImageFormat, VkImageAspectFlags.Color){});
        }

        return views;
    }
    
    public void Destroy()
    {
        vkDestroySwapchainKHR(Device.MyVkDevice, MyVkSwapchain);
    }
}