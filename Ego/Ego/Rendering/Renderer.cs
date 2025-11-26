global using static VulkanApi.LogicalDevice;
global using static VulkanApi.Api;
global using static VulkanApi.Surface;
global using static VulkanApi.MemoryAllocator;
global using static VulkanApi.Gpu;
using System.Drawing;
using Ego;
using Ego.Rendering;
using MessagePack;
using VulkanApi;
using SharpGLTF.Schema2;
using Silk.NET.Windowing;
using Vortice.ShaderCompiler;
using Vortice.Vulkan;
using Image = VulkanApi.Image;

namespace Rendering;

public partial class Renderer : IGpuImmediateSubmit
{
    public Swapchain Swapchain = null!;
    public RenderQueue RenderQueue = null!;
    public GpuDataTransferer DataTransferer = null!;
    public DescriptorAllocatorGrowable GlobalDescriptorAllocator = new();
    VkSampleCountFlags MsaaSamples = VkSampleCountFlags.Count8;
    private VkSampleCountFlags PrevMsaaSamples = VkSampleCountFlags.Count8;

    private MainRenderSchedule RenderSchedule = null!;
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
    public VkDescriptorSet TextureRegistryDescriptorSet;

    public SceneData SceneData = new SceneData();
    public VkDescriptorSetLayout SceneDataLayout;
    public VkDescriptorSetLayout BindlessTextureLayout;
    
    private ulong FrameCount = 0;
    private bool WantsResize = false;
    
    public Action<VkCommandBuffer> ERenderImgui = delegate {};
    public Action EPostRender = delegate {};

    public List<RenderRequest> RenderRequests = new();
    private List<IRenderCommand> CustomRenderCommands = new(); 

    public Window MainWindow;

    [Inspect] public Color ZenithColor = Color.FromArgb( 	101, 136, 168);
    [Inspect] public Color BelowHorizonColor = Color.FromArgb(101, 97, 93);
    [Inspect] public Color OverHorizonColor = Color.FromArgb(255, 255, 245);
    [Inspect] public float HorizonLength = 0.01f;
    [Inspect] public float ZenithLength = 0.05f;
    
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

        RenderRequests = aRenderData.RenderRequests; 
        SceneData.View = aRenderData.CameraView;
        SceneData.Projection = MatrixExtensions.CreatePerspectiveFieldOfView(90f * (float)(Math.PI/180f), (float)Swapchain.Extents.width / (float)Swapchain.Extents.height, 10000f, 0.1f);
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
        SceneData.Resolution = new Vector2(Swapchain.Extents.width, Swapchain.Extents.height);
        
        RenderResult result = RenderInternal();
        
        if (result == RenderResult.ResizeNeeded)
            RecreateFramebuffer();
        else if (PrevMsaaSamples != MsaaSamples)
        {
            PrevMsaaSamples = MsaaSamples;
            RecreateFramebuffer();
        }
            
    }
    
    public void SetPresentMode(VkPresentModeKHR aPresentMode)
    {
        PreferredPresentMode = aPresentMode;
        RecreateSwapchain();
    }

    protected override void Update()
    {
        RenderSchedule.SkyMaterial.Set("OverHorizonColor", OverHorizonColor.ToVec4());
        RenderSchedule.SkyMaterial.Set("BelowHorizonColor", BelowHorizonColor.ToVec4());
        RenderSchedule.SkyMaterial.Set("ZenithColor", ZenithColor.ToVec4());
        RenderSchedule.SkyMaterial.Set("HorizonLength", HorizonLength);
        RenderSchedule.SkyMaterial.Set("ZenithLength", ZenithLength);
        base.Update();
    }
}