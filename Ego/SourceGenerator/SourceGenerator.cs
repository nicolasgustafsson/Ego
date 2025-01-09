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

                IEnumerable<IPropertySymbol> members = typeSymbol.GetMembers().Where(member => member.GetAttributes().Any(data => data.AttributeClass!.Name == SourceGenerationHelper.InspectAttributeName)).OfType<IPropertySymbol>();
                NodeToSerialize node = new(typeSymbol.Name, typeSymbol.ContainingNamespace.Name, new(members.Select(member => new SerializedMember(member.Type.Name, member.Name)).ToArray()));
 
                return node;
            });

        context.RegisterSourceOutput(nodeTypesToSerialize, static (productionContext, serialize) =>
        {
            productionContext.AddSource($"{serialize.Namespace}.{serialize.Name}.generated.cs", SourceText.From(serialize.CreateSourceText(), System.Text.Encoding.UTF8));
        });
    }
}

    