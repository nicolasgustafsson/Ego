using NativeFileDialogs.Net;
using ImGuiViewport = ImguiBindings.ImGuiViewport;

namespace Editor;

[Node]
public partial class LandingArea : Node
{
    public override void Start()
    {
        base.Start();
        Debug.EDebug += EDebug;
    }

    private unsafe void EDebug()
    {

        ImGuiWindowFlags_ flags = ImGuiWindowFlags_.ImGuiWindowFlags_NoDecoration | ImGuiWindowFlags_.ImGuiWindowFlags_NoMove | ImGuiWindowFlags_.ImGuiWindowFlags_NoSavedSettings;
        ImGuiViewport* viewport = Imgui.GetMainViewport();
        Imgui.SetNextWindowPos(viewport->Pos);
        Imgui.SetNextWindowSize(viewport->Size);
        
        if (Imgui.Begin("Fullscreen window", flags))
        {
            if (Imgui.Button("Select Project..."))
            {
                Editor.Instance.SelectProject();
            }
            
            Imgui.End();
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Debug.EDebug -= EDebug;
    }
}