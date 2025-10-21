#version 450

//shader input
layout (location = 0) in vec3 inColor;

//output write
layout (location = 0) out vec4 outFragColor;


void main()
{
    outFragColor.rgb = inColor;
    outFragColor.a = 1.f;
}
