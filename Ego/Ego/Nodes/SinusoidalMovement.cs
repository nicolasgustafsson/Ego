using ImGuiNET;

namespace Ego;

public class SinusoidalMovement : Node3D
{
    public Vector3 Movement = new Vector3(1f, 0f, 0f);
    
    public override void Start()
    {
        base.Start();
        Context.EUpdate += Update;
    }
    
    private void Update()
    {
        LocalPosition = Movement * (float)Math.Sin(Context.Get<TimeKeeper>()!.ElapsedSeconds);
    }
    
    public override void Inspect()
    {
        base.Inspect();

        ImGui.SliderFloat3("Movement", ref Movement, -10f, 10f);
    }
}