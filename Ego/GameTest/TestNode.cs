using Ego;
using ImGuiNET;
using Serilog;

namespace GameTest;

public class TestNode : Node
{
    public override void Inspect()
    {
        base.Inspect();
        
        if (ImGui.Button("Do the thing"))
        {
            Log.Information("Herp");
        }
    }
}