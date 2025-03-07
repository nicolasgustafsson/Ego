namespace Ego;

public interface IEgoContextProvider
{
    public TimeKeeper Time { get; }
    public Window Window { get;  }
    public Debug Debug{ get; }
    public RendererApi RendererApi { get; }
    public AssetManager AssetManager { get; }
    public TreeInspector TreeInspector { get; }
    public MultithreadingManager MultithreadingManager { get; }
    public PerformanceMonitor PerformanceMonitor { get;} 
    public NodeTypeDatabase NodeTypeDatabase { get;}
    public MaterialBuilder MaterialBuilder { get;}
}