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
        Program.Context.Renderer.SetCameraView(WorldMatrix);
    }

    public override char GetIcon()
    {
        return (char)59403;
    }
}