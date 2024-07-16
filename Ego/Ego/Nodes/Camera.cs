using Rendering;
using Quaternion = System.Numerics.Quaternion;

namespace Ego;

public class Camera : Node3D
{
    public override void Update()
    {
        LocalRotation *= Quaternion.CreateFromYawPitchRoll(0f, 0f, 0.01f);
        Program.MyRenderer.SetCameraView(WorldMatrix);

        base.Update();
    }
}