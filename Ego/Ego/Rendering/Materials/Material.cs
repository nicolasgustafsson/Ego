using Vortice.Vulkan;
using VulkanApi;

namespace Rendering.Materials;

public enum MaterialPassType
{
    Opaque,
    Transparent,
}

public class Material
{
    public VkDescriptorSet DescriptorSet;
    public MaterialPassType PassType;
    public ShaderObject.Shader VertexShader = null!;
    public ShaderObject.Shader FragmentShader = null!;
    
    public Material() { }
    
    public unsafe Material(string aVertexShaderPath, string aFragmentShaderPath, Renderer aRenderer)
    {
        DescriptorWriter DescriptorWriter = new();
        DescriptorLayoutBuilder descriptorLayoutBuilder = new();
        descriptorLayoutBuilder.AddBinding(0, VkDescriptorType.UniformBuffer);

        VkDescriptorSetLayout MaterialLayout = descriptorLayoutBuilder.Build(VkShaderStageFlags.Vertex | VkShaderStageFlags.Fragment);
        
        List<VkDescriptorSetLayout> layouts = new() { aRenderer.SceneDataLayout, MaterialLayout };
        VkPushConstantRange range = new();
        range.offset = 0;
        range.size = (uint)sizeof(MeshPushConstants);
        range.stageFlags = VkShaderStageFlags.Vertex;
        
        VertexShader = new(VkShaderStageFlags.Vertex, File.ReadAllBytes(aVertexShaderPath), layouts, range);
        FragmentShader = new(VkShaderStageFlags.Fragment, File.ReadAllBytes(aFragmentShaderPath), layouts, range);
        
        PassType = MaterialPassType.Opaque;
        
        
        DescriptorSet = aRenderer.GlobalDescriptorAllocator.Allocate(MaterialLayout);
        
        DescriptorWriter.Clear();
        DescriptorWriter.UpdateSet(DescriptorSet);
    }
    
    public void Bind(CommandBufferHandle aCommandBuffer)
    {
        aCommandBuffer.BindShader(VertexShader);
        aCommandBuffer.BindShader(FragmentShader);
        aCommandBuffer.SetCullMode(VkCullModeFlags.Front);
        aCommandBuffer.SetBlendMode(BlendMode.Alpha);
        aCommandBuffer.SetPrimitiveTopology(VkPrimitiveTopology.TriangleList);
        aCommandBuffer.SetFrontFace(VkFrontFace.Clockwise);
        aCommandBuffer.SetDepthCompareOperation(VkCompareOp.Greater);
        aCommandBuffer.SetDepthWrite(true);
        aCommandBuffer.SetDepthTestEnable(true);
        aCommandBuffer.SetStencilTestEnable(false);
    }
}