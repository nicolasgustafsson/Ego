using System.Diagnostics;
using System.Drawing;
using Graphics;
using ImGuiNET;
using Utilities.Interop;
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

    private List<AllocatedBuffer<ImDrawVertCorrected>> myOldVBuffers = new();
    private List<AllocatedBuffer<ushort>> myOldIBuffers = new();
    private VkDescriptorSetLayout myVertexBufferLayout;
    private VkDescriptorSetLayout myIndexBufferLayout;

    private Stopwatch myStopwatch = new();

    public unsafe ImGuiContext(Renderer aRenderer, Window aWindow)
    {
        myStopwatch.Start();
        myWindow = aWindow;
        
        var context = ImGui.CreateContext();
        ImGui.SetCurrentContext(context);

        var io = ImGui.GetIO();

        io.ConfigFlags = ImGuiConfigFlags.DockingEnable | ImGuiConfigFlags.ViewportsEnable;
        io.Fonts.AddFontDefault();
        
        io.Fonts.GetTexDataAsRGBA32(out nint pixels, out var width, out var height);
        
        myFontTexture = new Image(aRenderer, (byte*)pixels.ToPointer(), VkFormat.R8G8B8A8Unorm, VkImageUsageFlags.Sampled | VkImageUsageFlags.TransferDst, new VkExtent3D(width, height, 1), false);
        myDescriptorAllocator = new DescriptorAllocatorGrowable();
        myDescriptorAllocator.InitPool(100, [new(ratio: 1000, type: VkDescriptorType.CombinedImageSampler)]);
        
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
        
        Window.EKeyboardKey += KeyDown;
        Window.ECharInput += CharInput;
        Window.EMouseScrolled += MouseScroll;
        Window.EMouseButton += MouseButton;
        Window.EMousePosition += MousePosition;
    }

    private void MousePosition(Vector2 aNewPosition)
    {
        var io = ImGui.GetIO();
        io.AddMousePosEvent(aNewPosition.X, aNewPosition.Y);
    }

    private void MouseButton(MouseButton aMouseButton, InputState aInputState)
    {
        var io = ImGui.GetIO();
        if (aInputState == InputState.Repeat)
            return;
        
        io.AddMouseButtonEvent((int)aMouseButton.AsImGuiMouseButton(), aInputState == InputState.Press);
    }

    private void MouseScroll(Vector2 aScroll)
    {
        var io = ImGui.GetIO();

        io.AddMouseWheelEvent(aScroll.X, aScroll.Y);
    }

    void CharInput(uint aCharInput)
    {
        var io = ImGui.GetIO();
        
        io.AddInputCharacter(aCharInput);
    }

    private void KeyDown(KeyboardKey aKey, InputState aInputState)
    {
        if (aInputState == InputState.Repeat)
            return;
        
        var io = ImGui.GetIO();
        
        io.AddKeyEvent(aKey.AsImGuiKey(), aInputState == InputState.Press);
        
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
    
    private void SetFrameData()
    {
        var io = ImGui.GetIO();

        Vector2 windowSize = new Vector2{X = myWindow.GetWindowSize().width, Y = myWindow.GetWindowSize().height};
        Vector2 framebufferSize = new Vector2{X = myWindow.GetFramebufferSize().width, Y = myWindow.GetFramebufferSize().height};
        
        io.DisplaySize = new Vector2(myWindow.GetFramebufferSize().width, myWindow.GetFramebufferSize().height);
        if (windowSize is {X: > 0, Y: > 0})
            io.DisplayFramebufferScale = new Vector2(framebufferSize.X / (float) windowSize.X,
                framebufferSize.Y / (float) windowSize.Y);
        
        io.DeltaTime = (float)myStopwatch.Elapsed.TotalSeconds;
        myStopwatch.Restart();
    } 
    
    private void UpdateImGuiInput()
    {
        var io = ImGui.GetIO();

        io.MousePos = myWindow.GetCursorPosition();
        /*

/*
        var mouseState = .Mice[0].CaptureState();
        var keyboardState = _input.Keyboards[0];

        var wheel = mouseState.GetScrollWheels()[0];
        io.MouseWheel = wheel.Y;
        io.MouseWheelH = wheel.X;

        _allKeys ??= (Key[]?) Enum.GetValues(typeof(Key));
        foreach (var key in _allKeys!)
        {
            if (key == Key.Unknown) continue;
            io.KeysDown[(int)key] = keyboardState.IsKeyPressed(key);
        }

        foreach (var c in _pressedChars) io.AddInputCharacter(c);
        _pressedChars.Clear();

        io.KeyCtrl = keyboardState.IsKeyPressed(Key.ControlLeft) || keyboardState.IsKeyPressed(Key.ControlRight);
        io.KeyAlt = keyboardState.IsKeyPressed(Key.AltLeft) || keyboardState.IsKeyPressed(Key.AltRight);
        io.KeyShift = keyboardState.IsKeyPressed(Key.ShiftLeft) || keyboardState.IsKeyPressed(Key.ShiftRight);
        io.KeySuper = keyboardState.IsKeyPressed(Key.SuperLeft) || keyboardState.IsKeyPressed(Key.SuperRight);*/
    } 
    
    public void Render(CommandBuffer cmd)
    {
        SetFrameData();
        UpdateImGuiInput();
        ImGui.NewFrame();
        ImGui.ShowDemoWindow();
        ImGui.ShowAboutWindow();
        //ImGui.Begin("sss");
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
    
    struct ImDrawVertCorrected
    {
        public Vector2 Position;
        public Vector2 UV;
        public Vector4 Color;
    }

    List<ImDrawVertCorrected> corrected = new();
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
        AllocatedBuffer<ImDrawVertCorrected> vertexBuffer = new(VkBufferUsageFlags.StorageBuffer | VkBufferUsageFlags.ShaderDeviceAddress, VmaMemoryUsage.CpuToGpu, (uint)aDrawDataPtr.TotalVtxCount);

        ulong vtxOffset = 0;
        ulong idxOffset = 0;
        
        for(int i = 0; i < aDrawDataPtr.CmdListsCount; i++)
        {
            ref var cmdList = ref aDrawDataPtr.CmdLists[i];
            ulong vtxChunkSize = (ulong) cmdList.VtxBuffer.Size * (ulong) sizeof(ImDrawVertCorrected);
            ulong idxChunkSize = (ulong) cmdList.IdxBuffer.Size * sizeof(ushort);

            Span<ImDrawVert> vertices = new Span<ImDrawVert>(cmdList.VtxBuffer.Data.ToPointer(), cmdList.VtxBuffer.Size);
            corrected.Clear();
            corrected.EnsureCapacity(vertices.Length);

            foreach(ImDrawVert vert in vertices)
            {
                Color color = Color.FromArgb((int)vert.col);
                corrected.Add(new() { Position = vert.pos, UV = vert.uv, Color = new Vector4(color.B / 255f, color.G / 255f, color.R / 255f, color.A / 255f) });
            }
            
            Span<ImDrawVertCorrected> verticesReal = corrected.AsSpan();
            
            Span<ushort> indices = new Span<ushort>(cmdList.IdxBuffer.Data.ToPointer(), cmdList.IdxBuffer.Size);

            vertexBuffer.SetWriteData(verticesReal, vtxOffset);
            indexBuffer.SetWriteData(indices, idxOffset);

            vtxOffset += vtxChunkSize;
            idxOffset += idxChunkSize;
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

                    var scissor = new VkRect2D(
                                             new VkOffset2D((int) clipRect.X, (int) clipRect.Y),
                                             new VkExtent2D((uint) (clipRect.Z - clipRect.X),
                                                          (uint) (clipRect.W - clipRect.Y))
                                            );
                    cmd.SetScissor(scissor);

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