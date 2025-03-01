﻿using Microsoft.CodeAnalysis;
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
        context.RegisterPostInitializationOutput(ctx => ctx.AddSource("Ego." + SourceGenerationHelper.AliasAttributeName + ".generated.cs", SourceText.From(SourceGenerationHelper.AliasAttribute, Encoding.UTF8)));
        context.RegisterPostInitializationOutput(ctx => ctx.AddSource("Ego." + SourceGenerationHelper.SerializeAttributeName + ".generated.cs", SourceText.From(SourceGenerationHelper.SerializeAttribute, Encoding.UTF8)));
        
        //Not sure how to make this more incremental. Docs suggest against using IncrementalValuesProvider for ISymbol and ISyntaxNode. https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.cookbook.md#pipeline-model-design
        IncrementalValuesProvider<NodeToSerialize> nodeTypesToSerialize = context.SyntaxProvider.ForAttributeWithMetadataName(
            fullyQualifiedMetadataName: "Ego." + SourceGenerationHelper.NodeAttributeName,
            predicate: static (node, token) => true,
            transform: static (syntaxContext, token) =>
            {
                ITypeSymbol typeSymbol = (syntaxContext.TargetSymbol as ITypeSymbol)!;

                IEnumerable<ISymbol> members = typeSymbol.GetMembers().
                    Where(member => member.GetAttributes().Any(data => data.AttributeClass!.Name == SourceGenerationHelper.InspectAttributeName || data.AttributeClass!.Name == SourceGenerationHelper.SerializeAttributeName)).
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
                        {
                            typeName = fieldSymbol.Type.ToDisplayString();
                        }
                        if (propertySymbol != null)
                        {
                            typeName = propertySymbol.Type.ToDisplayString();
                        }
                        
                        RefKind refKind = RefKind.None;
                        if (fieldSymbol != null)
                            refKind = fieldSymbol.RefKind;
                        if (propertySymbol != null)
                            refKind = propertySymbol.RefKind;

                        bool hasInspectAttribute = member.GetAttributes().Any(data => data.AttributeClass!.Name == SourceGenerationHelper.InspectAttributeName);

                        var aliases = member.GetAttributes().Where(attribute => attribute.AttributeClass!.Name == "AliasAttribute").ToList();

                        var aliasStrings = aliases.Select(alias => alias.ConstructorArguments.First().Value!.ToString());
                        
                        return new SerializedMember(typeName, member.Name, member.DeclaredAccessibility, refKind, hasInspectAttribute, propertySymbol != null, new EquatableArray<string>(aliasStrings.ToArray()), "");
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

    