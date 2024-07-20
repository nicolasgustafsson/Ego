
using System.Numerics;
using VulkanApi;
using ImGuiNET;

public static unsafe partial class ImGuiEx
{
    public static void Image(Image aImage, Vector2? aSize = null)
    {
        nint handle = aImage.GetHandle();
        Vector2 size = aSize ?? new Vector2(aImage.Extent.width, aImage.Extent.height);
        
        ImGui.Image(handle, size);
    }
}