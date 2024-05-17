using System.IO.Enumeration;

namespace Graphics;

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
}

