﻿using System.Diagnostics;

namespace Ego;

[Node(DisableEditorAdd = true)]
public partial class TimeKeeper : Node
{
    private Stopwatch DeltaTimeStopwatch = new();

    public TimeSpan DeltaTime { get; private set; }
    public TimeSpan ElapsedTime { get; private set; }
    public double DeltaSeconds => DeltaTime.TotalSeconds;
    
    public TimeKeeper()
    {
        DeltaTimeStopwatch.Start();
    }
    
    protected override void Update()
    {
        DeltaTime = DeltaTimeStopwatch.Elapsed;
        ElapsedTime += DeltaTime;
        DeltaTimeStopwatch.Restart();
    }
}