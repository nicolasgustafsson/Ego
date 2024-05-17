global using static Graphics.Surface;
namespace Graphics;

public unsafe class Surface : IGpuDestroyable
{
    private Window myWindow;
    public VkSurfaceKHR MyVkSurface;
    public VkSurfaceCapabilitiesKHR MySurfaceCapabilities;
    public static Surface WindowSurface = null!;

    internal Surface(Api aApi, Window aWindow)
    {
        myWindow = aWindow;
        
        switch (Helpers.GetDisplayServer())
        {
            case DisplayServer.Windows:
            {
                VkWin32SurfaceCreateInfoKHR createInfo = new VkWin32SurfaceCreateInfoKHR()
                {
                    hwnd = aWindow.Hwnd,
                    hinstance = System.Diagnostics.Process.GetCurrentProcess().Handle,
                    
                };
                fixed (VkSurfaceKHR* surfacePtr = &MyVkSurface)
                {
                    vkCreateWin32SurfaceKHR(aApi.MyVkInstance, &createInfo, null, surfacePtr).CheckResult();
                }
                break;
            }
            case DisplayServer.X11:
            {
                VkXlibSurfaceCreateInfoKHR createInfo = new ()
                {
                    display = aWindow.X11Display,
                    window = (UIntPtr)aWindow.X11Window
                };
                fixed (VkSurfaceKHR* surfacePtr = &MyVkSurface)
                {
                    vkCreateXlibSurfaceKHR(aApi.MyVkInstance, &createInfo, null, surfacePtr).CheckResult();
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
                fixed (VkSurfaceKHR* surfacePtr = &MyVkSurface)
                {
                    vkCreateWaylandSurfaceKHR(aApi.MyVkInstance, &createInfo, null, surfacePtr).CheckResult();
                }
                break;
            }
            default:
                throw new ArgumentOutOfRangeException();
        }

        WindowSurface = this;
    }
    
    public VkExtent2D GetSwapbufferExtent()
    {
        Helpers.SwapChainSupportDetails swapChainSupport = Helpers.QuerySwapChainSupport(GpuInstance.MyVkPhysicalDevice, MyVkSurface);

        MySurfaceCapabilities = swapChainSupport.Capabilities;
        
        (int width, int height) size = myWindow.GetFramebufferSize();

        VkExtent2D extent;
        extent.width = (uint)size.width;
        extent.height = (uint)size.height;

        extent.width = extent.width.Within(MySurfaceCapabilities.minImageExtent.width, MySurfaceCapabilities.maxImageExtent.width);
        extent.height = extent.height.Within(MySurfaceCapabilities.minImageExtent.height, MySurfaceCapabilities.maxImageExtent.height);

        return extent;
    }
    
    public void Destroy()
    {
        vkDestroySurfaceKHR(VulkanApi.MyVkInstance, MyVkSurface);
    }
}