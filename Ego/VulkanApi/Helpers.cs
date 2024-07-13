using System.Diagnostics;
using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;

namespace VulkanApi;

public static unsafe class Helpers
{
    public static byte* ToPointer(this string text)
    {
        return (byte*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(text);
    }
    
    public static sbyte* ToSPointer(this string text)
    {
        return (sbyte*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(text);
    }

    public static uint Version(uint major, uint minor, uint patch)
    {
        return (major << 22) | (minor << 12) | patch;
    }

    public static string GetString(sbyte* stringStart)
    {
        int characters = 0;
        while (stringStart[characters] != 0)
        {
            characters++;
        }

        return System.Text.Encoding.UTF8.GetString((byte*)stringStart, characters);
    }
    
    public ref struct SwapChainSupportDetails
    {
        public VkSurfaceCapabilitiesKHR Capabilities;
        public ReadOnlySpan<VkSurfaceFormatKHR> Formats;
        public ReadOnlySpan<VkPresentModeKHR> PresentModes;
    }

    public static SwapChainSupportDetails QuerySwapChainSupport(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface)
    {
        SwapChainSupportDetails details = new SwapChainSupportDetails();
        vkGetPhysicalDeviceSurfaceCapabilitiesKHR(physicalDevice, surface, out details.Capabilities).CheckResult();

        details.Formats = vkGetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface);
        details.PresentModes = vkGetPhysicalDeviceSurfacePresentModesKHR(physicalDevice, surface);
        return details;
    }
    
    private static DisplayServer LinuxDisplayServer = DisplayServer.X11;
    public static DisplayServer GetDisplayServer()
    {
        if (OperatingSystem.IsWindows())
            return DisplayServer.Windows;

        return LinuxDisplayServer;
    }
    public static string GetPlatformSurfaceExtension()
    {
        switch(GetDisplayServer())
        {
            case DisplayServer.Windows:
                return ExtensionNames.Instance.Win32Surface;
            case DisplayServer.X11:
                return ExtensionNames.Instance.X11Surface;
            case DisplayServer.Wayland:
                return ExtensionNames.Instance.WaylandSurface;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}