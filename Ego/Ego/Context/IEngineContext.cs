namespace Ego;

public interface IEngineContext
{
    public TimeKeeper Time { get; set; }
    public Window Window { get; set; }
    public Debug Debug{ get; set; }
    public RendererApi RendererApi { get; set; }
    public AssetManager AssetManager { get; set; }
    public TreeInspector TreeInspector { get; set; }
}