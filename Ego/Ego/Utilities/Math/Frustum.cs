namespace Ego;

public struct Frustum
{
    public Plane Top;
    public Plane Bottom;
    public Plane Left;
    public Plane Right;
    public Plane Near;
    public Plane Far;
        
    public Frustum(Matrix4x4 aMatrix)
    {
        Plane[] planes = Plane.ExtractPlanesFromFrustum(aMatrix);

        Left = planes[0];
        Right = planes[1];
        Top = planes[2];
        Bottom = planes[3];
        Near = planes[4];
        Far = planes[5];
    }
}