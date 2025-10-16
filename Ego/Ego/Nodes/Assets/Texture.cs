using MessagePack;
using Rendering;
using Rendering.Materials;
using StbImageSharp;
using Vortice.Vulkan;
using VulkanApi;

namespace Ego;

[MessagePackObject(true)]
public class TextureHeader
{
    public int Width;
    public int Height;
    
    //Nicos: In the future, we'll have one for each mip - right now this is redundant(it's just the rest of the file)
    //public int TextureByteSize;
}

public class TextureFile
{
    public FileHeader FileHeader;
    public TextureHeader Texture;
    
    public TextureFile(FileHeader aFileHeader, TextureHeader aTexture)
    {
        FileHeader = aFileHeader;
        Texture = aTexture;
    }
}

[Node]
public partial class Texture : Node, IImportable
{
    private Image? VulkanImage;
    public int Width;
    public int Height;
    
    private async Task UploadToGpu(byte[] aTextureBytes)
    {
        GpuDataTransferer dataTransfer = await EgoTask.GpuDataTransfer();

        Image vulkanImage = new(aTextureBytes, VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled, new VkExtent3D(Width, Height, 1), true);

        await EgoTask.MainThread();

        Image? toDelete = VulkanImage;
        VulkanImage = vulkanImage;

        //Destroy the previous image.
        await EgoTask.Renderer();
        toDelete?.Destroy();
    }
    
    public async Task Import(string aFilePath)
    {
        await EgoTask.WorkerThread();
        
        await using FileStream stream = File.OpenRead(aFilePath);

        ImageResult image = ImageResult.FromStream(stream);
        
        Width = image.Width;
        Height = image.Height;
        
        await UploadToGpu(image.Data);
        //await SerializeToFile()
    }
    
    public async Task SerializeToFile(string aFile, byte[] aBytes)
    {
        await EgoTask.WorkerThread();

        using FileStream stream = File.OpenWrite(aFile);

        FileHeader fileHeader = new();
        TextureHeader textureHeader = new();
        textureHeader.Height = Height;
        textureHeader.Width = Width;
        
        MessagePackSerializer.Serialize(stream, fileHeader);
        MessagePackSerializer.Serialize(stream, textureHeader);
        MessagePackSerializer.Serialize(stream, aBytes);
    }
    
    public async Task DeserializeFromFile(string aFile)
    {
        await EgoTask.WorkerThread();
        using FileStream stream = File.OpenRead(aFile);
        
        //MessagePackSerializer bad here - it deserializes the entire stream many times
        FileHeader fileHeader = MessagePackSerializer.Deserialize<FileHeader>(stream);
        TextureHeader textureHeader = MessagePackSerializer.Deserialize<TextureHeader>(stream);
        byte[] data = MessagePackSerializer.Deserialize<byte[]>(stream);

        Width = textureHeader.Width;
        Height = textureHeader.Height;

        await UploadToGpu(data);
    }
}