using System.Runtime.InteropServices;

namespace Utilities.Interop;

public static class Interop
{ 
    public static Span<T> AsSpan<T>(this List<T> aList)
    {
        Span<T> sizes = CollectionsMarshal.AsSpan(aList);

        return sizes;
    }
    
    public static GCHandle Pin(this object aObject)
    {
        return GCHandle.Alloc(aObject, GCHandleType.Pinned);
    }
}