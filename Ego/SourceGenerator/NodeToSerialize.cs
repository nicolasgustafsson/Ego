using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Text;
using Microsoft.CodeAnalysis;

namespace SourceGenerator;

public readonly record struct SerializedMember(string TypeName, string MemberName, Accessibility Accessibility, RefKind RefKind, bool ShouldInspect, bool IsProperty)
{
    public readonly string TypeName = TypeName;
    public readonly string MemberName = MemberName;
    public readonly Accessibility Accessibility = Accessibility;
    public readonly RefKind RefKind = RefKind;
    public readonly bool IsProperty = IsProperty;
    public bool IsField => !IsProperty;
    public readonly bool ShouldInspect = ShouldInspect;
        
    public string GetDeclaration()
    {
        return $"public {TypeName} {MemberName} {{ get {{ return field; }} set {{ field = value; }} }}";
    }
    public string GetPartialDeclaration()
    {
        if (IsField)
            return "";
        
        switch (RefKind)
        {
            case RefKind.None:
                return $"{Accessibility.GetSourceText()} partial {TypeName} {MemberName} {{ get {{ return field; }} set {{ field = value; }} }}";
            case RefKind.Ref:
                return $"{Accessibility.GetSourceText()} partial ref {TypeName} {MemberName} {{ get {{ return ref field; }}  }}";
            
            case RefKind.Out:
            case RefKind.In:
                throw new InvalidEnumArgumentException();
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public string GetPrepToNodeConverter()
    {
        return $"aNode.{MemberName} = {MemberName};";
    }
    
    public string GetNodeToPrepConverter()
    {
        return $"{MemberName} = aNode.{MemberName};";
    }
    
    public string GetInspectCall()
    {
        if (IsProperty)
            return $$"""
                 var _{{MemberName}} = {{MemberName}};
                 EmGui.Inspect("{{MemberName}}", ref _{{MemberName}});
                 {{MemberName}} = _{{MemberName}};
                 """; 
        
        return $"EmGui.Inspect(\"{MemberName}\", ref {MemberName});";
    }
}

public readonly record struct NodeToSerialize(string Name, string Namespace, EquatableArray<SerializedMember> Members, bool IsBaseNode, string BaseClass, bool HasInspectFunction)
{
    public readonly string Name = Name;
    public readonly string Namespace = Namespace;
    public readonly EquatableArray<SerializedMember> Members = Members;
    public readonly bool IsBaseNode = IsBaseNode;
    public readonly bool HasInspectFunction = HasInspectFunction;
    public readonly string BaseClass = BaseClass;
    public readonly string ConditionalNew = IsBaseNode ? "" : "new";
    public readonly string ConditionalOverride = IsBaseNode ? "virtual" : "override";
    public readonly string ConditionalInherit = IsBaseNode ? "" : $" : {BaseClass}.Serialization";
    public readonly string ConditionalInspectCall = HasInspectFunction ? $"Inspect();" : "DefaultInspect()";
    public bool ShouldEarlyOutInspect => !HasInspectFunction && !Members.Any(property => property.ShouldInspect);
    public string ConditionalEarlyOutInspect => ShouldEarlyOutInspect ? "return;" : "";
    public string ConditionalBaseCall(string aCall) =>  IsBaseNode ? "" : $"base.{aCall}";
    
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
    
    private string GetNodeToPrepConversionFunctions()
    {
        return 
            $$"""
             public {{ConditionalOverride}} void NodeToPrep(Node aBaseNode)
             {
                {{Name}} aNode = (aBaseNode as {{Name}})!;
                {{ConditionalBaseCall("NodeToPrep(aNode);")}}
                {{GetNodeToPrepConverters()}};
             }
             
             public {{ConditionalOverride}} void PrepToNode(Node aBaseNode)
             {
                {{Name}} aNode = (aBaseNode as {{Name}})!;
                {{ConditionalBaseCall("PrepToNode(aNode);")}}
                {{GetPrepToNodeConverters()}};
             }
             """;
    }
    
    private string GetSerializationCode()
    {
        return 
$$"""

{{GetNodeToPrepConversionFunctions()}}

public static SerializedNode Serialize({{Name}} aNode)
{
    Serialization prep = new();
    
    prep.NodeToPrep(aNode);
    
    return new(typeof({{Name}}).Name, MessagePackSerializer.Serialize<Serialization>(prep));
}

public {{ConditionalNew}} static {{Name}} Deserialize(SerializedNode aNode)
{
    Serialization prep = MessagePackSerializer.Deserialize<Serialization>(aNode.Data);

    {{Name}} node = new();

    prep.PrepToNode(node);
    
    return node;
}
                 
""";
    }
    
    private string GetInspectionCode()
    {
        return
            $$"""
              
              public {{ConditionalOverride}} void GeneratedInspect()
              {
                {{ConditionalBaseCall("GeneratedInspect()")}};
                
                {{ConditionalEarlyOutInspect}}
                
                if (ImGui.CollapsingHeader("{{Name}}", ImGuiTreeNodeFlags.DefaultOpen))
                {
                    {{ConditionalInspectCall}};
                }
              }
              
              public {{ConditionalNew}} void DefaultInspect()
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
using Ego;
using ImGuiNET;
#pragma warning disable
namespace {{Namespace}};
public partial class {{Name}}
{

    {{GetPartialMemberDeclarations()}}
    
    {{GetInspectionCode()}}
    
 
    public {{ConditionalNew}} static {{Name}} Deserialize(SerializedNode aNode)
    {
        return Serialization.Deserialize(aNode) as {{Name}};
    }

    public {{ConditionalOverride}} SerializedNode Serialize()
    {
        return Serialization.Serialize(this);
    }
 
    [MessagePackObject(keyAsPropertyName: true)]
    public {{ConditionalNew}} partial class Serialization {{ConditionalInherit}}
    {
        {{GetMemberDeclarations()}}
    
        {{GetSerializationCode()}}
    }
}
""";
        
    }
}
