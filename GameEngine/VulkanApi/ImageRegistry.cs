namespace Rendering;

public static class ImageRegistry
{
    public static Dictionary<nint, VulkanApi.Image> PointersToImages = new();
}