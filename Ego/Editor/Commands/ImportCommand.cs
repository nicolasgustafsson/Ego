namespace Editor;

public class ImportCommand : EditorCommand
{
    private readonly string ImportPath;
    private Node? CreatedChild = null;
    
    public ImportCommand(string aPath)
    {
        ImportPath = aPath;
    }
    
    public override async Task Do()
    {
        Mesh mesh = new();
        await mesh.Import(ImportPath);
        CreatedChild = Editor.Instance.AssetManager.AddChild(mesh);
    }

    public override async Task Undo()
    {
        CreatedChild?.Destroy();
    }
}