namespace VulkanApi;

public unsafe class Queue
{
    public VkQueue VkQueue;
    public uint QueueFamilyIndex;
    
    protected VkSemaphoreSubmitInfo GetSemaphoreSubmitInfo(VkPipelineStageFlags2 aStageMask, Semaphore aSemaphore)
    {
        VkSemaphoreSubmitInfo info = new();
        info.semaphore = aSemaphore.VkSemaphore;
        info.stageMask = aStageMask;
        info.deviceIndex = 0;
        info.value = 1;
        return info;
    }
    
    protected VkCommandBufferSubmitInfo GetCommandBufferSubmitInfo(CommandBuffer aCmd)
    {
        VkCommandBufferSubmitInfo info = new();
        info.commandBuffer = aCmd.VkCommandBuffer;
        info.deviceMask = 0;
        return info;
    }
    
    protected VkSubmitInfo2 GetSubmitInfo(VkCommandBufferSubmitInfo* aCmdInfo, VkSemaphoreSubmitInfo* aWaitSemaphoreInfo, VkSemaphoreSubmitInfo* aSignalSemaphoreInfo)
    {
        VkSubmitInfo2 info = new();
        
        info.signalSemaphoreInfoCount = (uint)(aSignalSemaphoreInfo == null ? 0 : 1);
        
        info.pSignalSemaphoreInfos = aSignalSemaphoreInfo;

        info.waitSemaphoreInfoCount = 0;
        
        info.waitSemaphoreInfoCount = (uint)(aWaitSemaphoreInfo == null ? 0 : 1);
        
        info.pWaitSemaphoreInfos = aWaitSemaphoreInfo;

        info.commandBufferInfoCount = 1;
        info.pCommandBufferInfos = aCmdInfo;

        return info;
    }
    
    public void Submit(CommandBuffer aCommandBuffer, Fence? aFence)
    {
        VkCommandBufferSubmitInfo cmdInfo = GetCommandBufferSubmitInfo(aCommandBuffer);

        VkSubmitInfo2 submitInfo = GetSubmitInfo(&cmdInfo, null, null);
        if (aFence != null)
            VkApiDevice.vkQueueSubmit2(VkQueue, 1, &submitInfo, aFence.VkFence).CheckResult();
        else
            VkApiDevice.vkQueueSubmit2(VkQueue, 1, &submitInfo, VkFence.Null).CheckResult();
    }
    
    protected Queue(uint aQueueFamilyIndex)
    {
        QueueFamilyIndex = aQueueFamilyIndex;
        VkApiDevice.vkGetDeviceQueue(Device.VkDevice, aQueueFamilyIndex, 0, out VkQueue);
    }
    
}