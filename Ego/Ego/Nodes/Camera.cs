using ImGuiNET;
using Rendering;
using Quaternion = System.Numerics.Quaternion;

namespace Ego;

public class Camera : Node3D
{
    public Camera()
    {
        Program.Context.EUpdate += Update;
    }
    
    public void Update()
    {
        //LocalRotation *= Quaternion.CreateFroawPitchRoll(0f, 0f, 0.01f);
        Program.Context.Renderer.SetCameraView(WorldMatrix);
    }
    
    public override void Inspect()
    {
        var position = LocalPosition;
        ImGui.SliderFloat3("Position", ref position, -10f, 10f);
        LocalPosition = position;
    }

    public override char GetIcon()
    {
        return (char)0xe0ee;
    }
}