using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;
using System.Runtime.InteropServices;

namespace Rendering;

public unsafe partial class Renderer
{
    private void Init(Window aWindow)
    {
        myWindow = aWindow;
        InitVulkan(aWindow);
    }
    
    private void InitVulkan(Window aWindow)
    {
        CreateVulkanInstance(aWindow);
        
        CreateSurface(aWindow);

        PickPhysicalDevice();

        CreateLogicalDevice();

        CreateSwapchain();
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
    
    private VkExtent2D GetSwapbufferExtents()
    {
        if (mySurfaceCapabilities.currentExtent.width != uint.MaxValue)
        {
            return mySurfaceCapabilities.currentExtent;
        }

        (int width, int height) size = myWindow.GetFramebufferSize();

        VkExtent2D extent;
        extent.width = (uint)size.width;
        extent.height = (uint)size.height;
        
        
    }

    private void CreateSwapchain()
    {
        VkSurfaceFormatKHR format = GetFormat();
        VkPresentModeKHR presentMode = GetPresentMode();
        
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
                    Helpers.CheckErrors(vkCreateWin32SurfaceKHR(myVulkanInstance, &createInfo, null, surfacePtr));
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
                    Helpers.CheckErrors(vkCreateXlibSurfaceKHR(myVulkanInstance, &createInfo, null, surfacePtr));
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
                    Helpers.CheckErrors(vkCreateWaylandSurfaceKHR(myVulkanInstance, &createInfo, null, surfacePtr));
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
        
        IntPtr* extensionsToBytesArray = stackalloc IntPtr[Extensions.Length];
        for (int i = 0; i < Extensions.Length; i++)
        {
            extensionsToBytesArray[i] = Marshal.StringToHGlobalAnsi(Extensions[i]);
        }

        info.enabledExtensionCount = (uint)Extensions.Length;
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
        Helpers.CheckErrors(vkCreateInstance(&info, null, out myVulkanInstance));
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

        VkDeviceCreateInfo deviceCreateInfo = new();
        deviceCreateInfo.pQueueCreateInfos = &deviceQueueCreateInfo;
        deviceCreateInfo.queueCreateInfoCount = 1;
        deviceCreateInfo.pEnabledFeatures = &deviceFeatures;

        vkCreateDevice(myPhysicalDevice, &deviceCreateInfo, null, out myDevice);

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
        vkDestroySurfaceKHR(myVulkanInstance, mySurface);
        vkDestroyDebugUtilsMessengerEXT(myVulkanInstance, myDebugMessenger);
        vkDestroyDevice(myDevice);
        vkDestroyInstance(myVulkanInstance);
    }
}