using Rendering;

namespace Ego;

[Node(AllowAddingToScene = false)]
public partial class Debug : Node
{
    private ImGuiDriver? ImGuiDriver = null!;

    public Action EDebug = () => {};
    
    public override void Start()
    {
        base.Start();

        ImGuiDriver = new ImGuiDriver(RendererApi.Renderer, Window);
    }

    protected override unsafe void Update()
    {
        if (ImGuiDriver == null)
            return;
        
        ImGuiDriver.Begin();
       
        Imgui.DockSpaceOverViewport(aFlags: ImGuiDockNodeFlags.PassthruCentralNode);

        Imgui.ShowDemoWindow();
        Imgui.ShowAboutWindow();

        EDebug();
        
        ImGuiDriver.End();
    }

    public override char GetIcon()
    {
        return (char)61832;
    }
}