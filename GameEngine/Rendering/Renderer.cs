using System.Runtime.InteropServices;
using Graphics;
using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;

namespace Rendering;

public unsafe partial class Renderer
{
    private Api myApi = null!;
    private Surface mySurface = null!;
    private Gpu myGpu = null!;
    private Device myDevice = null!;
    private Swapchain mySwapchain = null!;
    private DrawQueue myDrawQueue = null!;
    
    private List<ImageView> myImageViews = new();

    private List<FrameData> myFrameData = new() { };
    private FrameData myCurrentFrame => myFrameData[(int)(myFrameNumber % FrameOverlap)];
    
    private ulong myFrameNumber = 0;

    public Renderer(Window aWindow)
    {
        Init(aWindow);
    }

    public void Draw()
    {
        myCurrentFrame.MyRenderFence.Wait(myDevice);
        myCurrentFrame.MyRenderFence.Reset(myDevice);
        
        uint imageIndex = myDevice.AcquireNextImage(mySwapchain, myCurrentFrame.MyImageAvailableSemaphore);

        CommandBuffer cmd = myCurrentFrame.MyCommandBuffer;

        cmd.Reset();
        cmd.BeginRecording();
        
        VkImage currentImage = mySwapchain.MyImages[(int)imageIndex];
        
        cmd.TransitionImage(currentImage, VkImageLayout.Undefined, VkImageLayout.General);

        VkClearColorValue clearColor = new((float)Math.Sin((double)myFrameNumber/144d), 0f, 0f);

        cmd.ClearColor(currentImage, VkImageLayout.General, clearColor);
        
        cmd.TransitionImage(currentImage, VkImageLayout.General, VkImageLayout.PresentSrcKHR);

        cmd.EndRecording();

        myDrawQueue.Submit(cmd, myCurrentFrame.MyImageAvailableSemaphore, myCurrentFrame.MyRenderFinishedSemaphore, myCurrentFrame.MyRenderFence);
        
        myDrawQueue.Present(mySwapchain, myCurrentFrame.MyRenderFinishedSemaphore, imageIndex);
        
        myFrameNumber++;
    }
}