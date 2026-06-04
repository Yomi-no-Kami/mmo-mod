Shader "Custom/Particle (Unlit)" {
	Properties {
		[NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
		[Enum(UnityEngine.Rendering.BlendMode)] _SrcBlend ("Source Blend", Float) = 0
		[Enum(UnityEngine.Rendering.BlendMode)] _DstBlend ("Destination Blend", Float) = 0
		[Enum(Red,0,Green,1,Blue,2,Alpha,3)] _AlphaChannel ("Alpha Channel", Float) = 0
		[Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 2
		[MaterialToggle] _SkyMask ("SkyMask", Float) = 0
		[Toggle] _SoftParticles ("Soft Particles", Float) = 0
		_SoftFadeFactor ("Fade Factor", Float) = 1
		_SoftNearFade ("Near Soft", Float) = 0.5
		_CameraFadeFactor ("Camera Fade Factor", Float) = 1
		[Toggle] _FejdFog ("Enable Fog", Float) = 0
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4x4 unity_ObjectToWorld;
			float4x4 unity_MatrixVP;
			float4 _MainTex_ST;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct Vertex_Stage_Output
			{
				float2 uv : TEXCOORD0;
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.uv = (input.uv.xy * _MainTex_ST.xy) + _MainTex_ST.zw;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			Texture2D<float4> _MainTex;
			SamplerState sampler_MainTex;

			struct Fragment_Stage_Input
			{
				float2 uv : TEXCOORD0;
			};

			float4 frag(Fragment_Stage_Input input) : SV_TARGET
			{
				return _MainTex.Sample(sampler_MainTex, input.uv.xy);
			}

			ENDHLSL
		}
	}
}