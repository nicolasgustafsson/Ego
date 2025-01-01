using ImGuiNET;

namespace Ego;

public static partial class EmGui
{
    public static void Inspect(string aName, ref Vector3 aVector)
    {
        ImGui.PushID(aName);

        ImGui.BeginGroup();
        ImGui.TextUnformatted(aName);
        ImGui.SameLine();

        ImGui.Button("Yippie");
        ImGui.SameLine();
        ImGui.Text("hwat");

        ImGui.DragFloat3("", ref aVector, 0.1f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat);

        ImGui.EndGroup();
        ImGui.PopID();
    }
}