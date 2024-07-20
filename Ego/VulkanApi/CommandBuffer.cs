namespace VulkanApi;

//Currently only one buffer per pool, this might change in the future
public unsafe class CommandBuffer : IGpuDestroyable
{
    public VkCommandPool VkCommandPool;
    public VkCommandBuffer VkCommandBuffer;
    
    public CommandBuffer(Queue aQueue)
    {
        VkCommandPoolCreateInfo createInfo = new();
        createInfo.flags = VkCommandPoolCreateFlags.ResetCommandBuffer;
        createInfo.queueFamilyIndex = aQueue.QueueFamilyIndex;
        
        vkCreateCommandPool(Device.VkDevice, &createInfo, null, out VkCommandPool).CheckResult();

        VkCommandBufferAllocateInfo allocateInfo = new();
        allocateInfo.commandPool = VkCommandPool;
        allocateInfo.commandBufferCount = 1;
        allocateInfo.level = VkCommandBufferLevel.Primary;

        vkAllocateCommandBuffer(Device.VkDevice, &allocateInfo, out VkCommandBuffer).CheckResult();
    }
    
    public void Destroy()
    {
        vkDestroyCommandPool(Device.VkDevice, VkCommandPool);
    }
    
    public CommandBufferHandle BeginRecording()
    {
        return new CommandBufferHandle(this);
    }
}

public unsafe class CommandBufferHandle : IDisposable
{
    private CommandBuffer CommandBuffer;
    public VkCommandBuffer VkCommandBuffer => CommandBuffer.VkCommandBuffer;
    
    internal CommandBufferHandle(CommandBuffer aCommandBuffer)
    {
        CommandBuffer = aCommandBuffer;
        
        vkResetCommandBuffer(VkCommandBuffer, VkCommandBufferResetFlags.None).CheckResult();
        vkBeginCommandBuffer(VkCommandBuffer, VkCommandBufferUsageFlags.OneTimeSubmit).CheckResult();
    }
    
    public void TransitionImage(Image aImage, VkImageLayout aTo)
    {
        TransitionImage(aImage.VkImage, aImage.CurrentLayout, aTo);

        aImage.CurrentLayout = aTo;
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

        vkCmdPipelineBarrier2(VkCommandBuffer, &depInfo);
    }
    
    public void Blit(Image aFrom, Image aTo)
    {
        Blit(aFrom, aTo.VkImage, new VkExtent2D(aTo.Extent.width, aTo.Extent.height));
    }
    
    public void Blit(Image aFrom, VkImage aTo, VkExtent2D aExtent)
    {
        VkImageBlit2 blitRegion = new();

        blitRegion.srcOffsets[1].x = (int)aFrom.Extent.width;
        blitRegion.srcOffsets[1].y = (int)aFrom.Extent.height;
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

        blitInfo.srcImage = aFrom.VkImage;
        blitInfo.srcImageLayout = VkImageLayout.TransferSrcOptimal;
        
        blitInfo.dstImage = aTo;
        blitInfo.dstImageLayout = VkImageLayout.TransferDstOptimal;
        
        blitInfo.filter = VkFilter.Linear;
        blitInfo.regionCount = 1;
        blitInfo.pRegions = &blitRegion;

        vkCmdBlitImage2(VkCommandBuffer, &blitInfo);
    }
    
    public void ClearColor(Image aImage, VkImageLayout aImageLayout, VkClearColorValue aColor)
    {
        VkImageSubresourceRange clearRange = new VkImageSubresourceRange(VkImageAspectFlags.Color);
        vkCmdClearColorImage(VkCommandBuffer, aImage.VkImage, aImageLayout, &aColor, 1, &clearRange);
    }
    
    public void SetPushConstants<T>(T aPushConstants, VkPipelineLayout aLayout, VkShaderStageFlags aShaderStages) where T : unmanaged
    {
        vkCmdPushConstants(VkCommandBuffer, aLayout, aShaderStages, 0, (uint)sizeof(T), &aPushConstants);
    }
    
    public void DispatchCompute(uint X, uint Y, uint Z = 1)
    {
        vkCmdDispatch(VkCommandBuffer, X, Y, Z);
    }
    
    public void BindPipeline(Pipeline aPipeline)
    {
        vkCmdBindPipeline(VkCommandBuffer, aPipeline.BindPoint, aPipeline.VkPipeline);
    }
    
    public void BindIndexBuffer(AllocatedRawBuffer aIndexRawBuffer, VkIndexType aIndexType = VkIndexType.Uint32)
    {
        vkCmdBindIndexBuffer(VkCommandBuffer, aIndexRawBuffer.Buffer, 0, aIndexType);
    }
    
    public void BindDescriptorSet(VkPipelineLayout aLayout, VkDescriptorSet aDescriptorSet, VkPipelineBindPoint aBindPoint)
    {
        vkCmdBindDescriptorSets(VkCommandBuffer, aBindPoint, aLayout, 0, aDescriptorSet);
    }
        
    
    public void Draw(int aVertexCount)
    {
        vkCmdDraw(VkCommandBuffer, (uint)aVertexCount, 1, 0, 0);
    }
    
    public void DrawIndexed(uint aIndexCount)
    {
        vkCmdDrawIndexed(VkCommandBuffer, (uint)aIndexCount, 1, 0, 0, 0);
    }
    
    public void SetScissor(VkRect2D aRect)
    {
        vkCmdSetScissor(VkCommandBuffer, aRect);
    }
    
    public void DrawIndexed(uint aIndexCount, uint aInstanceCount, uint aFirstIndex, int aVertexOffset, uint aFirstInstance)
    {
        vkCmdDrawIndexed(VkCommandBuffer, (uint)aIndexCount, instanceCount: aInstanceCount, firstIndex: aFirstIndex, vertexOffset: aVertexOffset, firstInstance: aFirstInstance);
    }
    
    public void BeginRendering(Image aDrawImage, Image aDepthImage)
    {
        VkRenderingAttachmentInfo attachmentInfo = aDrawImage.GetAttachmentInfo(null);
        VkRenderingAttachmentInfo depthAttachmentInfo = aDepthImage.GetDepthAttachmentInfo(VkImageLayout.DepthAttachmentOptimal);
        VkRenderingInfo renderingInfo = aDrawImage.GetRenderingInfo(new VkExtent2D(aDrawImage.Extent.width, aDrawImage.Extent.height), attachmentInfo, depthAttachmentInfo);

        vkCmdBeginRendering(VkCommandBuffer, &renderingInfo);

        VkViewport dynamicViewport = new();
        dynamicViewport.x = 0;
        dynamicViewport.y = 0;
        dynamicViewport.width = aDrawImage.Extent.width;
        dynamicViewport.height = aDrawImage.Extent.height;
        dynamicViewport.minDepth = 0f;
        dynamicViewport.maxDepth = 1f;

        vkCmdSetViewport(VkCommandBuffer, 0, dynamicViewport);

        VkRect2D scissor = new();
        scissor.extent = new VkExtent2D(aDrawImage.Extent.width, aDrawImage.Extent.height);
        scissor.offset = new VkOffset2D(0, 0);

        vkCmdSetScissor(VkCommandBuffer, 0, scissor);
    }
    
    public void EndRendering()
    {
        vkCmdEndRendering(VkCommandBuffer);
    }

    public void Dispose()
    {
        vkEndCommandBuffer(VkCommandBuffer);
    }
}
