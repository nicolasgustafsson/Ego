namespace Rendering;

public class RenderData
{
    public List<RenderRequest> MeshRenders = new();
    public Matrix4x4 CameraView;
    public Vector4 AmbientColor;
    public Vector4 SunlightColor;
    public Vector4 SunlightDirection;
    public Vector3 CameraPosition;
    
    public void Render(RenderRequest aRenderRequest)
    {
        MeshRenders.Add(aRenderRequest);
    }
    
    public void SetCameraView(Matrix4x4 aView)
    {
        CameraView = aView;
    }
}