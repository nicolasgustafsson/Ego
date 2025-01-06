using ImGuiNET;

namespace Ego;

public class TreeInspector : Node
{
    private Node? InspectedNode = null;
    private Node? PreviousInspectedNode = null;

    private ImGuiTreeNodeFlags Flags = ImGuiTreeNodeFlags.SpanFullWidth | ImGuiTreeNodeFlags.FramePadding | ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick;
    private Vector4 EvenColor = new Vector4(1f, 1f, 1f, 0.0392f);
    private Vector4 OddColor = new Vector4(1f, 1f, 1f, 0f);

    private Vector2 FramePadding = new Vector2(0f, 3f);

    public override void Start()
    {
        base.Start();
        Debug.EDebug += EDebug;
    }

    unsafe void DrawRowsBackground(int aRowCount, float aLineHeight, float aMinX, float aMaxX, float aYOffset, uint aEvenColor, uint aOddColor)
    {
        Vector2 pos = ImGui.GetCursorPos();
        float y0 = ImGui.GetCursorScreenPos().Y + (float)(int)aYOffset; 
        
        ImGuiListClipperPtr clipper = new(ImGuiNative.ImGuiListClipper_ImGuiListClipper());

        ImDrawListPtr draw_list = ImGui.GetWindowDrawList();
        
        clipper.Begin(aRowCount, aLineHeight);
        while (clipper.Step())
        {
            for (int row_n = clipper.DisplayStart; row_n < clipper.DisplayEnd; ++row_n)
            {
                
                uint col = (row_n % 2 == 1) ? aOddColor : aEvenColor;
                
                /*if ((col & IM_COL32_A_MASK) == 0)
                    continue;*/
                
                float y1 = y0 + (aLineHeight * (float)(row_n));
                float y2 = y1 + aLineHeight;
                
                
                draw_list.AddRectFilled(new Vector2(aMinX, y1), new Vector2(aMaxX, y2), col);
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

        float minX = ImGui.GetCursorScreenPos().X;
        float maxX = minX + ImGui.GetContentRegionAvail().X;

        float verticalSpacing = ImGui.GetStyle().ItemSpacing.Y;
        float yOffset = -verticalSpacing * 0.5f;
        float lineHeight = ImGui.GetTextLineHeight() + verticalSpacing + FramePadding.Y * 2f;

        Vector2 cursorPosition = ImGui.GetCursorPos();
        
        int rowCount = Tree(Parent!);

        Vector2 afterPos = ImGui.GetCursorPos();

        ImGui.SetCursorPos(cursorPosition);
        DrawRowsBackground(rowCount, lineHeight, minX, maxX, yOffset, ImGui.GetColorU32(EvenColor), ImGui.GetColorU32(OddColor));
        ImGui.SetCursorPos(afterPos);
        
        ImGui.PopStyleVar();
        ImGui.PopStyleVar();
        
        if (parentActive)
            ImGui.PopStyleColor();

        ImGui.End();


        ImGui.Begin("Inspector");
        if (InspectedNode != null)
        {
            if (InspectedNode != PreviousInspectedNode)
                ImGui.GetStateStorage().Clear();
            InspectedNode.Inspect();

            PreviousInspectedNode = InspectedNode;
        }
        
        ImGui.End();
    }
    
    private unsafe int Tree(Node aNode, int aRows = 0)
    {
        ImGuiTreeNodeFlags flags = Flags;
        if (InspectedNode == aNode)
            flags |= ImGuiTreeNodeFlags.Selected;

        if (aNode.Children.Count == 0)
            flags |= ImGuiTreeNodeFlags.Leaf;

        if (aRows == 0)
            flags |= ImGuiTreeNodeFlags.DefaultOpen;
        
        aRows++;
        
        if (aNode == InspectedNode)
        {
            ImGui.PushStyleColor(ImGuiCol.HeaderHovered, ImGui.GetStyleColorVec4(ImGuiCol.TabActive)[0]);
            Vector4 color = ImGui.GetStyleColorVec4(ImGuiCol.ScrollbarGrabActive)[0];

            color.W = 1f;
            
            ImGui.PushStyleColor(ImGuiCol.HeaderActive, color);
        }

        Vector2 cursorPosition = ImGui.GetCursorScreenPos();

        ImGui.PushID(aNode.GetHashCode());
        bool wasOpened = ImGui.TreeNodeEx(aNode.GetName(), flags, "     " + $"{aNode.GetName()}");
        ImGui.PopID();
        
        if (aNode == InspectedNode)
        {
            ImGui.PopStyleColor();
            ImGui.PopStyleColor();
        }
        ImDrawListPtr draw_list = ImGui.GetWindowDrawList();

        Vector4? requestedColor = aNode.GetIconColor();
        uint requestedU32Color = requestedColor.HasValue ? ImGui.GetColorU32(requestedColor.Value) : ImGui.GetColorU32(ImGuiCol.Text);
        
        draw_list.AddText(cursorPosition + FramePadding + new Vector2(15f, 0f), requestedU32Color, aNode.GetIcon().ToString());
    
        if (ImGui.IsItemClicked())
        {
            InspectedNode = aNode;
        }
        
        if (wasOpened)
        {
            foreach(Node child in aNode.Children)
                aRows = Tree(child, aRows);
        }
        
        if (wasOpened)
            ImGui.TreePop();

        return aRows;
    }

    public override char GetIcon()
    {
        return (char)59393;
    }
}