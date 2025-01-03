namespace Ego;

//Two objects that we swap between - used for multithreading. Lockless baybeee
public class DoubleBuffer<T>(T aProducer, T aConsumer)
{
    public T Producer = aProducer;
    public T Consumer = aConsumer;

    public void Swap()
    {
        Consumer = Interlocked.Exchange(ref Producer, Consumer);
    }
}