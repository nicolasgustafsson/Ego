using ImGuiNET;
using Rendering;

namespace Ego;

public class Debug : Node
{
    private ImGuiDriver ImGuiDriver = null!;

    public Action EDebug = () => {};
    
    public override void Start()
    {
        base.Start();
        
        ImGuiDriver = AddChild(new ImGuiDriver(Context.Get<RendererApi>()!.Get<Renderer>()!, Context.Get<Window>()!));
    }

    protected override void Update()
    {
        lock(ImGuiDriver)
        {
            ImGuiDriver.Begin();
           
            ImGui.DockSpaceOverViewport(0, null, ImGuiDockNodeFlags.PassthruCentralNode);

            ImGui.ShowDemoWindow();
            ImGui.ShowAboutWindow();

            EDebug();
            
            ImGuiDriver.End();
        }
    }

    public override char GetIcon()
    {
        return (char)61832;
    }
}