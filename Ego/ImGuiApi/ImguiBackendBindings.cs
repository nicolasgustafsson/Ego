using System.Runtime.InteropServices;
using Vortice.Vulkan;

namespace ImguiBindings
{
    public partial struct GLFWwindow
    {
    }

    public partial struct GLFWwindow
    {
    }

    public partial struct GLFWmonitor
    {
    }

    public partial struct GLFWmonitor
    {
    }

    public unsafe partial struct ImGui_ImplVulkan_InitInfo
    {
        [NativeTypeName("uint32_t")]
        public uint ApiVersion;
        
        [NativeTypeName("VkInstance")]
        public nint Instance;

        [NativeTypeName("VkPhysicalDevice")]
        public nint PhysicalDevice;

        [NativeTypeName("VkDevice")]
        public nint Device;

        [NativeTypeName("uint32_t")]
        public uint QueueFamily;

        [NativeTypeName("VkQueue")]
        public nint Queue;

        [NativeTypeName("VkDescriptorPool")]
        public nint DescriptorPool;

        [NativeTypeName("uint32_t")]
        public uint DescriptorPoolSize;

        [NativeTypeName("uint32_t")]
        public uint MinImageCount;

        [NativeTypeName("uint32_t")]
        public uint ImageCount;

        [NativeTypeName("VkPipelineCache")]
        public nint PipelineCache;

        [NativeTypeName("VkRenderPass")]
        public nint RenderPass;

        [NativeTypeName("uint32_t")]
        public uint Subpass;

        public VkSampleCountFlags MSAASamples;

        [NativeTypeName("_Bool")]
        public byte UseDynamicRendering;

        [NativeTypeName("VkPipelineRenderingCreateInfoKHR")]
        public VkPipelineRenderingCreateInfo PipelineRenderingCreateInfo;

        [NativeTypeName("const VkAllocationCallbacks *")]
        public VkAllocationCallbacks* Allocator;

        [NativeTypeName("void (*)(VkResult)")]
        public delegate* unmanaged[Cdecl]<VkResult, void> CheckVkResultFn;
        

        [NativeTypeName("VkDeviceSize")]
        public ulong MinAllocationSize;
    }

    public unsafe partial struct ImGui_ImplVulkan_MainPipelineCreateInfo
    {
        /*
        [NativeTypeName("VkRenderPass")]
        public VkRenderPass_T* RenderPass;

        [NativeTypeName("uint32_t")]
        public uint Subpass;

        public VkSampleCountFlagBits MSAASamples;

        [NativeTypeName("VkPipelineRenderingCreateInfoKHR")]
        public VkPipelineRenderingCreateInfo PipelineRenderingCreateInfo;*/
    }

    
    public unsafe partial struct ImGui_ImplVulkan_RenderState
    {
        /*
        [NativeTypeName("VkCommandBuffer")]
        public VkCommandBuffer_T* CommandBuffer;

        [NativeTypeName("VkPipeline")]
        public VkPipeline_T* Pipeline;

        [NativeTypeName("VkPipelineLayout")]
        public VkPipelineLayout_T* PipelineLayout;*/
    }

    public unsafe partial struct ImGui_ImplVulkanH_Frame
    {
        /*
        [NativeTypeName("VkCommandPool")]
        public VkCommandPool_T* CommandPool;

        [NativeTypeName("VkCommandBuffer")]
        public VkCommandBuffer_T* CommandBuffer;

        [NativeTypeName("VkFence")]
        public VkFence_T* Fence;

        [NativeTypeName("VkImage")]
        public VkImage_T* Backbuffer;

        [NativeTypeName("VkImageView")]
        public VkImageView_T* BackbufferView;

        [NativeTypeName("VkFramebuffer")]
        public VkFramebuffer_T* Framebuffer;
*/
    }

    public unsafe partial struct ImGui_ImplVulkanH_FrameSemaphores
    {
        /*
        [NativeTypeName("VkSemaphore")]
        public VkSemaphore_T* ImageAcquiredSemaphore;

        [NativeTypeName("VkSemaphore")]
        public VkSemaphore_T* RenderCompleteSemaphore;*/
    }

    public unsafe partial struct ImVector_ImGui_ImplVulkanH_Frame
    {
        public int Size;

        public int Capacity;

        public ImGui_ImplVulkanH_Frame* Data;
    }

    public unsafe partial struct ImVector_ImGui_ImplVulkanH_FrameSemaphores
    {
        public int Size;

        public int Capacity;

        public ImGui_ImplVulkanH_FrameSemaphores* Data;
    }

    
    public unsafe partial struct ImGui_ImplVulkanH_Window
    {
        public int Width;

        public int Height;

        [NativeTypeName("VkSwapchainKHR")]
        public nint Swapchain;

        [NativeTypeName("VkSurfaceKHR")]
        public nint Surface;

        public VkSurfaceFormatKHR SurfaceFormat;

        public VkPresentModeKHR PresentMode;

        [NativeTypeName("VkRenderPass")]
        public nint RenderPass;

        [NativeTypeName("_Bool")]
        public byte UseDynamicRendering;

        [NativeTypeName("_Bool")]
        public byte ClearEnable;

        public VkClearValue ClearValue;

        [NativeTypeName("uint32_t")]
        public uint FrameIndex;

        [NativeTypeName("uint32_t")]
        public uint ImageCount;

        [NativeTypeName("uint32_t")]
        public uint SemaphoreCount;

        [NativeTypeName("uint32_t")]
        public uint SemaphoreIndex;

        public ImVector_ImGui_ImplVulkanH_Frame Frames;

        public ImVector_ImGui_ImplVulkanH_FrameSemaphores FrameSemaphores;
    }

    public static unsafe partial class ImguiNative
    {
        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGui_ImplGlfw_InitForOpenGL(GLFWwindow* window, [NativeTypeName("_Bool")] byte install_callbacks);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGui_ImplGlfw_InitForVulkan(GLFWwindow* window, [NativeTypeName("_Bool")] byte install_callbacks);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGui_ImplGlfw_InitForOther(GLFWwindow* window, [NativeTypeName("_Bool")] byte install_callbacks);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_Shutdown();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_NewFrame();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_InstallCallbacks(GLFWwindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_RestoreCallbacks(GLFWwindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_SetCallbacksChainForAllWindows([NativeTypeName("_Bool")] byte chain_for_all_windows);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_WindowFocusCallback(GLFWwindow* window, int focused);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_CursorEnterCallback(GLFWwindow* window, int entered);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_CursorPosCallback(GLFWwindow* window, double x, double y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_MouseButtonCallback(GLFWwindow* window, int button, int action, int mods);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_ScrollCallback(GLFWwindow* window, double xoffset, double yoffset);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_KeyCallback(GLFWwindow* window, int key, int scancode, int action, int mods);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_CharCallback(GLFWwindow* window, [NativeTypeName("unsigned int")] uint c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_MonitorCallback(GLFWmonitor* monitor, int @event);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplGlfw_Sleep(int milliseconds);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ImGui_ImplGlfw_GetContentScaleForWindow(GLFWwindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ImGui_ImplGlfw_GetContentScaleForMonitor(GLFWmonitor* monitor);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGui_ImplVulkan_Init(ImGui_ImplVulkan_InitInfo* info);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplVulkan_Shutdown();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplVulkan_NewFrame();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplVulkan_RenderDrawData(ImDrawData* draw_data, [NativeTypeName("VkCommandBuffer")] nint command_buffer, [NativeTypeName("VkPipeline")] nint pipeline);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplVulkan_SetMinImageCount([NativeTypeName("uint32_t")] uint min_image_count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplVulkan_CreateMainPipeline([NativeTypeName("const ImGui_ImplVulkan_MainPipelineCreateInfo")] ImGui_ImplVulkan_MainPipelineCreateInfo info);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplVulkan_UpdateTexture(ImTextureData* tex);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("VkDescriptorSet")]
        public static extern nint ImGui_ImplVulkan_AddTexture([NativeTypeName("VkSampler")] nint sampler, [NativeTypeName("VkImageView")] nint image_view, VkImageLayout image_layout);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplVulkan_RemoveTexture([NativeTypeName("VkDescriptorSet")] nint descriptor_set);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGui_ImplVulkan_LoadFunctions([NativeTypeName("uint32_t")] uint api_version, [NativeTypeName("PFN_vkVoidFunction (*)(const char *, void *)")] delegate* unmanaged[Cdecl]<sbyte*, void*, delegate* unmanaged[Stdcall]<void>> loader_func, void* user_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplVulkanH_CreateOrResizeWindow([NativeTypeName("VkInstance")] nint instance, [NativeTypeName("VkPhysicalDevice")] nint physical_device, [NativeTypeName("VkDevice")] nint device, ImGui_ImplVulkanH_Window* wd, [NativeTypeName("uint32_t")] uint queue_family, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* allocator, int w, int h, [NativeTypeName("uint32_t")] uint min_image_count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGui_ImplVulkanH_DestroyWindow([NativeTypeName("VkInstance")] nint instance, [NativeTypeName("VkDevice")] nint device, ImGui_ImplVulkanH_Window* wd, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* allocator);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern VkSurfaceFormatKHR ImGui_ImplVulkanH_SelectSurfaceFormat([NativeTypeName("VkPhysicalDevice")] nint physical_device, [NativeTypeName("VkSurfaceKHR")] nint surface, [NativeTypeName("const VkFormat *")] VkFormat* request_formats, int request_formats_count, VkColorSpaceKHR request_color_space);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern VkPresentModeKHR ImGui_ImplVulkanH_SelectPresentMode([NativeTypeName("VkPhysicalDevice")] nint physical_device, [NativeTypeName("VkSurfaceKHR")] nint surface, [NativeTypeName("const VkPresentModeKHR *")] VkPresentModeKHR* request_modes, int request_modes_count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("VkPhysicalDevice")]
        public static extern nint ImGui_ImplVulkanH_SelectPhysicalDevice([NativeTypeName("VkInstance")] nint instance);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint ImGui_ImplVulkanH_SelectQueueFamilyIndex([NativeTypeName("VkPhysicalDevice")] nint physical_device);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ImGui_ImplVulkanH_GetMinImageCountFromPresentMode(VkPresentModeKHR present_mode);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGui_ImplVulkanH_Window* ImGui_ImplVulkanH_Window_ImGui_ImplVulkanH_Window();
        
    }
}
