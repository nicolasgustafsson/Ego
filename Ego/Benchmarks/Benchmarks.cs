namespace Editor;

public class Benchmarks : Node
{
    public override void Start()
    {
        AddChild(new Camera()).LocalPosition += new Vector3(0f, 0f, -7.5f);
        AddChild(new BasicBench());
    }
}
