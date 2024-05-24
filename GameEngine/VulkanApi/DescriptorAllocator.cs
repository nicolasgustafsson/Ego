global using Utilities.Interop;
using Vortice.ShaderCompiler;

namespace Graphics;

public unsafe class DescriptorAllocator : IGpuDestroyable
{
    public class PoolSizeRatio
    {
        public VkDescriptorType Type;
        public float Ratio;
    }

    public VkDescriptorPool MyPool;

    public void InitPool(uint aMaxSets, List<PoolSizeRatio> aRatios)
    {
        List<VkDescriptorPoolSize> sizes = aRatios.Select(ratio => new VkDescriptorPoolSize(ratio.Type, (uint)(ratio.Ratio * (float)aMaxSets))).ToList();
        VkDescriptorPoolCreateInfo createInfo = new();
        createInfo.flags = VkDescriptorPoolCreateFlags.None;
        createInfo.maxSets = aMaxSets;
        createInfo.poolSizeCount = (uint)aRatios.Count;
        createInfo.pPoolSizes = sizes.AsSpan().GetPointerUnsafe();

        vkCreateDescriptorPool(Device.MyVkDevice, &createInfo, null, out MyPool).CheckResult();
    }
    
    public void ClearDescriptors()
    {
        vkResetDescriptorPool(Device.MyVkDevice, MyPool, VkDescriptorPoolResetFlags.None);
    }
    
    public void Destroy()
    {
        vkDestroyDescriptorPool(Device.MyVkDevice, MyPool, null);
    }
    
    public VkDescriptorSet Allocate(VkDescriptorSetLayout aLayout)
    {
        VkDescriptorSetAllocateInfo allocInfo = new();
        allocInfo.descriptorPool = MyPool;
        allocInfo.descriptorSetCount = 1;
        allocInfo.pSetLayouts = &aLayout;

        VkDescriptorSet descriptorSet;
        vkAllocateDescriptorSets(Device.MyVkDevice, &allocInfo, &descriptorSet);

        return descriptorSet;
    }
}