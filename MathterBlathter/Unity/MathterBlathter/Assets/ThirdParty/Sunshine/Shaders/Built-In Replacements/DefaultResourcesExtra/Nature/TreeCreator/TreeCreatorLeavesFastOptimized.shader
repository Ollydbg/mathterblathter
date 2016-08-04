Shader "Hidden/Nature/Tree Creator Leaves Fast Optimized" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_TranslucencyColor ("Translucency Color", Color) = (0.73,0.85,0.41,1) // (187,219,106,255)
	_Cutoff ("Alpha cutoff", Range(0,1)) = 0.3
	_TranslucencyViewDependency ("View dependency", Range(0,1)) = 0.7
	_ShadowStrength("Shadow Strength", Range(0,1)) = 1.0
	
	_MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
	_ShadowTex ("Shadow (RGB)", 2D) = "white" {}

	// These are here only to provide default values
	[HideInInspector] _TreeInstanceColor ("TreeInstanceColor", Vector) = (1,1,1,1)
	[HideInInspector] _TreeInstanceScale ("TreeInstanceScale", Vector) = (1,1,1,1)
	[HideInInspector] _SquashAmount ("Squash", Float) = 1
}

SubShader { 
	Tags {
		"IgnoreProjector"="True"
		"RenderType" = "TreeLeaf"
	}
	LOD 200

	Pass {
		Tags { "LightMode" = "ForwardBase" }
		Name "ForwardBase"

	CGPROGRAM
		#include "UnityBuiltin3xTreeLibrary.cginc"

		#pragma vertex VertexLeaf
		#pragma fragment FragmentLeaf
		#pragma multi_compile_fwdbase nolightmap
		#pragma multi_compile_fog
		
		#include "Assets/Sunshine/Shaders/Sunshine.cginc"
		//Leaves don't require higher quality filters:
		#pragma multi_compile SUNSHINE_DISABLED SUNSHINE_FILTER_PCF_2x2 SUNSHINE_FILTER_HARD
		#pragma target 3.0
		
		sampler2D _MainTex;
		float4 _MainTex_ST;

		fixed _Cutoff;
		sampler2D _ShadowMapTexture;

		struct v2f_leaf {
			float4 pos : SV_POSITION;
			fixed4 diffuse : COLOR0;
		#if defined(SHADOWS_SCREEN)
			fixed4 mainLight : COLOR1;
		#endif
			float2 uv : TEXCOORD0;
		#if defined(SHADOWS_SCREEN)
			float4 screenPos : TEXCOORD1;
		#else
			// Specify a Semantic for DX11:
			SUNSHINE_INPUT_PARAMS : TEXCOORD1;
		#endif
			UNITY_FOG_COORDS(2)
		};

		v2f_leaf VertexLeaf (appdata_full v)
		{
			v2f_leaf o;
			TreeVertLeaf(v);
			o.pos = mul(UNITY_MATRIX_MVP, v.vertex);

			fixed ao = v.color.a;
			ao += 0.1; ao = saturate(ao * ao * ao); // emphasize AO

			fixed3 color = v.color.rgb * ao;
			
			float3 worldN = UnityObjectToWorldNormal(v.normal);

			fixed4 mainLight;
			mainLight.rgb = ShadeTranslucentMainLight (v.vertex, worldN) * color;
			mainLight.a = v.color.a;
			o.diffuse.rgb = ShadeTranslucentLights (v.vertex, worldN) * color;
			o.diffuse.a = 1;
		#if defined(SHADOWS_SCREEN)
			o.mainLight = mainLight;
			o.screenPos = ComputeScreenPos (o.pos);
		#else
			o.diffuse += mainLight;
		#endif			
			o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
			UNITY_TRANSFER_FOG(o,o.pos);
			
			#if !defined(SHADOWS_SCREEN)
				SUNSHINE_WRITE_VERTEX(v, o);
			#endif

			return o;
		}

		fixed4 FragmentLeaf (v2f_leaf IN) : SV_Target
		{
			fixed4 albedo = tex2D(_MainTex, IN.uv);
			fixed alpha = albedo.a;
			clip (alpha - _Cutoff);

		#if defined(SHADOWS_SCREEN)
			half4 light = IN.mainLight;
			half atten = tex2Dproj(_ShadowMapTexture, UNITY_PROJ_COORD(IN.screenPos)).r;
			light.rgb *= lerp(1, atten, _ShadowStrength);
			light.rgb += IN.diffuse.rgb;
		#else
			half4 light = IN.diffuse;
			light.rgb *= SunshineLightAttenuation(IN.sunshine_lightData);
		#endif

			fixed4 col = fixed4 (albedo.rgb * light, 0.0);
			UNITY_APPLY_FOG(IN.fogCoord, col);
			return col;
		}

	ENDCG
	}

	// Pass to render object as a shadow caster
	Pass {
		Name "ShadowCaster"
		Tags { "LightMode" = "ShadowCaster" }
		
		ZWrite On ZTest LEqual

	CGPROGRAM
		#pragma vertex vert_surf
		#pragma fragment frag_surf
		#pragma multi_compile_shadowcaster
		#include "HLSLSupport.cginc"
		#include "UnityCG.cginc"
		#include "Lighting.cginc"

		#define INTERNAL_DATA
		#define WorldReflectionVector(data,normal) data.worldRefl

		#include "UnityBuiltin3xTreeLibrary.cginc"

		sampler2D _ShadowTex;

		struct v2f_surf {
			V2F_SHADOW_CASTER;
			float2 hip_pack0 : TEXCOORD1;
		};
		
		float4 _ShadowTex_ST;
		
		v2f_surf vert_surf (appdata_full v) {
			v2f_surf o;
			TreeVertLeaf (v);
			o.hip_pack0.xy = TRANSFORM_TEX(v.texcoord, _ShadowTex);
			TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
			return o;
		}
		
		fixed _Cutoff;
		
		half4 frag_surf (v2f_surf IN) : SV_Target {
			fixed alpha = tex2D(_ShadowTex, IN.hip_pack0.xy).r;
			clip (alpha - _Cutoff);
			SHADOW_CASTER_FRAGMENT(IN)
		}

	ENDCG

	}

}

Dependency "BillboardShader" = "Hidden/Nature/Tree Creator Leaves Rendertex"
}
