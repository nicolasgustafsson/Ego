using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using GLFW;

public class Window : BaseNode
{
    private static readonly ErrorCallback errorCallback = GlfwError;
    private static readonly MouseCallback mouseScrollCallback = MouseScrollCallback;
    private static readonly MouseButtonCallback mouseButtonCallback = MouseButtonCallback;
    private static readonly KeyCallback keyCallback = KeyCallback;
    private static readonly CharCallback charCallback = CharCallback;
    private static readonly MouseCallback mousePosCallback = MousePositionCallback;

    private readonly NativeWindow NativeWindow;

    public Action<Window, Vector2>? EMouseScrolled;
    public Action<Window, Vector2>? EMousePosition;
    public Action<Window, MouseButton, InputState>? EMouseButton;
    public Action<Window, KeyboardKey, InputState>? EKeyboardKey;
    public Action<Window, uint>? ECharInput;

    private static Dictionary<IntPtr, Window> Windows = new();

    public bool IsClosing => NativeWindow.IsClosing;
    public bool IsClosed => NativeWindow.IsClosed;
    public IntPtr Hwnd => NativeWindow.Hwnd;
    public string Name => NativeWindow.Title!;
    
    public IntPtr X11Display => GLFW.Native.GetX11Display();
    public IntPtr X11Window => GLFW.Native.GetX11Window(NativeWindow);

    public IntPtr WaylandDisplay => GLFW.Native.GetWaylandDisplay();
    public IntPtr WaylandWindow => GLFW.Native.GetWaylandWindow(NativeWindow);
    public bool IsMinimized => NativeWindow.Minimized;
    public bool IsFocused => NativeWindow.IsFocused;

    public Window(string aName, System.Numerics.Vector2 aWindowSize)
    {
        Glfw.WindowHint(Hint.ClientApi, ClientApi.None);
        Glfw.SetErrorCallback(errorCallback);
        NativeWindow = new((int)aWindowSize.X, (int)aWindowSize.Y, aName);
        
        Glfw.SetScrollCallback(NativeWindow, mouseScrollCallback);
        Glfw.SetMouseButtonCallback(NativeWindow, mouseButtonCallback);
        Glfw.SetCursorPositionCallback(NativeWindow, mousePosCallback);
        Glfw.SetKeyCallback(NativeWindow, keyCallback);
        Glfw.SetCharCallback(NativeWindow, charCallback);

        Windows.Add(NativeWindow.Handle, this);
        
    }

    private static void KeyCallback(IntPtr aWindow, GLFW.Keys aKey, int aScancode, GLFW.InputState aState, ModifierKeys aMods)
    {
        var window = Windows[aWindow];
        window.EKeyboardKey?.Invoke(window, (KeyboardKey)aKey, (InputState)aState);
    }

    private static void MouseButtonCallback(IntPtr aWindow, GLFW.MouseButton aButton, GLFW.InputState aState, ModifierKeys aModifiers)
    {
        var window = Windows[aWindow];
        Windows[aWindow].EMouseButton?.Invoke(window, (MouseButton)aButton, (InputState)aState);
    }

    private static void MouseScrollCallback(IntPtr aWindow, double aX, double aY)
    {
        var window = Windows[aWindow];
        Windows[aWindow].EMouseScrolled?.Invoke(window, new((float)aX, (float)aY));
    }

    private static void MousePositionCallback(IntPtr aWindow, double x, double y)
    {
        var window = Windows[aWindow];
        Windows[aWindow].EMousePosition?.Invoke(window, new((float)x, (float)y));
    }
    
    private static void CharCallback(IntPtr aWindow, uint aCodePoint)
    {
        var window = Windows[aWindow];
        Windows[aWindow].ECharInput?.Invoke(window, aCodePoint);
    }

    public void PollEvents()
    {
        lock(this)
        {
            Glfw.PollEvents();
        }
    }
    
    public Vector2 GetCursorPosition()
    {
        Glfw.GetCursorPosition(NativeWindow, out double x, out double y);

        return new((float)x, (float)y);
    }
    
    public bool IsMouseButtonDown(MouseButton aMouseButton)
    {
        return Glfw.GetMouseButton(NativeWindow, (GLFW.MouseButton)aMouseButton) == GLFW.InputState.Press;
    }
    
    public bool IsKeyboardKeyDown(KeyboardKey aKey)
    {
        return Glfw.GetKey(NativeWindow, (GLFW.Keys)aKey) == GLFW.InputState.Press;
    }
    private static void GlfwError(ErrorCode code, IntPtr message)
    {
        Log.Information(PtrToStringUTF8(message));
    }
    
    public static string PtrToStringUTF8(IntPtr ptr)
    {
      int length = 0;
      while (Marshal.ReadByte(ptr, length) != (byte) 0)
        ++length;
      byte[] numArray = new byte[length];
      Marshal.Copy(ptr, numArray, 0, length);
      return Encoding.UTF8.GetString(numArray);
    }
    
    public (int width, int height) GetFramebufferSize()
    {
        Glfw.GetFramebufferSize(NativeWindow, out int width, out int height);

        return (width, height);
    }
    
    public (int width, int height) GetWindowSize()
    {
        Glfw.GetWindowSize(NativeWindow, out int width, out int height);

        return (width, height);
    }
    
    public void SetWindowPosition(int x, int y)
    {
        Glfw.SetWindowPosition(NativeWindow, x, y);
    }
    
    public void SetWindowSize(int width, int height)
    {
        Glfw.SetWindowSize(NativeWindow, width, height);
    }
    
    public (int x, int y) GetWindowPosition()
    {
        Glfw.GetWindowPosition(NativeWindow, out int x, out int y);
        return (x, y);
    }

    public override void OnDestroy()
    {
        NativeWindow.Close();
        Windows.Remove(NativeWindow.Handle);
    }
    
    public void SetCursor(Cursor aCursor)
    {
        Glfw.SetCursor(NativeWindow, aCursor);
    }

    public void Show()
    {
        Glfw.ShowWindow(NativeWindow);
    }

    public void FocusWindow()
    {
        Glfw.FocusWindow(NativeWindow);
    }

    public void SetTitle(string aTitle)
    {
        NativeWindow.Title = aTitle;
    }
}