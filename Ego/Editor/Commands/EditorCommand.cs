namespace Editor;

public abstract class EditorCommand
{
    public abstract Task Do();
    public abstract Task Undo();
}