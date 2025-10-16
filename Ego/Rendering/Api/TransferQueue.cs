namespace VulkanApi;

public class TransferQueue : Queue
{
    public TransferQueue() : base(GpuInstance.TransferFamily) { }
}