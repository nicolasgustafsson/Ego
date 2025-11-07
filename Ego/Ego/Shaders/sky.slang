#include "sceneData.slang"

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
    output.OutVertex.Uv.x = v.Uv_x;
    output.OutVertex.Uv.y = v.Uv_y;  
    
    return output; 
}

[shader("pixel")]
float4 pixel(float3 inNormal, float3 inColor, float2 inUV) : SV_Target0
{
    return float4(1.0f, 1.0f, 0.0f, 1.0f); 
}
