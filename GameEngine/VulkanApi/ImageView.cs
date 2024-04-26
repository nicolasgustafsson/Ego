namespace Graphics;

public unsafe class ImageView
{
    public VkImageView MyVkImageView;
    
    public void Destroy(Device aDevice)
    {
        vkDestroyImageView(aDevice.MyVkDevice, MyVkImageView, null);
    }
}