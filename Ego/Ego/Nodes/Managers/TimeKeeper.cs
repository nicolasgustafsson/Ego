using System.Diagnostics;

namespace Ego;

public class TimeKeeper : BaseNode
{
    private Stopwatch Stopwatch = new();

    public float ElapsedSeconds => (float)Stopwatch.Elapsed.TotalSeconds;
    
    public TimeKeeper()
    {
        Stopwatch.Start();
    }
}