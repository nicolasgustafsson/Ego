using static Vortice.Vulkan.Vma;
namespace Graphics;
public unsafe class MemoryAllocator
{
    public VmaAllocator myVmaAllocator;
    public MemoryAllocator(Gpu aGpu, Api aApi)
    {
        VmaAllocatorCreateInfo createInfo = new();
        createInfo.physicalDevice = aGpu.MyVkPhysicalDevice;
        createInfo.instance = aApi.MyVkInstance;
        createInfo.device = Device.MyVkDevice;
        createInfo.flags = VmaAllocatorCreateFlags.BufferDeviceAddress;
        
        createInfo.vulkanApiVersion = VkVersion.Version_1_3;

        vmaCreateAllocator(&createInfo, out myVmaAllocator).CheckResult();
    }
    
    public void Destroy()
    {
        vmaDestroyAllocator(myVmaAllocator);
    }
}