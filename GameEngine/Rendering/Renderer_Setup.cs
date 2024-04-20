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
        
        vkInitialize();

        if (PrintExtensions)
            PrintAllAvailableInstanceExtensions();
        
        CreateVulkanInstance(aWindow);
        
        CreateSurface(aWindow);

        PickPhysicalDevice();

        if (PrintExtensions)
            PrintAllAvailableDeviceExtensions();

        CreateLogicalDevice();

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
            
            vkCreateCommandPool(myDevice, &createInfo, null, out newFrame.MyCommandPool).CheckResult();

            VkCommandBufferAllocateInfo allocateInfo = new();
            allocateInfo.commandPool = newFrame.MyCommandPool;
            allocateInfo.commandBufferCount = 1;
            allocateInfo.level = VkCommandBufferLevel.Primary;

            vkAllocateCommandBuffer(myDevice, &allocateInfo, out newFrame.MyCommandBuffer).CheckResult();

            vkCreateSemaphore(myDevice, out newFrame.MyRenderFinishedSemaphore).CheckResult();
            vkCreateSemaphore(myDevice, out newFrame.MyImageAvailableSemaphore).CheckResult();

            vkCreateFence(myDevice, VkFenceCreateFlags.Signaled, out newFrame.MyRenderFence).CheckResult();

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

            vkCreateImageView(myDevice, &createInfo, null, out var view).CheckResult();
            myImageViews.Add(view);
        }
    }

    private VkSurfaceFormatKHR GetFormat()
    {
        ReadOnlySpan<VkSurfaceFormatKHR> formats = vkGetPhysicalDeviceSurfaceFormatsKHR(myPhysicalDevice, mySurface);
        
        foreach(VkSurfaceFormatKHR format in formats)
        {
            if (format.format == PreferredFormat && format.colorSpace == PreferredColorSpace)
                return format;
        }

        return formats[0];
    }
    
    private VkPresentModeKHR GetPresentMode()
    {
        ReadOnlySpan<VkPresentModeKHR> presentModes = vkGetPhysicalDeviceSurfacePresentModesKHR(myPhysicalDevice, mySurface);
        
        foreach(VkPresentModeKHR presentMode in presentModes)
        {
            if (presentMode == PreferredPresentMode)
                return presentMode;
        }

        return presentModes[0];
    }
    
    private VkExtent2D GetSwapbufferExtent()
    {
        if (mySurfaceCapabilities.currentExtent.width != uint.MaxValue)
        {
            return mySurfaceCapabilities.currentExtent;
        }

        (int width, int height) size = myWindow.GetFramebufferSize();

        VkExtent2D extent;
        extent.width = ((uint)size.width);
        extent.height = (uint)size.height;

        extent.width = extent.width.Within(mySurfaceCapabilities.minImageExtent.width, mySurfaceCapabilities.maxImageExtent.width);
        extent.height = extent.height.Within(mySurfaceCapabilities.minImageExtent.height, mySurfaceCapabilities.maxImageExtent.height);

        return extent;
    }

    private void CreateSwapchain()
    {
        VkSurfaceFormatKHR surfaceFormat = GetFormat();
        VkPresentModeKHR presentMode = GetPresentMode();
        
        mySwapchainExtents = GetSwapbufferExtent();
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

        var families = FindQueueFamilies(myPhysicalDevice, mySurface);
        bool differentFamiliesForPresentingAndRastering = families.presentFamily != families.graphicsFamily;
        
        createInfo.imageSharingMode = differentFamiliesForPresentingAndRastering ? VkSharingMode.Concurrent : VkSharingMode.Exclusive;
        createInfo.preTransform = mySurfaceCapabilities.currentTransform;
        createInfo.compositeAlpha = VkCompositeAlphaFlagsKHR.Opaque;
        createInfo.clipped = true;
        createInfo.oldSwapchain = VkSwapchainKHR.Null;
        createInfo.surface = mySurface;

        vkCreateSwapchainKHR(myDevice, &createInfo, null, out mySwapchain).CheckResult();

        ReadOnlySpan<VkImage> images = vkGetSwapchainImagesKHR(myDevice, mySwapchain);
        myImages = images.ToArray().ToList();
    }

    private void CreateSurface(Window aWindow)
    {
        switch (GetDisplayServer())
        {
            case DisplayServer.Windows:
            {
                VkWin32SurfaceCreateInfoKHR createInfo = new VkWin32SurfaceCreateInfoKHR()
                {
                    hwnd = aWindow.Hwnd,
                    hinstance = System.Diagnostics.Process.GetCurrentProcess().Handle,
                    
                };
                fixed (VkSurfaceKHR* surfacePtr = &mySurface)
                {
                    vkCreateWin32SurfaceKHR(myVulkanInstance, &createInfo, null, surfacePtr).CheckResult();
                }
                break;
            }
            case DisplayServer.X11:
            {
                VkXlibSurfaceCreateInfoKHR createInfo = new ()
                {
                    display = aWindow.X11Display,
                    window = (UIntPtr)(long)aWindow.X11Window
                };
                fixed (VkSurfaceKHR* surfacePtr = &mySurface)
                {
                    vkCreateXlibSurfaceKHR(myVulkanInstance, &createInfo, null, surfacePtr).CheckResult();
                }
                break;
            }
            case DisplayServer.Wayland:
            {
                VkWaylandSurfaceCreateInfoKHR createInfo = new ()
                {
                    display = aWindow.WaylandDisplay,
                    surface = aWindow.WaylandWindow
                };
                fixed (VkSurfaceKHR* surfacePtr = &mySurface)
                {
                    vkCreateWaylandSurfaceKHR(myVulkanInstance, &createInfo, null, surfacePtr).CheckResult();
                }
                break;
            }
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void CreateVulkanInstance(Window aWindow)
    {
        VkApplicationInfo appInfo = new VkApplicationInfo
        {
            pApplicationName = aWindow.Name.ToSPointer(),
            pEngineName = "Have A Great Day".ToSPointer(),
            applicationVersion = VkVersion.Version_1_3,
            apiVersion = VkVersion.Version_1_3,
            engineVersion = VkVersion.Version_1_3
        };

        VkInstanceCreateInfo info = new();
        info.pApplicationInfo = &appInfo;
        
        IntPtr* extensionsToBytesArray = stackalloc IntPtr[InstanceExtensions.Length];
        for (int i = 0; i < InstanceExtensions.Length; i++)
        {
            extensionsToBytesArray[i] = Marshal.StringToHGlobalAnsi(InstanceExtensions[i]);
        }

        info.enabledExtensionCount = (uint)InstanceExtensions.Length;
        info.ppEnabledExtensionNames = (sbyte**)extensionsToBytesArray;
        
#if DEBUG
        IntPtr* layersToBytesArray = stackalloc IntPtr[ValidationLayers.Length];
        for (int i = 0; i < ValidationLayers.Length; i++)
        {
            layersToBytesArray[i] = Marshal.StringToHGlobalAnsi(ValidationLayers[i]);
        }

        info.enabledLayerCount = (uint)ValidationLayers.Length;
        info.ppEnabledLayerNames = (sbyte**)layersToBytesArray;      
           
        VkDebugUtilsMessengerCreateInfoEXT debugUtilsCreateInfo = new(); 
        debugUtilsCreateInfo.messageSeverity = VkDebugUtilsMessageSeverityFlagsEXT.Error | VkDebugUtilsMessageSeverityFlagsEXT.Warning;
        debugUtilsCreateInfo.messageType = VkDebugUtilsMessageTypeFlagsEXT.Validation | VkDebugUtilsMessageTypeFlagsEXT.Performance;
        debugUtilsCreateInfo.pfnUserCallback = &DebugMessengerCallback;
        info.pNext = &debugUtilsCreateInfo;
#else
        createInfo.enabledLayerCount = 0;
        createInfo.pNext = null;
#endif
        vkCreateInstance(&info, null, out myVulkanInstance).CheckResult();
        vkLoadInstanceOnly(myVulkanInstance);
        vkCreateDebugUtilsMessengerEXT(myVulkanInstance, &debugUtilsCreateInfo, null, out myDebugMessenger).CheckResult(); 
    }

    private void PickPhysicalDevice()
    { 
        uint physicalDevicesCount = 0;
        vkEnumeratePhysicalDevices(myVulkanInstance, &physicalDevicesCount, null).CheckResult();

        if (physicalDevicesCount == 0)
        {
            throw new Exception("Vulkan: Failed to find GPUs with Vulkan support");
        }

        VkPhysicalDevice* physicalDevices = stackalloc VkPhysicalDevice[(int)physicalDevicesCount];
        vkEnumeratePhysicalDevices(myVulkanInstance, &physicalDevicesCount, physicalDevices).CheckResult();

        for (int i = 0; i < physicalDevicesCount; i++)
        {
            VkPhysicalDevice physicalDevice = physicalDevices[i];

            if (IsDeviceSuitable(physicalDevice, mySurface) == false)
                continue;

            vkGetPhysicalDeviceProperties(physicalDevice, out VkPhysicalDeviceProperties checkProperties);
            bool discrete = checkProperties.deviceType == VkPhysicalDeviceType.DiscreteGpu;

            if (discrete || myPhysicalDevice.IsNull)
            {
                myPhysicalDevice = physicalDevice;
                if (discrete)
                {
                    // Prioritize discrete GPU
                    break;
                }
            }
        }
    }
    
    private void CreateLogicalDevice()
    {
        var indices = FindQueueFamilies(myPhysicalDevice, mySurface);

        myGraphicsFamily = indices.graphicsFamily;

        float queuePriority = 1f;
        VkDeviceQueueCreateInfo deviceQueueCreateInfo = new();
        deviceQueueCreateInfo.queueFamilyIndex = indices.graphicsFamily;
        deviceQueueCreateInfo.queueCount = 1;
        deviceQueueCreateInfo.pQueuePriorities = &queuePriority;

        VkPhysicalDeviceFeatures deviceFeatures = new();

        VkPhysicalDeviceVulkan13Features device13Features = new();
        device13Features.synchronization2 = true;

        
        VkDeviceCreateInfo deviceCreateInfo = new();
        deviceCreateInfo.pNext = &device13Features;
        deviceCreateInfo.pQueueCreateInfos = &deviceQueueCreateInfo;
        deviceCreateInfo.queueCreateInfoCount = 1;
        deviceCreateInfo.pEnabledFeatures = &deviceFeatures;
        
        IntPtr* extensionsToBytesArray = stackalloc IntPtr[DeviceExtensions.Length];
        for (int i = 0; i < DeviceExtensions.Length; i++)
        {
            extensionsToBytesArray[i] = Marshal.StringToHGlobalAnsi(DeviceExtensions[i]);
        }

        deviceCreateInfo.enabledExtensionCount = (uint)DeviceExtensions.Length;
        deviceCreateInfo.ppEnabledExtensionNames = (sbyte**)extensionsToBytesArray;

        vkCreateDevice(myPhysicalDevice, &deviceCreateInfo, null, out myDevice).CheckResult();

        vkLoadDevice(myDevice);
        
        vkGetDeviceQueue(myDevice, indices.graphicsFamily, 0, out myDrawQueue);
    }
    
    private bool IsDeviceSuitable(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface)
    {
        var checkQueueFamilies = FindQueueFamilies(physicalDevice, surface);
        if (checkQueueFamilies.graphicsFamily == VK_QUEUE_FAMILY_IGNORED)
            return false;

        if (checkQueueFamilies.presentFamily == VK_QUEUE_FAMILY_IGNORED)
            return false;

        Helpers.SwapChainSupportDetails swapChainSupport = Helpers.QuerySwapChainSupport(physicalDevice, surface);

        mySurfaceCapabilities = swapChainSupport.Capabilities;
        
        return !swapChainSupport.Formats.IsEmpty && !swapChainSupport.PresentModes.IsEmpty;
    } 
    
    static (uint graphicsFamily, uint presentFamily) FindQueueFamilies(VkPhysicalDevice device, VkSurfaceKHR surface)
    {
        ReadOnlySpan<VkQueueFamilyProperties> queueFamilies = vkGetPhysicalDeviceQueueFamilyProperties(device);

        uint graphicsFamily = VK_QUEUE_FAMILY_IGNORED;
        uint presentFamily = VK_QUEUE_FAMILY_IGNORED;
        uint i = 0;
        foreach (VkQueueFamilyProperties queueFamily in queueFamilies)
        {
            if ((queueFamily.queueFlags & VkQueueFlags.Graphics) != VkQueueFlags.None)
            {
                graphicsFamily = i;
            }

            vkGetPhysicalDeviceSurfaceSupportKHR(device, i, surface, out VkBool32 presentSupport);
            if (presentSupport)
            {
                presentFamily = i;
            }

            if (graphicsFamily != VK_QUEUE_FAMILY_IGNORED
                && presentFamily != VK_QUEUE_FAMILY_IGNORED)
            {
                break;
            }

            i++;
        }

        return (graphicsFamily, presentFamily);
    }
    
    public void Cleanup()
    {
        Console.WriteLine("Destroying renderer...");
        
        vkDeviceWaitIdle(myDevice);
        
        foreach (var frameData in myFrameData)
        {
            vkDestroyCommandPool(myDevice, frameData.MyCommandPool);
            vkDestroySemaphore(myDevice, frameData.MyRenderFinishedSemaphore);
            vkDestroySemaphore(myDevice, frameData.MyImageAvailableSemaphore);
            vkDestroyFence(myDevice, frameData.MyRenderFence);
        }

        myFrameData.Clear();

        vkDeviceWaitIdle(myDevice);
        
        foreach(var imageView in myImageViews)
            vkDestroyImageView(myDevice, imageView, null);
        
        myImageViews.Clear();
        
        vkDestroySwapchainKHR(myDevice, mySwapchain);
        
        vkDestroySurfaceKHR(myVulkanInstance, mySurface);
        vkDestroyDevice(myDevice);
        
        vkDestroyDebugUtilsMessengerEXT(myVulkanInstance, myDebugMessenger);
        vkDestroyInstance(myVulkanInstance);
        
        Console.WriteLine("Renderer successfully destroyed!");
    }
}