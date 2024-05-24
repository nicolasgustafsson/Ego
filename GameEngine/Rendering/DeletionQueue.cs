using Graphics;

namespace Rendering;

public class DeletionQueue
{
    private class ActionDeletor(Action deletor)
        : IGpuDestroyable
    {
        public Action Deletor = deletor;

        public void Destroy()
        {
            Deletor();
        }
    }
    private List<IGpuDestroyable> Deletors = new();
    
    public void Add(IGpuDestroyable aDestroyable) => Deletors.Add(aDestroyable);
    public void Add<T>(IEnumerable<T> aDestroyables) where T : IGpuDestroyable => Deletors.AddRange(aDestroyables.Select(destroyable => destroyable as IGpuDestroyable));
    public void Add(Action aAction) => Deletors.Add(new ActionDeletor(aAction));
    
    public void RunDeletor(IGpuDestroyable aDestroyable)
    {
        aDestroyable.Destroy();

        Deletors.Remove(aDestroyable);
    }
    
    public void Flush()
    {
        Deletors.Reverse();

        foreach (var deletor in Deletors)
        {
            //things may have already been destroyed - there should be a better solution for this(DAG maybe), but for now we just handle it like this.
            try
            {
                deletor.Destroy();
            }
            catch (AccessViolationException e)
            {
            }
        }

        Deletors.Clear();
    }
}