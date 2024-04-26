namespace Graphics;

public unsafe class Device
{
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
    
    public uint AcquireNextImage(Swapchain aSwapchain, Semaphore aImageAvailableSemaphore)
    {
        vkAcquireNextImageKHR(MyVkDevice, aSwapchain.MyVkSwapchain, 1_000_000_000, aImageAvailableSemaphore.MyVkSemaphore, VkFence.Null, out uint imageIndex);
        return imageIndex;
    }

    public void DestroySelf()
    {
        vkDestroyDevice(MyVkDevice);
    }
}