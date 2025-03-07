using System.Numerics;

namespace Utilities;

public static class VectorExtensions
{
    //specific version that handles reverse depth
    public static Vector4 Promote(this Vector3 aVector, float aW = 0f)
    {
        return new Vector4(aVector.X, aVector.Y, aVector.Z, aW);
    }
}