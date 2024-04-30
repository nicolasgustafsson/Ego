namespace Graphics;

public unsafe class Semaphore
{
    public VkSemaphore MyVkSemaphore;
    public Semaphore()
    {
        vkCreateSemaphore(Device.MyVkDevice, out MyVkSemaphore).CheckResult();
    }
    
    public void Destroy()
    {
        vkDestroySemaphore(Device.MyVkDevice, MyVkSemaphore);
    }
}