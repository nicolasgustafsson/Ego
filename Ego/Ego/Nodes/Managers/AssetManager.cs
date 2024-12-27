namespace Ego;

public class AssetManager : Node
{
    private Dictionary<string, Node> Assets = new();
    
    public T GetAsset<T>(string aPath) where T : Node, IAsset, new()
    {
        if (TryGetAsset<T>(aPath) is {} loadedAsset)
            return loadedAsset;

        return LoadAsset<T>(aPath);
    }
    
    private T? TryGetAsset<T>(string aPath) where T : Node
    {
        Assets.TryGetValue(aPath, out Node? aValue);

        return (T?)aValue;
    }
    
    private T LoadAsset<T>(string aPath) where T : Node, IAsset, new()
    {
        var child = AddChild(new T());

        child.LoadFrom(aPath);

        Assets.Add(aPath, child);

        return child;
    }
}