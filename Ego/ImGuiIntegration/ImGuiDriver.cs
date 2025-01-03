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
using Utilities;
using Vortice.ShaderCompiler;
using Vortice.Vulkan;
using Image = VulkanApi.Image;
using Vulkan = Vortice.Vulkan.Vulkan;

namespace Rendering;

public class ImGuiDriver : IGpuDestroyable
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
    
    private Image FontTexture;
    private DescriptorAllocatorGrowable DescriptorAllocator;
    private VkDescriptorSetLayout Layout;

    //We don't ever actually remove descriptors - this could be a problem in the future
    private Dictionary<nint, VkDescriptorSet> ImageDescriptors = new();
    private Sampler Sampler;
    private GraphicsPipeline Pipeline;
    private Window MainWindow;
    private List<Window> AdditionalWindows = new();
    private Dictionary<System.Guid, WindowUserData> WindowUserDatas = new();

    private List<AllocatedBuffer<ImDrawVertCorrected>> OldVBuffers = new();
    private List<AllocatedBuffer<ushort>> OldIBuffers = new();
    private VkDescriptorSetLayout VertexBufferLayout;
    private VkDescriptorSetLayout IndexBufferLayout;
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
    
    private Stopwatch Stopwatch = new();
    private PlatformUserData PlatformData = new();

    public unsafe ImGuiDriver(Renderer aRenderer, Window aMainWindow)
    {
        Stopwatch.Start();
        MainWindow = aMainWindow;
        
        var context = ImGui.CreateContext();
        ImGui.SetCurrentContext(context);

        var io = ImGui.GetIO();

        io.ConfigFlags = ImGuiConfigFlags.DockingEnable | ImGuiConfigFlags.ViewportsEnable;
        io.Fonts.AddFontFromFileTTF("Roboto-Regular.ttf", 15f);

        List<ushort> iconRange = new(300);

        iconRange.Add(59392);
        iconRange.Add(62324);
        iconRange.Add(0);
        ImFontConfigPtr config = ImGuiNative.ImFontConfig_ImFontConfig();
        config.MergeMode = true;
        config.SizePixels = 15f;

        //config.GlyphOffset = new(0f, 2f);
        
        io.Fonts.AddFontFromFileTTF("ego-icon-font.ttf", 15f, config, (IntPtr)iconRange.AsSpan().GetPointerUnsafe());
        io.Fonts.AddFontDefault();

        io.Fonts.Fonts[0].ConfigData.RasterizerMultiply = 1.2f;
        
        io.Fonts.GetTexDataAsRGBA32(out nint pixels, out var width, out var height);
        
        FontTexture = new Image(aRenderer, (byte*)pixels.ToPointer(), VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled | VkImageUsageFlags.TransferDst, new VkExtent3D(width, height, 1), false);
        DescriptorAllocator = new DescriptorAllocatorGrowable();
        DescriptorAllocator.InitPool(100, [new(ratio: 1000, type: VkDescriptorType.CombinedImageSampler)]);
        
        Sampler = new(VkFilter.Linear);

        DescriptorLayoutBuilder layoutBuilder = new();
        layoutBuilder.AddBinding(0, VkDescriptorType.CombinedImageSampler);
        Layout = layoutBuilder.Build(VkShaderStageFlags.Fragment);

        AddTexture(FontTexture);

        io.Fonts.SetTexID(FontTexture.GetHandle());
        
        Pipeline = new GraphicsPipeline.GraphicsPipelineBuilder()
            .AddPushConstant(new VkPushConstantRange { offset = 0, size = sizeof(float) * 4 + sizeof(VkDeviceAddress), stageFlags = VkShaderStageFlags.Vertex })
            .AddLayout(Layout)
            .SetBlendMode(BlendMode.Alpha)
            .DisableMultisampling()
            .SetVertexShader("Shaders/imguiVert.spv")
            .SetFragmentShader("Shaders/imguiFrag.spv")
            .SetTopology(VkPrimitiveTopology.TriangleList)
            .SetPolygonMode(VkPolygonMode.Fill)
            .SetCullMode(VkCullModeFlags.None, VkFrontFace.Clockwise)
            .DisableDepthTest()
            .SetColorAttachmentFormat(VkFormat.R16G16B16A16Sfloat)
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
        
        GCHandle handle = GCHandle.Alloc(PlatformData, GCHandleType.Pinned);
        io.BackendPlatformUserData = GCHandle.ToIntPtr(handle);
        
        PlatformData.StandardCursor = GLFW.Glfw.CreateStandardCursor(GLFW.CursorType.Arrow);
        PlatformData.TextInputCursor = GLFW.Glfw.CreateStandardCursor(GLFW.CursorType.Beam);
        PlatformData.ResizeEW = GLFW.Glfw.CreateStandardCursor(GLFW.CursorType.ResizeHorizontal);
        PlatformData.ResizeNS = GLFW.Glfw.CreateStandardCursor(GLFW.CursorType.ResizeVertical);
        PlatformData.Hand = GLFW.Glfw.CreateStandardCursor(GLFW.CursorType.Hand);

        ImGuiViewportPtr mainViewPort = ImGui.GetMainViewport();
        
        AdditionalWindows.Add(aMainWindow);
        UpdateMonitors();

        mainViewPort.PlatformUserData = GCHandle.ToIntPtr(CreateNewWindowUserData(aMainWindow).Pin());
        
        aRenderer.ERenderImgui += Render;
        aRenderer.EPostRender += RenderOtherWindows;

        SetupTheme();
    }
    
    private void SetupTheme()
    {
        ImGui.GetStyle().FrameBorderSize = 1f;
        
        var colors = ImGui.GetStyle().Colors;
        colors[(int)ImGuiCol.Text]                   = new Vector4(0.89f, 0.91f, 0.96f, 1.00f);
        colors[(int)ImGuiCol.TextDisabled]           = new Vector4(0.50f, 0.50f, 0.50f, 1.00f);
        colors[(int)ImGuiCol.WindowBg]               = new Vector4(0.16f, 0.17f, 0.22f, 0.94f);
        colors[(int)ImGuiCol.ChildBg]                = new Vector4(0.16f, 0.17f, 0.22f, 0.94f);
        colors[(int)ImGuiCol.PopupBg]                = new Vector4(0.16f, 0.17f, 0.22f, 0.94f);
        colors[(int)ImGuiCol.Border]                 = new Vector4(0.30f, 0.34f, 0.42f, 0.50f);
        colors[(int)ImGuiCol.BorderShadow]           = new Vector4(0.85f, 0.87f, 0.91f, 0.01f);
        colors[(int)ImGuiCol.FrameBg]                = new Vector4(0.26f, 0.30f, 0.37f, 0.54f);
        colors[(int)ImGuiCol.FrameBgHovered]         = new Vector4(0.62f, 0.67f, 0.77f, 0.23f);
        colors[(int)ImGuiCol.FrameBgActive]          = new Vector4(0.89f, 0.91f, 0.96f, 0.28f);
        colors[(int)ImGuiCol.TitleBg]                = new Vector4(0.23f, 0.26f, 0.32f, 0.94f);
        colors[(int)ImGuiCol.TitleBgActive]          = new Vector4(0.26f, 0.30f, 0.37f, 1.00f);
        colors[(int)ImGuiCol.TitleBgCollapsed]       = new Vector4(0.13f, 0.15f, 0.18f, 0.94f);
        colors[(int)ImGuiCol.MenuBarBg]              = new Vector4(0.14f, 0.14f, 0.14f, 1.00f);
        colors[(int)ImGuiCol.ScrollbarBg]            = new Vector4(0.18f, 0.20f, 0.25f, 1.00f);
        colors[(int)ImGuiCol.ScrollbarGrab]          = new Vector4(0.23f, 0.26f, 0.32f, 1.00f);
        colors[(int)ImGuiCol.ScrollbarGrabHovered]   = new Vector4(0.26f, 0.30f, 0.37f, 1.00f);
        colors[(int)ImGuiCol.ScrollbarGrabActive]    = new Vector4(0.30f, 0.34f, 0.42f, 1.00f);
        colors[(int)ImGuiCol.CheckMark]              = new Vector4(0.98f, 0.98f, 0.98f, 1.00f);
        colors[(int)ImGuiCol.SliderGrab]             = new Vector4(0.85f, 0.87f, 0.91f, 0.39f);
        colors[(int)ImGuiCol.SliderGrabActive]       = new Vector4(0.98f, 0.98f, 0.98f, 0.23f);
        colors[(int)ImGuiCol.Button]                 = new Vector4(0.30f, 0.34f, 0.42f, 0.40f);
        colors[(int)ImGuiCol.ButtonHovered]          = new Vector4(0.43f, 0.49f, 0.60f, 1.00f);
        colors[(int)ImGuiCol.ButtonActive]           = new Vector4(0.98f, 0.98f, 0.98f, 1.00f);
        colors[(int)ImGuiCol.Header]                 = new Vector4(0.85f, 0.87f, 0.91f, 0.18f);
        colors[(int)ImGuiCol.HeaderHovered]          = new Vector4(0.85f, 0.87f, 0.91f, 0.37f);
        colors[(int)ImGuiCol.HeaderActive]           = new Vector4(0.85f, 0.87f, 0.91f, 0.52f);
        colors[(int)ImGuiCol.Separator]              = new Vector4(0.43f, 0.43f, 0.50f, 0.50f);
        colors[(int)ImGuiCol.SeparatorHovered]       = new Vector4(0.75f, 0.75f, 0.75f, 0.78f);
        colors[(int)ImGuiCol.SeparatorActive]        = new Vector4(0.75f, 0.75f, 0.75f, 1.00f);
        colors[(int)ImGuiCol.ResizeGrip]             = new Vector4(0.98f, 0.98f, 0.98f, 0.20f);
        colors[(int)ImGuiCol.ResizeGripHovered]      = new Vector4(0.98f, 0.98f, 0.98f, 0.67f);
        colors[(int)ImGuiCol.ResizeGripActive]       = new Vector4(0.98f, 0.98f, 0.98f, 0.95f);
        colors[(int)ImGuiCol.Tab]                    = new Vector4(0.23f, 0.26f, 0.32f, 1.00f);
        colors[(int)ImGuiCol.TabHovered]             = new Vector4(0.52f, 0.56f, 0.65f, 0.80f);
        colors[(int)ImGuiCol.TabActive]              = new Vector4(0.35f, 0.39f, 0.48f, 1.00f);
        colors[(int)ImGuiCol.TabUnfocused]           = new Vector4(0.23f, 0.26f, 0.32f, 1.00f);
        colors[(int)ImGuiCol.TabUnfocusedActive]     = new Vector4(0.26f, 0.30f, 0.37f, 1.00f);
        colors[(int)ImGuiCol.DockingPreview]         = new Vector4(0.98f, 0.98f, 0.98f, 0.70f);
        colors[(int)ImGuiCol.DockingEmptyBg]         = new Vector4(0.20f, 0.20f, 0.20f, 1.00f);
        colors[(int)ImGuiCol.PlotLines]              = new Vector4(0.61f, 0.61f, 0.61f, 1.00f);
        colors[(int)ImGuiCol.PlotLinesHovered]       = new Vector4(1.00f, 0.43f, 0.35f, 1.00f);
        colors[(int)ImGuiCol.PlotHistogram]          = new Vector4(0.90f, 0.70f, 0.00f, 1.00f);
        colors[(int)ImGuiCol.PlotHistogramHovered]   = new Vector4(1.00f, 0.60f, 0.00f, 1.00f);
        colors[(int)ImGuiCol.TableHeaderBg]          = new Vector4(0.19f, 0.19f, 0.20f, 1.00f);
        colors[(int)ImGuiCol.TableBorderStrong]      = new Vector4(0.31f, 0.31f, 0.35f, 1.00f);
        colors[(int)ImGuiCol.TableBorderLight]       = new Vector4(0.23f, 0.26f, 0.32f, 0.94f);
        colors[(int)ImGuiCol.TableRowBg]             = new Vector4(0.18f, 0.20f, 0.25f, 0.94f);
        colors[(int)ImGuiCol.TableRowBgAlt]          = new Vector4(1.00f, 1.00f, 1.00f, 0.06f);
        colors[(int)ImGuiCol.TextSelectedBg]         = new Vector4(0.98f, 0.98f, 0.98f, 0.35f);
        colors[(int)ImGuiCol.DragDropTarget]         = new Vector4(0.93f, 0.94f, 0.96f, 0.64f);
        colors[(int)ImGuiCol.NavHighlight]           = new Vector4(0.98f, 0.98f, 0.98f, 1.00f);
        colors[(int)ImGuiCol.NavWindowingHighlight]  = new Vector4(1.00f, 1.00f, 1.00f, 0.70f);
        colors[(int)ImGuiCol.NavWindowingDimBg]      = new Vector4(0.80f, 0.80f, 0.80f, 0.20f);
        colors[(int)ImGuiCol.ModalWindowDimBg]       = new Vector4(0.80f, 0.80f, 0.80f, 0.35f);
            
            
        //Orange Highlights
        colors[(int)ImGuiCol.TabActive]              = new Vector4(0.63f, 0.41f, 0.12f, 1.00f);
        colors[(int)ImGuiCol.TitleBgActive]          = new Vector4(0.79f, 0.51f, 0.15f, 0.36f);
        colors[(int)ImGuiCol.ScrollbarGrabActive]    = new Vector4(0.79f, 0.51f, 0.15f, 0.36f);
        colors[(int)ImGuiCol.SliderGrabActive]       = new Vector4(0.79f, 0.51f, 0.15f, 0.66f);
        colors[(int)ImGuiCol.ButtonActive]           = new Vector4(0.63f, 0.41f, 0.12f, 1.00f);
        //colors[(int)ImGuiCol.HeaderHovered]          = new Vector4(0.76f, 0.50f, 0.15f, 1.00f);
        colors[(int)ImGuiCol.HeaderActive]           = new Vector4(0.88f, 0.91f, 0.96f, 0.37f);
        //colors[(int)ImGuiCol.TabHovered]             = new Vector4(0.76f, 0.50f, 0.15f, 1.00f);
        colors[(int)ImGuiCol.TabActive]              = new Vector4(0.72f, 0.47f, 0.13f, 1.00f);
        colors[(int)ImGuiCol.ScrollbarGrabActive]    = new Vector4(0.79f, 0.51f, 0.15f, 0.81f);
    }
    
    private VkDescriptorSet AddTexture(Image aImage)
    {
        var newDescriptorSet = DescriptorAllocator.Allocate(Layout);
        
        {
            DescriptorWriter writer = new();
            writer.WriteImage(0, aImage.ImageView, Sampler, VkImageLayout.ShaderReadOnlyOptimal, VkDescriptorType.CombinedImageSampler);
            writer.UpdateSet(newDescriptorSet);
        }
        ImageDescriptors.Add(aImage.GetHandle(), newDescriptorSet);

        return newDescriptorSet;
    }
    
    private VkDescriptorSet GetOrAddDescriptor(nint aImage)
    {
        return GetOrAddDescriptor(ImageRegistry.PointersToImages[aImage]);
    }
    
    private VkDescriptorSet GetOrAddDescriptor(Image aImage)
    {
        if (ImageDescriptors.TryGetValue(aImage.GetHandle(), out var descriptorSet))
        {
            return descriptorSet;
        }

        return AddTexture(aImage);
    }
    
    private System.Guid CreateNewWindowUserData(Window aWindow)
    {
        Guid guid = System.Guid.NewGuid();
        WindowUserDatas.Add(guid, new WindowUserData(aWindow));
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

        Vector2 windowSize = new Vector2{X = MainWindow.GetWindowSize().width, Y = MainWindow.GetWindowSize().height};
        Vector2 framebufferSize = new Vector2{X = MainWindow.GetFramebufferSize().width, Y = MainWindow.GetFramebufferSize().height};
        
        io.DisplaySize = new Vector2(MainWindow.GetFramebufferSize().width, MainWindow.GetFramebufferSize().height);
        if (windowSize is {X: > 0, Y: > 0})
            io.DisplayFramebufferScale = new Vector2(framebufferSize.X / (float) windowSize.X,
                framebufferSize.Y / (float) windowSize.Y);
        
        io.DeltaTime = (float)Stopwatch.Elapsed.TotalSeconds;
        Stopwatch.Restart();
    } 
    
    private unsafe void UpdateMonitors()
    {
        var platformIo = ImGui.GetPlatformIO();
        PlatformData.WantUpdateMonitors = false;

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

        AdditionalWindows.Add(window);

        vp.PlatformUserData = GCHandle.ToIntPtr(guid.Pin());
        
        window.EKeyboardKey += KeyDown;
        window.ECharInput += CharInput;
        window.EMouseScrolled += MouseScroll;
        window.EMouseButton += MouseButton;
        window.EMousePosition += MousePosition;

        LogicalDevice.Device.WaitUntilIdle();
        var userData = WindowUserDatas[guid];
        userData.Surface = Api.ApiInstance.CreateSurface(window);
        VkSurfaceFormatKHR surfaceFormat = Gpu.GpuInstance.GetSurfaceFormat(VkFormat.B8G8R8A8Unorm, VkColorSpaceKHR.SrgbNonLinear);
        VkPresentModeKHR presentMode = Gpu.GpuInstance.GetPresentMode(VkPresentModeKHR.FifoRelaxed);

        userData.Swapchain = new Swapchain(surfaceFormat, presentMode, userData.Surface.GetSwapbufferExtent(), userData.Surface);
        userData.ImageViews = userData.Swapchain.CreateImageViews();
        userData.RenderQueue = new RenderQueue();

        userData.RenderImage = new Image(VkFormat.R16G16B16A16Sfloat, VkImageUsageFlags.Storage | VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst | VkImageUsageFlags.TransferSrc, new VkExtent3D(userData.Swapchain.Extents.width, userData.Swapchain.Extents.height, 1), false);
        userData.DepthImage = new Image(VkFormat.D32Sfloat, VkImageUsageFlags.DepthStencilAttachment, new VkExtent3D(userData.Swapchain.Extents.width, userData.Swapchain.Extents.height, 1), false);

        userData.FrameData = new();
        
        for(int i = 0; i < 2; i++)
        {
            FrameData newFrame = new();

            newFrame.CommandBuffer = new CommandBuffer(userData.RenderQueue);
            newFrame.RenderFinishedSemaphore = new();
            newFrame.ImageAvailableSemaphore = new();
            newFrame.RenderFence = new();

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

        aUserData.RenderImage = new Image(VkFormat.R16G16B16A16Sfloat, VkImageUsageFlags.Storage | VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst | VkImageUsageFlags.TransferSrc, new VkExtent3D(aUserData.Swapchain.Extents.width, aUserData.Swapchain.Extents.height, 1), false);
        aUserData.DepthImage = new Image(VkFormat.D32Sfloat, VkImageUsageFlags.DepthStencilAttachment, new VkExtent3D(aUserData.Swapchain.Extents.width, aUserData.Swapchain.Extents.height, 1), false);
    }

    private void DestroyWindow(ImGuiViewportPtr vp)
    {
        if (vp.PlatformUserData != IntPtr.Zero)
        {
            var data = GetWindowUserDataFromViewport(vp);
            data.Window.OnDestroy();
            var handle = GCHandle.FromIntPtr(vp.PlatformUserData);
            WindowUserDatas.Remove((Guid)(handle.Target!));
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

        return WindowUserDatas[guid];
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
        return (byte)(data!.Window.IsMinimized ? 1 : 0);
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
                    data.Window.SetCursor(PlatformData.TextInputCursor);
                    break;
                case ImGuiMouseCursor.ResizeEW:
                    data.Window.SetCursor(PlatformData.ResizeEW);
                    break;
                case ImGuiMouseCursor.ResizeNS:
                    data.Window.SetCursor(PlatformData.ResizeNS);
                    break;
                case ImGuiMouseCursor.Hand:
                    data.Window.SetCursor(PlatformData.Hand);
                    break;
                default:
                    data.Window.SetCursor(PlatformData.StandardCursor);
                    break;
            }
        }
    }

    private Lock myLock = new();
    public void Begin()
    {
        myLock.Enter();
        SetFrameData();
        UpdateMouseCursor();
        ImGui.NewFrame();
    }
    
    public void End()
    {
        ImGui.EndFrame();
        ImGui.Render();
        ImGui.UpdatePlatformWindows();
        myLock.Exit();
    }

    private ImDrawDataPtr myDrawData;
    
    public unsafe void Render(CommandBufferHandle cmd)
    {
        lock(myLock)
        {
            var drawData = ImGui.GetDrawData();
        
            
            if (drawData.NativePtr == null)
                return;
        
            RenderDrawData(cmd, drawData);
        }
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
    private unsafe void RenderDrawData(CommandBufferHandle cmd, ImDrawDataPtr aDrawDataPtr)
    {
        if (OldIBuffers.Count > 5)
        {
            OldIBuffers[0].Destroy();
            OldIBuffers.RemoveAt(0);
        }
        if (OldVBuffers.Count > 5)
        {
            OldVBuffers[0].Destroy();
            OldVBuffers.RemoveAt(0);
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
            ulong vertexChunkSize = (ulong) cmdList.VtxBuffer.Size * (ulong) sizeof(ImDrawVertCorrected);
            ulong indexChunkSize = (ulong) cmdList.IdxBuffer.Size * sizeof(ushort);

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

            vtxOffset += vertexChunkSize;
            idxOffset += indexChunkSize;
        }
        

        cmd.BindPipeline(Pipeline);

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

        cmd.SetPushConstants(pushConstants, Pipeline.VkLayout, VkShaderStageFlags.Vertex);

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
                cmd.BindDescriptorSet(Pipeline.VkLayout, GetOrAddDescriptor(cmdItem.TextureId), VkPipelineBindPoint.Graphics);

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

        OldVBuffers.Add(vertexBuffer);
        OldIBuffers.Add(indexBuffer);
    }

    public unsafe void OnDestroy()
    {
        LogicalDevice.Device.WaitUntilIdle();
        FontTexture.Destroy();
        DescriptorAllocator.Destroy();
        Sampler.Destroy();
        
        Vulkan.vkDestroyDescriptorSetLayout(LogicalDevice.Device.VkDevice, Layout);

        Pipeline.Destroy();

        foreach (var buffer in OldVBuffers)
            buffer.Destroy();
        foreach (var buffer in OldIBuffers)
            buffer.Destroy();
        
        foreach (var data in WindowUserDatas.Values)
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
        lock(this)
        {
            var platformIo = ImGui.GetPlatformIO();
        
            for(int i = 0; i < platformIo.Viewports.Size; i++)
            {
                var viewport = platformIo.Viewports[i];

                if (viewport.NativePtr == ImGui.GetMainViewport().NativePtr)
                    continue;
                
                var viewportData = GetWindowUserDataFromViewport(viewport);

                LogicalDevice.Device.WaitUntilIdle();
                
                viewportData.CurrentFrame.RenderFence.Wait();
                viewportData.CurrentFrame.RenderFence.Reset();
                
                if (viewportData.WantsResize)
                {
                    ResizeWindow(viewportData);
                    viewportData.WantsResize = false;
                }
                
                viewportData.CurrentFrame.DeletionQueue.Flush();
                viewportData.CurrentFrame.FrameDescriptors.ClearPools();
                
                var nextImage = LogicalDevice.Device.AcquireNextImage(viewportData.Swapchain!, viewportData.CurrentFrame.ImageAvailableSemaphore);
                uint imageIndex = nextImage.imageIndex;
                if (nextImage.result == VkResult.ErrorOutOfDateKHR)
                {
                    viewportData.WantsResize = true;
                    i--;
                    continue;
                }
                
                VkImage currentSwapchainImage = viewportData.Swapchain!.Images[(int)imageIndex];
                
                using (CommandBufferHandle cmd = viewportData.CurrentFrame.CommandBuffer.BeginRecording())
                {
                    cmd.TransitionImage(viewportData.RenderImage!, VkImageLayout.General);
                    cmd.TransitionImage(viewportData.DepthImage!, VkImageLayout.DepthAttachmentOptimal);
                    
                    cmd.BeginRendering(viewportData.RenderImage!, viewportData.DepthImage!);
                    RenderDrawData(cmd, viewport.DrawData);
                    cmd.EndRendering();
                    cmd.TransitionImage(viewportData.RenderImage!, VkImageLayout.TransferSrcOptimal);
                    cmd.TransitionImage(currentSwapchainImage, VkImageLayout.Undefined, VkImageLayout.TransferDstOptimal);

                    cmd.Blit(viewportData.RenderImage!, currentSwapchainImage, viewportData.Swapchain.Extents);
                    
                    cmd.TransitionImage(currentSwapchainImage, VkImageLayout.TransferDstOptimal, VkImageLayout.PresentSrcKHR);
                }

                
                viewportData.RenderQueue!.Submit(viewportData.CurrentFrame.CommandBuffer, viewportData.CurrentFrame.ImageAvailableSemaphore, viewportData.CurrentFrame.RenderFinishedSemaphore, viewportData.CurrentFrame.RenderFence);
                
                VkResult result = viewportData.RenderQueue.Present(viewportData.Swapchain, viewportData.CurrentFrame.RenderFinishedSemaphore, imageIndex);
                
                if (result == VkResult.ErrorOutOfDateKHR)
                    viewportData.WantsResize = true;
                
                viewportData.FrameNumber++;
            }
        }
    }

    public void Destroy()
    {
        OnDestroy();
    }
}