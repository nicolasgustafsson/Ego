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
        myCurrentFrame.MyRenderFence.Wait();
        myCurrentFrame.MyRenderFence.Reset();
        myCurrentFrame.MyDeletionQueue.Flush();
        myCurrentFrame.MyFrameDescriptors.ClearPools();
        
        //Acquire image as early as possible, so we don't wait for the semaphore when we want to submit the command buffer
        var nextImageAcquisition = Device.AcquireNextImage(mySwapchain, myCurrentFrame.MyImageAvailableSemaphore);
        if (nextImageAcquisition.result == VkResult.ErrorOutOfDateKHR)
            return RenderResult.ResizeNeeded;
        
        uint imageIndex = nextImageAcquisition.imageIndex;
        
        UpdateSceneData();
        
        using (CommandBufferHandle cmd = myCurrentFrame.MyCommandBuffer.BeginRecording())
        {
            cmd.TransitionImage(myRenderImage, VkImageLayout.General);
            cmd.TransitionImage(myDepthImage, VkImageLayout.DepthAttachmentOptimal);

            RenderBackground(cmd);

            cmd.TransitionImage(myRenderImage, VkImageLayout.ColorAttachmentOptimal);

            RenderGeometry(cmd);

            cmd.BeginRendering(myRenderImage, myDepthImage);
            ERenderImgui(cmd);
            cmd.EndRendering();

            cmd.TransitionImage(myRenderImage, VkImageLayout.TransferSrcOptimal);
            
            VkImage currentSwapchainImage = mySwapchain.MyImages[(int)imageIndex];
            cmd.TransitionImage(currentSwapchainImage, VkImageLayout.Undefined, VkImageLayout.TransferDstOptimal);

            cmd.Blit(myRenderImage, currentSwapchainImage, mySwapchain.MyExtents);
            
            cmd.TransitionImage(currentSwapchainImage, VkImageLayout.TransferDstOptimal, VkImageLayout.PresentSrcKHR);
        }

        myRenderQueue.Submit(myCurrentFrame.MyCommandBuffer, myCurrentFrame.MyImageAvailableSemaphore, myCurrentFrame.MyRenderFinishedSemaphore, myCurrentFrame.MyRenderFence);
        
        VkResult presentResult = myRenderQueue.Present(mySwapchain, myCurrentFrame.MyRenderFinishedSemaphore, imageIndex);

        myFrameCount++;

        if (presentResult == VkResult.ErrorOutOfDateKHR)
            return RenderResult.ResizeNeeded;

        EPostRender();
        
        return RenderResult.Success;
    }

    private void RenderGeometry(CommandBufferHandle cmd)
    {
        cmd.BeginRendering(myRenderImage, myDepthImage); 

        cmd.BindPipeline(myTrianglePipeline);

        VkDescriptorSet descriptorSet = myCurrentFrame.MyFrameDescriptors.Allocate(mySingleTextureLayout);

        {
            DescriptorWriter writer = new();
            writer.WriteImage(0, myCheckerBoardImage.MyImageView, myDefaultNearestSampler, VkImageLayout.ShaderReadOnlyOptimal, VkDescriptorType.CombinedImageSampler);
            writer.UpdateSet(descriptorSet);
        }

        cmd.BindDescriptorSet(myTrianglePipeline.MyVkLayout, descriptorSet, VkPipelineBindPoint.Graphics); 
        
        Matrix4x4 translation = Matrix4x4.CreateTranslation(new Vector3(0f, 0f, -2f));
        Matrix4x4 view = mySceneData.View;
        Matrix4x4 projection = MatrixExtensions.CreatePerspectiveFieldOfView(90f * (float)(Math.PI/180f), (float)myRenderImage.MyExtent.width / (float)myRenderImage.MyExtent.height, 10000f, 0.1f);

        projection[1, 1] *= -1f;

        MeshPushConstants pushConstants = new();
        pushConstants.WorldMatrix = translation * view * projection;
        pushConstants.VertexBufferAddress = myMonke.MyMeshBuffers.MyVertexBufferAddress;

        cmd.SetPushConstants(pushConstants, myTrianglePipeline.MyVkLayout, VkShaderStageFlags.Vertex);

        cmd.BindIndexBuffer(myMonke.MyMeshBuffers.MyIndexRawBuffer);

        cmd.DrawIndexed(myMonke.MySurfaces[0].Count);
       
        cmd.EndRendering();
    }

    private unsafe void UpdateSceneData()
    {
        AllocatedBuffer<SceneData> sceneDataBuffer = new(VkBufferUsageFlags.UniformBuffer, VmaMemoryUsage.CpuToGpu);
        myCurrentFrame.MyDeletionQueue.Add(sceneDataBuffer);
        sceneDataBuffer.SetWriteData(mySceneData);
        VkDescriptorSet globalDescriptor = myCurrentFrame.MyFrameDescriptors.Allocate(mySceneDataLayout);
        
        {
            DescriptorWriter writer = new();
            writer.WriteBuffer(0, sceneDataBuffer.MyBuffer, (ulong)sizeof(SceneData), 0, VkDescriptorType.UniformBuffer);
            writer.UpdateSet(globalDescriptor);
        }
    }

    private void RenderBackground(CommandBufferHandle cmd)
    {
        cmd.BindPipeline(myGradientPipeline);

        cmd.BindDescriptorSet(myGradientPipeline.MyVkLayout, myRenderImageDescriptorSet, VkPipelineBindPoint.Compute);

        PushConstants pushConstants = new();
        pushConstants.data1.X = 0f;

        cmd.SetPushConstants(pushConstants, myGradientPipeline.MyVkLayout, VkShaderStageFlags.Compute);

        cmd.DispatchCompute((uint)Math.Ceiling(mySwapchain.MyExtents.width / 16d), (uint)Math.Ceiling(mySwapchain.MyExtents.height / 16d));
    }
}