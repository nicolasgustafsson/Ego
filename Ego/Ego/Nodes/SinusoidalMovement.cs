using ImGuiNET;

namespace Ego;

public class SinusoidalMovement : Node3D
{
    private Delta3D Movement = new(1f, 0f, 0f);
    
    protected override void Update()
    {
        LocalPosition = (Position3D)(Movement * Math.Sin(Time.DeltaSeconds));
    }
    
    public override void Inspect()
    {
        base.Inspect();

        ImGui.SliderFloat3("Movement", ref Movement.Underlying, -10f, 10f);
    }
}