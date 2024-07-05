using System.Reflection;
using Monitor = GLFW.Monitor;

namespace Platform;

public static class MonitorExtensions
{
    public static IntPtr GetHandle(this Monitor aMonitor)
    {
        return (IntPtr)(aMonitor.GetType().GetField("handle", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(aMonitor)!);
    }
}