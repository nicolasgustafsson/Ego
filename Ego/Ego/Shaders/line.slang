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
};

struct VertexStageOutput
{
    OutVertex    coarseVertex    : OutVertex;
    float4          sv_position     : SV_Position;
};

//TODO: Move this to a module
float4x4 inverse(float4x4 m) {
    float n11 = m[0][0], n12 = m[1][0], n13 = m[2][0], n14 = m[3][0];
    float n21 = m[0][1], n22 = m[1][1], n23 = m[2][1], n24 = m[3][1];
    float n31 = m[0][2], n32 = m[1][2], n33 = m[2][2], n34 = m[3][2];
    float n41 = m[0][3], n42 = m[1][3], n43 = m[2][3], n44 = m[3][3];

    float t11 = n23 * n34 * n42 - n24 * n33 * n42 + n24 * n32 * n43 - n22 * n34 * n43 - n23 * n32 * n44 + n22 * n33 * n44;
    float t12 = n14 * n33 * n42 - n13 * n34 * n42 - n14 * n32 * n43 + n12 * n34 * n43 + n13 * n32 * n44 - n12 * n33 * n44;
    float t13 = n13 * n24 * n42 - n14 * n23 * n42 + n14 * n22 * n43 - n12 * n24 * n43 - n13 * n22 * n44 + n12 * n23 * n44;
    float t14 = n14 * n23 * n32 - n13 * n24 * n32 - n14 * n22 * n33 + n12 * n24 * n33 + n13 * n22 * n34 - n12 * n23 * n34;

    float det = n11 * t11 + n21 * t12 + n31 * t13 + n41 * t14;
    float idet = 1.0f / det;

    float4x4 ret;

    ret[0][0] = t11 * idet;
    ret[0][1] = (n24 * n33 * n41 - n23 * n34 * n41 - n24 * n31 * n43 + n21 * n34 * n43 + n23 * n31 * n44 - n21 * n33 * n44) * idet;
    ret[0][2] = (n22 * n34 * n41 - n24 * n32 * n41 + n24 * n31 * n42 - n21 * n34 * n42 - n22 * n31 * n44 + n21 * n32 * n44) * idet;
    ret[0][3] = (n23 * n32 * n41 - n22 * n33 * n41 - n23 * n31 * n42 + n21 * n33 * n42 + n22 * n31 * n43 - n21 * n32 * n43) * idet;

    ret[1][0] = t12 * idet;
    ret[1][1] = (n13 * n34 * n41 - n14 * n33 * n41 + n14 * n31 * n43 - n11 * n34 * n43 - n13 * n31 * n44 + n11 * n33 * n44) * idet;
    ret[1][2] = (n14 * n32 * n41 - n12 * n34 * n41 - n14 * n31 * n42 + n11 * n34 * n42 + n12 * n31 * n44 - n11 * n32 * n44) * idet;
    ret[1][3] = (n12 * n33 * n41 - n13 * n32 * n41 + n13 * n31 * n42 - n11 * n33 * n42 - n12 * n31 * n43 + n11 * n32 * n43) * idet;

    ret[2][0] = t13 * idet;
    ret[2][1] = (n14 * n23 * n41 - n13 * n24 * n41 - n14 * n21 * n43 + n11 * n24 * n43 + n13 * n21 * n44 - n11 * n23 * n44) * idet;
    ret[2][2] = (n12 * n24 * n41 - n14 * n22 * n41 + n14 * n21 * n42 - n11 * n24 * n42 - n12 * n21 * n44 + n11 * n22 * n44) * idet;
    ret[2][3] = (n13 * n22 * n41 - n12 * n23 * n41 - n13 * n21 * n42 + n11 * n23 * n42 + n12 * n21 * n43 - n11 * n22 * n43) * idet;

    ret[3][0] = t14 * idet;
    ret[3][1] = (n13 * n24 * n31 - n14 * n23 * n31 + n14 * n21 * n33 - n11 * n24 * n33 - n13 * n21 * n34 + n11 * n23 * n34) * idet;
    ret[3][2] = (n14 * n22 * n31 - n12 * n24 * n31 - n14 * n21 * n32 + n11 * n24 * n32 + n12 * n21 * n34 - n11 * n22 * n34) * idet;
    ret[3][3] = (n12 * n23 * n31 - n13 * n22 * n31 + n13 * n21 * n32 - n11 * n23 * n32 - n12 * n21 * n33 + n11 * n22 * n33) * idet;

    return ret;
}

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
    
    float3 start = float3(PushConstants.render_matrix[0][0], PushConstants.render_matrix[0][1], PushConstants.render_matrix[0][2]);
    float3 end = float3(PushConstants.render_matrix[1][0], PushConstants.render_matrix[1][1], PushConstants.render_matrix[1][2]);
    float4 color = float4(PushConstants.render_matrix[3][0], PushConstants.render_matrix[3][1],PushConstants.render_matrix[3][2],PushConstants.render_matrix[3][3]);
    float verticalMovement = (position.y - 0.5);
    
    position.xyz = lerp(start, end, position.x);
    
    float3 lineDirection = (end - start);
    float3 cameraPosition = sceneData.cameraPosition;
    float3 normal = normalize(cross((position.xyz - cameraPosition), lineDirection));
    
    float requestedThickness = PushConstants.render_matrix[2][0];
    
    float3 positionInFrustum = position.xyz;
    float minimumThickness = CalculateSizeOfPixel(distance(position.xyz, cameraPosition))  * 1.4142f; //diagonal of a unit square
    position.xyz -= normal * verticalMovement * max(requestedThickness, minimumThickness);
    
    VertexStageOutput output;
    output.sv_position = mul(position, sceneData.viewProj);
    output.coarseVertex.Color = color;
    //output.coarseVertex.Color.a *= min((requestedThickness/minimumThickness), 1.0);
    
    return output;
}

[shader("pixel")]
float4 pixel(float4 aInColor) : SV_Target0
{
    return aInColor;
}
