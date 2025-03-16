using Utilities;
using Vortice.ShaderCompiler;

namespace VulkanApi;

public class ShaderObject : IGpuDestroyable
{
    public ShaderObject()
    {
        
    }
    
    public unsafe class Shader
    {
        private VkShaderStageFlags VkStage;
        private VkShaderStageFlags VkNextStage;
        private VkShaderEXT VkShader = VkShaderEXT.Null;
        private string Name = "Shader";
        private VkShaderCreateInfoEXT VkShaderCreateInfo;
        private byte[] SpirvSource;

        public Shader(VkShaderStageFlags aStage, VkShaderStageFlags aNextStage, string aName, byte[] aSpirvSource, List<VkDescriptorSetLayout> aLayouts)
        {
            VkStage = aStage;
            VkNextStage = aNextStage;
            Name = aName;
            SpirvSource = aSpirvSource;

            VkShaderCreateInfo = new();

            VkShaderCreateInfo.pNext = null;
            VkShaderCreateInfo.flags = 0;
            VkShaderCreateInfo.stage = VkStage;
            VkShaderCreateInfo.nextStage = VkNextStage;
            VkShaderCreateInfo.codeType = VkShaderCodeTypeEXT.SPIRV;
            VkShaderCreateInfo.codeSize = (nuint)(aSpirvSource.Length * sizeof(byte));
            fixed (byte* sourcePointer = aSpirvSource)
            {
                VkShaderCreateInfo.pCode = (uint*)sourcePointer;
            }

            VkShaderCreateInfo.pName = "main".ToPointer();
            VkShaderCreateInfo.setLayoutCount = (uint)aLayouts.Count;
            VkShaderCreateInfo.pSetLayouts = aLayouts.AsSpan().GetPointerUnsafe();
            VkShaderCreateInfo.pSpecializationInfo = null;
        }

        /*public Shader(VkShaderStageFlags aStage, VkShaderStageFlags aNextStage, )
        {

        }*/
    }
    
    public void Destroy()
    {
    }
}