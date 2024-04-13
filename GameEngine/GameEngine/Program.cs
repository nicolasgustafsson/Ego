using System.Diagnostics;
using System.Text;
using KHRRTXHelloTriangle;

public static class Program
{
    public static void Main()
    {
        HelloTriangle hello = new();
        hello.Run();
    }

    public static void Run()
    {
        Window window = Window.Create("Game");
        Rendering.Engine renderer = null!;

        renderer = new(window);

        while(!window.IsClosing)
        {
            renderer.Draw();
            window.Update();
        }

        renderer.Cleanup();
        
        
    }
}