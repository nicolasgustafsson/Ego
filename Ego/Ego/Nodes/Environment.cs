
namespace Ego;

[Node]
public partial class Environment : Node
{
    [Inspect] private Vector4 AmbientColor = new Vector4(0.3f, 0.3f, 0.3f, 0.3f);
    [Inspect] private Vector4 SunlightColor = new Vector4(1f, 1f, 1f, 1f);
    [Inspect] private Vector3 SunlightDirection = new Vector3(-0.5f, 1f, 0f);
    [Inspect] private float SunlightStrength = 1f;
    
    protected override void Update()
    {
        base.Update();

        RendererApi.RenderData.AmbientColor = AmbientColor;
        RendererApi.RenderData.SunlightColor = SunlightColor;
        RendererApi.RenderData.SunlightDirection = SunlightDirection.Promote(SunlightStrength);
    }
}