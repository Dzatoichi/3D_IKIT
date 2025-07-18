Shader "Custom/PanoramaUltimate" {
    Properties {
        _MainTex ("Panorama (RGB)", 2D) = "white" {}
        _SeamBlend ("Seam Blend", Range(0, 0.5)) = 0.2
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        Cull Front
        ZWrite Off

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
            };

            struct v2f {
                float3 rayDirection : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _SeamBlend;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.rayDirection = mul(unity_ObjectToWorld, v.vertex).xyz - _WorldSpaceCameraPos;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                float3 dir = normalize(i.rayDirection);
                
                // Преобразование направления в UV с улучшенной математикой
                float longitude = atan2(dir.z, dir.x);
                float latitude = asin(dir.y);
                
                float2 uv;
                uv.x = 0.5 - longitude / (2.0 * UNITY_PI);
                uv.y = 0.5 + latitude / UNITY_PI;
                
                // Специальная обработка шва
                float blendArea = _SeamBlend;
                float seamBlend = smoothstep(0.5 - blendArea, 0.5 + blendArea, uv.x);
                
                // Двойное сэмплирование для устранения шва
                fixed4 color1 = tex2D(_MainTex, uv * _MainTex_ST.xy + _MainTex_ST.zw);
                fixed4 color2 = tex2D(_MainTex, (uv + float2(1.0, 0)) * _MainTex_ST.xy + _MainTex_ST.zw);
                
                // Смешивание у границы шва
                fixed4 finalColor = lerp(color1, color2, seamBlend);
                
                // Коррекция полюсов
                float poleFactor = 1.0 - smoothstep(0.9, 1.0, abs(uv.y - 0.5) * 2.0);
                finalColor.rgb *= poleFactor;
                
                return finalColor;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}