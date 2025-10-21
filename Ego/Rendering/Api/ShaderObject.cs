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
        public VkShaderStageFlags VkStage;
        public VkShaderStageFlags VkNextStage;
        public VkShaderEXT VkShader = VkShaderEXT.Null;
        private VkShaderCreateInfoEXT VkShaderCreateInfo;
        public List<VkDescriptorSetLayout> Layouts;
        public VkPipelineLayout PipelineLayout;
        
        public Shader(VkShaderStageFlags aStage, byte[] aSpirvSource, List<VkDescriptorSetLayout> aLayouts, VkPushConstantRange aPushConstantRange)
        {
            VkStage = aStage;

            VkShaderStageFlags nextStage = VkShaderStageFlags.None;

            if (aStage is VkShaderStageFlags.Vertex or VkShaderStageFlags.MeshEXT)
                nextStage = VkShaderStageFlags.Fragment;
            
            VkNextStage = nextStage;

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
            VkShaderCreateInfo.pushConstantRangeCount = 1;
            VkShaderCreateInfo.pPushConstantRanges = &aPushConstantRange;

            Layouts = aLayouts;
            
            VkPipelineLayoutCreateInfo layoutCreateInfo = new();

            layoutCreateInfo.pushConstantRangeCount = 1;
            layoutCreateInfo.pPushConstantRanges = &aPushConstantRange;
            layoutCreateInfo.setLayoutCount = (uint)aLayouts.Count;
            layoutCreateInfo.pSetLayouts = aLayouts.AsSpan().GetPointerUnsafe();

            VkApiDevice.vkCreatePipelineLayout(Device.VkDevice, &layoutCreateInfo, null, out PipelineLayout);
            
            Build();
        }
        
        public void Build()
        {
            fixed(VkShaderEXT* shaderP = &VkShader)
            {
                VkApiDevice.vkCreateShadersEXT(LogicalDevice.Device.VkDevice, 1, VkShaderCreateInfo, null, shaderP).CheckResult();
            }
        }

        /*public Shader(VkShaderStageFlags aStage, VkShaderStageFlags aNextStage, )
        {

        }*/
    }
    
    public void Destroy()
    {
    }
}