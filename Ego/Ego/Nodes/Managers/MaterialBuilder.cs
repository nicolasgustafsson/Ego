using System.Buffers;
using Rendering;
using Rendering.Materials;
using Vortice.Vulkan;
using VulkanApi;

namespace Ego;

[Node(AllowAddingToScene = false)]
public partial class MaterialBuilder : Node
{
    private GraphicsPipeline OpaquePipeline = null!;
    private GraphicsPipeline TransparentPipeline = null!;
    private ShaderObject.Shader OpaqueVertexShader = null!;
    private ShaderObject.Shader OpaqueFragmentShader = null!;

    private VkDescriptorSetLayout MaterialLayout;
    private DescriptorWriter DescriptorWriter = new();
    
    public struct MaterialConstants 
    {
        public Vector4 Color;
        public Vector4 MetallicRoughness;
        public int ColorTexture;

        //This has to have an alignment of 256 for whichever reason https://vkguide.dev/docs/new_chapter_4/materials/
        /*public Vector4 Padding1;
        public Vector4 Padding2;
        public Vector4 Padding3;
        public Vector4 Padding4;
        public Vector4 Padding5;
        public Vector4 Padding6;
        public Vector4 Padding7;
        public Vector4 Padding8;
        public Vector4 Padding9;
        public Vector4 Padding10;
        public Vector4 Padding11;
        public Vector4 Padding12;
        public Vector4 Padding13;
        public Vector4 Padding14;*/
    }
    
    public override void Start()
    {
        base.Start();

    }
    public Material CreateMaterial(MaterialPassType aPassType, Image aColorImage, Sampler aColorSampler, Image aMetallicRoughnessImage, Sampler aMetallicRoughnessSampler, GpuBuffer<MaterialConstants> aBuffer, int aBufferOffset, DescriptorAllocatorGrowable aDescriptorAllocator)
    {
        Material material = new();

        material.VertexShader = OpaqueVertexShader;
        material.FragmentShader = OpaqueFragmentShader;

        material.PassType = aPassType;
        material.UniformBuffer = aBuffer;

        DescriptorWriter.Clear();
        DescriptorWriter.WriteImage(1, aColorImage.ImageView, aColorSampler, VkImageLayout.ReadOnlyOptimal, VkDescriptorType.CombinedImageSampler);
        DescriptorWriter.WriteImage(2, aMetallicRoughnessImage.ImageView, aMetallicRoughnessSampler, VkImageLayout.ReadOnlyOptimal, VkDescriptorType.CombinedImageSampler);


        return material;
    }
}