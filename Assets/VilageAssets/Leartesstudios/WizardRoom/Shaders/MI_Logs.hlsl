#define NUM_TEX_COORD_INTERPOLATORS 1
#define NUM_CUSTOM_VERTEX_INTERPOLATORS 0

struct Input
{
	//float3 Normal;
	float2 uv_MainTex : TEXCOORD0;
	float2 uv2_Material_Texture2D_0 : TEXCOORD1;
	float4 color : COLOR;
	float4 tangent;
	//float4 normal;
	float3 viewDir;
	float4 screenPos;
	float3 worldPos;
	//float3 worldNormal;
	float3 normal2;
};
struct SurfaceOutputStandard
{
	float3 Albedo;		// base (diffuse or specular) color
	float3 Normal;		// tangent space normal, if written
	half3 Emission;
	half Metallic;		// 0=non-metal, 1=metal
	// Smoothness is the user facing name, it should be perceptual smoothness but user should not have to deal with it.
	// Everywhere in the code you meet smoothness it is perceptual smoothness
	half Smoothness;	// 0=rough, 1=smooth
	half Occlusion;		// occlusion (default 1)
	float Alpha;		// alpha for transparencies
};

//#define Texture2D sampler2D
//#define TextureCube samplerCUBE
//#define SamplerState int
#define HDRP 1
//struct Material
//{
	//samplers start
SAMPLER( SamplerState_Linear_Repeat );
TEXTURE2D(       Material_Texture2D_0 );
SAMPLER( sampler_Material_Texture2D_0);
TEXTURE2D(       Material_Texture2D_1 );
SAMPLER( sampler_Material_Texture2D_1);
TEXTURE2D(       Material_Texture2D_2 );
SAMPLER( sampler_Material_Texture2D_2);
TEXTURE2D(       Material_Texture2D_3 );
SAMPLER( sampler_Material_Texture2D_3);
TEXTURE2D(       Material_Texture2D_4 );
SAMPLER( sampler_Material_Texture2D_4);

//};
struct MaterialStruct
{
	float4 VectorExpressions[78 ];
	float4 ScalarExpressions[31 ];
};
SamplerState View_MaterialTextureBilinearWrapedSampler;
SamplerState View_MaterialTextureBilinearClampedSampler;
struct ViewStruct
{
	float GameTime;
	float MaterialTextureMipBias;	
	float4 PrimitiveSceneData[ 40 ];
	float2 TemporalAAParams;
	float2 ViewRectMin;
	float4 ViewSizeAndInvSize;
	float MaterialTextureDerivativeMultiply;
};
struct ResolvedViewStruct
{
	float3 WorldCameraOrigin;
	float4 ScreenPositionScaleBias;
	float4x4 TranslatedWorldToView;
	float4x4 TranslatedWorldToCameraView;
	float4x4 ViewToTranslatedWorld;
	float4x4 CameraViewToTranslatedWorld;
};
struct PrimitiveStruct
{
	float4x4 WorldToLocal;
	float4x4 LocalToWorld;
};

static ViewStruct View;
static ResolvedViewStruct ResolvedView;
static PrimitiveStruct Primitive;
uniform float4 View_BufferSizeAndInvSize;
uniform int Material_Wrap_WorldGroupSettings;

#include "UnrealCommon.cginc"

MaterialStruct Material;
void InitializeExpressions()
{
	Material.VectorExpressions[0] = float4(0.000000,0.000000,0.000000,0.000000);//SelectionColor
	Material.VectorExpressions[1] = float4(0.000000,0.000000,0.000000,0.000000);//(Unknown)
	Material.VectorExpressions[2] = float4(1.000000,1.000000,1.000000,1.000000);//Base Tint
	Material.VectorExpressions[3] = float4(1.000000,1.000000,1.000000,0.000000);//(Unknown)
	Material.VectorExpressions[4] = float4(0.000000,0.000000,0.000000,1.000000);//(Unknown)
	Material.VectorExpressions[5] = float4(0.000000,0.000000,0.000000,1.000000);//SSScolor
	Material.VectorExpressions[6] = float4(0.000000,0.000000,0.000000,0.000000);//(Unknown)
	Material.ScalarExpressions[0] = float4(1.000000,0.000000,1.000000,0.000000);//UV Tiling NormalStrength EmissivePower (Unknown)
	Material.ScalarExpressions[1] = float4(1.000000,6.283185,1.000000,0.000000);//HueShift (Unknown) Base Color Multiply Base Color Tint Amount
	Material.ScalarExpressions[2] = float4(0.000000,0.000000,0.000000,0.000000);//Desaturation Amount __SubsurfaceProfile (Unknown) (Unknown)
}void CalcPixelMaterialInputs(in out FMaterialPixelParameters Parameters, in out FPixelMaterialInputs PixelMaterialInputs)
{
	float3 WorldNormalCopy = Parameters.WorldNormal;

	// Initial calculations (required for Normal)
	MaterialFloat2 Local0 = (Parameters.TexCoords[0].xy * Material.ScalarExpressions[0].x);
	MaterialFloat Local1 = MaterialStoreTexCoordScale(Parameters, Local0, 3);
	MaterialFloat4 Local2 = UnpackNormalMap(Texture2DSampleBias(Material_Texture2D_0, sampler_Material_Texture2D_0,Local0,View.MaterialTextureMipBias));
	MaterialFloat Local3 = MaterialStoreTexSample(Parameters, Local2, 3);
	MaterialFloat2 Local4 = (Local2.rgb.rg * Material.ScalarExpressions[0].y);

	// The Normal is a special case as it might have its own expressions and also be used to calculate other inputs, so perform the assignment here
	PixelMaterialInputs.Normal = MaterialFloat3(Local4,Local2.rgb.b);


	// Note that here MaterialNormal can be in world space or tangent space
	float3 MaterialNormal = GetMaterialNormal(Parameters, PixelMaterialInputs);

#if MATERIAL_TANGENTSPACENORMAL
#if SIMPLE_FORWARD_SHADING
	Parameters.WorldNormal = float3(0, 0, 1);
#endif

#if FEATURE_LEVEL >= FEATURE_LEVEL_SM4
	// Mobile will rely on only the final normalize for performance
	MaterialNormal = normalize(MaterialNormal);
#endif

	// normalizing after the tangent space to world space conversion improves quality with sheared bases (UV layout to WS causes shrearing)
	// use full precision normalize to avoid overflows
	Parameters.WorldNormal = TransformTangentNormalToWorld(Parameters.TangentToWorld, MaterialNormal);

#else //MATERIAL_TANGENTSPACENORMAL

	Parameters.WorldNormal = normalize(MaterialNormal);

#endif //MATERIAL_TANGENTSPACENORMAL

#if MATERIAL_TANGENTSPACENORMAL
	// flip the normal for backfaces being rendered with a two-sided material
	Parameters.WorldNormal *= Parameters.TwoSidedSign;
#endif

	Parameters.ReflectionVector = ReflectionAboutCustomWorldNormal(Parameters, Parameters.WorldNormal, false);

#if !PARTICLE_SPRITE_FACTORY
	Parameters.Particle.MotionBlurFade = 1.0f;
#endif // !PARTICLE_SPRITE_FACTORY

	// Now the rest of the inputs
	MaterialFloat Local5 = MaterialStoreTexCoordScale(Parameters, Local0, 6);
	MaterialFloat4 Local6 = ProcessMaterialColorTextureLookup(Texture2DSampleBias(Material_Texture2D_1, sampler_Material_Texture2D_1,Local0,View.MaterialTextureMipBias));
	MaterialFloat Local7 = MaterialStoreTexSample(Parameters, Local6, 6);
	MaterialFloat3 Local8 = (Local6.rgb * Material.ScalarExpressions[0].z);
	MaterialFloat3 Local9 = lerp(Local8,Material.VectorExpressions[1].rgb,MaterialFloat(Material.ScalarExpressions[0].w));
	MaterialFloat Local10 = MaterialStoreTexCoordScale(Parameters, Local0, 2);
	MaterialFloat4 Local11 = ProcessMaterialColorTextureLookup(Texture2DSampleBias(Material_Texture2D_2, sampler_Material_Texture2D_2,Local0,View.MaterialTextureMipBias));
	MaterialFloat Local12 = MaterialStoreTexSample(Parameters, Local11, 2);
	MaterialFloat3 Local13 = (Local11.rgb * Material.ScalarExpressions[1].z);
	MaterialFloat3 Local14 = (1.00000000 - Local13);
	MaterialFloat3 Local15 = (Local14 * 2.00000000);
	MaterialFloat3 Local16 = (Local15 * Material.VectorExpressions[4].rgb);
	MaterialFloat3 Local17 = (1.00000000 - Local16);
	MaterialFloat3 Local18 = (Local13 * 2.00000000);
	MaterialFloat3 Local19 = (Local18 * Material.VectorExpressions[3].rgb);
	MaterialFloat Local20 = ((Local13.r >= 0.50000000) ? Local17.r : Local19.r);
	MaterialFloat Local21 = ((Local13.g >= 0.50000000) ? Local17.g : Local19.g);
	MaterialFloat Local22 = ((Local13.b >= 0.50000000) ? Local17.b : Local19.b);
	MaterialFloat3 Local23 = lerp(Local11.rgb,MaterialFloat3(MaterialFloat2(Local20,Local21),Local22),MaterialFloat(Material.ScalarExpressions[1].w));
	MaterialFloat3 Local24 = RotateAboutAxis(MaterialFloat4((MaterialFloat3(1.00000000,1.00000000,1.00000000) / sqrt(dot(MaterialFloat3(1.00000000,1.00000000,1.00000000),MaterialFloat3(1.00000000,1.00000000,1.00000000)))),Material.ScalarExpressions[1].y),MaterialFloat3(0.00000000,0.00000000,0.00000000),Local23);
	MaterialFloat3 Local25 = (Local24 + Local23);
	MaterialFloat Local26 = dot(Local25, MaterialFloat3(0.30000001,0.58999997,0.11000000));
	MaterialFloat3 Local27 = lerp(Local25,MaterialFloat3(Local26,Local26,Local26),MaterialFloat(Material.ScalarExpressions[2].x));
	MaterialFloat Local28 = MaterialStoreTexCoordScale(Parameters, Local0, 0);
	MaterialFloat4 Local29 = ProcessMaterialColorTextureLookup(Texture2DSampleBias(Material_Texture2D_3, sampler_Material_Texture2D_3,Local0,View.MaterialTextureMipBias));
	MaterialFloat Local30 = MaterialStoreTexSample(Parameters, Local29, 0);
	MaterialFloat Local31 = MaterialStoreTexCoordScale(Parameters, Local0, 1);
	MaterialFloat4 Local32 = ProcessMaterialColorTextureLookup(Texture2DSampleBias(Material_Texture2D_4, sampler_Material_Texture2D_4,Local0,View.MaterialTextureMipBias));
	MaterialFloat Local33 = MaterialStoreTexSample(Parameters, Local32, 1);

	PixelMaterialInputs.EmissiveColor = Local9;
	PixelMaterialInputs.Opacity = 1.00000000;
	PixelMaterialInputs.OpacityMask = Local32.rgb;
	PixelMaterialInputs.BaseColor = Local27;
	PixelMaterialInputs.Metallic = Local29.b;
	PixelMaterialInputs.Specular = 0.50000000;
	PixelMaterialInputs.Roughness = Local29.g;
	PixelMaterialInputs.Anisotropy = 0.00000000;
	PixelMaterialInputs.Tangent = MaterialFloat3(1.00000000,0.00000000,0.00000000);
	PixelMaterialInputs.Subsurface = MaterialFloat4(Material.VectorExpressions[6].rgb,Material.ScalarExpressions[2].y);
	PixelMaterialInputs.AmbientOcclusion = Local29.r;
	PixelMaterialInputs.Refraction = 0;
	PixelMaterialInputs.PixelDepthOffset = 0.00000000;
	PixelMaterialInputs.ShadingModel = 2;


#if MATERIAL_USES_ANISOTROPY
	Parameters.WorldTangent = CalculateAnisotropyTangent(Parameters, PixelMaterialInputs);
#else
	Parameters.WorldTangent = 0;
#endif
}

#define UnityObjectToWorldDir TransformObjectToWorld
void SurfaceReplacement( Input In, out SurfaceOutputStandard o )
{
	InitializeExpressions();

	float3 Z3 = float3( 0, 0, 0 );
	float4 Z4 = float4( 0, 0, 0, 0 );

	float3 UnrealWorldPos = float3( In.worldPos.x, In.worldPos.y, In.worldPos.z );

	float3 UnrealNormal = In.normal2;

	FMaterialPixelParameters Parameters = (FMaterialPixelParameters)0;
#if NUM_TEX_COORD_INTERPOLATORS > 0			
	Parameters.TexCoords[ 0 ] = float2( In.uv_MainTex.x, In.uv_MainTex.y );
#endif
#if NUM_TEX_COORD_INTERPOLATORS > 1
	Parameters.TexCoords[ 1 ] = float2( In.uv2_Material_Texture2D_0.x, 1.0 - In.uv2_Material_Texture2D_0.y );
#endif
#if NUM_TEX_COORD_INTERPOLATORS > 2
	for( int i = 2; i < NUM_TEX_COORD_INTERPOLATORS; i++ )
	{
		Parameters.TexCoords[ i ] = float2( In.uv_MainTex.x, In.uv_MainTex.y );
	}
#endif
	Parameters.VertexColor = In.color;
	Parameters.WorldNormal = UnrealNormal;
	Parameters.ReflectionVector = half3( 0, 0, 1 );
	Parameters.CameraVector = normalize( _WorldSpaceCameraPos.xyz - UnrealWorldPos.xyz );
	//Parameters.CameraVector = mul( ( float3x3 )unity_CameraToWorld, float3( 0, 0, 1 ) ) * -1;
	Parameters.LightVector = half3( 0, 0, 0 );
	float4 screenpos = In.screenPos;
	screenpos /= screenpos.w;
	//screenpos.y = 1 - screenpos.y;
	Parameters.SvPosition = float4( screenpos.x, screenpos.y, 0, 0 );
	Parameters.ScreenPosition = Parameters.SvPosition;

	Parameters.UnMirrored = 1;

	Parameters.TwoSidedSign = 1;


	float3 InWorldNormal = UnrealNormal;
	float4 InTangent = In.tangent;
	float4 tangentWorld = float4( UnityObjectToWorldDir( InTangent.xyz ), InTangent.w );
	tangentWorld.xyz = normalize( tangentWorld.xyz );
	//float3x3 tangentToWorld = CreateTangentToWorldPerVertex( InWorldNormal, tangentWorld.xyz, tangentWorld.w );
	Parameters.TangentToWorld = float3x3( Z3, Z3, Z3 );// tangentToWorld;

	//WorldAlignedTexturing in UE relies on the fact that coords there are 100x larger, prepare values for that
	//but watch out for any computation that might get skewed as a side effect
	UnrealWorldPos = UnrealWorldPos * 100;

	//Parameters.TangentToWorld = half3x3( float3( 1, 1, 1 ), float3( 1, 1, 1 ), UnrealNormal.xyz );
	Parameters.AbsoluteWorldPosition = UnrealWorldPos;
	Parameters.WorldPosition_CamRelative = UnrealWorldPos;
	Parameters.WorldPosition_NoOffsets = UnrealWorldPos;

	Parameters.WorldPosition_NoOffsets_CamRelative = Parameters.WorldPosition_CamRelative;
	Parameters.LightingPositionOffset = float3( 0, 0, 0 );

	Parameters.AOMaterialMask = 0;

	Parameters.Particle.RelativeTime = 0;
	Parameters.Particle.MotionBlurFade;
	Parameters.Particle.Random = 0;
	Parameters.Particle.Velocity = half4( 1, 1, 1, 1 );
	Parameters.Particle.Color = half4( 1, 1, 1, 1 );
	Parameters.Particle.TranslatedWorldPositionAndSize = float4( UnrealWorldPos, 0 );
	Parameters.Particle.MacroUV = half4( 0, 0, 1, 1 );
	Parameters.Particle.DynamicParameter = half4( 0, 0, 0, 0 );
	Parameters.Particle.LocalToWorld = float4x4( Z4, Z4, Z4, Z4 );
	Parameters.Particle.Size = float2( 1, 1 );
	Parameters.TexCoordScalesParams = float2( 0, 0 );
	Parameters.PrimitiveId = 0;

	FPixelMaterialInputs PixelMaterialInputs = (FPixelMaterialInputs)0;
	PixelMaterialInputs.Normal = float3( 0, 0, 1 );
	PixelMaterialInputs.ShadingModel = 0;

	//Extra
	View.GameTime = -_Time.y;// _Time is (t/20, t, t*2, t*3), run in reverse because it works better with ElementalDemo
	View.MaterialTextureMipBias = 0.0;
	View.TemporalAAParams = float2( 0, 0 );
	View.ViewRectMin = float2( 0, 0 );
	View.ViewSizeAndInvSize = View_BufferSizeAndInvSize;
	View.MaterialTextureDerivativeMultiply = 1.0f;
	for( int i2 = 0; i2 < 40; i2++ )
		View.PrimitiveSceneData[ i2 ] = float4( 0, 0, 0, 0 );

	uint PrimitiveBaseOffset = Parameters.PrimitiveId * PRIMITIVE_SCENE_DATA_STRIDE;
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 0 ] = UNITY_MATRIX_M[ 0 ];//LocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 1 ] = UNITY_MATRIX_M[ 1 ];//LocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 2 ] = UNITY_MATRIX_M[ 2 ];//LocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 3 ] = UNITY_MATRIX_M[ 3 ];//LocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 6 ] = UNITY_MATRIX_I_M[ 0 ];//WorldToLocal
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 7 ] = UNITY_MATRIX_I_M[ 1 ];//WorldToLocal
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 8 ] = UNITY_MATRIX_I_M[ 2 ];//WorldToLocal
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 9 ] = UNITY_MATRIX_I_M[ 3 ];//WorldToLocal
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 10 ] = UNITY_MATRIX_I_M[ 0 ];//PreviousLocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 11 ] = UNITY_MATRIX_I_M[ 1 ];//PreviousLocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 12 ] = UNITY_MATRIX_I_M[ 2 ];//PreviousLocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 13 ] = UNITY_MATRIX_I_M[ 3 ];//PreviousLocalToWorld

	ResolvedView.WorldCameraOrigin = _WorldSpaceCameraPos.xyz;
	ResolvedView.ScreenPositionScaleBias = float4( 1, 1, 0, 0 );
	ResolvedView.TranslatedWorldToView = UNITY_MATRIX_V;
	ResolvedView.TranslatedWorldToCameraView = UNITY_MATRIX_V;
	ResolvedView.ViewToTranslatedWorld = UNITY_MATRIX_I_V;
	ResolvedView.CameraViewToTranslatedWorld = UNITY_MATRIX_I_V;
	Primitive.WorldToLocal = UNITY_MATRIX_I_M;
	Primitive.LocalToWorld = UNITY_MATRIX_M;
	CalcPixelMaterialInputs( Parameters, PixelMaterialInputs );

	#define HAS_WORLDSPACE_NORMAL 0
	#if HAS_WORLDSPACE_NORMAL
		PixelMaterialInputs.Normal = mul( PixelMaterialInputs.Normal, (MaterialFloat3x3)( transpose( Parameters.TangentToWorld ) ) );
	#endif

	o.Albedo = PixelMaterialInputs.BaseColor.rgb;
	o.Alpha = PixelMaterialInputs.Opacity;
	if( PixelMaterialInputs.OpacityMask < 0.333 ) discard;

	o.Metallic = PixelMaterialInputs.Metallic;
	o.Smoothness = 1.0 - PixelMaterialInputs.Roughness;
	o.Normal = normalize( PixelMaterialInputs.Normal );
	o.Emission = PixelMaterialInputs.EmissiveColor.rgb;
	o.Occlusion = PixelMaterialInputs.AmbientOcclusion;
}