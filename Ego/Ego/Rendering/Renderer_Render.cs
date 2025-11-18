using Ego;
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
    private unsafe RenderResult RenderInternal()
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
        
        UpdateBindlessTextures();
        
        using (CommandBufferHandle cmd = CurrentFrame.CommandBuffer.BeginRecording())
        {
            RenderSchedule.Execute(CurrentFrame, SceneData, cmd);
            
            VkImage currentSwapchainImage = Swapchain.Images[(int)imageIndex];
            cmd.TransitionImage(currentSwapchainImage, VkImageLayout.Undefined, VkImageLayout.TransferDstOptimal);

            cmd.Blit(RenderSchedule.RenderImage, currentSwapchainImage, Swapchain.Extents);
            
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

    private void UpdateBindlessTextures()
    {
        DescriptorWriter writer = new();
        
        foreach(var image in ImageRegistry.GetAllImages())
        {
            if (image == null)
                continue;
            writer.WriteImage(0, image.ImageView, null, VkImageLayout.ReadOnlyOptimal, VkDescriptorType.SampledImage, (uint)image.Index!.Value);
        }

        writer.WriteImage(1, null, DefaultLinearSampler, VkImageLayout.ReadOnlyOptimal, VkDescriptorType.Sampler);
        
        writer.UpdateSet(TextureRegistryDescriptorSet);
    }

}