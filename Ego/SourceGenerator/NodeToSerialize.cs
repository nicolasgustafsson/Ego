using System.Text;

namespace SourceGenerator;

/*public readonly record struct EnumToGenerate(string Name, string[] Values)
{
    public readonly string Name = Name;
    public readonly string[] Values = Values;
}*/

public readonly record struct SerializedMember(string TypeName, string MemberName)
{
    public readonly string TypeName = TypeName;
    public readonly string MemberName = MemberName;
    
    public string GetDeclaration()
    {
        return $"public {TypeName} {MemberName} {{ get {{ return field; }} set {{ field = value; }} }}";
    }
    public string GetPartialDeclaration()
    {
        return $"public partial {TypeName} {MemberName} {{ get {{ return field; }} set {{ field = value; }} }}";
    }

    public string GetPrepToNodeConverter()
    {
        return $"node.{MemberName} = prep.{MemberName};";
    }
    
    public string GetNodeToPrepConverter()
    {
        return $"prep.{MemberName} = aNode.{MemberName};";
    }
    
    public string GetInspectCall()
    {
        return $"{MemberName} = EmGui.Inspect(\"{MemberName}\", {MemberName});";
    }
}
    
public readonly record struct NodeToSerialize(string Name, string Namespace, EquatableArray<SerializedMember> Members)
{
    public readonly string Name = Name;
    public readonly string Namespace = Namespace;
    public readonly EquatableArray<SerializedMember> Members = Members;
    
    private string GetMemberDeclarations()
    {
        StringBuilder text = new();
        foreach(SerializedMember member in Members)
        {
            text.Append(member.GetDeclaration());
            text.AppendLine();
        }
        return text.ToString();
    }

    private string GetPartialMemberDeclarations()
    {
        StringBuilder text = new();
        foreach (SerializedMember member in Members)
        {
            text.Append(member.GetPartialDeclaration());
            text.AppendLine();
        }
        return text.ToString();
    }
    
    private string GetNodeToPrepConverters()
    {
        StringBuilder text = new();
        foreach (SerializedMember member in Members)
        {
            text.Append(member.GetNodeToPrepConverter());
            text.AppendLine();
        }
        return text.ToString();
    }
    
    private string GetPrepToNodeConverters()
    {
        StringBuilder text = new();
        foreach (SerializedMember member in Members)
        {
            text.Append(member.GetPrepToNodeConverter());
            text.AppendLine();
        }
        return text.ToString();
    }
    private string GetInspectCalls()
    {
        StringBuilder text = new();
        foreach (SerializedMember member in Members)
        {
            text.Append(member.GetInspectCall());
            text.AppendLine();
        }
        return text.ToString();
    }
    
    private string GetSerializationCode()
    {
        return 
$$"""

public static byte[] Serialize({{Name}} aNode)
{
    Serialization prep = new();
    
    {{GetNodeToPrepConverters()}};
    
    return MessagePackSerializer.Serialize<Serialization>(prep);
}

public static {{Name}} Deserialize(byte[] aData)
{
    Serialization prep = MessagePackSerializer.Deserialize<Serialization>(aData);

    {{Name}} node = new();

    {{GetPrepToNodeConverters()}};

    return node;
}
                 
""";
    }
    
    private string GetInspectionCode()
    {
        return
            $$"""
              public void ShowDefaultInspector()
              {
                {{GetInspectCalls()}}
              }
              """;
    }

    public string CreateSourceText()
    {
        return 
            $$"""
using MessagePack;
namespace {{Namespace}};
public partial class {{Name}}
{

    {{GetPartialMemberDeclarations()}}
    
    {{GetInspectionCode()}}
    
    [MessagePackObject(keyAsPropertyName: true)]
    public partial class Serialization
    {
        {{GetMemberDeclarations()}}
    
        {{GetSerializationCode()}}
    }
}
""";
        
    }
}
