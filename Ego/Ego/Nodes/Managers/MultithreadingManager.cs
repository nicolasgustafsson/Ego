namespace Ego;

public class MultithreadingManager : Node
{
    public List<ParallelBranch> Branches = new();

    public Task RunParallelTasks()
    {
        List<Task> parallels = new(); 
        foreach(var branch in Branches)
        {
            parallels.Add(Task.Run(branch.UpdateBranchInternal));
        }

        return Task.WhenAll(parallels);
    }

    public void UpdateSynchronous()
    {
        foreach(var branch in Branches)
        {
            branch.UpdateSynchronous();
        }
    }

    protected override void Update()
    {
        foreach(var branch in Branches)
        {
            branch.UpdateRoot();
        }
    }
}