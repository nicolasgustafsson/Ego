using MessagePack;

namespace Editor;

[Node]
public partial class Editor : Node
{
    private ProjectEditor ProjectEditor = null!;
    public override void Start()
    {
        base.Start();
        
        MessagePackSerializer.DefaultOptions = MessagePack.Resolvers.ContractlessStandardResolver.Options;
        ProjectEditor = AddChild(new ProjectEditor());
    }
}
