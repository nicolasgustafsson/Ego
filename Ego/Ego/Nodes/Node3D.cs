using SharpGLTF.Runtime;

namespace Ego;

public class Node3D : Node
{
    private Transform Transform = new();

    protected Matrix4x4 WorldMatrix => Transform.Matrix * (GetFirstParentOfType<Node3D>()?.WorldMatrix ?? Matrix4x4.Identity);
    
    public Vector3 LocalPosition
    {
        get => Transform.Position;
        set => Transform.Position = value;
    }
    
    public Quaternion LocalRotation
    {
        get => Transform.Rotation;
        set => Transform.Rotation = value;
    }
    
    public Vector3 LocalScale
    {
        get => Transform.Scale;
        set => Transform.Scale = value;
    }
}