namespace Ego;

public interface IEgoContextProvider
{
    public TimeKeeper Time { get; }
    public Window Window { get;  }
    public Debug Debug{ get; }
    public ParallelBranch<RendererApi> RendererApi { get; }
    public AssetManager AssetManager { get; }
    public TreeInspector TreeInspector { get; }
    public MultithreadingManager MultithreadingManager { get; }
}