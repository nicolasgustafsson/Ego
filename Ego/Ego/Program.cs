using System.Diagnostics;
using Ego;
using ImGuiNET;
using Rendering;

public static class Program
{
    public static Renderer MyRenderer = null!;

    public static Trunk myTree = new();
    
    public static void Main()
    {
        Run();
    }

    private static void Run()
    {
        Window window = new Window("Game", new Vector2(1920, 1080));
        MyRenderer = new(window);
        
        ImGuiContext imGuiContext = new (MyRenderer, window);
        
        Stopwatch stopwatch = new();

        SinusoidalMovement child = new();
        child.AddChild(new Camera());
        myTree.AddChild(child);
        
        while (!window.IsClosing)
        {
            myTree.Update();
            stopwatch.Restart();
            
            Debug(MyRenderer, imGuiContext);
            
            MyRenderer.Render();
            
            window.Update();
            Console.WriteLine($"FPS: {1d / stopwatch.Elapsed.TotalSeconds}");
        }

        imGuiContext.Destroy();
        MyRenderer.Cleanup();

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