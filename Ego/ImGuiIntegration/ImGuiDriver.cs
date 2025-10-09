global using VkDeviceAddress = ulong;
using System.Diagnostics;
using System.Drawing;
using System.Net.Mime;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using ImguiBindings;
using VulkanApi;
using Platform;
using Silk.NET.GLFW;
using Utilities;
using Vortice.ShaderCompiler;
using Vortice.Vulkan;
using ImFontConfig = ImguiBindings.ImFontConfig;

namespace Rendering;


internal static partial class Helpers
{
    internal static unsafe sbyte* AsBytes(this string aString)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(aString);

        fixed(byte* asBytesPtr = &bytes[0])
        {
            return (sbyte*)asBytesPtr;
        }
    }
}

public class ImGuiDriver : IGpuDestroyable
{
    private VkPipelineRenderingCreateInfo pipelineCreateInfo = new(); 
    private VkFormat format;
    
    public unsafe ImGuiDriver(Renderer aRenderer, Window aMainWindow)
    {
        var ctx = ImguiNative.CreateContext(null);
        var IO = ImguiNative.GetIO_ContextPtr(ctx);
        ImguiNative.GetIO_ContextPtr(ctx)->ConfigFlags |= (int)ImGuiConfigFlags.DockingEnable;
        ImguiNative.GetIO_ContextPtr(ctx)->ConfigFlags |= (int)ImGuiConfigFlags.ViewportsEnable;
        
        ImguiNative.SetCurrentContext(ctx);

        ImFontConfig* fontConfig = ImguiNative.ImFontConfig_ImFontConfig();

        fontConfig->RasterizerMultiply = 1.2f;
        
        var font = ImguiNative.ImFontAtlas_AddFontFromFileTTF(IO->Fonts, new string("Roboto-Regular.ttf").AsBytes(), 15f, fontConfig, null);
        //fontConfig->MergeMode = 1;

        
        List<ushort> iconRange = new(300);

        
        ImguiNative.ImGui_ImplGlfw_InitForVulkan((GLFWwindow*)aMainWindow.NativeWindow.Glfw, 1);
        var info = new ImGui_ImplVulkan_InitInfo();
        info.Instance = VulkanApi.Api.ApiInstance.VkInstance.Handle;
        info.PhysicalDevice = VulkanApi.Gpu.GpuInstance.VkPhysicalDevice.Handle;
        info.Device = VulkanApi.LogicalDevice.Device.VkDevice.Handle;
        info.QueueFamily = aRenderer.RenderQueue.QueueFamilyIndex;
        info.Queue = aRenderer.RenderQueue.VkQueue.Handle;
        info.PipelineCache = 0;
        info.DescriptorPool = 0;
        info.DescriptorPoolSize = 100;
        info.MinImageCount = 2;
        info.ImageCount = 2;
        info.UseDynamicRendering = 1;
        pipelineCreateInfo.colorAttachmentCount = 1;
        pipelineCreateInfo.depthAttachmentFormat = VkFormat.D32Sfloat;

        format = VkFormat.R16G16B16A16Sfloat;
        
        fixed(VkFormat* fixedFormat = &format)
            pipelineCreateInfo.pColorAttachmentFormats = fixedFormat;

        info.PipelineRenderingCreateInfo = pipelineCreateInfo;
        
        ImguiNative.ImGui_ImplVulkan_Init(&info);
        
        /*
        iconRange.Add(59392);
        iconRange.Add(62324);
        iconRange.Add(0);*/

        fontConfig->MergeMode = 1;
        fontConfig->DstFont = font;
        //ImguiNative.ImFontAtlas_AddFontFromFileTTF(IO->Fonts, new string("OpenFontIcons.ttf").AsBytes(), 16f, fontConfig, null);
        ImguiNative.ImFontAtlas_AddFontFromFileTTF(IO->Fonts, new string("ego-icon-font.ttf").AsBytes(), 16f, fontConfig, null);


        ImguiNative.ImFontConfig_destroy(fontConfig);
        
        aRenderer.ERenderImgui += Render;
        
        SetupThemeNew();
    }
    
    private void SetupThemeNew()
    {
        Imgui.GetStyle().FrameBorderSize = 1f;
        
        var colors = Imgui.GetStyle().Colors;
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
        colors[(int)ImGuiCol.TabSelected]              = new Vector4(0.35f, 0.39f, 0.48f, 1.00f);
        colors[(int)ImGuiCol.TabDimmed]           = new Vector4(0.23f, 0.26f, 0.32f, 1.00f);
        colors[(int)ImGuiCol.TabDimmedSelected]     = new Vector4(0.26f, 0.30f, 0.37f, 1.00f);
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
        colors[(int)ImGuiCol.NavCursor]           = new Vector4(0.98f, 0.98f, 0.98f, 1.00f);
        colors[(int)ImGuiCol.NavWindowingHighlight]  = new Vector4(1.00f, 1.00f, 1.00f, 0.70f);
        colors[(int)ImGuiCol.NavWindowingDimBg]      = new Vector4(0.80f, 0.80f, 0.80f, 0.20f);
        colors[(int)ImGuiCol.ModalWindowDimBg]       = new Vector4(0.80f, 0.80f, 0.80f, 0.35f);
            
            
        //Orange Highlights
        colors[(int)ImGuiCol.TitleBgActive]          = new Vector4(0.79f, 0.51f, 0.15f, 0.36f);
        colors[(int)ImGuiCol.ScrollbarGrabActive]    = new Vector4(0.79f, 0.51f, 0.15f, 0.36f);
        colors[(int)ImGuiCol.SliderGrabActive]       = new Vector4(0.79f, 0.51f, 0.15f, 0.66f);
        colors[(int)ImGuiCol.ButtonActive]           = new Vector4(0.63f, 0.41f, 0.12f, 1.00f);
        //colors[(int)ImGuiCol.HeaderHovered]          = new Vector4(0.76f, 0.50f, 0.15f, 1.00f);
        colors[(int)ImGuiCol.HeaderActive]           = new Vector4(0.88f, 0.91f, 0.96f, 0.37f);
        colors[(int)ImGuiCol.TabHovered]             = new Vector4(0.76f, 0.50f, 0.15f, 1.00f);
        colors[(int)ImGuiCol.TabSelected]              = new Vector4(0.72f, 0.47f, 0.13f, 1.00f);
        colors[(int)ImGuiCol.ScrollbarGrabActive]    = new Vector4(0.79f, 0.51f, 0.15f, 0.81f);
    }
    
    private Lock myLock = new();
    public void Begin()
    {
        myLock.Enter();
        
        ImguiNative.ImGui_ImplVulkan_NewFrame();
        ImguiNative.ImGui_ImplGlfw_NewFrame();
        ImguiNative.NewFrame();
    }
    
    public unsafe void End()
    {

        ImguiNative.EndFrame();
        ImguiNative.Render();
        ImguiNative.UpdatePlatformWindows();
        ImguiNative.RenderPlatformWindowsDefault(null, null);
        myLock.Exit();
    }

    public unsafe void Render(CommandBufferHandle cmd)
    {
        lock(myLock)
        {
            var drawData2 = ImguiNative.GetDrawData();
            ImguiNative.ImGui_ImplVulkan_RenderDrawData(drawData2, cmd.VkCommandBuffer.Handle, 0);
        }
    }
    
    public unsafe void OnDestroy()
    {
        
    }

    public void Destroy()
    {
        OnDestroy();
    }
}