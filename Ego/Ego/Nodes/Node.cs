namespace Ego;

public class Node : BaseNode, IEgoContext
{
    //TODO: These can be source generated? 
    public TimeKeeper Time => ((IEgoContext)Context).Time;
    public Window Window => ((IEgoContext)Context).Window;
    public Debug Debug => ((IEgoContext)Context).Debug;
    public RendererApi RendererApi => ((IEgoContext)Context).RendererApi;
    public AssetManager AssetManager => ((IEgoContext)Context).AssetManager;
    public TreeInspector TreeInspector => ((IEgoContext)Context).TreeInspector;
}