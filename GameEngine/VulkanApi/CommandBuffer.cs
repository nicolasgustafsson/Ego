namespace Graphics;

//Currently only one buffer per pool, this might change in the future
public unsafe class CommandBuffer : IGpuDestroyable
{
    public VkCommandPool MyVkCommandPool;
    public VkCommandBuffer MyVkCommandBuffer;
    
    public CommandBuffer(Queue aQueue)
    {
        VkCommandPoolCreateInfo createInfo = new();
        createInfo.flags = VkCommandPoolCreateFlags.ResetCommandBuffer;
        createInfo.queueFamilyIndex = aQueue.MyQueueFamilyIndex;
        
        vkCreateCommandPool(Device.MyVkDevice, &createInfo, null, out MyVkCommandPool).CheckResult();

        VkCommandBufferAllocateInfo allocateInfo = new();
        allocateInfo.commandPool = MyVkCommandPool;
        allocateInfo.commandBufferCount = 1;
        allocateInfo.level = VkCommandBufferLevel.Primary;

        vkAllocateCommandBuffer(Device.MyVkDevice, &allocateInfo, out MyVkCommandBuffer).CheckResult();
    }
    
    public void Destroy()
    {
        vkDestroyCommandPool(Device.MyVkDevice, MyVkCommandPool);
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
    
    public void TransitionImage(Image aImage, VkImageLayout aTo)
    {
        TransitionImage(aImage.MyVkImage, aImage.MyCurrentLayout, aTo);

        aImage.MyCurrentLayout = aTo;
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
    
    public void Blit(Image aFrom, Image aTo)
    {
        Blit(aFrom, aTo.MyVkImage, new VkExtent2D(aTo.MyExtent.width, aTo.MyExtent.height));
    }
    
    public void Blit(Image aFrom, VkImage aTo, VkExtent2D aExtent)
    {
        VkImageBlit2 blitRegion = new();

        blitRegion.srcOffsets[1].x = (int)aFrom.MyExtent.width;
        blitRegion.srcOffsets[1].y = (int)aFrom.MyExtent.height;
        blitRegion.srcOffsets[1].z = 1;
        
        blitRegion.dstOffsets[1].x = (int)aExtent.width;
        blitRegion.dstOffsets[1].y = (int)aExtent.height;
        blitRegion.dstOffsets[1].z = 1;

        blitRegion.srcSubresource.aspectMask = VkImageAspectFlags.Color;
        blitRegion.srcSubresource.baseArrayLayer = 0;
        blitRegion.srcSubresource.layerCount = 1;
        blitRegion.srcSubresource.mipLevel = 0;
        
        blitRegion.dstSubresource.aspectMask = VkImageAspectFlags.Color;
        blitRegion.dstSubresource.baseArrayLayer = 0;
        blitRegion.dstSubresource.layerCount = 1;
        blitRegion.dstSubresource.mipLevel = 0;

        VkBlitImageInfo2 blitInfo = new();

        blitInfo.srcImage = aFrom.MyVkImage;
        blitInfo.srcImageLayout = VkImageLayout.TransferSrcOptimal;
        
        blitInfo.dstImage = aTo;
        blitInfo.dstImageLayout = VkImageLayout.TransferDstOptimal;
        
        blitInfo.filter = VkFilter.Linear;
        blitInfo.regionCount = 1;
        blitInfo.pRegions = &blitRegion;

        vkCmdBlitImage2(MyVkCommandBuffer, &blitInfo);
    }
    
    public void ClearColor(Image aImage, VkImageLayout aImageLayout, VkClearColorValue aColor)
    {
        VkImageSubresourceRange clearRange = new VkImageSubresourceRange(VkImageAspectFlags.Color);
        vkCmdClearColorImage(MyVkCommandBuffer, aImage.MyVkImage, aImageLayout, &aColor, 1, &clearRange);
    }
    
    public void SetPushConstants<T>(T aPushConstants, VkPipelineLayout aLayout, VkShaderStageFlags aShaderStages) where T : unmanaged
    {
        vkCmdPushConstants(MyVkCommandBuffer, aLayout, aShaderStages, 0, (uint)sizeof(T), &aPushConstants);
    }
    
    public void DispatchCompute(uint X, uint Y, uint Z = 1)
    {
        vkCmdDispatch(MyVkCommandBuffer, X, Y, Z);
    }
    
    public void BindPipeline(Pipeline aPipeline)
    {
        vkCmdBindPipeline(MyVkCommandBuffer, aPipeline.MyBindPoint, aPipeline.MyVkPipeline);
    }
    
    public void BindIndexBuffer(AllocatedRawBuffer aIndexRawBuffer, VkIndexType aIndexType = VkIndexType.Uint32)
    {
        vkCmdBindIndexBuffer(MyVkCommandBuffer, aIndexRawBuffer.MyBuffer, 0, aIndexType);
    }
    
    public void BindDescriptorSet(VkPipelineLayout aLayout, VkDescriptorSet aDescriptorSet, VkPipelineBindPoint aBindPoint)
    {
        vkCmdBindDescriptorSets(MyVkCommandBuffer, aBindPoint, aLayout, 0, aDescriptorSet);
    }
        
    
    public void Draw(int aVertexCount)
    {
        vkCmdDraw(MyVkCommandBuffer, (uint)aVertexCount, 1, 0, 0);
    }
    
    public void DrawIndexed(uint aIndexCount)
    {
        vkCmdDrawIndexed(MyVkCommandBuffer, (uint)aIndexCount, 1, 0, 0, 0);
    }
    
    public void SetScissor(VkRect2D aRect)
    {
        vkCmdSetScissor(MyVkCommandBuffer, aRect);
    }
    
    public void DrawIndexed(uint aIndexCount, uint aInstanceCount, uint aFirstIndex, int aVertexOffset, uint aFirstInstance)
    {
        vkCmdDrawIndexed(MyVkCommandBuffer, (uint)aIndexCount, instanceCount: aInstanceCount, firstIndex: aFirstIndex, vertexOffset: aVertexOffset, firstInstance: aFirstInstance);
    }
    
    public void BeginRendering(Image aDrawImage, Image aDepthImage)
    {
        VkRenderingAttachmentInfo attachmentInfo = aDrawImage.GetAttachmentInfo(null, VkImageLayout.General);
        VkRenderingAttachmentInfo depthAttachmentInfo = aDepthImage.GetDepthAttachmentInfo(VkImageLayout.DepthAttachmentOptimal);
        VkRenderingInfo renderingInfo = aDrawImage.GetRenderingInfo(new VkExtent2D(aDrawImage.MyExtent.width, aDrawImage.MyExtent.height), attachmentInfo, depthAttachmentInfo);

        vkCmdBeginRendering(MyVkCommandBuffer, &renderingInfo);

        VkViewport dynamicViewport = new();
        dynamicViewport.x = 0;
        dynamicViewport.y = 0;
        dynamicViewport.width = aDrawImage.MyExtent.width;
        dynamicViewport.height = aDrawImage.MyExtent.height;
        dynamicViewport.minDepth = 0f;
        dynamicViewport.maxDepth = 1f;

        vkCmdSetViewport(MyVkCommandBuffer, 0, dynamicViewport);

        VkRect2D scissor = new();
        scissor.extent = new VkExtent2D(aDrawImage.MyExtent.width, aDrawImage.MyExtent.height);
        scissor.offset = new VkOffset2D(0, 0);

        vkCmdSetScissor(MyVkCommandBuffer, 0, scissor);
    }
    
    public void EndRendering()
    {
        vkCmdEndRendering(MyVkCommandBuffer);
    }
}