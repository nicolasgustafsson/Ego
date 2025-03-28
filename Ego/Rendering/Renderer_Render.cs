using Utilities;

namespace Rendering;
using Vortice.Vulkan;
using VulkanApi;

struct PushConstants
{
    public Vector4 data1;
    public Vector4 data2;
    public Vector4 data3;
    public Vector4 data4;
}

enum RenderResult
{
    ResizeNeeded,
    Success
}

public partial class Renderer
{
    private RenderResult RenderInternal()
    {
        CurrentFrame.RenderFence.Wait();
        CurrentFrame.RenderFence.Reset();
        CurrentFrame.DeletionQueue.Flush();
        CurrentFrame.FrameDescriptors.ClearPools();
        
        //Acquire image as early as possible, so we don't wait for the semaphore when we want to submit the command buffer
        var nextImageAcquisition = Device.AcquireNextImage(Swapchain, CurrentFrame.ImageAvailableSemaphore);
        if (nextImageAcquisition.result == VkResult.ErrorOutOfDateKHR)
            return RenderResult.ResizeNeeded;
        
        uint imageIndex = nextImageAcquisition.imageIndex;
        
        VkDescriptorSet globalDescriptor = UpdateSceneData();
        
        using (CommandBufferHandle cmd = CurrentFrame.CommandBuffer.BeginRecording())
        {
            cmd.TransitionImage(RenderImage, VkImageLayout.General);
            cmd.TransitionImage(DepthImage, VkImageLayout.DepthAttachmentOptimal);

            cmd.EnableShaderObjects();
            RenderBackground(cmd);

            cmd.TransitionImage(RenderImage, VkImageLayout.ColorAttachmentOptimal);

            RenderGeometry(cmd, globalDescriptor);
            
            cmd.BeginRendering(RenderImage, DepthImage);
            ERenderImgui(cmd);
            cmd.EndRendering();

            cmd.TransitionImage(RenderImage, VkImageLayout.TransferSrcOptimal);
            
            VkImage currentSwapchainImage = Swapchain.Images[(int)imageIndex];
            cmd.TransitionImage(currentSwapchainImage, VkImageLayout.Undefined, VkImageLayout.TransferDstOptimal);

            cmd.Blit(RenderImage, currentSwapchainImage, Swapchain.Extents);
            
            cmd.TransitionImage(currentSwapchainImage, VkImageLayout.TransferDstOptimal, VkImageLayout.PresentSrcKHR);
        }

        RenderQueue.Submit(CurrentFrame.CommandBuffer, CurrentFrame.ImageAvailableSemaphore, CurrentFrame.RenderFinishedSemaphore, CurrentFrame.RenderFence);
        
        VkResult presentResult = RenderQueue.Present(Swapchain, CurrentFrame.RenderFinishedSemaphore, imageIndex);

        FrameCount++;

        if (presentResult == VkResult.ErrorOutOfDateKHR)
            return RenderResult.ResizeNeeded;

        EPostRender();
        
        return RenderResult.Success;
    }

    private void RenderGeometry(CommandBufferHandle cmd, VkDescriptorSet aGlobalDescriptor)
    {
        cmd.BeginRendering(RenderImage, DepthImage);

        foreach(var renderData in MeshRenderData)
        {
            renderData.Material.Bind(cmd);
            
            cmd.BindDescriptorSet(renderData.Material.VertexShader.PipelineLayout, aGlobalDescriptor, VkPipelineBindPoint.Graphics, 0);
            cmd.BindDescriptorSet(renderData.Material.VertexShader.PipelineLayout, renderData.Material.DescriptorSet, VkPipelineBindPoint.Graphics, 1);

            cmd.BindIndexBuffer(renderData.MyMeshData.MeshBuffers.IndexRawBuffer);
            
            MeshPushConstants pushConstants = new();
            pushConstants.WorldMatrix = renderData.WorldMatrix; 
            pushConstants.VertexBufferAddress = renderData.MyMeshData.MeshBuffers.VertexBufferAddress;
            cmd.SetPushConstants(pushConstants, renderData.Material.VertexShader.PipelineLayout, VkShaderStageFlags.Vertex);

            cmd.DrawIndexed(renderData.MyMeshData.Surfaces[0].Count);
        }
       
        cmd.EndRendering();
    }

    private unsafe VkDescriptorSet UpdateSceneData()
    {
        AllocatedBuffer<SceneData> sceneDataBuffer = new(VkBufferUsageFlags.UniformBuffer, VmaMemoryUsage.CpuToGpu);
        CurrentFrame.DeletionQueue.Add(sceneDataBuffer);
        sceneDataBuffer.SetWriteData(SceneData);
        VkDescriptorSet globalDescriptor = CurrentFrame.FrameDescriptors.Allocate(SceneDataLayout);
        
        {
            DescriptorWriter writer = new();
            writer.WriteBuffer(0, sceneDataBuffer, 0, VkDescriptorType.UniformBuffer);
            writer.UpdateSet(globalDescriptor);
        }

        return globalDescriptor;
    }

    private void RenderBackground(CommandBufferHandle cmd)
    {
        cmd.BindShader(GradientShader);

        cmd.BindDescriptorSet(GradientShader.PipelineLayout, RenderImageDescriptorSet, VkPipelineBindPoint.Compute);

        PushConstants pushConstants = new();
        pushConstants.data1.X = 0f;

        cmd.SetPushConstants(pushConstants, GradientShader.PipelineLayout, VkShaderStageFlags.Compute);

        cmd.DispatchCompute((uint)Math.Ceiling(Swapchain.Extents.width / 16d), (uint)Math.Ceiling(Swapchain.Extents.height / 16d));
    }
}