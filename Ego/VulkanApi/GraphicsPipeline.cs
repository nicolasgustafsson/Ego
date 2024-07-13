using Vortice.ShaderCompiler;

namespace VulkanApi;

public class GraphicsPipeline : Pipeline
{
    public unsafe class GraphicsPipelineBuilder()
    {
        private List<VkDescriptorSetLayout> myLayouts = new();
        private List<VkPushConstantRange> myPushConstants = new();
        private ShaderModule myVertexShader;
        private ShaderModule myFragmentShader;

        private uint myCurrentPushConstantOffset = 0;
        
        private VkPipelineInputAssemblyStateCreateInfo myInputAssembly = new();
        private VkPipelineRasterizationStateCreateInfo myRasterizer = new();
        private VkPipelineColorBlendAttachmentState myColorBlendAttachment = new();
        private VkPipelineMultisampleStateCreateInfo myMultisample = new();
        private VkPipelineDepthStencilStateCreateInfo myDepthStencilState = new();
        private VkPipelineRenderingCreateInfo myRenderingInfo = new();
        private VkFormat myColorAttachmentFormat = new();
        private List<VkVertexInputBindingDescription>? myVertexBindings = null;
        private List<VkVertexInputAttributeDescription>? myVertexAttributes = null;

        public GraphicsPipelineBuilder AddLayout(VkDescriptorSetLayout aLayout)
        {
            myLayouts.Add(aLayout);
            return this;
        }
        
        public GraphicsPipelineBuilder AddPushConstant<T>(VkShaderStageFlags aShaderStages) where T : unmanaged
        {
            VkPushConstantRange range = new();
            range.offset = myCurrentPushConstantOffset;
            range.size = (uint)sizeof(T);
            range.stageFlags = aShaderStages;

            myCurrentPushConstantOffset += (uint)sizeof(T);

            return AddPushConstant(range);
        }
        
        public GraphicsPipelineBuilder AddPushConstant(VkPushConstantRange aPushConstant)
        {
            myPushConstants.Add(aPushConstant);
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
            myVertexShader = aShaderModule;
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
            myFragmentShader = aShaderModule;
            return this;
        }
        
        public GraphicsPipelineBuilder DisableMultisampling()
        {
            myMultisample.sampleShadingEnable = false;
            myMultisample.rasterizationSamples = VkSampleCountFlags.Count1;
            myMultisample.minSampleShading = 1f;
            myMultisample.pSampleMask = null;
            myMultisample.alphaToCoverageEnable = false;
            myMultisample.alphaToOneEnable = false;
            return this;
        }
        
        public GraphicsPipelineBuilder SetBlendMode(BlendMode aBlendMode)
        {
            myColorBlendAttachment = aBlendMode.ToVkBlendAttachment();
            return this;
        }
        
        public GraphicsPipelineBuilder SetVertexBinding(uint aStride, uint aBinding)
        {
            myVertexBindings ??= new();
            myVertexBindings.Add(new(stride: aStride, VkVertexInputRate.Vertex, aBinding));

            return this;
        }
        
        public GraphicsPipelineBuilder SetVertexAttribute(uint aLocation, uint aBinding, VkFormat aFormat)
        {
            myVertexAttributes ??= new();
            myVertexAttributes.Add(new VkVertexInputAttributeDescription(aLocation, aFormat, aBinding));

            return this;
        }
        
        public GraphicsPipelineBuilder SetColorAttachmentFormat(VkFormat aFormat)
        {
            myColorAttachmentFormat = aFormat;
            myRenderingInfo.colorAttachmentCount = 1;
            
            fixed(VkFormat* formatPointer = &myColorAttachmentFormat)
                myRenderingInfo.pColorAttachmentFormats = formatPointer;
            return this;
        }
        
        public GraphicsPipelineBuilder SetDepthFormat(VkFormat aFormat)
        {
            myRenderingInfo.depthAttachmentFormat = aFormat;
            return this;
        }
        
        
        public GraphicsPipelineBuilder DisableDepthTest()
        {
            myDepthStencilState.depthTestEnable = false;
            myDepthStencilState.depthWriteEnable = false;
            myDepthStencilState.depthCompareOp = VkCompareOp.Never;
            myDepthStencilState.depthBoundsTestEnable = false;
            myDepthStencilState.stencilTestEnable = false;
            myDepthStencilState.front = new();
            myDepthStencilState.back = new();
            myDepthStencilState.minDepthBounds = 0f;
            myDepthStencilState.maxDepthBounds = 1f;
            return this;
        }
        
        public GraphicsPipelineBuilder EnableDepthTest()
        {
            myDepthStencilState.depthTestEnable = true;
            myDepthStencilState.depthWriteEnable = true;
            myDepthStencilState.depthCompareOp = VkCompareOp.Greater;
            myDepthStencilState.depthBoundsTestEnable = false;
            myDepthStencilState.stencilTestEnable = false;
            myDepthStencilState.front = new();
            myDepthStencilState.back = new();
            myDepthStencilState.minDepthBounds = 0f;
            myDepthStencilState.maxDepthBounds = 1f;
            return this;
        }
        
        public GraphicsPipelineBuilder SetTopology(VkPrimitiveTopology aTopology)
        {
            myInputAssembly.topology = aTopology;
            myInputAssembly.primitiveRestartEnable = false;
            return this;
        }
        
        public GraphicsPipelineBuilder SetPolygonMode(VkPolygonMode aPolygonMode)
        {
            myRasterizer.polygonMode = aPolygonMode;
            myRasterizer.lineWidth = 1f;
            return this;
        }
        
        public GraphicsPipelineBuilder SetCullMode(VkCullModeFlags aCullMode, VkFrontFace aFrontFace)
        {
            myRasterizer.cullMode = aCullMode;
            myRasterizer.frontFace = aFrontFace;

            return this;
        }

        public GraphicsPipeline Build()
        {
            VkPipelineLayoutCreateInfo layoutCreateInfo = new();
            layoutCreateInfo.pSetLayouts = myLayouts.AsSpan().GetPointerUnsafe();

            layoutCreateInfo.setLayoutCount = (uint)myLayouts.Count;
            
            layoutCreateInfo.pPushConstantRanges = myPushConstants.AsSpan().GetPointerUnsafe();
            layoutCreateInfo.pushConstantRangeCount = (uint)myPushConstants.Count;

            VkPipelineLayout layout = new();

            vkCreatePipelineLayout(Device.MyVkDevice, &layoutCreateInfo, null, out layout).CheckResult();
            
            GraphicsPipeline graphicsPipeline = new();
            VkPipelineViewportStateCreateInfo viewportStateCreateInfo = new();
            viewportStateCreateInfo.viewportCount = 1;
            viewportStateCreateInfo.scissorCount = 1;

            VkPipelineColorBlendStateCreateInfo blendStateCreateInfo = new();
            blendStateCreateInfo.logicOpEnable = false;
            blendStateCreateInfo.logicOp = VkLogicOp.Copy;
            blendStateCreateInfo.attachmentCount = 1;
            
            fixed(VkPipelineColorBlendAttachmentState* colorBlendAttachmentP = &myColorBlendAttachment)
                blendStateCreateInfo.pAttachments = colorBlendAttachmentP;

            VkPipelineVertexInputStateCreateInfo vertexInputInfo = new();
            
            if (myVertexBindings != null)
            {
                vertexInputInfo.pVertexBindingDescriptions = myVertexBindings.AsSpan().GetPointerUnsafe();
                vertexInputInfo.vertexBindingDescriptionCount = (uint)myVertexBindings.Count;
            }
            else if (myVertexAttributes != null)
            {
                vertexInputInfo.pVertexAttributeDescriptions = myVertexAttributes.AsSpan().GetPointerUnsafe();
                vertexInputInfo.vertexAttributeDescriptionCount = (uint)myVertexAttributes.Count;
            }
            
            VkGraphicsPipelineCreateInfo pipelineCreateInfo = new();
            
            fixed(VkPipelineRenderingCreateInfo* renderInfoP = &myRenderingInfo)
                pipelineCreateInfo.pNext = renderInfoP;

            List<VkPipelineShaderStageCreateInfo> shaderModules = new() {myVertexShader.GetCreateInfo(VkShaderStageFlags.Vertex), myFragmentShader.GetCreateInfo(VkShaderStageFlags.Fragment)};

            pipelineCreateInfo.stageCount = (uint)shaderModules.Count;
            pipelineCreateInfo.pStages = shaderModules.AsSpan().GetPointerUnsafe();
            pipelineCreateInfo.pVertexInputState = &vertexInputInfo;
            
            fixed(VkPipelineInputAssemblyStateCreateInfo* pointer = &myInputAssembly)
                pipelineCreateInfo.pInputAssemblyState = pointer;

            pipelineCreateInfo.pViewportState = &viewportStateCreateInfo;
            
            fixed(VkPipelineRasterizationStateCreateInfo* pointer = &myRasterizer)
                pipelineCreateInfo.pRasterizationState = pointer;
            
            fixed(VkPipelineMultisampleStateCreateInfo* pointer = &myMultisample)
                pipelineCreateInfo.pMultisampleState = pointer;
            
            pipelineCreateInfo.pColorBlendState = &blendStateCreateInfo;
            
            fixed(VkPipelineDepthStencilStateCreateInfo* pointer = &myDepthStencilState)
            {
                pipelineCreateInfo.pDepthStencilState = pointer;
                
            }

            pipelineCreateInfo.layout = layout;
            
            VkDynamicState* dynamicState = stackalloc VkDynamicState[]{VkDynamicState.Viewport, VkDynamicState.Scissor};

            VkPipelineDynamicStateCreateInfo dynamicInfo = new();
            dynamicInfo.pDynamicStates = dynamicState;
            dynamicInfo.dynamicStateCount = 2;

            pipelineCreateInfo.pDynamicState = &dynamicInfo;

            vkCreateGraphicsPipeline(Device.MyVkDevice, pipelineCreateInfo, out VkPipeline pipeline).CheckResult("Could not create pipeline :(");

            graphicsPipeline.MyVkPipeline = pipeline;
            graphicsPipeline.MyVkLayout = layout;
            graphicsPipeline.MyBindPoint = VkPipelineBindPoint.Graphics;

            vkDestroyShaderModule(Device.MyVkDevice, myFragmentShader.MyModule); 
            vkDestroyShaderModule(Device.MyVkDevice, myVertexShader.MyModule); 
            
            return graphicsPipeline;
        }

    }
    
    public static GraphicsPipelineBuilder StartBuild()
    {
        return new GraphicsPipelineBuilder();
    }
}