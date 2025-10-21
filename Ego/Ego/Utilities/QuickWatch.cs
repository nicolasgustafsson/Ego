using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Ego;

public class QuickWatch
{
    private Stopwatch myWatch = new();

    private string myName;
    
    public QuickWatch(string aName)
    {
        myWatch.Start();
        myName = aName;
    }
    
    public TimeSpan GetTime()
    {
        return myWatch.Elapsed;
    }
    
    public void LogTime()
    {
        Log.Info($"Watch {myName}: {myWatch.Elapsed.TotalMilliseconds}ms");
    }
}