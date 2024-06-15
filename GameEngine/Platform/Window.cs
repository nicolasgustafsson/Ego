using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using GLFW;

public class Window
{
    private static readonly ErrorCallback errorCallback = GlfwError;
    private static readonly MouseCallback mouseScrollCallback = MouseCallback;
    private static readonly MouseButtonCallback mouseButtonCallback = MouseCallback;
    private static readonly KeyCallback keyCallback = KeyCallback;
    
    private readonly NativeWindow myNativeWindow;
    public bool WantsToClose = false;
    private bool myAllowClosing = false;

    public static Action<Vector2>? EMouseScrolled;
    public static Action<MouseButton, InputState>? EMouseButton;
    public static Action<KeyboardKey, InputState>? EKeyboardKey;

    public bool IsClosing => myNativeWindow.IsClosing;
    public bool IsClosed => myNativeWindow.IsClosed;
    public IntPtr Hwnd => myNativeWindow.Hwnd;
    public string Name => myNativeWindow.Title!;
    
    public IntPtr X11Display => GLFW.Native.GetX11Display();
    public IntPtr X11Window => GLFW.Native.GetX11Window(myNativeWindow);

    public IntPtr WaylandDisplay => GLFW.Native.GetWaylandDisplay();
    public IntPtr WaylandWindow => GLFW.Native.GetWaylandWindow(myNativeWindow);

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
        Glfw.SetKeyCallback(myNativeWindow, keyCallback);
    }

    private static void KeyCallback(IntPtr aWindow, GLFW.Keys aKey, int aScancode, GLFW.InputState aState, ModifierKeys aMods)
    {
        EKeyboardKey?.Invoke((KeyboardKey)aKey, (InputState)aState);
    }

    private static void MouseCallback(IntPtr aWindow, GLFW.MouseButton aButton, GLFW.InputState aState, ModifierKeys aModifiers)
    {
        EMouseButton?.Invoke((MouseButton)aButton, (InputState)aState);
    }

    private static void MouseCallback(IntPtr aWindow, double aX, double aY)
    {
        EMouseScrolled?.Invoke(new((float)aX, (float)aY));
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

    public void Close()
    {
        myAllowClosing = true;

        //myNativeWindow.SwapBuffers();
        //Glfw.PollEvents();
        //myNativeWindow.Close();
    }
}