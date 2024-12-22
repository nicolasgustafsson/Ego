namespace Ego;

public interface IEngineContext
{
    public TimeKeeper Time { get; }
    public Window Window { get;  }
    public Debug Debug{ get; }
    public RendererApi RendererApi { get; }
    public AssetManager AssetManager { get; }
    public TreeInspector TreeInspector { get; }
}