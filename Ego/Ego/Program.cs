using System.Diagnostics;
using Ego;
using ImGuiNET;
using Rendering;

namespace Ego;

public static partial class Program
{
    public static void Main()
    {
        EgoContext Context = null!;
        Context = new();
        Context.Run();
    }
}