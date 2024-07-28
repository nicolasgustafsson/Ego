
using ImGuiNET;

namespace Ego;

public class TreeInspector : Node
{
    private Node? InspectedNode = null;

    private ImGuiTreeNodeFlags Flags = ImGuiTreeNodeFlags.SpanFullWidth | ImGuiTreeNodeFlags.FramePadding | ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick;
    private Vector4 EvenColor = new Vector4(1f, 1f, 1f, 0.0392f);
    private Vector4 OddColor = new Vector4(1f, 1f, 1f, 0f);

    private Vector2 FramePadding = new Vector2(0f, 3f);
    
    public TreeInspector()
    {
        Program.Context.Debug.EDebug += EDebug;
    }
    
    unsafe void DrawRowsBackground(int row_count, float line_height, float x1, float x2, float y_offset, uint col_even, uint col_odd)
    {
        var pos = ImGui.GetCursorPos();
        float y0 = ImGui.GetCursorScreenPos().Y + (float)(int)y_offset; 
        
        ImGuiListClipperPtr clipper = new(ImGuiNative.ImGuiListClipper_ImGuiListClipper());

        var draw_list = ImGui.GetWindowDrawList();
        
        clipper.Begin(row_count, line_height);
        while (clipper.Step())
        {
            for (int row_n = clipper.DisplayStart; row_n < clipper.DisplayEnd; ++row_n)
            {
                
                uint col = (row_n % 2 == 1) ? col_odd : col_even;
                
                /*if ((col & IM_COL32_A_MASK) == 0)
                    continue;*/
                
                float y1 = y0 + (line_height * (float)(row_n));
                float y2 = y1 + line_height;
                
                
                draw_list.AddRectFilled(new Vector2(x1, y1), new Vector2(x2, y2), col);
            }
        }
        ImGui.SetCursorPos(pos);
    }
    
    private unsafe void EDebug()
    {
        ImGui.Begin("Node Tree");

        ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, Vector2.Zero);
        ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, FramePadding);

        bool parentActive = ImGui.IsWindowFocused();
        
        if (parentActive)
            ImGui.PushStyleColor(ImGuiCol.Header, ImGui.GetStyleColorVec4(ImGuiCol.TabActive)[0]);

        float windowPosX = ImGui.GetWindowPos().X;
        float x1 = windowPosX + ImGui.GetWindowContentRegionMin().X;;
        float x2 = windowPosX + ImGui.GetWindowContentRegionMax().X;

        float item_spacing_y = ImGui.GetStyle().ItemSpacing.Y;
        float item_offset_y = -item_spacing_y * 0.5f;
        float line_height = ImGui.GetTextLineHeight() + item_spacing_y + FramePadding.Y * 2f;

        Vector2 cursorPosition = ImGui.GetCursorPos();
        
        int rows = Tree(Parent!);

        var afterPos = ImGui.GetCursorPos();

        ImGui.SetCursorPos(cursorPosition);
        DrawRowsBackground(rows, line_height, x1, x2, item_offset_y, ImGui.GetColorU32(EvenColor), ImGui.GetColorU32(OddColor));
        ImGui.SetCursorPos(afterPos);
        
        ImGui.PopStyleVar();
        ImGui.PopStyleVar();
        
        if (parentActive)
            ImGui.PopStyleColor();

        ImGui.End();

        ImGui.Begin("Inspector");
        InspectedNode?.Inspect();
        ImGui.End();
    }
    
    private unsafe int Tree(Node aNode, int rows = 0)
    {
        var flags = Flags;
        if (InspectedNode == aNode)
            flags |= ImGuiTreeNodeFlags.Selected;

        if (aNode.Children.Count == 0)
            flags |= ImGuiTreeNodeFlags.Leaf;

        if (rows == 0)
            flags |= ImGuiTreeNodeFlags.DefaultOpen;
        
        rows++;
        
        if (aNode == InspectedNode)
        {
            ImGui.PushStyleColor(ImGuiCol.HeaderHovered, ImGui.GetStyleColorVec4(ImGuiCol.TabActive)[0]);
            var color = ImGui.GetStyleColorVec4(ImGuiCol.ScrollbarGrabActive)[0];

            color.W = 1f;
            
            ImGui.PushStyleColor(ImGuiCol.HeaderActive, color);
        }

        Vector2 cursorPosition = ImGui.GetCursorPos();
        
        bool wasOpened = ImGui.TreeNodeEx(aNode.GetName(true), flags, "     " + $"{aNode.GetName()}");
        
        if (aNode == InspectedNode)
        {
            ImGui.PopStyleColor();
            ImGui.PopStyleColor();
        }
        var draw_list = ImGui.GetWindowDrawList();

        draw_list.AddText(cursorPosition + ImGui.GetWindowPos() + FramePadding + new Vector2(15f, 0f), ImGui.GetColorU32(new Vector4(1f, 0f, 0f, 1f)), aNode.GetIcon().ToString());
        
        //ImGui.SameLine();
        //ImGui.TextColored(new Vector4(1f, 0f, 0f, 1f), aNode.GetIcon().ToString());
        //ImGui.SameLine();
        //ImGui.Text(aNode.GetName());
       
        
        if (ImGui.IsItemClicked())
            InspectedNode = aNode;
        
        if (wasOpened)
        {
            foreach(var child in aNode.Children)
                rows = Tree(child, rows);
        }
        
            
        if (wasOpened)
            ImGui.TreePop();

        return rows;
    }
    
    public override void Inspect()
    {
        ImGui.ColorPicker4("EvenColor", ref EvenColor);
        ImGui.ColorPicker4("OddColor", ref OddColor);

        ImGui.DragFloat2("FramePadding", ref FramePadding, 0f);
        
        foreach(var bla in Enum.GetValues<ImGuiTreeNodeFlags>())
        {
            bool aFlagIsActive = (Flags & bla) != 0;
            ImGui.Checkbox(bla.ToString(), ref aFlagIsActive);
            if (aFlagIsActive)
                Flags |= bla;
            if (!aFlagIsActive)
                Flags &= ~bla;
        }
    }

    public override char GetIcon()
    {
        return (char)59393;
    }
}