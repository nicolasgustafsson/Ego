namespace Ego;

[Node]
public partial class Camera : Node3D
{
    protected override void Update()
    {
        Matrix4x4.Invert(WorldMatrix, out var view);
        RendererApi.RenderData.SetCameraView(view);
        RendererApi.RenderData.CameraPosition = WorldMatrix.Translation;
    }

    public override char GetIcon()
    {
        return (char)59403;
    }
}