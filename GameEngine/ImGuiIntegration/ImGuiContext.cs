global using VkDeviceAddress = ulong;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GLFW;
using VulkanApi;
using ImGuiNET;
using Platform;
using Utilities.Interop;
using Vortice.Vulkan;
using Image = VulkanApi.Image;
using Vulkan = Vortice.Vulkan.Vulkan;

namespace Rendering;

public class ImGuiContext : IGpuDestroyable
{
    class PlatformUserData
    {
        public GLFW.Cursor StandardCursor;
        public GLFW.Cursor TextInputCursor;
        public GLFW.Cursor ResizeNS;
        public GLFW.Cursor ResizeEW;
        public GLFW.Cursor Hand;

        public bool WantUpdateMonitors = false;
    }
    
    class WindowUserData
    {
        public Window Window;
        public Surface? Surface = null;
        public Swapchain? Swapchain = null;
        public List<ImageView>? ImageViews = null;
        public RenderQueue? RenderQueue = null;

        public WindowUserData(Window aWindow)
        {
            Window = aWindow;
        }

        public Image? RenderImage { get; set; }
        public Image? DepthImage { get; set; }
        public List<FrameData>? FrameData { get; set; }

        public int FrameNumber = 0;
        public FrameData CurrentFrame => FrameData![(int)(FrameNumber % 2)];
        public bool WantsResize = false;
    }
    
    private Image myFontTexture;
    private DescriptorAllocatorGrowable myDescriptorAllocator;
    private VkDescriptorSetLayout myLayout;

    //We don't ever actually remove descriptors - this could be a problem in the future
    private Dictionary<nint, VkDescriptorSet> myImageDescriptors = new();
    private Sampler mySampler;
    private GraphicsPipeline myPipeline;
    private Window myMainWindow;
    private List<Window> myAdditionalWindows = new();
    private Dictionary<System.Guid, WindowUserData> myWindowUserDatas = new();

    private List<AllocatedBuffer<ImDrawVertCorrected>> myOldVBuffers = new();
    private List<AllocatedBuffer<ushort>> myOldIBuffers = new();
    private VkDescriptorSetLayout myVertexBufferLayout;
    private VkDescriptorSetLayout myIndexBufferLayout;
    private readonly Platform_CreateWindow _createWindow;
    private readonly Platform_DestroyWindow _destroyWindow;
    private readonly Platform_GetWindowPos _getWindowPos;
    private readonly Platform_ShowWindow _showWindow;
    private readonly Platform_SetWindowPos _setWindowPos;
    private readonly Platform_SetWindowSize _setWindowSize;
    private readonly Platform_GetWindowSize _getWindowSize;
    private readonly Platform_SetWindowFocus _setWindowFocus;
    private readonly Platform_GetWindowFocus _getWindowFocus;
    private readonly Platform_GetWindowMinimized _getWindowMinimized;
    private readonly Platform_SetWindowTitle _setWindowTitle; 
    
    private Stopwatch myStopwatch = new();
    private PlatformUserData myPlatformUserData = new();

    public unsafe ImGuiContext(Renderer aRenderer, Window aMainWindow)
    {
        myStopwatch.Start();
        myMainWindow = aMainWindow;
        
        var context = ImGui.CreateContext();
        ImGui.SetCurrentContext(context);

        var io = ImGui.GetIO();

        io.ConfigFlags = ImGuiConfigFlags.DockingEnable | ImGuiConfigFlags.ViewportsEnable;
        io.Fonts.AddFontDefault();
        
        io.Fonts.GetTexDataAsRGBA32(out nint pixels, out var width, out var height);
        
        myFontTexture = new Image(aRenderer, (byte*)pixels.ToPointer(), VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled | VkImageUsageFlags.TransferDst, new VkExtent3D(width, height, 1), false);
        myDescriptorAllocator = new DescriptorAllocatorGrowable();
        myDescriptorAllocator.InitPool(100, [new(ratio: 1000, type: VkDescriptorType.CombinedImageSampler)]);
        
        mySampler = new(VkFilter.Linear);

        DescriptorLayoutBuilder layoutBuilder = new();
        layoutBuilder.AddBinding(0, VkDescriptorType.CombinedImageSampler);
        myLayout = layoutBuilder.Build(VkShaderStageFlags.Fragment);

        AddTexture(myFontTexture);

        io.Fonts.SetTexID(myFontTexture.GetHandle());
        
        myPipeline = new GraphicsPipeline.GraphicsPipelineBuilder()
            .AddPushConstant(new VkPushConstantRange { offset = 0, size = sizeof(float) * 4 + sizeof(VkDeviceAddress), stageFlags = VkShaderStageFlags.Vertex })
            .AddLayout(myLayout)
            .SetBlendMode(BlendMode.Alpha)
            .DisableMultisampling()
            .SetVertexShader("Shaders/imguiVert.spv")
            .SetFragmentShader("Shaders/imguiFrag.spv")
            .SetTopology(VkPrimitiveTopology.TriangleList)
            .SetPolygonMode(VkPolygonMode.Fill)
            .DisableDepthTest()
            .SetDepthFormat(VkFormat.D32Sfloat)
            .Build();

        SetFrameData();
        
        aMainWindow.EKeyboardKey += KeyDown;
        aMainWindow.ECharInput += CharInput;
        aMainWindow.EMouseScrolled += MouseScroll;
        aMainWindow.EMouseButton += MouseButton;
        aMainWindow.EMousePosition += MousePosition;

        ImGuiPlatformIOPtr platformIo = ImGui.GetPlatformIO();

        _createWindow = CreateWindow;
        _destroyWindow = DestroyWindow;
        _getWindowPos = GetWindowPos;
        _showWindow = ShowWindow;
        _setWindowPos = SetWindowPos;
        _setWindowSize = SetWindowSize;
        _getWindowSize = GetWindowSize;
        _setWindowFocus = SetWindowFocus;
        _getWindowFocus = GetWindowFocus;
        _getWindowMinimized = GetWindowMinimized;
        _setWindowTitle = SetWindowTitle;
        io.BackendFlags |= ImGuiBackendFlags.HasMouseCursors;
        io.BackendFlags |= ImGuiBackendFlags.HasSetMousePos;
        io.BackendFlags |= ImGuiBackendFlags.PlatformHasViewports;
        io.BackendFlags |= ImGuiBackendFlags.RendererHasViewports; 
        
        platformIo.Platform_CreateWindow = Marshal.GetFunctionPointerForDelegate(_createWindow);
        platformIo.Platform_DestroyWindow = Marshal.GetFunctionPointerForDelegate(_destroyWindow);
        platformIo.Platform_ShowWindow = Marshal.GetFunctionPointerForDelegate(_showWindow);
        platformIo.Platform_SetWindowPos = Marshal.GetFunctionPointerForDelegate(_setWindowPos);
        platformIo.Platform_SetWindowSize = Marshal.GetFunctionPointerForDelegate(_setWindowSize);
        platformIo.Platform_SetWindowFocus = Marshal.GetFunctionPointerForDelegate(_setWindowFocus);
        platformIo.Platform_GetWindowFocus = Marshal.GetFunctionPointerForDelegate(_getWindowFocus);
        platformIo.Platform_GetWindowMinimized = Marshal.GetFunctionPointerForDelegate(_getWindowMinimized);
        platformIo.Platform_GetWindowMinimized = Marshal.GetFunctionPointerForDelegate(_getWindowMinimized);
        platformIo.Platform_SetWindowTitle = Marshal.GetFunctionPointerForDelegate(_setWindowTitle);
        
        //I'm not sure why this is needed, but otherwise we get garbage parameters. Copied from the sample program(docking branch)
        ImGuiNative.ImGuiPlatformIO_Set_Platform_GetWindowPos(platformIo.NativePtr, Marshal.GetFunctionPointerForDelegate(_getWindowPos));
        ImGuiNative.ImGuiPlatformIO_Set_Platform_GetWindowSize(platformIo.NativePtr, Marshal.GetFunctionPointerForDelegate(_getWindowSize));
        
        GCHandle handle = GCHandle.Alloc(myPlatformUserData, GCHandleType.Pinned);
        io.BackendPlatformUserData = GCHandle.ToIntPtr(handle);
        
        myPlatformUserData.StandardCursor = GLFW.Glfw.CreateStandardCursor(GLFW.CursorType.Arrow);
        myPlatformUserData.TextInputCursor = GLFW.Glfw.CreateStandardCursor(GLFW.CursorType.Beam);
        myPlatformUserData.ResizeEW = GLFW.Glfw.CreateStandardCursor(GLFW.CursorType.ResizeHorizontal);
        myPlatformUserData.ResizeNS = GLFW.Glfw.CreateStandardCursor(GLFW.CursorType.ResizeVertical);
        myPlatformUserData.Hand = GLFW.Glfw.CreateStandardCursor(GLFW.CursorType.Hand);

        ImGuiViewportPtr mainViewPort = ImGui.GetMainViewport();
        
        myAdditionalWindows.Add(aMainWindow);
        UpdateMonitors();

        mainViewPort.PlatformUserData = GCHandle.ToIntPtr(CreateNewWindowUserData(aMainWindow).Pin());
        
        aRenderer.ERenderImgui += Render;
        aRenderer.EPostRender += RenderOtherWindows;
    }
    
    private VkDescriptorSet AddTexture(Image aImage)
    {
        var newDescriptorSet = myDescriptorAllocator.Allocate(myLayout);
        
        {
            DescriptorWriter writer = new();
            writer.WriteImage(0, aImage.MyImageView, mySampler, VkImageLayout.ShaderReadOnlyOptimal, VkDescriptorType.CombinedImageSampler);
            writer.UpdateSet(newDescriptorSet);
        }
        myImageDescriptors.Add(aImage.GetHandle(), newDescriptorSet);

        return newDescriptorSet;
    }
    
    private VkDescriptorSet GetOrAddDescriptor(nint aImage)
    {
        return GetOrAddDescriptor(ImageRegistry.PointersToImages[aImage]);
    }
    
    private VkDescriptorSet GetOrAddDescriptor(Image aImage)
    {
        if (myImageDescriptors.TryGetValue(aImage.GetHandle(), out var descriptorSet))
        {
            return descriptorSet;
        }

        return AddTexture(aImage);
    }
    
    private System.Guid CreateNewWindowUserData(Window aWindow)
    {
        Guid guid = System.Guid.NewGuid();
        myWindowUserDatas.Add(guid, new WindowUserData(aWindow));
        return guid;
    }

    private void MousePosition(Window aWindow, Vector2 aNewPosition)
    {
        var io = ImGui.GetIO();
        var windowPosition = aWindow.GetWindowPosition();
        
        aNewPosition += new Vector2(windowPosition.x, windowPosition.y);
        
        io.AddMousePosEvent(aNewPosition.X, aNewPosition.Y);
    }

    private void MouseButton(Window aWindow, MouseButton aMouseButton, InputState aInputState)
    {
        var io = ImGui.GetIO();
        if (aInputState == InputState.Repeat)
            return;
        
        io.AddMouseButtonEvent((int)aMouseButton.AsImGuiMouseButton(), aInputState == InputState.Press);
    }

    private void MouseScroll(Window aWindow, Vector2 aScroll)
    {
        var io = ImGui.GetIO();

        io.AddMouseWheelEvent(aScroll.X, aScroll.Y);
    }

    void CharInput(Window aWindow, uint aCharInput)
    {
        var io = ImGui.GetIO();
        
        io.AddInputCharacter(aCharInput);
    }

    private void KeyDown(Window aWindow, KeyboardKey aKey, InputState aInputState)
    {
        if (aInputState == InputState.Repeat)
            return;
        
        var io = ImGui.GetIO();
        
        io.AddKeyEvent(aKey.AsImGuiKey(), aInputState == InputState.Press);
        
    }
    
    private void SetFrameData()
    {
        var io = ImGui.GetIO();

        Vector2 windowSize = new Vector2{X = myMainWindow.GetWindowSize().width, Y = myMainWindow.GetWindowSize().height};
        Vector2 framebufferSize = new Vector2{X = myMainWindow.GetFramebufferSize().width, Y = myMainWindow.GetFramebufferSize().height};
        
        io.DisplaySize = new Vector2(myMainWindow.GetFramebufferSize().width, myMainWindow.GetFramebufferSize().height);
        if (windowSize is {X: > 0, Y: > 0})
            io.DisplayFramebufferScale = new Vector2(framebufferSize.X / (float) windowSize.X,
                framebufferSize.Y / (float) windowSize.Y);
        
        io.DeltaTime = (float)myStopwatch.Elapsed.TotalSeconds;
        myStopwatch.Restart();
    } 
    
    private unsafe void UpdateMonitors()
    {
        var platformIo = ImGui.GetPlatformIO();
        myPlatformUserData.WantUpdateMonitors = false;

        Marshal.FreeHGlobal(platformIo.NativePtr->Monitors.Data);

        int monitorCount = Glfw.Monitors.Length;
        IntPtr data = Marshal.AllocHGlobal(Unsafe.SizeOf<ImGuiPlatformMonitor>() * Glfw.Monitors.Length);
        platformIo.NativePtr->Monitors = new ImVector(monitorCount, monitorCount, data);
        
        for(int i = 0; i < monitorCount; i++)
        {
            var glfwMonitor = Glfw.Monitors[i];
            Glfw.GetMonitorPosition(glfwMonitor, out int x, out int y);
            var videoMode = Glfw.GetVideoMode(glfwMonitor);
            ImGuiPlatformMonitorPtr monitorPtr = platformIo.Monitors[i];

            monitorPtr.MainPos = monitorPtr.WorkPos = new Vector2(x, y);
            monitorPtr.MainSize = monitorPtr.WorkSize = new Vector2(videoMode.Width, videoMode.Height);

            PointF contentScale = glfwMonitor.ContentScale;
            monitorPtr.DpiScale = contentScale.X;
            monitorPtr.PlatformHandle = glfwMonitor.GetHandle();
        }
    }
   
    private void CreateWindow(ImGuiViewportPtr vp)
    {
        Glfw.WindowHint(Hint.Visible, false);
        Glfw.WindowHint(Hint.Floating, false);
        Glfw.WindowHint(Hint.FocusOnShow, false);
        Glfw.WindowHint(Hint.Decorated, ((int)(vp.Flags & ImGuiViewportFlags.NoDecoration) == 0));
        Glfw.WindowHint(Hint.Floating, ((int)(vp.Flags & ImGuiViewportFlags.TopMost) == 1));
        
        var window = new Window("Irrelevant", new Vector2(200, 200));

        var guid = CreateNewWindowUserData(window);

        myAdditionalWindows.Add(window);

        vp.PlatformUserData = GCHandle.ToIntPtr(guid.Pin());
        
        window.EKeyboardKey += KeyDown;
        window.ECharInput += CharInput;
        window.EMouseScrolled += MouseScroll;
        window.EMouseButton += MouseButton;
        window.EMousePosition += MousePosition;

        LogicalDevice.Device.WaitUntilIdle();
        var userData = myWindowUserDatas[guid];
        userData.Surface = Api.ApiInstance.CreateSurface(window);
        VkSurfaceFormatKHR surfaceFormat = Gpu.GpuInstance.GetSurfaceFormat(VkFormat.B8G8R8A8Unorm, VkColorSpaceKHR.SrgbNonLinear);
        VkPresentModeKHR presentMode = Gpu.GpuInstance.GetPresentMode(VkPresentModeKHR.FifoRelaxed);

        userData.Swapchain = new Swapchain(surfaceFormat, presentMode, userData.Surface.GetSwapbufferExtent(), userData.Surface);
        userData.ImageViews = userData.Swapchain.CreateImageViews();
        userData.RenderQueue = new RenderQueue();

        userData.RenderImage = new Image(VkFormat.R16G16B16A16Sfloat, VkImageUsageFlags.Storage | VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst | VkImageUsageFlags.TransferSrc, new VkExtent3D(userData.Swapchain.MyExtents.width, userData.Swapchain.MyExtents.height, 1), false);
        userData.DepthImage = new Image(VkFormat.D32Sfloat, VkImageUsageFlags.DepthStencilAttachment, new VkExtent3D(userData.Swapchain.MyExtents.width, userData.Swapchain.MyExtents.height, 1), false);

        userData.FrameData = new();
        
        for(int i = 0; i < 2; i++)
        {
            FrameData newFrame = new();

            newFrame.MyCommandBuffer = new CommandBuffer(userData.RenderQueue);
            newFrame.MyRenderFinishedSemaphore = new();
            newFrame.MyImageAvailableSemaphore = new();
            newFrame.MyRenderFence = new();

            userData.FrameData.Add(newFrame);
        }
    }
    
    private void ResizeWindow(WindowUserData aUserData)
    {
        LogicalDevice.Device.WaitUntilIdle();

        aUserData.Swapchain!.Destroy();
        aUserData.RenderImage!.Destroy();
        aUserData.DepthImage!.Destroy();

        foreach (var imageView in aUserData.ImageViews!)
            imageView.Destroy();
        
        aUserData.ImageViews.Clear();

        VkSurfaceFormatKHR surfaceFormat = Gpu.GpuInstance.GetSurfaceFormat(VkFormat.B8G8R8A8Unorm, VkColorSpaceKHR.SrgbNonLinear);
        VkPresentModeKHR presentMode = Gpu.GpuInstance.GetPresentMode(VkPresentModeKHR.Mailbox);
        aUserData.Swapchain = new Swapchain(surfaceFormat, presentMode, aUserData.Surface!.GetSwapbufferExtent(), aUserData.Surface!);
        aUserData.ImageViews = aUserData.Swapchain.CreateImageViews();
        aUserData.RenderQueue = new RenderQueue();

        aUserData.RenderImage = new Image(VkFormat.R16G16B16A16Sfloat, VkImageUsageFlags.Storage | VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst | VkImageUsageFlags.TransferSrc, new VkExtent3D(aUserData.Swapchain.MyExtents.width, aUserData.Swapchain.MyExtents.height, 1), false);
        aUserData.DepthImage = new Image(VkFormat.D32Sfloat, VkImageUsageFlags.DepthStencilAttachment, new VkExtent3D(aUserData.Swapchain.MyExtents.width, aUserData.Swapchain.MyExtents.height, 1), false);
    }

    private void DestroyWindow(ImGuiViewportPtr vp)
    {
        if (vp.PlatformUserData != IntPtr.Zero)
        {
            var data = GetWindowUserDataFromViewport(vp);
            data.Window.Close();
            var handle = GCHandle.FromIntPtr(vp.PlatformUserData);
            myWindowUserDatas.Remove((Guid)(handle.Target!));
            handle.Free();
            vp.PlatformUserData = IntPtr.Zero;
            
            LogicalDevice.Device.WaitUntilIdle();
            data.Swapchain?.Destroy();
            data.Surface?.Destroy();
            
            if (data.ImageViews != null)
                foreach (var imageView in data.ImageViews)
                    imageView.Destroy();

            data.RenderImage?.Destroy();
            data.DepthImage?.Destroy();
            if (data.FrameData != null)
                foreach (var frameData in data.FrameData)
                    frameData.Destroy();
        }
    }
    
    private WindowUserData GetWindowUserDataFromViewport(ImGuiViewportPtr aViewport)
    {
        System.Guid guid = (System.Guid)(GCHandle.FromIntPtr(aViewport.PlatformUserData).Target)!;

        return myWindowUserDatas[guid];
    }

    private void ShowWindow(ImGuiViewportPtr vp)
    {
        var data = GetWindowUserDataFromViewport(vp);

        data.Window.Show();
    }

    private unsafe void GetWindowPos(ImGuiViewportPtr vp, Vector2* outPos)
    {
        var data = GetWindowUserDataFromViewport(vp);
        
        var position = data.Window.GetWindowPosition();

        *outPos = new Vector2(position.x, position.y);
    }

    private void SetWindowPos(ImGuiViewportPtr vp, Vector2 pos)
    {
        var data = GetWindowUserDataFromViewport(vp);
        data.Window.SetWindowPosition((int)pos.X, (int)pos.Y);
    }

    private void SetWindowSize(ImGuiViewportPtr vp, Vector2 size)
    {
        var data = GetWindowUserDataFromViewport(vp);
        data.Window.SetWindowSize((int)size.X, (int)size.Y);
    }

    private unsafe void GetWindowSize(ImGuiViewportPtr vp, Vector2* outSize)
    {
        var data = GetWindowUserDataFromViewport(vp);
        
        var size = data.Window.GetWindowSize();

        *outSize = new Vector2(size.width, size.height);
    } 
   
    private void SetWindowFocus(ImGuiViewportPtr vp)
    {
        var data = GetWindowUserDataFromViewport(vp);

        data.Window.FocusWindow();
    }

    private byte GetWindowFocus(ImGuiViewportPtr vp)
    {
        var data = GetWindowUserDataFromViewport(vp);

        return (byte)(data.Window.IsFocused ? 1 : 0);
    }

    private byte GetWindowMinimized(ImGuiViewportPtr vp)
    {
        var data = GetWindowUserDataFromViewport(vp);
        return (byte)(data!.Window.Minimized ? 1 : 0);
    }

    private unsafe void SetWindowTitle(ImGuiViewportPtr vp, IntPtr title)
    {
        var data = GetWindowUserDataFromViewport(vp);
        byte* titlePtr = (byte*)title;
        int count = 0;
        while (titlePtr[count] != 0)
        {
            count += 1;
        }
        data.Window.SetTitle(System.Text.Encoding.ASCII.GetString(titlePtr, count));
    }
    
    private void UpdateMouseCursor()
    {
        ImGuiMouseCursor imgui_cursor = ImGui.GetMouseCursor();
        var platformIo = ImGui.GetPlatformIO();
        for (int n = 0; n < platformIo.Viewports.Size; n++)
        {
            var viewport = platformIo.Viewports[n];
            var data = GetWindowUserDataFromViewport(viewport);
            
            switch(imgui_cursor)
            {
                case ImGuiMouseCursor.TextInput:
                    data.Window.SetCursor(myPlatformUserData.TextInputCursor);
                    break;
                case ImGuiMouseCursor.ResizeEW:
                    data.Window.SetCursor(myPlatformUserData.ResizeEW);
                    break;
                case ImGuiMouseCursor.ResizeNS:
                    data.Window.SetCursor(myPlatformUserData.ResizeNS);
                    break;
                case ImGuiMouseCursor.Hand:
                    data.Window.SetCursor(myPlatformUserData.Hand);
                    break;
                default:
                    data.Window.SetCursor(myPlatformUserData.StandardCursor);
                    break;
            }
        }
    }
    
    public void Begin()
    {
        SetFrameData();

        UpdateMouseCursor();
        ImGui.NewFrame();
    }
    
    public void End()
    {
        ImGui.EndFrame();
        ImGui.Render();
        ImGui.UpdatePlatformWindows();
    }
    
    public void Render(CommandBuffer cmd)
    {
        RenderDrawData(cmd, ImGui.GetDrawData());
    }
    
    struct imguiPushConstants
    {
        public Vector2 Scale;
        public Vector2 Translate;
        public VkDeviceAddress VertexBuffer;
    }
    
    struct ImDrawVertCorrected
    {
        public Vector2 Position;
        public Vector2 UV;
        public Vector4 Color;
    }

    List<ImDrawVertCorrected> corrected = new();
    private unsafe void RenderDrawData(CommandBuffer cmd, ImDrawDataPtr aDrawDataPtr)
    {
        if (myOldIBuffers.Count > 5)
        {
            myOldIBuffers[0].Destroy();
            myOldIBuffers.RemoveAt(0);
        }
        if (myOldVBuffers.Count > 5)
        {
            myOldVBuffers[0].Destroy();
            myOldVBuffers.RemoveAt(0);
        }
        
        var framebufferWidth = (int) aDrawDataPtr.DisplaySize.X * aDrawDataPtr.FramebufferScale.X;
        var frameBufferHeight = (int) aDrawDataPtr.DisplaySize.Y * aDrawDataPtr.FramebufferScale.Y;
        if (framebufferWidth <= 0 || frameBufferHeight <= 0 || aDrawDataPtr.TotalVtxCount == 0 || aDrawDataPtr.TotalIdxCount == 0) 
            return;

        AllocatedBuffer<ushort> indexBuffer = new(VkBufferUsageFlags.IndexBuffer, VmaMemoryUsage.CpuToGpu, (uint)aDrawDataPtr.TotalIdxCount);
        AllocatedBuffer<ImDrawVertCorrected> vertexBuffer = new(VkBufferUsageFlags.StorageBuffer | VkBufferUsageFlags.ShaderDeviceAddress, VmaMemoryUsage.CpuToGpu, (uint)aDrawDataPtr.TotalVtxCount);

        ulong vtxOffset = 0;
        ulong idxOffset = 0;
        
        for(int i = 0; i < aDrawDataPtr.CmdListsCount; i++)
        {
            ref var cmdList = ref aDrawDataPtr.CmdLists[i];
            ulong vtxChunkSize = (ulong) cmdList.VtxBuffer.Size * (ulong) sizeof(ImDrawVertCorrected);
            ulong idxChunkSize = (ulong) cmdList.IdxBuffer.Size * sizeof(ushort);

            Span<ImDrawVert> vertices = new Span<ImDrawVert>(cmdList.VtxBuffer.Data.ToPointer(), cmdList.VtxBuffer.Size);
            corrected.Clear();
            corrected.EnsureCapacity(vertices.Length);

            foreach(ImDrawVert vert in vertices)
            {
                Color color = Color.FromArgb((int)vert.col);
                corrected.Add(new() { Position = vert.pos, UV = vert.uv, Color = new Vector4(color.B / 255f, color.G / 255f, color.R / 255f, color.A / 255f) });
            }
            
            Span<ImDrawVertCorrected> verticesReal = corrected.AsSpan();
            
            Span<ushort> indices = new Span<ushort>(cmdList.IdxBuffer.Data.ToPointer(), cmdList.IdxBuffer.Size);

            vertexBuffer.SetWriteData(verticesReal, vtxOffset);
            indexBuffer.SetWriteData(indices, idxOffset);

            vtxOffset += vtxChunkSize;
            idxOffset += idxChunkSize;
        }
        

        cmd.BindPipeline(myPipeline);

        cmd.BindIndexBuffer(indexBuffer, VkIndexType.Uint16);

        var scale = stackalloc float[2];
        scale[0] = 2.0f / aDrawDataPtr.DisplaySize.X;
        scale[1] = 2.0f / aDrawDataPtr.DisplaySize.Y;
        var translate = stackalloc float[2];
        translate[0] = -1.0f - aDrawDataPtr.DisplayPos.X * scale[0];
        translate[1] = -1.0f - aDrawDataPtr.DisplayPos.Y * scale[1];

        imguiPushConstants pushConstants = new();
        pushConstants.Scale.X = 2.0f / aDrawDataPtr.DisplaySize.X;
        pushConstants.Scale.Y = 2.0f / aDrawDataPtr.DisplaySize.Y;
        pushConstants.Translate.X = -1.0f - aDrawDataPtr.DisplayPos.X * pushConstants.Scale.X;
        pushConstants.Translate.Y = -1.0f - aDrawDataPtr.DisplayPos.Y * pushConstants.Scale.Y;
        pushConstants.VertexBuffer = vertexBuffer.GetDeviceAddress();

        cmd.SetPushConstants(pushConstants, myPipeline.MyVkLayout, VkShaderStageFlags.Vertex);

        var clipOff = aDrawDataPtr.DisplayPos;
        var clipScale = aDrawDataPtr.FramebufferScale;

        var vertexOffset = 0;
        var indexOffset = 0;
        for (var n = 0; n < aDrawDataPtr.CmdListsCount; n++)
        {
            ref var cmdList = ref aDrawDataPtr.CmdLists[n];
            for (var i = 0; i < cmdList.CmdBuffer.Size; i++)
            {
                var cmdItem = cmdList.CmdBuffer[i];
                cmd.BindDescriptorSet(myPipeline.MyVkLayout, GetOrAddDescriptor(cmdItem.TextureId), VkPipelineBindPoint.Graphics);

                var clipRect = new Vector4
                {
                    X = (cmdItem.ClipRect.X - clipOff.X) * clipScale.X,
                    Y = (cmdItem.ClipRect.Y - clipOff.Y) * clipScale.Y,
                    Z = (cmdItem.ClipRect.Z - clipOff.X) * clipScale.X,
                    W = (cmdItem.ClipRect.W - clipOff.Y) * clipScale.Y,
                };
                if (clipRect.X < framebufferWidth
                    && clipRect.Y < frameBufferHeight
                    && clipRect.Z >= .0f
                    && clipRect.W >= .0f)
                {
                    if (clipRect.X < 0.0f) clipRect.X = 0.0f;
                    if (clipRect.Y < 0.0f) clipRect.Y = 0.0f;

                    var scissor = new VkRect2D(
                                             new VkOffset2D((int) clipRect.X, (int) clipRect.Y),
                                             new VkExtent2D((uint) (clipRect.Z - clipRect.X),
                                                          (uint) (clipRect.W - clipRect.Y))
                                            );
                    cmd.SetScissor(scissor);

                    cmd.DrawIndexed(cmdItem.ElemCount, 1, cmdItem.IdxOffset + (uint) indexOffset,
                                    (int) cmdItem.VtxOffset + vertexOffset, 0);

                }
            }
            indexOffset += cmdList.IdxBuffer.Size;
            vertexOffset += cmdList.VtxBuffer.Size;
        }

        myOldVBuffers.Add(vertexBuffer);
        myOldIBuffers.Add(indexBuffer);
    }

    public unsafe void Destroy()
    {
        LogicalDevice.Device.WaitUntilIdle();
        myFontTexture.Destroy();
        myDescriptorAllocator.Destroy();
        mySampler.Destroy();
        
        Vulkan.vkDestroyDescriptorSetLayout(LogicalDevice.Device.MyVkDevice, myLayout);

        myPipeline.Destroy();

        foreach (var buffer in myOldVBuffers)
            buffer.Destroy();
        foreach (var buffer in myOldIBuffers)
            buffer.Destroy();
        
        foreach (var data in myWindowUserDatas.Values)
        {
            data.Swapchain?.Destroy();
            data.Surface?.Destroy();
            
            if (data.ImageViews != null)
                foreach (var imageView in data.ImageViews)
                    imageView.Destroy();

            data.RenderImage?.Destroy();
            data.DepthImage?.Destroy();
            if (data.FrameData != null)
                foreach (var frameData in data.FrameData)
                    frameData.Destroy();
        }
    }

    public unsafe void RenderOtherWindows()
    {
        var platformIo = ImGui.GetPlatformIO();
        
        for(int i = 0; i < platformIo.Viewports.Size; i++)
        {
            var viewport = platformIo.Viewports[i];

            if (viewport.NativePtr == ImGui.GetMainViewport().NativePtr)
                continue;
            
            var viewportData = GetWindowUserDataFromViewport(viewport);

            LogicalDevice.Device.WaitUntilIdle();
            
            viewportData.CurrentFrame.MyRenderFence.Wait();
            viewportData.CurrentFrame.MyRenderFence.Reset();
            
            if (viewportData.WantsResize)
            {
                ResizeWindow(viewportData);
                viewportData.WantsResize = false;
            }
            
            viewportData.CurrentFrame.MyDeletionQueue.Flush();
            viewportData.CurrentFrame.MyFrameDescriptors.ClearPools();
            
            var nextImage = LogicalDevice.Device.AcquireNextImage(viewportData.Swapchain!, viewportData.CurrentFrame.MyImageAvailableSemaphore);
            uint imageIndex = nextImage.imageIndex;
            if (nextImage.result == VkResult.ErrorOutOfDateKHR)
            {
                viewportData.WantsResize = true;
                i--;
                continue;
            }
            
            VkImage currentSwapchainImage = viewportData.Swapchain!.MyImages[(int)imageIndex];
            
            CommandBuffer cmd = viewportData.CurrentFrame.MyCommandBuffer;

            cmd.Reset();
            cmd.BeginRecording();

            cmd.TransitionImage(viewportData.RenderImage!, VkImageLayout.General);
            cmd.TransitionImage(viewportData.DepthImage!, VkImageLayout.DepthAttachmentOptimal);
            
            cmd.BeginRendering(viewportData.RenderImage!, viewportData.DepthImage!);
            RenderDrawData(cmd, viewport.DrawData);
            cmd.EndRendering();
            cmd.TransitionImage(viewportData.RenderImage!, VkImageLayout.TransferSrcOptimal);
            cmd.TransitionImage(currentSwapchainImage, VkImageLayout.Undefined, VkImageLayout.TransferDstOptimal);

            cmd.Blit(viewportData.RenderImage!, currentSwapchainImage, viewportData.Swapchain.MyExtents);
            
            cmd.TransitionImage(currentSwapchainImage, VkImageLayout.TransferDstOptimal, VkImageLayout.PresentSrcKHR);

            cmd.EndRecording();
            
            viewportData.RenderQueue!.Submit(cmd, viewportData.CurrentFrame.MyImageAvailableSemaphore, viewportData.CurrentFrame.MyRenderFinishedSemaphore, viewportData.CurrentFrame.MyRenderFence);
            
            VkResult result = viewportData.RenderQueue.Present(viewportData.Swapchain, viewportData.CurrentFrame.MyRenderFinishedSemaphore, imageIndex);
            
            if (result == VkResult.ErrorOutOfDateKHR)
                viewportData.WantsResize = true;
            
            viewportData.FrameNumber++;
        }
    }
}