global using static Graphics.LogicalDevice;
global using static Graphics.Api;
global using static Graphics.Surface;
global using static Graphics.MemoryAllocator;
global using static Graphics.Gpu;

using Graphics;
using ImGuiNET;
using ImPlotNET;
using Vortice.Vulkan;

namespace Rendering;

public partial class Renderer : IGpuImmediateSubmit
{
    private Swapchain mySwapchain = null!;
    private DrawQueue myDrawQueue = null!;
    private Image myDrawImage = null!;
    private Image myDepthImage = null!;
    private DescriptorAllocatorGrowable myGlobalDescriptorAllocator = new();
    
    private ComputePipeline myGradientPipeline = null!;
    private GraphicsPipeline myTrianglePipeline = null!;

    public ImGuiContext MyImGuiContext = null!;

    private Fence myImmediateFence = null!;
    private CommandBuffer myImmediateCommandBuffer = null!;
    
    private List<ImageView> myImageViews = new();
    private VkDescriptorSet myDrawImageDescriptorSet;
    private VkDescriptorSetLayout myDrawImageDescriptorLayout;

    private VkDescriptorSetLayout mySingleTextureLayout;

    private readonly List<FrameData> myFrameData = new() { };
    private FrameData myCurrentFrame => myFrameData[(int)(myFrameNumber % FrameOverlap)];

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
    
    private ulong myFrameNumber = 0;
    private bool myWantsResize = false;

    public Renderer(Window aWindow)
    {
        Init(aWindow);
    }
    
    public void ImmediateSubmit(Action<CommandBuffer> aAction)
    {
        myImmediateFence.Reset();
        myImmediateCommandBuffer.Reset();

        myImmediateCommandBuffer.BeginRecording();
        aAction(myImmediateCommandBuffer);
        myImmediateCommandBuffer.EndRecording();
        myDrawQueue.Submit(myImmediateCommandBuffer, myImmediateFence);
        myImmediateFence.Wait();
    }
    
    public void Draw()
    {
        DrawInternal();
    }

    public void Debug()
    {
    }
}