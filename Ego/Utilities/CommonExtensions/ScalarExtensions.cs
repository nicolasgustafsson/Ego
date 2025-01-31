using System.Diagnostics;
using System.Numerics;

public static partial class Extensions
{
    private static T Max<T>(T aValue, T aMax) where T : IComparisonOperators<T, T, bool>
    {
        return aValue > aMax ? aValue : aMax;
    }
    
    private static T Min<T>(T aValue, T aMax) where T : IComparisonOperators<T, T, bool>
    {
        return aValue < aMax ? aValue : aMax;
    }
    
    public static T AtLeast<T>(this T aValue, T aMinimum) where T : IComparisonOperators<T, T, bool>
    {
        return Max(aValue, aMinimum);
    }
    
    public static T AtMost<T>(this T aValue, T aMaximum) where T : IComparisonOperators<T, T, bool>
    {
        return Min(aValue, aMaximum);
    }
    
    public static T Within<T>(this T aValue, T aMinimum, T aMaximum) where T : IComparisonOperators<T, T, bool>
    {
        return aValue.AtLeast(aMinimum).AtMost(aMaximum);
    }
    
    public static float ToRadians(this float aDegrees)
    {
        return aDegrees * 0.01745329252f;
    }
    
    public static float ToDegrees(this float aRadians)
    {
        return aRadians * (180f / MathF.PI);
    }
    
    public static int Round(this float aFloat)
    {
        return (int)MathF.Round(aFloat);
    }
    
    public static int Floor(this float aDouble)
    {
        return (int)MathF.Floor(aDouble);
    }
    
    public static int Ceiling(this float aDouble)
    {
        return (int)MathF.Ceiling(aDouble);
    }
    
    public static double ToRadians(this double aDegrees)
    {
        return aDegrees * 0.01745329252d;
    }
    
    public static double ToDegrees(this double aRadians)
    {
        return aRadians * (180d / Math.PI);
    }
    
    public static int Round(this double aDouble)
    {
        return (int)Math.Round(aDouble);
    }
    
    public static int Floor(this double aDouble)
    {
        return (int)Math.Floor(aDouble);
    }
    
    public static int Ceiling(this double aDouble)
    {
        return (int)Math.Ceiling(aDouble);
    }
}