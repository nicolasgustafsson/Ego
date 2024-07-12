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
            
            Debug(renderer);
            
            renderer.Draw();
            window.Update();
            Console.WriteLine($"FPS: {1d / stopwatch.Elapsed.TotalSeconds}");
        }

        renderer.Cleanup();

        window.Close();
    }
    
    private static void Debug(Rendering.Renderer aRenderer)
    {
        aRenderer.MyImGuiContext.Begin();
        
        ImGui.DockSpaceOverViewport(0, null, ImGuiDockNodeFlags.PassthruCentralNode);
        aRenderer.Debug();

        ImGui.ShowDemoWindow();
        ImGui.ShowAboutWindow();
        
        aRenderer.MyImGuiContext.End();
    }
}