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
        
        myApi = new(aWindow, Defaults.InstanceExtensions);

        if (PrintExtensions)
            myApi.PrintAllAvailableInstanceExtensions();

        mySurface = myApi.CreateSurface(aWindow);

        myGpu = myApi.PickGpu(mySurface);

        if (PrintExtensions)
            myGpu.PrintAllAvailableDeviceExtensions();

        myDevice = myGpu.CreateDevice(mySurface, Defaults.DeviceExtensions);

        myDrawQueue = new(myDevice, myGpu);

        CreateSwapchain();

        myImageViews = mySwapchain.CreateImageViews(myDevice);

        CreateFrameData();
        
        Console.WriteLine("Renderer successfully created!");
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
    }

    private void CreateSwapchain()
    {
        VkSurfaceFormatKHR surfaceFormat = myGpu.GetSurfaceFormat(mySurface, PreferredFormat, PreferredColorSpace);
        VkPresentModeKHR presentMode = myGpu.GetPresentMode(mySurface, PreferredPresentMode);

        mySwapchain = new Swapchain(myDevice, myGpu, mySurface, surfaceFormat, presentMode);
    }
    
    public void Cleanup()
    {
        Console.WriteLine("Destroying renderer...");

        myDevice.WaitUntilIdle();
        
        foreach (var frameData in myFrameData)
        {
            frameData.MyCommandBuffer.Destroy(myDevice);
            frameData.MyImageAvailableSemaphore.Destroy(myDevice);
            frameData.MyRenderFinishedSemaphore.Destroy(myDevice);
            frameData.MyRenderFence.Destroy(myDevice);
        }

        myFrameData.Clear();

        foreach (var imageView in myImageViews)
            imageView.Destroy(myDevice);
        
        myImageViews.Clear();

        mySwapchain.Destroy(myDevice);
        
        mySurface.Destroy(myApi);

        myDevice.DestroySelf();

        myApi.Destroy();
        
        Console.WriteLine("Renderer successfully destroyed!");
    }
}