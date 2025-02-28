namespace ExampleProject;

[Node]
public partial class WasdMovement : Node3D
{
    private bool MovingForwards = false;
    private bool MovingBack = false;
    private bool MovingLeft = false;
    private bool MovingRight = false;

    [Inspect] private float Speed = 1f;

    public override void Start()
    {
        base.Start();
        
        Window.EKeyboardKey += EKeyboardKey;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        
        Window.EKeyboardKey -= EKeyboardKey;
    }

    protected override void Update()
    {
        base.Update();
        
        if (MovingForwards)
            LocalPosition += Vector3.Transform(new Vector3(0f, 0f, -1f) * Speed, WorldRotation) * (float)Time.DeltaSeconds;
        
        if (MovingBack)
            LocalPosition += Vector3.Transform(new Vector3(0f, 0f, 1f) * Speed, WorldRotation) * (float)Time.DeltaSeconds;
        
        if (MovingLeft)
            LocalPosition += Vector3.Transform(new Vector3(-1f, 0f, 0f) * Speed, WorldRotation) * (float)Time.DeltaSeconds;
        
        if (MovingRight)
            LocalPosition += Vector3.Transform(new Vector3(1f, 0f, 0f) * Speed, WorldRotation) * (float)Time.DeltaSeconds;
    }

    private void EKeyboardKey(Window aWindow, KeyboardKey aKey, InputState aInputState)
    {
        if (Window != aWindow)
            return;

        bool isActive = aInputState != InputState.Release;
        
        switch (aKey)
        {
            case KeyboardKey.W:
                MovingForwards = isActive;
                break;
            case KeyboardKey.R:
                MovingBack = isActive;
                break;
            case KeyboardKey.A:
                MovingLeft = isActive;
                break;
            case KeyboardKey.S:
                MovingRight = isActive;
                break;
            default:
                break;
        }
    }
}