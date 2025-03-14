using ImGuiNET;
using Rendering;
using Rendering.Materials;
using Vortice.Vulkan;
using VulkanApi;

namespace Ego;

[Node]
public partial class MeshRenderer : Node3D
{
    private string ModelPath = "Models/structure.glb";
    private MeshData? MeshData = null;
    private Material Material = null!;
    private AllocatedBuffer<MaterialBuilder.MaterialConstants> MaterialConstantsBuffer = null!;

    [Serialize] private int MeshIndex = 0;
    
    public MeshRenderer()
    {
        
    }
    
    public MeshRenderer(MeshData aMeshData)
    {
        MeshData = aMeshData;
    }

    public override void Start()
    {
        base.Start();
        MaterialConstantsBuffer = new(VkBufferUsageFlags.UniformBuffer, VmaMemoryUsage.CpuToGpu);
        
        MaterialBuilder.MaterialConstants constants = new();
        
        constants.Color = Vector4.One;
        constants.MetallicRoughness = new Vector4(1f, 0.5f, 0f, 0f);
        MaterialConstantsBuffer.SetWriteData(constants);
        
        Material = MaterialBuilder.CreateMaterial(MaterialPassType.MainColor,
            RendererApi.Renderer.WhiteImage,
            RendererApi.Renderer.DefaultLinearSampler,
            RendererApi.Renderer.WhiteImage,
            RendererApi.Renderer.DefaultLinearSampler, MaterialConstantsBuffer, 0, RendererApi.Renderer.GlobalDescriptorAllocator);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();

        MaterialConstantsBuffer.Destroy();
    }

    protected override void Update()
    {
        if (MeshData != null)
            RendererApi.RenderData.RenderMesh(new(){MyMeshData = MeshData, Material = Material, WorldMatrix = WorldMatrix}); 
    }
/*
    private void Inspect()
    {
        ImGui.SliderInt("Mesh Index", ref MeshIndex, 0, MeshCollection.Meshes.Count - 1);
    }*/
}