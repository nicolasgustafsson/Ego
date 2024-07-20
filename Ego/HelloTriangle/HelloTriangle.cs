using Evergine.Bindings.Vulkan;
using GLFW;

namespace KHRRTXHelloTriangle
{
    public unsafe partial class HelloTriangle
    {
        const uint WIDTH = 800;
        const uint HEIGHT = 600;
        private NativeWindow Window;

        private void InitWindow()
        {
            
            Window = new NativeWindow(800, 600, "Hello World!");
            /*window = new Form();
            window.Text = "Vulkan Triangle Rasterization";
            window.Size = new System.Drawing.Size((int)WIDTH, (int)HEIGHT);
            window.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            window.Show();*/
        }

        private void InitVulkan()
        {
            CreateInstance();

            SetupDebugMessenger();

            CreateSurface();

            PickPhysicalDevice();

            CreateLogicalDevice();

            CreateSwapChain();

            CreateImageViews();

            CreateRenderPass();

            CreateGraphicsPipeline();

            CreateFramebuffers();

            CreateCommandPool();

            CreateCommandBuffers();

            CreateSemaphores();
        }

        private void MainLoop()
        {
            while (!Window.IsClosing)
            {
                Window.SwapBuffers();
                Glfw.PollEvents();
                DrawFrame();
            }

            Helpers.CheckErrors(VulkanNative.vkDeviceWaitIdle(this.device));
        }

        private void CleanUp()
        {
            VulkanNative.vkDestroySemaphore(this.device, this.renderFinishedSemaphore, null);
            VulkanNative.vkDestroySemaphore(this.device, this.imageAvailableSemaphore, null);

            VulkanNative.vkDestroyCommandPool(this.device, this.commandPool, null);

            foreach (var framebuffer in this.swapChainFramebuffers)
            {
                VulkanNative.vkDestroyFramebuffer(this.device, framebuffer, null);
            }

            VulkanNative.vkDestroyPipeline(this.device, this.graphicsPipeline, null);

            VulkanNative.vkDestroyPipelineLayout(this.device, this.pipelineLayout, null);

            VulkanNative.vkDestroyRenderPass(this.device, this.renderPass, null);

            foreach (var imageView in this.swapChainImageViews)
            {
                VulkanNative.vkDestroyImageView(this.device, imageView, null);
            }

            VulkanNative.vkDestroySwapchainKHR(this.device, this.swapChain, null);

            VulkanNative.vkDestroyDevice(this.device, null);

            this.DestroyDebugMessenger();

            VulkanNative.vkDestroySurfaceKHR(this.instance, this.surface, null);

            VulkanNative.vkDestroyInstance(this.instance, null);
        }

        public void Run()
        {
            this.InitWindow();

            this.InitVulkan();

            this.MainLoop();

            this.CleanUp();
        }   
    }
}
