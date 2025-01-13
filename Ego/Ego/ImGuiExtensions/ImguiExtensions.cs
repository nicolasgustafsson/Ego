
using System.Drawing;

public static class ImGuiExtensions
{
    public static Vector4 ToVec4(this Color aColor)
    {
        return new Vector4(aColor.R / 255f, aColor.G / 255f, aColor.B / 255f, aColor.A / 255f);
    }
}