namespace VulkanApi;

public interface IGpuImmediateSubmit
{
    public void ImmediateSubmit(Action<CommandBufferHandle> aAction);
}