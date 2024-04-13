using System.Diagnostics;
using System.Text;

public static class Program
{
    public static void Main()
    {
        Run();
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