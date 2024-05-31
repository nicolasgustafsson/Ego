using System.Numerics;
using System.Threading.Channels;
using Vortice.ShaderCompiler;

namespace Graphics;

public unsafe class DescriptorAllocatorGrowable
{
    public const uint MaxPoolSize = 4092;
    
    public class PoolSizeRatio
    {
        public VkDescriptorType Type;
        public float Ratio;
    }

    private List<PoolSizeRatio> myRatios = new();
    public uint mySetsPerPool;
    private List<VkDescriptorPool> myFullPools = new();
    private Stack<VkDescriptorPool> myReadyPools = new();

    public void InitPool(uint aSets, List<PoolSizeRatio> aRatios)
    {
        mySetsPerPool = aSets;
    }
    
    public void ClearPools()
    {
        foreach(var pool in myReadyPools)
        {
            vkResetDescriptorPool(Device.MyVkDevice, pool, 0);
        }
        foreach(var pool in myFullPools)
        {
            vkResetDescriptorPool(Device.MyVkDevice, pool, 0);
            myReadyPools.Push(pool);
        }

        myFullPools.Clear();
    }
    
    public void Destroy()
    {
        foreach(var pool in myFullPools)
        {
            vkDestroyDescriptorPool(Device.MyVkDevice, pool, null);
        }
        
        foreach(var pool in myReadyPools)
        {
            vkDestroyDescriptorPool(Device.MyVkDevice, pool, null);
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
        VkResult result = vkAllocateDescriptorSets(Device.MyVkDevice, &allocInfo, &descriptorSet);
        
        if (result is VkResult.ErrorOutOfPoolMemory or VkResult.ErrorFragmentedPool)
        {
            myFullPools.Add(pool);
            return Allocate(aLayout);
        }
        
        result.CheckResult();

        myReadyPools.Push(pool);

        return descriptorSet;
    }
    
    private void Grow()
    {
        mySetsPerPool = (uint)(mySetsPerPool * 1.5f).AtMost(MaxPoolSize);
    }
    
    private VkDescriptorPool AcquirePool()
    {
        if (!myReadyPools.IsEmpty())
        {
            return myReadyPools.Pop();
        }

        Grow();
        return CreatePool();
    }
    
    private VkDescriptorPool CreatePool()
    {
        List<VkDescriptorPoolSize> sizes = myRatios.Select(ratio => new VkDescriptorPoolSize(ratio.Type, (uint)(ratio.Ratio * (float)mySetsPerPool))).ToList();
        VkDescriptorPoolCreateInfo createInfo = new();
        createInfo.flags = VkDescriptorPoolCreateFlags.None;
        createInfo.maxSets = mySetsPerPool;
        createInfo.poolSizeCount = (uint)myRatios.Count;
        createInfo.pPoolSizes = sizes.AsSpan().GetPointerUnsafe();

        vkCreateDescriptorPool(Device.MyVkDevice, &createInfo, null, out var pool).CheckResult();

        return pool;
    }
}