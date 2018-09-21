#version 150 core

in vec4 a_Pos;
in vec2 a_Uv;
in vec3 a_Translation;
in vec3 a_Rotation;
in vec3 a_Scale;

out vec2 v_Uv;

void main() {
    v_Uv = a_Uv;
    mat4 tl = mat4(1);
    tl[0][3] = a_Translation.x;
    tl[1][3] = a_Translation.y;
    tl[2][3] = a_Translation.z;
    mat4 sc = mat4(1);
    sc[0][0] = a_Scale.x;
    sc[1][1] = a_Scale.y;
    sc[2][2] = a_Scale.z;
    mat4 rx = mat4(1);
    rx[1][1] = cos(a_Rotation.x);
    rx[1][2] = -sin(a_Rotation.x);
    rx[2][2] = cos(a_Rotation.x);
    rx[2][1] = sin(a_Rotation.x);
    mat4 ry = mat4(1);
    ry[0][0] = cos(a_Rotation.y);
    ry[0][2] = -sin(a_Rotation.y);
    ry[2][2] = cos(a_Rotation.y);
    ry[2][0] = sin(a_Rotation.y);
    mat4 rz = mat4(1);
    rz[0][0] = cos(a_Rotation.z);
    rz[0][1] = -sin(a_Rotation.z);
    rz[1][1] = cos(a_Rotation.z);
    rz[1][0] = sin(a_Rotation.z);

    mat4 rt = rx * ry * rz;
    mat4 transform = tl * rt * sc;

    mat4 proj = mat4(1);

    proj[0][0] = 18/16 * 1/tan(16.0/18.0);
    proj[1][1] = 1/tan(16.0/18.0);
    proj[2][2] = 100.0/(99.0);
    proj[3][2] = -100.0/(99.0);
    proj[2][3] = 1;
    proj[3][3] = 0;

    transform = transform * proj;
    gl_Position = a_Pos * transform;
}
