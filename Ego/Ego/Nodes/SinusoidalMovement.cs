using ImGuiNET;

namespace Ego;

[Node]
public partial class SinusoidalMovement : Node3D
{
    [Inspect] private Vector3 Movement = new(1f, 0f, 0f);
    
    protected override void Update()
    {
        LocalPosition = Movement * (float)Math.Sin(Time.ElapsedTime.TotalSeconds);
    }
}