global using static VulkanApi.Api;
global using static Vortice.Vulkan.Vulkan;
global using Vortice.Vulkan;
using System.Runtime.InteropServices;

namespace VulkanApi;

public enum DisplayServer
{
    Windows,
    X11,
    Wayland
}

public unsafe class Api : IGpuDestroyable
{
    public static Api ApiInstance = null!;
    public VkInstance VkInstance;
    private VkDebugUtilsMessengerEXT DebugMessenger = VkDebugUtilsMessengerEXT.Null;
    
    public Api(Window aWindow, List<string> aInstanceExtensions)
    {
        vkInitialize();

        string[] InstanceExtensions = aInstanceExtensions.ToArray();
        
        VkApplicationInfo appInfo = new VkApplicationInfo
        {
            pApplicationName = aWindow.Title.ToPointer(),
            pEngineName = "Have A Great Day".ToPointer(),
            applicationVersion = VkVersion.Version_1_3,
            apiVersion = VkVersion.Version_1_3,
            engineVersion = VkVersion.Version_1_3
        };

        VkInstanceCreateInfo info = new();
        info.pApplicationInfo = &appInfo;
        
        IntPtr* extensionsToBytesArray = stackalloc IntPtr[InstanceExtensions.Length];
        for (int i = 0; i < InstanceExtensions.Length; i++)
        {
            extensionsToBytesArray[i] = Marshal.StringToHGlobalAnsi(InstanceExtensions[i]);
        }

        info.enabledExtensionCount = (uint)InstanceExtensions.Length;
        info.ppEnabledExtensionNames = (byte**)extensionsToBytesArray;
        
#if DEBUG || DEVELOPMENT
        string[] validationLayers = ["VK_LAYER_KHRONOS_validation"];
        IntPtr* layersToBytesArray = stackalloc IntPtr[validationLayers.Length];
        for (int i = 0; i < validationLayers.Length; i++)
        {
            layersToBytesArray[i] = Marshal.StringToHGlobalAnsi(validationLayers[i]);
        }

        info.enabledLayerCount = (uint)validationLayers.Length;
        info.ppEnabledLayerNames = (byte**)layersToBytesArray;      
           
#else
        info.enabledLayerCount = 0;
#endif
        
        VkDebugUtilsMessengerCreateInfoEXT debugUtilsCreateInfo = new(); 
        debugUtilsCreateInfo.messageSeverity = VkDebugUtilsMessageSeverityFlagsEXT.Error | VkDebugUtilsMessageSeverityFlagsEXT.Warning;
        debugUtilsCreateInfo.messageType = VkDebugUtilsMessageTypeFlagsEXT.Validation | VkDebugUtilsMessageTypeFlagsEXT.Performance;
        debugUtilsCreateInfo.pfnUserCallback = &DebugMessengerCallback;
        info.pNext = &debugUtilsCreateInfo;
        
        vkCreateInstance(&info, null, out VkInstance).CheckResult();
        vkLoadInstanceOnly(VkInstance);
        
        
#if DEBUG
        vkCreateDebugUtilsMessengerEXT(VkInstance, &debugUtilsCreateInfo, null, out DebugMessenger).CheckResult();
#endif
        ApiInstance = this;
    }
    
    public void Destroy()
    {
        vkDestroyDebugUtilsMessengerEXT(VkInstance, DebugMessenger);
        vkDestroyInstance(VkInstance);
    }
    
    [UnmanagedCallersOnly]
    private static uint DebugMessengerCallback(VkDebugUtilsMessageSeverityFlagsEXT messageSeverity,
        VkDebugUtilsMessageTypeFlagsEXT messageTypes,
        VkDebugUtilsMessengerCallbackDataEXT* pCallbackData,
        void* userData)
    {
        string message = new((sbyte*)pCallbackData->pMessage);
        
        Log.Info($"[Vulkan]: {messageTypes}: {messageSeverity} - {message}");
        
        return VK_FALSE;
    }
    
    public void PrintAllAvailableInstanceExtensions()
    {
        Log.Info($"--- AVAILABLE INSTANCE EXTENSIONS ---");
        uint extensionCount = 0;
        vkEnumerateInstanceExtensionProperties(null, &extensionCount, null).CheckResult();
        VkExtensionProperties* extensions = stackalloc VkExtensionProperties[(int)extensionCount];
        vkEnumerateInstanceExtensionProperties(null, &extensionCount, extensions).CheckResult();

        for (int i = 0; i < extensionCount; i++)
        {
            Log.Info($"Extension: {Helpers.GetString((sbyte*)extensions[i].extensionName)} version: {extensions[i].specVersion}");
        }

        Log.Info($"--- ---------------------------- ---");
    }

    public Surface CreateSurface(Window aWindow)
    {
        Surface surface = new(this, aWindow);

        return surface;
    }
    
    public Gpu PickGpu()
    {
        Gpu gpu = new(this);

        return gpu;
    }
}