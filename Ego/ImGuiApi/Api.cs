using System.Numerics;
using System.Text;

namespace ImguiBindings;

internal static partial class Helpers
{
    internal static unsafe sbyte* AsBytes(this string aString)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(aString);

        fixed(byte* asBytesPtr = &bytes[0])
        {
            return (sbyte*)asBytesPtr;
        }
    }
}

public static unsafe partial class Imgui
{
    public static void Begin(string aName)
    {
        bool enabled = true;
        Begin(aName, ref enabled, 0);
    }
    
    public static void Begin(string aName, ref bool aEnabled, ImGuiWindowFlags_ aFlags)
    {
        fixed(bool* enabled = &aEnabled)
            ImguiNative.Begin(aName.AsBytes(), enabled, (int)aFlags);
    }
    
    public static void End()
    {
        ImguiNative.End();
    }
    
    public static void Text(string aText)
    {
        ImguiNative.Text(aText.AsBytes(), __arglist(0));
    }
    
    public static void PushID(string aID)
    {
        ImguiNative.PushID_Str(aID.AsBytes());
    }
    
    public static void PushID(int aID)
    {
        ImguiNative.PushID_Int(aID);
    }
    
    public static void PushID(IntPtr aID)
    {
        ImguiNative.PushID_Ptr(aID.ToPointer());
    }
    
    public static void PopID()
    {
        ImguiNative.PopID();
    }
    
    public static void PushStyleVar(ImGuiStyleVar_ idx, float val)
    {
        ImguiNative.PushStyleVar_Float((int)idx, val);
    }
    
    public static void PushStyleVar(ImGuiStyleVar_ idx, Vector2 val)
    {
        ImguiNative.PushStyleVar_Vec2((int)idx, val);
    }
    
    public static void PopStyleVar(int aCount = 1)
    {
        ImguiNative.PopStyleVar(aCount);
    }

    public static bool IsWindowFocused(ImGuiFocusedFlags_ aFlags = ImGuiFocusedFlags_.ImGuiFocusedFlags_None)
    {
        return ImguiNative.IsWindowFocused((int)aFlags) > 0;
    }
    
    public static ImGuiStorage* GetStateStorage()
    {
        ImGuiStorage* storage = ImguiNative.GetStateStorage();
        
        return storage;
    }
    
    public static void PushStyleColor(ImGuiCol_ aColorType, Vector4 aColor)
    {
        ImguiNative.PushStyleColor_Vec4((int)aColorType, aColor);
    }
    
    public static void PushStyleColor(ImGuiCol_ aColorType, uint aColor)
    {
        ImguiNative.PushStyleColor_U32((int)aColorType, aColor);
    }
    
    public static void PopStyleColor(int aCount = 1)
    {
        ImguiNative.PopStyleColor(aCount);
    }
    
    public static Vector4 GetStyleColorVec4(ImGuiCol_ aColorType)
    {
        return *ImguiNative.GetStyleColorVec4((int)aColorType);
    }
    
    public static Vector2 GetCursorScreenPos()
    {
        Vector2 pos;
        ImguiNative.GetCursorScreenPos(&pos);
        return pos;
    }
    
    public static Vector2 GetCursorPos()
    {
        Vector2 pos;
        ImguiNative.GetCursorPos(&pos);
        return pos;
    }
    
    public static Vector2 GetCursorStartPos()
    {
        Vector2 pos;
        ImguiNative.GetCursorStartPos(&pos);
        return pos;
    }
    
    public static void SetCursorPos(Vector2 aPos)
    {
        ImguiNative.SetCursorPos(aPos);
    }
    
    public static Vector2 GetContentRegionAvail()
    {
        Vector2 pos;
        ImguiNative.GetContentRegionAvail(&pos);
        return pos;
    }
    
    public static float GetTextLineHeight()
    {
        return ImguiNative.GetTextLineHeight();
    }
    
    public static float GetTextLineHeightWithSpacing()
    {
        return ImguiNative.GetTextLineHeightWithSpacing();
    }
    
    public static uint GetColorU32(ImGuiCol_ aColorType, float aAlphaMultiply)
    {
        return ImguiNative.GetColorU32_Col((int)aColorType, aAlphaMultiply);
    }
    
    public static uint GetColorU32(uint aColor, float aAlphaMultiply)
    {
        return ImguiNative.GetColorU32_U32(aColor, aAlphaMultiply);
    }
    
    public static uint GetColorU32(Vector4 aColor)
    {
        return ImguiNative.GetColorU32_Vec4(aColor);
    }
    
    public static ImDrawList* GetWindowDrawList()
    {
        return ImguiNative.GetWindowDrawList();
    }
    
    public static bool IsItemClicked(ImGuiMouseButton_ aMouseButton = ImGuiMouseButton_.ImGuiMouseButton_Left)
    {
        return ImguiNative.IsItemClicked((int)aMouseButton) > 0;
    }
    
    public static void OpenPopup(string aPopupName, ImGuiPopupFlags_ aFlags)
    {
        ImguiNative.OpenPopup_Str(aPopupName.AsBytes(), (int)aFlags);
    }
    
    public static void OpenPopup(uint aId, ImGuiPopupFlags_ aFlags)
    {
        ImguiNative.OpenPopup_ID(aId, (int)aFlags);
    }
    
    public static bool BeginPopup(string aPopupName, ImGuiWindowFlags_ aFlags)
    {
        return ImguiNative.BeginPopup(aPopupName.AsBytes(), (int)aFlags) > 0;
    }
    
    public static void EndPopup()
    {
        ImguiNative.EndPopup();
    }
    
    
}