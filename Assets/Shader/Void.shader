Shader "Custom/PitchBlackLit"
{
    Properties
    {
        _Glossiness ("Smoothness", Range(0,1)) = 0.0
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        float _Glossiness;
        float _Metallic;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Force albedo to pure black
            o.Albedo = float3(0,0,0);

            // Optional: keep smoothness/metallic if you want reflections
            o.Smoothness = _Glossiness;
            o.Metallic = _Metallic;

            // Alpha not needed for opaque
            o.Alpha = 1;
        }
        ENDCG
    }

    FallBack "Diffuse"
}
