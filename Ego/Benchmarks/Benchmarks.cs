namespace Editor;

public class Benchmarks : Node
{
    public override void Start()
    {
        AddChild(new SinusoidalMovement()).AddChild(new Node3D()).AddChild(new MeshRenderer());
        AddChild(new SinusoidalMovement()).AddChild(new Node3D()).AddChild(new MeshRenderer()).LocalPosition += new Vector3(2f, 2f, 0f);
        AddChild(new Camera()).LocalPosition += new Vector3(0f, 0f, -7.5f);
    }
}
