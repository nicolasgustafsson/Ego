namespace Ego;

public class RingBuffer<T>
{
    private T[] Buffer;
    private int Index = 0;
    public int Size = 0;
    
    public RingBuffer(int aSize)
    {
        Size = aSize;
        Buffer = new T[aSize];
    }

    public void Add(T aItem)
    {
        Buffer[Index] = aItem;

        Index++;
        Index %= Size;
    }
    
    public T[] AsArray()
    {
        return Buffer.TakeLast(Size - Index).Concat(Buffer.Take(Index)).ToArray();
    }
}