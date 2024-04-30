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
        
        cmd.TransitionImage(currentDrawImage, VkImageLayout.General);

        DrawBackground(cmd);

        cmd.TransitionImage(currentDrawImage, VkImageLayout.ColorAttachmentOptimal);

        DrawGeometry(cmd);

        cmd.TransitionImage(currentDrawImage, VkImageLayout.TransferSrcOptimal);
        cmd.TransitionImage(currentSwapchainImage, VkImageLayout.Undefined, VkImageLayout.TransferDstOptimal);

        cmd.Blit(currentDrawImage, currentSwapchainImage, mySwapchain.MyExtents);
        
        cmd.TransitionImage(currentSwapchainImage, VkImageLayout.TransferDstOptimal, VkImageLayout.PresentSrcKHR);

        cmd.EndRecording();

        myDrawQueue.Submit(cmd, myCurrentFrame.MyImageAvailableSemaphore, myCurrentFrame.MyRenderFinishedSemaphore, myCurrentFrame.MyRenderFence);
        
        myDrawQueue.Present(mySwapchain, myCurrentFrame.MyRenderFinishedSemaphore, imageIndex);
        
        myFrameNumber++;
    }

    private void DrawGeometry(CommandBuffer cmd)
    {
        cmd.BeginRendering(myDrawImage);
        
        Vulkan.vkCmdBindPipeline(cmd.MyVkCommandBuffer, VkPipelineBindPoint.Graphics, myTrianglePipeline.MyVkPipeline);

        Vulkan.vkCmdDraw(cmd.MyVkCommandBuffer, 3, 1, 0, 0);

        cmd.EndRendering();
    }

    private unsafe void DrawBackground(CommandBuffer cmd)
    {
        Vulkan.vkCmdBindPipeline(cmd.MyVkCommandBuffer, VkPipelineBindPoint.Compute, myGradientPipeline.MyVkPipeline);

        Vulkan.vkCmdBindDescriptorSets(cmd.MyVkCommandBuffer, VkPipelineBindPoint.Compute, myGradientPipeline.MyVkLayout, 0, myDrawImageDescriptors);

        PushConstants pushConstants = new();
        pushConstants.data1.X = 0f;

        Vulkan.vkCmdPushConstants(cmd.MyVkCommandBuffer, myGradientPipeline.MyVkLayout, VkShaderStageFlags.Compute, 0,
            (uint)sizeof(PushConstants), &pushConstants);

        Vulkan.vkCmdDispatch(cmd.MyVkCommandBuffer, (uint)Math.Ceiling(mySwapchain.MyExtents.width / 16d),
            (uint)Math.Ceiling(mySwapchain.MyExtents.height / 16d), 1);
    }
}