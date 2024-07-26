using ImGuiNET;
using Rendering;

namespace Ego;

public class Debug : Node
{
    private readonly ImGuiDriver ImGuiDriver;

    public Action EDebug = () => {};
    
    public Debug()
    {
        ImGuiDriver = AddChild(new ImGuiDriver(Program.Context.Renderer, Program.Context.Window));

        Program.Context.EUpdate += Update;
    }
    
    private void Update()
    {
        ImGuiDriver.Begin();
        
        ImGui.DockSpaceOverViewport(0, null, ImGuiDockNodeFlags.PassthruCentralNode);

        ImGui.ShowDemoWindow();
        ImGui.ShowAboutWindow();

        EDebug();
        
        ImGuiDriver.End();
    }
}