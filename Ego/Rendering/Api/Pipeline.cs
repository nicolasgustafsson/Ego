namespace VulkanApi;

public unsafe class Pipeline : IGpuDestroyable
{
    public VkPipeline VkPipeline;
    public VkPipelineLayout VkLayout;
    public VkPipelineBindPoint BindPoint;
    
    public void Destroy()
    {
        VkApiDevice.vkDestroyPipelineLayout(Device.VkDevice, VkLayout);
        VkApiDevice.vkDestroyPipeline(Device.VkDevice, VkPipeline);
    }
}