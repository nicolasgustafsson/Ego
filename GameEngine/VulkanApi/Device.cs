namespace Graphics;

public class Device
{
    public VkDevice MyVkDevice;
    public VkQueue MyDrawQueue;
    public uint MyDrawQueueIndex;

    public void LoadFunctions()
    {
        vkLoadDevice(MyVkDevice);
    }
    
    public void Setup(uint aDrawQueue)
    {
        MyDrawQueueIndex = aDrawQueue;

        vkGetDeviceQueue(MyVkDevice, MyDrawQueueIndex, 0, out MyDrawQueue);
    }
    
    public void WaitUntilIdle()
    {
        vkDeviceWaitIdle(MyVkDevice);
    }
}