using ImGuiNET;
using Rendering;

namespace Ego;

[Node(DisableEditorAdd = true)]
public partial class Debug : Node
{
    private ImGuiDriver? ImGuiDriver = null!;

    public Action EDebug = () => {};
    
    public override void Start()
    {
        base.Start();

        ImGuiDriver = new ImGuiDriver(RendererApi.Renderer, Window);
    }

    protected override void Update()
    {
        if (ImGuiDriver == null)
            return;
        
        ImGuiDriver.Begin();
       
        ImGui.DockSpaceOverViewport(0, null, ImGuiDockNodeFlags.PassthruCentralNode);

        ImGui.ShowDemoWindow();
        ImGui.ShowAboutWindow();

        EDebug();
        
        ImGuiDriver.End();
    }

    public override char GetIcon()
    {
        return (char)61832;
    }
}