namespace Ego;

public class MultithreadingManager : Node
{
    public List<ParallelBranch> Branches = new();

    public void HandleMessages()
    {
        foreach(var branch in Branches)
        {
            branch.HandleMessages();
        }
    }
    
    public Task RunParallelTasks()
    {
        List<Task> parallels = new(); 
        foreach(var updateFunc in Branches)
        {
            parallels.Add(Task.Run(updateFunc.UpdateBranch));
        }

        return Task.WhenAll(parallels);
    }
}