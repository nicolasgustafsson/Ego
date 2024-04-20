global using Utilities.CommonExtensions;
namespace Utilities.CommonExtensions;

public static class ScalarExtensions
{
    public static uint AtLeast(this uint aValue, uint aMinimum)
    {
        return Math.Max(aValue, aMinimum);
    }
    
    public static uint AtMost(this uint aValue, uint aMaximum)
    {
        return Math.Min(aValue, aMaximum);
    }
    
    public static uint Within(this uint aValue, uint aMinimum, uint aMaximum)
    {
        return aValue.AtLeast(aMinimum).AtMost(aMaximum);
    }
    
    public static int AtLeast(this int aValue, int aMinimum)
    {
        return Math.Max(aValue, aMinimum);
    }
    
    public static int AtMost(this int aValue, int aMaximum)
    {
        return Math.Min(aValue, aMaximum);
    }
    
    public static int Within(this int aValue, int aMinimum, int aMaximum)
    {
        return aValue.AtLeast(aMinimum).AtMost(aMaximum);
    }
    
    public static float AtLeast(this float aValue, float aMinimum)
    {
        return Math.Max(aValue, aMinimum);
    }
    
    public static float AtMost(this float aValue, float aMaximum)
    {
        return Math.Min(aValue, aMaximum);
    }
    
    public static float Within(this float aValue, float aMinimum, float aMaximum)
    {
        return aValue.AtLeast(aMinimum).AtMost(aMaximum);
    }
    
    public static double AtLeast(this double aValue, double aMinimum)
    {
        return Math.Max(aValue, aMinimum);
    }
    
    public static double AtMost(this double aValue, double aMaximum)
    {
        return Math.Min(aValue, aMaximum);
    }
    
    public static double Within(this double aValue, double aMinimum, double aMaximum)
    {
        return aValue.AtLeast(aMinimum).AtMost(aMaximum);
    }
    
    public static decimal AtLeast(this decimal aValue, decimal aMinimum)
    {
        return Math.Max(aValue, aMinimum);
    }
    
    public static decimal AtMost(this decimal aValue, decimal aMaximum)
    {
        return Math.Min(aValue, aMaximum);
    }
    
    public static decimal Within(this decimal aValue, decimal aMinimum, decimal aMaximum)
    {
        return aValue.AtLeast(aMinimum).AtMost(aMaximum);
    }
}