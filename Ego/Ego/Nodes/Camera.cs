using ImGuiNET;
using Rendering;
using Quaternion = System.Numerics.Quaternion;

namespace Ego;

public class Camera : Node3D
{
    public override void Start()
    {
        base.Start();
        Context.EUpdate += Update;
    }

    public void Update()
    {
        Context.Get<RendererApi>()!.Renderer.SetCameraView(WorldMatrix);
    }

    public override char GetIcon()
    {
        return (char)59403;
    }
}