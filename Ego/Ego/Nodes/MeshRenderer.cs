using System.Diagnostics;
using ImageMagick;
using ImGuiNET;
using Microsoft.IO;
using NativeFileDialogs.Net;
using Rendering;
using Rendering.Materials;
using StbImageSharp;
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
    private string lastPath = "";
    private Task? myLoadTextureTask;

    private static int index = 0;
    private Image? myPreviousVulkanImage = null;
    
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
        
        if (Window.IsKeyboardKeyDown(KeyboardKey.Backspace) && (myLoadTextureTask == null || myLoadTextureTask.IsCompleted))
        {
            var randomPathFolder = "C:/Users/Nicos/Desktop/RandomImages";
            string randomPath = Directory.GetFiles(randomPathFolder).OrderBy(thing => Guid.NewGuid().GetHashCode()).First();
            
            myLoadTextureTask = LoadATexture(randomPath);
        }
        if (Window.IsKeyboardKeyDown(KeyboardKey.U))
        {
            var randomPathFolder = "C:/Users/Nicos/Desktop/RandomImages";
            string randomPath = Directory.GetFiles(randomPathFolder).OrderBy(thing => Guid.NewGuid().GetHashCode()).First();
            
            var file = File.ReadAllBytes(randomPath);
        }
    }
    
    private async Task LoadATexture(string aPath)
    {
        index++;
        
        lastPath = aPath;
        
        await EgoTask.WorkerThread();
        
        /*RecyclableMemoryStreamManager manager;
        var file = manager.GetStream();*/
        
        
        using MagickImage image = new(new FileStream(aPath, FileMode.Open));
        image.Format = MagickFormat.Rgba;
        
        var rawTextureData = image.ToByteArray();

        //using FileStream stream = File.OpenRead(aPath);

        //ImageResult image = ImageResult.FromStream(stream);
        
        GpuDataTransferer dataTransfer = await EgoTask.GpuDataTransfer();
        
        /*
        int components = (int)image.Comp;
        
        if (components == 0)
            components = 4;

        VkFormat formatToUse;
        switch(image.Comp)
        {
            case ColorComponents.Default:
                formatToUse = VkFormat.R8G8B8A8Unorm;
                break;
            case ColorComponents.Grey:
                formatToUse = VkFormat.R8Unorm;
                break;
            case ColorComponents.GreyAlpha:
                formatToUse = VkFormat.R8G8Unorm;
                break;
            case ColorComponents.RedGreenBlue:
                formatToUse = VkFormat.R8G8B8Unorm;
                break;
            case ColorComponents.RedGreenBlueAlpha:
                formatToUse = VkFormat.R8G8B8A8Unorm;
                break;
            default:
                formatToUse = VkFormat.R8G8B8A8Unorm;
                break;
        }*/
        
        int dataSize = (int)image.Width * (int)image.Height * 4;
        var buffer = dataTransfer.TakeStagingBuffer((uint)dataSize);
        Image vulkanImage = new(dataTransfer, rawTextureData, VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled, new VkExtent3D(image.Width, image.Height, 1), true, buffer);
        dataTransfer.ReturnStagingBuffer(buffer);

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

        Image? toDelete = myPreviousVulkanImage;
        myPreviousVulkanImage = vulkanImage;

        //Destroy the previous image.
        await EgoTask.Renderer();
        toDelete?.Destroy();
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
                myLoadTextureTask = LoadATexture(outPath);
            }
        }
    }
}