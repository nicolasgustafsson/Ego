using Rendering;

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

        parallels.Add(Task.Run(UpdateGpuTransfer));

        var task = Task.WhenAll(parallels);
        return task;
    }
    
    private void UpdateGpuTransfer()
    {
        Thread.CurrentThread.Name = "Gpu Transfer";

        EgoSynchronizationContext.ExecuteGpuTransferContinuations(RendererApi.Renderer.DataTransferer);
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