namespace Graphics;

public unsafe class ImageView
{
    public VkImageView MyVkImageView;
    
    public ImageView(VkImage aImage, VkFormat aFormat)
    {
        VkImageViewCreateInfo createInfo = new();

        createInfo.image = aImage;
        createInfo.format = aFormat;
        
        createInfo.components = VkComponentMapping.Identity;
        createInfo.viewType = VkImageViewType.Image2D;
        createInfo.subresourceRange.aspectMask = VkImageAspectFlags.Color;
        createInfo.subresourceRange.baseMipLevel = 0;
        createInfo.subresourceRange.levelCount = 1;
        createInfo.subresourceRange.baseArrayLayer = 0;
        createInfo.subresourceRange.layerCount = 1;

        vkCreateImageView(Device.MyVkDevice, &createInfo, null, out MyVkImageView).CheckResult();
    }
    
    public void Destroy()
    {
        vkDestroyImageView(Device.MyVkDevice, MyVkImageView, null);
    }
}