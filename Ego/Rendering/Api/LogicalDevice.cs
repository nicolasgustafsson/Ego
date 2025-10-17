global using static VulkanApi.LogicalDevice;
namespace VulkanApi;

public unsafe class LogicalDevice : IGpuDestroyable
{
    public static LogicalDevice Device = null!;
    public VkDevice VkDevice;
    public static VkDeviceApi VkApiDevice = null!;

    public void LoadFunctions()
    {
        VkApiDevice = GetApi(Api.ApiInstance.VkInstance, VkDevice);
    }
    
    public void WaitUntilIdle()
    {
        VkApiDevice.vkDeviceWaitIdle(VkDevice);
    }
    
    public void WaitForFence(VkFence aFence)
    {
        VkApiDevice.vkWaitForFences(VkDevice, aFence, true, 300_000_000).CheckResult();
    }
    
    public void ResetFence(VkFence aFence)
    {
        VkApiDevice.vkResetFences(VkDevice, aFence).CheckResult();
    }
    
    public (VkResult result, uint imageIndex) AcquireNextImage(Swapchain aSwapchain, Semaphore aImageAvailableSemaphore)
    {
        VkResult result = VkApiDevice.vkAcquireNextImageKHR(VkDevice, aSwapchain.VkSwapchain, 1_000_000_000, aImageAvailableSemaphore.VkSemaphore, VkFence.Null, out uint imageIndex);
        return (result, imageIndex);
    }

    public void Destroy()
    {
        VkApiDevice.vkDestroyDevice(VkDevice);
    }
}