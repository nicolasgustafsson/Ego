namespace Rendering;

public class DeletionQueue
{
    private List<Action> Deletors = new();

    public void Add(Action aAction) => Deletors.Add(aAction);
    
    public void Flush()
    {
        Deletors.Reverse();

        foreach (Action deletor in Deletors)
            deletor();

        Deletors.Clear();
    }
}