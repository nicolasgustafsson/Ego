using System.Diagnostics;
using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;

namespace Rendering;

internal static unsafe class Helpers
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
        public Span<VkSurfaceFormatKHR> Formats;
        public Span<VkPresentModeKHR> PresentModes;
    }

    public static SwapChainSupportDetails QuerySwapChainSupport(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface)
    {
        SwapChainSupportDetails details = new SwapChainSupportDetails();
        VkApiInstance.vkGetPhysicalDeviceSurfaceCapabilitiesKHR(physicalDevice, surface, out details.Capabilities).CheckResult();
        
        VkApiInstance.vkGetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface, out uint surfaceFormatCount).CheckResult();
        details.Formats = new VkSurfaceFormatKHR[surfaceFormatCount];
        VkApiInstance.vkGetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface, details.Formats).CheckResult();
        
        VkApiInstance.vkGetPhysicalDeviceSurfacePresentModesKHR(physicalDevice, surface, out uint presentModeCount);
        details.PresentModes = new VkPresentModeKHR[presentModeCount];
            
        return details;
    }
}