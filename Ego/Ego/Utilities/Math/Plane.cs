namespace Ego;

public struct Plane
{
    public Vector3 Position => Normal * d;
    public Vector3 Normal => Vector3.Normalize(new Vector3(a, b, c));
    public float a;
    public float b;
    public float c;
    public float d;
    
    public static Plane[] ExtractPlanesFromFrustum(Matrix4x4 aMatrix)
    {
            
        Plane[] planes = new Plane[6]; 
// Left clipping plane
        planes[0].a = aMatrix[3,0] + aMatrix[0,0];
        planes[0].b = aMatrix[3,1] + aMatrix[0,1];
        planes[0].c = aMatrix[3,2] + aMatrix[0,2];
        planes[0].d = aMatrix[3,3] + aMatrix[0,3];
// Right clipping plane
        planes[1].a = aMatrix[3,0] - aMatrix[0,0];
        planes[1].b = aMatrix[3,1] - aMatrix[0,1];
        planes[1].c = aMatrix[3,2] - aMatrix[0,2];
        planes[1].d = aMatrix[3,3] - aMatrix[0,3];
// Top clipping plane
        planes[2].a = aMatrix[3,0] - aMatrix[1,0];
        planes[2].b = aMatrix[3,1] - aMatrix[1,1];
        planes[2].c = aMatrix[3,2] - aMatrix[1,2];
        planes[2].d = aMatrix[3,3] - aMatrix[1,3];
// Bottom clipping plane
        planes[3].a = aMatrix[3,0] + aMatrix[1,0];
        planes[3].b = aMatrix[3,1] + aMatrix[1,1];
        planes[3].c = aMatrix[3,2] + aMatrix[1,2];
        planes[3].d = aMatrix[3,3] + aMatrix[1,3];
// Near clipping plane
        planes[4].a = aMatrix[3,0] + aMatrix[2,0];
        planes[4].b = aMatrix[3,1] + aMatrix[2,1];
        planes[4].c = aMatrix[3,2] + aMatrix[2,2];
        planes[4].d = aMatrix[3,3] + aMatrix[2,3];
// Far clipping plane
        planes[5].a = aMatrix[3,0] - aMatrix[2,0];
        planes[5].b = aMatrix[3,1] - aMatrix[2,1];
        planes[5].c = aMatrix[3,2] - aMatrix[2,2];
        planes[5].d = aMatrix[3,3] - aMatrix[2,3];
        return planes;
    }
    
    public Vector3? IntersectLine(Vector3 V1, Vector3 V2)
    {
            Vector3 Diff = V2 - V1;
            float denominator = a * Diff.X + b * Diff.Y + c * Diff.Z;
            
            if(denominator == 0) 
                    return null;
            
            float u = (a * V1.X + b * V1.Y + c * V1.Z + d) / denominator;
            return (V1 + u * (V2 - V1));
    }
    
    public float DotNormal(Vector3 V)
    {
            return a * V.X + b * V.Y + c * V.Z;
    }
}