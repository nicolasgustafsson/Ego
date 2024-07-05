using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using GLFW;

public class Window
{
    private static readonly ErrorCallback errorCallback = GlfwError;
    private static readonly MouseCallback mouseScrollCallback = MouseScrollCallback;
    private static readonly MouseButtonCallback mouseButtonCallback = MouseButtonCallback;
    private static readonly KeyCallback keyCallback = KeyCallback;
    private static readonly CharCallback charCallback = CharCallback;
    private static readonly MouseCallback mousePosCallback = MousePositionCallback;

    private readonly NativeWindow myNativeWindow;
    public bool WantsToClose = false;
    private bool myAllowClosing = false;

    public static Action<Vector2>? EMouseScrolled;
    public static Action<Vector2>? EMousePosition;
    public static Action<MouseButton, InputState>? EMouseButton;
    public static Action<KeyboardKey, InputState>? EKeyboardKey;
    public static Action<uint>? ECharInput;

    public bool IsClosing => myNativeWindow.IsClosing;
    public bool IsClosed => myNativeWindow.IsClosed;
    public IntPtr Hwnd => myNativeWindow.Hwnd;
    public string Name => myNativeWindow.Title!;
    
    public IntPtr X11Display => GLFW.Native.GetX11Display();
    public IntPtr X11Window => GLFW.Native.GetX11Window(myNativeWindow);

    public IntPtr WaylandDisplay => GLFW.Native.GetWaylandDisplay();
    public IntPtr WaylandWindow => GLFW.Native.GetWaylandWindow(myNativeWindow);
    public bool Minimized => myNativeWindow.Minimized;
    public bool IsFocused => myNativeWindow.IsFocused;

    public Window(string aName, System.Numerics.Vector2 aWindowSize)
    {
        Glfw.WindowHint(Hint.ClientApi, ClientApi.None);
        Glfw.SetErrorCallback(errorCallback);
        myNativeWindow = new((int)aWindowSize.X, (int)aWindowSize.Y, aName);

        myNativeWindow.Closing += (sender, args) =>
        {
            if (!myAllowClosing)
            {
                args.Cancel = true;
                WantsToClose = true;
            }
            else
            {
                args.Cancel = false;
            }
        };
        
        Glfw.SetScrollCallback(myNativeWindow, mouseScrollCallback);
        Glfw.SetMouseButtonCallback(myNativeWindow, mouseButtonCallback);
        Glfw.SetCursorPositionCallback(myNativeWindow, mousePosCallback);
        Glfw.SetKeyCallback(myNativeWindow, keyCallback);
        Glfw.SetCharCallback(myNativeWindow, charCallback);
    }

    private static void KeyCallback(IntPtr aWindow, GLFW.Keys aKey, int aScancode, GLFW.InputState aState, ModifierKeys aMods)
    {
        EKeyboardKey?.Invoke((KeyboardKey)aKey, (InputState)aState);
    }

    private static void MouseButtonCallback(IntPtr aWindow, GLFW.MouseButton aButton, GLFW.InputState aState, ModifierKeys aModifiers)
    {
        EMouseButton?.Invoke((MouseButton)aButton, (InputState)aState);
    }

    private static void MouseScrollCallback(IntPtr aWindow, double aX, double aY)
    {
        EMouseScrolled?.Invoke(new((float)aX, (float)aY));
    }

    private static void MousePositionCallback(IntPtr window, double x, double y)
    {
        EMousePosition?.Invoke(new((float)x, (float)y));
    }
    
    private static void CharCallback(IntPtr aWindow, uint aCodePoint)
    {
        ECharInput?.Invoke(aCodePoint);
    }

    public void Update()
    {
        Glfw.PollEvents();
    }
    
    public Vector2 GetCursorPosition()
    {
        Glfw.GetCursorPosition(myNativeWindow, out double x, out double y);

        return new((float)x, (float)y);
    }
    
    public bool IsMouseButtonDown(MouseButton aMouseButton)
    {
        return Glfw.GetMouseButton(myNativeWindow, (GLFW.MouseButton)aMouseButton) == GLFW.InputState.Press;
    }
    
    
    public bool IsKeyboardKeyDown(KeyboardKey aKey)
    {
        return Glfw.GetKey(myNativeWindow, (GLFW.Keys)aKey) == GLFW.InputState.Press;
    }
    private static void GlfwError(ErrorCode code, IntPtr message)
    {
        Console.WriteLine(PtrToStringUTF8(message));
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
        Glfw.GetFramebufferSize(myNativeWindow, out int width, out int height);

        return (width, height);
    }
    
    public (int width, int height) GetWindowSize()
    {
        Glfw.GetWindowSize(myNativeWindow, out int width, out int height);

        return (width, height);
    }
    
    public void SetWindowPosition(int x, int y)
    {
        Glfw.SetWindowPosition(myNativeWindow, x, y);
    }
    
    public void SetWindowSize(int width, int height)
    {
        Glfw.SetWindowSize(myNativeWindow, width, height);
    }
    
    public (int x, int y) GetWindowPosition()
    {
        Glfw.GetWindowPosition(myNativeWindow, out int x, out int y);
        return (x, y);
    }

    public void Close()
    {
        myAllowClosing = true;

        //myNativeWindow.SwapBuffers();
        //Glfw.PollEvents();
        //myNativeWindow.Close();
    }
    
    
    public void SetCursor(Cursor aCursor)
    {
        Glfw.SetCursor(myNativeWindow, aCursor);
    }

    public void Show()
    {
        Glfw.ShowWindow(myNativeWindow);
    }

    public void FocusWindow()
    {
        Glfw.FocusWindow(myNativeWindow);
    }

    public void SetTitle(string aTitle)
    {
        myNativeWindow.Title = aTitle;
    }
}