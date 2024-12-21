namespace VulkanApi;

//Used for imgui integration, otherwise we use Dynamic Rendering
//Imgui integration needs this as the library we're using does not define Dynamic Rendering when generating bindings
public unsafe class RenderPass
{
    public VkRenderPass myRenderPass = new();
    
    public RenderPass(Swapchain aSwapchain)
    {
        
        VkAttachmentDescription attachmentDescription = new();
        attachmentDescription.format = aSwapchain.ImageFormat;
        attachmentDescription.samples = VkSampleCountFlags.Count1;
        attachmentDescription.loadOp = VkAttachmentLoadOp.Clear;
        attachmentDescription.storeOp = VkAttachmentStoreOp.Store;
        attachmentDescription.stencilLoadOp = VkAttachmentLoadOp.DontCare;
        attachmentDescription.stencilStoreOp = VkAttachmentStoreOp.DontCare;

        attachmentDescription.initialLayout = VkImageLayout.Undefined;
        attachmentDescription.finalLayout = VkImageLayout.PresentSrcKHR;

        VkAttachmentReference colorAttachmentRef = new();
        colorAttachmentRef.attachment = 0;
        colorAttachmentRef.layout = VkImageLayout.ColorAttachmentOptimal;

        VkSubpassDescription subPass = new();
        subPass.pipelineBindPoint = VkPipelineBindPoint.Graphics;
        subPass.colorAttachmentCount = 1;
        subPass.pColorAttachments = &colorAttachmentRef;

        VkRenderPassCreateInfo renderPassCreateInfo = new();
        renderPassCreateInfo.attachmentCount = 1;
        renderPassCreateInfo.pAttachments = &attachmentDescription;
        renderPassCreateInfo.subpassCount = 1;
        renderPassCreateInfo.pSubpasses = &subPass;

        vkCreateRenderPass(Device.VkDevice, renderPassCreateInfo, null, out VkRenderPass renderPass);

        myRenderPass = renderPass;
    }
}