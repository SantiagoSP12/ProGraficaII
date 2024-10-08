#version 330 core
layout (location = 0) in vec3 aPos; 
layout (location = 1) in vec3 aColor;
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;


out vec3 ourColor; // output a color to the fragment shader

void main()
{
    gl_Position = vec4(aPos, 1.0) * model * view * projection;
    ourColor = aColor;
}    