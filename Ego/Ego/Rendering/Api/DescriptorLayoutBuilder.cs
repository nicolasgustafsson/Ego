namespace VulkanApi;

public unsafe class DescriptorLayoutBuilder
{
    public List<VkDescriptorSetLayoutBinding> Bindings = new();
    
    public void AddBinding(uint aBinding, VkDescriptorType aType, int aCount = 1)
    {
        Bindings.Add(new() { binding = aBinding, descriptorType = aType, descriptorCount = (uint)aCount });
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
        
        createInfo.flags = aFlags | VkDescriptorSetLayoutCreateFlags.UpdateAfterBindPool;

        VkApiDevice.vkCreateDescriptorSetLayout(Device.VkDevice, &createInfo, null, out VkDescriptorSetLayout layout).CheckResult();
        
        return layout;
    }
    
    public VkDescriptorSetLayout BuildBindless(VkShaderStageFlags aShaderStages, VkDescriptorSetLayoutCreateFlags aFlags)
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
        
        createInfo.bindingCount = (uint)Bindings.Count;
        createInfo.pBindings = bindingsArray;
        
        createInfo.flags = aFlags | VkDescriptorSetLayoutCreateFlags.UpdateAfterBindPool;
        
        VkDescriptorBindingFlags flags =
            VK_DESCRIPTOR_BINDING_VARIABLE_DESCRIPTOR_COUNT_BIT |
            VK_DESCRIPTOR_BINDING_PARTIALLY_BOUND_BIT |
            VK_DESCRIPTOR_BINDING_UPDATE_AFTER_BIND_BIT |
            VK_DESCRIPTOR_BINDING_UPDATE_UNUSED_WHILE_PENDING_BIT;

        // In unextended Vulkan, there is no way to pass down flags to a binding, so we're going to do so via a pNext.
        // Each pBinding has a corresponding pBindingFlags.
        VkDescriptorSetLayoutBindingFlagsCreateInfo binding_flags = new();
        binding_flags.sType          = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_BINDING_FLAGS_CREATE_INFO;
        binding_flags.bindingCount   = 0;
        binding_flags.pBindingFlags  = &flags; 
        
        createInfo.pNext = &binding_flags;

        VkApiDevice.vkCreateDescriptorSetLayout(Device.VkDevice, &createInfo, null, out VkDescriptorSetLayout layout).CheckResult();
        
        return layout;
    }
}