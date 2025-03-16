using System.Buffers;
using System.Security.Cryptography;
using Rendering.Materials;
using Vortice.Vulkan;
using VulkanApi;

namespace Ego;

[Node(AllowAddingToScene = false)]
public partial class MaterialBuilder : Node
{
    private GraphicsPipeline OpaquePipeline = null!;
    private GraphicsPipeline TransparentPipeline = null!;

    private VkDescriptorSetLayout MaterialLayout;
    private DescriptorWriter DescriptorWriter = new();
    
    public struct MaterialConstants 
    {
        public Vector4 Color;
        public Vector4 MetallicRoughness;
        
        //This has to have an alignment of 256 for whichever reason https://vkguide.dev/docs/new_chapter_4/materials/
        public Vector4 Padding1;
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
        public Vector4 Padding14;
    }
    
    public override void Start()
    {
        base.Start();

        BuildDefaultPipelines();
    }
    
    private void BuildDefaultPipelines()
    {
        DescriptorLayoutBuilder descriptorLayoutBuilder = new();
        descriptorLayoutBuilder.AddBinding(0, VkDescriptorType.UniformBuffer);
        descriptorLayoutBuilder.AddBinding(1, VkDescriptorType.CombinedImageSampler);
        descriptorLayoutBuilder.AddBinding(2, VkDescriptorType.CombinedImageSampler);

        MaterialLayout = descriptorLayoutBuilder.Build(VkShaderStageFlags.Vertex | VkShaderStageFlags.Fragment);

        using GraphicsPipeline.GraphicsPipelineBuilder pipelineBuilder = new();
        
        pipelineBuilder.SetVertexShader("Shaders/meshVert.spv");
        pipelineBuilder.SetFragmentShader("Shaders/meshFrag.spv");
        pipelineBuilder.AddPushConstant<MeshPushConstants>(VkShaderStageFlags.Vertex);
        pipelineBuilder.AddDescriptorLayout(RendererApi.Renderer.SceneDataLayout);
        pipelineBuilder.AddDescriptorLayout(MaterialLayout);
        pipelineBuilder.SetTopology(VkPrimitiveTopology.TriangleList);
        pipelineBuilder.SetPolygonMode(VkPolygonMode.Fill);
        pipelineBuilder.SetCullMode(VkCullModeFlags.None, VkFrontFace.Clockwise);
        pipelineBuilder.DisableMultisampling();
        pipelineBuilder.SetBlendMode(BlendMode.Disabled);
        pipelineBuilder.SetDepthTest(VkCompareOp.Greater, true);
        pipelineBuilder.SetDepthFormat(VkFormat.D32Sfloat);
        pipelineBuilder.SetColorAttachmentFormat(RendererApi.Renderer.RenderImage.ImageFormat);

        OpaquePipeline = pipelineBuilder.Build();

                                               //ew
        pipelineBuilder.SetBlendMode(BlendMode.Additive);
            
        pipelineBuilder.SetDepthTest(VkCompareOp.Greater, false);
            
        TransparentPipeline = pipelineBuilder.Build();
    }
    
    public Material CreateMaterial(MaterialPassType aPassType, Image aColorImage, Sampler aColorSampler, Image aMetallicRoughnessImage, Sampler aMetallicRoughnessSampler,  AllocatedBuffer<MaterialConstants> aBuffer, int aBufferOffset, DescriptorAllocatorGrowable aDescriptorAllocator)
    {
        Material material = new();

        material.MyMaterialPassType = aPassType;
        
        if (aPassType == MaterialPassType.Transparent)
            material.Pipeline = TransparentPipeline;
        else
            material.Pipeline = OpaquePipeline;


        material.DescriptorSet = aDescriptorAllocator.Allocate(MaterialLayout);

        DescriptorWriter.Clear();

        DescriptorWriter.WriteBuffer(0, aBuffer, (ulong)aBufferOffset, VkDescriptorType.UniformBuffer);
        DescriptorWriter.WriteImage(1, aColorImage.ImageView, aColorSampler, VkImageLayout.ReadOnlyOptimal, VkDescriptorType.CombinedImageSampler);
        DescriptorWriter.WriteImage(2, aMetallicRoughnessImage.ImageView, aMetallicRoughnessSampler, VkImageLayout.ReadOnlyOptimal, VkDescriptorType.CombinedImageSampler);

        DescriptorWriter.UpdateSet(material.DescriptorSet);

        return material;
    }
}