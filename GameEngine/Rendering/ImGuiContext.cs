using Graphics;
using ImGuiNET;
using Vortice.Vulkan;

namespace Rendering;

public class ImGuiContext
{
    private Image myFontTexture;
    public ImGuiContext(Renderer aRenderer, Window aWindow)
    {
        var context = ImGui.CreateContext();

        ImGui.SetCurrentContext(context);

        var io = ImGui.GetIO();
        io.Fonts.AddFontDefault();
        io.Fonts.GetTexDataAsRGBA32(out nint pixels, out var width, out var height);

        myFontTexture = new Image(aRenderer.MyMemoryAllocator, VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled | VkImageUsageFlags.TransferDst, new VkExtent3D(width, height, 0));
    }
}