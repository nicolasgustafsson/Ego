using Utilities;
using Vortice.ShaderCompiler;

namespace VulkanApi;

public unsafe class DescriptorAllocatorGrowable : IGpuDestroyable
{
    public const uint MaxPoolSize = 4092;
    
    public class PoolSizeRatio
    {
        public VkDescriptorType Type;
        public float Ratio;

        public PoolSizeRatio()
        {
        }

        public PoolSizeRatio(float ratio, VkDescriptorType type)
        {
            Ratio = ratio;
            Type = type;
        }
    }

    private List<PoolSizeRatio> Ratios = new();
    public uint SetsPerPool;
    private List<VkDescriptorPool> FullPools = new();
    private Stack<VkDescriptorPool> ReadyPools = new();

    public void InitPool(uint aSets, List<PoolSizeRatio> aRatios)
    {
        SetsPerPool = aSets;
        Ratios = aRatios;
    }
    
    public void ClearPools()
    {
        foreach(var pool in ReadyPools)
        {
            vkResetDescriptorPool(Device.VkDevice, pool, 0);
        }
        foreach(var pool in FullPools)
        {
            vkResetDescriptorPool(Device.VkDevice, pool, 0);
            ReadyPools.Push(pool);
        }

        FullPools.Clear();
    }
    
    public void Destroy()
    {
        foreach(var pool in FullPools)
        {
            vkDestroyDescriptorPool(Device.VkDevice, pool, null);
        }
        
        foreach(var pool in ReadyPools)
        {
            vkDestroyDescriptorPool(Device.VkDevice, pool, null);
        }
    }
    
    public VkDescriptorSet Allocate(VkDescriptorSetLayout aLayout)
    {
        var pool = AcquirePool();
        VkDescriptorSetAllocateInfo allocInfo = new();
        allocInfo.descriptorPool = pool;
        allocInfo.descriptorSetCount = 1;
        allocInfo.pSetLayouts = &aLayout;

        VkDescriptorSet descriptorSet;
        VkResult result = vkAllocateDescriptorSets(Device.VkDevice, &allocInfo, &descriptorSet);
        
        if (result is VkResult.ErrorOutOfPoolMemory or VkResult.ErrorFragmentedPool)
        {
            FullPools.Add(pool);
            return Allocate(aLayout);
        }
        
        result.CheckResult();

        ReadyPools.Push(pool);

        return descriptorSet;
    }
    
    private void Grow()
    {
        SetsPerPool = (uint)(SetsPerPool * 1.5f).AtMost(MaxPoolSize);
    }
    
    private VkDescriptorPool AcquirePool()
    {
        if (!ReadyPools.IsEmpty())
        {
            return ReadyPools.Pop();
        }

        Grow();
        return CreatePool();
    }
    
    private VkDescriptorPool CreatePool()
    {
        List<VkDescriptorPoolSize> sizes = Ratios.Select(ratio => new VkDescriptorPoolSize(ratio.Type, (uint)(ratio.Ratio * (float)SetsPerPool))).ToList();
        VkDescriptorPoolCreateInfo createInfo = new();
        createInfo.flags = VkDescriptorPoolCreateFlags.None;
        createInfo.maxSets = SetsPerPool;
        createInfo.poolSizeCount = (uint)Ratios.Count;
        createInfo.pPoolSizes = sizes.AsSpan().GetPointerUnsafe();

        vkCreateDescriptorPool(Device.VkDevice, &createInfo, null, out var pool).CheckResult();

        return pool;
    }
}