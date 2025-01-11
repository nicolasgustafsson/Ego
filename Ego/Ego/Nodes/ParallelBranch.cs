namespace Ego;

//Handles multithreading!
public abstract class ParallelBranch : Node
{
    public abstract void UpdateBranchInternal();
    public abstract void UpdateSynchronous();
    public abstract void UpdateRoot();
}

public abstract class ParallelBranch<TClass> : ParallelBranch, IEgoContextProvider where TClass : ParallelBranch<TClass>
{
    private new MultithreadingManager MultithreadingManager = null!;
    private new PerformanceMonitor PerformanceMonitor = null!;
    
    public override void Start()
    {
        MultithreadingManager = MyContext.MultithreadingManager; 
        
        //Ensure Context is this here so we don't do things outside the branch
        //MyContext = null!;
        
        base.Start();
        
        MultithreadingManager.Branches.Add(this);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        
        MultithreadingManager.Branches.Remove(this);
    }

    private List<Action<TClass>> Messages = new();

    public void QueueMessage(Action<TClass> aMessage)
    {
        Messages.Add(aMessage);
    }

    public void HandleMessages()
    {
        foreach (Action<TClass> message in Messages)
        {
            message((TClass)this);
        }

        Messages.Clear();
    }
    
    public sealed override void UpdateBranchInternal()
    {
        HandleMessages();
        UpdateBranch();
        UpdateChildren();
    }
    
    public abstract void UpdateBranch();
}