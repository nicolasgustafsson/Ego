﻿namespace VulkanApi;

public unsafe class Sampler : IGpuDestroyable
{
    public VkSampler VkSampler;
    
    public Sampler(VkFilter aFilter)
    {
        VkSamplerCreateInfo samplerCreateInfo = new();
        samplerCreateInfo.minFilter = aFilter;
        samplerCreateInfo.magFilter = aFilter;

        vkCreateSampler(Device.VkDevice, &samplerCreateInfo, null, out VkSampler).CheckResult();
    }
    
    public void Destroy()
    {
        vkDestroySampler(Device.VkDevice, VkSampler);
    }
}