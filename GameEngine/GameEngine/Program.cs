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
        
        while (!window.WantsToClose)
        {
            renderer.Draw();
            window.Update();
        }

        renderer.Cleanup();

        //enable this after triangle hihi
        //window.Close();
    }
}