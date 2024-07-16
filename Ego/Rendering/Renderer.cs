global using static VulkanApi.LogicalDevice;
global using static VulkanApi.Api;
global using static VulkanApi.Surface;
global using static VulkanApi.MemoryAllocator;
global using static VulkanApi.Gpu;

using VulkanApi;
using ImGuiNET;
using Vortice.ShaderCompiler;
using Vortice.Vulkan;

namespace Rendering;

public partial class Renderer : IGpuImmediateSubmit
{
    private Swapchain mySwapchain = null!;
    private RenderQueue myRenderQueue = null!;
    private Image myRenderImage = null!;
    private Image myDepthImage = null!;
    private DescriptorAllocatorGrowable myGlobalDescriptorAllocator = new();
    
    private ComputePipeline myGradientPipeline = null!;
    private GraphicsPipeline myTrianglePipeline = null!;

    private Fence myImmediateFence = null!;
    private CommandBuffer myImmediateCommandBuffer = null!;
    
    private List<ImageView> myImageViews = new();
    private VkDescriptorSet myRenderImageDescriptorSet;
    private VkDescriptorSetLayout myRenderImageDescriptorLayout;

    private VkDescriptorSetLayout mySingleTextureLayout;

    private readonly List<FrameData> myFrameData = new() { };
    private FrameData myCurrentFrame => myFrameData[(int)(myFrameCount % FrameOverlap)];

    private DeletionQueue myCleanupQueue = new();

    private Mesh[] myMeshes = null!;
    private Mesh myMonke => myMeshes[2];

    private Image myBlackImage = null!;
    private Image myGreyImage = null!;
    private Image myWhiteImage = null!;
    public Image myCheckerBoardImage = null!;

    private Sampler myDefaultNearestSampler = null!;
    private Sampler myDefaultLinearSampler = null!;

    private SceneData mySceneData = new SceneData();
    private VkDescriptorSetLayout mySceneDataLayout;
    
    private ulong myFrameCount = 0;
    private bool myWantsResize = false;
    
    public Action<CommandBufferHandle> ERenderImgui = delegate {};
    public Action EPostRender = delegate {};

    public Renderer(Window aWindow)
    {
        Init(aWindow);
    }
    
    public void ImmediateSubmit(Action<CommandBufferHandle> aAction)
    {
        myImmediateFence.Reset();

        using (var handle = myImmediateCommandBuffer.BeginRecording())
            aAction(handle);
        
        myRenderQueue.Submit(myImmediateCommandBuffer, myImmediateFence);
        myImmediateFence.Wait();
    }
    
    public void Render()
    {
        RenderResult result = RenderInternal();
        
        if (result == RenderResult.ResizeNeeded)
            Resize();
    }

    public void Debug()
    {
    }

    public void SetCameraView(Matrix4x4 aCameraView)
    {
        mySceneData.View = aCameraView;
    }
}