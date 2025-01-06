namespace Ego;

public class BasicBench : Node
{
    public override void Start()
    {
        base.Start();
        
        for(int i = 0; i < 10000; i++)
        {
            AddChild(new SinusoidalMovement()).AddChild(new Node3D()).AddChild(new MeshRenderer());
        }
    }
}