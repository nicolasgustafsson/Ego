namespace VulkanApi;

public unsafe class Semaphore : IGpuDestroyable
{
    public VkSemaphore VkSemaphore;
    public Semaphore()
    {
        VkApiDevice.vkCreateSemaphore(Device.VkDevice, out VkSemaphore).CheckResult();
    }
    
    public void Destroy()
    {
        VkApiDevice.vkDestroySemaphore(Device.VkDevice, VkSemaphore);
    }
}