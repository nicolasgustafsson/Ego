using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using GLFW;

public class Window
{
    private static readonly ErrorCallback errorCallback = new ErrorCallback(GlfwError);
    private readonly NativeWindow myNativeWindow;

    public Window(string aName, System.Numerics.Vector2 aWindowSize)
    {
        Glfw.SetErrorCallback(errorCallback);
        myNativeWindow = new((int)aWindowSize.X, (int)aWindowSize.Y, aName);
    }

    public bool IsClosed => myNativeWindow.IsClosed;
    public IntPtr Hwnd => myNativeWindow.Hwnd;
    public string Name => myNativeWindow.Title!;
    
    public IntPtr X11Display => GLFW.Native.GetX11Display();
    public IntPtr X11Window => GLFW.Native.GetX11Window(myNativeWindow);

    public IntPtr WaylandDisplay => GLFW.Native.GetWaylandDisplay();
    public IntPtr WaylandWindow => GLFW.Native.GetWaylandWindow(myNativeWindow);
    public void Update()
    {
        myNativeWindow.SwapBuffers();
        Glfw.PollEvents();
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
}