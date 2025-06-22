using System.Reflection;
using MessagePack;

namespace Ego;

[Node(AllowAddingToScene = false)]
public partial class Scene : Node, IAsset
{
    private SceneBranchNode? SerializedTree;

    public override void Start()
    {
        base.Start();
        Log.Info($"Started Scene!", this);
    }

    public void LoadFrom(string aPath)
    {
    }
    
    public void SerializeTree(Node aNode)
    {
        SerializedTree = aNode.SerializeTree();
    }
    
    public Node DeserializeTree()
    {
        return DeserializeTree(SerializedTree!, false);
    }
}