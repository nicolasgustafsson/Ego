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

    protected override void Update()
    {
        base.Update();

        float segmentSize = 10f;
        int segments = 10;

        float thickness = 0.0f;
        //float x = 0;
        //Shapes.DrawLine(new Vector3(x * segmentSize, 0f, segments * -1f * segmentSize), new Vector3(x * segmentSize, 0f, segments * 1f * segmentSize), Vector4.One, 0.1f);
        for(int x = -segments; x <= segments; x++)
        {
            Shapes.DrawLine(new Vector3(x * segmentSize, 0f, segments * -1f * segmentSize), new Vector3(x * segmentSize, 0f, segments * 1f * segmentSize), Vector4.One, thickness);
        }

        for(int z = -10; z <= 10; z++)
        {
            Shapes.DrawLine(new Vector3(segments * -1f * segmentSize, 0f, z * segmentSize), new Vector3(segments * 1f * segmentSize, 0f, z * segmentSize), Vector4.One, thickness);
        }
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