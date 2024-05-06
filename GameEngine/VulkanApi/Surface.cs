﻿
namespace Graphics;

public unsafe class Surface
{
    private Window myWindow;
    public VkSurfaceKHR MyVkSurface;
    public VkSurfaceCapabilitiesKHR MySurfaceCapabilities;

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
    }
    
    public VkExtent2D GetSwapbufferExtent()
    {
        if (MySurfaceCapabilities.currentExtent.width != uint.MaxValue)
        {
            return MySurfaceCapabilities.currentExtent;
        }

        (int width, int height) size = myWindow.GetFramebufferSize();

        VkExtent2D extent;
        extent.width = ((uint)size.width);
        extent.height = (uint)size.height;

        extent.width = extent.width.Within(MySurfaceCapabilities.minImageExtent.width, MySurfaceCapabilities.maxImageExtent.width);
        extent.height = extent.height.Within(MySurfaceCapabilities.minImageExtent.height, MySurfaceCapabilities.maxImageExtent.height);

        return extent;
    }
    
    public void Destroy(Api aApi)
    {
        vkDestroySurfaceKHR(aApi.MyVkInstance, MyVkSurface);
    }
}