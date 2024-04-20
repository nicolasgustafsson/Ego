using System.Runtime.InteropServices;
using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;

namespace Rendering;

public unsafe partial class Renderer
{
    private DisplayServer GetDisplayServer()
    {
        if (OperatingSystem.IsWindows())
            return DisplayServer.Windows;

        return LinuxDisplayServer;
    }
    
    private string GetSurfaceExtension()
    {
        switch(GetDisplayServer())
        {
            case DisplayServer.Windows:
                return "VK_KHR_win32_surface";
            case DisplayServer.X11:
                return "VK_KHR_xlib_surface";
            case DisplayServer.Wayland:
                return "VK_KHR_wayland_surface";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    [UnmanagedCallersOnly]
    private static uint DebugMessengerCallback(VkDebugUtilsMessageSeverityFlagsEXT messageSeverity,
        VkDebugUtilsMessageTypeFlagsEXT messageTypes,
        VkDebugUtilsMessengerCallbackDataEXT* pCallbackData,
        void* userData)
    {
        string message = new(pCallbackData->pMessage);
        
        Console.WriteLine($"[Vulkan]: {messageTypes}: {messageSeverity} - {message}");
        
        return VK_FALSE;
    }
    
    private void PrintAllAvailableInstanceExtensions()
    {
        Console.WriteLine("--- AVAILABLE INSTANCE EXTENSIONS ---");
        uint extensionCount = 0;
        vkEnumerateInstanceExtensionProperties(null, &extensionCount, null).CheckResult();
        VkExtensionProperties* extensions = stackalloc VkExtensionProperties[(int)extensionCount];
        vkEnumerateInstanceExtensionProperties(null, &extensionCount, extensions).CheckResult();

        for (int i = 0; i < extensionCount; i++)
        {
            Console.WriteLine($"Extension: {Helpers.GetString(extensions[i].extensionName)} version: {extensions[i].specVersion}");
        }

        Console.WriteLine("--- ---------------------------- ---");
    }
    
    private void PrintAllAvailableDeviceExtensions()
    {
        
        Console.WriteLine("--- AVAILABLE DEVICE EXTENSIONS ---");
        uint extensionCount = 0;
        vkEnumerateDeviceExtensionProperties(myPhysicalDevice, null, &extensionCount, null).CheckResult();
        VkExtensionProperties* extensions = stackalloc VkExtensionProperties[(int)extensionCount];
        vkEnumerateDeviceExtensionProperties(myPhysicalDevice, null, &extensionCount, extensions).CheckResult();

        for (int i = 0; i < extensionCount; i++)
        {
            Console.WriteLine($"Extension: {Helpers.GetString(extensions[i].extensionName)} version: {extensions[i].specVersion}");
        }
        Console.WriteLine("--- ---------------------------- ---");
    }
    
    private void TransitionImage(VkCommandBuffer aCmd, VkImage aImage, VkImageLayout aFrom, VkImageLayout aTo)
    {
        VkImageMemoryBarrier2 imageBarrier = new();
        imageBarrier.srcStageMask = VkPipelineStageFlags2.AllCommands;
        imageBarrier.srcAccessMask = VkAccessFlags2.MemoryWrite;
        imageBarrier.dstStageMask = VkPipelineStageFlags2.AllCommands;
        imageBarrier.dstAccessMask = VkAccessFlags2.MemoryRead | VkAccessFlags2.MemoryWrite;

        imageBarrier.oldLayout = aFrom;
        imageBarrier.newLayout = aTo;
        VkImageAspectFlags aspectMask = (aTo == VkImageLayout.DepthAttachmentOptimal)
            ? VkImageAspectFlags.Depth
            : VkImageAspectFlags.Color;

        imageBarrier.subresourceRange = new VkImageSubresourceRange(aspectMask);
        imageBarrier.image = aImage;

        VkDependencyInfo depInfo = new();
        depInfo.imageMemoryBarrierCount = 1;
        depInfo.pImageMemoryBarriers = &imageBarrier;

        vkCmdPipelineBarrier2(aCmd, &depInfo);
    }
    
    VkSemaphoreSubmitInfo GetSemaphoreSubmitInfo(VkPipelineStageFlags2 aStageMask, VkSemaphore aSemaphore)
    {
        VkSemaphoreSubmitInfo info = new();
        info.semaphore = aSemaphore;
        info.stageMask = aStageMask;
        info.deviceIndex = 0;
        info.value = 1;
        return info;
    }
    
    VkCommandBufferSubmitInfo GetCommandBufferSubmitInfo(VkCommandBuffer aCmd)
    {
        VkCommandBufferSubmitInfo info = new();
        info.commandBuffer = aCmd;
        info.deviceMask = 0;
        return info;
    }
    
    private VkSubmitInfo2 GetSubmitInfo(VkCommandBufferSubmitInfo* aCmdInfo, VkSemaphoreSubmitInfo* aWaitSemaphoreInfo, VkSemaphoreSubmitInfo* aSignalSemaphoreInfo)
    {
        VkSubmitInfo2 info = new();
        
        info.signalSemaphoreInfoCount = 1;
        
        info.pSignalSemaphoreInfos = aSignalSemaphoreInfo;

        info.waitSemaphoreInfoCount = 0;
        
        info.waitSemaphoreInfoCount = 1;
        
        info.pWaitSemaphoreInfos = aWaitSemaphoreInfo;

        info.commandBufferInfoCount = 1;
        info.pCommandBufferInfos = aCmdInfo;

        return info;
    }
}