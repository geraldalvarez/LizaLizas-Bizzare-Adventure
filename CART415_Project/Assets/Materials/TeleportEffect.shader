Shader "Hidden/TeleportEffect"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Texture", 2D) = "white" {}

		[Space(20)]
		_DissolveMap("Dissolve", 2D) = "white" {}
	}
		SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 color : COLOR;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
			};
			fixed4 _Color;
			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.color = v.color * _Color;
				return o;
			}

			sampler2D _MainTex;
			sampler2D _DissolveMap;
			half _DissolveAmount;
			//faded
			float4 fadeColor;

			fixed4 frag(v2f i) : SV_Target
			{
				half a = fadeColor.a;

				//clipping the mask 
				fixed4 col = tex2D(_MainTex, i.uv) * i.color;
				fixed4 diss = tex2D(_DissolveMap, i.uv) * (fadeColor.rgba * a);
				col -= diss;

				return col;
			}
		ENDCG
	}
	}
}
