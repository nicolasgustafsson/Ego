namespace Ego;

public struct Transform
{
    public Quaternion Rotation = Quaternion.Identity;
    public Position3D Position = Position3D.Zero;
    public Vector3 Scale = Vector3.One;

    public Transform()
    {
    }

    public Matrix4x4 Matrix => Matrix4x4.CreateScale(Scale) * Matrix4x4.CreateFromQuaternion(Rotation) * Matrix4x4.CreateTranslation((Vector3)Position);
}