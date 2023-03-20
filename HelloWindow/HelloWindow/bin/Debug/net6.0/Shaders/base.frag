#version 400 core

out vec4 outputColor;

in vec3 ourColor;
in vec2 ourUv;

uniform sampler2D tex0;

void main()
{
    // Send fragment colors to the next render stages (and finally the screen)
    outputColor = texture(tex0, ourUv);
}
