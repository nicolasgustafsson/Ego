using System.Runtime.InteropServices;

namespace Rendering;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct SceneData
{
    public Matrix4x4 View;
    public Matrix4x4 Projection;
    public Matrix4x4 ViewProjection;
    public Vector4 AmbientColor;
    public Vector4 SunlightDirection;
    public Vector4 SunlightColor;
}
