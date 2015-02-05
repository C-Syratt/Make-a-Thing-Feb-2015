Shader "Custom/HealthTextureMix" {
	Properties {
		_MainTex ("Main Texture", 2D) = "white" {}
		_SecondTex ("Second Texture", 2D) = "white" {}
		_HealthBarMix ("Health Bar Wipe", Range (-5,5)) = 0
	}
	SubShader {
		Tags { "RenderType"="Geometry" }
		
		Pass
		{
		
		CGPROGRAM
		#pragma exclude_renderers ps3 xbox360 flash
		#pragma vertex vert
		#pragma fragment frag
		
		#include "UnityCG.cginc"

		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform sampler2D _SecondTex;
		uniform float4 _SecondTex_ST;
		uniform half _HealthBarMix;
		

			struct VertexInput {
					float4 vertex : POSITION;
					float4 texcoord : TEXCOORD0;
				};
			struct VertexOutput {
				float4 pos : SV_POSITION;
				half2 uv : TEXCOORD0;
				half2 uv2 : TEXCOORD1;
				fixed2 localPos : TEXCOORD2;
				
			};

			VertexOutput vert(VertexInput i)
			{
				VertexOutput o;
				o.localPos = i.vertex.xy; // + fixed2 (0.5, 0.5);
				o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
				o.uv = TRANSFORM_TEX (i.texcoord, _MainTex);
				o.uv2 = TRANSFORM_TEX (i.texcoord, _SecondTex);
				
				return o;
			}

			float4 frag(VertexOutput i) : COLOR {
				
				fixed4 mainTexColour = tex2D (_MainTex, i.uv);
				fixed4 secondTexColour = tex2D (_SecondTex, i.uv2);
				
				if(i.localPos.x < _HealthBarMix)
				{
					return mainTexColour;
				}
				else 
				{
					return secondTexColour;
				}
			}
			ENDCG
		}
	}

}
