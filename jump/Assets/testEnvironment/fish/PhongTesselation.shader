Shader "Custom/Phong Tessellation" {
	Properties{
		_EdgeLength("Edge length", Range(2,50)) = 5
		_Phong("Phong Strengh", Range(0,1)) = 0.5
		_MainTex("Albedo Texture", 2D) = "white" {}
		_Transparency("Transparency", Range(0.0,1.0)) = 0.5
		_Color("Color (RGBA)", color) = (1,1,1,1)
		_Multiplier("Multiplier", Float) = 3.141
		_Strength("Strength", Float) = 3.141
		_Jigglyness("Jigglyness", Float) = 3.141
		
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 300
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
		#pragma surface surf Lambert vertex:dispNone tessellate:tessEdge tessphong:_Phong nolightmap alpha:premul
		

		#include "Tessellation.cginc"
		//#include "UnityCG.cginc"

		struct v2f {
			float4 pos : SV_POSITION;
			float2 uv : TEXCOORD0;
			fixed4 color : COLOR;
		};

		float _Multiplier;
		float _Jigglyness;
		float _Strength;
		float _Transparency;

		struct appdata {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
			float2 texcoord : TEXCOORD0;
		};

		void dispNone(inout appdata v) { 
			float4 vert = v.vertex;
			vert.x += sin(vert.y * _Time * _Jigglyness + (_Multiplier * _Time)) * _Strength;
			vert.z += sin(vert.y * _Time * _Jigglyness + (_Multiplier * _Time)) * _Strength;
			v.vertex = vert;
		}

		float _Phong;
		float _EdgeLength;

		float4 tessEdge(appdata v0, appdata v1, appdata v2)
		{
			return UnityEdgeLengthBasedTess(v0.vertex, v1.vertex, v2.vertex, _EdgeLength);
		}

		struct Input {
			float2 uv_MainTex;
		};

		fixed4 _Color;
		sampler2D _MainTex;

		void surf(Input IN, inout SurfaceOutput o) {
			half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			
			o.Albedo = c.rgb;
			o.Alpha = _Transparency;
		}

	
		ENDCG
	}

	FallBack "Diffuse"
}