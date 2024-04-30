using Graphics;
using Utilities.Interop;
using Vortice.ShaderCompiler;
using Vortice.Vulkan;

namespace Rendering;

public unsafe class PipelineBuilder
{
    private List<VkPipelineShaderStageCreateInfo> myShaderStages = new();
    private VkPipelineInputAssemblyStateCreateInfo myInputAssembly;
    private VkPipelineRasterizationStateCreateInfo myRasterizer;
    private VkPipelineColorBlendAttachmentState myColorBlendAttachment;
    private VkPipelineMultisampleStateCreateInfo myMultisample;
    private VkPipelineLayout myPipelineLayout;
    private VkPipelineDepthStencilStateCreateInfo myDepthStencilState;
    private VkPipelineRenderingCreateInfo myRenderingInfo;
    private VkFormat myColorAttachmentFormat;
    
    public PipelineBuilder()
    {
        Clear();
    }
    
    public void Clear()
    {
        myInputAssembly = new();
        myRasterizer = new();
        myColorBlendAttachment = new();
        myMultisample = new();
        myPipelineLayout = new();
        myDepthStencilState = new();
        myRenderingInfo = new();
        myColorAttachmentFormat = new();
        myShaderStages.Clear();
    }
    
    public void SetLayout(VkPipelineLayout aLayout)
    {
        myPipelineLayout = aLayout;
    }
    
    public void SetShaders(ShaderModule aVertexShader, ShaderModule aFragmentShader)
    {
        myShaderStages.Clear();
        myShaderStages.Add(aVertexShader.GetCreateInfo(VkShaderStageFlags.Vertex));
        myShaderStages.Add(aFragmentShader.GetCreateInfo(VkShaderStageFlags.Fragment));
    }
    
    public void DisableMultisampling()
    {
        myMultisample.sampleShadingEnable = false;
        myMultisample.rasterizationSamples = VkSampleCountFlags.Count1;
        myMultisample.minSampleShading = 1f;
        myMultisample.pSampleMask = null;
        myMultisample.alphaToCoverageEnable = false;
        myMultisample.alphaToOneEnable = false;
    }
    
    public void DisableBlending()
    {
        myColorBlendAttachment.colorWriteMask = VkColorComponentFlags.All;
        myColorBlendAttachment.blendEnable = false;
    }
    
    public void SetColorAttachmentFormat(VkFormat aFormat)
    {
        myColorAttachmentFormat = aFormat;
        myRenderingInfo.colorAttachmentCount = 1;
        
        fixed(VkFormat* formatPointer = &myColorAttachmentFormat)
            myRenderingInfo.pColorAttachmentFormats = formatPointer;
    }
    
    public void SetDepthFormat(VkFormat aFormat)
    {
        myRenderingInfo.depthAttachmentFormat = aFormat;
    }
    
    
    public void DisableDepthTest()
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
    }
    
    public void SetTopology(VkPrimitiveTopology aTopology)
    {
        myInputAssembly.topology = aTopology;
        myInputAssembly.primitiveRestartEnable = false;
    }
    
    public void SetPolygonMode(VkPolygonMode aPolygonMode)
    {
        myRasterizer.polygonMode = aPolygonMode;
        myRasterizer.lineWidth = 1f;
    }
    
    public void SetCullMode(VkCullModeFlags aCullMode, VkFrontFace aFrontFace)
    {
        myRasterizer.cullMode = aCullMode;
        myRasterizer.frontFace = aFrontFace;
    }

    public VkPipeline Build(Device aDevice)
    {
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

        VkGraphicsPipelineCreateInfo pipelineCreateInfo = new();
        
        fixed(VkPipelineRenderingCreateInfo* renderInfoP = &myRenderingInfo)
            pipelineCreateInfo.pNext = renderInfoP;

        pipelineCreateInfo.stageCount = (uint)myShaderStages.Count;
        pipelineCreateInfo.pStages = myShaderStages.AsSpan().GetPointerUnsafe();
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
            pipelineCreateInfo.pDepthStencilState = pointer;

        pipelineCreateInfo.layout = myPipelineLayout;
        
        VkDynamicState* dynamicState = stackalloc VkDynamicState[]{VkDynamicState.Viewport, VkDynamicState.Scissor};

        VkPipelineDynamicStateCreateInfo dynamicInfo = new();
        dynamicInfo.pDynamicStates = dynamicState;
        dynamicInfo.dynamicStateCount = 2;

        pipelineCreateInfo.pDynamicState = &dynamicInfo;

        Vulkan.vkCreateGraphicsPipeline(aDevice.MyVkDevice, pipelineCreateInfo, out VkPipeline pipeline).CheckResult("Could not create pipeline :(");
        
        return pipeline;
    }
}