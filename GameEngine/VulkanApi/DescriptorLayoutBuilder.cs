namespace Graphics;

public unsafe class DescriptorLayoutBuilder
{
    public List<VkDescriptorSetLayoutBinding> MyBindings = new();
    
    public void AddBinding(uint aBinding, VkDescriptorType aType)
    {
        MyBindings.Add(new() { binding = aBinding, descriptorType = aType, descriptorCount = 1 });
    }
    
    public void Clear()
    {
        MyBindings.Clear();
    }

    public VkDescriptorSetLayout Build(Device aDevice, VkShaderStageFlags aShaderStages)
    {
        return Build(aDevice, aShaderStages, null, VkDescriptorSetLayoutCreateFlags.None);
    }
    
    public VkDescriptorSetLayout Build(Device aDevice, VkShaderStageFlags aShaderStages, void* pNext, VkDescriptorSetLayoutCreateFlags aFlags)
    {
        VkDescriptorSetLayoutCreateInfo createInfo;
        for(int i = 0; i < MyBindings.Count; i++)
        {
            var binding = MyBindings[i];
            binding.stageFlags |= aShaderStages;
            MyBindings[i] = binding;
        }

        var bindingsArray = stackalloc VkDescriptorSetLayoutBinding[MyBindings.Count];

        for (int i = 0; i < MyBindings.Count; i++)
            bindingsArray[i] = MyBindings[i];
        
        createInfo.pNext = pNext;
        createInfo.bindingCount = (uint)MyBindings.Count;
        createInfo.pBindings = bindingsArray;
        createInfo.flags = aFlags;

        vkCreateDescriptorSetLayout(aDevice.MyVkDevice, &createInfo, null, out VkDescriptorSetLayout layout).CheckResult();
        
        return layout;
    }
}