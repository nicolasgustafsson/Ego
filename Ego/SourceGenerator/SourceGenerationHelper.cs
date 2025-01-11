using System.Linq.Expressions;
using Microsoft.CodeAnalysis;

namespace SourceGenerator;

public static class SourceGenerationHelper
{
    public const string InspectAttributeName = "InspectAttribute";
    public const string InspectAttribute = @"
namespace Ego
{
    [System.AttributeUsage(System.AttributeTargets.Property | AttributeTargets.Field)]
    internal class InspectAttribute : System.Attribute
    {
        
    }
}";
    
    public const string NodeAttributeName = "NodeAttribute";
    public const string NodeAttribute = @"
namespace Ego
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    internal class NodeAttribute : System.Attribute
    {
        
    }
}";

    
    public const string AliasAttributeName = "AliasAttribute";
    public const string AliasAttribute = @"
namespace Ego
{
    [System.AttributeUsage(System.AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    internal class AliasAttribute(string Alias)
        : System.Attribute
    {
        public string Alias = Alias;
    }
}";
}


public static class SourceGenerationExtensions
{
    
    public static string GetSourceText(this RefKind aRefKind)
    {
        switch(aRefKind)
        {
            case RefKind.Ref:
                return "ref";
                break;
            case RefKind.Out:
                return "out";
                break;
            case RefKind.In:
                return "in";
                break;
            case RefKind.None:
            default:
                return "";
        }
    }
    public static string GetSourceText(this Accessibility aAccessibility)
    {
        switch(aAccessibility)
        {
            case Accessibility.Private:
                return "private";
            case Accessibility.ProtectedAndInternal:
                return "protected internal";
            case Accessibility.Protected:
                return "protected";
            case Accessibility.Internal:
                return "internal";
            case Accessibility.ProtectedOrInternal:
                return "private protected";
            case Accessibility.Public:
                return "public";
            
            case Accessibility.NotApplicable:
            default:
                return "";
        }
    }
}