#include "input_structures.slang"


struct Vertex 
{
    float3 position;
    float test;
};


struct VertexBuffer
{
    Vertex vertices[];
};

struct InputData 
{
    float4x4 render_matrix;
    VertexBuffer* VertexBuffer;
};

[[vk::push_constant]] 
InputData PushConstants; 

struct outputThing
{
    float3 Color;
};

struct VertexStageOutput
{
    outputThing    coarseVertex    : outputThing;
    float4          sv_position     : SV_Position;
};

[shader("vertex")]
VertexStageOutput vertex(uint vertexID : SV_VertexID)
{
    //load vertex data from device address
    Vertex v = PushConstants.VertexBuffer.vertices[vertexID];
    
    float4 position = float4(v.position, 1.0f);
    
    float3 start = float3(PushConstants.render_matrix[0][0], PushConstants.render_matrix[0][1], PushConstants.render_matrix[0][2]);
    float3 end = float3(PushConstants.render_matrix[1][0], PushConstants.render_matrix[1][1], PushConstants.render_matrix[1][2]);
    float thickness = PushConstants.render_matrix[2][0];
    
    float verticalMovement = (position.y - 0.5);
    position.xyz = lerp(start, end, position.x);
    
    float3 normal = normalize(cross(end - start, (mul(float4(1, 0, 0, 1), sceneData.view)).xyz));
    
    position.xyz += normal * verticalMovement * thickness;
    VertexStageOutput output;
    output.sv_position = mul(position, sceneData.viewproj);
    output.coarseVertex.Color = float3(1.0f, 1.0f, 1.0f);
    
    return output;
}


[shader("pixel")]
float4 pixel(float3 aInColor) : SV_Target0
{
    return float4(aInColor, 1.0f);
}
