namespace Utilities.CommonExtensions;

public static class ListExtensions
{
    public static bool IsEmpty<T>(this List<T> aList)
    {
        return aList.Count == 0;
    }
    
    public static bool IsEmpty<T>(this Stack<T> aList)
    {
        return aList.Count == 0;
    }
}