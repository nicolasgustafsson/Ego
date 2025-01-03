using ImGuiNET;

namespace Ego;

public static partial class EmGui
{
    public static void Inspect(string aName, ref Vector3 aVector)
    {
        ImGui.DragFloat3(aName, ref aVector, 0.1f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat);
    }
}