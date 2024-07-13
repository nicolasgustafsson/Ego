namespace VulkanApi;

public unsafe class Sampler : IGpuDestroyable
{
    public VkSampler MyVkSampler;
    
    public Sampler(VkFilter aFilter)
    {
        VkSamplerCreateInfo samplerCreateInfo = new();
        samplerCreateInfo.minFilter = aFilter;
        samplerCreateInfo.magFilter = aFilter;

        vkCreateSampler(Device.MyVkDevice, &samplerCreateInfo, null, out MyVkSampler).CheckResult();
    }
    
    public void Destroy()
    {
        vkDestroySampler(Device.MyVkDevice, MyVkSampler);
    }
}