namespace Ego;

[Node(AllowAddingToScene = false)]
public partial class MultithreadingManager : Node
{
    public List<ParallelBranch> Branches = new();
    public static EgoSynchronizationContext EgoSynchronizationContext = null!;
    
    public MultithreadingManager()
    {
        Thread.CurrentThread.Name = "Main Thread";
        EgoSynchronizationContext = new();
        SynchronizationContext.SetSynchronizationContext(EgoSynchronizationContext);
    }

    public Task RunParallelTasks()
    {
        List<Task> parallels = new(); 
        foreach(ParallelBranch branch in Branches)
        {
            parallels.Add(Task.Run(branch.UpdateBranchInternal));
        }

        var task = Task.WhenAll(parallels);
        return task;
    }

    public void UpdateSynchronous()
    {
        foreach(ParallelBranch branch in Branches)
        {
            branch.UpdateSynchronous();
        }
    }

    protected override void Update()
    {
        foreach(ParallelBranch branch in Branches)
        {
            branch.UpdateRoot(); 
        }

        EgoSynchronizationContext.ExecuteMainThreadContinuations();
    }
}