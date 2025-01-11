using ImGuiNET;

namespace Ego;

public class SinusoidalMovement : Node3D
{
    private Vector3 Movement = new(1f, 0f, 0f);
    
    protected override void Update()
    {
        LocalPosition = Movement * (float)Math.Sin(Time.ElapsedTime.TotalSeconds);
    }
}