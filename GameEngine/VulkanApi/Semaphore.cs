namespace Graphics;

public unsafe class Semaphore
{
    public VkSemaphore MyVkSemaphore;
    public Semaphore(Device aDevice)
    {
        vkCreateSemaphore(aDevice.MyVkDevice, out MyVkSemaphore).CheckResult();
    }
    
    public void Destroy(Device aDevice)
    {
        vkDestroySemaphore(aDevice.MyVkDevice, MyVkSemaphore);
    }
}