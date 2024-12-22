global using static VulkanApi.Gpu;
using System.Runtime.InteropServices;

namespace VulkanApi;

public unsafe class Gpu
{
    public VkPhysicalDevice VkPhysicalDevice;
    public static Gpu GpuInstance = null!;

    public uint GraphicsFamily;
    public uint PresentFamily;
    
    internal Gpu(Api aApi)
    {
        uint physicalDevicesCount = 0;
        vkEnumeratePhysicalDevices(aApi.VkInstance, &physicalDevicesCount, null).CheckResult();

        if (physicalDevicesCount == 0)
        {
            throw new Exception("Vulkan: Failed to find GPUs with Vulkan support");
        }

        VkPhysicalDevice* physicalDevices = stackalloc VkPhysicalDevice[(int)physicalDevicesCount];
        vkEnumeratePhysicalDevices(aApi.VkInstance, &physicalDevicesCount, physicalDevices).CheckResult();

        for (int i = 0; i < physicalDevicesCount; i++)
        {
            VkPhysicalDevice physicalDevice = physicalDevices[i];

            (GraphicsFamily, PresentFamily) = FindQueueFamilies(physicalDevice, MainWindowSurface.VkSurface);
            
            if (IsDeviceSuitable(physicalDevice) == false)
                continue;

            vkGetPhysicalDeviceProperties(physicalDevice, out VkPhysicalDeviceProperties checkProperties);
            bool discrete = checkProperties.deviceType == VkPhysicalDeviceType.DiscreteGpu;

            if (discrete || VkPhysicalDevice.IsNull)
            {
                VkPhysicalDevice = physicalDevice;
                if (discrete)
                {
                    // Prioritize discrete GPU
                    break;
                }
            }
        }

        GpuInstance = this;

    }
    
    private bool IsDeviceSuitable(VkPhysicalDevice physicalDevice)
    {
        if (GraphicsFamily == VK_QUEUE_FAMILY_IGNORED)
            return false;

        if (PresentFamily == VK_QUEUE_FAMILY_IGNORED)
            return false;

        Helpers.SwapChainSupportDetails swapChainSupport = Helpers.QuerySwapChainSupport(physicalDevice, MainWindowSurface.VkSurface);

        MainWindowSurface.SurfaceCapabilities = swapChainSupport.Capabilities;
        
        return !swapChainSupport.Formats.IsEmpty && !swapChainSupport.PresentModes.IsEmpty;
    }
    
    public void CreateDevice(List<string> aDeviceExtensions)
    {
        string[] deviceExtensions = aDeviceExtensions.ToArray();
        LogicalDevice logicalDevice = new();
        
        float queuePriority = 1f;
        VkDeviceQueueCreateInfo deviceQueueCreateInfo = new();
        deviceQueueCreateInfo.queueFamilyIndex = GraphicsFamily;
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
        deviceCreateInfo.ppEnabledExtensionNames = (byte**)extensionsToBytesArray;

        vkCreateDevice(VkPhysicalDevice, &deviceCreateInfo, null, out logicalDevice.VkDevice).CheckResult();

        logicalDevice.LoadFunctions();

        Device = logicalDevice;
    }
    
    public (uint graphicsFamily, uint presentFamily) FindQueueFamilies()
    {
        return FindQueueFamilies(VkPhysicalDevice, MainWindowSurface.VkSurface);
    }
    
    public (uint graphicsFamily, uint presentFamily) FindQueueFamilies(VkSurfaceKHR aSurface)
    {
        return FindQueueFamilies(VkPhysicalDevice, aSurface);
    }
    
    public (uint graphicsFamily, uint presentFamily) FindQueueFamilies(VkPhysicalDevice aDevice, VkSurfaceKHR WindowSurface)
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

            vkGetPhysicalDeviceSurfaceSupportKHR(aDevice, i, WindowSurface, out VkBool32 presentSupport);
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

    public VkSurfaceFormatKHR GetSurfaceFormat(VkFormat aPreferredFormat, VkColorSpaceKHR aPreferredColorSpace)
    {
        ReadOnlySpan<VkSurfaceFormatKHR> formats = vkGetPhysicalDeviceSurfaceFormatsKHR(VkPhysicalDevice, MainWindowSurface.VkSurface);
        
        foreach(VkSurfaceFormatKHR format in formats)
        {
            if (format.format == aPreferredFormat && format.colorSpace == aPreferredColorSpace)
                return format;
        }

        return formats[0];
    }

    public VkPresentModeKHR GetPresentMode(VkPresentModeKHR aPreferredPresentMode)
    {
        ReadOnlySpan<VkPresentModeKHR> presentModes = vkGetPhysicalDeviceSurfacePresentModesKHR(VkPhysicalDevice, MainWindowSurface.VkSurface);
        
        foreach(VkPresentModeKHR presentMode in presentModes)
        {
            if (presentMode == aPreferredPresentMode)
                return presentMode;
        }

        return presentModes[0];
    }
    
    public void PrintAllAvailableDeviceExtensions()
    {
        Log.Information("--- AVAILABLE DEVICE EXTENSIONS ---");
        uint extensionCount = 0;
        vkEnumerateDeviceExtensionProperties(VkPhysicalDevice, null, &extensionCount, null).CheckResult();
        VkExtensionProperties* extensions = stackalloc VkExtensionProperties[(int)extensionCount];
        vkEnumerateDeviceExtensionProperties(VkPhysicalDevice, null, &extensionCount, extensions).CheckResult();

        for (int i = 0; i < extensionCount; i++)
        {
            Log.Information($"Extension: {Helpers.GetString((sbyte*)extensions[i].extensionName)} version: {extensions[i].specVersion}");
        }
        Log.Information("--- ---------------------------- ---");
    }
}