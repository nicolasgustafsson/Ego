namespace ExampleProject;

[MessagePack.MessagePackObject(true)]
public class SubObject
{
    public int Integer = 10;
    public string String = "Yep";
    public string OtherSTring = "Yeppers";
    public string NewMember = "Yyippie";
}

[Node]
public partial class Test : Node3D
{
    [Inspect]
    List<List<List<List<SubObject>>>> obj = new();

    [Inspect] int hello;
}
