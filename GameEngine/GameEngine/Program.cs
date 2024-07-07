using System.Diagnostics;
using GLFW;
using ImGuiNET;

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

            ImGui.Begin("Test");
            ImGuiEx.Image(renderer.myCheckerBoardImage, new Vector2(160, 160));
            ImGui.End();

            ImGui.DockSpaceOverViewport(0, null, ImGuiDockNodeFlags.PassthruCentralNode);
            
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