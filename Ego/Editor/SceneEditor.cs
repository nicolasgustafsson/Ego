using ImGuiNET;

namespace Editor;

[Node(HideInEditor = true)]
public partial class SceneEditor : Node
{
    private Scene WorkingScene = new();
    
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
    
    public void SerializeScene()
    {
        WorkingScene.SerializeTree(Children.Last());
        Children.Last().Destroy();
    }
    
    public void DeserializeScene()
    {
        var node = WorkingScene.DeserializeTree();
        AddChild(node);
    }
    
    public void Save()
    {
        
    }
    
    public void Load()
    {
        
    }
}