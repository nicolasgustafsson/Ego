using Rendering.Materials;
using VulkanApi;

namespace Rendering;

public abstract class RenderRequest
{
    public virtual void Render(CommandBufferHandle cmd, VkDescriptorSet aSceneDataDescriptor, VkDescriptorSet aTextureRegistryDescriptor)
    {
    }
}

public class MeshRenderRequest : RenderRequest
{
    public MeshData MyMeshData = null!;
    public Material Material = null!;
    public Matrix4x4 WorldMatrix;
    
    public override void Render(CommandBufferHandle cmd, VkDescriptorSet aSceneDataDescriptor, VkDescriptorSet aTextureRegistryDescriptor)
    {
        Material.Bind(cmd);
            
        cmd.BindDescriptorSet(Material.VertexShader.PipelineLayout, aSceneDataDescriptor, VkPipelineBindPoint.Graphics, 0);
        cmd.BindDescriptorSet(Material.VertexShader.PipelineLayout, aTextureRegistryDescriptor, VkPipelineBindPoint.Graphics, 1);

        cmd.BindIndexBuffer(MyMeshData.MeshBuffers.IndexBuffer);

        SetupPushConstants(cmd);

        cmd.DrawIndexed(MyMeshData.Surfaces[0].Count);
    }
    
    private void SetupPushConstants(CommandBufferHandle cmd)
    {
        DefaultPushConstants pushConstants = new();
        pushConstants.MaterialUniformBufferAddress = Material.UniformBuffer.GetDeviceAddress();
        pushConstants.WorldMatrix = WorldMatrix; 
        pushConstants.VertexBufferAddress = MyMeshData.MeshBuffers.VertexBufferAddress;
        cmd.SetPushConstants(pushConstants, Material.VertexShader.PipelineLayout);
    }
}