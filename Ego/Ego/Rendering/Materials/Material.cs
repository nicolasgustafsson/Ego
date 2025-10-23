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
    public MaterialPassType PassType;
    public ShaderObject.Shader VertexShader = null!;
    public ShaderObject.Shader FragmentShader = null!;
    public GpuBuffer UniformBuffer = null!;
    
    public Material() { }
    
    //Todo: Uniform buffer should be created dynamically based on shader reflection, instead of being sent in here.
    public unsafe Material(ShaderObject.Shader aVertexShader, ShaderObject.Shader aFragmentShader, Renderer aRenderer, GpuBuffer aUniformBuffer)
    {
        UniformBuffer = aUniformBuffer;
        VertexShader = aVertexShader;
        FragmentShader = aFragmentShader; 
        
        PassType = MaterialPassType.Opaque;
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