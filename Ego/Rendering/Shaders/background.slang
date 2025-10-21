

layout (set = 0, binding = 0) uniform RWTexture2D<float4> image;

struct Constants
{
    float4 data1;
    float4 data2;
    float4 data3;
    float4 data4;
};

[vk::push_constant]
uniform Constants constants;

[shader("compute")]
[numthreads(16, 16, 1)]
void main(uint3 dispatchThreadID : SV_DispatchThreadID)
{

    int2 texelCoord = int2(dispatchThreadID.xy);
    int2 size = int2(0, 0);
    image.GetDimensions(size.x, size.y);
    
    if (texelCoord.x > size.x || texelCoord.y > size.y)
            return;
    
    float4 color = float4(0.0, 0.0, 0.0, 1.0);
    
    if (dispatchThreadID.x != 0 && dispatchThreadID.y != 0)
    {
        color.x = float(texelCoord.x) / (size.x);
        color.y = float(texelCoord.y) / (size.y);
        color.z = constants.data1.x;
    }
    
    image[texelCoord] = color;
}
