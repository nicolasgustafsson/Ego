namespace Ego;

public class SinusoidalMovement : Node3D
{
    public Vector3 Movement = new Vector3(1f, 0f, 0f);
    
    public override void Update()
    {
        LocalPosition = Movement * (float)Math.Sin(DateTime.Now.TimeOfDay.TotalSeconds);
        base.Update();
    }
}