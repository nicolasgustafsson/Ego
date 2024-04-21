namespace Graphics;

public static class ExtensionNames
{
    public static class Instance
    {
        public static string Surface = "VK_KHR_surface";
        public static string DebugUtils = "VK_EXT_debug_utils";

        public static string Win32Surface = "VK_KHR_win32_surface";
        public static string X11Surface = "VK_KHR_xlib_surface";
        public static string WaylandSurface = "VK_KHR_wayland_surface";
    }
    
    public static class Device
    {
        public static string Swapchain = "VK_KHR_swapchain";
        public static string Synchronization2 = "VK_KHR_synchronization2";
    }
}

public static partial class Defaults
{
    public static List<string> InstanceExtensions = 
    [
        ExtensionNames.Instance.Surface, 
        ExtensionNames.Instance.DebugUtils, 
        Helpers.GetPlatformSurfaceExtension()
    ];

    public static List<string> DeviceExtensions =
    [
        ExtensionNames.Device.Swapchain,
        ExtensionNames.Device.Synchronization2,
    ];
}