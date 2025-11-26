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

    public bool WriteDepth = true;
    public bool UseDepth = true;
    public bool CheckStencil = true;
    public VkCullModeFlags CullMode = VkCullModeFlags.Front;
    public VkCompareOp DepthMode = VkCompareOp.Greater;
    
    //Should be double-buffered probably!
    public GpuBuffer? UniformBuffer = null;
    public Material() { }
    
    //Assumes that the shader path contains vertex and pixel shaders with the entry point "vertex" and "pixel"
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
    
    public void Set(string aName, float aFloat)
    {
        uint offset = PixelShader.UniformTable[aName].Offset;
        UniformBuffer!.SetSubset(aFloat, offset);
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
    
    public void Bind(CommandBufferHandle aCommandBuffer)
    {
        aCommandBuffer.BindShader(VertexShader);
        aCommandBuffer.BindShader(PixelShader);
        aCommandBuffer.SetCullMode(CullMode);
        aCommandBuffer.SetBlendMode(BlendMode.Alpha);
        aCommandBuffer.SetPrimitiveTopology(VkPrimitiveTopology.TriangleList);
        aCommandBuffer.SetFrontFace(VkFrontFace.Clockwise);
        aCommandBuffer.SetDepthCompareOperation(DepthMode);
        aCommandBuffer.SetDepthWrite(WriteDepth);
        aCommandBuffer.SetDepthTestEnable(DepthMode != VkCompareOp.Always);
        aCommandBuffer.SetStencilTestEnable(CheckStencil);
    }
    
    //Nothing calls this right now :/
    public void Destroy()
    {
        UniformBuffer?.Destroy();
    }
}