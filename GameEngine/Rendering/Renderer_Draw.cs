namespace Rendering;
using Vortice.Vulkan;
using Graphics;

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

        Image currentDrawImage = myCurrentFrame.MyImage;
        VkImage currentSwapchainImage = mySwapchain.MyImages[(int)imageIndex];
        
        cmd.TransitionImage(currentDrawImage, VkImageLayout.Undefined, VkImageLayout.General);

        DrawBackground(cmd, currentDrawImage);

        cmd.TransitionImage(currentDrawImage, VkImageLayout.General, VkImageLayout.TransferSrcOptimal);
        cmd.TransitionImage(currentSwapchainImage, VkImageLayout.Undefined, VkImageLayout.TransferDstOptimal);

        cmd.Blit(currentDrawImage, currentSwapchainImage, mySwapchain.MyExtents);
        
        cmd.TransitionImage(currentSwapchainImage, VkImageLayout.TransferDstOptimal, VkImageLayout.PresentSrcKHR);

        cmd.EndRecording();

        myDrawQueue.Submit(cmd, myCurrentFrame.MyImageAvailableSemaphore, myCurrentFrame.MyRenderFinishedSemaphore, myCurrentFrame.MyRenderFence);
        
        myDrawQueue.Present(mySwapchain, myCurrentFrame.MyRenderFinishedSemaphore, imageIndex);
        
        myFrameNumber++;
    }

    private void DrawBackground(CommandBuffer cmd, Image aCurrentImage)
    {
        VkClearColorValue clearColor = new((float)Math.Sin((double)myFrameNumber/144d), 0f, 0f);

        cmd.ClearColor(aCurrentImage, VkImageLayout.General, clearColor);
    }
}