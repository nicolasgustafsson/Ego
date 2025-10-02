using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using Silk.NET.GLFW;
using Utilities;
using ClientApi = Silk.NET.GLFW.ClientApi;
using Cursor = Silk.NET.GLFW.Cursor;
using ErrorCode = Silk.NET.GLFW.ErrorCode;
using Glfw = Silk.NET.GLFW.Glfw;

public unsafe class Window
{
    private static readonly GlfwCallbacks.ErrorCallback errorCallback = GlfwError;
    private static readonly GlfwCallbacks.ScrollCallback mouseScrollCallback = MouseScrollCallback;
    private static readonly GlfwCallbacks.MouseButtonCallback mouseButtonCallback = MouseButtonCallback;
    private static readonly GlfwCallbacks.KeyCallback keyCallback = KeyCallback;
    private static readonly GlfwCallbacks.CharCallback charCallback = CharCallback;
    private static readonly GlfwCallbacks.CursorPosCallback mousePosCallback = MousePositionCallback;

    private WindowHandle* WindowHandle;

    public Action<Window, Vector2>? EMouseScrolled;
    public Action<Window, Vector2>? EMousePosition;
    public Action<Window, MouseButton, InputState>? EMouseButton;
    public Action<Window, KeyboardKey, InputState>? EKeyboardKey;
    public Action<Window, uint>? ECharInput;

    private static Dictionary<IntPtr, Window> Windows = new();

    public bool IsClosing => GlfwInstance.WindowShouldClose(WindowHandle);
    public bool IsClosed => IsClosing;
    public IntPtr Hwnd => NativeWindow.Win32!.Value.Hwnd;
    public string Title { get; private set; }

    public bool IsMinimized => GlfwInstance.GetWindowAttrib(WindowHandle, WindowAttributeGetter.Iconified);
    public bool IsFocused => GlfwInstance.GetWindowAttrib(WindowHandle, WindowAttributeGetter.Focused);

    public static Glfw GlfwInstance = null!;
    public GlfwNativeWindow NativeWindow;

    public Window(string aTitle, Vector2 aWindowSize)
    {
        Title = aTitle;
        
        if (GlfwInstance == null)
        {
            GlfwInstance = Glfw.GetApi();
            GlfwInstance.Init();
            GlfwInstance.SetErrorCallback(errorCallback);
        }
        
        GlfwInstance.WindowHint(WindowHintClientApi.ClientApi, ClientApi.NoApi);

        WindowHandle = GlfwInstance.CreateWindow(aWindowSize.X.Round(), aWindowSize.Y.Round(), aTitle, null, null);
        NativeWindow = new(GlfwInstance, WindowHandle);
        
        Windows.Add(new IntPtr(WindowHandle), this);
        
        GlfwInstance.SetScrollCallback(WindowHandle, mouseScrollCallback);
        GlfwInstance.SetMouseButtonCallback(WindowHandle, mouseButtonCallback);
        GlfwInstance.SetCursorPosCallback(WindowHandle, mousePosCallback);
        GlfwInstance.SetKeyCallback(WindowHandle, keyCallback);
        GlfwInstance.SetCharCallback(WindowHandle, charCallback);
    }

    private static void KeyCallback(WindowHandle* aWindow, Keys aKey, int aScancode, InputAction aState, KeyModifiers aMods)
    {
        var window = Windows[new IntPtr(aWindow)];
        window.EKeyboardKey?.Invoke(window, (KeyboardKey)aKey, (InputState)aState);
    }

    private static void MouseButtonCallback(WindowHandle* aWindow, Silk.NET.GLFW.MouseButton aButton, InputAction aState, KeyModifiers aModifiers)
    {
        var window = Windows[new IntPtr(aWindow)];
        Windows[new IntPtr(aWindow)].EMouseButton?.Invoke(window, (MouseButton)aButton, (InputState)aState);
    }

    private static unsafe void MouseScrollCallback(WindowHandle* aWindow, double aX, double aY)
    {
        var window = Windows[new IntPtr(aWindow)];
        Windows[new IntPtr(aWindow)].EMouseScrolled?.Invoke(window, new((float)aX, (float)aY));
    }

    private static void MousePositionCallback(WindowHandle* aWindow, double x, double y)
    {
        var window = Windows[new IntPtr(aWindow)];
        Windows[new IntPtr(aWindow)].EMousePosition?.Invoke(window, new((float)x, (float)y));
    }
    
    private static void CharCallback(WindowHandle* aWindow, uint aCodePoint)
    {
        var window = Windows[new IntPtr(aWindow)];
        Windows[new IntPtr(aWindow)].ECharInput?.Invoke(window, aCodePoint);
    }

    public void PollEvents()
    {
        lock(this)
        {
            GlfwInstance.PollEvents();
        }
    }
    
    public Vector2 GetCursorPosition()
    {
        GlfwInstance.GetCursorPos(WindowHandle, out double x, out double y);

        return new((float)x, (float)y);
    }
    
    public bool IsMouseButtonDown(MouseButton aMouseButton)
    {
        return (InputAction)GlfwInstance.GetMouseButton(WindowHandle, (int)aMouseButton) == InputAction.Press;
    }
    
    public bool IsKeyboardKeyDown(KeyboardKey aKey)
    {
        return (InputAction)GlfwInstance.GetKey(WindowHandle, (Keys)aKey) == InputAction.Press;
    }
    private static void GlfwError(ErrorCode code, string message)
    {
        Log.Error($"{message}");
    }
    
    public (int width, int height) GetFramebufferSize()
    {
        GlfwInstance.GetFramebufferSize(WindowHandle, out int width, out int height);

        return (width, height);
    }
    
    public (int width, int height) GetWindowSize()
    {
        GlfwInstance.GetWindowSize(WindowHandle, out int width, out int height);

        return (width, height);
    }
    
    public void SetWindowPosition(int x, int y)
    {
        GlfwInstance.SetWindowPos(WindowHandle, x, y);
    }
    
    public void SetWindowSize(int width, int height)
    {
        GlfwInstance.SetWindowSize(WindowHandle, width, height);
    }
    
    public (int x, int y) GetWindowPosition()
    {
        GlfwInstance.GetWindowPos(WindowHandle, out int X, out int Y);

        return (X, Y);
    }

    public void OnDestroy()
    {
        GlfwInstance.DestroyWindow(WindowHandle);
        Windows.Remove(new IntPtr(WindowHandle));
    }
    
    public void SetCursor(Cursor* aCursor)
    {
        GlfwInstance.SetCursor(WindowHandle, aCursor);
    }

    public void Show()
    {
        GlfwInstance.ShowWindow(WindowHandle);
    }

    public void FocusWindow()
    {
        GlfwInstance.FocusWindow(WindowHandle);
    }

    public void SetTitle(string aTitle)
    {
        Title = aTitle;
        GlfwInstance.SetWindowTitle(WindowHandle, aTitle);
    }

    public void HideCursor()
    {
        GlfwInstance.SetInputMode(WindowHandle, CursorStateAttribute.Cursor, CursorModeValue.CursorHidden);
    }

    public void ShowCursor()
    {
        GlfwInstance.SetInputMode(WindowHandle, CursorStateAttribute.Cursor, CursorModeValue.CursorNormal);
    }
    
    public void SetCursorPosition(Vector2 aMousePosition)
    {
        GlfwInstance.SetCursorPos(WindowHandle, aMousePosition.X, aMousePosition.Y);
    }
    
    public void CenterCursor()
    {
        SetCursorPosition(GetCenter());
    }
    
    public Vector2 GetCenter()
    {
        (int width, int height) windowSize = GetWindowSize();
        return new Vector2(windowSize.width / 2f, windowSize.height / 2f);
    }
}