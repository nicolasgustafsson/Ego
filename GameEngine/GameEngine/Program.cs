using System.Diagnostics;

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
        while (!window.WantsToClose)
        {
            stopwatch.Restart();
            renderer.Draw();
            window.Update();
            Console.WriteLine($"FPS: {1d / stopwatch.Elapsed.TotalSeconds}");
        }

        renderer.Cleanup();

        //enable this after triangle hihi
        //window.Close();
    }
}