using System.Reflection;
using MessagePack;

namespace Ego;

public class Scene : Node, IAsset
{
    private SerializedNode SerializedNode;
    
    public void LoadFrom(string aPath)
    {
    }
    
    public void SaveTree(Node aSceneRoot)
    {
        SerializedNode = aSceneRoot.Serialize();
    }
    
    public Node SpawnTree()
    {
        return SerializedNode.Deserialize(NodeTypeDatabase);
    }
}