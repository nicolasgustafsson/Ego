namespace VulkanApi;

public unsafe class ImageView : IGpuDestroyable
{
    public VkImageView VkImageView;
    
    public ImageView(VkImage aImage, VkFormat aFormat, VkImageAspectFlags aAspectFlags, uint aMipLevels = 1)
    {
        VkImageViewCreateInfo createInfo = new();

        createInfo.image = aImage;
        createInfo.format = aFormat;
        
        createInfo.components = VkComponentMapping.Identity;
        createInfo.viewType = VkImageViewType.Image2D;
        createInfo.subresourceRange.aspectMask = aAspectFlags;
        createInfo.subresourceRange.baseMipLevel = 0;
        createInfo.subresourceRange.levelCount = aMipLevels;
        createInfo.subresourceRange.baseArrayLayer = 0;
        createInfo.subresourceRange.layerCount = 1;

        VkApiDevice.vkCreateImageView(Device.VkDevice, &createInfo, null, out VkImageView).CheckResult();
    }
    
    public void Destroy()
    {
        VkApiDevice.vkDestroyImageView(Device.VkDevice, VkImageView, null);
    }
}