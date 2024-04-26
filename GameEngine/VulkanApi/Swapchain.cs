namespace Graphics;

public unsafe class Swapchain
{
    public VkSwapchainKHR MyVkSwapchain;

    public VkFormat MyImageFormat;
    public VkExtent2D MyExtents;
    public readonly List<VkImage> MyImages;

    public Swapchain(Device aDevice, Gpu aGpu, Surface aSurface, VkSurfaceFormatKHR aSurfaceFormat, VkPresentModeKHR aPresentMode)
    {
        MyExtents = aSurface.GetSwapbufferExtent();
        MyImageFormat = aSurfaceFormat.format;

        var surfaceCapabilities = aSurface.MySurfaceCapabilities;
        
        uint imageCount = (surfaceCapabilities.minImageCount + 1);
        if (surfaceCapabilities.maxImageCount > 0)
            imageCount = imageCount.AtMost(surfaceCapabilities.maxImageCount);

        VkSwapchainCreateInfoKHR createInfo = new();
        createInfo.minImageCount = imageCount;
        createInfo.imageFormat = aSurfaceFormat.format;
        createInfo.imageColorSpace = aSurfaceFormat.colorSpace;
        createInfo.presentMode = aPresentMode;
        createInfo.imageExtent = MyExtents;
        createInfo.imageArrayLayers = 1;
        createInfo.imageUsage = VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst;

        var families = aGpu.FindQueueFamilies(aSurface.MyVkSurface);
        bool differentFamiliesForPresentingAndRastering = families.presentFamily != families.graphicsFamily;
        
        createInfo.imageSharingMode = differentFamiliesForPresentingAndRastering ? VkSharingMode.Concurrent : VkSharingMode.Exclusive;
        createInfo.preTransform = surfaceCapabilities.currentTransform;
        createInfo.compositeAlpha = VkCompositeAlphaFlagsKHR.Opaque;
        createInfo.clipped = true;
        createInfo.oldSwapchain = VkSwapchainKHR.Null;
        createInfo.surface = aSurface.MyVkSurface;

        vkCreateSwapchainKHR(aDevice.MyVkDevice, &createInfo, null, out MyVkSwapchain).CheckResult();
        
        ReadOnlySpan<VkImage> images = vkGetSwapchainImagesKHR(aDevice.MyVkDevice, MyVkSwapchain);
        MyImages = images.ToArray().ToList();
    }
    
    public List<ImageView> CreateImageViews(Device aDevice)
    {
        List<ImageView> views = new();
        foreach(var image in MyImages)
        {
            VkImageViewCreateInfo createInfo = new();

            createInfo.image = image;
            createInfo.format = MyImageFormat;
            
            createInfo.components = VkComponentMapping.Identity;
            createInfo.viewType = VkImageViewType.Image2D;
            createInfo.subresourceRange.aspectMask = VkImageAspectFlags.Color;
            createInfo.subresourceRange.baseMipLevel = 0;
            createInfo.subresourceRange.levelCount = 1;
            createInfo.subresourceRange.baseArrayLayer = 0;
            createInfo.subresourceRange.layerCount = 1;

            vkCreateImageView(aDevice.MyVkDevice, &createInfo, null, out var view).CheckResult();
            views.Add(new(){MyVkImageView = view});
        }

        return views;
    }
    
    public void Destroy(Device aDevice)
    {
        vkDestroySwapchainKHR(aDevice.MyVkDevice, MyVkSwapchain);
    }
}