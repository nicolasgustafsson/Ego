namespace Ego;

public struct Position3D
{
    public Vector3 Underlying;
    
    public Position3D()
    {
        
    }

    //Use implicit conversion instead (i.e Position3D position = Vector3.zero)
    private Position3D(Vector3 aVector)
    {
        Underlying = aVector;
    }
    
    public Position3D(float X, float Y, float Z)
    {
        Underlying = new(X, Y, Z);
    }
    
    public static explicit operator Vector3(Position3D aVector) => aVector.Underlying;
    public static explicit operator Position3D(Delta3D aDelta) => (Position3D)aDelta.Underlying;
    
    public static explicit operator Position3D(Vector3 value)
    {
        return new Position3D(value);
    }
    
    public static Position3D operator +(Position3D aPosition, Delta3D aDelta)
    {
        return (Position3D)(aPosition.Underlying + aDelta.Underlying);
    }
    
    public static Position3D Zero
    {
        get => default;
    }
}