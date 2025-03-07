namespace Editor;

[Node]
public partial class EditorCameraMovement : Node3D
{
    private bool MovingForwards = false;
    private bool MovingBack = false;
    private bool MovingLeft = false;
    private bool MovingRight = false;

    private bool Sprinting = false;

    private bool MovingCamera = false;
    private float YawRotation = 0f;

    private float PitchRotation = 0f;

    [Inspect] private float Speed = 7f;
    [Inspect] private float SprintMultiplier = 2f;
    [Inspect] private float MouseSensitivity = 4f;
    
    private Vector2 CursorPositionBeforeCameraMoveInitiated = Vector2.Zero;

    public override void Start()
    {
        base.Start();
        
        Window.EKeyboardKey += EKeyboardKey;
        Window.EMouseButton += EMouseButton;
        Window.EMousePosition += EMousePosition;
    }

    private void EMouseButton(Window arg1, MouseButton arg2, InputState arg3)
    {
        if (arg2 == MouseButton.Right)
            ToggleMoveCamera(arg3 != InputState.Release);
    }
    
    private void ToggleMoveCamera(bool aIsMoving)
    {
        if (MovingCamera == aIsMoving)
            return;
        
        MovingCamera = aIsMoving;
        
        if (MovingCamera)
        {
            Window.HideCursor();
            CursorPositionBeforeCameraMoveInitiated = Window.GetCursorPosition();
            Window.CenterCursor();
        }
        else
        {
            Window.ShowCursor();
            Window.SetCursorPosition(CursorPositionBeforeCameraMoveInitiated);
        }
    }

    private void EMousePosition(Window aWindow, Vector2 aNewMousePosition)
    {
        if (!MovingCamera)
            return;

        Vector2 delta = aNewMousePosition - (Window.GetCenter());

        if (delta == Vector2.Zero) 
            return;
        
        YawRotation += -delta.X * MouseSensitivity * 0.001f;
        PitchRotation += -delta.Y * MouseSensitivity * 0.001f;
        LocalRotation = Quaternion.CreateFromYawPitchRoll(YawRotation, PitchRotation, 0f);

        Window.CenterCursor();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        
        Window.EKeyboardKey -= EKeyboardKey;
    }

    protected override void Update()
    {
        base.Update();

        if (!MovingCamera)
            return;

        Vector3 direction = Vector3.Zero;

        if (MovingForwards)
            direction += new Vector3(0f, 0f, -1f); 
        
        if (MovingBack)
            direction += new Vector3(0f, 0f, 1f); 
        
        if (MovingLeft)
            direction += new Vector3(-1f, 0f, 0f); 
        
        if (MovingRight)
            direction += new Vector3(1f, 0f, 0f);

        Vector3 totalMovement = direction * Speed * (float)Time.DeltaSeconds * (Sprinting ? SprintMultiplier : 1f);
        
        LocalPosition += Vector3.Transform(totalMovement, WorldRotation);
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
            case KeyboardKey.LeftShift:
                Sprinting = isActive;
                break;
            default:
                break;
        }
    }
}