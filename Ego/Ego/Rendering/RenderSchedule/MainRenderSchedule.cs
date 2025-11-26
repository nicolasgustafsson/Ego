using System.Drawing;
using Rendering;
using Rendering.Materials;
using VulkanApi;

namespace Ego.Rendering;

public struct FullscreenVertex
{
    public Vector3 Position;
    public float Dummy;
        
    public FullscreenVertex(float X, float Y, float Z)
    {
        Position.X = X;
        Position.Y = Y;
        Position.Z = Z;
    }
}

public struct FullscreenPushConstants
{
    public VkDeviceAddress VertexBufferAddress;
    public VkDeviceAddress MaterialUniformBufferAddress;
}

public class MainRenderSchedule : RenderSchedule
{
    public Image RenderImage = null!;
    public Image MsaaImage = null!;
    private Image DepthImage = null!;
    VkSampleCountFlags MsaaSamples = VkSampleCountFlags.Count8;

    public Color ClearColor = Color.CornflowerBlue;

    public Material SkyMaterial;
    public MeshData SquareMesh = null!;

    public MainRenderSchedule(Renderer aRenderer) : base(aRenderer)
    {
        Setup();
        SkyMaterial = new("Shaders/Sky.slang", aRenderer);
        SkyMaterial.UseDepth = false;
        SkyMaterial.CullMode = VkCullModeFlags.None;
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
        
        List<FullscreenVertex> vertices = new(){new(-1f, -1f, 0.0001f), new(1f, -1f, 0.0001f), new(1f, 1f, 0.0001f), new(-1f, 1f, 0.0001f)};
        List<uint> indices = new() {0, 2, 3, 2, 0, 1 }; 

        SquareMesh = new MeshData("Line", (new[]{new GeoSurface(){StartIndex = 0, Count = 6}}).ToList(), new MeshBuffers<FullscreenVertex>(Renderer, MemoryAllocator.GlobalAllocator, indices, vertices));
    }


    public override void Execute(FrameData aFrameData, SceneData aSceneData, CommandBufferHandle cmd)
    {
        VkDescriptorSet globalDescriptor = UpdateSceneData(aFrameData, aSceneData);
        
        cmd.EnableShaderObjects();
        cmd.SetMsaa(MsaaSamples);

        cmd.TransitionImage(MsaaImage, VkImageLayout.ColorAttachmentOptimal);
        
        RenderSky(MsaaImage, DepthImage, cmd, globalDescriptor);
        RenderGeometry(MsaaImage, DepthImage, cmd, globalDescriptor);
        
        
        cmd.ResolveMsaa(MsaaImage, RenderImage);
        cmd.DisableMsaa();

        cmd.BeginRendering(RenderImage);
        Renderer.ERenderImgui(cmd.VkCommandBuffer);
        cmd.EndRendering();
    }
    
    private void RenderSky(Image aRenderImage, Image aDepthImage, CommandBufferHandle cmd, VkDescriptorSet aSceneDataDescriptor)
    {
        cmd.BeginRendering(aRenderImage, aDepthImage, ClearColor);

        FullscreenPushConstants pushConstants = new();
        pushConstants.MaterialUniformBufferAddress = SkyMaterial.UniformBuffer!.GetDeviceAddress();
        pushConstants.VertexBufferAddress = SquareMesh.MeshBuffers.VertexBufferAddress;
        
        cmd.DrawGeometry(SquareMesh, SkyMaterial, aSceneDataDescriptor, Renderer.TextureRegistryDescriptorSet, pushConstants);

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
