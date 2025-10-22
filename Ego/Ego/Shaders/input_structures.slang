struct SceneData
{
    float4x4 view;
    float4x4 proj;
    float4x4 viewproj;
    float4 ambientColor;
    float4 sunlightDirection; //w for sun power
    float4 sunlightColor;
};

struct GLTFMaterialData
{
    float4 colorFactors;
    float4 metal_rough_factors;
};

[[vk::binding(0, 0)]]
ConstantBuffer<SceneData> sceneData;

[[vk::binding(0, 1)]]
ConstantBuffer<GLTFMaterialData> materialData;

layout(set = 1, binding = 1) uniform Sampler2D colorTex;
layout(set = 1, binding = 2) uniform Sampler2D metalRoughTex;
