using System.Reflection;

namespace Ego;

[Node(DisableEditorAdd = true)]
public partial class NodeTypeDatabase : Node
{
    public Dictionary<string, Type> NodeTypes = new();
    
    public NodeTypeDatabase()
    {
        AddNode(typeof(Node));

        Build(typeof(Node).Assembly);
    }
    
    public void Build(Assembly aAssembly)
    {
        Log.Information("Building Node Type Database of assembly {aAssembly}", aAssembly);
        Type NodeType = typeof(Node);

        var types = aAssembly.GetTypes().Where(type => type.IsSubclassOf(NodeType));
        
        foreach(Type type in types)
        {
            AddNode(type);
        }
        
        Log.Information("Finished adding {aAssembly} to Node Type Database!", aAssembly);
    }

    private void AddNode(Type type)
    {
        NodeTypes[type.Name] = type;

        Log.Information("NodeTypeDatabase: Added Node {type.Name}", type.Name);
    }
}