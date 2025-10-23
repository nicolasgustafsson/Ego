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
    public VkDescriptorSet DescriptorSet; //Todo: This should disappear! We should have a global descriptor texture set and push constants will handle uniform buffer
    public MaterialPassType PassType;
    public ShaderObject.Shader VertexShader = null!;
    public ShaderObject.Shader FragmentShader = null!;
    public GpuBuffer UniformBuffer = null!;
    
    public Material() { }
    
    //Todo: Uniform buffer should be created dynamically based on shader reflection.
    public unsafe Material(ShaderObject.Shader aVertexShader, ShaderObject.Shader aFragmentShader, Renderer aRenderer, GpuBuffer aUniformBuffer)
    {
        UniformBuffer = aUniformBuffer;
        DescriptorWriter DescriptorWriter = new();
        DescriptorLayoutBuilder descriptorLayoutBuilder = new();
        descriptorLayoutBuilder.AddBinding(0, VkDescriptorType.UniformBuffer);

        VkDescriptorSetLayout MaterialLayout = descriptorLayoutBuilder.Build(VkShaderStageFlags.Vertex | VkShaderStageFlags.Fragment);
        
        VertexShader = aVertexShader;
        FragmentShader = aFragmentShader; 
        
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