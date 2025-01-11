using Ego;
using ImGuiNET;
using Utilities;

public static partial class EmGui
{
    public static bool Inspect(string aName, ref object aObject)
    {
        
        return false;
    }
    
    public static bool Inspect(string aName, ref string aString)
    {
        return ImGui.InputText(aName, ref aString, 200);
    }
    
    public static bool Inspect(string aName, ref int aNumber)
    {
        return ImGui.InputInt(aName, ref aNumber);
    }
    
    public static bool Inspect(string aName, ref Vector3 aVector)
    {
        return ImGui.DragFloat3(aName, ref aVector, 0.1f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat);
    }
    
    public static bool Inspect(string aName, ref Transform aTransform)
    {
        bool changed = false;
        changed |= Inspect("Position", ref aTransform.Position);
        changed |= Inspect("Rotation", ref aTransform.Rotation);
        changed |= Inspect("Scale", ref aTransform.Scale);
        
        return changed;
    }
    
    public static bool Inspect(string aName, ref Quaternion aRotation)
    {
        bool changed = false;
        Vector3 Ypr;
        Ypr.X = ImGui.GetStateStorage().GetFloat((uint)"yaw".GetHashCode(), aRotation.ToEulerAngle().X);
        Ypr.Y = ImGui.GetStateStorage().GetFloat((uint)"pitch".GetHashCode(), aRotation.ToEulerAngle().Y);
        Ypr.Z = ImGui.GetStateStorage().GetFloat((uint)"roll".GetHashCode(), aRotation.ToEulerAngle().Z);
        
        if (ImGui.DragFloat3(aName, ref Ypr, 1f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat))
        {
            if (Ypr.X > 180f)
                Ypr.X -= 360f;
            if (Ypr.Y > 180f)
                Ypr.Y -= 360f;
            if (Ypr.Z > 180f)
                Ypr.Z -= 360f;
            if (Ypr.X < -180f)
                Ypr.X += 360f;
            if (Ypr.Y < -180f)
                Ypr.Y += 360f;
            if (Ypr.Z < -180f)
                Ypr.Z += 360f;
            
                
            Vector3 YprRadians = Ypr;
            YprRadians.X = Ypr.X.ToRadians();
            YprRadians.Y = Ypr.Y.ToRadians();
            YprRadians.Z = Ypr.Z.ToRadians();
            aRotation = YprRadians.ToQuaternion();

            changed = true;
        }

        ImGui.GetStateStorage().SetFloat((uint)"yaw".GetHashCode(), Ypr.X);
        ImGui.GetStateStorage().SetFloat((uint)"pitch".GetHashCode(), Ypr.Y);
        ImGui.GetStateStorage().SetFloat((uint)"roll".GetHashCode(), Ypr.Z);

        return changed;
    }
    
    public static bool Inspect<T>(string aName, ref T aVar)
    {
        if (aVar == null) 
            throw new ArgumentNullException(nameof(aVar));
        
        if (aVar.GetType().IsEnum)
        {
            return InspectEnum<T>(aName, ref aVar);
        }

        return false;
    }
    
    public static bool InspectEnum<T>(string aName, ref T aEnum)
    {
            bool newSelection = false;
            if (ImGui.BeginCombo(aName, aEnum!.ToString()))
            {
                foreach(var iEnum in Enum.GetValues(typeof(T)))
                {
                    bool selected = Equals(iEnum, aEnum);
                    if (ImGui.Selectable(iEnum.ToString()))
                    {
                        newSelection = true;
                        aEnum = (T)iEnum;
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