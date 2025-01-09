using ImGuiNET;

public static partial class EmGui
{
    public static void Inspect(string aName, object aDefaultObject)
    {
        
    }
    
    public static string Inspect(string aName, string aString)
    {
        string test = new(aString);
        ImGui.InputText(aName, ref test, 200);

        return test;
    }
    
    public static int Inspect(string aName, int aNumber)
    {
        int test = aNumber;
        ImGui.InputInt(aName, ref test);
        return test;
    }
    
    public static void Inspect(string aName, ref Vector3 aVector)
    {
        ImGui.DragFloat3(aName, ref aVector, 0.1f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat);
    }
    
    public static bool Inspect<T>(string aName, ref T aEnum) where T : struct, System.Enum
    {
        bool newSelection = false;
        if (ImGui.BeginCombo(aName, aEnum.ToString()))
        {
            foreach(var iEnum in Enum.GetValues<T>())
            {
                bool selected = Equals(iEnum, aEnum);
                if (ImGui.Selectable(iEnum.ToString()))
                {
                    newSelection = true;
                    aEnum = iEnum;
                }
                if (selected)
                {
                    ImGui.SetItemDefaultFocus();
                }
            }
            ImGui.EndCombo();
        }

        return newSelection;
    }
}