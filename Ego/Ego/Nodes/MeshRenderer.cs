using System.Diagnostics;
using System.Drawing;
using ImageMagick;
using Microsoft.IO;
using NativeFileDialogs.Net;
using Rendering;
using Rendering.Materials;
using SharpGLTF.Materials;
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
    private GpuBuffer<MaterialConstants> MaterialConstantsBuffer = null!;

    [Serialize] private int MeshIndex = 0;
    private string lastPath = "";
    private Task? myLoadTextureTask;

    private static int index = 0;
    private Image? myPreviousVulkanImage = null;

    private Vector4 myColor = Vector4.One;
    
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

        MaterialConstantsBuffer = new(GpuBufferType.Uniform, GpuBufferTransferType.Direct);
        
        MaterialConstants constants = new();
        constants.Color = Vector4.One;
        constants.MetallicRoughness = new Vector4(1f, 0.5f, 0f, 0f);
        constants.ColorTexture = RendererApi.Renderer.WhiteImage.Index!.Value;
        MaterialConstantsBuffer.SetData(constants);

        Material = new Material("Shaders/mesh.slang", MaterialConstantsBuffer, this);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();

        MaterialConstantsBuffer.Destroy();
    }

    protected override void Update()
    {
        if (MeshData != null)
            RendererApi.RenderData.Render(new MeshRenderRequest(){MyMeshData = MeshData, Material = Material, WorldMatrix = WorldMatrix}); 
        
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
        
        Image vulkanImage = new(rawTextureData.AsSpan(), VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled, new VkExtent3D(image.Width, image.Height, 1), true);

        MaterialConstants constants = new();
        
        constants.Color = myColor;
        constants.MetallicRoughness = new Vector4(1f, 0.5f, 0f, 0f);
        constants.ColorTexture = vulkanImage.Index!.Value;
        MaterialConstantsBuffer.SetData(constants);
        
        await EgoTask.MainThread();

        Image? toDelete = myPreviousVulkanImage;
        myPreviousVulkanImage = vulkanImage;

        //Destroy the previous image.
        await EgoTask.Renderer();
        toDelete?.Destroy();
    }

    private void Inspect()
    {
        if (Imgui.Button("Load Texture"))
        {
            if (Nfd.OpenDialog(out string? outPath, new Dictionary<string, string>()
            {
                { "Texture", "png" },
            }) == NfdStatus.Ok && outPath != null)
            {
                myLoadTextureTask = LoadATexture(outPath);
            }
        }
        
        if (Imgui.ColorPicker4("Color", ref myColor))
        {
            MaterialConstants constants = new();
        
            constants.Color = myColor;
            constants.MetallicRoughness = new Vector4(1f, 0.5f, 0f, 0f);
            constants.ColorTexture = myPreviousVulkanImage?.Index!.Value ?? RendererApi.Renderer.WhiteImage.Index!.Value;
            MaterialConstantsBuffer.SetData(constants);
        }
    }
}