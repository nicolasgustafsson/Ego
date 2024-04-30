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
        
        CreateFrameData();

        InitializeDescriptors();

        InitializePipelines();
        
        Console.WriteLine("Renderer successfully created!");
    }

    private void InitializePipelines()
    {
        InitializeBackgroundPipelines();
    }

    private unsafe void InitializeBackgroundPipelines()
    {
        VkPipelineLayoutCreateInfo computeLayout = new();
        
        fixed(VkDescriptorSetLayout* pLayout = &myDrawImageDescriptorLayout)
        {
            computeLayout.pSetLayouts = pLayout;
        }

        computeLayout.setLayoutCount = 1;

        VkPushConstantRange pushConstantRange = new();
        pushConstantRange.offset = 0;
        pushConstantRange.size = (uint)sizeof(PushConstants);
        pushConstantRange.stageFlags = VkShaderStageFlags.Compute;
        
        computeLayout.pPushConstantRanges = &pushConstantRange;
        computeLayout.pushConstantRangeCount = 1;

        vkCreatePipelineLayout(myDevice.MyVkDevice, &computeLayout, null, out myGradientPipelineLayout);

        ShaderModule? computeDrawShader = ShaderModule.Load("Shaders/comp.spv", myDevice);
        
        if (computeDrawShader == null)
        {
            Console.WriteLine("Could not create shader!");
            return;
        }

        VkPipelineShaderStageCreateInfo stageInfo = new();
        stageInfo.stage = VkShaderStageFlags.Compute;
        stageInfo.module = computeDrawShader.MyModule;
        stageInfo.pName = "main".ToSPointer();

        VkComputePipelineCreateInfo computePipelineCreateInfo = new();
        computePipelineCreateInfo.layout = myGradientPipelineLayout;
        computePipelineCreateInfo.stage = stageInfo;

        VkPipeline pipeline;
        vkCreateComputePipelines(myDevice.MyVkDevice, Vortice.Vulkan.VkPipelineCache.Null, computePipelineCreateInfo, &pipeline);

        myGradientPipeline = pipeline;

        computeDrawShader.Destroy(myDevice);

        myCleanupQueue.Add(() =>
        {
            vkDestroyPipelineLayout(myDevice.MyVkDevice, myGradientPipelineLayout);
            vkDestroyPipeline(myDevice.MyVkDevice, myGradientPipeline);
        });
    }

    private void CreateDrawImage()
    {
         myDrawImage = new Image(myDevice, myMemoryAllocator, VkFormat.R16G16B16A16Sfloat, VkImageUsageFlags.Storage | VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst | VkImageUsageFlags.TransferSrc, new VkExtent3D(mySwapchain.MyExtents.width, mySwapchain.MyExtents.height, 1));
         myCleanupQueue.Add(() => { myDrawImage.Destroy(myDevice, myMemoryAllocator); });
    }

    private unsafe void InitializeDescriptors()
    {
        List<DescriptorAllocator.PoolSizeRatio> sizes = new List<DescriptorAllocator.PoolSizeRatio> { new() { Ratio = 1f, Type = VkDescriptorType.StorageImage} };

        myGlobalDescriptorAllocator = new();
        myGlobalDescriptorAllocator.InitPool(myDevice, 10, sizes);

        DescriptorLayoutBuilder builder = new();
        builder.AddBinding(0, VkDescriptorType.StorageImage);
        myDrawImageDescriptorLayout = builder.Build(myDevice, VkShaderStageFlags.Compute);

        myDrawImageDescriptors = myGlobalDescriptorAllocator.Allocate(myDevice, myDrawImageDescriptorLayout);

        VkDescriptorImageInfo imageInfo = new();
        imageInfo.imageLayout = VkImageLayout.General;
        imageInfo.imageView = myDrawImage.MyImageView.MyVkImageView;

        VkWriteDescriptorSet drawImageWrite = new();
        drawImageWrite.dstBinding = 0;
        drawImageWrite.dstSet = myDrawImageDescriptors;
        drawImageWrite.descriptorCount = 1;
        drawImageWrite.descriptorType = VkDescriptorType.StorageImage;
        drawImageWrite.pImageInfo = &imageInfo;

        vkUpdateDescriptorSets(myDevice.MyVkDevice, 1, &drawImageWrite, 0, null);

        myCleanupQueue.Add(() =>
        {
            vkDestroyDescriptorSetLayout(myDevice.MyVkDevice, myDrawImageDescriptorLayout);
            myGlobalDescriptorAllocator.DestroyPool(myDevice);
        });
    }

    private void CreateMemoryAllocator()
    {
        myMemoryAllocator = new MemoryAllocator(myGpu, myDevice, myApi);
        myCleanupQueue.Add(() => myMemoryAllocator.Destroy());
    }

    private void PrintAllExtensions()
    {
        myApi.PrintAllAvailableInstanceExtensions();
        myGpu.PrintAllAvailableDeviceExtensions();
    }

    private void PickGpu()
    {
        myGpu = myApi.PickGpu(mySurface);
    }

    private void CreateDrawQueue()
    {
        myDrawQueue = new DrawQueue(myDevice, myGpu);
    }

    private void CreateApi(Window aWindow)
    {
        myApi = new(aWindow, Defaults.InstanceExtensions);
        myCleanupQueue.Add(() => myApi.Destroy());
    }

    private void CreateSurface(Window aWindow)
    {
        mySurface = myApi.CreateSurface(aWindow);
        myCleanupQueue.Add(() => mySurface.Destroy(myApi));
    }

    private void CreateImageViews()
    {
        myImageViews = mySwapchain.CreateImageViews(myDevice);

        myCleanupQueue.Add(() =>
        {
            foreach (var imageView in myImageViews)
                imageView.Destroy(myDevice);

            myImageViews.Clear();
        });
    }

    private void CreateDevice()
    {
        myDevice = myGpu.CreateDevice(Defaults.DeviceExtensions);
        myCleanupQueue.Add(() => myDevice.Destroy());
    }

    private void CreateFrameData()
    {
        for(int i = 0; i < FrameOverlap; i++)
        {
            FrameData newFrame = new();

            newFrame.MyCommandBuffer = new CommandBuffer(myDevice, myDrawQueue);
            newFrame.MyRenderFinishedSemaphore = new(myDevice);
            newFrame.MyImageAvailableSemaphore = new(myDevice);
            newFrame.MyRenderFence = new(myDevice);

            myFrameData.Add(newFrame);
        }

        myCleanupQueue.Add(() =>
        {
            foreach (FrameData frameData in myFrameData)
                frameData.Destroy(myDevice, myMemoryAllocator);

            myFrameData.Clear();
        });
    }

    private void CreateSwapchain()
    {
        VkSurfaceFormatKHR surfaceFormat = myGpu.GetSurfaceFormat(mySurface, PreferredFormat, PreferredColorSpace);
        VkPresentModeKHR presentMode = myGpu.GetPresentMode(mySurface, PreferredPresentMode);

        mySwapchain = new Swapchain(myDevice, myGpu, mySurface, surfaceFormat, presentMode);
        myCleanupQueue.Add(() => mySwapchain.Destroy(myDevice));
    }
    
    public void Cleanup()
    {
        Console.WriteLine("Destroying renderer...");

        myDevice.WaitUntilIdle();
        
        myCleanupQueue.Flush();
        
        Console.WriteLine("Renderer successfully destroyed!");
    }
}