global using Utilities.Interop;
using Vortice.ShaderCompiler;

namespace Graphics;

public unsafe class DescriptorAllocator
{
    public class PoolSizeRatio
    {
        public VkDescriptorType Type;
        public float Ratio;
    }

    public VkDescriptorPool MyPool;

    public void InitPool(Device aDevice, uint aMaxSets, List<PoolSizeRatio> aRatios)
    {
        List<VkDescriptorPoolSize> sizes = aRatios.Select(ratio => new VkDescriptorPoolSize(ratio.Type, (uint)(ratio.Ratio * (float)aMaxSets))).ToList();
        VkDescriptorPoolCreateInfo createInfo = new();
        createInfo.flags = VkDescriptorPoolCreateFlags.None;
        createInfo.maxSets = aMaxSets;
        createInfo.poolSizeCount = (uint)aRatios.Count;
        createInfo.pPoolSizes = sizes.AsSpan().GetPointerUnsafe();

        vkCreateDescriptorPool(aDevice.MyVkDevice, &createInfo, null, out MyPool).CheckResult();
    }
    
    public void ClearDescriptors(Device aDevice)
    {
        vkResetDescriptorPool(aDevice.MyVkDevice, MyPool, VkDescriptorPoolResetFlags.None);
    }
    
    public void DestroyPool(Device aDevice)
    {
        vkDestroyDescriptorPool(aDevice.MyVkDevice, MyPool, null);
    }
    
    public VkDescriptorSet Allocate(Device aDevice, VkDescriptorSetLayout aLayout)
    {
        VkDescriptorSetAllocateInfo allocInfo = new();
        allocInfo.descriptorPool = MyPool;
        allocInfo.descriptorSetCount = 1;
        allocInfo.pSetLayouts = &aLayout;

        VkDescriptorSet descriptorSet;
        vkAllocateDescriptorSets(aDevice.MyVkDevice, &allocInfo, &descriptorSet);

        return descriptorSet;
    }
}