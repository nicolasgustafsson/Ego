namespace Graphics;

public unsafe class Fence
{
    public VkFence MyVkFence;
    public Fence()
    {
        vkCreateFence(Device.MyVkDevice, VkFenceCreateFlags.Signaled, out MyVkFence).CheckResult();
    }
    
    public void Destroy()
    {
        vkDestroyFence(Device.MyVkDevice, MyVkFence);
    }
    
    public void Wait()
    {
        Device.WaitForFence(MyVkFence);
    }
    
    public void Reset()
    {
        Device.ResetFence(MyVkFence);
    }
}