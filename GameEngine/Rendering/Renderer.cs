using System.Runtime.InteropServices;
using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;

namespace Rendering;

enum DisplayServer
{
    Windows,
    X11,
    Wayland
}

public unsafe partial class Renderer
{
    private Window myWindow;
    
    private VkInstance myVulkanInstance;
    private VkSurfaceKHR mySurface;
    private VkPhysicalDevice myPhysicalDevice; 
    private VkDevice myDevice;
    private VkQueue myDrawQueue;
    private uint myGraphicsFamily;
    private VkSwapchainKHR mySwapchain = new();
    private VkSurfaceCapabilitiesKHR mySurfaceCapabilities;
    private List<VkImage> myImages = null!;
    private List<VkImageView> myImageViews = new();

    private VkDebugUtilsMessengerEXT myDebugMessenger = VkDebugUtilsMessengerEXT.Null;
    private VkFormat mySwapchainImageFormat;
    private VkExtent2D mySwapchainExtents;

    private List<FrameData> myFrameData = new() { };
    private FrameData myCurrentFrame => myFrameData[(int)(myFrameNumber % FrameOverlap)];
    private ulong myFrameNumber = 0;

    public Renderer(Window aWindow)
    {
        myWindow = aWindow;
        
        Init(aWindow);
    }

    public void Draw()
    {
        vkWaitForFences(myDevice, myCurrentFrame.MyRenderFence, true, 1_000_000_000).CheckResult();
        vkResetFences(myDevice, myCurrentFrame.MyRenderFence).CheckResult();
        vkAcquireNextImageKHR(myDevice, mySwapchain, 1_000_000_000, myCurrentFrame.MyImageAvailableSemaphore, VkFence.Null, out uint imageIndex);

        VkCommandBuffer cmd = myCurrentFrame.MyCommandBuffer;
        vkResetCommandBuffer(cmd, VkCommandBufferResetFlags.None).CheckResult();
        
        vkBeginCommandBuffer(cmd, VkCommandBufferUsageFlags.OneTimeSubmit).CheckResult();

        VkImage currentImage = myImages[(int)imageIndex];
        
        TransitionImage(cmd, currentImage, VkImageLayout.Undefined, VkImageLayout.General);

        VkClearColorValue clearColor = new((float)Math.Sin((double)myFrameNumber/144d), 0f, 0f);
        VkImageSubresourceRange clearRange = new VkImageSubresourceRange(VkImageAspectFlags.Color);

        vkCmdClearColorImage(cmd, currentImage, VkImageLayout.General, &clearColor, 1, &clearRange);

        TransitionImage(cmd, currentImage, VkImageLayout.General, VkImageLayout.PresentSrcKHR);

        vkEndCommandBuffer(cmd);

        VkCommandBufferSubmitInfo cmdInfo = GetCommandBufferSubmitInfo(cmd);
        VkSemaphoreSubmitInfo waitInfo = GetSemaphoreSubmitInfo(VkPipelineStageFlags2.ColorAttachmentOutput,
            myCurrentFrame.MyImageAvailableSemaphore);
        VkSemaphoreSubmitInfo signalInfo = GetSemaphoreSubmitInfo(VkPipelineStageFlags2.AllGraphics,
            myCurrentFrame.MyRenderFinishedSemaphore);

        VkSubmitInfo2 submitInfo = GetSubmitInfo(&cmdInfo, &waitInfo, &signalInfo);

        vkQueueSubmit2(myDrawQueue, 1, &submitInfo, myCurrentFrame.MyRenderFence);

        VkSwapchainKHR* swapchainPointer = stackalloc VkSwapchainKHR[] { mySwapchain };
        VkSemaphore* waitSemaphorePointer = stackalloc VkSemaphore[] { myCurrentFrame.MyRenderFinishedSemaphore };
        
        VkPresentInfoKHR presentInfo = new();
        presentInfo.pSwapchains = swapchainPointer;
        presentInfo.swapchainCount = 1;
        presentInfo.pWaitSemaphores = waitSemaphorePointer;
        presentInfo.waitSemaphoreCount = 1;
        presentInfo.pImageIndices = &imageIndex;

        vkQueuePresentKHR(myDrawQueue, &presentInfo);
        
        myFrameNumber++;
    }
}