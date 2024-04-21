using System.Runtime.InteropServices;
using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;

namespace Rendering;

public unsafe partial class Renderer
{
    
    private void TransitionImage(VkCommandBuffer aCmd, VkImage aImage, VkImageLayout aFrom, VkImageLayout aTo)
    {
        VkImageMemoryBarrier2 imageBarrier = new();
        imageBarrier.srcStageMask = VkPipelineStageFlags2.AllCommands;
        imageBarrier.srcAccessMask = VkAccessFlags2.MemoryWrite;
        imageBarrier.dstStageMask = VkPipelineStageFlags2.AllCommands;
        imageBarrier.dstAccessMask = VkAccessFlags2.MemoryRead | VkAccessFlags2.MemoryWrite;

        imageBarrier.oldLayout = aFrom;
        imageBarrier.newLayout = aTo;
        VkImageAspectFlags aspectMask = (aTo == VkImageLayout.DepthAttachmentOptimal)
            ? VkImageAspectFlags.Depth
            : VkImageAspectFlags.Color;

        imageBarrier.subresourceRange = new VkImageSubresourceRange(aspectMask);
        imageBarrier.image = aImage;

        VkDependencyInfo depInfo = new();
        depInfo.imageMemoryBarrierCount = 1;
        depInfo.pImageMemoryBarriers = &imageBarrier;

        vkCmdPipelineBarrier2(aCmd, &depInfo);
    }
    
    VkSemaphoreSubmitInfo GetSemaphoreSubmitInfo(VkPipelineStageFlags2 aStageMask, VkSemaphore aSemaphore)
    {
        VkSemaphoreSubmitInfo info = new();
        info.semaphore = aSemaphore;
        info.stageMask = aStageMask;
        info.deviceIndex = 0;
        info.value = 1;
        return info;
    }
    
    VkCommandBufferSubmitInfo GetCommandBufferSubmitInfo(VkCommandBuffer aCmd)
    {
        VkCommandBufferSubmitInfo info = new();
        info.commandBuffer = aCmd;
        info.deviceMask = 0;
        return info;
    }
    
    private VkSubmitInfo2 GetSubmitInfo(VkCommandBufferSubmitInfo* aCmdInfo, VkSemaphoreSubmitInfo* aWaitSemaphoreInfo, VkSemaphoreSubmitInfo* aSignalSemaphoreInfo)
    {
        VkSubmitInfo2 info = new();
        
        info.signalSemaphoreInfoCount = 1;
        
        info.pSignalSemaphoreInfos = aSignalSemaphoreInfo;

        info.waitSemaphoreInfoCount = 0;
        
        info.waitSemaphoreInfoCount = 1;
        
        info.pWaitSemaphoreInfos = aWaitSemaphoreInfo;

        info.commandBufferInfoCount = 1;
        info.pCommandBufferInfos = aCmdInfo;

        return info;
    }
}