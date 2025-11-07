struct SceneData
{
    float4x4 view;
    float4x4 proj;
    float4x4 viewProj;
    float4x4 inverseView;
    float4x4 inverseViewProj;
    float4 ambientColor;
    float4 sunlightDirection; //w for sun power
    float4 sunlightColor;
    float fieldOfView;
    float time;
};

[[vk::binding(0, 0)]]
ConstantBuffer<SceneData> sceneData;

[[vk::binding(0, 1)]] 
Texture2D textures[];

[[vk::binding(1, 1)]] 
SamplerState linearSampler;
