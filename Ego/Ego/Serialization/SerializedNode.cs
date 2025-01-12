using System.Reflection;
using MessagePack;

namespace Ego;

[MessagePackObject(true)]
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