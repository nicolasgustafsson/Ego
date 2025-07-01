using System.Diagnostics;
using ImageMagick;
using ImGuiNET;
using NativeFileDialogs.Net;
using Rendering;
using Rendering.Materials;
using Vortice.Vulkan;
using VulkanApi;

namespace Ego;

[Node]
public partial class MeshRenderer : Node3D
{
    private string ModelPath = "Models/structure.glb";
    private MeshData? MeshData = null;
    private Material Material = null!;
    private AllocatedBuffer<MaterialBuilder.MaterialConstants> MaterialConstantsBuffer = null!;

    [Serialize] private int MeshIndex = 0;
    
    public MeshRenderer()
    {
        
    }
    
    public MeshRenderer(MeshData aMeshData)
    {
        MeshData = aMeshData;
    }

    public override void Start()
    {
        base.Start();

        MaterialConstantsBuffer = new(VkBufferUsageFlags.UniformBuffer, VmaMemoryUsage.CpuToGpu);
        
        MaterialBuilder.MaterialConstants constants = new();
        
        constants.Color = Vector4.One;
        constants.MetallicRoughness = new Vector4(1f, 0.5f, 0f, 0f);
        MaterialConstantsBuffer.SetWriteData(constants);
        
        Material = MaterialBuilder.CreateMaterial(MaterialPassType.MainColor,
            RendererApi.Renderer.WhiteImage,
            RendererApi.Renderer.DefaultLinearSampler,
            RendererApi.Renderer.WhiteImage,
            RendererApi.Renderer.DefaultLinearSampler, MaterialConstantsBuffer, 0, RendererApi.Renderer.GlobalDescriptorAllocator);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();

        MaterialConstantsBuffer.Destroy();
    }

    protected override void Update()
    {
        if (MeshData != null)
            RendererApi.RenderData.RenderMesh(new(){MyMeshData = MeshData, Material = Material, WorldMatrix = WorldMatrix}); 
    }
    
    private async Task LoadATexture(string aPath)
    {
        await EgoTask.WorkerThread();

        var file = await File.ReadAllBytesAsync(aPath);
        
        MagickImage image = new(file);
        image.Format = MagickFormat.Rgba;
        var rawTextureData = image.ToByteArray();

        Renderer renderer = await EgoTask.Renderer();
        
        Image vulkanImage = new(renderer, rawTextureData, VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled, new VkExtent3D(image.Width, image.Height, 1), true);

        MaterialConstantsBuffer = new(VkBufferUsageFlags.UniformBuffer, VmaMemoryUsage.CpuToGpu);
        
        MaterialBuilder.MaterialConstants constants = new();
        
        constants.Color = Vector4.One;
        constants.MetallicRoughness = new Vector4(1f, 0.5f, 0f, 0f);
        MaterialConstantsBuffer.SetWriteData(constants);
        
        var newMaterial = MaterialBuilder.CreateMaterial(MaterialPassType.MainColor,
            vulkanImage,
            RendererApi.Renderer.DefaultLinearSampler,
            RendererApi.Renderer.WhiteImage,
            RendererApi.Renderer.DefaultLinearSampler, MaterialConstantsBuffer, 0, RendererApi.Renderer.GlobalDescriptorAllocator);
        
        await EgoTask.MainThread();
        Material = newMaterial;
    }

    private void Inspect()
    {
        if (ImGui.Button("Load Texture"))
        {
            if (Nfd.OpenDialog(out string? outPath, new Dictionary<string, string>()
            {
                { "Texture", "png" },
            }) == NfdStatus.Ok && outPath != null)
            {
                LoadATexture(outPath);
            }
        }
    }
}