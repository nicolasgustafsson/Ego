using System.Numerics;

public partial class BaseNode
{
    private List<BaseNode> xChildren { get; set; } = new();
    private BaseNode? xParent = null;
    
    public IReadOnlyList<BaseNode> Children => xChildren;
    public BaseNode? Parent => xParent;

    public Context Context = null!;
    
    public T? GetFirstParentOfType<T>() where T : BaseNode
    {
        if (Parent != null && Parent is not T)
            return Parent.GetFirstParentOfType<T>();

        return Parent as T;
    }
    
    public T AddChild<T>(T aChild) where T : BaseNode
    {
        xChildren.Add(aChild);
        aChild.xParent = this;
        aChild.Context = Context;

        aChild.Start();
        return aChild;
    }
    
    public T? Get<T>() where T : BaseNode
    {
        return xChildren.OfType<T>().FirstOrDefault();
    }
    
    public void RemoveChild<T>(T aChild) where T : BaseNode
    {
        xChildren.Remove(aChild);
    }
    
    public virtual void Start()
    {
        
    }
    
    protected void UpdateInternal()
    {
        Update();
        
        foreach(var child in xChildren)
        {
            child.UpdateInternal();
        }
    }
    
    protected virtual void Update()
    {
        
    }
    
    public void Destroy()
    {
        DestroyChildren();
        
        OnDestroy();
        
        //We remove from parent last as OnDestroy might want to do things with the parent
        //Parent may be null when destroying contexts, so null check here
        Parent?.RemoveChild(this);
    }
    
    protected virtual void DestroyChildren()
    {
        foreach (var child in Children.Reverse())
            child.Destroy();
    }
    
    public virtual void OnDestroy()
    {
        
    }

    protected virtual string Name => GetType().Name;
    
    public string GetName(bool aIncludeUniqueIdentifier = false)
    {
        if (aIncludeUniqueIdentifier)
            return $"{Name} {GetHashCode()}";
        
        return $"{Name}";
    }
    
    public virtual char GetIcon()
    {
        return (char)61708;
    }
    
    public virtual Vector4? GetIconColor()
    {
        return null;
    }

    public virtual void Inspect()
    {
        
    }
}