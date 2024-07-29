using ImGuiNET;
using SharpGLTF.Runtime;
using Utilities.CommonExtensions;

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
    
    static Vector3 Ypr = Vector3.Zero;
    private static Node3D? LastInspectedNode;
    
    public override void Inspect()
    {
        var position = LocalPosition;
        ImGui.DragFloat3("Position", ref position, 0.1f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat);
        LocalPosition = position;
        var scale = LocalScale;
        
        ImGui.DragFloat3("Scale", ref scale, 0.01f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat);

        if (LastInspectedNode != this)
        {
            LastInspectedNode = this;

            Ypr = LocalRotation.ToEulerAngle();

            Ypr.X = Ypr.X.ToDegrees();
            Ypr.Y = Ypr.Z.ToDegrees();
            Ypr.Z = Ypr.Z.ToDegrees();
        }
        
        if (ImGui.DragFloat3("Rotation", ref Ypr, 1f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat))
        {
            if (Ypr.X > 360f)
                Ypr.X -= 360f;
            if (Ypr.Y > 360f)
                Ypr.Y -= 360f;
            if (Ypr.Z > 360f)
                Ypr.Z -= 360f;
            if (Ypr.X < -360f)
                Ypr.X += 360f;
            if (Ypr.Y < -360f)
                Ypr.Y += 360f;
            if (Ypr.Z < -360f)
                Ypr.Z += 360f;
                
            var YprRadians = Ypr;
            YprRadians.X = Ypr.X.ToRadians();
            YprRadians.Y = Ypr.Y.ToRadians();
            YprRadians.Z = Ypr.Z.ToRadians();
            LocalRotation = YprRadians.ToQuaternion();
        }
        
        LocalScale = scale;
    }

    public override Vector4? GetIconColor()
    {
        return new Vector4(0.95f, 0.5f, 0.5f, 1f);
    }
}