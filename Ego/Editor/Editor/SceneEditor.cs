using ImGuiNET;
using Environment = Ego.Environment;

namespace Editor;

[Node(AllowAddingToScene = false)]
public partial class SceneEditor : Node
{
    private Scene WorkingScene = new();
    private Guid InspectedNodeGuid;
    
    public override void Start()
    {
        var scene = AddChild(WorkingScene);
        scene.AddChild(new MeshRenderer());
        
        var movement = AddChild(new EditorCameraMovement());

        movement.AddChild(new Camera());
        movement.AddChild(new Environment());

        movement.LocalPosition.Z += 5f;
    }
    
    public void PrepareForHotReload()
    {
        if (TreeInspector.InspectedNode != null)
            InspectedNodeGuid = TreeInspector.InspectedNode.Guid;
        WorkingScene.SerializeTree(WorkingScene.Children[0]);
        WorkingScene.Children[0].Destroy();
    }
    
    public void ReinitializeAfterHotReload()
    {
        Node node = WorkingScene.DeserializeTree();
        WorkingScene.AddChild(node);
        TreeInspector.InspectedNode = node.FindNodeWithGuid(InspectedNodeGuid);
    }
    
    public void Save()
    {
        
    }
    
    public void Load()
    {
        
    }
}