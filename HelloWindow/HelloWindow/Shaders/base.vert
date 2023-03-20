#version 400 core

layout(location = 0) in vec3 aPosition;  
layout(location = 1) in vec3 aColor;
layout(location = 2) in vec2 aUv;

out vec3 ourColor; // variable name to output a color to the fragment shader
out vec2 ourUv; // variable name to output a color to the fragment shader

void main(void)
{
    gl_Position = vec4(aPosition, 1.0); 
	ourColor = aColor; // Sends interpolated colors to the fragment stage
	ourUv = aUv;
}
