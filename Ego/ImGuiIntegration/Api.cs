using System.Collections.Specialized;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImguiBindings;

internal static partial class Helpers
{
    internal static unsafe sbyte* AsBytes(this string aString)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(aString);

        fixed(byte* asBytesPtr = &bytes[0])
        {
            return (sbyte*)asBytesPtr;
        }
    }
}

public static unsafe partial class Imgui
{
    public static bool Begin(string aName, ImGuiWindowFlags aFlags = 0)
    {
        bool enabled = true;
        return Begin(aName, ref enabled, aFlags);
    }
    
    public static bool Begin(string aName, ref bool aEnabled, ImGuiWindowFlags aFlags)
    {
        fixed(bool* enabled = &aEnabled)
            return ImguiNative.Begin(aName.AsBytes(), enabled, (int)aFlags) > 0;
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
    
    public static void PushStyleVar(ImGuiStyleVar idx, float val)
    {
        ImguiNative.PushStyleVar_Float((int)idx, val);
    }
    
    public static void PushStyleVar(ImGuiStyleVar idx, Vector2 val)
    {
        ImguiNative.PushStyleVar_Vec2((int)idx, val);
    }
    
    public static void PopStyleVar(int aCount = 1)
    {
        ImguiNative.PopStyleVar(aCount);
    }

    public static bool IsWindowFocused(ImGuiFocusedFlags aFlags = ImGuiFocusedFlags.None)
    {
        return ImguiNative.IsWindowFocused((int)aFlags) > 0;
    }
    
    public static ImguiStorage GetStateStorage()
    {
        ImguiStorage storage = ImguiNative.GetStateStorage();
        
        return storage;
    }
    
    public static void PushStyleColor(ImGuiCol aColorType, Vector4 aColor)
    {
        ImguiNative.PushStyleColor_Vec4((int)aColorType, aColor);
    }
    
    public static void PushStyleColor(ImGuiCol aColorType, uint aColor)
    {
        ImguiNative.PushStyleColor_U32((int)aColorType, aColor);
    }
    
    public static void PopStyleColor(int aCount = 1)
    {
        ImguiNative.PopStyleColor(aCount);
    }
    
    public static Vector4 GetStyleColorVec4(ImGuiCol aColorType)
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
    
    public static uint GetColorU32(ImGuiCol aColorType, float aAlphaMultiply = 1f)
    {
        return ImguiNative.GetColorU32_Col((int)aColorType, aAlphaMultiply);
    }
    
    public static uint GetColorU32(uint aColor, float aAlphaMultiply = 1f)
    {
        return ImguiNative.GetColorU32_U32(aColor, aAlphaMultiply);
    }
    
    public static uint GetColorU32(Vector4 aColor)
    {
        return ImguiNative.GetColorU32_Vec4(aColor);
    }
    
    public static ImguiDrawList GetWindowDrawList()
    {
        return new(ImguiNative.GetWindowDrawList());
    }
    
    public static bool IsItemClicked(ImGuiMouseButton aMouseButton = ImGuiMouseButton.Left)
    {
        return ImguiNative.IsItemClicked((int)aMouseButton) > 0;
    }
    
    public static void OpenPopup(string aPopupName, ImGuiPopupFlags aFlags = 0)
    {
        ImguiNative.OpenPopup_Str(aPopupName.AsBytes(), (int)aFlags);
    }
    
    public static void OpenPopup(uint aId, ImGuiPopupFlags aFlags)
    {
        ImguiNative.OpenPopup_ID(aId, (int)aFlags);
    }
    
    public static bool BeginPopup(string aPopupName, ImGuiWindowFlags aFlags = 0)
    {
        return ImguiNative.BeginPopup(aPopupName.AsBytes(), (int)aFlags) > 0;
    }
    
    public static void EndPopup()
    {
        ImguiNative.EndPopup();
    }
    
    public static void SeparatorText(string aLabel)
    {
        ImguiNative.SeparatorText(aLabel.AsBytes());
    }
    
    public static bool Selectable(string aLabel, bool aSelected = true, ImGuiSelectableFlags aFlags = (ImGuiSelectableFlags)0, Vector2 aSize = new Vector2())
    {
        ImGuiSelectableFlags flags = (ImGuiSelectableFlags)0;
        return ImguiNative.Selectable_Bool(aLabel.AsBytes(), aSelected ? (byte)1 : (byte)0, (int)aFlags, aSize) > 0;
    }
    
    public static void TreePop()
    {
        ImguiNative.TreePop();
    }
    
    public static bool TreeNodeEx(string str_id, ImGuiTreeNodeFlags flags, string fmt = "")
    {
        ImGuiListClipper clipper = new();
        return ImguiNative.TreeNodeEx_StrStr(str_id.AsBytes(), (int)flags, fmt.AsBytes(), __arglist(0)) > 0;
    }
    
    public static ImguiStyle GetStyle()
    {
        return ImguiNative.GetStyle();
    }

    public static bool InputText(string aName, ref string aString, int aCount, ImGuiInputTextFlags aFlags = 0)
    {
        return ImguiNative.InputText(aName.AsBytes(), aString.AsBytes(), (uint)aCount, (int)aFlags, null, null) > 0;
    }

    public static bool InputInt(string aName, ref int aNumber, int aStep = 1, int aStepFast = 100, ImGuiInputTextFlags aFlags = 0)
    {
        fixed(int* number = &aNumber)
            return ImguiNative.InputInt(aName.AsBytes(), number, aStep, aStepFast, (int)aFlags) > 0;
    }

    public static bool DragFloat(string aName, ref float aNumber, float aSpeed = 1f, float aMin = 0f, float aMax = 0f, string aFormat = "%.3f", ImGuiSliderFlags aFlags = 0)
    {
        fixed(float* number = &aNumber)
            return ImguiNative.DragFloat(aName.AsBytes(), number, aSpeed, aMin , aMax, aFormat.AsBytes(), (int)aFlags) > 0;
    }

    public static bool ColorPicker4(string aName, ref Vector4 aColorAsVec4, ImGuiColorEditFlags aFlags = 0)
    {
        fixed (Vector4* color = &aColorAsVec4)
        {
            return ImguiNative.ColorPicker4(aName.AsBytes(), (float*)color, (int)aFlags, null) > 0;
        }
    }
    
    public static bool DragFloat2(string aName, ref Vector2 aNumber, float aSpeed = 1f, float aMin = 0f, float aMax = 0f, string aFormat = "%.3f", ImGuiSliderFlags aFlags = 0)
    {
        fixed(Vector2* number = &aNumber)
            return ImguiNative.DragFloat2(aName.AsBytes(), (float*)number, aSpeed, aMin , aMax, aFormat.AsBytes(), (int)aFlags) > 0;
    }

    public static bool DragFloat3(string aName, ref Vector3 aNumber, float aSpeed = 1f, float aMin = 0f, float aMax = 0f, string aFormat = "%.3f", ImGuiSliderFlags aFlags = 0)
    {
        fixed(Vector3* number = &aNumber)
            return ImguiNative.DragFloat3(aName.AsBytes(), (float*)number, aSpeed, aMin , aMax, aFormat.AsBytes(), (int)aFlags) > 0;
    }
    
    public static bool DragFloat4(string aName, ref Vector4 aNumber, float aSpeed = 1f, float aMin = 0f, float aMax = 0f, string aFormat = "%.3f", ImGuiSliderFlags aFlags = 0)
    {
        fixed(Vector4* number = &aNumber)
            return ImguiNative.DragFloat4(aName.AsBytes(), (float*)number, aSpeed, aMin , aMax, aFormat.AsBytes(), (int)aFlags) > 0;
    }

    public static void SameLine(float aOffsetFromStartX = 0f, float aSpacing = -1f)
    {
        ImguiNative.SameLine(aOffsetFromStartX, aSpacing);
    }

    public static void BeginDisabled(bool aDisabled = true)
    {
        ImguiNative.BeginDisabled((byte)(aDisabled ? 1 : 0));
    }
    
    public static void EndDisabled()
    {
        ImguiNative.EndDisabled();
    }

    public static bool Button(string aLabel, Vector2 aSize = new Vector2())
    {
        return ImguiNative.Button(aLabel.AsBytes(), aSize) > 0;
    }
    
    public static bool BeginChild(string aLabel, Vector2 aSize = new(), ImGuiChildFlags aChildFlags = 0, ImGuiWindowFlags aWindowFlags = 0)
    {
        return ImguiNative.BeginChild_Str(aLabel.AsBytes(), aSize, (int)aChildFlags, (int)aWindowFlags) > 0; 
    }

    public static void EndChild()
    {
        ImguiNative.EndChild();
    }

    public static void TextColored(Vector4 aColor, string aFormat)
    {
        ImguiNative.TextColored(aColor, aFormat.AsBytes(), __arglist());
    }

    public static bool BeginCombo(string aName, string aPreviewValue, ImGuiComboFlags aComboFlags = 0)
    {
        return ImguiNative.BeginCombo(aName.AsBytes(), aPreviewValue.AsBytes(), (int)aComboFlags) > 0;
    }
    
    public static void EndCombo()
    {
        ImguiNative.EndCombo();
    }

    public static void SetItemDefaultFocus()
    {
        ImguiNative.SetItemDefaultFocus();
    }
    
    public static bool CollapsingHeader(string aHeader, ImGuiTreeNodeFlags aFlags)
    {
        return ImguiNative.CollapsingHeader_TreeNodeFlags(aHeader.AsBytes(), (int)aFlags) > 0;
    }

    public static ImGuiViewport* GetMainViewport()
    {
        return ImguiNative.GetMainViewport();
    }

    public static void SetNextWindowPos(Vector2 aSize, ImGuiCond aCond = 0, Vector2 aPivot = new())
    {
        ImguiNative.SetNextWindowPos(aSize, (int)aCond, aPivot);
    }

    public static void SetNextWindowSize(Vector2 aSize, ImGuiCond aCond = 0)
    {
        ImguiNative.SetNextWindowSize(aSize, (int)aCond);
    }

    public static bool BeginMainMenuBar()
    {
        return ImguiNative.BeginMainMenuBar() > 0;
    }

    public static bool BeginMenu(string aLabel, bool aEnabled = true)
    {
        return ImguiNative.BeginMenu(aLabel.AsBytes(), (byte)(aEnabled ? 1 : 0)) > 0;
    }
    
    public static bool MenuItem(string aLabel, string? aShortcut = null, bool aSelected = false, bool aEnabled = true)
    {
        return ImguiNative.MenuItem_Bool(aLabel.AsBytes(), aShortcut != null ? aShortcut.AsBytes() : null, (byte)(aSelected ? 1 : 0), (byte)(aEnabled ? 1 : 0)) > 0;
    }

    public static void Separator()
    {
        ImguiNative.Separator();
    }

    public static void EndMainMenuBar()
    {
        ImguiNative.EndMainMenuBar();
    }

    public static void PlotLines(string aLabel, ref float aValueStart, int aValueCount, Vector2 aGraphSize = new(), int aValuesOffset = 3, string aOverlayText = "", float aScaleMin = float.MinValue, float aScaleMax = float.MaxValue, int aStride = sizeof(float))
    {
        fixed (float* valPtr = &aValueStart)
            ImguiNative.PlotLines_FloatPtr(aLabel.AsBytes(), valPtr, aValueCount, aValuesOffset, aOverlayText.AsBytes(), aScaleMin, aScaleMax, aGraphSize, aStride);
    }

    public static void DockSpaceOverViewport(uint aDockspaceId = 0, ImGuiViewport* aViewport = null, ImGuiDockNodeFlags aFlags = 0, ImGuiWindowClass* aWindowClass = null)
    {
        ImguiNative.DockSpaceOverViewport(aDockspaceId, aViewport, (int)aFlags, aWindowClass);
    }

    public static void ShowDemoWindow()
    {
        bool enabled = true;
        ShowDemoWindow(ref enabled);
    }
    
    public static void ShowAboutWindow()
    {
        bool enabled = true;
        ShowAboutWindow(ref enabled);
    }
    
    public static void ShowDemoWindow(ref bool aEnabled)
    {
        fixed(bool* enabled = &aEnabled)
            ImguiNative.ShowDemoWindow(enabled);
    }
    
    public static void ShowAboutWindow(ref bool aEnabled)
    {
        fixed(bool* enabled = &aEnabled)
            ImguiNative.ShowAboutWindow(enabled);
    }

    public static bool DragInt(string aName, ref int aInt, float aSpeed = 1f, int aMin = Int32.MinValue, int aMax = Int32.MaxValue, string aFormat = "%d", ImGuiSliderFlags aFlags = 0)
    {
        fixed (int* intPtr = &aInt)
            return ImguiNative.DragInt(aName.AsBytes(), intPtr, aSpeed, aMin, aMax,aFormat.AsBytes(), (int)aFlags) > 0;
    }
}

public unsafe partial class ImguiListClipper
{
    private ImGuiListClipper* mNativeClipperPtr;
    
    public ref int DisplayStart => ref Unsafe.AsRef<int>(&mNativeClipperPtr->DisplayStart);
    public ref int DisplayEnd => ref Unsafe.AsRef<int>(&mNativeClipperPtr->DisplayEnd);
    public ref int ItemsCount => ref Unsafe.AsRef<int>(&mNativeClipperPtr->ItemsCount);
    public ref float ItemsHeight => ref Unsafe.AsRef<float>(&mNativeClipperPtr->ItemsHeight);
    public ref float StartPosY => ref Unsafe.AsRef<float>(&mNativeClipperPtr->StartPosY);
    
    public ImguiListClipper()
    {
        mNativeClipperPtr = ImguiNative.ImGuiListClipper_ImGuiListClipper();
    }
    
    public void Begin(int aItemsCount, float aItemsHeight)
    {
        ImguiNative.ImGuiListClipper_Begin(mNativeClipperPtr, aItemsCount, aItemsHeight);
    }
    
    public bool Step()
    {
        return ImguiNative.ImGuiListClipper_Step(mNativeClipperPtr) > 0;
    }
    
    public void Destroy()
    {
        ImguiNative.ImGuiListClipper_destroy(mNativeClipperPtr);
    }
}

public unsafe partial class ImguiDrawList
{
    private ImDrawList* mNativeDrawListPtr;
    
    internal ImguiDrawList(ImDrawList* aNativePtr)
    {
        mNativeDrawListPtr = aNativePtr;
    }
    
    public void AddRectFilled(Vector2 aMin, Vector2 aMax, uint aColor, float aRounding = 0f, ImDrawFlags_ aDrawFlags = (ImDrawFlags_)0)
    {
        ImguiNative.ImDrawList_AddRectFilled(mNativeDrawListPtr, aMin, aMax, aColor, aRounding, (int)aDrawFlags);
    }

    public void AddText(Vector2 aCursorPosition, uint aRequestedU32Color, string aString)
    {
        int size = System.Text.UTF8Encoding.Unicode.GetByteCount(aString) + 1;
        sbyte* bytes = aString.AsBytes();
        ImguiNative.ImDrawList_AddText_Vec2(mNativeDrawListPtr, aCursorPosition, aRequestedU32Color, bytes, bytes + size);
    }
}

public unsafe partial struct ImguiStyle
{
    public ImGuiStyle* NativePtr { get; }
    public ImguiStyle(ImGuiStyle* nativePtr) => NativePtr = nativePtr;
    public ImguiStyle(IntPtr nativePtr) => NativePtr = (ImGuiStyle*)nativePtr;
    public static implicit operator ImguiStyle(ImGuiStyle* nativePtr) => new ImguiStyle(nativePtr);
    public static implicit operator ImGuiStyle* (ImguiStyle wrappedPtr) => wrappedPtr.NativePtr;
    public static implicit operator ImguiStyle(IntPtr nativePtr) => new ImguiStyle(nativePtr);
    public ref float Alpha => ref Unsafe.AsRef<float>(&NativePtr->Alpha);
    public ref float DisabledAlpha => ref Unsafe.AsRef<float>(&NativePtr->DisabledAlpha);
    public ref Vector2 WindowPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->WindowPadding);
    public ref float WindowRounding => ref Unsafe.AsRef<float>(&NativePtr->WindowRounding);
    public ref float WindowBorderSize => ref Unsafe.AsRef<float>(&NativePtr->WindowBorderSize);
    public ref Vector2 WindowMinSize => ref Unsafe.AsRef<Vector2>(&NativePtr->WindowMinSize);
    public ref Vector2 WindowTitleAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->WindowTitleAlign);
    public ref ImGuiDir WindowMenuButtonPosition => ref Unsafe.AsRef<ImGuiDir>(&NativePtr->WindowMenuButtonPosition);
    public ref float ChildRounding => ref Unsafe.AsRef<float>(&NativePtr->ChildRounding);
    public ref float ChildBorderSize => ref Unsafe.AsRef<float>(&NativePtr->ChildBorderSize);
    public ref float PopupRounding => ref Unsafe.AsRef<float>(&NativePtr->PopupRounding);
    public ref float PopupBorderSize => ref Unsafe.AsRef<float>(&NativePtr->PopupBorderSize);
    public ref Vector2 FramePadding => ref Unsafe.AsRef<Vector2>(&NativePtr->FramePadding);
    public ref float FrameRounding => ref Unsafe.AsRef<float>(&NativePtr->FrameRounding);
    public ref float FrameBorderSize => ref Unsafe.AsRef<float>(&NativePtr->FrameBorderSize);
    public ref Vector2 ItemSpacing => ref Unsafe.AsRef<Vector2>(&NativePtr->ItemSpacing);
    public ref Vector2 ItemInnerSpacing => ref Unsafe.AsRef<Vector2>(&NativePtr->ItemInnerSpacing);
    public ref Vector2 CellPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->CellPadding);
    public ref Vector2 TouchExtraPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->TouchExtraPadding);
    public ref float IndentSpacing => ref Unsafe.AsRef<float>(&NativePtr->IndentSpacing);
    public ref float ColumnsMinSpacing => ref Unsafe.AsRef<float>(&NativePtr->ColumnsMinSpacing);
    public ref float ScrollbarSize => ref Unsafe.AsRef<float>(&NativePtr->ScrollbarSize);
    public ref float ScrollbarRounding => ref Unsafe.AsRef<float>(&NativePtr->ScrollbarRounding);
    public ref float GrabMinSize => ref Unsafe.AsRef<float>(&NativePtr->GrabMinSize);
    public ref float GrabRounding => ref Unsafe.AsRef<float>(&NativePtr->GrabRounding);
    public ref float LogSliderDeadzone => ref Unsafe.AsRef<float>(&NativePtr->LogSliderDeadzone);
    public ref float TabRounding => ref Unsafe.AsRef<float>(&NativePtr->TabRounding);
    public ref float TabBorderSize => ref Unsafe.AsRef<float>(&NativePtr->TabBorderSize);
    public ref float TabCloseButtonMinWidthSelected => ref Unsafe.AsRef<float>(&NativePtr->TabCloseButtonMinWidthSelected);
    public ref float TabCloseButtonMinWidthUnselected => ref Unsafe.AsRef<float>(&NativePtr->TabCloseButtonMinWidthUnselected);
    public ref float TabBarBorderSize => ref Unsafe.AsRef<float>(&NativePtr->TabBarBorderSize);
    public ref float TableAngledHeadersAngle => ref Unsafe.AsRef<float>(&NativePtr->TableAngledHeadersAngle);
    public ref Vector2 TableAngledHeadersTextAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->TableAngledHeadersTextAlign);
    public ref ImGuiDir ColorButtonPosition => ref Unsafe.AsRef<ImGuiDir>(&NativePtr->ColorButtonPosition);
    public ref Vector2 ButtonTextAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->ButtonTextAlign);
    public ref Vector2 SelectableTextAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->SelectableTextAlign);
    public ref float SeparatorTextBorderSize => ref Unsafe.AsRef<float>(&NativePtr->SeparatorTextBorderSize);
    public ref Vector2 SeparatorTextAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->SeparatorTextAlign);
    public ref Vector2 SeparatorTextPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->SeparatorTextPadding);
    public ref Vector2 DisplayWindowPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplayWindowPadding);
    public ref Vector2 DisplaySafeAreaPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplaySafeAreaPadding);
    public ref float DockingSeparatorSize => ref Unsafe.AsRef<float>(&NativePtr->DockingSeparatorSize);
    public ref float MouseCursorScale => ref Unsafe.AsRef<float>(&NativePtr->MouseCursorScale);
    public ref bool AntiAliasedLines => ref Unsafe.AsRef<bool>(&NativePtr->AntiAliasedLines);
    public ref bool AntiAliasedLinesUseTex => ref Unsafe.AsRef<bool>(&NativePtr->AntiAliasedLinesUseTex);
    public ref bool AntiAliasedFill => ref Unsafe.AsRef<bool>(&NativePtr->AntiAliasedFill);
    public ref float CurveTessellationTol => ref Unsafe.AsRef<float>(&NativePtr->CurveTessellationTol);
    public ref float CircleTessellationMaxError => ref Unsafe.AsRef<float>(&NativePtr->CircleTessellationMaxError);
    public RangeAccessor<Vector4> Colors => new RangeAccessor<Vector4>(&NativePtr->Colors.e0, (int)ImGuiCol.COUNT);
    public ref float HoverStationaryDelay => ref Unsafe.AsRef<float>(&NativePtr->HoverStationaryDelay);
    public ref float HoverDelayShort => ref Unsafe.AsRef<float>(&NativePtr->HoverDelayShort);
    public ref float HoverDelayNormal => ref Unsafe.AsRef<float>(&NativePtr->HoverDelayNormal);
    public ref ImGuiHoveredFlags HoverFlagsForTooltipMouse => ref Unsafe.AsRef<ImGuiHoveredFlags>(&NativePtr->HoverFlagsForTooltipMouse);
    public ref ImGuiHoveredFlags HoverFlagsForTooltipNav => ref Unsafe.AsRef<ImGuiHoveredFlags>(&NativePtr->HoverFlagsForTooltipNav);
    public void Destroy()
    {
        ImguiNative.ImGuiStyle_destroy((ImGuiStyle*)(NativePtr));
    }
    public void ScaleAllSizes(float scale_factor)
    {
        ImguiNative.ImGuiStyle_ScaleAllSizes((ImGuiStyle*)(NativePtr), scale_factor);
    }
}

public unsafe partial struct ImguiStorage
{
    public ImGuiStorage* NativePtr { get; }
    public ImguiStorage(ImGuiStorage* nativePtr) => NativePtr = nativePtr;
    public ImguiStorage(IntPtr nativePtr) => NativePtr = (ImGuiStorage*)nativePtr;
    public static implicit operator ImguiStorage(ImGuiStorage* nativePtr) => new ImguiStorage(nativePtr);
    public static implicit operator ImGuiStorage* (ImguiStorage wrappedPtr) => wrappedPtr.NativePtr;
    public static implicit operator ImguiStorage(IntPtr nativePtr) => new ImguiStorage(nativePtr);
    public void BuildSortByKey()
    {
        ImguiNative.ImGuiStorage_BuildSortByKey((ImGuiStorage*)(NativePtr));
    }
    public void Clear()
    {
        ImguiNative.ImGuiStorage_Clear((ImGuiStorage*)(NativePtr));
    }
    public bool GetBool(uint key)
    {
        byte default_val = 0;
        byte ret = ImguiNative.ImGuiStorage_GetBool((ImGuiStorage*)(NativePtr), key, default_val);
        return ret != 0;
    }
    public bool GetBool(uint key, bool default_val)
    {
        byte native_default_val = default_val ? (byte)1 : (byte)0;
        byte ret = ImguiNative.ImGuiStorage_GetBool((ImGuiStorage*)(NativePtr), key, native_default_val);
        return ret != 0;
    }
    public byte* GetBoolRef(uint key)
    {
        byte default_val = 0;
        byte* ret = (byte*)ImguiNative.ImGuiStorage_GetBoolRef((ImGuiStorage*)(NativePtr), key, default_val);
        return ret;
    }
    public byte* GetBoolRef(uint key, bool default_val)
    {
        byte native_default_val = default_val ? (byte)1 : (byte)0;
        byte* ret = (byte*)ImguiNative.ImGuiStorage_GetBoolRef((ImGuiStorage*)(NativePtr), key, native_default_val);
        return ret;
    }
    public float GetFloat(uint key)
    {
        float default_val = 0.0f;
        float ret = ImguiNative.ImGuiStorage_GetFloat((ImGuiStorage*)(NativePtr), key, default_val);
        return ret;
    }
    public float GetFloat(uint key, float default_val)
    {
        float ret = ImguiNative.ImGuiStorage_GetFloat((ImGuiStorage*)(NativePtr), key, default_val);
        return ret;
    }
    public float* GetFloatRef(uint key)
    {
        float default_val = 0.0f;
        float* ret = ImguiNative.ImGuiStorage_GetFloatRef((ImGuiStorage*)(NativePtr), key, default_val);
        return ret;
    }
    public float* GetFloatRef(uint key, float default_val)
    {
        float* ret = ImguiNative.ImGuiStorage_GetFloatRef((ImGuiStorage*)(NativePtr), key, default_val);
        return ret;
    }
    public int GetInt(uint key)
    {
        int default_val = 0;
        int ret = ImguiNative.ImGuiStorage_GetInt((ImGuiStorage*)(NativePtr), key, default_val);
        return ret;
    }
    public int GetInt(uint key, int default_val)
    {
        int ret = ImguiNative.ImGuiStorage_GetInt((ImGuiStorage*)(NativePtr), key, default_val);
        return ret;
    }
    public int* GetIntRef(uint key)
    {
        int default_val = 0;
        int* ret = ImguiNative.ImGuiStorage_GetIntRef((ImGuiStorage*)(NativePtr), key, default_val);
        return ret;
    }
    public int* GetIntRef(uint key, int default_val)
    {
        int* ret = ImguiNative.ImGuiStorage_GetIntRef((ImGuiStorage*)(NativePtr), key, default_val);
        return ret;
    }
    public IntPtr GetVoidPtr(uint key)
    {
        void* ret = ImguiNative.ImGuiStorage_GetVoidPtr((ImGuiStorage*)(NativePtr), key);
        return (IntPtr)ret;
    }
    public void** GetVoidPtrRef(uint key)
    {
        void* default_val = null;
        void** ret = ImguiNative.ImGuiStorage_GetVoidPtrRef((ImGuiStorage*)(NativePtr), key, default_val);
        return ret;
    }
    public void** GetVoidPtrRef(uint key, IntPtr default_val)
    {
        void* native_default_val = (void*)default_val.ToPointer();
        void** ret = ImguiNative.ImGuiStorage_GetVoidPtrRef((ImGuiStorage*)(NativePtr), key, native_default_val);
        return ret;
    }
    public void SetAllInt(int val)
    {
        ImguiNative.ImGuiStorage_SetAllInt((ImGuiStorage*)(NativePtr), val);
    }
    public void SetBool(uint key, bool val)
    {
        byte native_val = val ? (byte)1 : (byte)0;
        ImguiNative.ImGuiStorage_SetBool((ImGuiStorage*)(NativePtr), key, native_val);
    }
    public void SetFloat(uint key, float val)
    {
        ImguiNative.ImGuiStorage_SetFloat((ImGuiStorage*)(NativePtr), key, val);
    }
    public void SetInt(uint key, int val)
    {
        ImguiNative.ImGuiStorage_SetInt((ImGuiStorage*)(NativePtr), key, val);
    }
    public void SetVoidPtr(uint key, IntPtr val)
    {
        void* native_val = (void*)val.ToPointer();
        ImguiNative.ImGuiStorage_SetVoidPtr((ImGuiStorage*)(NativePtr), key, native_val);
    }
}
