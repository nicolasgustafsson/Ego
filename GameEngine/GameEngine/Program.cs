using System.Diagnostics;
using ImGuiNET;
using Rendering;

public static class Program
{
    public static void Main()
    {
        Run();
    }

    private static void Run()
    {
        Window window = new Window("Game", new Vector2(1280, 720));
        Renderer renderer = new(window);
        ImGuiContext imGuiContext = new (renderer, window);
        
        Stopwatch stopwatch = new();
        while (!window.IsClosing)
        {
            stopwatch.Restart();
            
            Debug(renderer, imGuiContext);
            
            renderer.Draw();
            
            window.Update();
            Console.WriteLine($"FPS: {1d / stopwatch.Elapsed.TotalSeconds}");
        }

        imGuiContext.Destroy();
        renderer.Cleanup();

        window.Close();
    }
    
    private static void Debug(Renderer aRenderer, ImGuiContext aImguiContext)
    {
        aImguiContext.Begin();
        
        ImGui.DockSpaceOverViewport(0, null, ImGuiDockNodeFlags.PassthruCentralNode);
        aRenderer.Debug();

        ImGui.ShowDemoWindow();
        ImGui.ShowAboutWindow();
        
        aImguiContext.End();
    }
}