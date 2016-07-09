Shader "Sprites/WhiteSpriteShader"
 {
     Properties
     {
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_SelfIllum ("Self Illumination",Range(0.0,1.0)) = 0.0
		_FlashAmount ("Flash Amount",Range(0.0,1.0)) = 0.0
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		
		_BumpScale("Scale", Float) = 1.0
		_BumpMap("Normal Map", 2D) = "bump" {}
		
		_RimColor("Rim Color", Color) = (1.0, 1.0, 1.0, 0.0)
		_RimPower("Rim Power", Range(0.0, 1.0)) = 3.0

		[HideInInspector] _Mode ("__mode", Float) = 0.0
		[HideInInspector] _SrcBlend ("__src", Float) = 1.0
		[HideInInspector] _DstBlend ("__dst", Float) = 0.0
		[HideInInspector] _ZWrite ("__zw", Float) = 1.0

     }
 
     SubShader
     {
		Tags
		{ 
		    "Queue"="Transparent" 
		    "IgnoreProjector"="True" 
		    "RenderType"="Transparent" 
		    "PreviewType"="Plane"
		    "CanUseSpriteAtlas"="True"
		}
		
		Cull Off
		Lighting Off
		ZWrite Off
		Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha
		
		CGPROGRAM
		//#pragma surface surf Lambert alpha vertex:vert
		#pragma surface surf Lambert alpha vertex:vert
		#pragma multi_compile DUMMY PIXELSNAP_ON

		sampler2D _MainTex;
		sampler2D _BumpMap;
		fixed4 _Color;
		float _FlashAmount,_SelfIllum;
		float4 _RimColor;
		float _RimPower;

		struct Input
		{
		    float2 uv_MainTex;
		    float2 uv_BumpMap;
		    float3 viewDir;
		    fixed4 color;
		};
			 
		void vert (inout appdata_full v, out Input o)
		{
		    #if defined(PIXELSNAP_ON) && !defined(SHADER_API_FLASH)
		    v.vertex = UnityPixelSnap (v.vertex);
		    #endif
		    v.normal = float3(0,0,-1);
		    
		    UNITY_INITIALIZE_OUTPUT(Input, o);
		    o.color = _Color;
		}

		void surf (Input IN, inout SurfaceOutput o)
		{
		    fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * IN.color;
		    o.Albedo = lerp(c.rgb,float3(1.0,1.0,1.0),_FlashAmount);
		    //o.Emission = lerp(c.rgb,float3(1.0,1.0,1.0),_FlashAmount) * _SelfIllum;
		    o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

		    half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
		    o.Emission = _RimColor.rgb * pow(rim, _RimPower);


		    o.Alpha = c.a;
		}
		ENDCG
     }
 
 Fallback "Transparent/VertexLit"
 }