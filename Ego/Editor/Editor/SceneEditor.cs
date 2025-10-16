namespace Editor;

[Node(AllowAddingToScene = false)]
public partial class SceneEditor : Node
{
    private Scene WorkingScene = new(); 
    private Guid InspectedNodeGuid;
    
    public override void Start()
    {
        var scene = AddChild(WorkingScene);
        var node = scene.AddChild(new Node());
        node.AddChild(new EditorDummy());
        
        var movement = AddChild(new EditorCameraMovement());

        movement.AddChild(new Camera());
        
        AddChild(new WorldEnvironment());

        movement.LocalPosition.X -= 3.5f;
        movement.LocalPosition.Y += 3.5f;
        movement.LocalPosition.Z += 5f;
        movement.YawRotation = -0.5f;
        movement.PitchRotation = -0.64f;
        
        movement.UpdateRotation();
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