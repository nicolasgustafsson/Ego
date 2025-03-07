using System.Runtime.InteropServices;

namespace Rendering;

public struct SceneData
{
    public Matrix4x4 View = Matrix4x4.Identity;
    public Matrix4x4 Projection;
    public Matrix4x4 ViewProjection;
    public Vector4 AmbientColor;
    public Vector4 SunlightDirection;
    public Vector4 SunlightColor;

    public SceneData()
    {
        Projection = default;
        ViewProjection = default;
        AmbientColor = default;
        SunlightDirection = new (0f, 1f, 0f, 0f);
        SunlightColor = default;
    }
}
