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
    public ShaderObject.Shader PixelShader = null!;
    public GpuBuffer? UniformBuffer = null;
    
    public Material() { }
    
    //Assumes that the shader path contains vertex and pixel shaders with the entry point "vertex" and "pixel"
    //Todo: Uniform buffer should be created dynamically based on shader reflection, instead of being sent in here.
    public unsafe Material(string aShaderPath, Node aContext)
    {
        DescriptorLayoutBuilder descriptorLayoutBuilder = new();
        descriptorLayoutBuilder.AddBinding(0, VkDescriptorType.UniformBuffer);
        VkDescriptorSetLayout MaterialLayout = descriptorLayoutBuilder.Build(VkShaderStageFlags.Vertex | VkShaderStageFlags.Fragment);

        var renderer = aContext.RendererApi.Renderer;
        
        var vertexShader = aContext.ShaderCompiler.LoadShaderImmediate(aShaderPath, VkShaderStageFlags.Vertex, new() { renderer.SceneDataLayout, renderer.BindlessTextureLayout, MaterialLayout }, "vertex");
        var pixelShader = aContext.ShaderCompiler.LoadShaderImmediate(aShaderPath, VkShaderStageFlags.Fragment, new() { renderer.SceneDataLayout, renderer.BindlessTextureLayout, MaterialLayout }, "pixel");
        
        VertexShader = vertexShader!;
        PixelShader = pixelShader!;
        
        CreateUniformBuffer();
        
        PassType = MaterialPassType.Opaque;
    }
    
    private void CreateUniformBuffer()
    {
        if (PixelShader.UniformTable.Count == 0)
            return;
        
        ShaderObject.UniformMemberInfo lastMember = PixelShader.UniformTable.Values.MaxBy(thing => thing.Offset);
        uint size = lastMember.Size + lastMember.Offset;
        
        UniformBuffer = new GpuBuffer<byte>(GpuBufferType.Uniform, GpuBufferTransferType.Direct, size);
    }
    
    public void Set(string aName, Image aImage)
    {
        uint offset = PixelShader.UniformTable[aName].Offset;
        UniformBuffer!.SetSubset(aImage.Index!.Value, offset);
    }
    
    public void Set(string aName, int aInt)
    {
        uint offset = PixelShader.UniformTable[aName].Offset;
        UniformBuffer!.SetSubset(aInt, offset);
    }
    
    public void Set(string aName, Vector4 aVector)
    {
        uint offset = PixelShader.UniformTable[aName].Offset;
        UniformBuffer!.SetSubset(aVector, offset);
    }
    
    //Todo: Uniform buffer should be created dynamically based on shader reflection, instead of being sent in here.
    public unsafe Material(ShaderObject.Shader aVertexShader, ShaderObject.Shader aPixelShader, GpuBuffer aUniformBuffer)
    {
        UniformBuffer = aUniformBuffer;
        VertexShader = aVertexShader;
        PixelShader = aPixelShader; 
        
        PassType = MaterialPassType.Opaque;
    }
    
    public void Bind(CommandBufferHandle aCommandBuffer)
    {
        aCommandBuffer.BindShader(VertexShader);
        aCommandBuffer.BindShader(PixelShader);
        aCommandBuffer.SetCullMode(VkCullModeFlags.Front);
        aCommandBuffer.SetBlendMode(BlendMode.Alpha);
        aCommandBuffer.SetPrimitiveTopology(VkPrimitiveTopology.TriangleList);
        aCommandBuffer.SetFrontFace(VkFrontFace.Clockwise);
        aCommandBuffer.SetDepthCompareOperation(VkCompareOp.Greater);
        aCommandBuffer.SetDepthWrite(true);
        aCommandBuffer.SetDepthTestEnable(true);
        aCommandBuffer.SetStencilTestEnable(false);
    }
    
    //Nothing calls this right now :/
    public void Destroy()
    {
        UniformBuffer?.Destroy();
    }
}