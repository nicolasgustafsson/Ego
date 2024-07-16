namespace Ego;

public class Node3D : Node
{
    private Transform myTransform = new();

    private Matrix4x4? CachedWorldMatrix = null;

    public Matrix4x4 LocalMatrix => myTransform.Matrix;
    public override Matrix4x4 WorldMatrix => CachedWorldMatrix ??= LocalMatrix * MyParent.WorldMatrix;
    
    public Vector3 LocalPosition
    {
        get => myTransform.Position;
        set
        {
            myTransform.Position = value;
            CachedWorldMatrix = null;
        }
    }
    
    public Quaternion LocalRotation
    {
        get => myTransform.Rotation;
        set 
        { 
            myTransform.Rotation = value;
            CachedWorldMatrix = null;
        }
    }
    
    public Vector3 LocalScale
    {
        get => myTransform.Scale;
        set 
        { 
            myTransform.Scale = value;
            CachedWorldMatrix = null;
        }
    }
}