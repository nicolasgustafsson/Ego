using System.Numerics;
using Utilities;

public class Node
{
    private List<Node> xChildren { get; set; } = new();
    private Node? xParent = null;
    
    public IReadOnlyList<Node> Children => xChildren;
    public Node? Parent => xParent;

    public Context? Context => GetFirstParentOfType<Context>();
    
    public T? GetFirstParentOfType<T>() where T : Node
    {
        if (Parent != null && Parent is not T)
            return Parent.GetFirstParentOfType<T>();

        return Parent as T;
    }
    
    public T AddChild<T>(T aChild) where T : Node
    {
        xChildren.Add(aChild);
        aChild.xParent = this;
        return aChild;
    }
    
    public T? Get<T>() where T : Node
    {
        return Children.OfType<T>().FirstOrDefault();
    }
    
    public void RemoveChild<T>(T aChild) where T : Node
    {
        xChildren.Remove(aChild);
    }
    
    public void Destroy()
    {
        foreach (var child in Children.Reverse())
            child.Destroy();
        
        OnDestroy();
        
        //We remove from parent last as OnDestroy might want to do things with the parent
        //Parent may be null when destroying contexts, so null check here
        Parent?.RemoveChild(this);
    }
    
    public virtual void OnDestroy()
    {
        
    }
    
    public string GetName(bool aIncludeUniqueIdentifier = false)
    {
        if (aIncludeUniqueIdentifier)
            return $"{GetType().Name} {GetHashCode()}";
        
        return $"{GetType().Name}";
    }
    
    public virtual char GetIcon()
    {
        return (char)0xe005;
    }

    public virtual void Inspect()
    {
        
    }
}