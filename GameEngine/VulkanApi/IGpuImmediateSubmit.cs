namespace Graphics;

public interface IGpuImmediateSubmit
{
    public void ImmediateSubmit(Action<CommandBuffer> aAction);
}