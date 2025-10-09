using System.Reflection;
using ImguiBindings;

namespace Ego;

public class TreeInspector : Node
{
    public Node? InspectedNode = null;
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
        Vector2 pos = Imgui.GetCursorPos();
        float y0 = Imgui.GetCursorScreenPos().Y + (float)(int)aYOffset; 
        
        ImguiListClipper clipper = new();
        
        ImguiDrawList draw_list = Imgui.GetWindowDrawList();
        
        clipper.Begin(aRowCount, aLineHeight);
        while (clipper.Step())
        {
            for (int row_n = clipper.DisplayStart; row_n < clipper.DisplayEnd; ++row_n)
            {
                uint columnColor = (row_n % 2 == 1) ? aOddColor : aEvenColor;
                
                /*if ((col & IM_COL32_A_MASK) == 0)
                    continue;*/
                
                float y1 = y0 + (aLineHeight * (float)(row_n));
                float y2 = y1 + aLineHeight;
                
                
                draw_list.AddRectFilled(new Vector2(aMinX, y1), new Vector2(aMaxX, y2), columnColor);
            }
        }

        clipper.Destroy();
        Imgui.SetCursorPos(pos);
    }
    
    private unsafe void EDebug()
    {
        Imgui.Begin("Inspector");
        if (InspectedNode != null)
        {
            Imgui.PushID(InspectedNode.Guid.ToString());
            if (InspectedNode.Guid != PreviousInspectedNode?.Guid)
                Imgui.GetStateStorage().Clear();

            InspectedNode.GeneratedInspect();

            PreviousInspectedNode = InspectedNode;
            Imgui.PopID();
        }
        
        Imgui.End();
        Imgui.Begin("Node Tree");

        Imgui.PushStyleVar(ImGuiStyleVar.ItemSpacing, Vector2.Zero);
        Imgui.PushStyleVar(ImGuiStyleVar.FramePadding, FramePadding);
        
        bool parentActive = Imgui.IsWindowFocused();
        
        if (parentActive)
            Imgui.PushStyleColor(ImGuiCol.Header, Imgui.GetStyleColorVec4(ImGuiCol.TabSelected));

        float minX = Imgui.GetCursorScreenPos().X;
        float maxX = minX + Imgui.GetContentRegionAvail().X;

        float verticalSpacing = Imgui.GetStyle().ItemSpacing.Y;
        float yOffset = -verticalSpacing * 0.5f;
        float lineHeight = Imgui.GetTextLineHeight() + verticalSpacing + FramePadding.Y * 2f;

        Vector2 cursorPosition = Imgui.GetCursorPos();
        
        int rowCount = Tree(Parent!);

        Vector2 afterPos = Imgui.GetCursorPos();

        Imgui.SetCursorPos(cursorPosition);
        DrawRowsBackground(rowCount, lineHeight, minX, maxX, yOffset, Imgui.GetColorU32(EvenColor), Imgui.GetColorU32(OddColor));
        Imgui.SetCursorPos(afterPos);
        
        Imgui.PopStyleVar();
        Imgui.PopStyleVar();
        
        if (parentActive)
            Imgui.PopStyleColor();

        Imgui.End();
    }
    
    private unsafe int Tree(Node aNode, int aRows = 0)
    {
        ImGuiTreeNodeFlags flags = Flags;
        if (InspectedNode == aNode) 
            flags |= ImGuiTreeNodeFlags.Selected;

        if (aNode.Children.Length == 0)
            flags |= ImGuiTreeNodeFlags.Leaf;

        flags |= ImGuiTreeNodeFlags.DefaultOpen;
        
        aRows++;
        
        if (aNode == InspectedNode)
        {
            Imgui.PushStyleColor(ImGuiCol.HeaderHovered, Imgui.GetStyleColorVec4(ImGuiCol.TabSelected));
            Vector4 color = Imgui.GetStyleColorVec4(ImGuiCol.ScrollbarGrabActive);

            color.W = 1f;
            
            Imgui.PushStyleColor(ImGuiCol.HeaderActive, color);
        }

        Vector2 cursorPosition = Imgui.GetCursorScreenPos();

        Imgui.PushID(aNode.GetHashCode());
        
        bool wasOpened = Imgui.TreeNodeEx(aNode.GetName(), flags, "     " + $"{aNode.GetName()}");
        
        if (aNode == InspectedNode)
        {
            Imgui.PopStyleColor();
            Imgui.PopStyleColor();
        }
        ImguiDrawList draw_list = Imgui.GetWindowDrawList();

        Vector4? requestedColor = aNode.GetIconColor();
        uint requestedU32Color = requestedColor.HasValue ? Imgui.GetColorU32(requestedColor.Value) : Imgui.GetColorU32(ImGuiCol.Text);
        
        draw_list.AddText(cursorPosition + FramePadding + new Vector2(15f, 0f), requestedU32Color, $"{aNode.GetIcon()}");
        
        if (Imgui.IsItemClicked())
            InspectedNode = aNode;
        
        if (Imgui.IsItemClicked(ImGuiMouseButton.Right))
        {
            InspectedNode = aNode;
            Imgui.OpenPopup("Context Menu");
        }
        
        if (Imgui.BeginPopup("Context Menu"))
        {
            Imgui.SeparatorText("Node Actions");
            if (Imgui.Selectable("Duplicate"))
            {
                aNode.Parent!.AddChild(aNode.Duplicate());
            }
            
            if (Imgui.Selectable("Delete"))
            {
                if (aNode == InspectedNode)
                    InspectedNode = null;

                aNode.Destroy();
            }
            
            Imgui.SeparatorText("Add Node...");
            
            foreach(var keyValue in NodeTypeDatabase.NodeTypes)
            {
                if (keyValue.Value.IsAbstract)
                    continue;
                
                NodeAttribute? attribute = keyValue.Value.GetCustomAttribute<NodeAttribute>();

                if (attribute is null || !attribute.AllowAddingToScene)
                    continue;
                    
                if (Imgui.Selectable(keyValue.Key))
                {
                    if (Activator.CreateInstance(keyValue.Value) is Node child)
                        aNode.AddChild(child);
                }
            }

            Imgui.EndPopup();
        }
        
        if (wasOpened)
        {
            foreach(Node child in new List<Node>(aNode.Children.ToArray()))
                aRows = Tree(child, aRows);
        }
        
        if (wasOpened)
            Imgui.TreePop();

        Imgui.PopID();
        return aRows;
    }

    public override char GetIcon()
    {
        return (char)59393;
    }
}