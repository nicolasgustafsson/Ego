using ImGuiNET;
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
    
    public override void Inspect()
    {
        var position = LocalPosition;
        ImGui.SliderFloat3("Position", ref position, -10f, 10f);
        LocalPosition = position;
        var scale = LocalScale;
        ImGui.SliderFloat3("Scale", ref scale, -10f, 10f);
        LocalScale = scale;
    }

    public override Vector4? GetIconColor()
    {
        return new Vector4(0.95f, 0.5f, 0.5f, 1f);
    }
}