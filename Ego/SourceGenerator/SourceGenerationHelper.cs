namespace SourceGenerator;

public static class SourceGenerationHelper
{
    public const string InspectAttributeName = "InspectAttribute";
    public const string InspectAttribute = @"
namespace Ego
{
    [System.AttributeUsage(System.AttributeTargets.Property/* | AttributeTargets.Field*/, Inherited = true)]
    internal class InspectAttribute : System.Attribute
    {
        
    }
}";
    
    public const string NodeAttributeName = "NodeAttribute";
    public const string NodeAttribute = @"
namespace Ego
{
    [System.AttributeUsage(System.AttributeTargets.Class/* | AttributeTargets.Field*/, Inherited = true)]
    internal class NodeAttribute : System.Attribute
    {
        
    }
}";
}