Shader "Learning/guacaipiao"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
    // �����Ⱦ��RenderTexture
    _BlitTex("BlitTexture", 2D) = "white" {}
    }
        SubShader
    {
        Tags{"Queue" = "AlphaTest" "IgnoreProjector" = "True" "RenderType" = "TransparentCutout"}
        Cull Off
        Pass
        {
            Tags{"LightMode" = "ForwardBase"}

            // ����alpah���
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Lighting.cginc"
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _BlitTex;

            struct a2v
            {
                float4 vertex : POSITION;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float2 uv : TEXCOORD2;
                float4 paintPos : TEXCOORD3;
            };

            // �����ͶӰ����
            // C#��ͨ��SetMatrix����
            // material.SetMatrix("paintCameraVP", camera.nonJitteredProjectionMatrix * camera.worldToCameraMatrix);
            float4x4 paintCameraVP;

            v2f vert(a2v v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);

                // ����������ͨ��ͶӰ���󽫶���任����������ϵ��([0, 1])
                float4 paintPos = mul(paintCameraVP, mul(unity_ObjectToWorld, v.vertex));
                paintPos /= paintPos.w; // ����w������������������ͶӰ����ʡ��
                o.paintPos.xy = paintPos.xy * 0.5 + 0.5; // ��[-1, 1] �任�� [0, 1]
                return o;
            }

            fixed4 frag(v2f i) : SV_TARGET0
            {
                fixed4 texcolor = tex2D(_MainTex,i.uv);
            // �����Ĺ켣rֵΪ1������1 - r��ΪԭͼƬ��alphaֵ���
            float mask = tex2D(_BlitTex, i.paintPos).r;
            return fixed4(texcolor.rgb, 1 - mask);
        }
        ENDCG
    }
    }
}
