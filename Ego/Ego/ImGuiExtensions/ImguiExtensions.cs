
using System.Drawing;

public static class ImGuiExtensions
{
    public static Vector4 ToVec4(this Color aColor)
    {
        return new Vector4(aColor.R / 255f, aColor.G / 255f, aColor.B / 255f, aColor.A / 255f);
    }
    
    public static Color ToColor(this Vector4 aColor)
    {
        return Color.FromArgb(alpha: (aColor.W * 255f).Round(), (aColor.X * 255f).Round(), (aColor.Y * 255f).Round(), (aColor.Z * 255f).Round());
        //Color color = new Color(){R = 255};



        //return new Color() { R: aColor.X * 255f }; // (aColor.X * 255f, aColor.Y * 255f, aColor.Z * 255f, aColor.W * 255f);
    }
}