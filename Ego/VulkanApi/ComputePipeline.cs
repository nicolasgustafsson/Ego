using Utilities;
using Vortice.ShaderCompiler;

namespace VulkanApi;

public class ComputePipeline : Pipeline
{
    public unsafe class ComputePipelineBuilder()
    {
        private List<VkDescriptorSetLayout> Layouts = new();
        private List<VkPushConstantRange> PushConstants = new();
        private ShaderModule ComputeShader;

        private uint CurrentOffset = 0;

        public ComputePipelineBuilder AddLayout(VkDescriptorSetLayout aLayout)
        {
            Layouts.Add(aLayout);
            return this;
        }
        
        public ComputePipelineBuilder AddPushConstant<T>() where T : unmanaged
        {
            VkPushConstantRange range = new();
            range.offset = CurrentOffset;
            range.size = (uint)sizeof(T);
            range.stageFlags = VkShaderStageFlags.Compute;

            CurrentOffset += (uint)sizeof(T);

            return AddPushConstant(range);
        }
        
        public ComputePipelineBuilder AddPushConstant(VkPushConstantRange aPushConstant)
        {
            PushConstants.Add(aPushConstant);
            return this;
        }
        
        public ComputePipelineBuilder SetComputeShader(string aShaderModulePath)
        {
            ShaderModule? shader = ShaderModule.Load(aShaderModulePath);
            
            if (shader == null)
            {
                Log.Info($"Could not create shader!");
                throw new Exception();
            }

            return SetComputeShader(shader);
        }
        
        public ComputePipelineBuilder SetComputeShader(ShaderModule aShaderModule)
        {
            ComputeShader = aShaderModule;
            return this;
        }
        
        public ComputePipeline Build()
        {
            ComputePipeline computePipeline = new();
            
            VkPipelineLayoutCreateInfo computeLayout = new();
            
            computeLayout.pSetLayouts = Layouts.AsSpan().GetPointerUnsafe();

            computeLayout.setLayoutCount = (uint)Layouts.Count;
            
            computeLayout.pPushConstantRanges = PushConstants.AsSpan().GetPointerUnsafe();
            computeLayout.pushConstantRangeCount = (uint)PushConstants.Count();

            vkCreatePipelineLayout(Device.VkDevice, &computeLayout, null, out computePipeline.VkLayout).CheckResult();

            VkComputePipelineCreateInfo computePipelineCreateInfo = new();
            computePipelineCreateInfo.layout = computePipeline.VkLayout;
            computePipelineCreateInfo.stage = ComputeShader.GetCreateInfo(VkShaderStageFlags.Compute);

            VkPipeline pipeline;
            vkCreateComputePipelines(Device.VkDevice, VkPipelineCache.Null, computePipelineCreateInfo, &pipeline).CheckResult();

            computePipeline.VkPipeline = pipeline;
            computePipeline.BindPoint = VkPipelineBindPoint.Compute;

            ComputeShader.Destroy();

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