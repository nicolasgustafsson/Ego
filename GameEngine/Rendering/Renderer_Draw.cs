using System.Runtime.InteropServices;

namespace Rendering;
using Vortice.Vulkan;
using Graphics;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
struct PushConstants
{
    public System.Numerics.Vector4 data1;
    public System.Numerics.Vector4 data2;
    public System.Numerics.Vector4 data3;
    public System.Numerics.Vector4 data4;
}

public partial class Renderer
{
    private void DrawInternal()
    {
        myCurrentFrame.MyRenderFence.Wait(myDevice);
        myCurrentFrame.MyRenderFence.Reset(myDevice);

        myCurrentFrame.MyDeletionQueue.Flush();
        
        uint imageIndex = myDevice.AcquireNextImage(mySwapchain, myCurrentFrame.MyImageAvailableSemaphore);

        CommandBuffer cmd = myCurrentFrame.MyCommandBuffer;

        cmd.Reset();
        cmd.BeginRecording();

        Image currentDrawImage = myDrawImage;
        VkImage currentSwapchainImage = mySwapchain.MyImages[(int)imageIndex];
        
        cmd.TransitionImage(currentDrawImage, VkImageLayout.Undefined, VkImageLayout.General);

        //DrawBackground(cmd);

        cmd.TransitionImage(currentDrawImage, VkImageLayout.General, VkImageLayout.ColorAttachmentOptimal);

        DrawGeometry(cmd);

        cmd.TransitionImage(currentDrawImage, VkImageLayout.ColorAttachmentOptimal, VkImageLayout.TransferSrcOptimal);
        cmd.TransitionImage(currentSwapchainImage, VkImageLayout.Undefined, VkImageLayout.TransferDstOptimal);

        cmd.Blit(currentDrawImage, currentSwapchainImage, mySwapchain.MyExtents);
        
        cmd.TransitionImage(currentSwapchainImage, VkImageLayout.TransferDstOptimal, VkImageLayout.PresentSrcKHR);

        cmd.EndRecording();

        myDrawQueue.Submit(cmd, myCurrentFrame.MyImageAvailableSemaphore, myCurrentFrame.MyRenderFinishedSemaphore, myCurrentFrame.MyRenderFence);
        
        myDrawQueue.Present(mySwapchain, myCurrentFrame.MyRenderFinishedSemaphore, imageIndex);
        
        myFrameNumber++;
    }

    private unsafe void DrawGeometry(CommandBuffer cmd)
    {
        VkRenderingAttachmentInfo attachmentInfo = myDrawImage.GetAttachmentInfo(null, VkImageLayout.General);
        VkRenderingInfo renderingInfo = myDrawImage.GetRenderingInfo(new VkExtent2D(myDrawImage.MyExtent.width, myDrawImage.MyExtent.height), attachmentInfo, null);

        Vulkan.vkCmdBeginRendering(cmd.MyVkCommandBuffer, &renderingInfo);

        Vulkan.vkCmdBindPipeline(cmd.MyVkCommandBuffer, VkPipelineBindPoint.Graphics, myTrianglePipeline);

        VkViewport dynamicViewport = new();
        dynamicViewport.x = 0;
        dynamicViewport.y = 0;
        dynamicViewport.width = myDrawImage.MyExtent.width;
        dynamicViewport.height = myDrawImage.MyExtent.height;
        dynamicViewport.minDepth = 0f;
        dynamicViewport.maxDepth = 1f;

        Vulkan.vkCmdSetViewport(cmd.MyVkCommandBuffer, 0, dynamicViewport);

        VkRect2D scissor = new();
        scissor.extent = new VkExtent2D(myDrawImage.MyExtent.width, myDrawImage.MyExtent.height);
        scissor.offset = new VkOffset2D(0, 0);

        Vulkan.vkCmdSetScissor(cmd.MyVkCommandBuffer, 0, scissor);

        Vulkan.vkCmdDraw(cmd.MyVkCommandBuffer, 3, 1, 0, 0);

        Vulkan.vkCmdEndRendering(cmd.MyVkCommandBuffer);
    }

    private unsafe void DrawBackground(CommandBuffer cmd)
    {
        Vulkan.vkCmdBindPipeline(cmd.MyVkCommandBuffer, VkPipelineBindPoint.Compute, myGradientPipeline);

        Vulkan.vkCmdBindDescriptorSets(cmd.MyVkCommandBuffer, VkPipelineBindPoint.Compute, myGradientPipelineLayout, 0, myDrawImageDescriptors);

        PushConstants pushConstants = new();
        pushConstants.data1.X = 0f;

        Vulkan.vkCmdPushConstants(cmd.MyVkCommandBuffer, myGradientPipelineLayout, VkShaderStageFlags.Compute, 0,
            (uint)sizeof(PushConstants), &pushConstants);

        Vulkan.vkCmdDispatch(cmd.MyVkCommandBuffer, (uint)Math.Ceiling(mySwapchain.MyExtents.width / 16d),
            (uint)Math.Ceiling(mySwapchain.MyExtents.height / 16d), 1);
    }
}