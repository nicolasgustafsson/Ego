﻿global using System.Numerics;
global using VkDeviceAddress = ulong;
using System.Runtime.InteropServices;
using Rendering;
using Utilities.Interop;
using Vortice.ShaderCompiler;
using Vortice.Vulkan;

namespace Graphics;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Vertex
{
    public Vector3 Position;
    public float Uv_X;
    public Vector3 Normal;
    public float Uv_Y;
    public Vector4 Color;
}

public unsafe class MeshBuffers
{
    public AllocatedBuffer MyIndexBuffer;
    public AllocatedBuffer MyVertexBuffer;
    public VkDeviceAddress MyVertexBufferAddress;
    
    public MeshBuffers(Renderer aRenderer, MemoryAllocator aAllocator, List<uint> aIndices, List<Vertex> aVertices)
    {
        ulong vertexBufferSize = (ulong)sizeof(Vertex) * (ulong)aVertices.Count;
        ulong indexBufferSize = (ulong)sizeof(uint) * (ulong)aIndices.Count;

        MyVertexBuffer = new AllocatedBuffer(aAllocator, vertexBufferSize, VkBufferUsageFlags.StorageBuffer | VkBufferUsageFlags.TransferDst | VkBufferUsageFlags.ShaderDeviceAddress, VmaMemoryUsage.GpuOnly);

        MyVertexBufferAddress = MyVertexBuffer.GetDeviceAddress();

        MyIndexBuffer = new AllocatedBuffer(aAllocator, indexBufferSize, VkBufferUsageFlags.IndexBuffer | VkBufferUsageFlags.TransferDst, VmaMemoryUsage.GpuOnly);

        AllocatedBuffer stagingBuffer = new(aAllocator, vertexBufferSize + indexBufferSize, VkBufferUsageFlags.TransferSrc, VmaMemoryUsage.CpuOnly);

        byte* mappedData = (byte*)stagingBuffer.MyAllocationInfo.pMappedData;
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
            Vulkan.vkCmdCopyBuffer(cmd.MyVkCommandBuffer, stagingBuffer.MyBuffer, MyVertexBuffer.MyBuffer, 1, &vertexCopy);
            
            VkBufferCopy indexCopy = new();
            indexCopy.dstOffset = 0;
            indexCopy.srcOffset = vertexBufferSize;
            indexCopy.size = indexBufferSize;
            Vulkan.vkCmdCopyBuffer(cmd.MyVkCommandBuffer, stagingBuffer.MyBuffer, MyIndexBuffer.MyBuffer, 1, &indexCopy);
        });

        stagingBuffer.Destroy(aAllocator);
    }
    
    public void Destroy(MemoryAllocator aAllocator)
    {
        MyVertexBuffer.Destroy(aAllocator);
        MyIndexBuffer.Destroy(aAllocator);
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct MeshPushConstants
{
    public Matrix4x4 WorldMatrix;
    public VkDeviceAddress VertexBufferAddress;
}