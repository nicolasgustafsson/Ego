namespace VulkanApi;

public unsafe class ShaderModule : IGpuDestroyable
{
    public VkShaderModule Module;
    
    private ShaderModule(byte[] aBytes)
    {
        VkShaderModuleCreateInfo createInfo = new VkShaderModuleCreateInfo();
        createInfo.codeSize = (UIntPtr)aBytes.Length;

        fixed (byte* sourcePointer = aBytes)
        {
            createInfo.pCode = (uint*)sourcePointer;
        }

        VkApiDevice.vkCreateShaderModule(Device.VkDevice, &createInfo, null, out Module).CheckResult();
    }
    
    public static ShaderModule? Load(string aFilePath)
    {
        if (!File.Exists(aFilePath))
            return null;
        
        var bytes = File.ReadAllBytes(aFilePath);
        
        return new(bytes);
    }

    public void Destroy()
    {
        VkApiDevice.vkDestroyShaderModule(Device.VkDevice, Module);
    }
    
    public VkPipelineShaderStageCreateInfo GetCreateInfo(VkShaderStageFlags aStage)
    {
        VkPipelineShaderStageCreateInfo stageInfo = new();
        stageInfo.stage = aStage;
        stageInfo.module = Module;
        stageInfo.pName = "main".ToPointer();

        return stageInfo;
    }
}