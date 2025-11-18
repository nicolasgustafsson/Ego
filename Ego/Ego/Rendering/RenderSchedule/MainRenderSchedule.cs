using System.Drawing;
using Rendering;
using Rendering.Materials;
using VulkanApi;

namespace Ego.Rendering;

public class MainRenderSchedule : RenderSchedule
{
    public Image RenderImage = null!;
    public Image MsaaImage = null!;
    private Image DepthImage = null!;
    VkSampleCountFlags MsaaSamples = VkSampleCountFlags.Count8;
    
    public Color ClearColor = Color.CornflowerBlue;

    //public Material SkyMaterial;

    public MainRenderSchedule(Renderer aRenderer) : base(aRenderer)
    {
        Setup();
    }
    
    public void Setup()
    {
        VkExtent3D extents = new (Renderer.Swapchain.Extents.width, Renderer.Swapchain.Extents.height, 1);
        RenderImage = new Image(VkFormat.R16G16B16A16Sfloat, 
            VkImageUsageFlags.Storage | VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst | VkImageUsageFlags.TransferSrc,
            extents, aMipMaps: false, aIsRenderTexture:true, VkSampleCountFlags.Count1);
        
        MsaaImage = new Image(VkFormat.R16G16B16A16Sfloat, 
            VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst | VkImageUsageFlags.TransferSrc,
            extents, aMipMaps: false, aIsRenderTexture:true, MsaaSamples);

        DepthImage = new Image(VkFormat.D32Sfloat, 
            VkImageUsageFlags.DepthStencilAttachment, 
            extents, aMipMaps: false, aIsRenderTexture:true, MsaaSamples);
    }
        
    public override void Execute(FrameData aFrameData, SceneData aSceneData, CommandBufferHandle cmd)
    {
        VkDescriptorSet globalDescriptor = UpdateSceneData(aFrameData, aSceneData);
        
        cmd.EnableShaderObjects();
        cmd.SetMsaa(MsaaSamples);

        cmd.ClearColor(MsaaImage, ClearColor);

        RenderGeometry(MsaaImage, DepthImage, cmd, globalDescriptor);
            
        cmd.ResolveMsaa(MsaaImage, RenderImage);
        cmd.DisableMsaa();
            
        cmd.BeginRendering(RenderImage);
        Renderer.ERenderImgui(cmd.VkCommandBuffer);
        cmd.EndRendering();
    }
    
    private unsafe VkDescriptorSet UpdateSceneData(FrameData CurrentFrame, SceneData SceneData)
    {
        AllocatedBuffer<SceneData> sceneDataBuffer = new(VkBufferUsageFlags.UniformBuffer, VmaMemoryUsage.CpuToGpu);
        CurrentFrame.DeletionQueue.Add(sceneDataBuffer);
        sceneDataBuffer.SetWriteData(SceneData);
        VkDescriptorSet globalDescriptor = CurrentFrame.FrameDescriptors.Allocate(Renderer.SceneDataLayout);
        
        {
            DescriptorWriter writer = new();
            writer.WriteBuffer(0, sceneDataBuffer, 0, VkDescriptorType.UniformBuffer);
            writer.UpdateSet(globalDescriptor);
        }

        return globalDescriptor;
    }

    public override void Destroy()
    {
        base.Destroy();

        RenderImage.Destroy();
        DepthImage.Destroy();
        MsaaImage.Destroy();
    }
}
