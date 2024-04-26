namespace Graphics;

//Currently only one buffer per pool, this might change in the future
public unsafe class CommandBuffer
{
    public VkCommandPool MyVkCommandPool;
    public VkCommandBuffer MyVkCommandBuffer;
    
    public CommandBuffer(Device aDevice, Queue aQueue)
    {
        VkCommandPoolCreateInfo createInfo = new();
        createInfo.flags = VkCommandPoolCreateFlags.ResetCommandBuffer;
        createInfo.queueFamilyIndex = aQueue.MyQueueFamilyIndex;
        
        vkCreateCommandPool(aDevice.MyVkDevice, &createInfo, null, out MyVkCommandPool).CheckResult();

        VkCommandBufferAllocateInfo allocateInfo = new();
        allocateInfo.commandPool = MyVkCommandPool;
        allocateInfo.commandBufferCount = 1;
        allocateInfo.level = VkCommandBufferLevel.Primary;

        vkAllocateCommandBuffer(aDevice.MyVkDevice, &allocateInfo, out MyVkCommandBuffer).CheckResult();
    }
    
    public void Destroy(Device aDevice)
    {
        vkDestroyCommandPool(aDevice.MyVkDevice, MyVkCommandPool);
    }
    
    public void Reset()
    {
        vkResetCommandBuffer(MyVkCommandBuffer, VkCommandBufferResetFlags.None).CheckResult();
    }
    
    public void BeginRecording()
    {
        vkBeginCommandBuffer(MyVkCommandBuffer, VkCommandBufferUsageFlags.OneTimeSubmit).CheckResult();
    }
    
    public void EndRecording()
    {
        vkEndCommandBuffer(MyVkCommandBuffer);
    }
    
    public void TransitionImage(VkImage aImage, VkImageLayout aFrom, VkImageLayout aTo)
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

        vkCmdPipelineBarrier2(MyVkCommandBuffer, &depInfo);
    }
    
    public void ClearColor(VkImage aImage, VkImageLayout aImageLayout, VkClearColorValue aColor)
    {
        VkImageSubresourceRange clearRange = new VkImageSubresourceRange(VkImageAspectFlags.Color);
        vkCmdClearColorImage(MyVkCommandBuffer, aImage, aImageLayout, &aColor, 1, &clearRange);
    }
}