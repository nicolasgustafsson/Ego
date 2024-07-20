global using System.Numerics;
global using VkDeviceAddress = ulong;
using System.Runtime.InteropServices;
using Rendering;
using Utilities.Interop;
using Vortice.ShaderCompiler;
using Vortice.Vulkan;

namespace VulkanApi;

public struct Vertex
{
    public Vector3 Position;
    public float Uv_X;
    public Vector3 Normal;
    public float Uv_Y;
    public Vector4 Color;
}

public unsafe class MeshBuffers : IGpuDestroyable
{
    public AllocatedRawBuffer IndexRawBuffer;
    public AllocatedRawBuffer VertexRawBuffer;
    public VkDeviceAddress VertexBufferAddress;
    
    public MeshBuffers(Renderer aRenderer, MemoryAllocator aAllocator, List<uint> aIndices, List<Vertex> aVertices)
    {
        ulong vertexBufferSize = (ulong)sizeof(Vertex) * (ulong)aVertices.Count;
        ulong indexBufferSize = (ulong)sizeof(uint) * (ulong)aIndices.Count;

        VertexRawBuffer = new AllocatedRawBuffer( vertexBufferSize, VkBufferUsageFlags.StorageBuffer | VkBufferUsageFlags.TransferDst | VkBufferUsageFlags.ShaderDeviceAddress, VmaMemoryUsage.GpuOnly);

        VertexBufferAddress = VertexRawBuffer.GetDeviceAddress();

        IndexRawBuffer = new AllocatedRawBuffer(indexBufferSize, VkBufferUsageFlags.IndexBuffer | VkBufferUsageFlags.TransferDst, VmaMemoryUsage.GpuOnly);

        AllocatedRawBuffer stagingRawBuffer = new(vertexBufferSize + indexBufferSize, VkBufferUsageFlags.TransferSrc, VmaMemoryUsage.CpuOnly);

        byte* mappedData = (byte*)stagingRawBuffer.AllocationInfo.pMappedData;
        Span<Vertex> destinationVertex = new(mappedData, aVertices.Count);
        Span<uint> destinationIndex = new Span<uint>(mappedData + vertexBufferSize, (int)indexBufferSize);

        aVertices.AsSpan().CopyTo(destinationVertex);
        aIndices.AsSpan().CopyTo(destinationIndex);

        aRenderer.ImmediateSubmit((cmd) =>
        {
            VkBufferCopy vertexCopy = new();
            vertexCopy.dstOffset = 0;
            vertexCopy.srcOffset = 0;
            vertexCopy.size = vertexBufferSize;
            Vortice.Vulkan.Vulkan.vkCmdCopyBuffer(cmd.VkCommandBuffer, stagingRawBuffer.Buffer, VertexRawBuffer.Buffer, 1, &vertexCopy);
            
            VkBufferCopy indexCopy = new();
            indexCopy.dstOffset = 0;
            indexCopy.srcOffset = vertexBufferSize;
            indexCopy.size = indexBufferSize;
            Vortice.Vulkan.Vulkan.vkCmdCopyBuffer(cmd.VkCommandBuffer, stagingRawBuffer.Buffer, IndexRawBuffer.Buffer, 1, &indexCopy);
        });

        stagingRawBuffer.Destroy();
    }
    
    public void Destroy()
    {
        VertexRawBuffer.Destroy();
        IndexRawBuffer.Destroy();
    }
}

public struct MeshPushConstants
{
    public Matrix4x4 WorldMatrix;
    public VkDeviceAddress VertexBufferAddress;
}