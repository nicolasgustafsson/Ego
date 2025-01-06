namespace Editor;
using Ego;

internal class Program
{
    static void Main(string[] args)
    {
        EgoContext engine = new();
        engine.Run<Benchmarks>();
    }
}
