#include "input_structures.slang"

[shader("pixel")]
float4 main(float3 inNormal, float3 inColor, float2 inUV) : SV_Target0
{
    float lightValue = max(dot(inNormal, sceneData.sunlightDirection.xyz), 0.1f);

    float3 color = inColor * colorTex.Sample(inUV).xyz;
    float3 ambient = color *  sceneData.ambientColor.xyz;

    return float4(color * lightValue *  sceneData.sunlightColor.w + ambient, 1.0f);
}
