namespace Graphics;

public unsafe class DrawQueue : Queue
{
    public DrawQueue(Device aDevice, Gpu aGpu) : base(aDevice, aGpu.MyGraphicsFamily) { }
    
    public void Submit(CommandBuffer aCommandBuffer, Semaphore aImageAvailableSemaphore, Semaphore aRenderFinishedSemaphore, Fence aRenderFence)
    {
        VkCommandBufferSubmitInfo cmdInfo = GetCommandBufferSubmitInfo(aCommandBuffer);
        VkSemaphoreSubmitInfo waitInfo = GetSemaphoreSubmitInfo(VkPipelineStageFlags2.ColorAttachmentOutput, aImageAvailableSemaphore);
        VkSemaphoreSubmitInfo signalInfo = GetSemaphoreSubmitInfo(VkPipelineStageFlags2.AllGraphics, aRenderFinishedSemaphore);

        VkSubmitInfo2 submitInfo = GetSubmitInfo(&cmdInfo, &waitInfo, &signalInfo);
        vkQueueSubmit2(MyVkQueue, 1, &submitInfo, aRenderFence.MyVkFence);
    }
    
    //Currently the draw queue handles presenting too; this might be changed in the future
    public void Present(Swapchain aSwapchain, Semaphore aRenderFinishedSemaphore, uint aImageIndex)
    {
        VkSwapchainKHR* swapchainPointer = stackalloc VkSwapchainKHR[] { aSwapchain.MyVkSwapchain };
        VkSemaphore* waitSemaphorePointer = stackalloc VkSemaphore[] { aRenderFinishedSemaphore.MyVkSemaphore };
        
        VkPresentInfoKHR presentInfo = new();
        presentInfo.pSwapchains = swapchainPointer;
        presentInfo.swapchainCount = 1;
        presentInfo.pWaitSemaphores = waitSemaphorePointer;
        presentInfo.waitSemaphoreCount = 1;
        presentInfo.pImageIndices = &aImageIndex;

        vkQueuePresentKHR(MyVkQueue, &presentInfo);
    }
}