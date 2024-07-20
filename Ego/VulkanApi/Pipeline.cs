namespace VulkanApi;

public unsafe class Pipeline : IGpuDestroyable
{
    public VkPipeline VkPipeline;
    public VkPipelineLayout VkLayout;
    public VkPipelineBindPoint BindPoint;
    
    public void Destroy()
    {
        vkDestroyPipelineLayout(Device.VkDevice, VkLayout);
        vkDestroyPipeline(Device.VkDevice, VkPipeline);
    }
}