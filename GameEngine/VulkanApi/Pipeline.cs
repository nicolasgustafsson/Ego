namespace Graphics;

public unsafe class Pipeline : IGpuDestroyable
{
    public VkPipeline MyVkPipeline;
    public VkPipelineLayout MyVkLayout;
    public VkPipelineBindPoint MyBindPoint;
    
    public void Destroy()
    {
        vkDestroyPipelineLayout(Device.MyVkDevice, MyVkLayout);
        vkDestroyPipeline(Device.MyVkDevice, MyVkPipeline);
    }
}