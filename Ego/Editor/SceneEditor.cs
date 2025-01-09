using ImGuiNET;

namespace Editor;

public class SceneEditor : Node
{
    private Scene WorkingScene = new();
    public override void Inspect()
    {
        base.Inspect();
        
        if (ImGui.Button("Help"))
        {
            WorkingScene.TrySerialize();
        }

        if (ImGui.Button("Duplicate"))
        {
            WorkingScene.SaveTree(Editor.GameAssembly, Children.Last());
            var node = WorkingScene.Spawn(Editor.GameAssembly);
            AddChild(node);
        }
    }
    
    public void SerializeScene()
    {
        WorkingScene.SaveTree(Editor.GameAssembly, Children.Last());
        Children.Last().Destroy();
    }
    
    public void DeserializeScene()
    {
        var node = WorkingScene.Spawn(Editor.GameAssembly);
        AddChild(node);
    }
}