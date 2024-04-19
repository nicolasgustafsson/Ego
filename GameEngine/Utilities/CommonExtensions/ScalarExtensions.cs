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
}