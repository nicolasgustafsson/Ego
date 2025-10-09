using System.Diagnostics;
using ImGuiNET;
using Vortice.ShaderCompiler;

namespace Ego;

[Node(AllowAddingToScene = false)]
public partial class PerformanceMonitor : Node
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


    private int FrameCount = 100;
    public PerformanceMonitor(int aFrameCount = 100)
    {
        FrameCount = aFrameCount;
    }
    
    public PerformanceTracer StartTrace()
    {
        return new PerformanceTracer(this);
    }
    
    private void Trace(TimeSpan passedTime, string aName)
    {
        lock(this)
        {
            Traces.TryAdd(aName, new(FrameCount));

            Traces[aName].Add(passedTime);
        }
    }

    public void Inspect()
    {
        //ImGui.Begin("Performance Monitor");
        string totalFps = (1d / Time.DeltaTime.TotalSeconds).ToString("0.0") + " fps";
        Imgui.Text(totalFps);
        
        lock(Traces)
        {
            foreach(KeyValuePair<string, RingBuffer<TimeSpan>> help in Traces)
            {
                var ms = help.Value.AsArray().Select(val => (float)val.TotalMilliseconds).ToArray();

                float currentFrameMs = ms.Last();

                string formattedFrameMs = help.Key + ": " + currentFrameMs.ToString("0.00") + "ms";

                float min = ms.Min();
                float max = ms.Max();
                float average = ms.Average();

                Imgui.PushID(help.Key);
                Imgui.PlotLines($"Min: {min:N1}ms\nMax: {max:N1}ms\nAverage: {average:N1}ms", ref ms[0], help.Value.Size, aGraphSize: new Vector2(0, 100), aValuesOffset:0, aOverlayText:formattedFrameMs, aScaleMin:0, aScaleMax:50);
                Imgui.PopID();
            }
        }
        //ImGui.End();
    }
}


