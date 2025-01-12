namespace Ego;

[Node(HideInEditor = true)]
public partial class MultithreadingManager : Node
{
    public List<ParallelBranch> Branches = new();

    public Task RunParallelTasks()
    {
        List<Task> parallels = new(); 
        foreach(ParallelBranch branch in Branches)
        {
            parallels.Add(Task.Run(branch.UpdateBranchInternal));
        }

        return Task.WhenAll(parallels);
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
    }
}