namespace Rendering;

public class RenderData
{
    public List<MeshRenderData> MeshRenders = new();
    public List<IRenderCommand> CustomRenders = new();
    public Matrix4x4 CameraView;
    public Vector4 AmbientColor;
    public Vector4 SunlightColor;
    public Vector4 SunlightDirection;
    
    public void RenderMesh(MeshRenderData aRenderData)
    {
        MeshRenders.Add(aRenderData);
    }
    
    public void SetCameraView(Matrix4x4 aView)
    {
        CameraView = aView;
    }

}