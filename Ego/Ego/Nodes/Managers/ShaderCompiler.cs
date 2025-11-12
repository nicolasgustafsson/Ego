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

        bool shouldCompile = true;//ShaderNeedsCompilation<TPushConstant>(aSlangPath, spirvPath);
        
        if (shouldCompile)
        {
            var retVal = Compile<TPushConstant>(aSlangPath, aSaveToFile, aShaderType, aLayouts, aEntryPoint);

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
    
    private ShaderObject.Shader? Compile<TPushConstant>(string aPath, bool aSaveToFile, VkShaderStageFlags aShaderType, List<VkDescriptorSetLayout> aLayouts, string aEntryPoint)
    {

        try
        {
            QuickWatch watch = new($"Shader Compilation");
            //var blob = Slangc.NET.SlangCompiler.Compile(aPath, "-target", "spirv", "-entry", aEntryPoint);
            var blob = SlangCompiler2.CompileWithReflection(new []{aPath, "-target", "spirv", "-entry", aEntryPoint}, out SlangReflection reflection);
            
            Log.Info($"Successfully compiled {aPath} with entry {aEntryPoint} in {watch.GetTime().TotalMilliseconds}ms!");
            VkPushConstantRange range = new();
            range.offset = 0;
            range.stageFlags = VkShaderStageFlags.Fragment | VkShaderStageFlags.Vertex | VkShaderStageFlags.Compute | VkShaderStageFlags.MeshEXT;
            range.size = GetSize<TPushConstant>();
            ShaderObject.Shader shader = new(aShaderType, blob, aLayouts, range);
            
            if (aSaveToFile)
            {
                Save(GetSpirvPath(aPath, aEntryPoint), blob);
                File.WriteAllText(GetReflectionPath(aPath, aEntryPoint), reflection.Json);
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


//Need to create this class because if it tries to parse the json it throws nullreferenceexception
public static class SlangCompiler2
{
  private static readonly SlangSession session;

  static SlangCompiler2()
  {
    NativeLibrary.TryLoad("dxcompiler", out IntPtr _);
    string lowerInvariant = RuntimeInformation.ProcessArchitecture.ToString().ToLowerInvariant();
    if (OperatingSystem.IsWindows())
    {
      string path1 = Path.Combine(AppContext.BaseDirectory, "runtimes", "win-" + lowerInvariant, "native");
      NativeLibrary.Load(Path.Combine(path1, "slang-glslang.dll"));
      NativeLibrary.Load(Path.Combine(path1, "slang.dll"));
    }
    else if (OperatingSystem.IsLinux())
    {
      string path1 = Path.Combine(AppContext.BaseDirectory, "runtimes", "linux-" + lowerInvariant, "native");
      NativeLibrary.Load(Path.Combine(path1, "libslang-glslang.so"));
      NativeLibrary.Load(Path.Combine(path1, "libslang.so"));
    }
    else
    {
      if (!OperatingSystem.IsMacOS())
        throw new PlatformNotSupportedException("Slangc.NET is not supported on this platform.");
      string path1 = Path.Combine(AppContext.BaseDirectory, "runtimes", "osx-" + lowerInvariant, "native");
      NativeLibrary.Load(Path.Combine(path1, "libslang-glslang.dylib"));
      NativeLibrary.Load(Path.Combine(path1, "libslang.dylib"));
    }
    SlangCompiler2.session = new SlangSession();
  }

  public static byte[] Compile(params string[] args)
  {
    using (SlangCompileRequest compileRequest = SlangCompiler2.session.CreateCompileRequest())
    {
      SlangCompiler2.Compile(compileRequest, args);
      return compileRequest.GetResult();
    }
  }

  public static byte[] CompileWithReflection(string[] args, out SlangReflection reflection)
  {
    using (SlangCompileRequest compileRequest = SlangCompiler2.session.CreateCompileRequest())
    {
      SlangCompiler2.Compile(compileRequest, args);
      reflection = new SlangReflection(compileRequest.Handle, false);
      return compileRequest.GetResult();
    }
  }

  private static unsafe SlangCompileRequest Compile(SlangCompileRequest request, string[] args)
  {
    StringBuilder stringBuilder = new StringBuilder();
    GCHandle userData = GCHandle.Alloc((object) stringBuilder);
    try
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      request.SetDiagnosticCallback(SlangCompiler2.DiagnosticCallback, (void*) (IntPtr) userData);
      if (request.ProcessCommandLineArguments(args) != 0)
        throw new Exception(stringBuilder.ToString());
      return request.Compile() == 0 ? request : throw new Exception(stringBuilder.ToString());
    }
    finally
    {
      userData.Free();
    }
  }

  private static unsafe void DiagnosticCallback(char* message, void* userData)
  {
    ((StringBuilder) ((GCHandle) (IntPtr) userData).Target!).Append(Marshal.PtrToStringAnsi((IntPtr) message) ?? string.Empty);
  }
}
