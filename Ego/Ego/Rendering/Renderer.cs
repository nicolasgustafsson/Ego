global using static VulkanApi.LogicalDevice;
global using static VulkanApi.Api;
global using static VulkanApi.Surface;
global using static VulkanApi.MemoryAllocator;
global using static VulkanApi.Gpu;
using VulkanApi;
using SharpGLTF.Schema2;
using Silk.NET.Windowing;
using Vortice.ShaderCompiler;
using Vortice.Vulkan;
using Image = VulkanApi.Image;

namespace Rendering;

public partial class Renderer : IGpuImmediateSubmit
{
    private Swapchain Swapchain = null!;
    public RenderQueue RenderQueue = null!;
    public GpuDataTransferer DataTransferer = null!;
    public Image RenderImage = null!;
    private Image DepthImage = null!;
    public DescriptorAllocatorGrowable GlobalDescriptorAllocator = new();

    public ShaderObject.Shader GradientShader = null!;
        
    private ComputePipeline GradientPipeline = null!;
    private GraphicsPipeline TrianglePipeline = null!;

    private Fence ImmediateFence = null!;
    private CommandBuffer ImmediateCommandBuffer = null!;
    
    private List<ImageView> ImageViews = new();
    private VkDescriptorSet RenderImageDescriptorSet;
    public VkDescriptorSetLayout RenderImageDescriptorLayout;

    private VkDescriptorSetLayout SingleTextureLayout;

    private readonly List<FrameData> FrameData = new() { };
    private FrameData CurrentFrame => FrameData[(int)(FrameCount % FrameOverlap)];

    private DeletionQueue CleanupQueue = new();

    public Image BlackImage = null!;
    public Image GreyImage = null!;
    public Image WhiteImage = null!;
    public Image CheckerBoardImage = null!;

    public Sampler DefaultNearestSampler = null!;
    public Sampler DefaultLinearSampler = null!;

    public int TextureCount = 2048;
    private VkDescriptorSet TextureRegistryDescriptorSet;

    private SceneData SceneData = new SceneData();
    public VkDescriptorSetLayout SceneDataLayout;
    public VkDescriptorSetLayout BindlessTextureLayout;
    
    private ulong FrameCount = 0;
    private bool WantsResize = false;
    
    public Action<VkCommandBuffer> ERenderImgui = delegate {};
    public Action EPostRender = delegate {};

    private List<MeshRenderData> MeshRenderData = new();
    private List<IRenderCommand> CustomRenderCommands = new();

    public Window MainWindow;
    
    

    public Renderer(Window aWindow) : this(aWindow, new())
    {
        
    }
    
    public Renderer(Window aWindow, RendererInitSettings aSettings)
    {
        PreferredPresentMode = aSettings.PresentMode;
        
        MainWindow = aWindow;
    }

    public override void Start()
    {
        Init(MainWindow);
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
        CustomRenderCommands = aRenderData.CustomRenders;
        SceneData.View = aRenderData.CameraView;
        SceneData.Projection = MatrixExtensions.CreatePerspectiveFieldOfView(90f * (float)(Math.PI/180f), (float)RenderImage.Extent.width / (float)RenderImage.Extent.height, 10000f, 0.1f);
        SceneData.Projection[1, 1] *= -1f;
        SceneData.ViewProjection = SceneData.View * SceneData.Projection;
        Matrix4x4.Invert(SceneData.View, out SceneData.InverseView);
        Matrix4x4.Invert(SceneData.ViewProjection, out SceneData.InverseViewProj);

        SceneData.AmbientColor = aRenderData.AmbientColor;
        SceneData.SunlightColor = aRenderData.SunlightColor;
        SceneData.SunlightDirection = aRenderData.SunlightDirection;
        SceneData.Time = (float)Time.ElapsedTime.TotalSeconds;
        SceneData.CameraPosition = aRenderData.CameraPosition;
        SceneData.FieldOfView = 90f;
        
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