namespace VulkanApi;

public unsafe class RenderQueue : Queue
{
    public RenderQueue() : base(GpuInstance.GraphicsFamily) { }
    
    public void Submit(CommandBuffer aCommandBuffer, Semaphore aWaitSemaphore, Semaphore aRenderFinishedSemaphore, Fence aRenderFence)
    {
        VkCommandBufferSubmitInfo cmdInfo = GetCommandBufferSubmitInfo(aCommandBuffer);
        VkSemaphoreSubmitInfo waitInfo = GetSemaphoreSubmitInfo(VkPipelineStageFlags2.ColorAttachmentOutput, aWaitSemaphore);
        VkSemaphoreSubmitInfo signalInfo = GetSemaphoreSubmitInfo(VkPipelineStageFlags2.AllGraphics, aRenderFinishedSemaphore);

        VkSubmitInfo2 submitInfo = GetSubmitInfo(&cmdInfo, &waitInfo, &signalInfo);
        VkApiDevice.vkQueueSubmit2(VkQueue, 1, &submitInfo, aRenderFence.VkFence).CheckResult();
    }
    
    //Currently the draw queue handles presenting too; this might be changed in the future
    public VkResult Present(Swapchain aSwapchain, Semaphore aRenderFinishedSemaphore, uint aImageIndex)
    {
        VkSwapchainKHR* swapchainPointer = stackalloc VkSwapchainKHR[] { aSwapchain.VkSwapchain };
        VkSemaphore* waitSemaphorePointer = stackalloc VkSemaphore[] { aRenderFinishedSemaphore.VkSemaphore };
        
        VkPresentInfoKHR presentInfo = new();
        presentInfo.pSwapchains = swapchainPointer;
        presentInfo.swapchainCount = 1;
        presentInfo.pWaitSemaphores = waitSemaphorePointer;
        presentInfo.waitSemaphoreCount = 1;
        presentInfo.pImageIndices = &aImageIndex;

        return VkApiDevice.vkQueuePresentKHR(VkQueue, &presentInfo);
    }
}