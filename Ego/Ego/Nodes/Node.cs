namespace Ego;

public class Node : IEgoContextProvider
{
    //TODO: These can be source generated? 
    public TimeKeeper Time => MyContext.Time;
    public Window Window => MyContext.Window;
    public Debug Debug => MyContext.Debug;
    public RendererApi RendererApi => MyContext.RendererApi;
    public AssetManager AssetManager => MyContext.AssetManager;
    public TreeInspector TreeInspector => MyContext.TreeInspector;
    public MultithreadingManager MultithreadingManager => MyContext.MultithreadingManager;
    public PerformanceMonitor PerformanceMonitor => MyContext.PerformanceMonitor;
    
    private List<Node> xChildren { get; set; } = new();
    private Node? xParent = null;
    
    public IReadOnlyList<Node> Children => xChildren;
    public Node? Parent => xParent;

    public IEgoContextProvider MyContext = null!;
    
    public T? GetFirstParentOfType<T>() where T :Node
    {
        if (Parent != null && Parent is not T)
            return Parent.GetFirstParentOfType<T>();

        return Parent as T;
    }
    
    public T AddChild<T>(T aChild) where T : Node
    {
        xChildren.Add(aChild);
        aChild.xParent = this;
        aChild.MyContext = MyContext;

        aChild.Start();
        return aChild;
    }
    
    public T? Get<T>() where T  : Node
    {
        return xChildren.OfType<T>().FirstOrDefault();
    }
    
    public void RemoveChild<T>(T aChild) where T : Node
    {
        xChildren.Remove(aChild);
    }
    
    public virtual void Start()
    {
        
    }
    
    internal virtual void UpdateInternal()
    {
        Update();

        UpdateChildren();
    }

    internal void UpdateChildren()
    {
        foreach(Node child in xChildren)
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
        foreach (Node child in Children.Reverse())
            child.Destroy();
    }
    
    public virtual void OnDestroy()
    {
        
    }

    protected virtual string Name => GetType().Name;
    
    public string GetName(bool aIncludeUniqueIdentifier = false)
    {
        if (aIncludeUniqueIdentifier)
            return $"{Name}{GetHashCode()}";
        
        return Name;
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