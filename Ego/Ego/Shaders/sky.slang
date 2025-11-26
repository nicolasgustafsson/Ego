#include "sceneData.slang"

struct Vertex 
{
    float3 Position;
    float Dummy;
};

struct VertexBuffer
{
    Vertex Vertices[];
}

struct OutVertex
{
    float2 Uv;
    float3 cameraDirection;
};

struct VertexStageOutput
{
    OutVertex       OutVertex    : OutVertex;
    float4          Position     : SV_Position;
};

struct SkyData
{
    float4 OverHorizonColor;
    float4 BelowHorizonColor;
    float4 ZenithColor;
    float HorizonLength;
    float ZenithLength;
} Uniform;

struct InputData 
{
    VertexBuffer* VertexBuffer;
    SkyData* MaterialBuffer; 
};

[[vk::push_constant]] 
InputData PushConstants; 

[shader("vertex")]
VertexStageOutput vertex(uint aVertexId : SV_VertexID)
{
    Vertex v = PushConstants.VertexBuffer->Vertices[aVertexId];

    VertexStageOutput output;
    
    float4 position = float4(v.Position, 1.0f);

    output.Position =  position;
    
    output.OutVertex.Uv.x = (position.x * 0.5f) + 0.5f;
    output.OutVertex.Uv.y = (position.y * 0.5f) + 0.5f;  
    
    position.z = 0;
    
    output.OutVertex.cameraDirection = normalize(mul(position, sceneData.inverseViewProj).xyz);
    
    return output; 
}

[shader("pixel")]
float4 pixel(float2 inUV, float3 inCameraDirection) : SV_Target0
{
    float4 belowToHorizon = lerp(PushConstants.MaterialBuffer.BelowHorizonColor, PushConstants.MaterialBuffer.OverHorizonColor, 
    smoothstep(-PushConstants.MaterialBuffer.HorizonLength * 0.5, PushConstants.MaterialBuffer.HorizonLength * 0.5, inCameraDirection.y));
    
    float4 horizonToZenith = lerp(belowToHorizon, PushConstants.MaterialBuffer.ZenithColor, 
    smoothstep(PushConstants.MaterialBuffer.HorizonLength * 0.5, PushConstants.MaterialBuffer.HorizonLength * 0.5 + PushConstants.MaterialBuffer.ZenithLength, inCameraDirection.y));
    
    return horizonToZenith;
}