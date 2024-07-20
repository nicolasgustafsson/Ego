using Ego.Systems;

namespace Ego;

public class SinusoidalMovement : Node3D
{
    public Vector3 Movement = new Vector3(1f, 0f, 0f);
    
    public SinusoidalMovement()
    {
        Program.Context.EUpdate += Update;
    }
    
    public void Update()
    {
        LocalPosition = Movement * (float)Math.Sin(Program.Context.Time.ElapsedSeconds);
    }
}