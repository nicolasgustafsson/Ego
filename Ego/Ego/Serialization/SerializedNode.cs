using System.Reflection;

namespace Ego;

public readonly record struct SerializedNode(string NodeTypeHash, byte[] Data)
{
    public readonly string NodeTypeHash = NodeTypeHash;
    public readonly byte[] Data = Data;
    
    public Node Deserialize(NodeTypeDatabase aDatabase)
    {
        var type = aDatabase.NodeTypes[NodeTypeHash];

        
        return (type!.GetMethod("Deserialize")!.Invoke(null, [this]) as Node)!;
    }
}