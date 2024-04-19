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

public unsafe partial class Renderer
{
    private Window myWindow;
    
    private VkInstance myVulkanInstance;
    private VkSurfaceKHR mySurface;
    private VkPhysicalDevice myPhysicalDevice; 
    private VkDevice myDevice;
    private VkQueue myDrawQueue;
    private uint myGraphicsFamily;
    private VkSurfaceCapabilitiesKHR mySurfaceCapabilities;

    private VkDebugUtilsMessengerEXT myDebugMessenger = VkDebugUtilsMessengerEXT.Null;

    public Renderer(Window aWindow)
    {
        vkInitialize();
        
        PrintAllAvailableExtensions();
        
        Init(aWindow);
    }

    public void Draw()
    {
        
    }
}