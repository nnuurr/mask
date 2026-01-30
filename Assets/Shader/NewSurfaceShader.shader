Shader "Custom/LitCircularVignetteGradientNoise"
{
    Properties
    {
        _MainTex ("Albedo", 2D) = "white" {}
        _Color ("Color Tint", Color) = (1,1,1,1)

        _NoiseScale ("Noise Scale", Float) = 5.0
        _NoiseStrength ("Noise Strength", Range(0,1)) = 0.5

        _VignetteRadius ("Vignette Radius", Range(0,1)) = 0.5
        _VignetteSoftness ("Vignette Softness", Range(0.001,1)) = 0.25
        _VignetteIntensity ("Vignette Intensity", Range(0,1)) = 0.8
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        float4 _Color;

        float _NoiseScale;
        float _NoiseStrength;

        float _VignetteRadius;
        float _VignetteSoftness;
        float _VignetteIntensity;

        struct Input
        {
            float2 uv_MainTex;
        };

        // ---------------------------------------------------------
        // 2D GRADIENT NOISE (Perlin-style)
        // ---------------------------------------------------------

        float2 hash(float2 p)
        {
            p = float2(dot(p, float2(127.1, 311.7)),
                       dot(p, float2(269.5, 183.3)));
            return frac(sin(p) * 43758.5453) * 2.0 - 1.0;
        }

        float gradientNoise(float2 uv)
        {
            float2 i = floor(uv);
            float2 f = frac(uv);

            float2 g00 = normalize(hash(i + float2(0,0)));
            float2 g10 = normalize(hash(i + float2(1,0)));
            float2 g01 = normalize(hash(i + float2(0,1)));
            float2 g11 = normalize(hash(i + float2(1,1)));

            float n00 = dot(g00, f - float2(0,0));
            float n10 = dot(g10, f - float2(1,0));
            float n01 = dot(g01, f - float2(0,1));
            float n11 = dot(g11, f - float2(1,1));

            float2 u = f * f * (3.0 - 2.0 * f);

            return lerp(lerp(n00, n10, u.x),
                        lerp(n01, n11, u.x),
                        u.y);
        }

        // ---------------------------------------------------------

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 uv = IN.uv_MainTex;

            float4 c = tex2D(_MainTex, uv) * _Color;

            // --- CIRCULAR VIGNETTE ---
            float2 center = float2(0.5, 0.5);
            float dist = distance(uv, center);

            float vignette = smoothstep(_VignetteRadius, _VignetteRadius + _VignetteSoftness, dist);

            // --- PROCEDURAL GRADIENT NOISE ---
            float n = gradientNoise(uv * _NoiseScale);

            // Normalize noise from [-1,1] to [0,1]
            n = n * 0.5 + 0.5;

            // Blend noise into vignette
            vignette *= lerp(1.0, n, _NoiseStrength);

            // Apply intensity
            float finalVignette = lerp(1.0, 1.0 - vignette, _VignetteIntensity);

            c.rgb *= finalVignette;

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }

    FallBack "Diffuse"
}
