using System.Runtime.InteropServices;
using System.Text;
using NativeFileDialogs.Net;
using Slangc.NET;
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
    public string ShaderPath = "Shaders/meshVert.slang";
    [Inspect] public VkShaderStageFlags ShaderType = VkShaderStageFlags.Vertex;
    public Dictionary<string, ShaderObject.Shader> CompiledShaders = new();
    
    public void Inspect()
    {
        DefaultInspect();

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
                CreateShader();
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                throw;
            }
        }
    }
    
    private async Task CreateShader()
    {
        DescriptorLayoutBuilder descriptorLayoutBuilder = new();
        descriptorLayoutBuilder.AddBinding(0, VkDescriptorType.UniformBuffer);
        descriptorLayoutBuilder.AddBinding(1, VkDescriptorType.CombinedImageSampler);
        descriptorLayoutBuilder.AddBinding(2, VkDescriptorType.CombinedImageSampler);

        var MaterialLayout = descriptorLayoutBuilder.Build(VkShaderStageFlags.Vertex | VkShaderStageFlags.Fragment);
        
        List<VkDescriptorSetLayout> layouts = new() { RendererApi.Renderer.SceneDataLayout, RendererApi.Renderer.BindlessTextureLayout, MaterialLayout };
 
        var shader = await LoadShader<DefaultPushConstants>(ShaderPath, ShaderType, layouts);
    }
    
    public async Task<ShaderObject.Shader?> LoadShader<TPushConstant>(string aSlangPath,  VkShaderStageFlags aShaderType, List<VkDescriptorSetLayout> aLayouts, string aEntryPoint = "main")
    {
        return await CompileIfNewer<TPushConstant>(aSlangPath, true, aShaderType, aLayouts, aEntryPoint);
    }
    
    public async Task<ShaderObject.Shader?> LoadShader(string aSlangPath,  VkShaderStageFlags aShaderType, List<VkDescriptorSetLayout> aLayouts, string aEntryPoint = "main")
    {
        return await LoadShader<DefaultPushConstants>(aSlangPath, aShaderType, aLayouts, aEntryPoint);
    }
    
    public ShaderObject.Shader? LoadShaderImmediate(string aSlangPath,  VkShaderStageFlags aShaderType, List<VkDescriptorSetLayout> aLayouts, string aEntryPoint = "main")
    {
        return LoadShaderImmediate<DefaultPushConstants>(aSlangPath, aShaderType, aLayouts, aEntryPoint);
    }
    
    public ShaderObject.Shader? LoadShaderImmediate<TPushConstant>(string aSlangPath,  VkShaderStageFlags aShaderType, List<VkDescriptorSetLayout> aLayouts, string aEntryPoint = "main")
    {
        return CompileIfNewerImmediate<TPushConstant>(aSlangPath, true, aShaderType, aLayouts, aEntryPoint);
    }
    
    private async Task<ShaderObject.Shader?> CompileIfNewer<TPushConstant>(string aSlangPath, bool aSaveToFile, VkShaderStageFlags aShaderType, List<VkDescriptorSetLayout> aLayouts, string aEntryPoint = "main")
    {
        await EgoTask.WorkerThread();
        
        var shader = CompileIfNewerImmediate<TPushConstant>(aSlangPath, aSaveToFile, aShaderType, aLayouts, aEntryPoint);
        
        await EgoTask.MainThread();
        
        return shader;
    }
    
    private ShaderObject.Shader? CompileIfNewerImmediate<TPushConstant>(string aSlangPath, bool aSaveToFile, VkShaderStageFlags aShaderType, List<VkDescriptorSetLayout> aLayouts, string aEntryPoint = "main")
    {
        var spirvPath = GetSpirvPath(aSlangPath, aEntryPoint);
        
        if (!Path.Exists(aSlangPath))
        {
            Log.Error($"Shader with path {aSlangPath} does not exist!");
            return null;
        }

        bool shouldCompile = ShaderNeedsCompilation<TPushConstant>(aSlangPath, spirvPath);
        
        if (shouldCompile)
        {
            var retVal = Compile<TPushConstant>(aSlangPath, aSaveToFile, aShaderType, aLayouts, aEntryPoint, true); 

            return retVal;
        }
        
        if (CompiledShaders.TryGetValue(spirvPath, out ShaderObject.Shader? value))
            return value;

        Log.Info($"File {aSlangPath} with entry {aEntryPoint} exists already! Reusing shader...");
        
        VkPushConstantRange range = new();
        range.offset = 0;
        range.stageFlags = VkShaderStageFlags.Vertex | VkShaderStageFlags.Fragment | VkShaderStageFlags.Compute | VkShaderStageFlags.MeshEXT;
        range.size = GetSize<TPushConstant>();
        ShaderObject.Shader shader = new(aShaderType, File.ReadAllBytes(spirvPath), aLayouts, range);

        CompiledShaders.Add(spirvPath, shader);

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
    
    private string GetReflectionPath(string aPath, string aEntryPoint)
    {
        return Path.GetFileNameWithoutExtension(aPath) + $"-{aEntryPoint}-reflection.json";
    }
    
    unsafe uint GetSize<TPushConstant>()
    {
        return (uint)sizeof(TPushConstant);
    }
    
    private ShaderObject.Shader? Compile<TPushConstant>(string aPath, bool aSaveToFile, VkShaderStageFlags aShaderType, List<VkDescriptorSetLayout> aLayouts, string aEntryPoint, bool aReflect)
    {

        try
        {
            QuickWatch watch = new($"Shader Compilation");

            SlangReflection? reflection = null;
            
            byte[] blob;
            if (aReflect)
            {
                blob = SlangCompiler.CompileWithReflection(new []{aPath, "-target", "spirv", "-entry", aEntryPoint}, out SlangReflection outReflection);
                outReflection.Deserialize();

                reflection = outReflection;
            }
            else
            {
                blob = SlangCompiler.Compile(aPath, "-target", "spirv", "-entry", aEntryPoint);
            }
            
            Log.Info($"Successfully compiled {aPath} with entry {aEntryPoint} in {watch.GetTime().TotalMilliseconds}ms!");
            VkPushConstantRange range = new();
            range.offset = 0;
            range.stageFlags = VkShaderStageFlags.Fragment | VkShaderStageFlags.Vertex | VkShaderStageFlags.Compute | VkShaderStageFlags.MeshEXT;
            range.size = GetSize<TPushConstant>();
            ShaderObject.Shader shader = new(aShaderType, blob, aLayouts, range);

            if (reflection != null)
                shader.BuildUniformTable(reflection);
            
            if (aSaveToFile)
            {
                //We currently don't save uniform table so no saving:(
                //Save(GetSpirvPath(aPath, aEntryPoint), blob);
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