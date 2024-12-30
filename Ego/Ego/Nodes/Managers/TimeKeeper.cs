using System.Diagnostics;

namespace Ego;

public class TimeKeeper : Node
{
    private Stopwatch Stopwatch = new();

    public TimeSpan DeltaTime => Stopwatch.Elapsed;
    public double DeltaSeconds => DeltaTime.TotalSeconds;
    
    public TimeKeeper()
    {
        Stopwatch.Start();
    }
}