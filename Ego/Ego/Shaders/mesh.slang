#include "sceneData.slang"

struct GLTFMaterialData
{
    float4 ColorFactors;
    float4 MetalRoughness;
    int TextureIndex;
} Uniform;

struct Vertex 
{
    float3 Position;
    float Uv_x;
    float3 Normal;
    float Uv_y;
    float4 Color;
};

struct VertexBuffer
{
    Vertex Vertices[];
}

struct OutVertex
{
    float3 Normal;
    float3 Color;
    float2 Uv;
};

struct VertexStageOutput
{
    OutVertex       OutVertex    : OutVertex;
    float4          Position     : SV_Position;
};

struct InputData 
{
    float4x4 RenderMatrix;
    VertexBuffer* VertexBuffer;
    GLTFMaterialData* MaterialBuffer; 
};

[[vk::push_constant]] 
InputData PushConstants; 

[shader("vertex")]
VertexStageOutput vertex(uint aVertexId : SV_VertexID)
{
    Vertex v = PushConstants.VertexBuffer->Vertices[aVertexId];

    VertexStageOutput output;
    
    float4 position = float4(v.Position, 1.0f);

    output.Position =  mul(mul(position, PushConstants.RenderMatrix), sceneData.viewProj);
    
    output.OutVertex.Normal = mul(float4(v.Normal, 0.f), PushConstants.RenderMatrix).xyz;
    output.OutVertex.Color = v.Color.xyz * PushConstants.MaterialBuffer.ColorFactors.xyz;
    output.OutVertex.Uv.x = v.Uv_x;
    output.OutVertex.Uv.y = v.Uv_y;  
    
    return output; 
}

[shader("pixel")]
float4 pixel(float3 inNormal, float3 inColor, float2 inUV) : SV_Target0
{
    float lightValue = max(dot(inNormal, sceneData.sunlightDirection.xyz), 0.1f);

    float3 color = inColor * textures[PushConstants.MaterialBuffer->TextureIndex].Sample(linearSampler, inUV).xyz;
    float3 ambient = color *  sceneData.ambientColor.xyz;

    return float4(color * lightValue *  sceneData.sunlightColor.w + ambient, 1.0f);
}
