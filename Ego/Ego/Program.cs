using System.Diagnostics;
using Ego;
using ImGuiNET;
using Rendering;

namespace Ego;

public static partial class Program
{
    public static void Main()
    {
        EgoContext contextProvider = null!;
        contextProvider = new();
        contextProvider.Run();
    }
}