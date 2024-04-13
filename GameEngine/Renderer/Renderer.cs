using System.Runtime.InteropServices;
using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;

namespace Rendering;

enum DisplayServer
{
    Windows,
    X11,
    Wayland
}

public unsafe partial class Engine
{
    private VkInstance myVulkanInstance;
    private VkSurfaceKHR mySurface;
    private VkPhysicalDevice myPhysicalDevice; 

    private VkDebugUtilsMessengerEXT myDebugMessenger = VkDebugUtilsMessengerEXT.Null;
    
    private readonly string[] ValidationLayers = new[]
    {
        "VK_LAYER_KHRONOS_validation"
    };
    
    private DisplayServer GetDisplayServer()
    {
        if (OperatingSystem.IsWindows())
            return DisplayServer.Windows;

        return DisplayServer.Wayland;
    }
    
    private string GetSurfaceExtension()
    {
        switch(GetDisplayServer())
        {
            case DisplayServer.Windows:
                return "VK_KHR_win32_surface";
            case DisplayServer.X11:
                return "VK_KHR_xlib_surface";
            case DisplayServer.Wayland:
                return "VK_KHR_wayland_surface";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private string[] Extensions => new[]
    {
        "VK_KHR_surface",
        GetSurfaceExtension(),
        "VK_EXT_debug_utils",
    };
        
    public Engine(Window aWindow)
    {
        vkInitialize();
        
        PrintAllAvailableExtensions();
        
        Init(aWindow);
    }

    public void Draw()
    {
        
    }
    
    [UnmanagedCallersOnly]
    private static uint DebugMessengerCallback(VkDebugUtilsMessageSeverityFlagsEXT messageSeverity,
        VkDebugUtilsMessageTypeFlagsEXT messageTypes,
        VkDebugUtilsMessengerCallbackDataEXT* pCallbackData,
        void* userData)
    {
        string message = new(pCallbackData->pMessage);
        if (messageTypes == VkDebugUtilsMessageTypeFlagsEXT.Validation)
        {
            if (messageSeverity == VkDebugUtilsMessageSeverityFlagsEXT.Error)
            {
                Console.WriteLine($"[Vulkan]: Validation: {messageSeverity} - {message}");
            }
            else if (messageSeverity == VkDebugUtilsMessageSeverityFlagsEXT.Warning)
            {
                Console.WriteLine($"[Vulkan]: Validation: {messageSeverity} - {message}");
            }

            Console.WriteLine($"[Vulkan]: Validation: {messageSeverity} - {message}");
        }
        else
        {
            if (messageSeverity == VkDebugUtilsMessageSeverityFlagsEXT.Error)
            {
                Console.WriteLine($"[Vulkan]: {messageSeverity} - {message}");
            }
            else if (messageSeverity == VkDebugUtilsMessageSeverityFlagsEXT.Warning)
            {
                Console.WriteLine($"[Vulkan]: {messageSeverity} - {message}");
            }

            Console.WriteLine($"[Vulkan]: {messageSeverity} - {message}");
        }

        return VK_FALSE;
    }
    
    private void PrintAllAvailableExtensions()
    {
        uint extensionCount = 0;
        Helpers.CheckErrors(vkEnumerateInstanceExtensionProperties(null, &extensionCount, null));
        VkExtensionProperties* extensions = stackalloc VkExtensionProperties[(int)extensionCount];
        Helpers.CheckErrors(vkEnumerateInstanceExtensionProperties(null, &extensionCount, extensions));

        for (int i = 0; i < extensionCount; i++)
        {
            Console.WriteLine($"Extension: {Helpers.GetString(extensions[i].extensionName)} version: {extensions[i].specVersion}");
        }
    }
}