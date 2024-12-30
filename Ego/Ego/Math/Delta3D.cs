namespace Ego;

public struct Delta3D
{
    public Vector3 Underlying;
    
    public Delta3D()
    {
        
    }

    //Use implicit conversion instead (i.e Delta3D position = Vector3.zero)
    private Delta3D(Vector3 aVector)
    {
        Underlying = aVector;
    }
    
    public Delta3D(float X, float Y, float Z)
    {
        Underlying = new(X, Y, Z);
    }
    
    public static Delta3D operator *(Delta3D aDelta, float aMultiplier)
    {
        return (Delta3D)(aDelta.Underlying * aMultiplier);
    }
    
    public static Delta3D operator *(Delta3D aDelta, double aMultiplier)
    {
        return (Delta3D)(aDelta.Underlying * (float)aMultiplier);
    }
    
    public static explicit operator Vector3(Delta3D vector) => vector.Underlying;
    
    public static explicit operator Delta3D(Vector3 value)
    {
        return new Delta3D(value);
    }
}

