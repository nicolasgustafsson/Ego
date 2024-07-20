using System.Diagnostics;
using Ego;
using Ego.Systems;
using ImGuiNET;
using Rendering;

namespace Ego;

public static partial class Program
{
    public static EgoContext Context = null!;
    public static void Main()
    {
        Context = new();
        Context.Run();
    }
}