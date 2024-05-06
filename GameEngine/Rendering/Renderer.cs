global using static Graphics.LogicalDevice;

using System.Runtime.InteropServices;
using Graphics;
using Vortice.Vulkan;

namespace Rendering;

public partial class Renderer
{
    private Api myApi = null!;
    private Surface mySurface = null!;
    private Gpu myGpu = null!;
    private Swapchain mySwapchain = null!;
    private DrawQueue myDrawQueue = null!;
    private Image myDrawImage = null!;
    
    private ComputePipeline myGradientPipeline = null!;
    private GraphicsPipeline myTrianglePipeline = null!;
    private MeshBuffers myTriangleMeshBuffers = null!;

    private Fence myImmediateFence = null!;
    private CommandBuffer myImmediateCommandBuffer = null!;
    
    private List<ImageView> myImageViews = new();
    private DescriptorAllocator myGlobalDescriptorAllocator = new();
    private VkDescriptorSet myDrawImageDescriptorSet;
    private VkDescriptorSetLayout myDrawImageDescriptorLayout;

    private MemoryAllocator myMemoryAllocator = null!;
    
    private List<FrameData> myFrameData = new() { };
    private FrameData myCurrentFrame => myFrameData[(int)(myFrameNumber % FrameOverlap)];

    private DeletionQueue myCleanupQueue = new();
    
    private ulong myFrameNumber = 0;

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
}