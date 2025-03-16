using Vortice.Vulkan;
using VulkanApi;

namespace Rendering.Materials;

public enum MaterialPassType
{
    MainColor,
    Transparent,
    Other
}

public class Material
{
    public VkDescriptorSet DescriptorSet;
    public MaterialPassType MyMaterialPassType = MaterialPassType.MainColor;
    public ShaderObject.Shader VertexShader = null!;
    public ShaderObject.Shader FragmentShader = null!;
    
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