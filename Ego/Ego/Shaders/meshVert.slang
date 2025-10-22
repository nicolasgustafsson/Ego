#include "input_structures.slang"

struct Vertex 
{

    float3 position;
    float uv_x;
    float3 normal;
    float uv_y;
    float4 color;
};

struct outputThing
{
    float3 Normal;
    float3 Color;
    float2 UV;
};

struct VertexStageOutput
{
    outputThing    coarseVertex    : outputThing;
    float4          sv_position     : SV_Position;
};

struct VertexBuffer
{
    Vertex vertices[];
}

struct InputData 
{
    float4x4 render_matrix;
    VertexBuffer* VertexBuffer;
};

[[vk::push_constant]] 
InputData PushConstants; 

[shader("vertex")]
VertexStageOutput main(uint vertexID : SV_VertexID)
{
    Vertex v = PushConstants.VertexBuffer->vertices[vertexID];

    VertexStageOutput output;
    
    float4 position = float4(v.position, 1.0f);

    output.sv_position =  mul(mul(position, PushConstants.render_matrix), sceneData.viewproj);
    

    output.coarseVertex.Normal = mul(float4(v.normal, 0.f), PushConstants.render_matrix).xyz;
    output.coarseVertex.Color = v.color.xyz * materialData.colorFactors.xyz;
    output.coarseVertex.UV.x = v.uv_x;
    output.coarseVertex.UV.y = v.uv_y;
    
    return output; 
}
