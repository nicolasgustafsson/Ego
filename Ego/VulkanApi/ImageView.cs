namespace VulkanApi;

public unsafe class ImageView : IGpuDestroyable
{
    public VkImageView MyVkImageView;
    
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

        vkCreateImageView(Device.MyVkDevice, &createInfo, null, out MyVkImageView).CheckResult();
    }
    
    public void Destroy()
    {
        vkDestroyImageView(Device.MyVkDevice, MyVkImageView, null);
    }
}