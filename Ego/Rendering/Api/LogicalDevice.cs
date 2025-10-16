global using static VulkanApi.LogicalDevice;
namespace VulkanApi;

public unsafe class LogicalDevice : IGpuDestroyable
{
    public static LogicalDevice Device = null!;
    public VkDevice VkDevice;

    public void LoadFunctions()
    {
        vkLoadDevice(VkDevice);
    }
    
    public void WaitUntilIdle()
    {
        vkDeviceWaitIdle(VkDevice);
    }
    
    public void WaitForFence(VkFence aFence)
    {
        vkWaitForFences(VkDevice, aFence, true, 300_000_000).CheckResult();
    }
    
    public void ResetFence(VkFence aFence)
    {
        vkResetFences(VkDevice, aFence).CheckResult();
    }
    
    public (VkResult result, uint imageIndex) AcquireNextImage(Swapchain aSwapchain, Semaphore aImageAvailableSemaphore)
    {
        VkResult result = vkAcquireNextImageKHR(VkDevice, aSwapchain.VkSwapchain, 1_000_000_000, aImageAvailableSemaphore.VkSemaphore, VkFence.Null, out uint imageIndex);
        return (result, imageIndex);
    }

    public void Destroy()
    {
        vkDestroyDevice(VkDevice);
    }
}