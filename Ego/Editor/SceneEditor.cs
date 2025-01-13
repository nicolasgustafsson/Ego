using ImGuiNET;

namespace Editor;

[Node(HideInEditor = true)]
public partial class SceneEditor : Node
{
    private Scene WorkingScene = new();
    private Guid InspectedNodeGuid;
    
    public override void Start()
    {
        AddChild(WorkingScene);
    }
    
    public void Inspect()
    {
        if (ImGui.Button("Duplicate"))
        {
            WorkingScene.SerializeTree(Children.Last());
            var node = WorkingScene.DeserializeTree();
            AddChild(node);
        }
    }
    
    public void PrepareForHotReload()
    {
        if (TreeInspector.InspectedNode != null)
            InspectedNodeGuid = TreeInspector.InspectedNode.Guid;
        WorkingScene.SerializeTree(Children.Last());
        Children.Last().Destroy();
    }
    
    public void ReinitializeAfterHotReload()
    {
        Node node = WorkingScene.DeserializeTree();
        AddChild(node);
        TreeInspector.InspectedNode = node.FindNodeWithGuid(InspectedNodeGuid);
    }
    
    public void Save()
    {
        
    }
    
    public void Load()
    {
        
    }
}