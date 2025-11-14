namespace VulkanApi;

//Currently only one buffer per pool, this might change in the future
public unsafe class CommandBuffer : IGpuDestroyable
{
    public VkCommandPool VkCommandPool;
    public VkCommandBuffer VkCommandBuffer;
    private bool Transient = false;
    
    public CommandBuffer(Queue aQueue, bool aTransient = false)
    {
        VkCommandPoolCreateInfo createInfo = new();
        if (!aTransient)
            createInfo.flags = VkCommandPoolCreateFlags.ResetCommandBuffer;
        else
            createInfo.flags = VkCommandPoolCreateFlags.Transient;
        createInfo.queueFamilyIndex = aQueue.QueueFamilyIndex;

        Transient = aTransient;
        
        VkApiDevice.vkCreateCommandPool(Device.VkDevice, &createInfo, null, out VkCommandPool).CheckResult();

        VkCommandBufferAllocateInfo allocateInfo = new();
        allocateInfo.commandPool = VkCommandPool;
        allocateInfo.commandBufferCount = 1;
        allocateInfo.level = VkCommandBufferLevel.Primary;

        VkApiDevice.vkAllocateCommandBuffer(Device.VkDevice, &allocateInfo, out VkCommandBuffer).CheckResult();
    }
    
    public void Destroy()
    {
        VkApiDevice.vkDestroyCommandPool(Device.VkDevice, VkCommandPool);
    }
    
    public CommandBufferHandle BeginRecording()
    {
        return new CommandBufferHandle(this, !Transient);
    }
}

public unsafe class CommandBufferHandle : IDisposable
{
    private CommandBuffer CommandBuffer;
    public VkCommandBuffer VkCommandBuffer => CommandBuffer.VkCommandBuffer;
    
    internal CommandBufferHandle(CommandBuffer aCommandBuffer, bool aShouldReset)
    {
        CommandBuffer = aCommandBuffer;

        if (aShouldReset)
            VkApiDevice.vkResetCommandBuffer(VkCommandBuffer, VkCommandBufferResetFlags.None).CheckResult();
        VkApiDevice.vkBeginCommandBuffer(VkCommandBuffer, VkCommandBufferUsageFlags.OneTimeSubmit).CheckResult();
    }
    
    public void CopyBufferToBuffer(AllocatedRawBuffer aFrom, AllocatedRawBuffer aTo, uint aSize)
    {
        VkBufferCopy aCopy = new();
        aCopy.dstOffset = 0;
        aCopy.srcOffset = 0;
        aCopy.size = aSize;
        VkApiDevice.vkCmdCopyBuffer(VkCommandBuffer, aFrom.Buffer, aTo.Buffer, 1, &aCopy);
    }
    
    public void CopyBufferToImage(AllocatedRawBuffer aBuffer, Image aImage, VkImageLayout aLayout)
    {
        VkBufferImageCopy copyRegion = new();
        copyRegion.bufferOffset = 0;
        copyRegion.bufferRowLength = 0;
        copyRegion.bufferImageHeight = 0;

        copyRegion.imageSubresource.aspectMask = VkImageAspectFlags.Color;
        copyRegion.imageSubresource.mipLevel = 0;
        copyRegion.imageSubresource.baseArrayLayer = 0;
        copyRegion.imageSubresource.layerCount = 1;
        copyRegion.imageExtent = aImage.Extent;
        
        VkApiDevice.vkCmdCopyBufferToImage(VkCommandBuffer, aBuffer.Buffer, aImage.VkImage, VkImageLayout.TransferDstOptimal, 1, &copyRegion);
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

        VkApiDevice.vkCmdPipelineBarrier2(VkCommandBuffer, &depInfo);
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

        VkApiDevice.vkCmdBlitImage2(VkCommandBuffer, &blitInfo);
    }
    
    public void ClearColor(Image aImage, VkImageLayout aImageLayout, VkClearColorValue aColor)
    {
        VkImageSubresourceRange clearRange = new VkImageSubresourceRange(VkImageAspectFlags.Color);
        VkApiDevice.vkCmdClearColorImage(VkCommandBuffer, aImage.VkImage, aImageLayout, &aColor, 1, &clearRange);

        aImage.CurrentLayout = aImageLayout;
    }
    
    public void SetPushConstants<T>(T aPushConstants, VkPipelineLayout aLayout) where T : unmanaged
    {
        VkApiDevice.vkCmdPushConstants(VkCommandBuffer, aLayout, VkShaderStageFlags.Fragment | VkShaderStageFlags.Vertex | VkShaderStageFlags.Compute | VkShaderStageFlags.MeshEXT, 0, (uint)sizeof(T), &aPushConstants);
    }
    
    public void SetPushConstants<T>(T aPushConstants, VkPipelineLayout aLayout, VkShaderStageFlags aShaderStages) where T : unmanaged
    {
        VkApiDevice.vkCmdPushConstants(VkCommandBuffer, aLayout, aShaderStages, 0, (uint)sizeof(T), &aPushConstants);
    }
    
    public void DispatchCompute(uint X, uint Y, uint Z = 1)
    {
        VkApiDevice.vkCmdDispatch(VkCommandBuffer, X, Y, Z);
    }
    
    public void BindPipeline(Pipeline aPipeline)
    {
        VkApiDevice.vkCmdBindPipeline(VkCommandBuffer, aPipeline.BindPoint, aPipeline.VkPipeline);
    }
    
    public void BindIndexBuffer(AllocatedRawBuffer aIndexRawBuffer, VkIndexType aIndexType = VkIndexType.Uint32)
    {
        VkApiDevice.vkCmdBindIndexBuffer(VkCommandBuffer, aIndexRawBuffer.Buffer, 0, aIndexType);
    }
    
    public void BindDescriptorSet(VkPipelineLayout aLayout, VkDescriptorSet aDescriptorSet, VkPipelineBindPoint aBindPoint, int aDescriptorIndex = 0)
    {
        VkApiDevice.vkCmdBindDescriptorSets(VkCommandBuffer, aBindPoint, aLayout, (uint)aDescriptorIndex, aDescriptorSet);
    }
    
    public void SetCullMode(VkCullModeFlags aCullMode)
    {
        VkApiDevice.vkCmdSetCullModeEXT(VkCommandBuffer, aCullMode);
    }
    
    public void SetBlendMode(BlendMode aBlendMode)
    {
        VkBool32 enable = true;
        VkApiDevice.vkCmdSetColorBlendEnableEXT(VkCommandBuffer, 0, 1, &enable);
        VkColorBlendEquationEXT equation = aBlendMode.ToVkBlendEquation();
        VkApiDevice.vkCmdSetColorBlendEquationEXT(VkCommandBuffer, 0, 1, &equation);
    }
    
    public void SetPrimitiveTopology(VkPrimitiveTopology aTopology)
    {
        VkApiDevice.vkCmdSetPrimitiveTopology(VkCommandBuffer, aTopology);
        VkApiDevice.vkCmdSetPrimitiveRestartEnableEXT(VkCommandBuffer, VkBool32.False);
    }
    
    public void SetFrontFace(VkFrontFace aFrontFace)
    {
        VkApiDevice.vkCmdSetFrontFace(VkCommandBuffer, aFrontFace);
    }
    
    public void SetDepthCompareOperation(VkCompareOp aCompareOperation)
    {
        VkApiDevice.vkCmdSetDepthCompareOp(VkCommandBuffer, aCompareOperation);
    }
    
    public void SetDepthTestEnable(bool aEnable)
    {
        VkApiDevice.vkCmdSetDepthTestEnable(VkCommandBuffer, aEnable);
    }
    
    public void SetStencilTestEnable(bool aEnable)
    {
        VkApiDevice.vkCmdSetStencilTestEnable(VkCommandBuffer, aEnable);
    }
    
    public void SetDepthWrite(bool aEnable)
    {
        VkApiDevice.vkCmdSetDepthWriteEnable(VkCommandBuffer, aEnable);
    }
    
    public void EnableShaderObjects(VkSampleCountFlags aMultisample)
    {
        VkApiDevice.vkCmdSetRasterizerDiscardEnable(VkCommandBuffer, VkBool32.False);
        VkApiDevice.vkCmdSetDepthBoundsTestEnableEXT(VkCommandBuffer, false);
        VkApiDevice.vkCmdSetDepthBiasEnable(VkCommandBuffer, false);
        VkApiDevice.vkCmdSetLogicOpEnableEXT(VkCommandBuffer, false);
        VkBool32 untrue = false;
        VkApiDevice.vkCmdSetColorBlendEnableEXT(VkCommandBuffer, 0, 1, &untrue);

        VkColorComponentFlags flags = VkColorComponentFlags.All;

        VkApiDevice.vkCmdSetColorWriteMaskEXT(VkCommandBuffer, 0, 1, &flags);
        VkApiDevice.vkCmdSetPolygonModeEXT(VkCommandBuffer, VkPolygonMode.Fill);
        uint sampleMask = ~(uint)(0);
        VkApiDevice.vkCmdSetSampleMaskEXT(VkCommandBuffer, aMultisample, &sampleMask);
        VkApiDevice.vkCmdSetRasterizationSamplesEXT(VkCommandBuffer, aMultisample);
        VkApiDevice.vkCmdSetAlphaToCoverageEnableEXT(VkCommandBuffer, VkBool32.True);
    }

    public void SetMsaa(VkSampleCountFlags aMultisample)
    {
        VkApiDevice.vkCmdSetRasterizationSamplesEXT(VkCommandBuffer, aMultisample);
    }
    
    public void BindShader(ShaderObject.Shader aShader)
    {
        fixed(VkShaderStageFlags* flags = &aShader.VkStage)
        {
            fixed(VkShaderEXT* shader = &aShader.VkShader)
            {
                VkApiDevice.vkCmdBindShadersEXT(VkCommandBuffer, 1, flags, shader);
            }
        }
    }
    
    public void UnbindShader(VkShaderStageFlags aShaderStage)
    {
        VkApiDevice.vkCmdBindShadersEXT(VkCommandBuffer, 1, &aShaderStage, null);
    }
    
    public void Draw(int aVertexCount)
    {
        VkApiDevice.vkCmdDraw(VkCommandBuffer, (uint)aVertexCount, 1, 0, 0);
    }
    
    public void DrawIndexed(uint aIndexCount)
    {
        VkApiDevice.vkCmdSetVertexInputEXT(VkCommandBuffer, 0, null, 0, null);
        VkApiDevice.vkCmdDrawIndexed(VkCommandBuffer, (uint)aIndexCount, 1, 0, 0, 0);
    }
    
    public void SetScissor(VkRect2D aRect)
    {
        VkApiDevice.vkCmdSetScissor(VkCommandBuffer, 0, aRect);
    }
    
    public void DrawIndexed(uint aIndexCount, uint aInstanceCount, uint aFirstIndex, int aVertexOffset, uint aFirstInstance)
    {
        VkApiDevice.vkCmdDrawIndexed(VkCommandBuffer, (uint)aIndexCount, instanceCount: aInstanceCount, firstIndex: aFirstIndex, vertexOffset: aVertexOffset, firstInstance: aFirstInstance);
    }
    
    public void BeginRendering(Image aDrawImage, Image aDepthImage)
    {
        VkRenderingAttachmentInfo attachmentInfo = aDrawImage.GetAttachmentInfo(null);
        VkRenderingAttachmentInfo depthAttachmentInfo = aDepthImage.GetDepthAttachmentInfo(VkImageLayout.DepthAttachmentOptimal);
        VkRenderingInfo renderingInfo = aDrawImage.GetRenderingInfo(new VkExtent2D(aDrawImage.Extent.width, aDrawImage.Extent.height), attachmentInfo, depthAttachmentInfo);

        VkApiDevice.vkCmdBeginRendering(VkCommandBuffer, &renderingInfo);
        
        VkViewport dynamicViewport = new();
        dynamicViewport.x = 0; 
        dynamicViewport.y = 0;
        dynamicViewport.width = aDrawImage.Extent.width;
        dynamicViewport.height = aDrawImage.Extent.height;
        dynamicViewport.minDepth = 0f;
        dynamicViewport.maxDepth = 1f;

        VkApiDevice.vkCmdSetViewport(VkCommandBuffer, 0, dynamicViewport);
        VkApiDevice.vkCmdSetViewportWithCount(VkCommandBuffer, 1, &dynamicViewport);

        VkRect2D scissor = new();
        scissor.extent = new VkExtent2D(aDrawImage.Extent.width, aDrawImage.Extent.height);
        scissor.offset = new VkOffset2D(0, 0);

        VkApiDevice.vkCmdSetScissor(VkCommandBuffer, 0, scissor);
        VkApiDevice.vkCmdSetScissorWithCount(VkCommandBuffer, 1, &scissor);
    }
    
    public void BeginRendering(Image aDrawImage)
    {
        VkRenderingAttachmentInfo attachmentInfo = aDrawImage.GetAttachmentInfo(null);
        VkRenderingInfo renderingInfo = aDrawImage.GetRenderingInfo(new VkExtent2D(aDrawImage.Extent.width, aDrawImage.Extent.height), attachmentInfo);

        VkApiDevice.vkCmdBeginRendering(VkCommandBuffer, &renderingInfo);
        
        VkViewport dynamicViewport = new();
        dynamicViewport.x = 0; 
        dynamicViewport.y = 0;
        dynamicViewport.width = aDrawImage.Extent.width;
        dynamicViewport.height = aDrawImage.Extent.height;
        dynamicViewport.minDepth = 0f;
        dynamicViewport.maxDepth = 1f;

        VkApiDevice.vkCmdSetViewport(VkCommandBuffer, 0, dynamicViewport);
        VkApiDevice.vkCmdSetViewportWithCount(VkCommandBuffer, 1, &dynamicViewport);

        VkRect2D scissor = new();
        scissor.extent = new VkExtent2D(aDrawImage.Extent.width, aDrawImage.Extent.height);
        scissor.offset = new VkOffset2D(0, 0);

        VkApiDevice.vkCmdSetScissor(VkCommandBuffer, 0, scissor);
        VkApiDevice.vkCmdSetScissorWithCount(VkCommandBuffer, 1, &scissor);
    }
    
    public void ResolveMsaa(Image aFrom, Image aTo)
    {
        VkImageResolve resolveRegion;
        //resolveRegion.srcSubresource = 
            
        resolveRegion.srcSubresource.aspectMask = VkImageAspectFlags.Color;
        resolveRegion.srcSubresource.baseArrayLayer = 0;
        resolveRegion.srcSubresource.layerCount = 1;
        resolveRegion.srcSubresource.mipLevel = 0;
        
        resolveRegion.dstSubresource.aspectMask = VkImageAspectFlags.Color;
        resolveRegion.dstSubresource.baseArrayLayer = 0;
        resolveRegion.dstSubresource.layerCount = 1;
        resolveRegion.dstSubresource.mipLevel = 0;
        resolveRegion.extent = aFrom.Extent;
        VkApiDevice.vkCmdResolveImage(VkCommandBuffer, aFrom.VkImage, aFrom.CurrentLayout, aTo.VkImage, aTo.CurrentLayout, 1, &resolveRegion);
    }
    
    public void EndRendering()
    {
        VkApiDevice.vkCmdEndRendering(VkCommandBuffer);
    }

    public void Dispose()
    {
        VkApiDevice.vkEndCommandBuffer(VkCommandBuffer);
    }
}
