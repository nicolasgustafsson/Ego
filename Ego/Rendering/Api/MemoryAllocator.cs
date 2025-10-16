global using static VulkanApi.MemoryAllocator;
using static Vortice.Vulkan.Vma;
namespace VulkanApi;

public unsafe class MemoryAllocator : IGpuDestroyable
{
    public static MemoryAllocator GlobalAllocator = null!;
    public VmaAllocator VmaAllocator;
    public MemoryAllocator()
    {
        VmaAllocatorCreateInfo createInfo = new();
        createInfo.physicalDevice = GpuInstance.VkPhysicalDevice;
        createInfo.instance = ApiInstance.VkInstance;
        createInfo.device = Device.VkDevice;
        createInfo.flags = VmaAllocatorCreateFlags.BufferDeviceAddress;
        
        createInfo.vulkanApiVersion = VkVersion.Version_1_3;

        vmaCreateAllocator(&createInfo, out VmaAllocator).CheckResult();
        
        GlobalAllocator = this;
    }
    
    public void Destroy()
    {
        vmaDestroyAllocator(VmaAllocator);
    }
}