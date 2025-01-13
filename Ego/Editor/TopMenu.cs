using System.Drawing;
using ImGuiNET;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Filters;

namespace Editor;

enum LoggingType
{
    Normal,
    EditorStatus
}

enum TopMenuStatus
{
    InProgress,
    Success
}

[Node]
public partial class TopMenu : Node, ILogEventSink
{
    private string StatusMessage;
    private System.DateTime StatusTimeStamp;
    private System.DateTime FlashTime;
    private Color StatusColor = Color.White;
    private Vector4 MenuBarColor;
    
    
    public override unsafe void Start()
    {
        base.Start();

        MenuBarColor = *ImGui.GetStyleColorVec4(ImGuiCol.MenuBarBg);
        
        Debug.EDebug += OnDebug;

        (MyContext as EgoContext)!.AddLoggerConfigHook(configuration =>
        {
            return configuration.WriteTo.Logger(lc =>
                lc.Filter.ByIncludingOnly(Matching.WithProperty<LoggingType>("Status", type => type == LoggingType.EditorStatus)).WriteTo.Sink(this));
        });
        
    }

    private void OnDebug()
    {
        Vector4 flashColor = Vector4.Lerp(StatusColor.ToVec4(), MenuBarColor, (float)((DateTime.Now - FlashTime).TotalSeconds).Within(0f, 1f));
        
        ImGui.PushStyleColor(ImGuiCol.MenuBarBg, flashColor);
        
        if (!ImGui.BeginMainMenuBar())
            return;

        if ((System.DateTime.Now - StatusTimeStamp).TotalSeconds < 5f)
        {
            ImGui.Separator();
            ImGui.TextColored(StatusColor.ToVec4(), StatusMessage);
        }
        
        ImGui.EndMainMenuBar();

        ImGui.PopStyleColor();
    }

    public void Emit(LogEvent aLogEvent)
    {
        StatusMessage = aLogEvent.RenderMessage();
        StatusTimeStamp = System.DateTime.Now;
        
        if (aLogEvent.Properties.TryGetValue("EditorStatus", out LogEventPropertyValue aColor))
        {
            if (aColor is ScalarValue scalarVal)
            {
                TopMenuStatus status = (TopMenuStatus)scalarVal.Value!;

                switch (status)
                {
                    case TopMenuStatus.InProgress:
                        StatusColor = Color.Yellow;
                        break;
                    case TopMenuStatus.Success:
                        StatusColor = Color.LawnGreen;
                        FlashTime = System.DateTime.Now;
                        break;
                }
            }
        }
    }
}