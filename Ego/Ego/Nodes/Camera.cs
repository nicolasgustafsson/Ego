using Ego.Systems;
using ImGuiNET;
using Rendering;
using Quaternion = System.Numerics.Quaternion;

namespace Ego;

public class Camera : Node3D
{
    public Camera()
    {
        Program.Context.EUpdate += Update;
        Program.Context.Debug.EDebug += Debug;
    }
    
    public void Update()
    {
        //LocalRotation *= Quaternion.CreateFroawPitchRoll(0f, 0f, 0.01f);
        Program.Context.Renderer.SetCameraView(WorldMatrix);
    }
    
    public void Debug()
    {
        ImGui.Begin("Hello there");

        var position = LocalPosition;
        ImGui.SliderFloat3("Position", ref position, -10f, 10f);
        LocalPosition = position;
        ImGui.End();
    }
}