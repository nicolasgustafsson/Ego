using System.Diagnostics.CodeAnalysis;
using Utilities;

namespace Ego;

[Node(AllowAddingToScene = true)]
public partial class Node3D : Node
{
    [Inspect] private Transform Transform = new();
    
    public Matrix4x4 WorldMatrix => Transform.Matrix * ((Parent as Node3D)?.WorldMatrix ?? Matrix4x4.Identity);
    public Matrix4x4 LocalMatrix => Transform.Matrix; 

    public ref Vector3 LocalPosition => ref Transform.Position;
    public ref Quaternion LocalRotation => ref Transform.Rotation;
    public Quaternion WorldRotation => Transform.Rotation * ((Parent as Node3D)?.WorldRotation ?? Quaternion.Identity);
    public ref Vector3 LocalScale => ref Transform.Scale;

    public override Vector4? GetIconColor()
    {
        return new Vector4(0.95f, 0.5f, 0.5f, 1f);   
    }

    protected override void Update()
    {
        base.Update();
        //Shapes.DrawPoint(WorldMatrix.Translation, Vector4.One, 0.5f);
    }
}