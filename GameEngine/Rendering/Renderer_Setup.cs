global using Utilities.CommonExtensions;
using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;
using System.Runtime.InteropServices;

namespace Rendering;

public unsafe partial class Renderer
{
    private void Init(Window aWindow)
    {
        InitVulkan(aWindow);
    }
    
    private void InitVulkan(Window aWindow)
    {
        Console.WriteLine("Creating renderer...");
        
        myApi = new(aWindow, Graphics.Defaults.InstanceExtensions);

        if (PrintExtensions)
            myApi.PrintAllAvailableInstanceExtensions();

        mySurface = myApi.CreateSurface(aWindow);

        myGpu = myApi.PickGpu(mySurface);

        if (PrintExtensions)
            myGpu.PrintAllAvailableDeviceExtensions();

        myDevice = myGpu.CreateDevice(mySurface, Graphics.Defaults.DeviceExtensions);

        CreateSwapchain();

        CreateImageViews();

        CreateFrameData();
        
        Console.WriteLine("Renderer successfully created!");
    }
    
    private void CreateFrameData()
    {
        VkCommandPoolCreateInfo createInfo = new();
        createInfo.flags = VkCommandPoolCreateFlags.ResetCommandBuffer;
        createInfo.queueFamilyIndex = myGraphicsFamily;
        
        for(int i = 0; i < FrameOverlap; i++)
        {
            FrameData newFrame = new();
            
            vkCreateCommandPool(myVkDevice, &createInfo, null, out newFrame.MyCommandPool).CheckResult();

            VkCommandBufferAllocateInfo allocateInfo = new();
            allocateInfo.commandPool = newFrame.MyCommandPool;
            allocateInfo.commandBufferCount = 1;
            allocateInfo.level = VkCommandBufferLevel.Primary;

            vkAllocateCommandBuffer(myVkDevice, &allocateInfo, out newFrame.MyCommandBuffer).CheckResult();

            vkCreateSemaphore(myVkDevice, out newFrame.MyRenderFinishedSemaphore).CheckResult();
            vkCreateSemaphore(myVkDevice, out newFrame.MyImageAvailableSemaphore).CheckResult();

            vkCreateFence(myVkDevice, VkFenceCreateFlags.Signaled, out newFrame.MyRenderFence).CheckResult();

            myFrameData.Add(newFrame);
        }
    }

    private void CreateImageViews()
    {
        foreach(var image in myImages)
        {
            VkImageViewCreateInfo createInfo = new();

            createInfo.image = image;
            createInfo.format = mySwapchainImageFormat;
            
            createInfo.components = VkComponentMapping.Identity;
            createInfo.viewType = VkImageViewType.Image2D;
            createInfo.subresourceRange.aspectMask = VkImageAspectFlags.Color;
            createInfo.subresourceRange.baseMipLevel = 0;
            createInfo.subresourceRange.levelCount = 1;
            createInfo.subresourceRange.baseArrayLayer = 0;
            createInfo.subresourceRange.layerCount = 1;

            vkCreateImageView(myVkDevice, &createInfo, null, out var view).CheckResult();
            myImageViews.Add(view);
        }
    }

    private VkSurfaceFormatKHR GetFormat()
    {
        ReadOnlySpan<VkSurfaceFormatKHR> formats = vkGetPhysicalDeviceSurfaceFormatsKHR(myGpu.MyPhysicalDevice, mySurface.MyVkSurface);
        
        foreach(VkSurfaceFormatKHR format in formats)
        {
            if (format.format == PreferredFormat && format.colorSpace == PreferredColorSpace)
                return format;
        }

        return formats[0];
    }
    
    private VkPresentModeKHR GetPresentMode()
    {
        ReadOnlySpan<VkPresentModeKHR> presentModes = vkGetPhysicalDeviceSurfacePresentModesKHR(myGpu.MyPhysicalDevice, mySurface.MyVkSurface);
        
        foreach(VkPresentModeKHR presentMode in presentModes)
        {
            if (presentMode == PreferredPresentMode)
                return presentMode;
        }

        return presentModes[0];
    }
    

    private void CreateSwapchain()
    {
        VkSurfaceFormatKHR surfaceFormat = GetFormat();
        VkPresentModeKHR presentMode = GetPresentMode();
        
        mySwapchainExtents = mySurface.GetSwapbufferExtent();
        mySwapchainImageFormat = surfaceFormat.format;
        
        uint imageCount = (mySurfaceCapabilities.minImageCount + 1);
        if (mySurfaceCapabilities.maxImageCount > 0)
            imageCount = imageCount.AtMost(mySurfaceCapabilities.maxImageCount);

        VkSwapchainCreateInfoKHR createInfo = new();
        createInfo.minImageCount = imageCount;
        createInfo.imageFormat = surfaceFormat.format;
        createInfo.imageColorSpace = surfaceFormat.colorSpace;
        createInfo.presentMode = presentMode;
        createInfo.imageExtent = mySwapchainExtents;
        createInfo.imageArrayLayers = 1;
        createInfo.imageUsage = VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst;

        var families = myGpu.FindQueueFamilies(mySurface.MyVkSurface);
        bool differentFamiliesForPresentingAndRastering = families.presentFamily != families.graphicsFamily;
        
        createInfo.imageSharingMode = differentFamiliesForPresentingAndRastering ? VkSharingMode.Concurrent : VkSharingMode.Exclusive;
        createInfo.preTransform = mySurfaceCapabilities.currentTransform;
        createInfo.compositeAlpha = VkCompositeAlphaFlagsKHR.Opaque;
        createInfo.clipped = true;
        createInfo.oldSwapchain = VkSwapchainKHR.Null;
        createInfo.surface = mySurface.MyVkSurface;

        vkCreateSwapchainKHR(myVkDevice, &createInfo, null, out mySwapchain).CheckResult();

        ReadOnlySpan<VkImage> images = vkGetSwapchainImagesKHR(myVkDevice, mySwapchain);
        myImages = images.ToArray().ToList();
    }
    
    public void Cleanup()
    {
        Console.WriteLine("Destroying renderer...");

        myDevice.WaitUntilIdle();
        
        foreach (var frameData in myFrameData)
        {
            vkDestroyCommandPool(myVkDevice, frameData.MyCommandPool);
            vkDestroySemaphore(myVkDevice, frameData.MyRenderFinishedSemaphore);
            vkDestroySemaphore(myVkDevice, frameData.MyImageAvailableSemaphore);
            vkDestroyFence(myVkDevice, frameData.MyRenderFence);
        }

        myFrameData.Clear();

        foreach(var imageView in myImageViews)
            vkDestroyImageView(myVkDevice, imageView, null);
        
        myImageViews.Clear();
        
        vkDestroySwapchainKHR(myVkDevice, mySwapchain);

        mySurface.Destroy(myApi);
        
        vkDestroyDevice(myVkDevice);

        myApi.Destroy();
        
        Console.WriteLine("Renderer successfully destroyed!");
    }
}