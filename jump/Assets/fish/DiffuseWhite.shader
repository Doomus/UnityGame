Shader "Custom/Diffuse White"
{
	Properties{
		_Color("Color", Color) = (1, 1, 1, 1)
		_Multiplier("Multiplier", Float) = 3.141
		_Strength("Strength", Float) = 3.141
		_Jigglyness("Jigglyness", Float) = 3.141
	}

		SubShader{
			Pass{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				struct v2f {
					float4 pos : SV_POSITION;
					float2 uv : TEXCOORD0;
					fixed4 color : COLOR;
				};

				float _Multiplier;
				float _Jigglyness;
				float _Strength;

				v2f vert(appdata_full v)
				{
					v2f o;

					float4 vert = v.vertex;
					vert.x += sin(vert.y * _Time * _Jigglyness + (_Multiplier * _Time)) * _Strength;
					vert.z += sin(vert.y * _Time * _Jigglyness + (_Multiplier * _Time)) * _Strength;

					//float2 uv = v.texcoord;
					//uv.x += sin(uv.y * _Time * _Jigglyness + (_Multiplier * _Time)) * _Strength;

					//o.uv = uv;

					o.pos = UnityObjectToClipPos(vert);
					o.color.xyz = v.normal * 0.5 + 0.5;
					o.color.w = 1.0;
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					return i.color; 
				}
			ENDCG
		}
	}
	Fallback "Diffuse"
}