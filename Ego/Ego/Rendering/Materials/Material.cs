using Ego;
using Vortice.Vulkan;
using VulkanApi;

namespace Rendering.Materials;

public enum MaterialPassType
{
    Opaque,
    Transparent,
}
public struct MaterialConstants 
{
    public Vector4 Color;
    public Vector4 MetallicRoughness;
    public int ColorTexture;
}

public class Material
{
    public MaterialPassType PassType;
    public ShaderObject.Shader VertexShader = null!;
    public ShaderObject.Shader FragmentShader = null!;
    public GpuBuffer UniformBuffer = null!;
    
    public Material() { }
    
    
    //Assumes that the shader path contains vertex and pixel shaders with the entry point "vertex" and "pixel"
    //Todo: Uniform buffer should be created dynamically based on shader reflection, instead of being sent in here.
    public unsafe Material(string aShaderPath, GpuBuffer aUniformBuffer, Node aContext)
    {
        DescriptorLayoutBuilder descriptorLayoutBuilder = new();
        descriptorLayoutBuilder.AddBinding(0, VkDescriptorType.UniformBuffer);
        VkDescriptorSetLayout MaterialLayout = descriptorLayoutBuilder.Build(VkShaderStageFlags.Vertex | VkShaderStageFlags.Fragment);

        var renderer = aContext.RendererApi.Renderer;
        
        var vertexShader = aContext.ShaderCompiler.LoadShaderImmediate(aShaderPath, VkShaderStageFlags.Vertex, new() { renderer.SceneDataLayout, renderer.BindlessTextureLayout, MaterialLayout }, "vertex");
        var pixelShader = aContext.ShaderCompiler.LoadShaderImmediate(aShaderPath, VkShaderStageFlags.Fragment, new() { renderer.SceneDataLayout, renderer.BindlessTextureLayout, MaterialLayout }, "pixel");
        
        
        UniformBuffer = aUniformBuffer;
        VertexShader = vertexShader!;
        FragmentShader = pixelShader!; 
        
        PassType = MaterialPassType.Opaque;
    }
    
    //Todo: Uniform buffer should be created dynamically based on shader reflection, instead of being sent in here.
    public unsafe Material(ShaderObject.Shader aVertexShader, ShaderObject.Shader aFragmentShader, GpuBuffer aUniformBuffer)
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