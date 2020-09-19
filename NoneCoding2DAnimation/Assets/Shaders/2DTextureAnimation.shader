Shader "bihailvlin/ShaderAnimation"
{
	Properties
	{
		_MainTex("Sequence Frame Image", 2D) = "white" {}   // 序列帧动画纹理
		_Color("Color Tint", Color) = (1, 1, 1, 1)                        // 颜色
		_HorizontalAmount("Horizontal Amount", float) = 4        // 行数
		_VerticalAmount("Vertical Amount", float) = 4               // 列数
		_Speed("Speed", Range(1, 100)) = 30                        // 播放速度
	}

		SubShader
		{
			// 由于序列帧图像通常包含了透明通道，因此可以被当成是一个半透明对象。
			// 在这里我们使用半透明的“标配”来设置它的SubShader 标签，即把Queue 和RenderType 设置成Transparent，
			//把IgnoreProjector 设置为True
			Tags { "RenderType" = "Transparent" "Queue" = "Transparent" "IgnoreProjector" = "True"}
			LOD 100
			Pass
			{
				Tags{"LightMode" = "ForwardBase"}
				// 由于序列帧图像通常是透明纹理，我们需要设置Pass 的相关状态，以渲染透明效果
				   // 在Pass 中，我们使用Blend 命令来开启并设置混合模式，同时关闭了深度写入
				   ZWrite Off
				   Blend SrcAlpha OneMinusSrcAlpha

				   CGPROGRAM
				   #pragma vertex vert
				   #pragma fragment frag

				   #include "UnityCG.cginc"

				   struct appdata
				   {
					   float4 vertex : POSITION;
					   float2 uv : TEXCOORD0;
				   };

				   struct v2f
				   {
					   float2 uv : TEXCOORD0;
					   float4 vertex : SV_POSITION;
				   };

				   sampler2D _MainTex;
				   float4 _MainTex_ST;
				   fixed4 _Color;
				   float _HorizontalAmount;
				   float _VerticalAmount;
				   float _Speed;

				   v2f vert(appdata v)
				   {
					   v2f o;
					   o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					   o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					   return o;
				   }

				   fixed4 frag(v2f i) : SV_Target
				   {
					   float time = floor(_Time.y * _Speed);                 //所经过的时间
					   float row = floor(time / _HorizontalAmount);       // 第几行图片 （和行数不能对应起来）
					   float column = time - row * _HorizontalAmount;  // 第几列图片

					   //每次更新的量
	   				   //float offserX = 1.0 / _HorizontalAmount;  
	   				   //float offserY = 1.0 / _VerticalAmount;
	   				   //half2 uv = float2(i.uv.x * offsetX, i.uv.y*offsetY);

					   //将所显示的图片缩放至应有的大小 （即一个关键帧图像的大小）
					   half2 uv = float2(i.uv.x / _HorizontalAmount, i.uv.y / _VerticalAmount);  // 等价于上面3句

					   //下面方法虽然不能和序列帧动画一一对应，但仍符合序列帧动画的执行顺序
					   uv.x += column / _HorizontalAmount;  // 更换序列帧
					   uv.y -= row / _VerticalAmount;           //等价于uv.y  += 1.0 - row / _VerticalAmount; 

					   // sample the texture
					   fixed4 col = tex2D(_MainTex, uv);
					   col.rgb *= _Color.rgb;                  // 设置纹理颜色
					   return col;
				   }
				   ENDCG
			   }
		}
}
