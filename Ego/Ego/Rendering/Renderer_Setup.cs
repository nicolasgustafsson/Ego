global using Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;
using System.Runtime.InteropServices;
using Ego;
using VulkanApi;
using Vortice.ShaderCompiler;

namespace Rendering;

public struct RendererInitSettings()
{
    public VkPresentModeKHR PresentMode = VkPresentModeKHR.Fifo;
}

[Node(AllowAddingToScene = false)]
public partial class Renderer : Node
{
    private Renderer()
    {
        MainWindow = null!;
    }
    
    private void Init(Window aWindow)
    {
        InitVulkan(aWindow);
    }
    
    private void InitVulkan(Window aWindow)
    {
        Log.Info($"Creating renderer...");
        
        CreateApi(aWindow);

        CreateSurface(aWindow);

        PickGpu();

        if (PrintExtensions)
            PrintAllExtensions();
        
        CreateDevice();

        CreateRenderQueue();
        
        CreateDataTransferer();

        CreateSwapchain();

        CreateImageViews();

        CreateMemoryAllocator();
        
        CreateRenderImage();

        CreateImmediateCommandBuffer();
        
        CreateFrameData();

        CreateDefaultImages(); 
        
        InitializeDescriptors();

        Log.Info($"Renderer successfully created!");
    }

    private unsafe void CreateDefaultImages()
    {
        Color white = Color.White;
        int whitePacked = white.ToArgb();
        Color black = Color.Black;
        int blackPacked = black.ToArgb();
        Color grey = Color.Gray;
        int greyPacked = grey.ToArgb();
        Color magenta = Color.Magenta;
        int magentaPacked = magenta.ToArgb();

        int[] checkerboard = new int[16 * 16];
        
        for(int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 16; y++)
            {
                checkerboard[y*16 + x] = (((x % 2) ^ (y % 2)) == 0) ? magentaPacked : blackPacked;
            }
        }

        WhiteImage = new Image((byte*)&whitePacked, VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled, new VkExtent3D(1, 1, 1), false);
        BlackImage = new Image((byte*)&blackPacked, VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled, new VkExtent3D(1, 1, 1), false);
        GreyImage = new Image((byte*)&greyPacked, VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled, new VkExtent3D(1, 1, 1), false);
        CheckerBoardImage = new Image((byte*)checkerboard.AsSpan().GetPointerUnsafe(), VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled, new VkExtent3D(16, 16, 1), false);

        DefaultLinearSampler = new(VkFilter.Linear);
        DefaultNearestSampler = new(VkFilter.Nearest);
        
        CleanupQueue.Add(WhiteImage);
        CleanupQueue.Add(BlackImage);
        CleanupQueue.Add(GreyImage);
        CleanupQueue.Add(CheckerBoardImage);
        CleanupQueue.Add(DefaultLinearSampler);
        CleanupQueue.Add(DefaultNearestSampler);
    }

    private void RecreateFramebuffer()
    {
        Device.WaitUntilIdle();

        CleanupQueue.RunDeletor(RenderImage);
        CleanupQueue.RunDeletor(DepthImage);
        
        foreach (var imageView in ImageViews)
            CleanupQueue.RunDeletor(imageView);

        ImageViews.Clear();

        RecreateSwapchain();
        CreateImageViews();
        CreateRenderImage();
        UpdateRenderImageDescriptorSet();
    }
    
    public void RecreateSwapchain()
    {
        CleanupQueue.RunDeletor(Swapchain);
        CreateSwapchain();
    }

    private void CreateImmediateCommandBuffer()
    {
        ImmediateFence = new();
        ImmediateCommandBuffer = new(RenderQueue);
        CleanupQueue.Add(ImmediateFence);
        CleanupQueue.Add(ImmediateCommandBuffer);
    }

    private void CreateRenderImage()
    {
         RenderImage = new Image(VkFormat.R16G16B16A16Sfloat, VkImageUsageFlags.Storage | VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst | VkImageUsageFlags.TransferSrc, new VkExtent3D(Swapchain.Extents.width, Swapchain.Extents.height, 1), false, aIsRenderTexture:true, VkSampleCountFlags.Count1);
         MsaaImage = new Image(VkFormat.R16G16B16A16Sfloat, VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst | VkImageUsageFlags.TransferSrc, new VkExtent3D(Swapchain.Extents.width, Swapchain.Extents.height, 1), false, aIsRenderTexture:true, MsaaSamples);
         CleanupQueue.Add(RenderImage);
         CleanupQueue.Add(MsaaImage);
         
         DepthImage = new Image(VkFormat.D32Sfloat, VkImageUsageFlags.DepthStencilAttachment, new VkExtent3D(Swapchain.Extents.width, Swapchain.Extents.height, 1), false, aIsRenderTexture:true, MsaaSamples);
         CleanupQueue.Add(DepthImage);
    }

    private unsafe void InitializeDescriptors()
    {
        List<DescriptorAllocatorGrowable.PoolSizeRatio> sizes =
        [
            new() { Ratio = 1f, Type = VkDescriptorType.StorageImage },
            new() { Ratio = 24f, Type = VkDescriptorType.UniformBuffer },
            new() { Ratio = 1f, Type = VkDescriptorType.CombinedImageSampler },
            new() { Ratio = 1f, Type = VkDescriptorType.Sampler },
            new() { Ratio = 24f, Type = VkDescriptorType.SampledImage }
        ];

        GlobalDescriptorAllocator = new();
        GlobalDescriptorAllocator.InitPool(100, sizes);

        CreateRenderImageDescriptor();

        CleanupQueue.Add(() =>
        {
            VkApiDevice.vkDestroyDescriptorSetLayout(Device.VkDevice, RenderImageDescriptorLayout);
        });
        
        {
            DescriptorLayoutBuilder builder = new();
            builder.AddBinding(0, VkDescriptorType.CombinedImageSampler);
            SingleTextureLayout = builder.Build(VkShaderStageFlags.Fragment);

            CleanupQueue.Add(() =>
            {
                VkApiDevice.vkDestroyDescriptorSetLayout(Device.VkDevice, SingleTextureLayout);
            });
        }

        CleanupQueue.Add(GlobalDescriptorAllocator);
        
        {
            DescriptorLayoutBuilder builder = new();
            builder.AddBinding(0, VkDescriptorType.UniformBuffer);
            SceneDataLayout = builder.Build(VkShaderStageFlags.Vertex | VkShaderStageFlags.Fragment);
            CleanupQueue.Add(() =>
            {
                VkApiDevice.vkDestroyDescriptorSetLayout(Device.VkDevice, SceneDataLayout);
            });
        }

        CreateBindlessDescriptors();
    }
    
    private void CreateBindlessDescriptors()
    {
        DescriptorLayoutBuilder builder = new();
        builder.AddBinding(0, VkDescriptorType.SampledImage, TextureCount);
        builder.AddBinding(1, VkDescriptorType.Sampler);
        var layout = builder.BuildBindless(VkShaderStageFlags.Fragment, VkDescriptorSetLayoutCreateFlags.None);

        BindlessTextureLayout = layout;
        
        /*
        VkDescriptorSetAllocateInfo allocate_info = vkb::initializers::descriptor_set_allocate_info(descriptors.descriptor_pool, &descriptors.set_layout, 1);

        // Just like descriptor flags, for each descriptor set we allocate, we can describe how large the descriptor array should be.
        VkDescriptorSetVariableDescriptorCountAllocateInfoEXT variable_info{};
        variable_info.sType              = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_ALLOCATE_INFO_EXT;
        variable_info.descriptorSetCount = 1;
        allocate_info.pNext              = &variable_info;

        variable_info.pDescriptorCounts = &NumDescriptorsStreaming;
        */
        TextureRegistryDescriptorSet = GlobalDescriptorAllocator.AllocateVariable(layout, TextureCount);
    }

    private void CreateRenderImageDescriptor()
    {
        DescriptorLayoutBuilder builder = new();
        builder.AddBinding(0, VkDescriptorType.StorageImage);
        RenderImageDescriptorLayout = builder.Build(VkShaderStageFlags.Compute | VkShaderStageFlags.Fragment);
        RenderImageDescriptorSet = GlobalDescriptorAllocator.Allocate(RenderImageDescriptorLayout);
        
        UpdateRenderImageDescriptorSet();
    }

    private void UpdateRenderImageDescriptorSet()
    {
        DescriptorWriter writer = new();
        writer.WriteImage(0, RenderImage.ImageView, null, VkImageLayout.General, VkDescriptorType.StorageImage);
        writer.UpdateSet(RenderImageDescriptorSet);
    }

    private void CreateMemoryAllocator()
    {
        new MemoryAllocator();
        CleanupQueue.Add(GlobalAllocator);
    }

    private void PrintAllExtensions()
    {
        ApiInstance.PrintAllAvailableInstanceExtensions();
        GpuInstance.PrintAllAvailableDeviceExtensions();
    }

    private void PickGpu()
    {
        GpuInstance = ApiInstance.PickGpu();
    }

    private void CreateRenderQueue()
    {
        RenderQueue = new RenderQueue();
    }
    
    private void CreateDataTransferer()
    {
        DataTransferer = new();
        CleanupQueue.Add(DataTransferer);
    }

    private void CreateApi(Window aWindow)
    {
        new Api(aWindow, Defaults.InstanceExtensions);
        CleanupQueue.Add(ApiInstance);
    }

    private void CreateSurface(Window aWindow)
    {
        MainWindowSurface = ApiInstance.CreateSurface(aWindow);
        
        CleanupQueue.Add(MainWindowSurface);
    }

    private void CreateImageViews()
    {
        ImageViews = Swapchain.CreateImageViews();

        CleanupQueue.Add(ImageViews);
    }

    private void CreateDevice()
    {
        GpuInstance.CreateDevice(Defaults.DeviceExtensions);
        CleanupQueue.Add(Device);
    }

    private void CreateFrameData()
    {
        for(int i = 0; i < FrameOverlap; i++)
        {
            FrameData newFrame = new();

            newFrame.CommandBuffer = new CommandBuffer(RenderQueue);
            newFrame.RenderFinishedSemaphore = new();
            newFrame.ImageAvailableSemaphore = new();
            newFrame.RenderFence = new();
            
            List<DescriptorAllocatorGrowable.PoolSizeRatio> sizes = new List<DescriptorAllocatorGrowable.PoolSizeRatio>
            {
                new() { Ratio = 3f, Type = VkDescriptorType.StorageImage},
                new() { Ratio = 3f, Type = VkDescriptorType.StorageBuffer},
                new() { Ratio = 3f, Type = VkDescriptorType.UniformBuffer},
                new() { Ratio = 4f, Type = VkDescriptorType.CombinedImageSampler},
            };
            newFrame.FrameDescriptors.InitPool(1000, sizes);

            FrameData.Add(newFrame);
        }

        CleanupQueue.Add(FrameData);
    }

    private void CreateSwapchain()
    {
        VkSurfaceFormatKHR surfaceFormat = GpuInstance.GetSurfaceFormat(PreferredFormat, PreferredColorSpace);
        VkPresentModeKHR presentMode = GpuInstance.GetPresentMode(PreferredPresentMode);

        Swapchain = new Swapchain(surfaceFormat, presentMode, MainWindowSurface.GetSwapbufferExtent(), MainWindowSurface);
        CleanupQueue.Add(Swapchain);
    }
    
    public void OnDestroy()
    {
        Log.Info($"Destroying renderer...");

        Device.WaitUntilIdle();
        
        CleanupQueue.Flush();
        
        Log.Info($"Renderer successfully destroyed!");
    }
}