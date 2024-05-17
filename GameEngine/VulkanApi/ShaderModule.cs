namespace Graphics;

public unsafe class ShaderModule : IGpuDestroyable
{
    public VkShaderModule MyModule;
    
    private ShaderModule(byte[] aBytes)
    {
        VkShaderModuleCreateInfo createInfo = new VkShaderModuleCreateInfo();
        createInfo.codeSize = (UIntPtr)aBytes.Length;

        fixed (byte* sourcePointer = aBytes)
        {
            createInfo.pCode = (uint*)sourcePointer;
        }

        vkCreateShaderModule(Device.MyVkDevice, &createInfo, null, out MyModule).CheckResult();
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
        vkDestroyShaderModule(Device.MyVkDevice, MyModule);
    }
    
    public VkPipelineShaderStageCreateInfo GetCreateInfo(VkShaderStageFlags aStage)
    {
        VkPipelineShaderStageCreateInfo stageInfo = new();
        stageInfo.stage = aStage;
        stageInfo.module = MyModule;
        stageInfo.pName = "main".ToSPointer();

        return stageInfo;
    }
}