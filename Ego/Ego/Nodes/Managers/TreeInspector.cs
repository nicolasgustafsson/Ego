
using ImGuiNET;

namespace Ego;

public class TreeInspector : Node
{
    private Node? InspectedNode = null;

    private ImGuiTreeNodeFlags Flags = ImGuiTreeNodeFlags.SpanFullWidth | ImGuiTreeNodeFlags.FramePadding | ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick;
    
    public TreeInspector()
    {
        Program.Context.Debug.EDebug += EDebug;
    }

    private void EDebug()
    {
        ImGui.Begin("Node Tree");

        ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, Vector2.Zero);
        Tree(Parent!);
        ImGui.PopStyleVar();

        ImGui.End();

        ImGui.Begin("Inspector");
        InspectedNode?.Inspect();
        ImGui.End();
    }
    
    private void Tree(Node aNode)
    {
        var flags = Flags;
        if (InspectedNode == aNode)
            flags |= ImGuiTreeNodeFlags.Selected;

        if (aNode.Children.Count == 0)
            flags |= ImGuiTreeNodeFlags.Leaf;

        bool wasOpened = ImGui.TreeNodeEx(aNode.GetName(true), flags, aNode.GetName());
        
        if (ImGui.IsItemClicked())
            InspectedNode = aNode;
        
        if (wasOpened)
        {
            foreach(var child in aNode.Children)
                Tree(child);
        }
        
            
        if (wasOpened)
            ImGui.TreePop();
    }
    
    public override void Inspect()
    {
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
}