global using static VulkanApi.Surface;
namespace VulkanApi;

public unsafe class Surface : IGpuDestroyable
{
    private Window Window;
    public VkSurfaceKHR VkSurface;
    public VkSurfaceCapabilitiesKHR SurfaceCapabilities;
    public static Surface MainWindowSurface = null!;

    internal Surface(Api aApi, Window aWindow)
    {
        Window = aWindow;
        
        switch (Helpers.GetDisplayServer())
        {
            case DisplayServer.Windows:
            {
                VkWin32SurfaceCreateInfoKHR createInfo = new VkWin32SurfaceCreateInfoKHR()
                {
                    hwnd = aWindow.Hwnd,
                    hinstance = System.Diagnostics.Process.GetCurrentProcess().Handle,
                    
                };
                fixed (VkSurfaceKHR* surfacePtr = &VkSurface)
                {
                    vkCreateWin32SurfaceKHR(aApi.VkInstance, &createInfo, null, surfacePtr).CheckResult();
                }
                break;
            }
            case DisplayServer.X11:
            {
                VkXlibSurfaceCreateInfoKHR createInfo = new ()
                {
                    dpy = aWindow.X11Display,
                    window = (UIntPtr)aWindow.X11Window
                };
                fixed (VkSurfaceKHR* surfacePtr = &VkSurface)
                {
                    vkCreateXlibSurfaceKHR(aApi.VkInstance, &createInfo, null, surfacePtr).CheckResult();
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
                fixed (VkSurfaceKHR* surfacePtr = &VkSurface)
                {
                    vkCreateWaylandSurfaceKHR(aApi.VkInstance, &createInfo, null, surfacePtr).CheckResult();
                }
                break;
            }
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public VkExtent2D GetSwapbufferExtent()
    {
        Helpers.SwapChainSupportDetails swapChainSupport = Helpers.QuerySwapChainSupport(GpuInstance.VkPhysicalDevice, VkSurface);

        SurfaceCapabilities = swapChainSupport.Capabilities;
        
        (int width, int height) size = Window.GetFramebufferSize();

        VkExtent2D extent;
        extent.width = (uint)size.width;
        extent.height = (uint)size.height;

        extent.width = extent.width.Within(SurfaceCapabilities.minImageExtent.width.AtLeast(1u), SurfaceCapabilities.maxImageExtent.width);
        extent.height = extent.height.Within(SurfaceCapabilities.minImageExtent.height.AtLeast(1u), SurfaceCapabilities.maxImageExtent.height);

        return extent;
    }
    
    public void Destroy()
    {
        vkDestroySurfaceKHR(ApiInstance.VkInstance, VkSurface);
    }
}