namespace Editor;
using Ego;
using Vortice.Vulkan;

internal class Program
{
    static void Main(string[] args)
    {
        EgoContext engine = new();
        
        EngineInitSettings settings = new();
        settings.Name = "Editor";
        settings.RendererInitSettings.PresentMode = VkPresentModeKHR.Mailbox;
        
        engine.Run<Editor>(settings, editor =>
        {
            if (args.Length > 0)
                ProjectEditor.Instance.SelectProject(args[0]);
        });
    }
}