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
}