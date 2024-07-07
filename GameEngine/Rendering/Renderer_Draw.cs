using System.Runtime.InteropServices;
using SharpGLTF.Schema2;

namespace Rendering;
using Vortice.Vulkan;
using Graphics;

struct PushConstants
{
    public Vector4 data1;
    public Vector4 data2;
    public Vector4 data3;
    public Vector4 data4;
}

public partial class Renderer
{
    private void DrawInternal()
    {
        myCurrentFrame.MyRenderFence.Wait();
        myCurrentFrame.MyRenderFence.Reset();

        if (myWantsResize)
        {
            Resize();
            myWantsResize = false;
        }
        
        myCurrentFrame.MyDeletionQueue.Flush();
        myCurrentFrame.MyFrameDescriptors.ClearPools();
        
        var nextImage = Device.AcquireNextImage(mySwapchain, myCurrentFrame.MyImageAvailableSemaphore);
        uint imageIndex = nextImage.imageIndex;
        if (nextImage.result == VkResult.ErrorOutOfDateKHR)
        {
            myWantsResize = true;
            return;
        }
        
        VkImage currentSwapchainImage = mySwapchain.MyImages[(int)imageIndex];

        CommandBuffer cmd = myCurrentFrame.MyCommandBuffer;

        cmd.Reset();
        cmd.BeginRecording();

        cmd.TransitionImage(myDrawImage, VkImageLayout.General);
        cmd.TransitionImage(myDepthImage, VkImageLayout.DepthAttachmentOptimal);

        DrawBackground(cmd);

        cmd.TransitionImage(myDrawImage, VkImageLayout.ColorAttachmentOptimal);

        DrawGeometry(cmd);

        cmd.BeginRendering(myDrawImage, myDepthImage);
        MyImGuiContext.Render(cmd);
        cmd.EndRendering();

        cmd.TransitionImage(myDrawImage, VkImageLayout.TransferSrcOptimal);
        cmd.TransitionImage(currentSwapchainImage, VkImageLayout.Undefined, VkImageLayout.TransferDstOptimal);

        cmd.Blit(myDrawImage, currentSwapchainImage, mySwapchain.MyExtents);
        
        cmd.TransitionImage(currentSwapchainImage, VkImageLayout.TransferDstOptimal, VkImageLayout.PresentSrcKHR);

        cmd.EndRecording();

        myDrawQueue.Submit(cmd, myCurrentFrame.MyImageAvailableSemaphore, myCurrentFrame.MyRenderFinishedSemaphore, myCurrentFrame.MyRenderFence);
        
        VkResult result = myDrawQueue.Present(mySwapchain, myCurrentFrame.MyRenderFinishedSemaphore, imageIndex);
        
        if (result == VkResult.ErrorOutOfDateKHR)
            myWantsResize = true;


        MyImGuiContext.RenderOtherWindows();
        
        myFrameNumber++;
    }

    private unsafe void DrawGeometry(CommandBuffer cmd)
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
        
        cmd.BeginRendering(myDrawImage, myDepthImage); 

        cmd.BindPipeline(myTrianglePipeline);

        VkDescriptorSet descriptorSet = myCurrentFrame.MyFrameDescriptors.Allocate(mySingleTextureLayout);

        {
            DescriptorWriter writer = new();
            writer.WriteImage(0, myCheckerBoardImage.MyImageView, myDefaultNearestSampler, VkImageLayout.ShaderReadOnlyOptimal, VkDescriptorType.CombinedImageSampler);
            writer.UpdateSet(descriptorSet);
        }

        cmd.BindDescriptorSet(myTrianglePipeline.MyVkLayout, descriptorSet, VkPipelineBindPoint.Graphics); 
        
        Matrix4x4 view = Matrix4x4.CreateTranslation(new Vector3(0f, 0f, -2f));
        Matrix4x4 projection = MatrixExtensions.CreatePerspectiveFieldOfView(90f * (float)(Math.PI/180f), (float)myDrawImage.MyExtent.width / (float)myDrawImage.MyExtent.height, 10000f, 0.1f);

        projection[1, 1] *= -1f;

        MeshPushConstants pushConstants = new();
        pushConstants.WorldMatrix = view * projection;
        pushConstants.VertexBufferAddress = myMonke.MyMeshBuffers.MyVertexBufferAddress;

        cmd.SetPushConstants(pushConstants, myTrianglePipeline.MyVkLayout, VkShaderStageFlags.Vertex);

        cmd.BindIndexBuffer(myMonke.MyMeshBuffers.MyIndexRawBuffer);

        cmd.DrawIndexed(myMonke.MySurfaces[0].Count);
       
        cmd.EndRendering();
    }

    private void DrawBackground(CommandBuffer cmd)
    {
        cmd.BindPipeline(myGradientPipeline);

        cmd.BindDescriptorSet(myGradientPipeline.MyVkLayout, myDrawImageDescriptorSet, VkPipelineBindPoint.Compute);

        PushConstants pushConstants = new();
        pushConstants.data1.X = 0f;

        cmd.SetPushConstants(pushConstants, myGradientPipeline.MyVkLayout, VkShaderStageFlags.Compute);

        cmd.DispatchCompute((uint)Math.Ceiling(mySwapchain.MyExtents.width / 16d), (uint)Math.Ceiling(mySwapchain.MyExtents.height / 16d));
    }
}