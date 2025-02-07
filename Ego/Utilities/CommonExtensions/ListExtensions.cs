namespace Utilities;

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
    public struct EnumeratedInstance<T>
    {
        public int Index;
        public T Item;
    }
    
    public static IEnumerable<EnumeratedInstance<T>> Enumerate<T>(this IEnumerable<T> collection)
    {
        int counter = 0;
        foreach (var item in collection)
        {
            yield return new EnumeratedInstance<T>
            {
                Index = counter,
                Item = item
            };
            counter++;
        }
    }
}