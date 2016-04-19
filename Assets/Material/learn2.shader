﻿Shader "unityCookie/tut/intro/2- FlatColor"{
	Properties
	{
		_Color ("Color", Color) = (1.0,1.0,1.0,1.0)
	}

	SubShader
	{
		Pass
		{
			Tags { "LightMode" = "ForwardBase" }

			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			
			//user define variables
			uniform float4 _Color;

			//unity defined variables.
			uniform float4 _LightColor0;

			//base input struct
			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 col : COLOR;
			};

			//vertex functions
			vertexOutput vert(vertexInput v)
			{
				vertexOutput o;

				float3 normalDirection = normalize( mul( float4( v.normal, 0.0), _World2Object).xyz);
				float3 lightDirection;
				float atten = 1.0;

				lightDirection = normalize( _WorldSpaceLightPos0.xyz );

				float3 diffuseReflection = atten * _LightColor0.xyz * _Color.rgb * max(0.0,  dot(normalDirection, lightDirection) );

				o.col = float4( diffuseReflection, 1.0);
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);

				return o;
			}

			//fragment function
			float4 frag(vertexOutput i) : COLOR
			{
				return i.col;
			}

			ENDCG
		}
	}
}