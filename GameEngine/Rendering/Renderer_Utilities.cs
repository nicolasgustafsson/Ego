using System.Runtime.InteropServices;
using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;

namespace Rendering;

public unsafe partial class Renderer
{
    private DisplayServer GetDisplayServer()
    {
        if (OperatingSystem.IsWindows())
            return DisplayServer.Windows;

        return LinuxDisplayServer;
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
    
    [UnmanagedCallersOnly]
    private static uint DebugMessengerCallback(VkDebugUtilsMessageSeverityFlagsEXT messageSeverity,
        VkDebugUtilsMessageTypeFlagsEXT messageTypes,
        VkDebugUtilsMessengerCallbackDataEXT* pCallbackData,
        void* userData)
    {
        string message = new(pCallbackData->pMessage);
        
        Console.WriteLine($"[Vulkan]: {messageTypes}: {messageSeverity} - {message}");
        
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