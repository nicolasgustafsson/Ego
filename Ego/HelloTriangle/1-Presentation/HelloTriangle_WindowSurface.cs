﻿using System.Diagnostics;
using Evergine.Bindings.Vulkan;

namespace KHRRTXHelloTriangle
{
    public unsafe partial class HelloTriangle
    {
        private VkSurfaceKHR surface;

        private void CreateSurface()
        {
            VkWin32SurfaceCreateInfoKHR createInfo = new VkWin32SurfaceCreateInfoKHR()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR,
                hwnd = Window.Hwnd,
                hinstance = System.Diagnostics.Process.GetCurrentProcess().Handle,
            };

            fixed (VkSurfaceKHR* surfacePtr = &surface)
            {
                Helpers.CheckErrors(VulkanNative.vkCreateWin32SurfaceKHR(instance, &createInfo, null, surfacePtr));
            }
        }
    }
}
