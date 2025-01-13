using System.Runtime.Serialization;
using ImGuiNET;
using MessagePack;

namespace Ego;

[Node]
public partial class Node : IEgoContextProvider
{
    [MessagePackObject(true)]
    public class SceneBranchNode
    {
        public SerializedNode Node;
        public List<SceneBranchNode> Children = new();
    }
    [Serialize] public System.Guid Guid = System.Guid.NewGuid();

    private bool HasStarted = false;
    
    //TODO: These can be source generated? 
    public TimeKeeper Time => MyContext.Time;
    public Window Window => MyContext.Window;
    public Debug Debug => MyContext.Debug;
    public RendererApi RendererApi => MyContext.RendererApi;
    public AssetManager AssetManager => MyContext.AssetManager;
    public TreeInspector TreeInspector => MyContext.TreeInspector;
    public MultithreadingManager MultithreadingManager => MyContext.MultithreadingManager;
    public PerformanceMonitor PerformanceMonitor => MyContext.PerformanceMonitor;
    public NodeTypeDatabase NodeTypeDatabase => MyContext.NodeTypeDatabase;

    private List<Node> xChildren { get; set; } = new();
    private Node? xParent = null;

    public Node? FindNodeWithGuid(Guid aGuid)
    {
        if (Guid == aGuid)
            return this;
        
        foreach(var child in xChildren)
        {
            var node = child.FindNodeWithGuid(aGuid);

            if (node != null)
                return node;
        }

        return null;
    }

    public IReadOnlyList<Node> Children => xChildren; 
    public Node? Parent => xParent;

    public IEgoContextProvider MyContext = null!; 
     
    public T? GetFirstParentOfType<T>() where T :Node
    {
        if (Parent != null && Parent is not T)
            return Parent.GetFirstParentOfType<T>();

        return Parent as T; 
    }
    
    public T AddChild<T>(T aChild, bool aStart = true) where T : Node
    {
        xChildren.Add(aChild);

        aChild.SetParent(this, aStart);

        return aChild;
    }
    
    private void SetParent(Node aParent, bool aStart)
    {
        xParent = aParent;
        MyContext = aParent.MyContext;

        if (aStart && MyContext != null && !HasStarted)
        {
            HasStarted = true;
            Start();
        }
        
        //update context
        foreach (var child in xChildren)
            child.SetParent(this, aStart);
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
    
    public Node Duplicate()
    {
        return DeserializeTree(SerializeTree(), true);
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

    public override int GetHashCode()
    {
        return Guid.GetHashCode();
    }
    
    public SceneBranchNode SerializeTree()
    {
        return SerializeBranch(this);
    }
    
    private SceneBranchNode SerializeBranch(Node aBranch)
    {
        SceneBranchNode serialized = new();
        serialized.Node = aBranch.Serialize();
        foreach(var node in aBranch.Children)
        {
            serialized.Children.Add(SerializeBranch(node));
        }

        return serialized;
    }
    
    public Node DeserializeTree(SceneBranchNode aNode, bool aNewGuid)
    {
        Node node = DeserializeBranch(aNode, aNewGuid);

        return node;
    }
    
    public Node DeserializeBranch(SceneBranchNode aSerializedTree, bool aNewGuid)
    {
        Node aNode = aSerializedTree.Node.Deserialize(NodeTypeDatabase);
        if (aNewGuid)
            aNode.Guid = Guid.NewGuid();
        
        foreach(var branch in aSerializedTree.Children)
        {
            aNode.AddChild(DeserializeBranch(branch, aNewGuid), false);
        }

        return aNode;
    }
}