using Utilities;
using Vortice.ShaderCompiler;

namespace VulkanApi;

public class GraphicsPipeline : Pipeline
{
    public unsafe class GraphicsPipelineBuilder()
    {
        private List<VkDescriptorSetLayout> Layouts = new();
        private List<VkPushConstantRange> PushConstants = new();
        private ShaderModule VertexShader;
        private ShaderModule FragmentShader;

        private uint CurrentPushConstantOffset = 0;
        
        private VkPipelineInputAssemblyStateCreateInfo InputAssembly = new();
        private VkPipelineRasterizationStateCreateInfo Rasterizer = new();
        private VkPipelineColorBlendAttachmentState ColorBlendAttachment = new();
        private VkPipelineMultisampleStateCreateInfo Multisample = new();
        private VkPipelineDepthStencilStateCreateInfo DepthStencilState = new();
        private VkPipelineRenderingCreateInfo RenderingInfo = new();
        private VkFormat ColorAttachmentFormat = new();
        private List<VkVertexInputBindingDescription>? VertexBindings = null;
        private List<VkVertexInputAttributeDescription>? VertexAttributes = null;

        public GraphicsPipelineBuilder AddLayout(VkDescriptorSetLayout aLayout)
        {
            Layouts.Add(aLayout);
            return this;
        }
        
        public GraphicsPipelineBuilder AddPushConstant<T>(VkShaderStageFlags aShaderStages) where T : unmanaged
        {
            VkPushConstantRange range = new();
            range.offset = CurrentPushConstantOffset;
            range.size = (uint)sizeof(T);
            range.stageFlags = aShaderStages;

            CurrentPushConstantOffset += (uint)sizeof(T);

            return AddPushConstant(range);
        }
        
        public GraphicsPipelineBuilder AddPushConstant(VkPushConstantRange aPushConstant)
        {
            PushConstants.Add(aPushConstant);
            return this;
        }
        
        public GraphicsPipelineBuilder SetVertexShader(string aShaderModulePath)
        {
            ShaderModule? shader = ShaderModule.Load(aShaderModulePath);
            
            if (shader == null)
            {
                Console.WriteLine("Could not create shader!");
                throw new Exception();
            }

            return SetVertexShader(shader);
        }
        
        public GraphicsPipelineBuilder SetVertexShader(ShaderModule aShaderModule)
        {
            VertexShader = aShaderModule;
            return this;
        }
        
        public GraphicsPipelineBuilder SetFragmentShader(string aShaderModulePath)
        {
            ShaderModule? shader = ShaderModule.Load(aShaderModulePath);
            
            if (shader == null)
            {
                Console.WriteLine("Could not create shader!");
                throw new Exception();
            }

            return SetFragmentShader(shader);
        }
        
        public GraphicsPipelineBuilder SetFragmentShader(ShaderModule aShaderModule)
        {
            FragmentShader = aShaderModule;
            return this;
        }
        
        public GraphicsPipelineBuilder DisableMultisampling()
        {
            Multisample.sampleShadingEnable = false;
            Multisample.rasterizationSamples = VkSampleCountFlags.Count1;
            Multisample.minSampleShading = 1f;
            Multisample.pSampleMask = null;
            Multisample.alphaToCoverageEnable = false;
            Multisample.alphaToOneEnable = false;
            return this;
        }
        
        public GraphicsPipelineBuilder SetBlendMode(BlendMode aBlendMode)
        {
            ColorBlendAttachment = aBlendMode.ToVkBlendAttachment();
            return this;
        }
        
        public GraphicsPipelineBuilder SetVertexBinding(uint aStride, uint aBinding)
        {
            VertexBindings ??= new();
            VertexBindings.Add(new(stride: aStride, VkVertexInputRate.Vertex, aBinding));

            return this;
        }
        
        public GraphicsPipelineBuilder SetVertexAttribute(uint aLocation, uint aBinding, VkFormat aFormat)
        {
            VertexAttributes ??= new();
            VertexAttributes.Add(new VkVertexInputAttributeDescription(aLocation, aFormat, aBinding));

            return this;
        }
        
        public GraphicsPipelineBuilder SetColorAttachmentFormat(VkFormat aFormat)
        {
            ColorAttachmentFormat = aFormat;
            RenderingInfo.colorAttachmentCount = 1;
            
            fixed(VkFormat* formatPointer = &ColorAttachmentFormat)
                RenderingInfo.pColorAttachmentFormats = formatPointer;
            return this;
        }
        
        public GraphicsPipelineBuilder SetDepthFormat(VkFormat aFormat)
        {
            RenderingInfo.depthAttachmentFormat = aFormat;
            return this;
        }
        
        
        public GraphicsPipelineBuilder DisableDepthTest()
        {
            DepthStencilState.depthTestEnable = false;
            DepthStencilState.depthWriteEnable = false;
            DepthStencilState.depthCompareOp = VkCompareOp.Never;
            DepthStencilState.depthBoundsTestEnable = false;
            DepthStencilState.stencilTestEnable = false;
            DepthStencilState.front = new();
            DepthStencilState.back = new();
            DepthStencilState.minDepthBounds = 0f;
            DepthStencilState.maxDepthBounds = 1f;
            return this;
        }
        
        public GraphicsPipelineBuilder EnableDepthTest()
        {
            DepthStencilState.depthTestEnable = true;
            DepthStencilState.depthWriteEnable = true;
            DepthStencilState.depthCompareOp = VkCompareOp.Greater;
            DepthStencilState.depthBoundsTestEnable = false;
            DepthStencilState.stencilTestEnable = false;
            DepthStencilState.front = new();
            DepthStencilState.back = new();
            DepthStencilState.minDepthBounds = 0f;
            DepthStencilState.maxDepthBounds = 1f;
            return this;
        }
        
        public GraphicsPipelineBuilder SetTopology(VkPrimitiveTopology aTopology)
        {
            InputAssembly.topology = aTopology;
            InputAssembly.primitiveRestartEnable = false;
            return this;
        }
        
        public GraphicsPipelineBuilder SetPolygonMode(VkPolygonMode aPolygonMode)
        {
            Rasterizer.polygonMode = aPolygonMode;
            Rasterizer.lineWidth = 1f;
            return this;
        }
        
        public GraphicsPipelineBuilder SetCullMode(VkCullModeFlags aCullMode, VkFrontFace aFrontFace)
        {
            Rasterizer.cullMode = aCullMode;
            Rasterizer.frontFace = aFrontFace;

            return this;
        }

        public GraphicsPipeline Build()
        {
            VkPipelineLayoutCreateInfo layoutCreateInfo = new();
            layoutCreateInfo.pSetLayouts = Layouts.AsSpan().GetPointerUnsafe();

            layoutCreateInfo.setLayoutCount = (uint)Layouts.Count;
            
            layoutCreateInfo.pPushConstantRanges = PushConstants.AsSpan().GetPointerUnsafe();
            layoutCreateInfo.pushConstantRangeCount = (uint)PushConstants.Count;

            VkPipelineLayout layout = new();

            vkCreatePipelineLayout(Device.VkDevice, &layoutCreateInfo, null, out layout).CheckResult();
            
            GraphicsPipeline graphicsPipeline = new();
            VkPipelineViewportStateCreateInfo viewportStateCreateInfo = new();
            viewportStateCreateInfo.viewportCount = 1;
            viewportStateCreateInfo.scissorCount = 1;

            VkPipelineColorBlendStateCreateInfo blendStateCreateInfo = new();
            blendStateCreateInfo.logicOpEnable = false;
            blendStateCreateInfo.logicOp = VkLogicOp.Copy;
            blendStateCreateInfo.attachmentCount = 1;
            
            fixed(VkPipelineColorBlendAttachmentState* colorBlendAttachmentP = &ColorBlendAttachment)
                blendStateCreateInfo.pAttachments = colorBlendAttachmentP;

            VkPipelineVertexInputStateCreateInfo vertexInputInfo = new();
            
            if (VertexBindings != null)
            {
                vertexInputInfo.pVertexBindingDescriptions = VertexBindings.AsSpan().GetPointerUnsafe();
                vertexInputInfo.vertexBindingDescriptionCount = (uint)VertexBindings.Count;
            }
            else if (VertexAttributes != null)
            {
                vertexInputInfo.pVertexAttributeDescriptions = VertexAttributes.AsSpan().GetPointerUnsafe();
                vertexInputInfo.vertexAttributeDescriptionCount = (uint)VertexAttributes.Count;
            }
            
            VkGraphicsPipelineCreateInfo pipelineCreateInfo = new();
            
            fixed(VkPipelineRenderingCreateInfo* renderInfoP = &RenderingInfo)
                pipelineCreateInfo.pNext = renderInfoP;

            List<VkPipelineShaderStageCreateInfo> shaderModules = new() {VertexShader.GetCreateInfo(VkShaderStageFlags.Vertex), FragmentShader.GetCreateInfo(VkShaderStageFlags.Fragment)};

            pipelineCreateInfo.stageCount = (uint)shaderModules.Count;
            pipelineCreateInfo.pStages = shaderModules.AsSpan().GetPointerUnsafe();
            pipelineCreateInfo.pVertexInputState = &vertexInputInfo;
            
            fixed(VkPipelineInputAssemblyStateCreateInfo* pointer = &InputAssembly)
                pipelineCreateInfo.pInputAssemblyState = pointer;

            pipelineCreateInfo.pViewportState = &viewportStateCreateInfo;
            
            fixed(VkPipelineRasterizationStateCreateInfo* pointer = &Rasterizer)
                pipelineCreateInfo.pRasterizationState = pointer;
            
            fixed(VkPipelineMultisampleStateCreateInfo* pointer = &Multisample)
                pipelineCreateInfo.pMultisampleState = pointer;
            
            pipelineCreateInfo.pColorBlendState = &blendStateCreateInfo;
            
            fixed(VkPipelineDepthStencilStateCreateInfo* pointer = &DepthStencilState)
            {
                pipelineCreateInfo.pDepthStencilState = pointer;
                
            }

            pipelineCreateInfo.layout = layout;
            
            VkDynamicState* dynamicState = stackalloc VkDynamicState[]{VkDynamicState.Viewport, VkDynamicState.Scissor};

            VkPipelineDynamicStateCreateInfo dynamicInfo = new();
            dynamicInfo.pDynamicStates = dynamicState;
            dynamicInfo.dynamicStateCount = 2;

            pipelineCreateInfo.pDynamicState = &dynamicInfo;

            vkCreateGraphicsPipeline(Device.VkDevice, pipelineCreateInfo, out VkPipeline pipeline).CheckResult("Could not create pipeline :(");

            graphicsPipeline.VkPipeline = pipeline;
            graphicsPipeline.VkLayout = layout;
            graphicsPipeline.BindPoint = VkPipelineBindPoint.Graphics;

            vkDestroyShaderModule(Device.VkDevice, FragmentShader.Module); 
            vkDestroyShaderModule(Device.VkDevice, VertexShader.Module); 
            
            return graphicsPipeline;
        }

    }
    
    public static GraphicsPipelineBuilder StartBuild()
    {
        return new GraphicsPipelineBuilder();
    }
}