using System.Runtime.InteropServices;

namespace Graphics;

public unsafe class Gpu
{
    public VkPhysicalDevice MyVkPhysicalDevice;

    public uint MyGraphicsFamily;
    public uint MyPresentFamily;
    
    internal Gpu(Api aApi, Surface aSurface)
    {
        uint physicalDevicesCount = 0;
        vkEnumeratePhysicalDevices(aApi.MyVkInstance, &physicalDevicesCount, null).CheckResult();

        if (physicalDevicesCount == 0)
        {
            throw new Exception("Vulkan: Failed to find GPUs with Vulkan support");
        }

        VkPhysicalDevice* physicalDevices = stackalloc VkPhysicalDevice[(int)physicalDevicesCount];
        vkEnumeratePhysicalDevices(aApi.MyVkInstance, &physicalDevicesCount, physicalDevices).CheckResult();

        for (int i = 0; i < physicalDevicesCount; i++)
        {
            VkPhysicalDevice physicalDevice = physicalDevices[i];

            (MyGraphicsFamily, MyPresentFamily) = FindQueueFamilies(physicalDevice, aSurface.MyVkSurface);
            
            if (IsDeviceSuitable(physicalDevice, aSurface) == false)
                continue;

            vkGetPhysicalDeviceProperties(physicalDevice, out VkPhysicalDeviceProperties checkProperties);
            bool discrete = checkProperties.deviceType == VkPhysicalDeviceType.DiscreteGpu;

            if (discrete || MyVkPhysicalDevice.IsNull)
            {
                MyVkPhysicalDevice = physicalDevice;
                if (discrete)
                {
                    // Prioritize discrete GPU
                    break;
                }
            }
        }

    }
    
    private bool IsDeviceSuitable(VkPhysicalDevice physicalDevice, Surface surface)
    {
        if (MyGraphicsFamily == VK_QUEUE_FAMILY_IGNORED)
            return false;

        if (MyPresentFamily == VK_QUEUE_FAMILY_IGNORED)
            return false;

        Helpers.SwapChainSupportDetails swapChainSupport = Helpers.QuerySwapChainSupport(physicalDevice, surface.MyVkSurface);

        //uggo
        surface.MySurfaceCapabilities = swapChainSupport.Capabilities;
        
        return !swapChainSupport.Formats.IsEmpty && !swapChainSupport.PresentModes.IsEmpty;
    }
    
    public void CreateDevice(List<string> aDeviceExtensions)
    {
        string[] deviceExtensions = aDeviceExtensions.ToArray();
        LogicalDevice logicalDevice = new();
        
        float queuePriority = 1f;
        VkDeviceQueueCreateInfo deviceQueueCreateInfo = new();
        deviceQueueCreateInfo.queueFamilyIndex = MyGraphicsFamily;
        deviceQueueCreateInfo.queueCount = 1;
        deviceQueueCreateInfo.pQueuePriorities = &queuePriority;

        VkPhysicalDeviceFeatures deviceFeatures = new();
        
        VkPhysicalDeviceVulkan12Features device12Features = new();
        device12Features.bufferDeviceAddress = true;
        device12Features.descriptorIndexing = true;

        VkPhysicalDeviceVulkan13Features device13Features = new();
        device13Features.synchronization2 = true;
        device13Features.dynamicRendering = true;
        device13Features.pNext = &device12Features;
        
        VkDeviceCreateInfo deviceCreateInfo = new();
        deviceCreateInfo.pNext = &device13Features;
        deviceCreateInfo.pQueueCreateInfos = &deviceQueueCreateInfo;
        deviceCreateInfo.queueCreateInfoCount = 1;
        deviceCreateInfo.pEnabledFeatures = &deviceFeatures;
        
        IntPtr* extensionsToBytesArray = stackalloc IntPtr[deviceExtensions.Length];
        for (int i = 0; i < deviceExtensions.Length; i++)
        {
            extensionsToBytesArray[i] = Marshal.StringToHGlobalAnsi(deviceExtensions[i]);
        }

        deviceCreateInfo.enabledExtensionCount = (uint)deviceExtensions.Length;
        deviceCreateInfo.ppEnabledExtensionNames = (sbyte**)extensionsToBytesArray;

        vkCreateDevice(MyVkPhysicalDevice, &deviceCreateInfo, null, out logicalDevice.MyVkDevice).CheckResult();

        logicalDevice.LoadFunctions();

        Device = logicalDevice;
    }
    
    public (uint graphicsFamily, uint presentFamily) FindQueueFamilies(Surface aSurface)
    {
        return FindQueueFamilies(MyVkPhysicalDevice, aSurface.MyVkSurface);
    }
    
    public (uint graphicsFamily, uint presentFamily) FindQueueFamilies(VkSurfaceKHR aSurface)
    {
        return FindQueueFamilies(MyVkPhysicalDevice, aSurface);
    }
    
    public (uint graphicsFamily, uint presentFamily) FindQueueFamilies(VkPhysicalDevice aDevice, VkSurfaceKHR aSurface)
    {
        ReadOnlySpan<VkQueueFamilyProperties> queueFamilies = vkGetPhysicalDeviceQueueFamilyProperties(aDevice);

        uint graphicsFamily = VK_QUEUE_FAMILY_IGNORED;
        uint presentFamily = VK_QUEUE_FAMILY_IGNORED;
        uint i = 0;
        foreach (VkQueueFamilyProperties queueFamily in queueFamilies)
        {
            if ((queueFamily.queueFlags & VkQueueFlags.Graphics) != VkQueueFlags.None)
            {
                graphicsFamily = i;
            }

            vkGetPhysicalDeviceSurfaceSupportKHR(aDevice, i, aSurface, out VkBool32 presentSupport);
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

    public VkSurfaceFormatKHR GetSurfaceFormat(Surface aSurface, VkFormat aPreferredFormat, VkColorSpaceKHR aPreferredColorSpace)
    {
        ReadOnlySpan<VkSurfaceFormatKHR> formats = vkGetPhysicalDeviceSurfaceFormatsKHR(MyVkPhysicalDevice, aSurface.MyVkSurface);
        
        foreach(VkSurfaceFormatKHR format in formats)
        {
            if (format.format == aPreferredFormat && format.colorSpace == aPreferredColorSpace)
                return format;
        }

        return formats[0];
    }

    public VkPresentModeKHR GetPresentMode(Surface aSurface, VkPresentModeKHR aPreferredPresentMode)
    {
        ReadOnlySpan<VkPresentModeKHR> presentModes = vkGetPhysicalDeviceSurfacePresentModesKHR(MyVkPhysicalDevice, aSurface.MyVkSurface);
        
        foreach(VkPresentModeKHR presentMode in presentModes)
        {
            if (presentMode == aPreferredPresentMode)
                return presentMode;
        }

        return presentModes[0];
    }
    
    public void PrintAllAvailableDeviceExtensions()
    {
        Console.WriteLine("--- AVAILABLE DEVICE EXTENSIONS ---");
        uint extensionCount = 0;
        vkEnumerateDeviceExtensionProperties(MyVkPhysicalDevice, null, &extensionCount, null).CheckResult();
        VkExtensionProperties* extensions = stackalloc VkExtensionProperties[(int)extensionCount];
        vkEnumerateDeviceExtensionProperties(MyVkPhysicalDevice, null, &extensionCount, extensions).CheckResult();

        for (int i = 0; i < extensionCount; i++)
        {
            Console.WriteLine($"Extension: {Helpers.GetString(extensions[i].extensionName)} version: {extensions[i].specVersion}");
        }
        Console.WriteLine("--- ---------------------------- ---");
    }
}