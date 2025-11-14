using System.Collections;
using System.Drawing;
using System.Reflection;
using Ego;
using ImguiBindings;
using Utilities;

public static partial class EmGui
{
    public static bool Inspect(string aName, ref string aString)
    {
        return Imgui.InputText(aName, ref aString, 200);
    }
    
    public static bool Inspect(string aName, ref int aNumber)
    {
        return Imgui.InputInt(aName, ref aNumber);
    }
    
    public static bool Inspect(string aName, ref float aNumber)
    {
        return Imgui.DragFloat(aName, ref aNumber, aSpeed: 0.1f);
    }
    
    public static bool Inspect(string aName, ref Color aColor)
    {
        Vector4 colorAsVec4 = aColor.ToVec4();
        bool result = Imgui.ColorPicker4(aName, ref colorAsVec4);
        aColor = colorAsVec4.ToColor();

        return result;
    }
    
    public static bool Inspect(string aName, ref Vector3 aVector)
    {
        return Imgui.DragFloat3(aName, ref aVector, 0.1f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat);
    }
    
    public static bool Inspect(string aName, ref Vector4 aVector)
    {
        return Imgui.DragFloat4(aName, ref aVector, 0.1f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat);
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
        Ypr.X = Imgui.GetStateStorage().GetFloat((uint)"yaw".GetHashCode(), aRotation.ToEulerAngle().X);
        Ypr.Y = Imgui.GetStateStorage().GetFloat((uint)"pitch".GetHashCode(), aRotation.ToEulerAngle().Y);
        Ypr.Z = Imgui.GetStateStorage().GetFloat((uint)"roll".GetHashCode(), aRotation.ToEulerAngle().Z);
        
        if (Imgui.DragFloat3(aName, ref Ypr, 1f, -99999999f, 99999999f, "%.3f", ImGuiSliderFlags.NoRoundToFormat))
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

        Imgui.GetStateStorage().SetFloat((uint)"yaw".GetHashCode(), Ypr.X);
        Imgui.GetStateStorage().SetFloat((uint)"pitch".GetHashCode(), Ypr.Y);
        Imgui.GetStateStorage().SetFloat((uint)"roll".GetHashCode(), Ypr.Z);

        return changed;
    }

    public static bool InspectList(string aName, ref IList aList)
    {
        bool changed = false;

        bool expanded = (Imgui.TreeNodeEx(aName, ImGuiTreeNodeFlags.DefaultOpen | ImGuiTreeNodeFlags.AllowOverlap | ImGuiTreeNodeFlags.FramePadding));
            
        Imgui.SameLine();
        bool wasEmpty = aList.Count == 0;
        if (wasEmpty)
            Imgui.BeginDisabled();
        if (Imgui.Button("-"))
        {
            aList.RemoveAt(aList.Count - 1);
        }
        if (wasEmpty)
            Imgui.EndDisabled();
        Imgui.SameLine();
        if (Imgui.Button("+"))
        {
            Type? itemType = aList.GetType().GenericTypeArguments.FirstOrDefault();
            if (itemType == null)
            {
                Log.Error($"Could not add item to list {aName}! Item type was null. Your list is weird.", aName);
                Imgui.EndChild();
                Imgui.TreePop();
                return false;
            }

            aList.Add(Activator.CreateInstance(itemType));
        }

        Imgui.SameLine();
        Imgui.Text($"Size: {aList.Count}");

        if (!expanded) 
            return true;
        
        if (Imgui.BeginChild(aName, Vector2.Zero, ImGuiChildFlags.Borders | ImGuiChildFlags.AlwaysAutoResize | ImGuiChildFlags.AutoResizeY))
        {
            //ImGui.SameLine();
            for(int i = 0; i < aList.Count; i++)
            {
                var refObj = aList[i]!;
                changed |= Inspect<object>($"Item {i}", ref refObj);
                aList[i] = refObj;
            }
                
            Imgui.EndChild();
        }
        Imgui.TreePop();

        return changed;
    }
    
    public static bool Inspect<T>(string aName, ref T aVar)
    {
        if (aVar == null)
        {
            Imgui.TextColored(Color.Brown.ToVec4(), $"Variable [{aName}] is null, make sure to create it!");
            return false;
        }
        
        if (aVar.GetType().IsEnum)
        {
            return InspectEnum<T>(aName, ref aVar);
        }
        
        if (aVar is IList list)
        {
            return InspectList(aName, ref list);
        }
        
        object cloned = aVar;

        bool changed = DynamicInspect(aName, ref cloned);

        aVar = (T)cloned;

        return changed;
    }
    
    public static bool DynamicInspect(string aName, ref object aVar)
    {
        bool changed = false;
        /*if (aVar is string aString)
        {
            changed = Inspect(aName, ref aString);
            aVar = aString;
            return changed;
        }
        if (aVar is Vector3 aVector3)
        {
            changed = Inspect(aName, ref aVector3);
            aVar = aVector3;
            return changed;
        }
        
        if (aVar is int aInt)
        {
            changed = Inspect(aName, ref aInt);
            aVar = aInt;
            return changed;
        }
        if (aVar is Transform aTransform)
        {
            changed = Inspect(aName, ref aTransform);
            aVar = aTransform;
            return changed;
        }*/
        
        if (Imgui.TreeNodeEx(aName, ImGuiTreeNodeFlags.DefaultOpen))
        {
            foreach(var member in aVar.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public))
            {
                var val = member.GetValue(aVar)!;

                changed |= Inspect(member.Name, ref val);
                
                member.SetValue(aVar, val);
            }

            Imgui.TreePop();
        }

        return changed;
    }
    
    public static bool InspectEnum<T>(string aName, ref T aEnum)
    {
            bool newSelection = false;
            if (Imgui.BeginCombo(aName, aEnum!.ToString()!))
            {
                foreach(var iEnum in Enum.GetValues(typeof(T)))
                {
                    bool selected = Equals(iEnum, aEnum);
                    if (Imgui.Selectable(iEnum.ToString()!))
                    {
                        newSelection = true;
                        aEnum = (T)iEnum;
                    }
                    if (selected)
                    {
                        Imgui.SetItemDefaultFocus();
                    }
                }
                Imgui.EndCombo();
            }

            return newSelection;
    }
}