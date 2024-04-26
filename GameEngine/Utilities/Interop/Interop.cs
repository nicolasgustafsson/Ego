namespace Utilities.Interop;

public static class Interop
{ 
    public static Span<T> AsSpan<T>(this List<T> aList)
    {
        Span<T> sizes = System.Runtime.InteropServices.CollectionsMarshal.AsSpan(aList);

        return sizes;
    }
}