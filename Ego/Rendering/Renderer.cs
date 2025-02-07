global using static VulkanApi.LogicalDevice;
global using static VulkanApi.Api;
global using static VulkanApi.Surface;
global using static VulkanApi.MemoryAllocator;
global using static VulkanApi.Gpu;
using VulkanApi;
using Vortice.Vulkan;
using Image = VulkanApi.Image;

namespace Rendering;

public partial class Renderer : IGpuImmediateSubmit
{
    private Swapchain Swapchain = null!;
    private RenderQueue RenderQueue = null!;
    private Image RenderImage = null!;
    private Image DepthImage = null!;
    private DescriptorAllocatorGrowable GlobalDescriptorAllocator = new();
    
    private ComputePipeline GradientPipeline = null!;
    private GraphicsPipeline TrianglePipeline = null!;

    private Fence ImmediateFence = null!;
    private CommandBuffer ImmediateCommandBuffer = null!;
    
    private List<ImageView> ImageViews = new();
    private VkDescriptorSet RenderImageDescriptorSet;
    private VkDescriptorSetLayout RenderImageDescriptorLayout;

    private VkDescriptorSetLayout SingleTextureLayout;

    private readonly List<FrameData> FrameData = new() { };
    private FrameData CurrentFrame => FrameData[(int)(FrameCount % FrameOverlap)];

    private DeletionQueue CleanupQueue = new();

    private Image BlackImage = null!;
    private Image GreyImage = null!;
    private Image WhiteImage = null!;
    public Image CheckerBoardImage = null!;

    private Sampler DefaultNearestSampler = null!;
    private Sampler DefaultLinearSampler = null!;

    private SceneData SceneData = new SceneData();
    private VkDescriptorSetLayout SceneDataLayout;
    
    private ulong FrameCount = 0;
    private bool WantsResize = false;
    
    public Action<CommandBufferHandle> ERenderImgui = delegate {};
    public Action EPostRender = delegate {};

    private List<MeshRenderData> MeshRenderData = new();

    public Window MainWindow;

    public Renderer(Window aWindow) : this(aWindow, new())
    {
        
    }
    
    public Renderer(Window aWindow, RendererInitSettings aSettings)
    {
        PreferredPresentMode = aSettings.PresentMode;
        
        MainWindow = aWindow;
        Init(aWindow);
    }
    
    public void WaitUntilIdle()
    {
        Device.WaitUntilIdle();
    }
    
    public void ImmediateSubmit(Action<CommandBufferHandle> aAction)
    {
        ImmediateFence.Reset();

        using (var handle = ImmediateCommandBuffer.BeginRecording())
            aAction(handle);
        
        RenderQueue.Submit(ImmediateCommandBuffer, ImmediateFence);
        ImmediateFence.Wait();
    }

    public void Render(RenderData aRenderData)
    {
        if (MainWindow.IsMinimized)
            return;

        MeshRenderData = aRenderData.MeshRenders;
        SceneData.View = aRenderData.CameraView;
        RenderResult result = RenderInternal();
        
        if (result == RenderResult.ResizeNeeded)
            Resize();
    }
    
    public void SetPresentMode(VkPresentModeKHR aPresentMode)
    {
        PreferredPresentMode = aPresentMode;
        RecreateSwapchain();
    }
}