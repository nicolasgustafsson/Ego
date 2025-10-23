global using System.Numerics;
global using VkDeviceAddress = ulong;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Rendering;
using Utilities;
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

public abstract unsafe class MeshBufferBase : IGpuDestroyable
{
    public required GpuBuffer IndexBuffer;
    public required GpuBuffer VertexBuffer;
    public VkDeviceAddress VertexBufferAddress;
    
    public void Destroy()
    {
        VertexBuffer.Destroy();
        IndexBuffer.Destroy();
    }
}

public unsafe class MeshBuffers<T> : MeshBufferBase where T : unmanaged
{
    [SetsRequiredMembers]
    public MeshBuffers(Renderer aRenderer, MemoryAllocator aAllocator, List<uint> aIndices, List<T> aVertices)
    {
        ulong vertexBufferSize = (ulong)sizeof(T) * (ulong)aVertices.Count;
        ulong indexBufferSize = (ulong)sizeof(uint) * (ulong)aIndices.Count;
        VertexBuffer = new GpuBuffer<T>(GpuBufferType.Constant, GpuBufferTransferType.Staging, (uint)aVertices.Count);

        VertexBufferAddress = VertexBuffer.GetDeviceAddress();

        IndexBuffer = new GpuBuffer<uint>(GpuBufferType.Index, GpuBufferTransferType.Staging, (uint)aIndices.Count);

        AllocatedRawBuffer stagingRawBuffer = new(vertexBufferSize + indexBufferSize, VkBufferUsageFlags.TransferSrc, VmaMemoryUsage.CpuOnly);

        byte* mappedData = (byte*)stagingRawBuffer.AllocationInfo.pMappedData;
        Span<T> destinationVertex = new(mappedData, aVertices.Count);
        Span<uint> destinationIndex = new Span<uint>(mappedData + vertexBufferSize, (int)indexBufferSize);

        aVertices.AsSpan().CopyTo(destinationVertex);
        aIndices.AsSpan().CopyTo(destinationIndex);

        aRenderer.ImmediateSubmit((cmd) =>
        {
            VkBufferCopy vertexCopy = new();
            vertexCopy.dstOffset = 0;
            vertexCopy.srcOffset = 0;
            vertexCopy.size = vertexBufferSize;
            VkApiDevice.vkCmdCopyBuffer(cmd.VkCommandBuffer, stagingRawBuffer.Buffer, VertexBuffer.MyInternalBuffer.Buffer, 1, &vertexCopy);
            
            VkBufferCopy indexCopy = new();
            indexCopy.dstOffset = 0;
            indexCopy.srcOffset = vertexBufferSize;
            indexCopy.size = indexBufferSize;
            VkApiDevice.vkCmdCopyBuffer(cmd.VkCommandBuffer, stagingRawBuffer.Buffer, IndexBuffer.MyInternalBuffer.Buffer, 1, &indexCopy);
        });

        stagingRawBuffer.Destroy();
    }
}

public struct MeshPushConstants
{
    public Matrix4x4 WorldMatrix;
    public VkDeviceAddress VertexBufferAddress;
    public VkDeviceAddress MaterialUniformBufferAddress;
}