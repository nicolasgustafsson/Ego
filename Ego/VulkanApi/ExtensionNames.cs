namespace VulkanApi;

public static class ExtensionNames
{
    public static class Instance
    {
        public static readonly string Surface = "VK_KHR_surface";
        public static readonly string DebugUtils = "VK_EXT_debug_utils";

        public static readonly string Win32Surface = "VK_KHR_win32_surface";
        public static readonly string X11Surface = "VK_KHR_xlib_surface";
        public static readonly string WaylandSurface = "VK_KHR_wayland_surface";
    }
    
    public static class Device
    {
        public static readonly string Swapchain = "VK_KHR_swapchain";
        public static readonly string Synchronization2 = "VK_KHR_synchronization2";
        public static readonly string ShaderObjects = "VK_EXT_shader_object";
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
        ExtensionNames.Device.ShaderObjects,
    ];
}