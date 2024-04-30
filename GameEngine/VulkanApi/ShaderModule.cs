namespace Graphics;

public unsafe class ShaderModule
{
    public VkShaderModule MyModule;
    
    private ShaderModule(Device aDevice, byte[] aBytes)
    {
        VkShaderModuleCreateInfo createInfo = new VkShaderModuleCreateInfo();
        createInfo.codeSize = (UIntPtr)aBytes.Length;

        fixed (byte* sourcePointer = aBytes)
        {
            createInfo.pCode = (uint*)sourcePointer;
        }

        vkCreateShaderModule(aDevice.MyVkDevice, &createInfo, null, out MyModule).CheckResult();
    }
    
    public static ShaderModule? Load(string aFilePath, Device aDevice)
    {
        if (!File.Exists(aFilePath))
            return null;
        
        var bytes = File.ReadAllBytes(aFilePath);
        
        return new(aDevice, bytes);
    }

    public void Destroy(Device aDevice)
    {
        vkDestroyShaderModule(aDevice.MyVkDevice, MyModule);
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