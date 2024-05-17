global using static Graphics.LogicalDevice;
namespace Graphics;

public unsafe class LogicalDevice : IGpuDestroyable
{
    public static LogicalDevice Device;
    public VkDevice MyVkDevice;

    public void LoadFunctions()
    {
        vkLoadDevice(MyVkDevice);
    }
    
    public void WaitUntilIdle()
    {
        vkDeviceWaitIdle(MyVkDevice);
    }
    
    public void WaitForFence(VkFence aFence)
    {
        vkWaitForFences(MyVkDevice, aFence, true, 1_000_000_000).CheckResult();
    }
    
    public void ResetFence(VkFence aFence)
    {
        vkResetFences(MyVkDevice, aFence).CheckResult();
    }
    
    public (VkResult result, uint imageIndex) AcquireNextImage(Swapchain aSwapchain, Semaphore aImageAvailableSemaphore)
    {
        VkResult result = vkAcquireNextImageKHR(MyVkDevice, aSwapchain.MyVkSwapchain, 1_000_000_000, aImageAvailableSemaphore.MyVkSemaphore, VkFence.Null, out uint imageIndex);
        return (result, imageIndex);
    }

    public void Destroy()
    {
        vkDestroyDevice(MyVkDevice);
    }
}