namespace Graphics;

public unsafe class Fence
{
    public VkFence MyVkFence;
    public Fence(Device aDevice)
    {
        vkCreateFence(aDevice.MyVkDevice, VkFenceCreateFlags.Signaled, out MyVkFence).CheckResult();
    }
    
    public void Destroy(Device aDevice)
    {
        vkDestroyFence(aDevice.MyVkDevice, MyVkFence);
    }
    
    public void Wait(Device aDevice)
    {
        aDevice.WaitForFence(MyVkFence);
    }
    
    public void Reset(Device aDevice)
    {
        aDevice.ResetFence(MyVkFence);
    }
}