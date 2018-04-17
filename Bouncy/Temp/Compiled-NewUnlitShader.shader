// Compiled shader for Android, uncompressed size: 33.0KB

// Skipping shader variants that would not be included into build of current scene.

Shader "Custom/SimpleGrabPassBlur" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _BumpAmt ("Distortion", Range(0,128)) = 10
 _MainTex ("Tint Color (RGB)", 2D) = "white" { }
 _BumpMap ("Normalmap", 2D) = "bump" { }
 _Size ("Size", Range(0,20)) = 1
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Opaque" }
 GrabPass {
  Tags { "LIGHTMODE"="Always" }
 }


 // Stats for Vertex shader:
 //        gles : 40 math, 9 texture
 Pass {
  Tags { "LIGHTMODE"="Always" "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Opaque" }
  GpuProgramID 33989
Program "vp" {
SubProgram "gles " {
// Stats: 40 math, 9 textures
"!!GLES
#version 100

#ifdef VERTEX
attribute vec4 _glesVertex;
uniform highp mat4 glstate_matrix_mvp;
varying highp vec4 xlv_TEXCOORD0;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_1 = (glstate_matrix_mvp * _glesVertex);
  tmpvar_2.xy = ((tmpvar_1.xy + tmpvar_1.w) * 0.5);
  tmpvar_2.zw = tmpvar_1.zw;
  gl_Position = tmpvar_1;
  xlv_TEXCOORD0 = tmpvar_2;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _GrabTexture;
uniform highp vec4 _GrabTexture_TexelSize;
uniform highp float _Size;
varying highp vec4 xlv_TEXCOORD0;
void main ()
{
  mediump vec4 sum_1;
  highp vec4 tmpvar_2;
  tmpvar_2.x = (xlv_TEXCOORD0.x + ((_GrabTexture_TexelSize.x * -4.0) * _Size));
  tmpvar_2.yzw = xlv_TEXCOORD0.yzw;
  lowp vec4 tmpvar_3;
  tmpvar_3 = texture2DProj (_GrabTexture, tmpvar_2);
  sum_1 = (tmpvar_3 * 0.05);
  highp vec4 tmpvar_4;
  tmpvar_4.x = (xlv_TEXCOORD0.x + ((_GrabTexture_TexelSize.x * -3.0) * _Size));
  tmpvar_4.yzw = xlv_TEXCOORD0.yzw;
  lowp vec4 tmpvar_5;
  tmpvar_5 = texture2DProj (_GrabTexture, tmpvar_4);
  sum_1 = (sum_1 + (tmpvar_5 * 0.09));
  highp vec4 tmpvar_6;
  tmpvar_6.x = (xlv_TEXCOORD0.x + ((_GrabTexture_TexelSize.x * -2.0) * _Size));
  tmpvar_6.yzw = xlv_TEXCOORD0.yzw;
  lowp vec4 tmpvar_7;
  tmpvar_7 = texture2DProj (_GrabTexture, tmpvar_6);
  sum_1 = (sum_1 + (tmpvar_7 * 0.12));
  highp vec4 tmpvar_8;
  tmpvar_8.x = (xlv_TEXCOORD0.x + (-(_GrabTexture_TexelSize.x) * _Size));
  tmpvar_8.yzw = xlv_TEXCOORD0.yzw;
  lowp vec4 tmpvar_9;
  tmpvar_9 = texture2DProj (_GrabTexture, tmpvar_8);
  sum_1 = (sum_1 + (tmpvar_9 * 0.15));
  lowp vec4 tmpvar_10;
  tmpvar_10 = texture2DProj (_GrabTexture, xlv_TEXCOORD0);
  sum_1 = (sum_1 + (tmpvar_10 * 0.18));
  highp vec4 tmpvar_11;
  tmpvar_11.x = (xlv_TEXCOORD0.x + (_GrabTexture_TexelSize.x * _Size));
  tmpvar_11.yzw = xlv_TEXCOORD0.yzw;
  lowp vec4 tmpvar_12;
  tmpvar_12 = texture2DProj (_GrabTexture, tmpvar_11);
  sum_1 = (sum_1 + (tmpvar_12 * 0.15));
  highp vec4 tmpvar_13;
  tmpvar_13.x = (xlv_TEXCOORD0.x + ((_GrabTexture_TexelSize.x * 2.0) * _Size));
  tmpvar_13.yzw = xlv_TEXCOORD0.yzw;
  lowp vec4 tmpvar_14;
  tmpvar_14 = texture2DProj (_GrabTexture, tmpvar_13);
  sum_1 = (sum_1 + (tmpvar_14 * 0.12));
  highp vec4 tmpvar_15;
  tmpvar_15.x = (xlv_TEXCOORD0.x + ((_GrabTexture_TexelSize.x * 3.0) * _Size));
  tmpvar_15.yzw = xlv_TEXCOORD0.yzw;
  lowp vec4 tmpvar_16;
  tmpvar_16 = texture2DProj (_GrabTexture, tmpvar_15);
  sum_1 = (sum_1 + (tmpvar_16 * 0.09));
  highp vec4 tmpvar_17;
  tmpvar_17.x = (xlv_TEXCOORD0.x + ((_GrabTexture_TexelSize.x * 4.0) * _Size));
  tmpvar_17.yzw = xlv_TEXCOORD0.yzw;
  lowp vec4 tmpvar_18;
  tmpvar_18 = texture2DProj (_GrabTexture, tmpvar_17);
  sum_1 = (sum_1 + (tmpvar_18 * 0.05));
  gl_FragData[0] = sum_1;
}


#endif
"
}
SubProgram "gles3 " {
"!!GLES3
#ifdef VERTEX
#version 300 es
precision highp float;
precision highp int;
uniform 	vec4 _Time;
uniform 	vec4 _SinTime;
uniform 	vec4 _CosTime;
uniform 	vec4 unity_DeltaTime;
uniform 	vec3 _WorldSpaceCameraPos;
uniform 	vec4 _ProjectionParams;
uniform 	vec4 _ScreenParams;
uniform 	vec4 _ZBufferParams;
uniform 	vec4 unity_OrthoParams;
uniform 	vec4 unity_CameraWorldClipPlanes[6];
uniform 	mat4 unity_CameraProjection;
uniform 	mat4 unity_CameraInvProjection;
uniform 	vec4 _WorldSpaceLightPos0;
uniform 	vec4 _LightPositionRange;
uniform 	vec4 unity_4LightPosX0;
uniform 	vec4 unity_4LightPosY0;
uniform 	vec4 unity_4LightPosZ0;
uniform 	mediump vec4 unity_4LightAtten0;
uniform 	mediump vec4 unity_LightColor[8];
uniform 	vec4 unity_LightPosition[8];
uniform 	mediump vec4 unity_LightAtten[8];
uniform 	vec4 unity_SpotDirection[8];
uniform 	mediump vec4 unity_SHAr;
uniform 	mediump vec4 unity_SHAg;
uniform 	mediump vec4 unity_SHAb;
uniform 	mediump vec4 unity_SHBr;
uniform 	mediump vec4 unity_SHBg;
uniform 	mediump vec4 unity_SHBb;
uniform 	mediump vec4 unity_SHC;
uniform 	mediump vec3 unity_LightColor0;
uniform 	mediump vec3 unity_LightColor1;
uniform 	mediump vec3 unity_LightColor2;
uniform 	mediump vec3 unity_LightColor3;
uniform 	vec4 unity_ShadowSplitSpheres[4];
uniform 	vec4 unity_ShadowSplitSqRadii;
uniform 	vec4 unity_LightShadowBias;
uniform 	vec4 _LightSplitsNear;
uniform 	vec4 _LightSplitsFar;
uniform 	mat4 unity_World2Shadow[4];
uniform 	mediump vec4 _LightShadowData;
uniform 	vec4 unity_ShadowFadeCenterAndType;
uniform 	mat4 glstate_matrix_mvp;
uniform 	mat4 glstate_matrix_modelview0;
uniform 	mat4 glstate_matrix_invtrans_modelview0;
uniform 	mat4 _Object2World;
uniform 	mat4 _World2Object;
uniform 	vec4 unity_LODFade;
uniform 	vec4 unity_WorldTransformParams;
uniform 	mat4 glstate_matrix_transpose_modelview0;
uniform 	mat4 glstate_matrix_projection;
uniform 	lowp vec4 glstate_lightmodel_ambient;
uniform 	mat4 unity_MatrixV;
uniform 	mat4 unity_MatrixVP;
uniform 	lowp vec4 unity_AmbientSky;
uniform 	lowp vec4 unity_AmbientEquator;
uniform 	lowp vec4 unity_AmbientGround;
uniform 	lowp vec4 unity_FogColor;
uniform 	vec4 unity_FogParams;
uniform 	vec4 unity_LightmapST;
uniform 	vec4 unity_DynamicLightmapST;
uniform 	vec4 unity_SpecCube0_BoxMax;
uniform 	vec4 unity_SpecCube0_BoxMin;
uniform 	vec4 unity_SpecCube0_ProbePosition;
uniform 	mediump vec4 unity_SpecCube0_HDR;
uniform 	vec4 unity_SpecCube1_BoxMax;
uniform 	vec4 unity_SpecCube1_BoxMin;
uniform 	vec4 unity_SpecCube1_ProbePosition;
uniform 	mediump vec4 unity_SpecCube1_HDR;
uniform 	lowp vec4 unity_ColorSpaceGrey;
uniform 	lowp vec4 unity_ColorSpaceDouble;
uniform 	mediump vec4 unity_ColorSpaceDielectricSpec;
uniform 	mediump vec4 unity_ColorSpaceLuminance;
uniform 	mediump vec4 unity_Lightmap_HDR;
uniform 	mediump vec4 unity_DynamicLightmap_HDR;
uniform 	vec4 _GrabTexture_TexelSize;
uniform 	float _Size;
in highp vec4 in_POSITION0;
out highp vec4 vs_TEXCOORD0;
highp vec4 t0;
void main()
{
    t0 = in_POSITION0.yyyy * glstate_matrix_mvp[1];
    t0 = glstate_matrix_mvp[0] * in_POSITION0.xxxx + t0;
    t0 = glstate_matrix_mvp[2] * in_POSITION0.zzzz + t0;
    t0 = glstate_matrix_mvp[3] * in_POSITION0.wwww + t0;
    gl_Position = t0;
    t0.xy = t0.ww + t0.xy;
    vs_TEXCOORD0.zw = t0.zw;
    vs_TEXCOORD0.xy = t0.xy * vec2(0.5, 0.5);
    return;
}

#endif
#ifdef FRAGMENT
#version 300 es
precision highp float;
precision highp int;
uniform 	vec4 _Time;
uniform 	vec4 _SinTime;
uniform 	vec4 _CosTime;
uniform 	vec4 unity_DeltaTime;
uniform 	vec3 _WorldSpaceCameraPos;
uniform 	vec4 _ProjectionParams;
uniform 	vec4 _ScreenParams;
uniform 	vec4 _ZBufferParams;
uniform 	vec4 unity_OrthoParams;
uniform 	vec4 unity_CameraWorldClipPlanes[6];
uniform 	mat4 unity_CameraProjection;
uniform 	mat4 unity_CameraInvProjection;
uniform 	vec4 _WorldSpaceLightPos0;
uniform 	vec4 _LightPositionRange;
uniform 	vec4 unity_4LightPosX0;
uniform 	vec4 unity_4LightPosY0;
uniform 	vec4 unity_4LightPosZ0;
uniform 	mediump vec4 unity_4LightAtten0;
uniform 	mediump vec4 unity_LightColor[8];
uniform 	vec4 unity_LightPosition[8];
uniform 	mediump vec4 unity_LightAtten[8];
uniform 	vec4 unity_SpotDirection[8];
uniform 	mediump vec4 unity_SHAr;
uniform 	mediump vec4 unity_SHAg;
uniform 	mediump vec4 unity_SHAb;
uniform 	mediump vec4 unity_SHBr;
uniform 	mediump vec4 unity_SHBg;
uniform 	mediump vec4 unity_SHBb;
uniform 	mediump vec4 unity_SHC;
uniform 	mediump vec3 unity_LightColor0;
uniform 	mediump vec3 unity_LightColor1;
uniform 	mediump vec3 unity_LightColor2;
uniform 	mediump vec3 unity_LightColor3;
uniform 	vec4 unity_ShadowSplitSpheres[4];
uniform 	vec4 unity_ShadowSplitSqRadii;
uniform 	vec4 unity_LightShadowBias;
uniform 	vec4 _LightSplitsNear;
uniform 	vec4 _LightSplitsFar;
uniform 	mat4 unity_World2Shadow[4];
uniform 	mediump vec4 _LightShadowData;
uniform 	vec4 unity_ShadowFadeCenterAndType;
uniform 	mat4 glstate_matrix_mvp;
uniform 	mat4 glstate_matrix_modelview0;
uniform 	mat4 glstate_matrix_invtrans_modelview0;
uniform 	mat4 _Object2World;
uniform 	mat4 _World2Object;
uniform 	vec4 unity_LODFade;
uniform 	vec4 unity_WorldTransformParams;
uniform 	mat4 glstate_matrix_transpose_modelview0;
uniform 	mat4 glstate_matrix_projection;
uniform 	lowp vec4 glstate_lightmodel_ambient;
uniform 	mat4 unity_MatrixV;
uniform 	mat4 unity_MatrixVP;
uniform 	lowp vec4 unity_AmbientSky;
uniform 	lowp vec4 unity_AmbientEquator;
uniform 	lowp vec4 unity_AmbientGround;
uniform 	lowp vec4 unity_FogColor;
uniform 	vec4 unity_FogParams;
uniform 	vec4 unity_LightmapST;
uniform 	vec4 unity_DynamicLightmapST;
uniform 	vec4 unity_SpecCube0_BoxMax;
uniform 	vec4 unity_SpecCube0_BoxMin;
uniform 	vec4 unity_SpecCube0_ProbePosition;
uniform 	mediump vec4 unity_SpecCube0_HDR;
uniform 	vec4 unity_SpecCube1_BoxMax;
uniform 	vec4 unity_SpecCube1_BoxMin;
uniform 	vec4 unity_SpecCube1_ProbePosition;
uniform 	mediump vec4 unity_SpecCube1_HDR;
uniform 	lowp vec4 unity_ColorSpaceGrey;
uniform 	lowp vec4 unity_ColorSpaceDouble;
uniform 	mediump vec4 unity_ColorSpaceDielectricSpec;
uniform 	mediump vec4 unity_ColorSpaceLuminance;
uniform 	mediump vec4 unity_Lightmap_HDR;
uniform 	mediump vec4 unity_DynamicLightmap_HDR;
uniform 	vec4 _GrabTexture_TexelSize;
uniform 	float _Size;
uniform lowp sampler2D _GrabTexture;
in highp vec4 vs_TEXCOORD0;
layout(location = 0) out mediump vec4 SV_Target0;
highp vec4 t0;
mediump vec4 t16_0;
lowp vec4 t10_0;
highp vec4 t1;
lowp vec4 t10_1;
highp vec4 t2;
lowp vec4 t10_2;
highp vec4 t3;
mediump vec4 t16_3;
lowp vec4 t10_3;
lowp vec4 t10_4;
highp vec2 t6;
void main()
{
    t0.yw = vs_TEXCOORD0.yy;
    t1.x = _GrabTexture_TexelSize.x * _Size;
    t2 = t1.xxxx * vec4(3.0, -4.0, -3.0, -2.0) + vs_TEXCOORD0.xxxx;
    t0.xz = t2.yz;
    t0 = t0 / vs_TEXCOORD0.wwww;
    t10_3 = texture(_GrabTexture, t0.zw);
    t10_0 = texture(_GrabTexture, t0.xy);
    t16_3 = t10_3 * vec4(0.0900000036, 0.0900000036, 0.0900000036, 0.0900000036);
    t16_0 = t10_0 * vec4(0.0500000007, 0.0500000007, 0.0500000007, 0.0500000007) + t16_3;
    t3.x = t2.w;
    t3.yw = vs_TEXCOORD0.yy;
    t6.xy = t3.xy / vs_TEXCOORD0.ww;
    t10_4 = texture(_GrabTexture, t6.xy);
    t16_0 = t10_4 * vec4(0.119999997, 0.119999997, 0.119999997, 0.119999997) + t16_0;
    t3.z = (-_GrabTexture_TexelSize.x) * _Size + vs_TEXCOORD0.x;
    t6.xy = vec2(t3.z / vs_TEXCOORD0.w, t3.w / vs_TEXCOORD0.w);
    t10_3 = texture(_GrabTexture, t6.xy);
    t16_0 = t10_3 * vec4(0.150000006, 0.150000006, 0.150000006, 0.150000006) + t16_0;
    t6.xy = vs_TEXCOORD0.xy / vs_TEXCOORD0.ww;
    t10_3 = texture(_GrabTexture, t6.xy);
    t16_0 = t10_3 * vec4(0.180000007, 0.180000007, 0.180000007, 0.180000007) + t16_0;
    t3.x = _GrabTexture_TexelSize.x * _Size + vs_TEXCOORD0.x;
    t3.yw = vs_TEXCOORD0.yy;
    t6.xy = t3.xy / vs_TEXCOORD0.ww;
    t10_4 = texture(_GrabTexture, t6.xy);
    t16_0 = t10_4 * vec4(0.150000006, 0.150000006, 0.150000006, 0.150000006) + t16_0;
    t3.z = t1.x * 2.0 + vs_TEXCOORD0.x;
    t2.z = t1.x * 4.0 + vs_TEXCOORD0.x;
    t1.xy = vec2(t3.z / vs_TEXCOORD0.w, t3.w / vs_TEXCOORD0.w);
    t10_1 = texture(_GrabTexture, t1.xy);
    t16_0 = t10_1 * vec4(0.119999997, 0.119999997, 0.119999997, 0.119999997) + t16_0;
    t2.yw = vs_TEXCOORD0.yy;
    t1 = t2 / vs_TEXCOORD0.wwww;
    t10_2 = texture(_GrabTexture, t1.zw);
    t10_1 = texture(_GrabTexture, t1.xy);
    t16_0 = t10_1 * vec4(0.0900000036, 0.0900000036, 0.0900000036, 0.0900000036) + t16_0;
    t16_0 = t10_2 * vec4(0.0500000007, 0.0500000007, 0.0500000007, 0.0500000007) + t16_0;
    SV_Target0 = t16_0;
    return;
}

#endif
"
}
}
Program "fp" {
SubProgram "gles " {
"!!GLES"
}
SubProgram "gles3 " {
"!!GLES3"
}
}
 }
 GrabPass {
  Tags { "LIGHTMODE"="Always" }
 }


 // Stats for Vertex shader:
 //        gles : 40 math, 9 texture
 Pass {
  Tags { "LIGHTMODE"="Always" "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Opaque" }
  GpuProgramID 114073
Program "vp" {
SubProgram "gles " {
// Stats: 40 math, 9 textures
"!!GLES
#version 100

#ifdef VERTEX
attribute vec4 _glesVertex;
uniform highp mat4 glstate_matrix_mvp;
varying highp vec4 xlv_TEXCOORD0;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_1 = (glstate_matrix_mvp * _glesVertex);
  tmpvar_2.xy = ((tmpvar_1.xy + tmpvar_1.w) * 0.5);
  tmpvar_2.zw = tmpvar_1.zw;
  gl_Position = tmpvar_1;
  xlv_TEXCOORD0 = tmpvar_2;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _GrabTexture;
uniform highp vec4 _GrabTexture_TexelSize;
uniform highp float _Size;
varying highp vec4 xlv_TEXCOORD0;
void main ()
{
  mediump vec4 sum_1;
  highp vec4 tmpvar_2;
  tmpvar_2.x = xlv_TEXCOORD0.x;
  tmpvar_2.y = (xlv_TEXCOORD0.y + ((_GrabTexture_TexelSize.y * -4.0) * _Size));
  tmpvar_2.zw = xlv_TEXCOORD0.zw;
  lowp vec4 tmpvar_3;
  tmpvar_3 = texture2DProj (_GrabTexture, tmpvar_2);
  sum_1 = (tmpvar_3 * 0.05);
  highp vec4 tmpvar_4;
  tmpvar_4.x = xlv_TEXCOORD0.x;
  tmpvar_4.y = (xlv_TEXCOORD0.y + ((_GrabTexture_TexelSize.y * -3.0) * _Size));
  tmpvar_4.zw = xlv_TEXCOORD0.zw;
  lowp vec4 tmpvar_5;
  tmpvar_5 = texture2DProj (_GrabTexture, tmpvar_4);
  sum_1 = (sum_1 + (tmpvar_5 * 0.09));
  highp vec4 tmpvar_6;
  tmpvar_6.x = xlv_TEXCOORD0.x;
  tmpvar_6.y = (xlv_TEXCOORD0.y + ((_GrabTexture_TexelSize.y * -2.0) * _Size));
  tmpvar_6.zw = xlv_TEXCOORD0.zw;
  lowp vec4 tmpvar_7;
  tmpvar_7 = texture2DProj (_GrabTexture, tmpvar_6);
  sum_1 = (sum_1 + (tmpvar_7 * 0.12));
  highp vec4 tmpvar_8;
  tmpvar_8.x = xlv_TEXCOORD0.x;
  tmpvar_8.y = (xlv_TEXCOORD0.y + (-(_GrabTexture_TexelSize.y) * _Size));
  tmpvar_8.zw = xlv_TEXCOORD0.zw;
  lowp vec4 tmpvar_9;
  tmpvar_9 = texture2DProj (_GrabTexture, tmpvar_8);
  sum_1 = (sum_1 + (tmpvar_9 * 0.15));
  lowp vec4 tmpvar_10;
  tmpvar_10 = texture2DProj (_GrabTexture, xlv_TEXCOORD0);
  sum_1 = (sum_1 + (tmpvar_10 * 0.18));
  highp vec4 tmpvar_11;
  tmpvar_11.x = xlv_TEXCOORD0.x;
  tmpvar_11.y = (xlv_TEXCOORD0.y + (_GrabTexture_TexelSize.y * _Size));
  tmpvar_11.zw = xlv_TEXCOORD0.zw;
  lowp vec4 tmpvar_12;
  tmpvar_12 = texture2DProj (_GrabTexture, tmpvar_11);
  sum_1 = (sum_1 + (tmpvar_12 * 0.15));
  highp vec4 tmpvar_13;
  tmpvar_13.x = xlv_TEXCOORD0.x;
  tmpvar_13.y = (xlv_TEXCOORD0.y + ((_GrabTexture_TexelSize.y * 2.0) * _Size));
  tmpvar_13.zw = xlv_TEXCOORD0.zw;
  lowp vec4 tmpvar_14;
  tmpvar_14 = texture2DProj (_GrabTexture, tmpvar_13);
  sum_1 = (sum_1 + (tmpvar_14 * 0.12));
  highp vec4 tmpvar_15;
  tmpvar_15.x = xlv_TEXCOORD0.x;
  tmpvar_15.y = (xlv_TEXCOORD0.y + ((_GrabTexture_TexelSize.y * 3.0) * _Size));
  tmpvar_15.zw = xlv_TEXCOORD0.zw;
  lowp vec4 tmpvar_16;
  tmpvar_16 = texture2DProj (_GrabTexture, tmpvar_15);
  sum_1 = (sum_1 + (tmpvar_16 * 0.09));
  highp vec4 tmpvar_17;
  tmpvar_17.x = xlv_TEXCOORD0.x;
  tmpvar_17.y = (xlv_TEXCOORD0.y + ((_GrabTexture_TexelSize.y * 4.0) * _Size));
  tmpvar_17.zw = xlv_TEXCOORD0.zw;
  lowp vec4 tmpvar_18;
  tmpvar_18 = texture2DProj (_GrabTexture, tmpvar_17);
  sum_1 = (sum_1 + (tmpvar_18 * 0.05));
  gl_FragData[0] = sum_1;
}


#endif
"
}
SubProgram "gles3 " {
"!!GLES3
#ifdef VERTEX
#version 300 es
precision highp float;
precision highp int;
uniform 	vec4 _Time;
uniform 	vec4 _SinTime;
uniform 	vec4 _CosTime;
uniform 	vec4 unity_DeltaTime;
uniform 	vec3 _WorldSpaceCameraPos;
uniform 	vec4 _ProjectionParams;
uniform 	vec4 _ScreenParams;
uniform 	vec4 _ZBufferParams;
uniform 	vec4 unity_OrthoParams;
uniform 	vec4 unity_CameraWorldClipPlanes[6];
uniform 	mat4 unity_CameraProjection;
uniform 	mat4 unity_CameraInvProjection;
uniform 	vec4 _WorldSpaceLightPos0;
uniform 	vec4 _LightPositionRange;
uniform 	vec4 unity_4LightPosX0;
uniform 	vec4 unity_4LightPosY0;
uniform 	vec4 unity_4LightPosZ0;
uniform 	mediump vec4 unity_4LightAtten0;
uniform 	mediump vec4 unity_LightColor[8];
uniform 	vec4 unity_LightPosition[8];
uniform 	mediump vec4 unity_LightAtten[8];
uniform 	vec4 unity_SpotDirection[8];
uniform 	mediump vec4 unity_SHAr;
uniform 	mediump vec4 unity_SHAg;
uniform 	mediump vec4 unity_SHAb;
uniform 	mediump vec4 unity_SHBr;
uniform 	mediump vec4 unity_SHBg;
uniform 	mediump vec4 unity_SHBb;
uniform 	mediump vec4 unity_SHC;
uniform 	mediump vec3 unity_LightColor0;
uniform 	mediump vec3 unity_LightColor1;
uniform 	mediump vec3 unity_LightColor2;
uniform 	mediump vec3 unity_LightColor3;
uniform 	vec4 unity_ShadowSplitSpheres[4];
uniform 	vec4 unity_ShadowSplitSqRadii;
uniform 	vec4 unity_LightShadowBias;
uniform 	vec4 _LightSplitsNear;
uniform 	vec4 _LightSplitsFar;
uniform 	mat4 unity_World2Shadow[4];
uniform 	mediump vec4 _LightShadowData;
uniform 	vec4 unity_ShadowFadeCenterAndType;
uniform 	mat4 glstate_matrix_mvp;
uniform 	mat4 glstate_matrix_modelview0;
uniform 	mat4 glstate_matrix_invtrans_modelview0;
uniform 	mat4 _Object2World;
uniform 	mat4 _World2Object;
uniform 	vec4 unity_LODFade;
uniform 	vec4 unity_WorldTransformParams;
uniform 	mat4 glstate_matrix_transpose_modelview0;
uniform 	mat4 glstate_matrix_projection;
uniform 	lowp vec4 glstate_lightmodel_ambient;
uniform 	mat4 unity_MatrixV;
uniform 	mat4 unity_MatrixVP;
uniform 	lowp vec4 unity_AmbientSky;
uniform 	lowp vec4 unity_AmbientEquator;
uniform 	lowp vec4 unity_AmbientGround;
uniform 	lowp vec4 unity_FogColor;
uniform 	vec4 unity_FogParams;
uniform 	vec4 unity_LightmapST;
uniform 	vec4 unity_DynamicLightmapST;
uniform 	vec4 unity_SpecCube0_BoxMax;
uniform 	vec4 unity_SpecCube0_BoxMin;
uniform 	vec4 unity_SpecCube0_ProbePosition;
uniform 	mediump vec4 unity_SpecCube0_HDR;
uniform 	vec4 unity_SpecCube1_BoxMax;
uniform 	vec4 unity_SpecCube1_BoxMin;
uniform 	vec4 unity_SpecCube1_ProbePosition;
uniform 	mediump vec4 unity_SpecCube1_HDR;
uniform 	lowp vec4 unity_ColorSpaceGrey;
uniform 	lowp vec4 unity_ColorSpaceDouble;
uniform 	mediump vec4 unity_ColorSpaceDielectricSpec;
uniform 	mediump vec4 unity_ColorSpaceLuminance;
uniform 	mediump vec4 unity_Lightmap_HDR;
uniform 	mediump vec4 unity_DynamicLightmap_HDR;
uniform 	vec4 _GrabTexture_TexelSize;
uniform 	float _Size;
in highp vec4 in_POSITION0;
out highp vec4 vs_TEXCOORD0;
highp vec4 t0;
void main()
{
    t0 = in_POSITION0.yyyy * glstate_matrix_mvp[1];
    t0 = glstate_matrix_mvp[0] * in_POSITION0.xxxx + t0;
    t0 = glstate_matrix_mvp[2] * in_POSITION0.zzzz + t0;
    t0 = glstate_matrix_mvp[3] * in_POSITION0.wwww + t0;
    gl_Position = t0;
    t0.xy = t0.ww + t0.xy;
    vs_TEXCOORD0.zw = t0.zw;
    vs_TEXCOORD0.xy = t0.xy * vec2(0.5, 0.5);
    return;
}

#endif
#ifdef FRAGMENT
#version 300 es
precision highp float;
precision highp int;
uniform 	vec4 _Time;
uniform 	vec4 _SinTime;
uniform 	vec4 _CosTime;
uniform 	vec4 unity_DeltaTime;
uniform 	vec3 _WorldSpaceCameraPos;
uniform 	vec4 _ProjectionParams;
uniform 	vec4 _ScreenParams;
uniform 	vec4 _ZBufferParams;
uniform 	vec4 unity_OrthoParams;
uniform 	vec4 unity_CameraWorldClipPlanes[6];
uniform 	mat4 unity_CameraProjection;
uniform 	mat4 unity_CameraInvProjection;
uniform 	vec4 _WorldSpaceLightPos0;
uniform 	vec4 _LightPositionRange;
uniform 	vec4 unity_4LightPosX0;
uniform 	vec4 unity_4LightPosY0;
uniform 	vec4 unity_4LightPosZ0;
uniform 	mediump vec4 unity_4LightAtten0;
uniform 	mediump vec4 unity_LightColor[8];
uniform 	vec4 unity_LightPosition[8];
uniform 	mediump vec4 unity_LightAtten[8];
uniform 	vec4 unity_SpotDirection[8];
uniform 	mediump vec4 unity_SHAr;
uniform 	mediump vec4 unity_SHAg;
uniform 	mediump vec4 unity_SHAb;
uniform 	mediump vec4 unity_SHBr;
uniform 	mediump vec4 unity_SHBg;
uniform 	mediump vec4 unity_SHBb;
uniform 	mediump vec4 unity_SHC;
uniform 	mediump vec3 unity_LightColor0;
uniform 	mediump vec3 unity_LightColor1;
uniform 	mediump vec3 unity_LightColor2;
uniform 	mediump vec3 unity_LightColor3;
uniform 	vec4 unity_ShadowSplitSpheres[4];
uniform 	vec4 unity_ShadowSplitSqRadii;
uniform 	vec4 unity_LightShadowBias;
uniform 	vec4 _LightSplitsNear;
uniform 	vec4 _LightSplitsFar;
uniform 	mat4 unity_World2Shadow[4];
uniform 	mediump vec4 _LightShadowData;
uniform 	vec4 unity_ShadowFadeCenterAndType;
uniform 	mat4 glstate_matrix_mvp;
uniform 	mat4 glstate_matrix_modelview0;
uniform 	mat4 glstate_matrix_invtrans_modelview0;
uniform 	mat4 _Object2World;
uniform 	mat4 _World2Object;
uniform 	vec4 unity_LODFade;
uniform 	vec4 unity_WorldTransformParams;
uniform 	mat4 glstate_matrix_transpose_modelview0;
uniform 	mat4 glstate_matrix_projection;
uniform 	lowp vec4 glstate_lightmodel_ambient;
uniform 	mat4 unity_MatrixV;
uniform 	mat4 unity_MatrixVP;
uniform 	lowp vec4 unity_AmbientSky;
uniform 	lowp vec4 unity_AmbientEquator;
uniform 	lowp vec4 unity_AmbientGround;
uniform 	lowp vec4 unity_FogColor;
uniform 	vec4 unity_FogParams;
uniform 	vec4 unity_LightmapST;
uniform 	vec4 unity_DynamicLightmapST;
uniform 	vec4 unity_SpecCube0_BoxMax;
uniform 	vec4 unity_SpecCube0_BoxMin;
uniform 	vec4 unity_SpecCube0_ProbePosition;
uniform 	mediump vec4 unity_SpecCube0_HDR;
uniform 	vec4 unity_SpecCube1_BoxMax;
uniform 	vec4 unity_SpecCube1_BoxMin;
uniform 	vec4 unity_SpecCube1_ProbePosition;
uniform 	mediump vec4 unity_SpecCube1_HDR;
uniform 	lowp vec4 unity_ColorSpaceGrey;
uniform 	lowp vec4 unity_ColorSpaceDouble;
uniform 	mediump vec4 unity_ColorSpaceDielectricSpec;
uniform 	mediump vec4 unity_ColorSpaceLuminance;
uniform 	mediump vec4 unity_Lightmap_HDR;
uniform 	mediump vec4 unity_DynamicLightmap_HDR;
uniform 	vec4 _GrabTexture_TexelSize;
uniform 	float _Size;
uniform lowp sampler2D _GrabTexture;
in highp vec4 vs_TEXCOORD0;
layout(location = 0) out mediump vec4 SV_Target0;
highp vec4 t0;
mediump vec4 t16_0;
lowp vec4 t10_0;
highp vec4 t1;
lowp vec4 t10_1;
highp vec4 t2;
lowp vec4 t10_2;
highp vec4 t3;
mediump vec4 t16_3;
lowp vec4 t10_3;
lowp vec4 t10_4;
highp vec2 t6;
void main()
{
    t0.xz = vs_TEXCOORD0.xx;
    t1.x = _GrabTexture_TexelSize.y * _Size;
    t2 = t1.xxxx * vec4(-4.0, 3.0, -3.0, -2.0) + vs_TEXCOORD0.yyyy;
    t0.yw = t2.xz;
    t0 = t0 / vs_TEXCOORD0.wwww;
    t10_3 = texture(_GrabTexture, t0.zw);
    t10_0 = texture(_GrabTexture, t0.xy);
    t16_3 = t10_3 * vec4(0.0900000036, 0.0900000036, 0.0900000036, 0.0900000036);
    t16_0 = t10_0 * vec4(0.0500000007, 0.0500000007, 0.0500000007, 0.0500000007) + t16_3;
    t3.y = t2.w;
    t3.xz = vs_TEXCOORD0.xx;
    t6.xy = t3.xy / vs_TEXCOORD0.ww;
    t10_4 = texture(_GrabTexture, t6.xy);
    t16_0 = t10_4 * vec4(0.119999997, 0.119999997, 0.119999997, 0.119999997) + t16_0;
    t3.w = (-_GrabTexture_TexelSize.y) * _Size + vs_TEXCOORD0.y;
    t6.xy = vec2(t3.z / vs_TEXCOORD0.w, t3.w / vs_TEXCOORD0.w);
    t10_3 = texture(_GrabTexture, t6.xy);
    t16_0 = t10_3 * vec4(0.150000006, 0.150000006, 0.150000006, 0.150000006) + t16_0;
    t6.xy = vs_TEXCOORD0.xy / vs_TEXCOORD0.ww;
    t10_3 = texture(_GrabTexture, t6.xy);
    t16_0 = t10_3 * vec4(0.180000007, 0.180000007, 0.180000007, 0.180000007) + t16_0;
    t3.y = _GrabTexture_TexelSize.y * _Size + vs_TEXCOORD0.y;
    t3.xz = vs_TEXCOORD0.xx;
    t6.xy = t3.xy / vs_TEXCOORD0.ww;
    t10_4 = texture(_GrabTexture, t6.xy);
    t16_0 = t10_4 * vec4(0.150000006, 0.150000006, 0.150000006, 0.150000006) + t16_0;
    t3.w = t1.x * 2.0 + vs_TEXCOORD0.y;
    t2.w = t1.x * 4.0 + vs_TEXCOORD0.y;
    t1.xy = vec2(t3.z / vs_TEXCOORD0.w, t3.w / vs_TEXCOORD0.w);
    t10_1 = texture(_GrabTexture, t1.xy);
    t16_0 = t10_1 * vec4(0.119999997, 0.119999997, 0.119999997, 0.119999997) + t16_0;
    t2.xz = vs_TEXCOORD0.xx;
    t1 = t2 / vs_TEXCOORD0.wwww;
    t10_2 = texture(_GrabTexture, t1.zw);
    t10_1 = texture(_GrabTexture, t1.xy);
    t16_0 = t10_1 * vec4(0.0900000036, 0.0900000036, 0.0900000036, 0.0900000036) + t16_0;
    t16_0 = t10_2 * vec4(0.0500000007, 0.0500000007, 0.0500000007, 0.0500000007) + t16_0;
    SV_Target0 = t16_0;
    return;
}

#endif
"
}
}
Program "fp" {
SubProgram "gles " {
"!!GLES"
}
SubProgram "gles3 " {
"!!GLES3"
}
}
 }
 GrabPass {
  Tags { "LIGHTMODE"="Always" }
 }


 // Stats for Vertex shader:
 //        gles : 8 math, 3 texture
 Pass {
  Tags { "LIGHTMODE"="Always" "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Opaque" }
  GpuProgramID 154776
Program "vp" {
SubProgram "gles " {
// Stats: 8 math, 3 textures
"!!GLES
#version 100

#ifdef VERTEX
attribute vec4 _glesVertex;
attribute vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp vec4 _BumpMap_ST;
uniform highp vec4 _MainTex_ST;
varying highp vec4 xlv_TEXCOORD0;
varying highp vec2 xlv_TEXCOORD1;
varying highp vec2 xlv_TEXCOORD2;
void main ()
{
  highp vec4 tmpvar_1;
  highp vec4 tmpvar_2;
  tmpvar_1 = (glstate_matrix_mvp * _glesVertex);
  tmpvar_2.xy = ((tmpvar_1.xy + tmpvar_1.w) * 0.5);
  tmpvar_2.zw = tmpvar_1.zw;
  gl_Position = tmpvar_1;
  xlv_TEXCOORD0 = tmpvar_2;
  xlv_TEXCOORD1 = ((_glesMultiTexCoord0.xy * _BumpMap_ST.xy) + _BumpMap_ST.zw);
  xlv_TEXCOORD2 = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
}


#endif
#ifdef FRAGMENT
uniform highp float _BumpAmt;
uniform lowp vec4 _Color;
uniform sampler2D _GrabTexture;
uniform highp vec4 _GrabTexture_TexelSize;
uniform sampler2D _BumpMap;
uniform sampler2D _MainTex;
varying highp vec4 xlv_TEXCOORD0;
varying highp vec2 xlv_TEXCOORD1;
varying highp vec2 xlv_TEXCOORD2;
void main ()
{
  highp vec4 tmpvar_1;
  tmpvar_1.zw = xlv_TEXCOORD0.zw;
  mediump vec4 tint_2;
  mediump vec4 col_3;
  mediump vec2 bump_4;
  lowp vec2 tmpvar_5;
  tmpvar_5 = ((texture2D (_BumpMap, xlv_TEXCOORD1).xyz * 2.0) - 1.0).xy;
  bump_4 = tmpvar_5;
  tmpvar_1.xy = (((bump_4 * _BumpAmt) * (_GrabTexture_TexelSize.xy * xlv_TEXCOORD0.z)) + xlv_TEXCOORD0.xy);
  lowp vec4 tmpvar_6;
  tmpvar_6 = texture2DProj (_GrabTexture, tmpvar_1);
  col_3 = tmpvar_6;
  lowp vec4 tmpvar_7;
  tmpvar_7 = (texture2D (_MainTex, xlv_TEXCOORD2) * _Color);
  tint_2 = tmpvar_7;
  gl_FragData[0] = (col_3 * tint_2);
}


#endif
"
}
SubProgram "gles3 " {
"!!GLES3
#ifdef VERTEX
#version 300 es
precision highp float;
precision highp int;
uniform 	vec4 _Time;
uniform 	vec4 _SinTime;
uniform 	vec4 _CosTime;
uniform 	vec4 unity_DeltaTime;
uniform 	vec3 _WorldSpaceCameraPos;
uniform 	vec4 _ProjectionParams;
uniform 	vec4 _ScreenParams;
uniform 	vec4 _ZBufferParams;
uniform 	vec4 unity_OrthoParams;
uniform 	vec4 unity_CameraWorldClipPlanes[6];
uniform 	mat4 unity_CameraProjection;
uniform 	mat4 unity_CameraInvProjection;
uniform 	vec4 _WorldSpaceLightPos0;
uniform 	vec4 _LightPositionRange;
uniform 	vec4 unity_4LightPosX0;
uniform 	vec4 unity_4LightPosY0;
uniform 	vec4 unity_4LightPosZ0;
uniform 	mediump vec4 unity_4LightAtten0;
uniform 	mediump vec4 unity_LightColor[8];
uniform 	vec4 unity_LightPosition[8];
uniform 	mediump vec4 unity_LightAtten[8];
uniform 	vec4 unity_SpotDirection[8];
uniform 	mediump vec4 unity_SHAr;
uniform 	mediump vec4 unity_SHAg;
uniform 	mediump vec4 unity_SHAb;
uniform 	mediump vec4 unity_SHBr;
uniform 	mediump vec4 unity_SHBg;
uniform 	mediump vec4 unity_SHBb;
uniform 	mediump vec4 unity_SHC;
uniform 	mediump vec3 unity_LightColor0;
uniform 	mediump vec3 unity_LightColor1;
uniform 	mediump vec3 unity_LightColor2;
uniform 	mediump vec3 unity_LightColor3;
uniform 	vec4 unity_ShadowSplitSpheres[4];
uniform 	vec4 unity_ShadowSplitSqRadii;
uniform 	vec4 unity_LightShadowBias;
uniform 	vec4 _LightSplitsNear;
uniform 	vec4 _LightSplitsFar;
uniform 	mat4 unity_World2Shadow[4];
uniform 	mediump vec4 _LightShadowData;
uniform 	vec4 unity_ShadowFadeCenterAndType;
uniform 	mat4 glstate_matrix_mvp;
uniform 	mat4 glstate_matrix_modelview0;
uniform 	mat4 glstate_matrix_invtrans_modelview0;
uniform 	mat4 _Object2World;
uniform 	mat4 _World2Object;
uniform 	vec4 unity_LODFade;
uniform 	vec4 unity_WorldTransformParams;
uniform 	mat4 glstate_matrix_transpose_modelview0;
uniform 	mat4 glstate_matrix_projection;
uniform 	lowp vec4 glstate_lightmodel_ambient;
uniform 	mat4 unity_MatrixV;
uniform 	mat4 unity_MatrixVP;
uniform 	lowp vec4 unity_AmbientSky;
uniform 	lowp vec4 unity_AmbientEquator;
uniform 	lowp vec4 unity_AmbientGround;
uniform 	lowp vec4 unity_FogColor;
uniform 	vec4 unity_FogParams;
uniform 	vec4 unity_LightmapST;
uniform 	vec4 unity_DynamicLightmapST;
uniform 	vec4 unity_SpecCube0_BoxMax;
uniform 	vec4 unity_SpecCube0_BoxMin;
uniform 	vec4 unity_SpecCube0_ProbePosition;
uniform 	mediump vec4 unity_SpecCube0_HDR;
uniform 	vec4 unity_SpecCube1_BoxMax;
uniform 	vec4 unity_SpecCube1_BoxMin;
uniform 	vec4 unity_SpecCube1_ProbePosition;
uniform 	mediump vec4 unity_SpecCube1_HDR;
uniform 	lowp vec4 unity_ColorSpaceGrey;
uniform 	lowp vec4 unity_ColorSpaceDouble;
uniform 	mediump vec4 unity_ColorSpaceDielectricSpec;
uniform 	mediump vec4 unity_ColorSpaceLuminance;
uniform 	mediump vec4 unity_Lightmap_HDR;
uniform 	mediump vec4 unity_DynamicLightmap_HDR;
uniform 	float _BumpAmt;
uniform 	vec4 _BumpMap_ST;
uniform 	vec4 _MainTex_ST;
uniform 	lowp vec4 _Color;
uniform 	vec4 _GrabTexture_TexelSize;
in highp vec4 in_POSITION0;
in highp vec2 in_TEXCOORD0;
out highp vec4 vs_TEXCOORD0;
out highp vec2 vs_TEXCOORD1;
out highp vec2 vs_TEXCOORD2;
highp vec4 t0;
void main()
{
    t0 = in_POSITION0.yyyy * glstate_matrix_mvp[1];
    t0 = glstate_matrix_mvp[0] * in_POSITION0.xxxx + t0;
    t0 = glstate_matrix_mvp[2] * in_POSITION0.zzzz + t0;
    t0 = glstate_matrix_mvp[3] * in_POSITION0.wwww + t0;
    gl_Position = t0;
    t0.xy = t0.ww + t0.xy;
    vs_TEXCOORD0.zw = t0.zw;
    vs_TEXCOORD0.xy = t0.xy * vec2(0.5, 0.5);
    vs_TEXCOORD1.xy = in_TEXCOORD0.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;
    vs_TEXCOORD2.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    return;
}

#endif
#ifdef FRAGMENT
#version 300 es
precision highp float;
precision highp int;
uniform 	vec4 _Time;
uniform 	vec4 _SinTime;
uniform 	vec4 _CosTime;
uniform 	vec4 unity_DeltaTime;
uniform 	vec3 _WorldSpaceCameraPos;
uniform 	vec4 _ProjectionParams;
uniform 	vec4 _ScreenParams;
uniform 	vec4 _ZBufferParams;
uniform 	vec4 unity_OrthoParams;
uniform 	vec4 unity_CameraWorldClipPlanes[6];
uniform 	mat4 unity_CameraProjection;
uniform 	mat4 unity_CameraInvProjection;
uniform 	vec4 _WorldSpaceLightPos0;
uniform 	vec4 _LightPositionRange;
uniform 	vec4 unity_4LightPosX0;
uniform 	vec4 unity_4LightPosY0;
uniform 	vec4 unity_4LightPosZ0;
uniform 	mediump vec4 unity_4LightAtten0;
uniform 	mediump vec4 unity_LightColor[8];
uniform 	vec4 unity_LightPosition[8];
uniform 	mediump vec4 unity_LightAtten[8];
uniform 	vec4 unity_SpotDirection[8];
uniform 	mediump vec4 unity_SHAr;
uniform 	mediump vec4 unity_SHAg;
uniform 	mediump vec4 unity_SHAb;
uniform 	mediump vec4 unity_SHBr;
uniform 	mediump vec4 unity_SHBg;
uniform 	mediump vec4 unity_SHBb;
uniform 	mediump vec4 unity_SHC;
uniform 	mediump vec3 unity_LightColor0;
uniform 	mediump vec3 unity_LightColor1;
uniform 	mediump vec3 unity_LightColor2;
uniform 	mediump vec3 unity_LightColor3;
uniform 	vec4 unity_ShadowSplitSpheres[4];
uniform 	vec4 unity_ShadowSplitSqRadii;
uniform 	vec4 unity_LightShadowBias;
uniform 	vec4 _LightSplitsNear;
uniform 	vec4 _LightSplitsFar;
uniform 	mat4 unity_World2Shadow[4];
uniform 	mediump vec4 _LightShadowData;
uniform 	vec4 unity_ShadowFadeCenterAndType;
uniform 	mat4 glstate_matrix_mvp;
uniform 	mat4 glstate_matrix_modelview0;
uniform 	mat4 glstate_matrix_invtrans_modelview0;
uniform 	mat4 _Object2World;
uniform 	mat4 _World2Object;
uniform 	vec4 unity_LODFade;
uniform 	vec4 unity_WorldTransformParams;
uniform 	mat4 glstate_matrix_transpose_modelview0;
uniform 	mat4 glstate_matrix_projection;
uniform 	lowp vec4 glstate_lightmodel_ambient;
uniform 	mat4 unity_MatrixV;
uniform 	mat4 unity_MatrixVP;
uniform 	lowp vec4 unity_AmbientSky;
uniform 	lowp vec4 unity_AmbientEquator;
uniform 	lowp vec4 unity_AmbientGround;
uniform 	lowp vec4 unity_FogColor;
uniform 	vec4 unity_FogParams;
uniform 	vec4 unity_LightmapST;
uniform 	vec4 unity_DynamicLightmapST;
uniform 	vec4 unity_SpecCube0_BoxMax;
uniform 	vec4 unity_SpecCube0_BoxMin;
uniform 	vec4 unity_SpecCube0_ProbePosition;
uniform 	mediump vec4 unity_SpecCube0_HDR;
uniform 	vec4 unity_SpecCube1_BoxMax;
uniform 	vec4 unity_SpecCube1_BoxMin;
uniform 	vec4 unity_SpecCube1_ProbePosition;
uniform 	mediump vec4 unity_SpecCube1_HDR;
uniform 	lowp vec4 unity_ColorSpaceGrey;
uniform 	lowp vec4 unity_ColorSpaceDouble;
uniform 	mediump vec4 unity_ColorSpaceDielectricSpec;
uniform 	mediump vec4 unity_ColorSpaceLuminance;
uniform 	mediump vec4 unity_Lightmap_HDR;
uniform 	mediump vec4 unity_DynamicLightmap_HDR;
uniform 	float _BumpAmt;
uniform 	vec4 _BumpMap_ST;
uniform 	vec4 _MainTex_ST;
uniform 	lowp vec4 _Color;
uniform 	vec4 _GrabTexture_TexelSize;
uniform lowp sampler2D _BumpMap;
uniform lowp sampler2D _GrabTexture;
uniform lowp sampler2D _MainTex;
in highp vec4 vs_TEXCOORD0;
in highp vec2 vs_TEXCOORD1;
in highp vec2 vs_TEXCOORD2;
layout(location = 0) out mediump vec4 SV_Target0;
highp vec2 t0;
lowp vec4 t10_0;
mediump vec4 t16_1;
lowp vec4 t10_1;
void main()
{
    t10_0.xy = texture(_BumpMap, vs_TEXCOORD1.xy).xy;
    t10_1.xy = t10_0.xy * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
    t0.xy = t10_1.xy * vec2(_BumpAmt);
    t0.xy = t0.xy * _GrabTexture_TexelSize.xy;
    t0.xy = t0.xy * vs_TEXCOORD0.zz + vs_TEXCOORD0.xy;
    t0.xy = t0.xy / vs_TEXCOORD0.ww;
    t10_0 = texture(_GrabTexture, t0.xy);
    t10_1 = texture(_MainTex, vs_TEXCOORD2.xy);
    t16_1 = t10_1 * _Color;
    SV_Target0 = t10_0 * t16_1;
    return;
}

#endif
"
}
}
Program "fp" {
SubProgram "gles " {
"!!GLES"
}
SubProgram "gles3 " {
"!!GLES3"
}
}
 }
}
}