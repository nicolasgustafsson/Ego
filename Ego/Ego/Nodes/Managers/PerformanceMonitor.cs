using System.Diagnostics;
using ImGuiNET;
using Vortice.ShaderCompiler;

namespace Ego;

public class PerformanceMonitor : Node
{
    private Dictionary<string, RingBuffer<TimeSpan>> Traces = new();
    //Not super accurate. its ok; this is mostly for overview, not profiling.
    public class PerformanceTracer
    {
        private PerformanceMonitor Monitor;
        private Stopwatch Watch = new();
        
        public PerformanceTracer(PerformanceMonitor aMonitor)
        {
            Monitor = aMonitor;

            Watch.Start();
            
            
        }
        
        public void Trace(string aName)
        {
            TimeSpan passedTime = Watch.Elapsed;
            Monitor.Trace(passedTime, aName);
        }
    }


    private int FrameCount = 180;
    public PerformanceMonitor(int aFrameCount = 180)
    {
        FrameCount = aFrameCount;
    }
    
    public PerformanceTracer StartTrace()
    {
        return new PerformanceTracer(this);
    }
    
    private void Trace(TimeSpan passedTime, string aName)
    {
        Traces.TryAdd(aName, new(FrameCount));

        Traces[aName].Add(passedTime);
    }

    public override void Inspect()
    {
        //ImGui.Begin("Performance Monitor");
        
        foreach(KeyValuePair<string, RingBuffer<TimeSpan>> help in Traces)
        {
            var ms = help.Value.AsArray().Select(val => (float)val.TotalMilliseconds).ToArray();

            ImGui.PlotLines(help.Key, ref ms[0], help.Value.Size);
        }

        //ImGui.End();
    }
}


