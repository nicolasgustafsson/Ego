using Vortice.Vulkan;

namespace Editor;
using Ego;

internal class Program
{
    static void Main(string[] args)
    {
        EgoContext engine = new();

        EngineInitSettings settings = new();
        settings.Name = "Benchmarks";
        settings.RendererInitSettings.PresentMode = VkPresentModeKHR.Immediate;
        
        engine.Run<Benchmarks>(settings);
    }
}
