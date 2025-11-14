#include "sceneData.slang"

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

struct OutVertex
{
    float4 Color;
    float2 UV;
};

struct VertexStageOutput
{
    OutVertex    coarseVertex    : OutVertex;
    float4          sv_position     : SV_Position;
};

float CalculateSizeOfPixel(float aDistance)
{
    //pixel size = 2 * tan ( horiz.fov /2 ) * distance / image width in pixels.
    return 2.0 * (tan(sceneData.fieldOfView * 2) * (aDistance / sceneData.resolution.x));
}

[shader("vertex")]
VertexStageOutput vertex(uint vertexID : SV_VertexID)
{
    Vertex v = PushConstants.VertexBuffer.vertices[vertexID];
    
    float4 position = float4(v.position, 1.0f);
    float2 uv = position.xy;
    
    float3 start = float3(PushConstants.render_matrix[0][0], PushConstants.render_matrix[0][1], PushConstants.render_matrix[0][2]);
    //float3 end = float3(PushConstants.render_matrix[1][0], PushConstants.render_matrix[1][1], PushConstants.render_matrix[1][2]);
    float4 color = float4(PushConstants.render_matrix[3][0], PushConstants.render_matrix[3][1],PushConstants.render_matrix[3][2],PushConstants.render_matrix[3][3]);
    float verticalMovement = (position.y) - 0.5;
    float horizontalMovement = (position.x) - 0.5;
    
    position.xyz = start;
    
    //position.xyz = lerp(start, end, position.x);
    
    //float3 lineDirection = (end - start);
    float3 cameraPosition = sceneData.cameraPosition;
    float3 cameraRight = float3(sceneData.view[0][0], sceneData.view[1][0], sceneData.view[2][0]);
    float3 cameraUp = float3(sceneData.view[0][1], sceneData.view[1][1], sceneData.view[2][1]);
    
    //float3 normal = normalize(cross((position.xyz - cameraPosition), lineDirection));
    
    float requestedThickness = PushConstants.render_matrix[2][0];
    
    float minimumThickness = CalculateSizeOfPixel(distance(position.xyz, cameraPosition)) * (2.0f);
    //position.xyz -= normal * verticalMovement * max(requestedThickness, minimumThickness);
    position.xyz += cameraUp * verticalMovement * max(requestedThickness, minimumThickness);
    position.xyz += cameraRight * horizontalMovement * max(requestedThickness, minimumThickness);
    
    VertexStageOutput output;
    output.sv_position = mul(position, sceneData.viewProj);
    output.coarseVertex.Color = color;
    output.coarseVertex.Color.a *= max(0.0, min((requestedThickness/minimumThickness), 1.0));
    output.coarseVertex.UV = uv;
    
    return output;
}

[shader("pixel")]
float4 pixel(float4 aInColor, float2 aUV) : SV_Target0
{
    float inCircle = smoothstep( 0.502, 0.498, distance(aUV, float2(0.5, 0.5)));
    
    aInColor.w *= inCircle;

    return aInColor;
}
