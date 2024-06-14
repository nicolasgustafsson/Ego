#version 450
#extension GL_EXT_buffer_reference : require

layout (location = 0) out vec4 outColor;
layout (location = 1) out vec2 outUV;

struct Vertex 
{
    vec2 position;
    float uv_x;
    float uv_y;
    uint color;
};

layout(buffer_reference, std430) readonly buffer VertexBuffer
{
    Vertex vertices[];
};

layout( push_constant ) uniform constants
{
    vec2 scale;
    vec2 translate;
    VertexBuffer vertexBuffer;
} PushConstants;

void main()
{
    //load vertex data from device adress
    Vertex v = PushConstants.vertexBuffer.vertices[gl_VertexIndex];

    //output data
    gl_Position = vec4(v.position, 0, 1);
    outColor = vec4(1.f, 1.f, 1.f, 1.f);//v.color;
    outUV.x = v.uv_x;
    outUV.y = v.uv_y;
}
