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
        
        UpdateSceneData();
        
        using (CommandBufferHandle cmd = CurrentFrame.CommandBuffer.BeginRecording())
        {
            cmd.TransitionImage(RenderImage, VkImageLayout.General);
            cmd.TransitionImage(DepthImage, VkImageLayout.DepthAttachmentOptimal);

            RenderBackground(cmd);

            cmd.TransitionImage(RenderImage, VkImageLayout.ColorAttachmentOptimal);

            RenderGeometry(cmd);

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

    private void RenderGeometry(CommandBufferHandle cmd)
    {
        cmd.BeginRendering(RenderImage, DepthImage); 

        cmd.BindPipeline(TrianglePipeline);

        foreach(var renderData in RenderData)
        {
            VkDescriptorSet descriptorSet = CurrentFrame.FrameDescriptors.Allocate(SingleTextureLayout);

            {
                DescriptorWriter writer = new();
                writer.WriteImage(0, CheckerBoardImage.ImageView, DefaultNearestSampler, VkImageLayout.ShaderReadOnlyOptimal, VkDescriptorType.CombinedImageSampler);
                writer.UpdateSet(descriptorSet);
            }

            cmd.BindDescriptorSet(TrianglePipeline.VkLayout, descriptorSet, VkPipelineBindPoint.Graphics); 
            
            Matrix4x4 world = renderData.WorldMatrix;
            Matrix4x4 view = SceneData.View;
            Matrix4x4 projection = MatrixExtensions.CreatePerspectiveFieldOfView(90f * (float)(Math.PI/180f), (float)RenderImage.Extent.width / (float)RenderImage.Extent.height, 10000f, 0.1f);

            projection[1, 1] *= -1f;

            MeshPushConstants pushConstants = new();
            pushConstants.WorldMatrix = world * view * projection;
            pushConstants.VertexBufferAddress = renderData.Mesh.MeshBuffers.VertexBufferAddress;

            cmd.SetPushConstants(pushConstants, TrianglePipeline.VkLayout, VkShaderStageFlags.Vertex);

            cmd.BindIndexBuffer(renderData.Mesh.MeshBuffers.IndexRawBuffer);

            cmd.DrawIndexed(renderData.Mesh.Surfaces[0].Count);
        }
       
        cmd.EndRendering();
    }

    private unsafe void UpdateSceneData()
    {
        AllocatedBuffer<SceneData> sceneDataBuffer = new(VkBufferUsageFlags.UniformBuffer, VmaMemoryUsage.CpuToGpu);
        CurrentFrame.DeletionQueue.Add(sceneDataBuffer);
        sceneDataBuffer.SetWriteData(SceneData);
        VkDescriptorSet globalDescriptor = CurrentFrame.FrameDescriptors.Allocate(SceneDataLayout);
        
        {
            DescriptorWriter writer = new();
            writer.WriteBuffer(0, sceneDataBuffer.Buffer, (ulong)sizeof(SceneData), 0, VkDescriptorType.UniformBuffer);
            writer.UpdateSet(globalDescriptor);
        }
    }

    private void RenderBackground(CommandBufferHandle cmd)
    {
        cmd.BindPipeline(GradientPipeline);

        cmd.BindDescriptorSet(GradientPipeline.VkLayout, RenderImageDescriptorSet, VkPipelineBindPoint.Compute);

        PushConstants pushConstants = new();
        pushConstants.data1.X = 0f;

        cmd.SetPushConstants(pushConstants, GradientPipeline.VkLayout, VkShaderStageFlags.Compute);

        cmd.DispatchCompute((uint)Math.Ceiling(Swapchain.Extents.width / 16d), (uint)Math.Ceiling(Swapchain.Extents.height / 16d));
    }
}