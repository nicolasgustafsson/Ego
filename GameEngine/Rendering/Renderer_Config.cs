namespace Rendering;

public partial class Renderer
{
    private readonly string[] ValidationLayers = new[]
    {
        "VK_LAYER_KHRONOS_validation"
    };
    
    private string[] Extensions => new[]
    {
        "VK_KHR_surface",
        GetSurfaceExtension(),
        "VK_EXT_debug_utils",
    };

    private DisplayServer LinuxDisplayServer = DisplayServer.X11;
}