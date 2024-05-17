global using static Graphics.MemoryAllocator;
using static Vortice.Vulkan.Vma;
namespace Graphics;

public unsafe class MemoryAllocator : IGpuDestroyable
{
    public static MemoryAllocator GlobalAllocator = null!;
    public VmaAllocator myVmaAllocator;
    public MemoryAllocator()
    {
        VmaAllocatorCreateInfo createInfo = new();
        createInfo.physicalDevice = GpuInstance.MyVkPhysicalDevice;
        createInfo.instance = VulkanApi.MyVkInstance;
        createInfo.device = Device.MyVkDevice;
        createInfo.flags = VmaAllocatorCreateFlags.BufferDeviceAddress;
        
        createInfo.vulkanApiVersion = VkVersion.Version_1_3;

        vmaCreateAllocator(&createInfo, out myVmaAllocator).CheckResult();
        
        GlobalAllocator = this;
    }
    
    public void Destroy()
    {
        vmaDestroyAllocator(myVmaAllocator);
    }
}