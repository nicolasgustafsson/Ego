using System.Numerics;

namespace Utilities.CommonExtensions;

public static class MatrixExtensions
{
    //specific version that handles reverse depth
    public static Matrix4x4 CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(fieldOfView, 0.0f);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(fieldOfView, float.Pi);

        float height = 1.0f / MathF.Tan(fieldOfView * 0.5f);
        float width = height / aspectRatio;
        float range = float.IsPositiveInfinity(farPlaneDistance) ? -1.0f : farPlaneDistance / (nearPlaneDistance - farPlaneDistance);

        Matrix4x4 result = new();

        result.M11 = width;
        result.M12 = 0;
        result.M13 = 0;
        result.M14 = 0;

        result.M21 = 0;
        result.M22 = height;
        result.M23 = 0;
        result.M24 = 0;
        
        result.M31 = 0;
        result.M32 = 0;
        result.M33 = range;
        result.M34 = -1.0f;
        
        result.M41 = 0;
        result.M42 = 0;
        result.M43 = range * nearPlaneDistance;
        result.M44 = 0.0f;

        return result;
    }
}