using NativeFileDialogs.Net;
using Vortice.Vulkan;
using VulkanApi;

namespace Ego;


struct PushConstants
{
    public Vector4 data1;
    public Vector4 data2;
    public Vector4 data3;
    public Vector4 data4;
}
[Node(AllowAddingToScene = false)]
public partial class ShaderCompiler : Node
{
    public string ShaderPath = "Shaders/background.slang";
    
    public void Inspect()
    {
        Imgui.BeginDisabled();
        DefaultInspect();
        Imgui.EndDisabled();

        Imgui.Text(ShaderPath);
        
        if (Imgui.Button("Select Shader"))
        if (Nfd.OpenDialog(out string? outPath, new Dictionary<string, string>()
            {
                { "Shader", "slang" },
            }) == NfdStatus.Ok && outPath != null)
        {
            ShaderPath = outPath;
        }
        
        if (Imgui.Button("Compile"))
        {
            try
            {
                ChangeBackgroundShader(ShaderPath);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                throw;
            }
        }
    }
    
    private async Task ChangeBackgroundShader(string aShaderPath)
    {
        List<VkDescriptorSetLayout> layouts = new() { RendererApi.Renderer.RenderImageDescriptorLayout };
        var shader = await LoadShader<PushConstants>(aShaderPath, VkShaderStageFlags.Compute, layouts);
        if (shader != null)
            RendererApi.Renderer.GradientShader = shader;
    }
    
    public async Task<ShaderObject.Shader?> LoadShader<TPushConstant>(string aSlangPath,  VkShaderStageFlags aShaderType, List<VkDescriptorSetLayout> aLayouts, string aEntryPoint = "main")
    {
        return await CompileIfNewer<TPushConstant>(aSlangPath, true, aShaderType, aLayouts, aEntryPoint);
    }
    
    private async Task<ShaderObject.Shader?> CompileIfNewer<TPushConstant>(string aSlangPath, bool aSaveToFile, VkShaderStageFlags aShaderType, List<VkDescriptorSetLayout> aLayouts, string aEntryPoint = "main")
    {
        await EgoTask.WorkerThread();
        var spirvPath = GetSpirvPath(aSlangPath, aEntryPoint);
        
        if (!Path.Exists(aSlangPath))
        {
            Log.Error($"Shader with path {aSlangPath} does not exist!");

            return null;
        }

        bool shouldCompile = ShaderNeedsCompilation<TPushConstant>(aSlangPath, spirvPath);
        
        if (shouldCompile)
        {
            var retVal = Compile<TPushConstant>(aSlangPath, aSaveToFile, aShaderType, aLayouts, aEntryPoint);

            return retVal;
        }


        Log.Info($"File exists already! Reusing shader...");
        
        VkPushConstantRange range = new();
        range.offset = 0;
        range.stageFlags = aShaderType;
        range.size = GetSize<TPushConstant>();
        ShaderObject.Shader shader = new(aShaderType, File.ReadAllBytes(spirvPath), aLayouts, range);
        
        await EgoTask.MainThread();
        
        return shader;
    }

    private static bool ShaderNeedsCompilation<TPushConstant>(string aSlangPath, string spirvPath)
    {
        bool spirvExists = Path.Exists(spirvPath);
        bool slangFileIsNewer = false;

        if (spirvExists)
            slangFileIsNewer = File.GetLastWriteTime(aSlangPath) > File.GetLastWriteTime(spirvPath);

        bool shouldCompile = !spirvExists || slangFileIsNewer;
        return shouldCompile;
    }

    private async Task Save(string aPath, byte[] aBytes)
    {
        await EgoTask.WorkerThread();

        File.WriteAllBytes(aPath, aBytes);

        Log.Info($"Shader saved to {aPath}!");
    }
    
    private string GetSpirvPath(string aPath, string aEntryPoint)
    {
        return Path.GetFileNameWithoutExtension(aPath) + $"-{aEntryPoint}.spirv";
        
    }
    
    unsafe uint GetSize<TPushConstant>()
    {
        return (uint)sizeof(TPushConstant);
    }
    
    private ShaderObject.Shader? Compile<TPushConstant>(string aPath, bool aSaveToFile, VkShaderStageFlags aShaderType, List<VkDescriptorSetLayout> aLayouts, string aEntryPoint)
    {

        try
        {
            QuickWatch watch = new($"Shader Compilation");
            var blob = Slangc.NET.SlangCompiler.Compile(aPath, "-target", "spirv", "-entry", aEntryPoint);
            Log.Info($"Successfully compiled {aPath} in {watch.GetTime().TotalMilliseconds}ms!");
            VkPushConstantRange range = new();
            range.offset = 0;
            range.stageFlags = aShaderType;
            range.size = GetSize<TPushConstant>();
            ShaderObject.Shader shader = new(aShaderType, blob, aLayouts, range);
            
            if (aSaveToFile)
            {
                Save(GetSpirvPath(aPath, aEntryPoint), blob);
            }
            return shader;
        }
        catch (Exception e)
        {
            Log.Error($"{e.Message}");
        }

        return null;
    }
}