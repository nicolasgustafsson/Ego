using GLFW;

public class Window
{
    private readonly NativeWindow myNativeWindow;
    public bool IsClosing => myNativeWindow.IsClosing;
    public IntPtr Hwnd => myNativeWindow.Hwnd;
    public string Name => myNativeWindow.Title!;
    public IntPtr LinuxDisplay => GLFW.Native.GetX11Display();
    public IntPtr LinuxWindow => GLFW.Native.GetX11Window(myNativeWindow);
    
    public static Window Create(string aName)
    {
        var window = new Window(aName);

        return window;
    }

    private Window(string aName)
    {
        myNativeWindow = new NativeWindow(1280, 720, aName);    
    }
    
    public void Update()
    {
        //myNativeWindow.SwapBuffers();
        Glfw.PollEvents();
    }
}