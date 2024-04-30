using System.Runtime.InteropServices;

using Graphics;
using Vortice.Vulkan;

namespace Rendering;

public partial class Renderer
{
    private Api myApi = null!;
    private Surface mySurface = null!;
    private Gpu myGpu = null!;
    private Device myDevice = null!;
    private Swapchain mySwapchain = null!;
    private DrawQueue myDrawQueue = null!;
    private Image myDrawImage = null!;
    
    private List<ImageView> myImageViews = new();
    private DescriptorAllocator myGlobalDescriptorAllocator = new();
    private VkDescriptorSet myDrawImageDescriptors;
    private VkDescriptorSetLayout myDrawImageDescriptorLayout;
    private VkPipeline myGradientPipeline;
    private VkPipelineLayout myGradientPipelineLayout;

    private VkPipeline myTrianglePipeline;
    private VkPipelineLayout myTrianglePipelineLayout;
    
    private MemoryAllocator myMemoryAllocator = null!;
    
    private List<FrameData> myFrameData = new() { };
    private FrameData myCurrentFrame => myFrameData[(int)(myFrameNumber % FrameOverlap)];

    private DeletionQueue myCleanupQueue = new();
    
    private ulong myFrameNumber = 0;

    public Renderer(Window aWindow)
    {
        Init(aWindow);
    }
    
    public void Draw()
    {
        DrawInternal();
    }
}