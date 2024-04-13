public static class Program
{
    public static void Main()
    {
        Run();
    }

    public static void Run()
    {
        Window window = new Window("Game", new Vector2(1280, 720));
        Rendering.Engine renderer = null!;

        renderer = new(window);
        
        while (!window.IsClosed)
        {
            renderer.Draw();
            window.Update();
        }

        renderer.Cleanup();
    }
}