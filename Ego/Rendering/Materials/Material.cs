using Vortice.Vulkan;
using VulkanApi;

namespace Rendering.Materials;

public enum MaterialPassType
{
    MainColor,
    Transparent,
    Other
}

public class Material
{
    public GraphicsPipeline Pipeline = null!;
    public VkDescriptorSet DescriptorSet;
    public MaterialPassType MyMaterialPassType = MaterialPassType.MainColor;
}