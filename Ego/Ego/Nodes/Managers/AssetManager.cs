namespace Ego;

public class AssetManager : Node
{
    private Dictionary<string, BaseNode> Assets = new();
    
    public T GetAsset<T>(string aPath) where T : BaseNode, IAsset, new()
    {
        if (TryGetAsset<T>(aPath) is {} loadedAsset)
            return loadedAsset;

        return LoadAsset<T>(aPath);
    }
    
    private T? TryGetAsset<T>(string aPath) where T : BaseNode
    {
        Assets.TryGetValue(aPath, out BaseNode? aValue);

        return (T?)aValue;
    }
    
    private T LoadAsset<T>(string aPath) where T : BaseNode, IAsset, new()
    {
        var child = AddChild(new T());

        child.LoadFrom(aPath);

        Assets.Add(aPath, child);

        return child;
    }
}