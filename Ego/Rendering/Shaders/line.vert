#version 450
#extension GL_EXT_buffer_reference : require
#extension GL_GOOGLE_include_directive : require

#include "input_structures.glsl"

layout (location = 0) out vec3 outColor;

struct Vertex 
{
    vec3 position;
    float test;
};

layout(buffer_reference, std430) readonly buffer VertexBuffer
{
    Vertex vertices[];
};

layout( push_constant ) uniform constants
{
    mat4 render_matrix;
    VertexBuffer vertexBuffer;
} PushConstants;

void main()
{
    //load vertex data from device address
    Vertex v = PushConstants.vertexBuffer.vertices[gl_VertexIndex];
    
    vec4 position = vec4(v.position, 1.0f);
    
    vec3 start = vec3(PushConstants.render_matrix[0][0], PushConstants.render_matrix[0][1], PushConstants.render_matrix[0][2]);
    vec3 end = vec3(PushConstants.render_matrix[1][0], PushConstants.render_matrix[1][1], PushConstants.render_matrix[1][2]);
    float thickness = PushConstants.render_matrix[2][0];
    
    float verticalMovement = (position.y - 0.5);
    position.xyz = mix(start, end, position.x);
    
    vec3 normal = normalize(cross(end - start, (sceneData.view * vec4(1, 0, 0, 1)).xyz));
    
    position.xyz += normal * verticalMovement * thickness;
    
    gl_Position = sceneData.viewproj * position;
    
    //PushConstants.render_matrix;


    //output data
    outColor = vec3(1.0f, 1.0f, 1.0f);
    
    //gl_Position = vec4(end, 1.0f);
}
