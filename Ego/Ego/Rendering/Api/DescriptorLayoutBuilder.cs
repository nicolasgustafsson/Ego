namespace VulkanApi;

public unsafe class DescriptorLayoutBuilder
{
    public List<VkDescriptorSetLayoutBinding> Bindings = new();
    
    public void AddBinding(uint aBinding, VkDescriptorType aType)
    {
        Bindings.Add(new() { binding = aBinding, descriptorType = aType, descriptorCount = 1 });
    }
    
    public void Clear()
    {
        Bindings.Clear();
    }

    public VkDescriptorSetLayout Build(VkShaderStageFlags aShaderStages)
    {
        return Build(aShaderStages, null, VkDescriptorSetLayoutCreateFlags.None);
    }
    
    public VkDescriptorSetLayout Build(VkShaderStageFlags aShaderStages, void* pNext, VkDescriptorSetLayoutCreateFlags aFlags)
    {
        VkDescriptorSetLayoutCreateInfo createInfo = new();
        for(int i = 0; i < Bindings.Count; i++)
        {
            var binding = Bindings[i];
            binding.stageFlags |= aShaderStages;
            Bindings[i] = binding;
        }

        var bindingsArray = stackalloc VkDescriptorSetLayoutBinding[Bindings.Count];

        for (int i = 0; i < Bindings.Count; i++)
            bindingsArray[i] = Bindings[i];
        
        createInfo.pNext = pNext;
        createInfo.bindingCount = (uint)Bindings.Count;
        createInfo.pBindings = bindingsArray;
        createInfo.flags = aFlags;

        VkApiDevice.vkCreateDescriptorSetLayout(Device.VkDevice, &createInfo, null, out VkDescriptorSetLayout layout).CheckResult();
        
        return layout;
    }
}