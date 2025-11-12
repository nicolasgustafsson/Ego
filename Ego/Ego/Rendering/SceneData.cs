using System.Runtime.InteropServices;

namespace Rendering;

public struct SceneData
{
    public Matrix4x4 View = Matrix4x4.Identity;
    public Matrix4x4 Projection;
    public Matrix4x4 ViewProjection;
    public Matrix4x4 InverseView;
    public Matrix4x4 InverseViewProj;
    public Vector4 AmbientColor;
    public Vector4 SunlightDirection;
    public Vector4 SunlightColor;
    public Vector3 CameraPosition;
    public float FieldOfView;
    public float Time;

    public SceneData()
    {
        Projection = default;
        ViewProjection = default;
        AmbientColor = default;
        SunlightDirection = new (0f, 1f, 0f, 0f);
        SunlightColor = default;
    }
}
