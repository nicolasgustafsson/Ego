using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;
using System.Runtime.InteropServices;

namespace Rendering;

public unsafe partial class Engine
{
    public void Init(Window aWindow)
    {
        InitVulkan(aWindow);
    }
    
    private void InitVulkan(Window aWindow)
    {
        CreateVulkanInstance(aWindow);
        
        CreateSurface(aWindow);

        PickPhysicalDevice();
    }

    private void CreateSurface(Window aWindow)
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
    }

    private void CreateVulkanInstance(Window aWindow)
    {
        VkApplicationInfo appInfo = new VkApplicationInfo(){};
        
        appInfo.pApplicationName = aWindow.Name.ToSPointer();
        appInfo.pEngineName = aWindow.Name.ToSPointer();
        
        appInfo.applicationVersion = VkVersion.Version_1_3;
        appInfo.apiVersion = VkVersion.Version_1_3;
        appInfo.engineVersion = VkVersion.Version_1_3;

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
                    // If this is discrete GPU, look no further (prioritize discrete GPU)
                    break;
                }
            }
        }
    }
    
    private static bool IsDeviceSuitable(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface)
    {
        var checkQueueFamilies = FindQueueFamilies(physicalDevice, surface);
        if (checkQueueFamilies.graphicsFamily == VK_QUEUE_FAMILY_IGNORED)
            return false;

        if (checkQueueFamilies.presentFamily == VK_QUEUE_FAMILY_IGNORED)
            return false;

        Helpers.SwapChainSupportDetails swapChainSupport = Helpers.QuerySwapChainSupport(physicalDevice, surface);
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
        vkDestroyInstance(myVulkanInstance);
    }
}