using System.IO.Enumeration;

namespace VulkanApi;

public enum BlendMode
{
    Additive,
    Alpha,
    Disabled
}

public static partial class Extensions
{
    public static VkPipelineColorBlendAttachmentState ToVkBlendAttachment(this BlendMode aBlendMode)
    {
        VkPipelineColorBlendAttachmentState state = new();
        switch (aBlendMode)
        {
            case BlendMode.Additive:
                state.colorWriteMask = VkColorComponentFlags.All;
                state.blendEnable = true;
                state.srcColorBlendFactor = VkBlendFactor.One;
                state.dstColorBlendFactor = VkBlendFactor.DstAlpha;
                state.colorBlendOp = VkBlendOp.Add;
                state.srcAlphaBlendFactor = VkBlendFactor.One;
                state.dstAlphaBlendFactor = VkBlendFactor.Zero;
                state.alphaBlendOp = VkBlendOp.Add;
                break;
            case BlendMode.Alpha:
                state.colorWriteMask = VkColorComponentFlags.All;
                state.blendEnable = true;
                state.srcColorBlendFactor = VkBlendFactor.SrcAlpha;
                state.dstColorBlendFactor = VkBlendFactor.OneMinusSrcAlpha;
                state.colorBlendOp = VkBlendOp.Add;
                state.srcAlphaBlendFactor = VkBlendFactor.One;
                state.dstAlphaBlendFactor = VkBlendFactor.Zero;
                state.alphaBlendOp = VkBlendOp.Add;
                break;
            case BlendMode.Disabled:
                state.colorWriteMask = VkColorComponentFlags.All;
                state.blendEnable = false;
                break;
        }

        return state;
    }
    
    public static VkColorBlendEquationEXT ToVkBlendEquation(this BlendMode aBlendMode)
    {
        VkColorBlendEquationEXT equation = new();
        switch (aBlendMode)
        {
            case BlendMode.Additive:
                equation.srcColorBlendFactor = VkBlendFactor.One;
                equation.dstColorBlendFactor = VkBlendFactor.DstAlpha;
                equation.colorBlendOp = VkBlendOp.Add;
                equation.srcAlphaBlendFactor = VkBlendFactor.One;
                equation.dstAlphaBlendFactor = VkBlendFactor.Zero;
                equation.alphaBlendOp = VkBlendOp.Add;
                break;
            case BlendMode.Alpha:
                equation.srcColorBlendFactor = VkBlendFactor.SrcAlpha;
                equation.dstColorBlendFactor = VkBlendFactor.OneMinusSrcAlpha;
                equation.colorBlendOp = VkBlendOp.Add;
                equation.srcAlphaBlendFactor = VkBlendFactor.One;
                equation.dstAlphaBlendFactor = VkBlendFactor.Zero;
                equation.alphaBlendOp = VkBlendOp.Add;
                break;
            case BlendMode.Disabled:
                break;
        }

        return equation;
    }
}

