using ImGuiNET;
using Rendering;
using Quaternion = System.Numerics.Quaternion;

namespace Ego;

public class Camera : EgoNode3D
{
    protected override void Update()
    {
        Context.Get<RendererApi>()!.SetCameraView(WorldMatrix);
    }

    public override char GetIcon()
    {
        return (char)59403;
    }
}