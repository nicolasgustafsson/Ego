namespace Ego;

public class Node : BaseNode, IEngineContext
{
    //TODO: These can be source generated? 
    public TimeKeeper Time => ((EgoContext)Context).Time;
    public Window Window => ((EgoContext)Context).Window;
    public Debug Debug => ((EgoContext)Context).Debug;
    public RendererApi RendererApi => ((EgoContext)Context).RendererApi;
    public AssetManager AssetManager => ((EgoContext)Context).AssetManager;
    public TreeInspector TreeInspector => ((EgoContext)Context).TreeInspector;
}