using ImGuiNET;

namespace Editor;

[Node(AllowAddingToScene = false)]
public partial class SceneEditor : Node
{
    private Scene WorkingScene = new();
    private Guid InspectedNodeGuid;
    
    public override void Start()
    {
        AddChild(WorkingScene);
    }
    
    public void PrepareForHotReload()
    {
        if (TreeInspector.InspectedNode != null)
            InspectedNodeGuid = TreeInspector.InspectedNode.Guid;
        WorkingScene.SerializeTree(Children[^1]);
        Children[^1].Destroy();
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