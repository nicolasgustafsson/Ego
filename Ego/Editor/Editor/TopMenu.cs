using System.Drawing;
using ImGuiNET;

namespace Editor;

[Node]
public partial class TopMenu : Node
{
    public enum TopMenuState
    {
        None,
        Flash,
        Color
    }
    
    private string StatusMessage = "";
    private DateTime StatusTimeStamp;
    private DateTime FlashTime;
    private Color StatusColor = Color.White;
    private Vector4 MenuBarColor;
    private TopMenuState State = TopMenuState.Flash;
    
    public override unsafe void Start()
    {
        base.Start();

        MenuBarColor = *ImGui.GetStyleColorVec4(ImGuiCol.MenuBarBg);
        
        Debug.EDebug += OnDebug;
    }

    private void OnDebug()
    {
        switch(State)
        {
            case TopMenuState.Flash:
                float flashProgress = (float)((DateTime.Now - FlashTime).TotalSeconds).Within(0f, 1f);
                Vector4 flashColor = Vector4.Lerp(StatusColor.ToVec4(), MenuBarColor, flashProgress);
                ImGui.PushStyleColor(ImGuiCol.MenuBarBg, flashColor);

                if (flashProgress > 0.999f)
                    State = TopMenuState.None;
                
                break;
            
            case TopMenuState.Color:
                ImGui.PushStyleColor(ImGuiCol.MenuBarBg, StatusColor.ToVec4());
                break;

            case TopMenuState.None:
            default:
                ImGui.PushStyleColor(ImGuiCol.MenuBarBg, MenuBarColor);
                break;
        }
        
        if (!ImGui.BeginMainMenuBar())
            return;

        if ((System.DateTime.Now - StatusTimeStamp).TotalSeconds < 5f)
        {
            ImGui.Separator();
            ImGui.Text(StatusMessage);
        }
        
        ImGui.EndMainMenuBar();

        ImGui.PopStyleColor();
    }
    
    public void Flash(Color aColor, string aMessage)
    {
        StatusColor = aColor;
        FlashTime = System.DateTime.Now;

        StatusMessage = aMessage;
        StatusTimeStamp = System.DateTime.Now;

        State = TopMenuState.Flash;
    }
    
    public void SetColor(Color aColor, string aMessage)
    {
        StatusColor = aColor;
        StatusMessage = aMessage;
        StatusTimeStamp = System.DateTime.Now;

        State = TopMenuState.Color;
    }
}