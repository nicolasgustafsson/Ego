using System.Drawing;
using Rendering;
using Rendering.Materials;
using VulkanApi;

namespace Ego.Rendering;

public abstract class RenderSchedule : IGpuDestroyable
{
    public Renderer Renderer;
    
    public RenderSchedule(Renderer aRenderer)
    {
        Renderer = aRenderer;
    }
    
    public abstract void Execute(FrameData aFrameData, SceneData aSceneData, CommandBufferHandle cmd);

    public virtual void Destroy()
    {
    }
    
    protected void RenderGeometry(Image aRenderImage, Image aDepthImage, CommandBufferHandle cmd, VkDescriptorSet aSceneDataDescriptor, Color? aClearColor = null)
    {
        cmd.BeginRendering(aRenderImage, aDepthImage, aClearColor);
        foreach(var renderData in Renderer.RenderRequests)
        {
            renderData.Render(cmd, aSceneDataDescriptor, Renderer.TextureRegistryDescriptorSet);
        }
        cmd.EndRendering();
    }
    
    protected void FullscreenPass(Image aRenderImage, CommandBufferHandle cmd, Material aFullscreenMaterial, VkDescriptorSet aSceneDataDescriptor)
    {
        cmd.TransitionImage(aRenderImage, VkImageLayout.ColorAttachmentOptimal);
        
        aFullscreenMaterial.Bind(cmd);
        
        cmd.BindDescriptorSet(aFullscreenMaterial.VertexShader.PipelineLayout, aSceneDataDescriptor, VkPipelineBindPoint.Graphics, 0);
        cmd.BindDescriptorSet(aFullscreenMaterial.VertexShader.PipelineLayout, Renderer.TextureRegistryDescriptorSet, VkPipelineBindPoint.Graphics, 1);

        /*
        cmd.BindIndexBuffer(MyMeshData.MeshBuffers.IndexBuffer);

        DefaultPushConstants pushConstants = new();
        pushConstants.MaterialUniformBufferAddress = Material.UniformBuffer.GetDeviceAddress();
        pushConstants.WorldMatrix = WorldMatrix; 
        pushConstants.VertexBufferAddress = MyMeshData.MeshBuffers.VertexBufferAddress;
        cmd.SetPushConstants(pushConstants, Material.VertexShader.PipelineLayout);

        cmd.DrawIndexed(MyMeshData.Surfaces[0].Count);*/
    }
}