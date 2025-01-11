using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace SourceGenerator;


[Generator]
public class SourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        //Add Marker classes
        context.RegisterPostInitializationOutput(ctx => ctx.AddSource("Ego." + SourceGenerationHelper.InspectAttributeName + ".generated.cs", SourceText.From(SourceGenerationHelper.InspectAttribute, Encoding.UTF8)));
        context.RegisterPostInitializationOutput(ctx => ctx.AddSource("Ego." + SourceGenerationHelper.NodeAttributeName + ".generated.cs", SourceText.From(SourceGenerationHelper.NodeAttribute, Encoding.UTF8)));
        
        //Not sure how to make this more incremental. Docs suggest against using IncrementalValuesProvider for ISymbol and ISyntaxNode. https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.cookbook.md#pipeline-model-design
        IncrementalValuesProvider<NodeToSerialize> nodeTypesToSerialize = context.SyntaxProvider.ForAttributeWithMetadataName(
            fullyQualifiedMetadataName: "Ego." + SourceGenerationHelper.NodeAttributeName,
            predicate: static (node, token) => true,
            transform: static (syntaxContext, token) =>
            {
                ITypeSymbol typeSymbol = (syntaxContext.TargetSymbol as ITypeSymbol)!;

                IEnumerable<ISymbol> members = typeSymbol.GetMembers().
                    Where(member => member.GetAttributes().Any(data => data.AttributeClass!.Name == SourceGenerationHelper.InspectAttributeName)).
                    Where(member => member is IPropertySymbol or IFieldSymbol);
                
                bool hasInspect = typeSymbol.GetMembers().OfType<IMethodSymbol>().Any(method => method.Name == "Inspect");
                
                NodeToSerialize node = new(
                    typeSymbol.Name, 
                    typeSymbol.ContainingNamespace.Name, 
                    new(members.Select(member =>
                    {
                        IFieldSymbol? fieldSymbol = member as IFieldSymbol;
                        IPropertySymbol? propertySymbol = member as IPropertySymbol;

                        string typeName = "";
                        if (fieldSymbol != null)
                            typeName = fieldSymbol.Type.Name;
                        if (propertySymbol != null)
                            typeName = propertySymbol.Type.Name;
                        
                        RefKind refKind = RefKind.None;
                        if (fieldSymbol != null)
                            refKind = fieldSymbol.RefKind;
                        if (propertySymbol != null)
                            refKind = propertySymbol.RefKind;

                        return new SerializedMember(typeName, member.Name, member.DeclaredAccessibility, refKind, true, propertySymbol != null);
                    }).ToArray()), 
                    typeSymbol.Name == "Node", 
                    typeSymbol.BaseType!.Name,
                    hasInspect);
 
                return node;
            });

        context.RegisterSourceOutput(nodeTypesToSerialize, static (productionContext, serialize) =>
        {
            productionContext.AddSource($"{serialize.Namespace}.{serialize.Name}.generated.cs", SourceText.From(serialize.CreateSourceText(), System.Text.Encoding.UTF8));
        });
    }
}

    