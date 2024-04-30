namespace Graphics;

public unsafe class Pipeline
{
    public VkPipeline MyVkPipeline;
    public VkPipelineLayout MyVkLayout;
    
    public void Destroy(Device aDevice)
    {
        vkDestroyPipelineLayout(aDevice.MyVkDevice, MyVkLayout);
        vkDestroyPipeline(aDevice.MyVkDevice, MyVkPipeline);
    }
}