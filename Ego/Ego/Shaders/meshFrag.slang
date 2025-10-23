#include "sceneData.slang"

struct GLTFMaterialData
{
    float4 ColorFactors;
    float4 MetalRoughness;
    int TextureIndex;
};

struct InputData 
{
    float4x4 RenderMatrix;
    VertexBuffer* VertexBuffer;
    GLTFMaterialData* MaterialBuffer;
};

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

[[vk::push_constant]] 
InputData PushConstants; 

layout(set = 2, binding = 1) uniform Sampler2D colorTex;
layout(set = 2, binding = 2) uniform Sampler2D metalRoughTex;
[shader("pixel")]
float4 main(float3 inNormal, float3 inColor, float2 inUV) : SV_Target0
{
    float lightValue = max(dot(inNormal, sceneData.sunlightDirection.xyz), 0.1f);

    float3 color = inColor * textures[PushConstants.MaterialBuffer->TextureIndex].Sample(linearSampler, inUV).xyz;
    float3 ambient = color *  sceneData.ambientColor.xyz;

    return float4(color * lightValue *  sceneData.sunlightColor.w + ambient, 1.0f);
}
