namespace VulkanApi;

public unsafe class Semaphore : IGpuDestroyable
{
    public VkSemaphore VkSemaphore;
    public Semaphore()
    {
        vkCreateSemaphore(Device.VkDevice, out VkSemaphore).CheckResult();
    }
    
    public void Destroy()
    {
        vkDestroySemaphore(Device.VkDevice, VkSemaphore);
    }
}