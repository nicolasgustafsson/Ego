namespace Ego;

public class Node
{
    private List<Node> myChildren { get; set; } = new();
    public IReadOnlyList<Node> MyChildren => myChildren;
    public Node MyParent => myParent;
    
    private Node myParent = null!;
    public virtual Matrix4x4 WorldMatrix => myParent.WorldMatrix;
    
    public void AddChild(Node aChild)
    {
        myChildren.Add(aChild);
        aChild.myParent = this;
    }
    
    public virtual void Update()
    {
        foreach(Node child in MyChildren)
        {
            child.Update();
        }
    }
}