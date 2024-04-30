using Vortice.ShaderCompiler;

namespace Graphics;

public class ComputePipeline : Pipeline
{
    public unsafe class ComputePipelineBuilder()
    {
        private List<VkDescriptorSetLayout> myLayouts = new();
        private List<VkPushConstantRange> myPushConstants = new();
        private ShaderModule myComputeShader;

        private uint myCurrentOffset = 0;

        public ComputePipelineBuilder AddLayout(VkDescriptorSetLayout aLayout)
        {
            myLayouts.Add(aLayout);
            return this;
        }
        
        public ComputePipelineBuilder AddPushConstant<T>() where T : unmanaged
        {
            VkPushConstantRange range = new();
            range.offset = myCurrentOffset;
            range.size = (uint)sizeof(T);
            range.stageFlags = VkShaderStageFlags.Compute;

            myCurrentOffset += (uint)sizeof(T);

            return AddPushConstant(range);
        }
        
        public ComputePipelineBuilder AddPushConstant(VkPushConstantRange aPushConstant)
        {
            myPushConstants.Add(aPushConstant);
            return this;
        }
        
        public ComputePipelineBuilder SetComputeShader(string aShaderModulePath)
        {
            ShaderModule? shader = ShaderModule.Load(aShaderModulePath);
            
            if (shader == null)
            {
                Console.WriteLine("Could not create shader!");
                throw new Exception();
            }

            return SetComputeShader(shader);
        }
        
        public ComputePipelineBuilder SetComputeShader(ShaderModule aShaderModule)
        {
            myComputeShader = aShaderModule;
            return this;
        }
        
        public ComputePipeline Build()
        {
            ComputePipeline computePipeline = new();
            
            VkPipelineLayoutCreateInfo computeLayout = new();
            
            computeLayout.pSetLayouts = myLayouts.AsSpan().GetPointerUnsafe();

            computeLayout.setLayoutCount = (uint)myLayouts.Count;
            
            computeLayout.pPushConstantRanges = myPushConstants.AsSpan().GetPointerUnsafe();
            computeLayout.pushConstantRangeCount = (uint)myPushConstants.Count();

            vkCreatePipelineLayout(Device.MyVkDevice, &computeLayout, null, out computePipeline.MyVkLayout).CheckResult();

            VkComputePipelineCreateInfo computePipelineCreateInfo = new();
            computePipelineCreateInfo.layout = computePipeline.MyVkLayout;
            computePipelineCreateInfo.stage = myComputeShader.GetCreateInfo(VkShaderStageFlags.Compute);

            VkPipeline pipeline;
            vkCreateComputePipelines(Device.MyVkDevice, VkPipelineCache.Null, computePipelineCreateInfo, &pipeline).CheckResult();

            computePipeline.MyVkPipeline = pipeline;
            computePipeline.MyBindPoint = VkPipelineBindPoint.Compute;

            myComputeShader.Destroy();

            return computePipeline;
        }
    }
    
    public static ComputePipelineBuilder StartBuild()
    {
        return new ComputePipelineBuilder();
    }
    
    internal ComputePipeline()
    {
    }
}