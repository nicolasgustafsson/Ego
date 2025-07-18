namespace Ego;

[Node(AllowAddingToScene = false)]
public partial class AssetManager : Node
{
    private Dictionary<string, Node> Assets = new();
    
    public T GetAsset<T>(string aPath) where T : Node, IFileAsset, new()
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
    
    private T LoadAsset<T>(string aPath) where T : Node, IFileAsset, new()
    {
        T child = AddChild(new T());

        child.LoadFrom(aPath);

        Assets.Add(aPath, child);

        return child;
    }
}