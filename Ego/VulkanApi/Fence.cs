namespace VulkanApi;

public unsafe class Fence : IGpuDestroyable
{
    public VkFence VkFence;
    public Fence()
    {
        vkCreateFence(Device.VkDevice, VkFenceCreateFlags.Signaled, out VkFence).CheckResult();
    }
    
    public void Destroy()
    {
        vkDestroyFence(Device.VkDevice, VkFence);
    }
    
    public void Wait()
    {
        Device.WaitForFence(VkFence);
    }
    
    public void Reset()
    {
        Device.ResetFence(VkFence);
    }
}