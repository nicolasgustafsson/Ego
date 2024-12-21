using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
//using GLFW;
using Hexa.NET.GLFW;
using Hexa.NET.ImGui;
using Hexa.NET.ImGui.Backends.GLFW;
using GLFWwindow = Hexa.NET.GLFW.GLFWwindow;
using GLFWwindowPtr = Hexa.NET.GLFW.GLFWwindowPtr;

public unsafe class Window : Node
{
    private static readonly GLFWerrorfun errorCallback = GlfwError;
    private static readonly GLFWscrollfun mouseScrollCallback = MouseScrollCallback;
    private static readonly GLFWmousebuttonfun mouseButtonCallback = MouseButtonCallback;
    private static readonly GLFWkeyfun keyCallback = KeyCallback;
    private static readonly GLFWcharfun charCallback = CharCallback;
    private static readonly GLFWcursorposfun mousePosCallback = MousePositionCallback;

    public readonly GLFWwindowPtr NativeWindow;

    public Action<Window, Vector2>? EMouseScrolled;
    public Action<Window, Vector2>? EMousePosition;
    public Action<Window, MouseButton, InputState>? EMouseButton;
    public Action<Window, KeyboardKey, InputState>? EKeyboardKey;
    public Action<Window, uint>? ECharInput;

    private static Dictionary<IntPtr, Window> Windows = new();

    public bool IsClosing => GLFW.WindowShouldClose(NativeWindow) == 1;
    public bool IsClosed => GLFW.WindowShouldClose(NativeWindow) == 1; //NativeWindow.IsClosed;
    public IntPtr Hwnd => GLFW.GetWin32Window(NativeWindow);//NativeWindow.Hwnd;
    public string Name => GLFW.GetWindowTitleS(NativeWindow);//NativeWindow.Title!;

    public IntPtr X11Display => (IntPtr)GLFW.GetX11Display();//GLFW.Native.GetX11Display();
    public Hexa.NET.GLFW.X11Window X11Window => GLFW.GetX11Window(NativeWindow);//GLFW.Native.GetX11Window(NativeWindow);

    public WlDisplayPtr WaylandDisplay => GLFW.GetWaylandDisplay();//GLFW.Native.GetWaylandDisplay();
    public WlSurfacePtr WaylandWindow => GLFW.GetWaylandWindow(NativeWindow);//GLFW.Native.GetWaylandWindow(NativeWindow);
    public bool IsMinimized => GetWindowSize().width == 0;//NativeWindow.Minimized;
    public bool IsFocused => GLFW.GetWindowAttrib(NativeWindow, GLFW.GLFW_FOCUSED) == 1;//NativeWindow.IsFocused;

    public Window(string aName, System.Numerics.Vector2 aWindowSize)
    {
        GLFW.Init();
        GLFW.WindowHint(GLFW.GLFW_CLIENT_API, GLFW.GLFW_NO_API);
        GLFW.SetErrorCallback(errorCallback);

        NativeWindow = GLFW.CreateWindow((int)aWindowSize.X, (int)aWindowSize.Y, aName, null, null);

        GLFW.SetScrollCallback(NativeWindow, mouseScrollCallback);
        GLFW.SetMouseButtonCallback(NativeWindow, mouseButtonCallback);
        GLFW.SetCursorPosCallback(NativeWindow, mousePosCallback);
        GLFW.SetKeyCallback(NativeWindow, keyCallback);
        GLFW.SetCharCallback(NativeWindow, charCallback);
        
        Windows.Add((IntPtr)NativeWindow.Handle, this);
    }

    private static void KeyCallback(GLFWwindow* aWindow, int aKey, int aScancode, int aState, int aMods)
    {
        var window = Windows[(IntPtr)aWindow];
        window.EKeyboardKey?.Invoke(window, (KeyboardKey)aKey, (InputState)aState);
    }

    private static void MouseButtonCallback(GLFWwindow* aWindow, int aButton, int aState, int aModifiers)
    {
        var window = Windows[(IntPtr)aWindow];
        Windows[(IntPtr)aWindow].EMouseButton?.Invoke(window, (MouseButton)aButton, (InputState)aState);
    }

    private static void MouseScrollCallback(GLFWwindow* aWindow, double aX, double aY)
    {
        var window = Windows[(IntPtr)aWindow];
        Windows[(IntPtr)aWindow].EMouseScrolled?.Invoke(window, new((float)aX, (float)aY));
    }

    private static void MousePositionCallback(GLFWwindow* aWindow, double x, double y)
    {
        var window = Windows[(IntPtr)aWindow];
        Windows[(IntPtr)aWindow].EMousePosition?.Invoke(window, new((float)x, (float)y));
    }
    
    private static void CharCallback(GLFWwindow* aWindow, uint aCodePoint)
    {
        var window = Windows[(IntPtr)aWindow];
        Windows[(IntPtr)aWindow].ECharInput?.Invoke(window, aCodePoint);
    }

    public void PollEvents()
    {
        lock(this)
        {
            GLFW.PollEvents();
        }
    }
    
    public Vector2 GetCursorPosition()
    {
        double x = 0d, y = 0d;
        GLFW.GetCursorPos(NativeWindow, ref x, ref y);

        return new((float)x, (float)y);
    }
    
    public bool IsMouseButtonDown(MouseButton aMouseButton)
    {
        return GLFW.GetMouseButton(NativeWindow, (int)aMouseButton) == GLFW.GLFW_PRESS;
    }
    
    public bool IsKeyboardKeyDown(KeyboardKey aKey)
    {
        return GLFW.GetKey(NativeWindow, (int)aKey) == GLFW.GLFW_PRESS;
    }
    private static void GlfwError(int code, byte* message)
    {
        Console.WriteLine(PtrToStringUTF8((IntPtr)message));
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
        int width = 0, height = 0;
        GLFW.GetFramebufferSize(NativeWindow, ref width, ref height);

        return (width, height);
    }
    
    public (int width, int height) GetWindowSize()
    {
        int width = 0, height = 0;
        GLFW.GetWindowSize(NativeWindow, ref width, ref height);

        return (width, height);
    }
    
    public void SetWindowPosition(int x, int y)
    {
        GLFW.SetWindowPos(NativeWindow, x, y);
    }
    
    public void SetWindowSize(int width, int height)
    {
        GLFW.SetWindowSize(NativeWindow, width, height);
    }
    
    public (int x, int y) GetWindowPosition()
    {
        int x = 0, y = 0;
        GLFW.GetWindowPos(NativeWindow, ref x, ref y);
        return (x, y);
    }

    public override void OnDestroy()
    {
        GLFW.SetWindowShouldClose(NativeWindow, 1);
        Windows.Remove((IntPtr)NativeWindow.Handle);
    }
    
    public void SetCursor(GLFWcursorPtr aCursor)
    {
        GLFW.SetCursor(NativeWindow, aCursor);
    }

    public void Show()
    {
        GLFW.ShowWindow(NativeWindow);
    }

    public void FocusWindow()
    {
        GLFW.FocusWindow(NativeWindow);
    }

    public void SetTitle(string aTitle)
    {
        GLFW.SetWindowTitle(NativeWindow, aTitle);
    }
}