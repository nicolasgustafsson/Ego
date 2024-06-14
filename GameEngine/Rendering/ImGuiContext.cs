using Graphics;
using ImGuiNET;
using Vortice.Vulkan;

namespace Rendering;

public class ImGuiContext : IGpuDestroyable
{
    private Image myFontTexture;
    private DescriptorAllocatorGrowable myDescriptorAllocator;
    private VkDescriptorSetLayout myLayout;
    private VkDescriptorSet myDescriptorSet;
    private Sampler mySampler;
    private GraphicsPipeline myPipeline;
    private Window myWindow;

    private List<AllocatedBuffer<ImDrawVert>> myOldVBuffers = new();
    private List<AllocatedBuffer<ushort>> myOldIBuffers = new();
    private VkDescriptorSetLayout myVertexBufferLayout;
    private VkDescriptorSetLayout myIndexBufferLayout;
    private VkDescriptorSet myVertexDescriptor;
    private VkDescriptorSet myIndexDescriptor;

    public unsafe ImGuiContext(Renderer aRenderer, Window aWindow)
    {
        myWindow = aWindow;
        var context = ImGui.CreateContext();
        ImGui.SetCurrentContext(context);

        var io = ImGui.GetIO();
        
        io.Fonts.AddFontDefault();
        
        io.Fonts.GetTexDataAsRGBA32(out nint pixels, out var width, out var height);
        
        myFontTexture = new Image(aRenderer, (byte*)pixels.ToPointer(), VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled | VkImageUsageFlags.TransferDst, new VkExtent3D(width, height, 1), false);
        myDescriptorAllocator = new DescriptorAllocatorGrowable();
        myDescriptorAllocator.InitPool(100, [new(ratio: 1000, type: VkDescriptorType.CombinedImageSampler)]);

        {
            DescriptorLayoutBuilder builder = new();
            builder.AddBinding(0, VkDescriptorType.StorageBuffer);
            myVertexBufferLayout = builder.Build(VkShaderStageFlags.Vertex);
            myVertexDescriptor = myDescriptorAllocator.Allocate(myVertexBufferLayout);
        }
        
        {
            DescriptorLayoutBuilder builder = new();
            builder.AddBinding(0, VkDescriptorType.StorageBuffer);
            myIndexBufferLayout = builder.Build(VkShaderStageFlags.Vertex);
            myIndexDescriptor = myDescriptorAllocator.Allocate(myIndexBufferLayout);
        }
        
        mySampler = new(VkFilter.Linear);

        DescriptorLayoutBuilder layoutBuilder = new();
        layoutBuilder.AddBinding(0, VkDescriptorType.CombinedImageSampler);
        myLayout = layoutBuilder.Build(VkShaderStageFlags.Fragment);

        myDescriptorSet = myDescriptorAllocator.Allocate(myLayout);
        
        {
            DescriptorWriter writer = new();
            writer.WriteImage(0, myFontTexture.MyImageView, mySampler, VkImageLayout.ShaderReadOnlyOptimal, VkDescriptorType.CombinedImageSampler);
            writer.UpdateSet(myDescriptorSet);
        }

        
        //io.Fonts.SetTexID((nint)myDescriptorSet.Handle);
        io.Fonts.SetTexID((nint)myDescriptorSet.Handle);
        
        myPipeline = new GraphicsPipeline.GraphicsPipelineBuilder()
            .AddPushConstant(new VkPushConstantRange { offset = 0, size = sizeof(float) * 4 + sizeof(VkDeviceAddress), stageFlags = VkShaderStageFlags.Vertex })
            .AddLayout(myLayout)
            .SetBlendMode(BlendMode.Alpha)
            .DisableMultisampling()
            .SetVertexShader("Shaders/imguiVert.spv")
            .SetFragmentShader("Shaders/imguiFrag.spv")
            .SetTopology(VkPrimitiveTopology.TriangleList)
            .SetPolygonMode(VkPolygonMode.Fill)
            .DisableDepthTest()
            .SetDepthFormat(VkFormat.D32Sfloat)
            .Build();

        SetKeyMappings();
        SetFrameData();
    }
    
    private void SetKeyMappings()
    {
        /*
        var io = ImGui.GetIO();
        io.KeyMap[(int)ImGuiKey.Tab] = (int)Key.Tab;
        io.KeyMap[(int)ImGuiKey.LeftArrow] = (int)Key.Left;
        io.KeyMap[(int)ImGuiKey.RightArrow] = (int)Key.Right;
        io.KeyMap[(int)ImGuiKey.UpArrow] = (int)Key.Up;
        io.KeyMap[(int)ImGuiKey.DownArrow] = (int)Key.Down;
        io.KeyMap[(int)ImGuiKey.PageUp] = (int)Key.PageUp;
        io.KeyMap[(int)ImGuiKey.PageDown] = (int)Key.PageDown;
        io.KeyMap[(int)ImGuiKey.Home] = (int)Key.Home;
        io.KeyMap[(int)ImGuiKey.End] = (int)Key.End;
        io.KeyMap[(int)ImGuiKey.Delete] = (int)Key.Delete;
        io.KeyMap[(int)ImGuiKey.Backspace] = (int)Key.Backspace;
        io.KeyMap[(int)ImGuiKey.Enter] = (int)Key.Enter;
        io.KeyMap[(int)ImGuiKey.Escape] = (int)Key.Escape;
        io.KeyMap[(int)ImGuiKey.A] = (int)Key.A;
        io.KeyMap[(int)ImGuiKey.C] = (int)Key.C;
        io.KeyMap[(int)ImGuiKey.V] = (int)Key.V;
        io.KeyMap[(int)ImGuiKey.X] = (int)Key.X;
        io.KeyMap[(int)ImGuiKey.Y] = (int)Key.Y;
        io.KeyMap[(int)ImGuiKey.Z] = (int)Key.Z;*/
    }
    
    //private void OnKeyChar(IKeyboard kb, char @char) => _pressedChars.Add(@char);
    
    private void SetFrameData(float deltaTime = 1f/60f)
    {
        var io = ImGui.GetIO();

        Vector2 windowSize = new Vector2{X = myWindow.GetWindowSize().width, Y = myWindow.GetWindowSize().height};
        Vector2 framebufferSize = new Vector2{X = myWindow.GetFramebufferSize().width, Y = myWindow.GetFramebufferSize().height};
        
        io.DisplaySize = new Vector2(myWindow.GetFramebufferSize().width, myWindow.GetFramebufferSize().height);
        if (windowSize is {X: > 0, Y: > 0})
            io.DisplayFramebufferScale = new Vector2(framebufferSize.X / (float) windowSize.X,
                framebufferSize.Y / (float) windowSize.Y);
        
        io.DeltaTime = deltaTime;
    } 
    
    public void Render(CommandBuffer cmd)
    {
        ImGui.NewFrame();
        ImGui.ShowAboutWindow();
        //ImGui.Begin("");
        //ImGui.Text("Hello world!");
        //ImGui.End();
        
        
        ImGui.EndFrame();
        ImGui.Render();

        RenderDrawData(cmd, ImGui.GetDrawData());
    }
    
    struct imguiPushConstants
    {
        public Vector2 Scale;
        public Vector2 Translate;
        public VkDeviceAddress VertexBuffer;
    }

    private unsafe void RenderDrawData(CommandBuffer cmd, ImDrawDataPtr aDrawDataPtr)
    {
        
        if (myOldIBuffers.Count > 5)
        {
            myOldIBuffers[0].Destroy();
            myOldIBuffers.RemoveAt(0);
        }
        if (myOldVBuffers.Count > 5)
        {
            myOldVBuffers[0].Destroy();
            myOldVBuffers.RemoveAt(0);
        }
        
        var framebufferWidth = (int) aDrawDataPtr.DisplaySize.X * aDrawDataPtr.FramebufferScale.X;
        var frameBufferHeight = (int) aDrawDataPtr.DisplaySize.Y * aDrawDataPtr.FramebufferScale.Y;
        if (framebufferWidth <= 0 || frameBufferHeight <= 0 || aDrawDataPtr.TotalVtxCount == 0 || aDrawDataPtr.TotalIdxCount == 0) 
            return;

        AllocatedBuffer<ushort> indexBuffer = new(VkBufferUsageFlags.IndexBuffer, VmaMemoryUsage.CpuToGpu, (uint)aDrawDataPtr.TotalIdxCount);
        AllocatedBuffer<ImDrawVert> vertexBuffer = new(VkBufferUsageFlags.StorageBuffer | VkBufferUsageFlags.ShaderDeviceAddress, VmaMemoryUsage.CpuToGpu, (uint)aDrawDataPtr.TotalVtxCount);

        ulong vtxOffset = 0;
        ulong idxOffset = 0;
        
        for(int i = 0; i < aDrawDataPtr.CmdListsCount; i++)
        {
            ref var cmdList = ref aDrawDataPtr.CmdLists[i];
            ulong vtxChunkSize = (ulong) cmdList.VtxBuffer.Size * (ulong) sizeof(ImDrawVert);
            ulong idxChunkSize = (ulong) cmdList.IdxBuffer.Size * sizeof(ushort);

            Span<ImDrawVert> vertices = new Span<ImDrawVert>(cmdList.VtxBuffer.Data.ToPointer(), cmdList.VtxBuffer.Size);
            Span<ushort> indices = new Span<ushort>(cmdList.IdxBuffer.Data.ToPointer(), cmdList.IdxBuffer.Size);

            vertexBuffer.SetWriteData(vertices, vtxOffset);
            indexBuffer.SetWriteData(indices, idxOffset);

            /*{
                DescriptorWriter writer = new();
                writer.WriteBuffer(0, vertexBuffer.MyBuffer, (ulong)sizeof(ImDrawVert) * (ulong)cmdList.VtxBuffer.Size, vtxOffset, VkDescriptorType.StorageBuffer);
                writer.UpdateSet(myVertexDescriptor);
            }*/
            
            vtxOffset += vtxChunkSize;
            idxOffset += idxChunkSize;
            
            /*{
                DescriptorWriter writer = new();
                writer.WriteBuffer(0, indexBuffer.MyBuffer, (ulong)sizeof(SceneData), 0, VkDescriptorType.StorageBuffer);
                writer.UpdateSet(myIndexDescriptor);
            }*/
            
        }
        

        cmd.BindPipeline(myPipeline);
        cmd.BindDescriptorSet(myPipeline.MyVkLayout, myDescriptorSet, VkPipelineBindPoint.Graphics);

        cmd.BindIndexBuffer(indexBuffer, VkIndexType.Uint16);

        var scale = stackalloc float[2];
        scale[0] = 2.0f / aDrawDataPtr.DisplaySize.X;
        scale[1] = 2.0f / aDrawDataPtr.DisplaySize.Y;
        var translate = stackalloc float[2];
        translate[0] = -1.0f - aDrawDataPtr.DisplayPos.X * scale[0];
        translate[1] = -1.0f - aDrawDataPtr.DisplayPos.Y * scale[1];

        imguiPushConstants pushConstants = new();
        pushConstants.Scale.X = 2.0f / aDrawDataPtr.DisplaySize.X;
        pushConstants.Scale.Y = 2.0f / aDrawDataPtr.DisplaySize.Y;
        pushConstants.Translate.X = -1.0f - aDrawDataPtr.DisplayPos.X * pushConstants.Scale.X;
        pushConstants.Translate.Y = -1.0f - aDrawDataPtr.DisplayPos.Y * pushConstants.Scale.Y;
        pushConstants.VertexBuffer = vertexBuffer.GetDeviceAddress();

        cmd.SetPushConstants(pushConstants, myPipeline.MyVkLayout, VkShaderStageFlags.Vertex);

        var clipOff = aDrawDataPtr.DisplayPos;
        var clipScale = aDrawDataPtr.FramebufferScale;

        var vertexOffset = 0;
        var indexOffset = 0;
        for (var n = 0; n < aDrawDataPtr.CmdListsCount; n++)
        {
            ref var cmdList = ref aDrawDataPtr.CmdLists[n];
            for (var i = 0; i < cmdList.CmdBuffer.Size; i++)
            {
                var cmdItem = cmdList.CmdBuffer[i];
                cmd.BindDescriptorSet(myPipeline.MyVkLayout, myDescriptorSet, VkPipelineBindPoint.Graphics);

                var clipRect = new Vector4
                {
                    X = (cmdItem.ClipRect.X - clipOff.X) * clipScale.X,
                    Y = (cmdItem.ClipRect.Y - clipOff.Y) * clipScale.Y,
                    Z = (cmdItem.ClipRect.Z - clipOff.X) * clipScale.X,
                    W = (cmdItem.ClipRect.W - clipOff.Y) * clipScale.Y,
                };
                if (clipRect.X < framebufferWidth
                    && clipRect.Y < frameBufferHeight
                    && clipRect.Z >= .0f
                    && clipRect.W >= .0f)
                {
                    if (clipRect.X < 0.0f) clipRect.X = 0.0f;
                    if (clipRect.Y < 0.0f) clipRect.Y = 0.0f;

                    //var scissor = Rect2D(
                    //                         new Offset2D((int) clipRect.X, (int) clipRect.Y),
                    //                         new Extent2D((uint) (clipRect.Z - clipRect.X),
                    //                                      (uint) (clipRect.W - clipRect.Y))
                    //                        );
                    //cmd.SetScissor(scissor);

                    cmd.DrawIndexed(cmdItem.ElemCount, 1, cmdItem.IdxOffset + (uint) indexOffset,
                                    (int) cmdItem.VtxOffset + vertexOffset, 0);

                }
            }
            indexOffset += cmdList.IdxBuffer.Size;
            vertexOffset += cmdList.VtxBuffer.Size;
        }

        myOldVBuffers.Add(vertexBuffer);
        myOldIBuffers.Add(indexBuffer);
    }

    public unsafe void Destroy()
    {
        myFontTexture.Destroy();
        myDescriptorAllocator.Destroy();
        mySampler.Destroy();
        
        Vulkan.vkDestroyDescriptorSetLayout(Device.MyVkDevice, myLayout);

        myPipeline.Destroy();

        foreach (var buffer in myOldVBuffers)
            buffer.Destroy();
        foreach (var buffer in myOldIBuffers)
            buffer.Destroy();
    }
}