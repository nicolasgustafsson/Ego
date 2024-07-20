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

public partial class Renderer : Node, IGpuImmediateSubmit
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

    private Mesh[] Meshes = null!;
    private Mesh Monke => Meshes[2];

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

    private List<MeshRenderData> RenderData = new();

    public Renderer(Window aWindow)
    {
        Init(aWindow);
    }
    
    public void ImmediateSubmit(Action<CommandBufferHandle> aAction)
    {
        ImmediateFence.Reset();

        using (var handle = ImmediateCommandBuffer.BeginRecording())
            aAction(handle);
        
        RenderQueue.Submit(ImmediateCommandBuffer, ImmediateFence);
        ImmediateFence.Wait();
    }
    
    public void Render()
    {
        RenderResult result = RenderInternal();
        
        if (result == RenderResult.ResizeNeeded)
            Resize();
    }


    public void SetCameraView(Matrix4x4 aCameraView)
    {
        SceneData.View = aCameraView;
    }

    public void SetRenderData(List<MeshRenderData> aRenderData)
    {
        RenderData = aRenderData;
    }
}