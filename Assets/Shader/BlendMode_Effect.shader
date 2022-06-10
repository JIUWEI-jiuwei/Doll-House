Shader "Custom/ImageEffect" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_LuminosityAmount("GrayScale Amount", Range(0.0, 1.0)) = 1.0
			_BlendTex("Blend Texture", 2D) = "white" {}
		_Opacity("Blend Opacity", Range(0.0, 1.0)) = 1.0
	}

		SubShader{
			Pass {
				CGPROGRAM
				#pragma vertex vert_img
				#pragma fragment frag

				#include "UnityCG.cginc"

				uniform sampler2D _MainTex;
				uniform sampler2D _BlendTex;
				fixed _LuminosityAmount;
				fixed _Opacity;
			
				fixed4 frag(v2f_img i) : COLOR
				{
				//Get the colors from the RenderTexture and the uv's
				//from the v2f_img struct
				fixed4 renderTex = tex2D(_MainTex, i.uv);
				fixed4 blendTex = tex2D(_BlendTex, i.uv);

				// Perform a multiply Blend mode
				fixed4 blendedMultiply = renderTex * blendTex;

				// Adjust amount of Blend Mode with a lerp
				renderTex = lerp(renderTex, blendedMultiply,  _Opacity);

				return renderTex;
			}

			ENDCG
		}
		}
			FallBack "Diffuse"
}
