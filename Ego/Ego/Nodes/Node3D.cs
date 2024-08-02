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
    
    private static Node3D? LastInspectedNode;
    
    public override void Inspect()
    {
        var position = LocalPosition;
        ImGui.DragFloat3("Position", ref position, 0.1f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat);
        LocalPosition = position;
        var scale = LocalScale;
        
        ImGui.DragFloat3("Scale", ref scale, 0.01f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat);

        Vector3 Ypr;
        Ypr.X = ImGui.GetStateStorage().GetFloat((uint)"yaw".GetHashCode(), LocalRotation.ToEulerAngle().X);
        Ypr.Y = ImGui.GetStateStorage().GetFloat((uint)"pitch".GetHashCode(), LocalRotation.ToEulerAngle().Y);
        Ypr.Z = ImGui.GetStateStorage().GetFloat((uint)"roll".GetHashCode(), LocalRotation.ToEulerAngle().Z);
        
        if (ImGui.DragFloat3("Rotation", ref Ypr, 1f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat))
        {
            if (Ypr.X > 180f)
                Ypr.X -= 360f;
            if (Ypr.Y > 180f)
                Ypr.Y -= 360f;
            if (Ypr.Z > 180f)
                Ypr.Z -= 360f;
            if (Ypr.X < -180f)
                Ypr.X += 360f;
            if (Ypr.Y < -180f)
                Ypr.Y += 360f;
            if (Ypr.Z < -180f)
                Ypr.Z += 360f;
            
                
            var YprRadians = Ypr;
            YprRadians.X = Ypr.X.ToRadians();
            YprRadians.Y = Ypr.Y.ToRadians();
            YprRadians.Z = Ypr.Z.ToRadians();
            LocalRotation = YprRadians.ToQuaternion();
        }

        ImGui.GetStateStorage().SetFloat((uint)"yaw".GetHashCode(), Ypr.X);
        ImGui.GetStateStorage().SetFloat((uint)"pitch".GetHashCode(), Ypr.Y);
        ImGui.GetStateStorage().SetFloat((uint)"roll".GetHashCode(), Ypr.Z);
            
            
        
        
        LocalScale = scale;
    }

    public override Vector4? GetIconColor()
    {
        return new Vector4(0.95f, 0.5f, 0.5f, 1f);
    }
}