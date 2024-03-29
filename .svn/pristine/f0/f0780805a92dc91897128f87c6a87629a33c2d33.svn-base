Shader "Unlit/bridge"
{
Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Move ("Move",Range(0,200)) = 0
        _Color ("Color",Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            ZWrite Off
            ZTest Off
            Cull Off
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Move;
            float4 _Color;
            float _IsRight;
            v2f vert (appdata v)
            {
                v2f o;
                float remapUVx;
                if(_IsRight==0)
                {
                    remapUVx = v.uv.x;
                    v.vertex.y += remapUVx*_Move;
                    v.vertex.x -= remapUVx*_Move/2;
                }
                else
                {
                    remapUVx = 1-v.uv.x;
                    v.vertex.y += remapUVx*_Move;
                    v.vertex.x += remapUVx*_Move/2;
                }

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv)*_Color;
                return col;
            }
            ENDCG
        }
    }
}
