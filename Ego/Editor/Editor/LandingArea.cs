using NativeFileDialogs.Net;
namespace Editor;

[Node]
public partial class LandingArea : Node
{
    public override void Start()
    {
        base.Start();
        Debug.EDebug += EDebug;
    }

    private void EDebug()
    {

        ImGuiWindowFlags flags = ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings;
        ImGuiViewportPtr viewport = ImGui.GetMainViewport();
        ImGui.SetNextWindowPos(viewport.Pos);
        ImGui.SetNextWindowSize(viewport.Size);
        
        if (ImGui.Begin("Fullscreen window", flags))
        {
            if (ImGui.Button("Select Project..."))
            {
                Editor.Instance.SelectProject();
            }
            
            ImGui.End();
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Debug.EDebug -= EDebug;
    }
}