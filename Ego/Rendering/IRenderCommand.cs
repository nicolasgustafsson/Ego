using VulkanApi;

namespace Rendering;

public interface IRenderCommand
{
    public void Render(CommandBufferHandle aHandle);
}