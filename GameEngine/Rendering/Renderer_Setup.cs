global using Utilities.CommonExtensions;
using System.Drawing;
using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;
using System.Runtime.InteropServices;
using VulkanApi;
using Vortice.ShaderCompiler;

namespace Rendering;

public partial class Renderer
{
    private void Init(Window aWindow)
    {
        InitVulkan(aWindow);
    }
    
    private void InitVulkan(Window aWindow)
    {
        Console.WriteLine("Creating renderer...");
        
        CreateApi(aWindow);

        CreateSurface(aWindow);

        PickGpu();

        if (PrintExtensions)
            PrintAllExtensions();
        
        CreateDevice();

        CreateRenderQueue();

        CreateSwapchain();

        CreateImageViews();

        CreateMemoryAllocator();
        
        CreateRenderImage();

        CreateImmediateCommandBuffer();
        
        CreateFrameData();

        CreateDefaultImages();
        
        InitializeDescriptors();

        InitializePipelines();
        
        CreateMonke();
        
        Console.WriteLine("Renderer successfully created!");
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

        myWhiteImage = new Image(this, (byte*)&whitePacked, VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled, new VkExtent3D(1, 1, 1), false);
        myBlackImage = new Image(this, (byte*)&blackPacked, VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled, new VkExtent3D(1, 1, 1), false);
        myGreyImage = new Image(this, (byte*)&greyPacked, VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled, new VkExtent3D(1, 1, 1), false);
        myCheckerBoardImage = new Image(this, (byte*)checkerboard.AsSpan().GetPointerUnsafe(), VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled, new VkExtent3D(16, 16, 1), false);

        myDefaultLinearSampler = new(VkFilter.Linear);
        myDefaultNearestSampler = new(VkFilter.Nearest);
        
        myCleanupQueue.Add(myWhiteImage);
        myCleanupQueue.Add(myBlackImage);
        myCleanupQueue.Add(myGreyImage);
        myCleanupQueue.Add(myCheckerBoardImage);
        myCleanupQueue.Add(myDefaultLinearSampler);
        myCleanupQueue.Add(myDefaultNearestSampler);
    }

    private void Resize()
    {
        Device.WaitUntilIdle();

        myCleanupQueue.RunDeletor(mySwapchain);
        myCleanupQueue.RunDeletor(myRenderImage);
        myCleanupQueue.RunDeletor(myDepthImage);
        
        foreach (var imageView in myImageViews)
            myCleanupQueue.RunDeletor(imageView);

        myImageViews.Clear();
        
        CreateSwapchain();
        CreateImageViews();
        CreateRenderImage();
        UpdateRenderImageDescriptorSet();
    }

    private void CreateMonke()
    {
        myMeshes = Mesh.LoadGltf(this, "Models/basicmesh.glb").ToArray();
        myCleanupQueue.Add(myMeshes.ToList());
    }

    private void CreateImmediateCommandBuffer()
    {
        myImmediateFence = new();
        myImmediateCommandBuffer = new(myRenderQueue);
        myCleanupQueue.Add(myImmediateFence);
        myCleanupQueue.Add(myImmediateCommandBuffer);
    }

    private void InitializePipelines()
    {
        InitializeBackgroundPipelines();

        InitializeMeshTrianglePipeline();
    }

    private void InitializeMeshTrianglePipeline()
    {
        myTrianglePipeline = GraphicsPipeline
            .StartBuild()
            .AddPushConstant<MeshPushConstants>(VkShaderStageFlags.Vertex)
            .AddLayout(mySingleTextureLayout)
            .SetVertexShader("Shaders/vert.spv")
            .SetFragmentShader("Shaders/frag.spv")
            .SetTopology(VkPrimitiveTopology.TriangleList)
            .SetPolygonMode(VkPolygonMode.Fill)
            .SetCullMode(VkCullModeFlags.None, VkFrontFace.Clockwise)
            .DisableMultisampling()
            .EnableDepthTest()
            .SetBlendMode(BlendMode.Alpha)
            .SetColorAttachmentFormat(myRenderImage.MyImageFormat)
            .SetDepthFormat(VkFormat.D32Sfloat)
            .Build();

        myCleanupQueue.Add(myTrianglePipeline);
    }

    private void InitializeBackgroundPipelines()
    {
        myGradientPipeline = ComputePipeline.StartBuild().SetComputeShader("Shaders/comp.spv").AddLayout(myRenderImageDescriptorLayout).AddPushConstant<PushConstants>().Build();
        myCleanupQueue.Add(myGradientPipeline);
    }

    private void CreateRenderImage()
    {
         myRenderImage = new Image(VkFormat.R16G16B16A16Sfloat, VkImageUsageFlags.Storage | VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst | VkImageUsageFlags.TransferSrc, new VkExtent3D(mySwapchain.MyExtents.width, mySwapchain.MyExtents.height, 1), false);
         myCleanupQueue.Add(myRenderImage);
         
         myDepthImage = new Image(VkFormat.D32Sfloat, VkImageUsageFlags.DepthStencilAttachment, new VkExtent3D(mySwapchain.MyExtents.width, mySwapchain.MyExtents.height, 1), false);
         myCleanupQueue.Add(myDepthImage);
    }

    private unsafe void InitializeDescriptors()
    {
        List<DescriptorAllocatorGrowable.PoolSizeRatio> sizes = new List<DescriptorAllocatorGrowable.PoolSizeRatio>
        {
            new() { Ratio = 1f, Type = VkDescriptorType.StorageImage},
            new() { Ratio = 1f, Type = VkDescriptorType.CombinedImageSampler},
        };

        myGlobalDescriptorAllocator = new();
        myGlobalDescriptorAllocator.InitPool(10, sizes);

        CreateRenderImageDescriptor();

        myCleanupQueue.Add(() =>
        {
            vkDestroyDescriptorSetLayout(Device.MyVkDevice, myRenderImageDescriptorLayout);
        });
        
        {
            DescriptorLayoutBuilder builder = new();
            builder.AddBinding(0, VkDescriptorType.CombinedImageSampler);
            mySingleTextureLayout = builder.Build(VkShaderStageFlags.Fragment);

            myCleanupQueue.Add(() =>
            {
                vkDestroyDescriptorSetLayout(Device.MyVkDevice, mySingleTextureLayout);
            });
        }

        myCleanupQueue.Add(myGlobalDescriptorAllocator);
        
        {
            DescriptorLayoutBuilder builder = new();
            builder.AddBinding(0, VkDescriptorType.UniformBuffer);
            mySceneDataLayout = builder.Build(VkShaderStageFlags.Vertex | VkShaderStageFlags.Fragment);
            myCleanupQueue.Add(() =>
            {
                vkDestroyDescriptorSetLayout(Device.MyVkDevice, mySceneDataLayout);
            });
        }
        
    }

    private void CreateRenderImageDescriptor()
    {
        DescriptorLayoutBuilder builder = new();
        builder.AddBinding(0, VkDescriptorType.StorageImage);
        myRenderImageDescriptorLayout = builder.Build(VkShaderStageFlags.Compute | VkShaderStageFlags.Fragment);
        myRenderImageDescriptorSet = myGlobalDescriptorAllocator.Allocate(myRenderImageDescriptorLayout);
        
        UpdateRenderImageDescriptorSet();
    }

    private void UpdateRenderImageDescriptorSet()
    {
        DescriptorWriter writer = new();
        writer.WriteImage(0, myRenderImage.MyImageView, null, VkImageLayout.General, VkDescriptorType.StorageImage);
        writer.UpdateSet(myRenderImageDescriptorSet);
    }

    private void CreateMemoryAllocator()
    {
        new MemoryAllocator();
        myCleanupQueue.Add(GlobalAllocator);
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
        myRenderQueue = new RenderQueue();
    }

    private void CreateApi(Window aWindow)
    {
        new Api(aWindow, Defaults.InstanceExtensions);
        myCleanupQueue.Add(ApiInstance);
    }

    private void CreateSurface(Window aWindow)
    {
        MainWindowSurface = ApiInstance.CreateSurface(aWindow);
        
        myCleanupQueue.Add(MainWindowSurface);
    }

    private void CreateImageViews()
    {
        myImageViews = mySwapchain.CreateImageViews();

        myCleanupQueue.Add(myImageViews);
    }

    private void CreateDevice()
    {
        GpuInstance.CreateDevice(Defaults.DeviceExtensions);
        myCleanupQueue.Add(Device);
    }

    private void CreateFrameData()
    {
        for(int i = 0; i < FrameOverlap; i++)
        {
            FrameData newFrame = new();

            newFrame.MyCommandBuffer = new CommandBuffer(myRenderQueue);
            newFrame.MyRenderFinishedSemaphore = new();
            newFrame.MyImageAvailableSemaphore = new();
            newFrame.MyRenderFence = new();
            
            List<DescriptorAllocatorGrowable.PoolSizeRatio> sizes = new List<DescriptorAllocatorGrowable.PoolSizeRatio>
            {
                new() { Ratio = 3f, Type = VkDescriptorType.StorageImage},
                new() { Ratio = 3f, Type = VkDescriptorType.StorageBuffer},
                new() { Ratio = 3f, Type = VkDescriptorType.UniformBuffer},
                new() { Ratio = 4f, Type = VkDescriptorType.CombinedImageSampler},
            };
            newFrame.MyFrameDescriptors.InitPool(1000, sizes);

            myFrameData.Add(newFrame);
        }

        myCleanupQueue.Add(myFrameData);
    }

    private void CreateSwapchain()
    {
        VkSurfaceFormatKHR surfaceFormat = GpuInstance.GetSurfaceFormat(PreferredFormat, PreferredColorSpace);
        VkPresentModeKHR presentMode = GpuInstance.GetPresentMode(PreferredPresentMode);

        mySwapchain = new Swapchain(surfaceFormat, presentMode, MainWindowSurface.GetSwapbufferExtent(), MainWindowSurface);
        myCleanupQueue.Add(mySwapchain);
    }
    
    public void Cleanup()
    {
        Console.WriteLine("Destroying renderer...");

        Device.WaitUntilIdle();
        
        myCleanupQueue.Flush();
        
        Console.WriteLine("Renderer successfully destroyed!");
    }
}