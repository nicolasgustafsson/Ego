using System.Diagnostics;
using GLFW;

public static class Program
{
    public static void Main()
    {
        Run();
    }

    private static void Run()
    {
        Window window = new Window("Game", new Vector2(1280, 720));
        Rendering.Renderer renderer = null!;

        renderer = new(window);

        Stopwatch stopwatch = new();
        while (!window.IsClosing)
        {
            stopwatch.Restart();
            renderer.MyImGuiContext.Begin();

            renderer.Debug();
            
            renderer.MyImGuiContext.End();
            
            renderer.Draw();
            window.Update();
            //Console.WriteLine($"FPS: {1d / stopwatch.Elapsed.TotalSeconds}");
        }

        renderer.Cleanup();

        window.Close();
    }
}