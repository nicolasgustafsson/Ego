global using Utilities.CommonExtensions;
using Vortice.Vulkan;
using static Vortice.Vulkan.Vulkan;
using System.Runtime.InteropServices;
using Graphics;

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

        CreateDrawQueue();

        CreateSwapchain();

        CreateImageViews();

        CreateMemoryAllocator();
        
        CreateDrawImage();

        CreateImmediateCommandBuffer();
        
        CreateFrameData();

        InitializeDescriptors();

        InitializePipelines();
        
        CreateImGui(aWindow);

        CreateMonke();
        
        Console.WriteLine("Renderer successfully created!");
    }
    
    private void Resize()
    {
        Device.WaitUntilIdle();

        myCleanupQueue.RunDeletor(mySwapchain);
        myCleanupQueue.RunDeletor(myDrawImage);
        myCleanupQueue.RunDeletor(myDepthImage);
        
        foreach (var imageView in myImageViews)
            myCleanupQueue.RunDeletor(imageView);

        myImageViews.Clear();
        
        CreateSwapchain();
        CreateImageViews();
        CreateDrawImage();
        UpdateDrawImageDescriptorSet();
    }

    private void CreateMonke()
    {
        myMeshes = Mesh.LoadGltf(this, "Models/basicmesh.glb").ToArray();
        myCleanupQueue.Add(myMeshes.ToList());
    }

    private void CreateImGui(Window aWindow)
    {
        //myImGuiContext = new(this, aWindow);
    }

    private void CreateImmediateCommandBuffer()
    {
        myImmediateFence = new();
        myImmediateCommandBuffer = new(myDrawQueue);
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
            .AddLayout(myDrawImageDescriptorLayout)
            .SetVertexShader("Shaders/vert.spv")
            .SetFragmentShader("Shaders/frag.spv")
            .SetTopology(VkPrimitiveTopology.TriangleList)
            .SetPolygonMode(VkPolygonMode.Fill)
            .SetCullMode(VkCullModeFlags.None, VkFrontFace.Clockwise)
            .DisableMultisampling()
            .EnableDepthTest()
            .SetBlendMode(BlendMode.Alpha)
            .SetColorAttachmentFormat(myDrawImage.MyImageFormat)
            .SetDepthFormat(VkFormat.D32Sfloat)
            .Build();

        myCleanupQueue.Add(myTrianglePipeline);
    }

    private void InitializeBackgroundPipelines()
    {
        myGradientPipeline = ComputePipeline.StartBuild().SetComputeShader("Shaders/comp.spv").AddLayout(myDrawImageDescriptorLayout).AddPushConstant<PushConstants>().Build();
        myCleanupQueue.Add(myGradientPipeline);
    }

    private void CreateDrawImage()
    {
         myDrawImage = new Image(VkFormat.R16G16B16A16Sfloat, VkImageUsageFlags.Storage | VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst | VkImageUsageFlags.TransferSrc, new VkExtent3D(mySwapchain.MyExtents.width, mySwapchain.MyExtents.height, 1));
         myCleanupQueue.Add(myDrawImage);
         
         myDepthImage = new Image(VkFormat.D32Sfloat, VkImageUsageFlags.DepthStencilAttachment, new VkExtent3D(mySwapchain.MyExtents.width, mySwapchain.MyExtents.height, 1));
         myCleanupQueue.Add(myDepthImage);
    }

    private unsafe void InitializeDescriptors()
    {
        List<DescriptorAllocator.PoolSizeRatio> sizes = new List<DescriptorAllocator.PoolSizeRatio>
        {
            new() { Ratio = 1f, Type = VkDescriptorType.StorageImage},
            new() { Ratio = 1f, Type = VkDescriptorType.CombinedImageSampler},
        };

        myGlobalDescriptorAllocator = new();
        myGlobalDescriptorAllocator.InitPool(10, sizes);

        CreateDrawImageDescriptor();

        myCleanupQueue.Add(() =>
        {
            vkDestroyDescriptorSetLayout(Device.MyVkDevice, myDrawImageDescriptorLayout);
        });

        myCleanupQueue.Add(myGlobalDescriptorAllocator);
    }

    private void CreateDrawImageDescriptor()
    {
        DescriptorLayoutBuilder builder = new();
        builder.AddBinding(0, VkDescriptorType.StorageImage);
        myDrawImageDescriptorLayout = builder.Build(VkShaderStageFlags.Compute | VkShaderStageFlags.Fragment);
        myDrawImageDescriptorSet = myGlobalDescriptorAllocator.Allocate(myDrawImageDescriptorLayout);
        
        UpdateDrawImageDescriptorSet();
    }

    private unsafe void UpdateDrawImageDescriptorSet()
    {
        VkDescriptorImageInfo imageInfo = new();
        imageInfo.imageLayout = VkImageLayout.General;
        imageInfo.imageView = myDrawImage.MyImageView.MyVkImageView;

        VkWriteDescriptorSet drawImageWrite = new();
        drawImageWrite.dstBinding = 0;
        drawImageWrite.dstSet = myDrawImageDescriptorSet;
        drawImageWrite.descriptorCount = 1;
        drawImageWrite.descriptorType = VkDescriptorType.StorageImage;
        drawImageWrite.pImageInfo = &imageInfo;

        vkUpdateDescriptorSets(Device.MyVkDevice, 1, &drawImageWrite, 0, null);
    }

    private void CreateMemoryAllocator()
    {
        new MemoryAllocator();
        myCleanupQueue.Add(GlobalAllocator);
    }

    private void PrintAllExtensions()
    {
        VulkanApi.PrintAllAvailableInstanceExtensions();
        GpuInstance.PrintAllAvailableDeviceExtensions();
    }

    private void PickGpu()
    {
        GpuInstance = VulkanApi.PickGpu();
    }

    private void CreateDrawQueue()
    {
        myDrawQueue = new DrawQueue(GpuInstance);
    }

    private void CreateApi(Window aWindow)
    {
        new Api(aWindow, Defaults.InstanceExtensions);
        myCleanupQueue.Add(VulkanApi);
    }

    private void CreateSurface(Window aWindow)
    {
        VulkanApi.CreateSurface(aWindow);
        myCleanupQueue.Add(WindowSurface);
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

            newFrame.MyCommandBuffer = new CommandBuffer(myDrawQueue);
            newFrame.MyRenderFinishedSemaphore = new();
            newFrame.MyImageAvailableSemaphore = new();
            newFrame.MyRenderFence = new();

            myFrameData.Add(newFrame);
        }

        myCleanupQueue.Add(myFrameData);
    }

    private void CreateSwapchain()
    {
        VkSurfaceFormatKHR surfaceFormat = GpuInstance.GetSurfaceFormat(PreferredFormat, PreferredColorSpace);
        VkPresentModeKHR presentMode = GpuInstance.GetPresentMode(PreferredPresentMode);

        mySwapchain = new Swapchain(surfaceFormat, presentMode);
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