﻿Shader "DungeonArchitect/Unlit/CircleShader"
{
    Properties
    {
        _BodyColor ("Body Color", Color) = (1, 1, 1, 1)
        _BorderColor ("Border Color", Color) = (0, 0, 0, 0.75)
        _BorderThickness ("Border Thickness", Float) = 0.05
    }
    SubShader
    {
        Tags {
            "Queue"="Transparent" 
            "IgnoreProjector"="True" 
            "RenderType"="Transparent"
        }
        LOD 100
        
        Blend SrcAlpha OneMinusSrcAlpha 

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float4 _BodyColor;
            float4 _BorderColor;
            float _BorderThickness;
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float d = length(i.uv - float2(0.5, 0.5)) * 2;
                float s = 0;

                float4 col;
                float thickness = clamp(_BorderThickness, 0, 1);
                if (d < 1 - thickness) {
                    col = _BodyColor;
                }
                else if (d < 1) {
                    col = _BorderColor;
                }
                else {
                    col = float4(0, 0, 0, 0);
                }
                return col * i.color;
            }
            ENDCG
        }
    }
}
