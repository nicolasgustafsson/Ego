namespace Graphics;

public unsafe class Queue
{
    public VkQueue MyVkQueue;
    public uint MyQueueFamilyIndex;
    
    protected VkSemaphoreSubmitInfo GetSemaphoreSubmitInfo(VkPipelineStageFlags2 aStageMask, Graphics.Semaphore aSemaphore)
    {
        VkSemaphoreSubmitInfo info = new();
        info.semaphore = aSemaphore.MyVkSemaphore;
        info.stageMask = aStageMask;
        info.deviceIndex = 0;
        info.value = 1;
        return info;
    }
    
    protected VkCommandBufferSubmitInfo GetCommandBufferSubmitInfo(CommandBuffer aCmd)
    {
        VkCommandBufferSubmitInfo info = new();
        info.commandBuffer = aCmd.MyVkCommandBuffer;
        info.deviceMask = 0;
        return info;
    }
    
    protected VkSubmitInfo2 GetSubmitInfo(VkCommandBufferSubmitInfo* aCmdInfo, VkSemaphoreSubmitInfo* aWaitSemaphoreInfo, VkSemaphoreSubmitInfo* aSignalSemaphoreInfo)
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
    
    protected Queue(Device aDevice, uint aQueueFamilyIndex)
    {
        vkGetDeviceQueue(aDevice.MyVkDevice, aQueueFamilyIndex, 0, out MyVkQueue);
    }
    
}