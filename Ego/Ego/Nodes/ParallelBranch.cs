namespace Ego;

//Handles multithreading!
public abstract class ParallelBranch : Node, IEgoContextProvider
{
    private new MultithreadingManager MultithreadingManager = null!;
    
    public override void Start()
    {
        MultithreadingManager = MyContext.MultithreadingManager;
        
        //Ensure Context is null here so we don't do things outside the branch
        MyContext = null!;
        
        base.Start();
        
        MultithreadingManager.Branches.Add(this);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        
        MultithreadingManager.Branches.Remove(this);
    }

    internal override void UpdateInternal()
    {
    }

    protected sealed override void Update()
    {
    }

    public abstract void HandleMessages();
    
    public void UpdateBranch()
    {
        UpdateChildren();
    }
}

public class ParallelBranch<T> : ParallelBranch where T : Node
{
    private List<Action<T>> Messages = new();

    private T BranchRoot = null!;
    
    public ParallelBranch(T aBranchRoot)
    {
        BranchRoot = aBranchRoot;
    }
    
    public override void Start()
    {
        base.Start();

        AddChild(BranchRoot);
    }

    public void QueueMessage(Action<T> aMessage)
    {
        Messages.Add(aMessage);
    }

    public override void HandleMessages()
    {
        foreach (Action<T> message in Messages)
        {
            message(BranchRoot);
        }

        Messages.Clear();
    }
}