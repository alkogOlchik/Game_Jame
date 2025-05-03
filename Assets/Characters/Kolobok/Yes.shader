Shader "Sprites/GlitchSprite"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _GlitchPower ("Glitch Power", Range(0, 0.3)) = 0.1
        _Speed ("Speed", Float) = 10.0
    }

    SubShader
    {
        Tags
        { 
            "Queue"="Transparent" 
            "IgnoreProjector"="True" 
            "RenderType"="Transparent" 
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            float _GlitchPower;
            float _Speed;

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = TRANSFORM_TEX(IN.texcoord, _MainTex);
                OUT.color = IN.color * _Color;
                return OUT;
            }

            float random(float2 p)
            {
                return frac(sin(dot(p, float2(12.9898, 78.233))) * 43758.5453);
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                float time = _Time.y * _Speed;
                float2 uv = IN.texcoord;

                // Простой эффект глитча
                uv.x += (random(float2(time, uv.y)) - 0.5) * _GlitchPower;
                uv.y += (random(float2(time, uv.x)) - 0.5) * _GlitchPower * 0.5;

                fixed4 c = tex2D(_MainTex, uv) * IN.color;
                
                // Добавляем случайные артефакты
                if (random(uv + time) < 0.05 * _GlitchPower * 10)
                {
                    c.rgb = random(uv) > 0.5 ? fixed3(1,1,1) : fixed3(0,0,0);
                }

                return c;
            }
            ENDCG
        }
    }
}