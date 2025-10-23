using Rendering;
using Rendering.Materials;
using VulkanApi;

namespace Ego;

//Immediate mode shapes drawing!
[Node(AllowAddingToScene = false)]
public partial class Shapes : Node
{
    public struct LineDrawCommand
    {
        public Vector3 Start;
        public Vector3 End;
    }
    
    private struct LineVertex
    {
        public Vector3 Position;
        public float dummy;
        
        public LineVertex(float X, float Y, float Z)
        {
            Position.X = X;
            Position.Y = Y;
            Position.Z = Z;

            dummy = 0;
        }
    }
    
    private struct Garbage
    {
        public float PieceOfGarbage;
    }
    
    private List<LineDrawCommand> DrawCommands = new();

    private MeshData LineMesh = null!;
    private Material LineMaterial = null!;
    private GpuBuffer<Garbage> GarbageBuffer = null!;

    public override void Start()
    {
        base.Start();
        
        List<LineVertex> vertices = new(){new(0f, 0f, 0f), new(1f, 0f, 0f), new(1f, 1f, 0f), new(0f, 1f, 0f)};
        List<uint> indices = new() {0, 2, 3, 2, 0, 1 };

        GarbageBuffer = new(GpuBufferType.Uniform, GpuBufferTransferType.Direct);
        
        LineMesh = new MeshData("Line", (new[]{new GeoSurface(){StartIndex = 0, Count = 6}}).ToList(), new MeshBuffers<LineVertex>(RendererApi.Renderer, MemoryAllocator.GlobalAllocator, indices, vertices));
        DescriptorLayoutBuilder descriptorLayoutBuilder = new();
        descriptorLayoutBuilder.AddBinding(0, VkDescriptorType.UniformBuffer);

        VkDescriptorSetLayout MaterialLayout = descriptorLayoutBuilder.Build(VkShaderStageFlags.Vertex | VkShaderStageFlags.Fragment);
        var vertexShader = ShaderCompiler.LoadShaderImmediate<MeshPushConstants>("Shaders/line.slang", VkShaderStageFlags.Vertex, new() { RendererApi.Renderer.SceneDataLayout, RendererApi.Renderer.BindlessTextureLayout, MaterialLayout }, "vertex");
        var pixelShader = ShaderCompiler.LoadShaderImmediate<MeshPushConstants>("Shaders/line.slang", VkShaderStageFlags.Fragment, new() { RendererApi.Renderer.SceneDataLayout, RendererApi.Renderer.BindlessTextureLayout, MaterialLayout }, "pixel");
        LineMaterial = new Material(vertexShader!, pixelShader!, RendererApi.Renderer, GarbageBuffer);
    }

    public void DrawLine(Vector3 aStart, Vector3 aEnd)
    {
        DrawCommands.Add(new() { Start = aStart, End = aEnd });
    }

    protected override void Update()
    {
        foreach(var command in DrawCommands)
        {
            Matrix4x4 matrix = new();

            matrix[0,0] = command.Start.X;
            matrix[0,1] = command.Start.Y;
            matrix[0,2] = command.Start.Z;
            matrix[1,0] = command.End.X;
            matrix[1,1] = command.End.Y;
            matrix[1,2] = command.End.Z;
            matrix[2, 0] = 0.1f;
            
            RendererApi.RenderData.MeshRenders.Add(new() { MyMeshData = LineMesh, Material = LineMaterial, WorldMatrix = matrix });
        }
        
        DrawCommands.Clear();
    }
}