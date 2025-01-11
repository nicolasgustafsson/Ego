using ImGuiNET;

namespace Editor;

[Node]
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
            WorkingScene.SaveTree(Children.Last());
            var node = WorkingScene.SpawnTree();
            AddChild(node);
        }
    }
    
    public void SerializeScene()
    {
        WorkingScene.SaveTree(Children.Last());
        Children.Last().Destroy();
    }
    
    public void DeserializeScene()
    {
        var node = WorkingScene.SpawnTree();
        AddChild(node);
    }
}