using System.Diagnostics;

namespace Ego.Systems;

public class TimeKeeper : Node
{
    private Stopwatch Stopwatch = new();

    public float ElapsedSeconds => (float)Stopwatch.Elapsed.TotalSeconds;
    
    public TimeKeeper()
    {
        Stopwatch.Start();
    }
}