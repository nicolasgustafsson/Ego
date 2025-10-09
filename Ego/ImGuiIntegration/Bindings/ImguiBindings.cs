using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ImguiBindings
{
    public partial struct ImGuiDockRequest
    {
    }

    public partial struct ImGuiDockRequest
    {
    }

    public partial struct ImGuiDockNodeSettings
    {
    }

    public partial struct ImGuiDockNodeSettings
    {
    }

    public partial struct ImGuiInputTextDeactivateData
    {
    }

    public partial struct ImGuiInputTextDeactivateData
    {
    }

    public partial struct ImGuiTableColumnsSettings
    {
    }

    public partial struct ImGuiTableColumnsSettings
    {
    }

    public partial struct STB_TexteditState
    {
    }

    public partial struct STB_TexteditState
    {
    }

    public partial struct stbrp_node
    {
    }

    public partial struct stbrp_node
    {
    }

    public unsafe partial struct ImVector_const_charPtr
    {
        public int Size;

        public int Capacity;

        [NativeTypeName("const char **")]
        public sbyte** Data;
    }

    public unsafe partial struct ImTextureRef
    {
        public ImTextureData* _TexData;

        [NativeTypeName("ImTextureID")]
        public ulong _TexID;
    }

    public enum ImGuiWindowFlags
    {
        None = 0,
        NoTitleBar = 1 << 0,
        NoResize = 1 << 1,
        NoMove = 1 << 2,
        NoScrollbar = 1 << 3,
        NoScrollWithMouse = 1 << 4,
        NoCollapse = 1 << 5,
        AlwaysAutoResize = 1 << 6,
        NoBackground = 1 << 7,
        NoSavedSettings = 1 << 8,
        NoMouseInputs = 1 << 9,
        MenuBar = 1 << 10,
        HorizontalScrollbar = 1 << 11,
        NoFocusOnAppearing = 1 << 12,
        NoBringToFrontOnFocus = 1 << 13,
        AlwaysVerticalScrollbar = 1 << 14,
        AlwaysHorizontalScrollbar = 1 << 15,
        NoNavInputs = 1 << 16,
        NoNavFocus = 1 << 17,
        UnsavedDocument = 1 << 18,
        NoDocking = 1 << 19,
        NoNav = NoNavInputs | NoNavFocus,
        NoDecoration = NoTitleBar | NoResize | NoScrollbar | NoCollapse,
        NoInputs = NoMouseInputs | NoNavInputs | NoNavFocus,
        DockNodeHost = 1 << 23,
        ChildWindow = 1 << 24,
        Tooltip = 1 << 25,
        Popup = 1 << 26,
        Modal = 1 << 27,
        ChildMenu = 1 << 28,
    }

    public enum ImGuiChildFlags
    {
        None = 0,
        Borders = 1 << 0,
        AlwaysUseWindowPadding = 1 << 1,
        ResizeX = 1 << 2,
        ResizeY = 1 << 3,
        AutoResizeX = 1 << 4,
        AutoResizeY = 1 << 5,
        AlwaysAutoResize = 1 << 6,
        FrameStyle = 1 << 7,
        NavFlattened = 1 << 8,
    }

    public enum ImGuiItemFlags
    {
        None = 0,
        NoTabStop = 1 << 0,
        NoNav = 1 << 1,
        NoNavDefaultFocus = 1 << 2,
        ButtonRepeat = 1 << 3,
        AutoClosePopups = 1 << 4,
        AllowDuplicateId = 1 << 5,
    }

    public enum ImGuiInputTextFlags
    {
        None = 0,
        CharsDecimal = 1 << 0,
        CharsHexadecimal = 1 << 1,
        CharsScientific = 1 << 2,
        CharsUppercase = 1 << 3,
        CharsNoBlank = 1 << 4,
        AllowTabInput = 1 << 5,
        EnterReturnsTrue = 1 << 6,
        EscapeClearsAll = 1 << 7,
        CtrlEnterForNewLine = 1 << 8,
        ReadOnly = 1 << 9,
        Password = 1 << 10,
        AlwaysOverwrite = 1 << 11,
        AutoSelectAll = 1 << 12,
        ParseEmptyRefVal = 1 << 13,
        DisplayEmptyRefVal = 1 << 14,
        NoHorizontalScroll = 1 << 15,
        NoUndoRedo = 1 << 16,
        ElideLeft = 1 << 17,
        CallbackCompletion = 1 << 18,
        CallbackHistory = 1 << 19,
        CallbackAlways = 1 << 20,
        CallbackCharFilter = 1 << 21,
        CallbackResize = 1 << 22,
        CallbackEdit = 1 << 23,
        WordWrap = 1 << 24,
    }

    public enum ImGuiTreeNodeFlags
    {
        None = 0,
        Selected = 1 << 0,
        Framed = 1 << 1,
        AllowOverlap = 1 << 2,
        NoTreePushOnOpen = 1 << 3,
        NoAutoOpenOnLog = 1 << 4,
        DefaultOpen = 1 << 5,
        OpenOnDoubleClick = 1 << 6,
        OpenOnArrow = 1 << 7,
        Leaf = 1 << 8,
        Bullet = 1 << 9,
        FramePadding = 1 << 10,
        SpanAvailWidth = 1 << 11,
        SpanFullWidth = 1 << 12,
        SpanLabelWidth = 1 << 13,
        SpanAllColumns = 1 << 14,
        LabelSpanAllColumns = 1 << 15,
        NavLeftJumpsToParent = 1 << 17,
        CollapsingHeader = Framed | NoTreePushOnOpen |NoAutoOpenOnLog,
        DrawLinesNone = 1 << 18,
        DrawLinesFull = 1 << 19,
        DrawLinesToNodes = 1 << 20,
    }

    public enum ImGuiPopupFlags
    {
        None = 0,
        MouseButtonLeft = 0,
        MouseButtonRight = 1,
        MouseButtonMiddle = 2,
        MouseButtonMask_ = 0x1F,
        MouseButtonDefault_ = 1,
        NoReopen = 1 << 5,
        NoOpenOverExistingPopup = 1 << 7,
        NoOpenOverItems = 1 << 8,
        AnyPopupId = 1 << 10,
        AnyPopupLevel = 1 << 11,
        AnyPopup = AnyPopupId | AnyPopupLevel,
    }

    public enum ImGuiSelectableFlags
    {
        None = 0,
        NoAutoClosePopups = 1 << 0,
        SpanAllColumns = 1 << 1,
        AllowDoubleClick = 1 << 2,
        Disabled = 1 << 3,
        AllowOverlap = 1 << 4,
        Highlight = 1 << 5,
        SelectOnNav = 1 << 6,
    }

    public enum ImGuiComboFlags
    {
        None = 0,
        PopupAlignLeft = 1 << 0,
        HeightSmall = 1 << 1,
        HeightRegular = 1 << 2,
        HeightLarge = 1 << 3,
        HeightLargest = 1 << 4,
        NoArrowButton = 1 << 5,
        NoPreview = 1 << 6,
        WidthFitPreview = 1 << 7,
        HeightMask_ = HeightSmall | HeightRegular | HeightLarge | HeightLargest,
    }

    public enum ImGuiTabBarFlags
    {
        None = 0,
        Reorderable = 1 << 0,
        AutoSelectNewTabs = 1 << 1,
        TabListPopupButton = 1 << 2,
        NoCloseWithMiddleMouseButton = 1 << 3,
        NoTabListScrollingButtons = 1 << 4,
        NoTooltip = 1 << 5,
        DrawSelectedOverline = 1 << 6,
        FittingPolicyMixed = 1 << 7,
        FittingPolicyShrink = 1 << 8,
        FittingPolicyScroll = 1 << 9,
        FittingPolicyMask_ = FittingPolicyMixed | FittingPolicyShrink | FittingPolicyScroll,
        FittingPolicyDefault_ = FittingPolicyMixed,
    }

    public enum ImGuiTabItemFlags
    {
        None = 0,
        UnsavedDocument = 1 << 0,
        SetSelected = 1 << 1,
        NoCloseWithMiddleMouseButton = 1 << 2,
        NoPushId = 1 << 3,
        NoTooltip = 1 << 4,
        NoReorder = 1 << 5,
        Leading = 1 << 6,
        Trailing = 1 << 7,
        NoAssumedClosure = 1 << 8,
    }

    public enum ImGuiFocusedFlags
    {
        None = 0,
        ChildWindows = 1 << 0,
        RootWindow = 1 << 1,
        AnyWindow = 1 << 2,
        NoPopupHierarchy = 1 << 3,
        DockHierarchy = 1 << 4,
        RootAndChildWindows = RootWindow | ChildWindows,
    }

    public enum ImGuiHoveredFlags
    {
        None = 0,
        ChildWindows = 1 << 0,
        RootWindow = 1 << 1,
        AnyWindow = 1 << 2,
        NoPopupHierarchy = 1 << 3,
        DockHierarchy = 1 << 4,
        AllowWhenBlockedByPopup = 1 << 5,
        AllowWhenBlockedByActiveItem = 1 << 7,
        AllowWhenOverlappedByItem = 1 << 8,
        AllowWhenOverlappedByWindow = 1 << 9,
        AllowWhenDisabled = 1 << 10,
        NoNavOverride = 1 << 11,
        AllowWhenOverlapped = AllowWhenOverlappedByItem | AllowWhenOverlappedByWindow,
        RectOnly = AllowWhenBlockedByPopup | AllowWhenBlockedByActiveItem | AllowWhenOverlapped,
        RootAndChildWindows = RootWindow | ChildWindows,
        ForTooltip = 1 << 12,
        Stationary = 1 << 13,
        DelayNone = 1 << 14,
        DelayShort = 1 << 15,
        DelayNormal = 1 << 16,
        NoSharedDelay = 1 << 17,
    }

    public enum ImGuiDockNodeFlags
    {
        None = 0,
        KeepAliveOnly = 1 << 0,
        NoDockingOverCentralNode = 1 << 2,
        PassthruCentralNode = 1 << 3,
        NoDockingSplit = 1 << 4,
        NoResize = 1 << 5,
        AutoHideTabBar = 1 << 6,
        NoUndocking = 1 << 7,
    }

    public enum ImGuiDragDropFlags
    {
        None = 0,
        SourceNoPreviewTooltip = 1 << 0,
        SourceNoDisableHover = 1 << 1,
        SourceNoHoldToOpenOthers = 1 << 2,
        SourceAllowNullID = 1 << 3,
        SourceExtern = 1 << 4,
        PayloadAutoExpire = 1 << 5,
        PayloadNoCrossContext = 1 << 6,
        PayloadNoCrossProcess = 1 << 7,
        AcceptBeforeDelivery = 1 << 10,
        AcceptNoDrawDefaultRect = 1 << 11,
        AcceptNoPreviewTooltip = 1 << 12,
        AcceptPeekOnly = AcceptBeforeDelivery | AcceptNoDrawDefaultRect,
    }

    public enum ImGuiDataType
    {
        S8,
        U8,
        S16,
        U16,
        S32,
        U32,
        S64,
        U64,
        Float,
        Double,
        Bool,
        String,
        COUNT,
    }

    public enum ImGuiDir
    {
        None = -1,
        Left = 0,
        Right = 1,
        Up = 2,
        Down = 3,
        COUNT = 4,
    }

    public enum ImGuiSortDirection
    {
        None = 0,
        Ascending = 1,
        Descending = 2,
    }

    public enum ImGuiKey
    {
        None = 0,
        NamedKey_BEGIN = 512,
        Tab = 512,
        LeftArrow = 513,
        RightArrow = 514,
        UpArrow = 515,
        DownArrow = 516,
        PageUp = 517,
        PageDown = 518,
        Home = 519,
        End = 520,
        Insert = 521,
        Delete = 522,
        Backspace = 523,
        Space = 524,
        Enter = 525,
        Escape = 526,
        LeftCtrl = 527,
        LeftShift = 528,
        LeftAlt = 529,
        LeftSuper = 530,
        RightCtrl = 531,
        RightShift = 532,
        RightAlt = 533,
        RightSuper = 534,
        Menu = 535,
        _0 = 536,
        _1 = 537,
        _2 = 538,
        _3 = 539,
        _4 = 540,
        _5 = 541,
        _6 = 542,
        _7 = 543,
        _8 = 544,
        _9 = 545,
        A = 546,
        B = 547,
        C = 548,
        D = 549,
        E = 550,
        F = 551,
        G = 552,
        H = 553,
        I = 554,
        J = 555,
        K = 556,
        L = 557,
        M = 558,
        N = 559,
        O = 560,
        P = 561,
        Q = 562,
        R = 563,
        S = 564,
        T = 565,
        U = 566,
        V = 567,
        W = 568,
        X = 569,
        Y = 570,
        Z = 571,
        F1 = 572,
        F2 = 573,
        F3 = 574,
        F4 = 575,
        F5 = 576,
        F6 = 577,
        F7 = 578,
        F8 = 579,
        F9 = 580,
        F10 = 581,
        F11 = 582,
        F12 = 583,
        F13 = 584,
        F14 = 585,
        F15 = 586,
        F16 = 587,
        F17 = 588,
        F18 = 589,
        F19 = 590,
        F20 = 591,
        F21 = 592,
        F22 = 593,
        F23 = 594,
        F24 = 595,
        Apostrophe = 596,
        Comma = 597,
        Minus = 598,
        Period = 599,
        Slash = 600,
        Semicolon = 601,
        Equal = 602,
        LeftBracket = 603,
        Backslash = 604,
        RightBracket = 605,
        GraveAccent = 606,
        CapsLock = 607,
        ScrollLock = 608,
        NumLock = 609,
        PrintScreen = 610,
        Pause = 611,
        Keypad0 = 612,
        Keypad1 = 613,
        Keypad2 = 614,
        Keypad3 = 615,
        Keypad4 = 616,
        Keypad5 = 617,
        Keypad6 = 618,
        Keypad7 = 619,
        Keypad8 = 620,
        Keypad9 = 621,
        KeypadDecimal = 622,
        KeypadDivide = 623,
        KeypadMultiply = 624,
        KeypadSubtract = 625,
        KeypadAdd = 626,
        KeypadEnter = 627,
        KeypadEqual = 628,
        AppBack = 629,
        AppForward = 630,
        Oem102 = 631,
        GamepadStart = 632,
        GamepadBack = 633,
        GamepadFaceLeft = 634,
        GamepadFaceRight = 635,
        GamepadFaceUp = 636,
        GamepadFaceDown = 637,
        GamepadDpadLeft = 638,
        GamepadDpadRight = 639,
        GamepadDpadUp = 640,
        GamepadDpadDown = 641,
        GamepadL1 = 642,
        GamepadR1 = 643,
        GamepadL2 = 644,
        GamepadR2 = 645,
        GamepadL3 = 646,
        GamepadR3 = 647,
        GamepadLStickLeft = 648,
        GamepadLStickRight = 649,
        GamepadLStickUp = 650,
        GamepadLStickDown = 651,
        GamepadRStickLeft = 652,
        GamepadRStickRight = 653,
        GamepadRStickUp = 654,
        GamepadRStickDown = 655,
        MouseLeft = 656,
        MouseRight = 657,
        MouseMiddle = 658,
        MouseX1 = 659,
        MouseX2 = 660,
        MouseWheelX = 661,
        MouseWheelY = 662,
        ReservedForModCtrl = 663,
        ReservedForModShift = 664,
        ReservedForModAlt = 665,
        ReservedForModSuper = 666,
        NamedKey_END = 667,
        NamedKey_COUNT = NamedKey_END - NamedKey_BEGIN,
        ImGuiMod_None = 0,
        ImGuiMod_Ctrl = 1 << 12,
        ImGuiMod_Shift = 1 << 13,
        ImGuiMod_Alt = 1 << 14,
        ImGuiMod_Super = 1 << 15,
        ImGuiMod_Mask_ = 0xF000,
    }

    public enum ImGuiInputFlags
    {
        None = 0,
        Repeat = 1 << 0,
        RouteActive = 1 << 10,
        RouteFocused = 1 << 11,
        RouteGlobal = 1 << 12,
        RouteAlways = 1 << 13,
        RouteOverFocused = 1 << 14,
        RouteOverActive = 1 << 15,
        RouteUnlessBgFocused = 1 << 16,
        RouteFromRootWindow = 1 << 17,
        Tooltip = 1 << 18,
    }

    public enum ImGuiConfigFlags
    {
        None = 0,
        NavEnableKeyboard = 1 << 0,
        NavEnableGamepad = 1 << 1,
        NoMouse = 1 << 4,
        NoMouseCursorChange = 1 << 5,
        NoKeyboard = 1 << 6,
        DockingEnable = 1 << 7,
        ViewportsEnable = 1 << 10,
        IsSRGB = 1 << 20,
        IsTouchScreen = 1 << 21,
    }

    public enum ImGuiBackendFlags
    {
        None = 0,
        HasGamepad = 1 << 0,
        HasMouseCursors = 1 << 1,
        HasSetMousePos = 1 << 2,
        RendererHasVtxOffset = 1 << 3,
        RendererHasTextures = 1 << 4,
        PlatformHasViewports = 1 << 10,
        HasMouseHoveredViewport = 1 << 11,
        RendererHasViewports = 1 << 12,
    }

    public enum ImGuiCol
    {
        Text,
        TextDisabled,
        WindowBg,
        ChildBg,
        PopupBg,
        Border,
        BorderShadow,
        FrameBg,
        FrameBgHovered,
        FrameBgActive,
        TitleBg,
        TitleBgActive,
        TitleBgCollapsed,
        MenuBarBg,
        ScrollbarBg,
        ScrollbarGrab,
        ScrollbarGrabHovered,
        ScrollbarGrabActive,
        CheckMark,
        SliderGrab,
        SliderGrabActive,
        Button,
        ButtonHovered,
        ButtonActive,
        Header,
        HeaderHovered,
        HeaderActive,
        Separator,
        SeparatorHovered,
        SeparatorActive,
        ResizeGrip,
        ResizeGripHovered,
        ResizeGripActive,
        InputTextCursor,
        TabHovered,
        Tab,
        TabSelected,
        TabSelectedOverline,
        TabDimmed,
        TabDimmedSelected,
        TabDimmedSelectedOverline,
        DockingPreview,
        DockingEmptyBg,
        PlotLines,
        PlotLinesHovered,
        PlotHistogram,
        PlotHistogramHovered,
        TableHeaderBg,
        TableBorderStrong,
        TableBorderLight,
        TableRowBg,
        TableRowBgAlt,
        TextLink,
        TextSelectedBg,
        TreeLines,
        DragDropTarget,
        NavCursor,
        NavWindowingHighlight,
        NavWindowingDimBg,
        ModalWindowDimBg,
        COUNT,
    }

    public enum ImGuiStyleVar
    {
        Alpha,
        DisabledAlpha,
        WindowPadding,
        WindowRounding,
        WindowBorderSize,
        WindowMinSize,
        WindowTitleAlign,
        ChildRounding,
        ChildBorderSize,
        PopupRounding,
        PopupBorderSize,
        FramePadding,
        FrameRounding,
        FrameBorderSize,
        ItemSpacing,
        ItemInnerSpacing,
        IndentSpacing,
        CellPadding,
        ScrollbarSize,
        ScrollbarRounding,
        ScrollbarPadding,
        GrabMinSize,
        GrabRounding,
        ImageBorderSize,
        TabRounding,
        TabBorderSize,
        TabMinWidthBase,
        TabMinWidthShrink,
        TabBarBorderSize,
        TabBarOverlineSize,
        TableAngledHeadersAngle,
        TableAngledHeadersTextAlign,
        TreeLinesSize,
        TreeLinesRounding,
        ButtonTextAlign,
        SelectableTextAlign,
        SeparatorTextBorderSize,
        SeparatorTextAlign,
        SeparatorTextPadding,
        DockingSeparatorSize,
        COUNT,
    }

    public enum ImGuiButtonFlags
    {
        None = 0,
        MouseButtonLeft = 1 << 0,
        MouseButtonRight = 1 << 1,
        MouseButtonMiddle = 1 << 2,
        MouseButtonMask_ = MouseButtonLeft | MouseButtonRight | MouseButtonMiddle,
        EnableNav = 1 << 3,
    }

    public enum ImGuiColorEditFlags
    {
        None = 0,
        NoAlpha = 1 << 1,
        NoPicker = 1 << 2,
        NoOptions = 1 << 3,
        NoSmallPreview = 1 << 4,
        NoInputs = 1 << 5,
        NoTooltip = 1 << 6,
        NoLabel = 1 << 7,
        NoSidePreview = 1 << 8,
        NoDragDrop = 1 << 9,
        NoBorder = 1 << 10,
        AlphaOpaque = 1 << 11,
        AlphaNoBg = 1 << 12,
        AlphaPreviewHalf = 1 << 13,
        AlphaBar = 1 << 16,
        HDR = 1 << 19,
        DisplayRGB = 1 << 20,
        DisplayHSV = 1 << 21,
        DisplayHex = 1 << 22,
        Uint8 = 1 << 23,
        Float = 1 << 24,
        PickerHueBar = 1 << 25,
        PickerHueWheel = 1 << 26,
        InputRGB = 1 << 27,
        InputHSV = 1 << 28,
        DefaultOptions_ =Uint8 | DisplayRGB | InputRGB | PickerHueBar,
        AlphaMask_ = NoAlpha | AlphaOpaque | AlphaNoBg | AlphaPreviewHalf,
        DisplayMask_ = DisplayRGB | DisplayHSV | DisplayHex,
        DataTypeMask_ = Uint8 | Float,
        PickerMask_ = PickerHueWheel | PickerHueBar,
        InputMask_ = InputRGB | InputHSV,
    }

    public enum ImGuiSliderFlags
    {
        None = 0,
        Logarithmic = 1 << 5,
        NoRoundToFormat = 1 << 6,
        NoInput = 1 << 7,
        WrapAround = 1 << 8,
        ClampOnInput = 1 << 9,
        ClampZeroRange = 1 << 10,
        NoSpeedTweaks = 1 << 11,
        AlwaysClamp =ClampOnInput |ClampZeroRange,
        InvalidMask_ = 0x7000000F,
    }

    public enum ImGuiMouseButton
    {
        Left = 0,
        Right = 1,
        Middle = 2,
        COUNT = 5,
    }

    public enum ImGuiMouseCursor
    {
        None = -1,
        Arrow = 0,
        TextInput,
        ResizeAll,
        ResizeNS,
        ResizeEW,
        ResizeNESW,
        ResizeNWSE,
        Hand,
        Wait,
        Progress,
        NotAllowed,
        COUNT,
    }

    public enum ImGuiMouseSource
    {
        Mouse = 0,
        TouchScreen = 1,
        Pen = 2,
        COUNT = 3,
    }

    public enum ImGuiCond
    {
        None = 0,
        Always = 1 << 0,
        Once = 1 << 1,
        FirstUseEver = 1 << 2,
        Appearing = 1 << 3,
    }

    public enum ImGuiTableFlags
    {
        None = 0,
        Resizable = 1 << 0,
        Reorderable = 1 << 1,
        Hideable = 1 << 2,
        Sortable = 1 << 3,
        NoSavedSettings = 1 << 4,
        ContextMenuInBody = 1 << 5,
        RowBg = 1 << 6,
        BordersInnerH = 1 << 7,
        BordersOuterH = 1 << 8,
        BordersInnerV = 1 << 9,
        BordersOuterV = 1 << 10,
        BordersH = BordersInnerH | BordersOuterH,
        BordersV = BordersInnerV | BordersOuterV,
        BordersInner = BordersInnerV | BordersInnerH,
        BordersOuter = BordersOuterV | BordersOuterH,
        Borders = BordersInner | BordersOuter,
        NoBordersInBody = 1 << 11,
        NoBordersInBodyUntilResize = 1 << 12,
        SizingFixedFit = 1 << 13,
        SizingFixedSame = 2 << 13,
        SizingStretchProp = 3 << 13,
        SizingStretchSame = 4 << 13,
        NoHostExtendX = 1 << 16,
        NoHostExtendY = 1 << 17,
        NoKeepColumnsVisible = 1 << 18,
        PreciseWidths = 1 << 19,
        NoClip = 1 << 20,
        PadOuterX = 1 << 21,
        NoPadOuterX = 1 << 22,
        NoPadInnerX = 1 << 23,
        ScrollX = 1 << 24,
        ScrollY = 1 << 25,
        SortMulti = 1 << 26,
        SortTristate = 1 << 27,
        HighlightHoveredColumn = 1 << 28,
        SizingMask_ = SizingFixedFit | SizingFixedSame | SizingStretchProp | SizingStretchSame,
    }

    public enum ImGuiTableColumnFlags
    {
        None = 0,
        Disabled = 1 << 0,
        DefaultHide = 1 << 1,
        DefaultSort = 1 << 2,
        WidthStretch = 1 << 3,
        WidthFixed = 1 << 4,
        NoResize = 1 << 5,
        NoReorder = 1 << 6,
        NoHide = 1 << 7,
        NoClip = 1 << 8,
        NoSort = 1 << 9,
        NoSortAscending = 1 << 10,
        NoSortDescending = 1 << 11,
        NoHeaderLabel = 1 << 12,
        NoHeaderWidth = 1 << 13,
        PreferSortAscending = 1 << 14,
        PreferSortDescending = 1 << 15,
        IndentEnable = 1 << 16,
        IndentDisable = 1 << 17,
        AngledHeader = 1 << 18,
        IsEnabled = 1 << 24,
        IsVisible = 1 << 25,
        IsSorted = 1 << 26,
        IsHovered = 1 << 27,
        WidthMask_ = WidthStretch |WidthFixed,
        IndentMask_ = IndentEnable | IndentDisable,
        StatusMask_ = IsEnabled | IsVisible | IsSorted | IsHovered,
        NoDirectResize_ = 1 << 30,
    }

    public enum ImGuiTableRowFlags
    {
        None = 0,
        Headers = 1 << 0,
    }

    public enum ImGuiTableBgTarget
    {
        None = 0,
        RowBg0 = 1,
        RowBg1 = 2,
        CellBg = 3,
    }

    public unsafe partial struct ImGuiTableSortSpecs
    {
        [NativeTypeName("const ImGuiTableColumnSortSpecs *")]
        public ImGuiTableColumnSortSpecs* Specs;

        public int SpecsCount;

        [NativeTypeName("_Bool")]
        public byte SpecsDirty;
    }

    public partial struct ImGuiTableColumnSortSpecs
    {
        [NativeTypeName("ImGuiID")]
        public uint ColumnUserID;

        [NativeTypeName("ImS16")]
        public short ColumnIndex;

        [NativeTypeName("ImS16")]
        public short SortOrder;

        public ImGuiSortDirection SortDirection;
    }

    public partial struct ImGuiStyle
    {
        public float FontSizeBase;

        public float FontScaleMain;

        public float FontScaleDpi;

        public float Alpha;

        public float DisabledAlpha;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 WindowPadding;

        public float WindowRounding;

        public float WindowBorderSize;

        public float WindowBorderHoverPadding;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 WindowMinSize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 WindowTitleAlign;

        public ImGuiDir WindowMenuButtonPosition;

        public float ChildRounding;

        public float ChildBorderSize;

        public float PopupRounding;

        public float PopupBorderSize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 FramePadding;

        public float FrameRounding;

        public float FrameBorderSize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ItemSpacing;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ItemInnerSpacing;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 CellPadding;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 TouchExtraPadding;

        public float IndentSpacing;

        public float ColumnsMinSpacing;

        public float ScrollbarSize;

        public float ScrollbarRounding;

        public float ScrollbarPadding;

        public float GrabMinSize;

        public float GrabRounding;

        public float LogSliderDeadzone;

        public float ImageBorderSize;

        public float TabRounding;

        public float TabBorderSize;

        public float TabMinWidthBase;

        public float TabMinWidthShrink;

        public float TabCloseButtonMinWidthSelected;

        public float TabCloseButtonMinWidthUnselected;

        public float TabBarBorderSize;

        public float TabBarOverlineSize;

        public float TableAngledHeadersAngle;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 TableAngledHeadersTextAlign;

        [NativeTypeName("ImGuiTreeNodeFlags")]
        public int TreeLinesFlags;

        public float TreeLinesSize;

        public float TreeLinesRounding;

        public ImGuiDir ColorButtonPosition;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ButtonTextAlign;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 SelectableTextAlign;

        public float SeparatorTextBorderSize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 SeparatorTextAlign;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 SeparatorTextPadding;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 DisplayWindowPadding;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 DisplaySafeAreaPadding;

        [NativeTypeName("_Bool")]
        public byte DockingNodeHasCloseButton;

        public float DockingSeparatorSize;

        public float MouseCursorScale;

        [NativeTypeName("_Bool")]
        public byte AntiAliasedLines;

        [NativeTypeName("_Bool")]
        public byte AntiAliasedLinesUseTex;

        [NativeTypeName("_Bool")]
        public byte AntiAliasedFill;

        public float CurveTessellationTol;

        public float CircleTessellationMaxError;

        [NativeTypeName("ImVec4[60]")]
        public _Colors_e__FixedBuffer Colors;

        public float HoverStationaryDelay;

        public float HoverDelayShort;

        public float HoverDelayNormal;

        [NativeTypeName("ImGuiHoveredFlags")]
        public int HoverFlagsForTooltipMouse;

        [NativeTypeName("ImGuiHoveredFlags")]
        public int HoverFlagsForTooltipNav;

        public float _MainScale;

        public float _NextFrameFontSizeBase;

        [InlineArray(60)]
        public partial struct _Colors_e__FixedBuffer
        {
            public System.Numerics.Vector4 e0;
        }
    }

    public partial struct ImGuiKeyData
    {
        [NativeTypeName("_Bool")]
        public byte Down;

        public float DownDuration;

        public float DownDurationPrev;

        public float AnalogValue;
    }

    public unsafe partial struct ImVector_ImWchar
    {
        public int Size;

        public int Capacity;

        [NativeTypeName("ImWchar *")]
        public ushort* Data;
    }

    public unsafe partial struct ImGuiIO
    {
        [NativeTypeName("ImGuiConfigFlags")]
        public int ConfigFlags;

        [NativeTypeName("ImGuiBackendFlags")]
        public int BackendFlags;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 DisplaySize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 DisplayFramebufferScale;

        public float DeltaTime;

        public float IniSavingRate;

        [NativeTypeName("const char *")]
        public sbyte* IniFilename;

        [NativeTypeName("const char *")]
        public sbyte* LogFilename;

        public void* UserData;

        public ImFontAtlas* Fonts;

        public ImFont* FontDefault;

        [NativeTypeName("_Bool")]
        public byte FontAllowUserScaling;

        [NativeTypeName("_Bool")]
        public byte ConfigNavSwapGamepadButtons;

        [NativeTypeName("_Bool")]
        public byte ConfigNavMoveSetMousePos;

        [NativeTypeName("_Bool")]
        public byte ConfigNavCaptureKeyboard;

        [NativeTypeName("_Bool")]
        public byte ConfigNavEscapeClearFocusItem;

        [NativeTypeName("_Bool")]
        public byte ConfigNavEscapeClearFocusWindow;

        [NativeTypeName("_Bool")]
        public byte ConfigNavCursorVisibleAuto;

        [NativeTypeName("_Bool")]
        public byte ConfigNavCursorVisibleAlways;

        [NativeTypeName("_Bool")]
        public byte ConfigDockingNoSplit;

        [NativeTypeName("_Bool")]
        public byte ConfigDockingWithShift;

        [NativeTypeName("_Bool")]
        public byte ConfigDockingAlwaysTabBar;

        [NativeTypeName("_Bool")]
        public byte ConfigDockingTransparentPayload;

        [NativeTypeName("_Bool")]
        public byte ConfigViewportsNoAutoMerge;

        [NativeTypeName("_Bool")]
        public byte ConfigViewportsNoTaskBarIcon;

        [NativeTypeName("_Bool")]
        public byte ConfigViewportsNoDecoration;

        [NativeTypeName("_Bool")]
        public byte ConfigViewportsNoDefaultParent;

        [NativeTypeName("_Bool")]
        public byte ConfigViewportPlatformFocusSetsImGuiFocus;

        [NativeTypeName("_Bool")]
        public byte ConfigDpiScaleFonts;

        [NativeTypeName("_Bool")]
        public byte ConfigDpiScaleViewports;

        [NativeTypeName("_Bool")]
        public byte MouseDrawCursor;

        [NativeTypeName("_Bool")]
        public byte ConfigMacOSXBehaviors;

        [NativeTypeName("_Bool")]
        public byte ConfigInputTrickleEventQueue;

        [NativeTypeName("_Bool")]
        public byte ConfigInputTextCursorBlink;

        [NativeTypeName("_Bool")]
        public byte ConfigInputTextEnterKeepActive;

        [NativeTypeName("_Bool")]
        public byte ConfigDragClickToInputText;

        [NativeTypeName("_Bool")]
        public byte ConfigWindowsResizeFromEdges;

        [NativeTypeName("_Bool")]
        public byte ConfigWindowsMoveFromTitleBarOnly;

        [NativeTypeName("_Bool")]
        public byte ConfigWindowsCopyContentsWithCtrlC;

        [NativeTypeName("_Bool")]
        public byte ConfigScrollbarScrollByPage;

        public float ConfigMemoryCompactTimer;

        public float MouseDoubleClickTime;

        public float MouseDoubleClickMaxDist;

        public float MouseDragThreshold;

        public float KeyRepeatDelay;

        public float KeyRepeatRate;

        [NativeTypeName("_Bool")]
        public byte ConfigErrorRecovery;

        [NativeTypeName("_Bool")]
        public byte ConfigErrorRecoveryEnableAssert;

        [NativeTypeName("_Bool")]
        public byte ConfigErrorRecoveryEnableDebugLog;

        [NativeTypeName("_Bool")]
        public byte ConfigErrorRecoveryEnableTooltip;

        [NativeTypeName("_Bool")]
        public byte ConfigDebugIsDebuggerPresent;

        [NativeTypeName("_Bool")]
        public byte ConfigDebugHighlightIdConflicts;

        [NativeTypeName("_Bool")]
        public byte ConfigDebugHighlightIdConflictsShowItemPicker;

        [NativeTypeName("_Bool")]
        public byte ConfigDebugBeginReturnValueOnce;

        [NativeTypeName("_Bool")]
        public byte ConfigDebugBeginReturnValueLoop;

        [NativeTypeName("_Bool")]
        public byte ConfigDebugIgnoreFocusLoss;

        [NativeTypeName("_Bool")]
        public byte ConfigDebugIniSettings;

        [NativeTypeName("const char *")]
        public sbyte* BackendPlatformName;

        [NativeTypeName("const char *")]
        public sbyte* BackendRendererName;

        public void* BackendPlatformUserData;

        public void* BackendRendererUserData;

        public void* BackendLanguageUserData;

        [NativeTypeName("_Bool")]
        public byte WantCaptureMouse;

        [NativeTypeName("_Bool")]
        public byte WantCaptureKeyboard;

        [NativeTypeName("_Bool")]
        public byte WantTextInput;

        [NativeTypeName("_Bool")]
        public byte WantSetMousePos;

        [NativeTypeName("_Bool")]
        public byte WantSaveIniSettings;

        [NativeTypeName("_Bool")]
        public byte NavActive;

        [NativeTypeName("_Bool")]
        public byte NavVisible;

        public float Framerate;

        public int MetricsRenderVertices;

        public int MetricsRenderIndices;

        public int MetricsRenderWindows;

        public int MetricsActiveWindows;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 MouseDelta;

        public ImGuiContext* Ctx;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 MousePos;

        [NativeTypeName("_Bool[5]")]
        public _MouseDown_e__FixedBuffer MouseDown;

        public float MouseWheel;

        public float MouseWheelH;

        public ImGuiMouseSource MouseSource;

        [NativeTypeName("ImGuiID")]
        public uint MouseHoveredViewport;

        [NativeTypeName("_Bool")]
        public byte KeyCtrl;

        [NativeTypeName("_Bool")]
        public byte KeyShift;

        [NativeTypeName("_Bool")]
        public byte KeyAlt;

        [NativeTypeName("_Bool")]
        public byte KeySuper;

        [NativeTypeName("ImGuiKeyChord")]
        public int KeyMods;

        [NativeTypeName("ImGuiKeyData[155]")]
        public _KeysData_e__FixedBuffer KeysData;

        [NativeTypeName("_Bool")]
        public byte WantCaptureMouseUnlessPopupClose;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 MousePosPrev;

        [NativeTypeName("ImVec2[5]")]
        public _MouseClickedPos_e__FixedBuffer MouseClickedPos;

        [NativeTypeName("double[5]")]
        public _MouseClickedTime_e__FixedBuffer MouseClickedTime;

        [NativeTypeName("_Bool[5]")]
        public _MouseClicked_e__FixedBuffer MouseClicked;

        [NativeTypeName("_Bool[5]")]
        public _MouseDoubleClicked_e__FixedBuffer MouseDoubleClicked;

        [NativeTypeName("ImU16[5]")]
        public _MouseClickedCount_e__FixedBuffer MouseClickedCount;

        [NativeTypeName("ImU16[5]")]
        public _MouseClickedLastCount_e__FixedBuffer MouseClickedLastCount;

        [NativeTypeName("_Bool[5]")]
        public _MouseReleased_e__FixedBuffer MouseReleased;

        [NativeTypeName("double[5]")]
        public _MouseReleasedTime_e__FixedBuffer MouseReleasedTime;

        [NativeTypeName("_Bool[5]")]
        public _MouseDownOwned_e__FixedBuffer MouseDownOwned;

        [NativeTypeName("_Bool[5]")]
        public _MouseDownOwnedUnlessPopupClose_e__FixedBuffer MouseDownOwnedUnlessPopupClose;

        [NativeTypeName("_Bool")]
        public byte MouseWheelRequestAxisSwap;

        [NativeTypeName("_Bool")]
        public byte MouseCtrlLeftAsRightClick;

        [NativeTypeName("float[5]")]
        public _MouseDownDuration_e__FixedBuffer MouseDownDuration;

        [NativeTypeName("float[5]")]
        public _MouseDownDurationPrev_e__FixedBuffer MouseDownDurationPrev;

        [NativeTypeName("ImVec2[5]")]
        public _MouseDragMaxDistanceAbs_e__FixedBuffer MouseDragMaxDistanceAbs;

        [NativeTypeName("float[5]")]
        public _MouseDragMaxDistanceSqr_e__FixedBuffer MouseDragMaxDistanceSqr;

        public float PenPressure;

        [NativeTypeName("_Bool")]
        public byte AppFocusLost;

        [NativeTypeName("_Bool")]
        public byte AppAcceptingEvents;

        [NativeTypeName("ImWchar16")]
        public ushort InputQueueSurrogate;

        public ImVector_ImWchar InputQueueCharacters;

        [InlineArray(5)]
        public partial struct _MouseDown_e__FixedBuffer
        {
            public bool e0;
        }

        [InlineArray(155)]
        public partial struct _KeysData_e__FixedBuffer
        {
            public ImGuiKeyData e0;
        }

        [InlineArray(5)]
        public partial struct _MouseClickedPos_e__FixedBuffer
        {
            public System.Numerics.Vector2 e0;
        }

        [InlineArray(5)]
        public partial struct _MouseClickedTime_e__FixedBuffer
        {
            public double e0;
        }

        [InlineArray(5)]
        public partial struct _MouseClicked_e__FixedBuffer
        {
            public bool e0;
        }

        [InlineArray(5)]
        public partial struct _MouseDoubleClicked_e__FixedBuffer
        {
            public bool e0;
        }

        [InlineArray(5)]
        public partial struct _MouseClickedCount_e__FixedBuffer
        {
            public ushort e0;
        }

        [InlineArray(5)]
        public partial struct _MouseClickedLastCount_e__FixedBuffer
        {
            public ushort e0;
        }

        [InlineArray(5)]
        public partial struct _MouseReleased_e__FixedBuffer
        {
            public bool e0;
        }

        [InlineArray(5)]
        public partial struct _MouseReleasedTime_e__FixedBuffer
        {
            public double e0;
        }

        [InlineArray(5)]
        public partial struct _MouseDownOwned_e__FixedBuffer
        {
            public bool e0;
        }

        [InlineArray(5)]
        public partial struct _MouseDownOwnedUnlessPopupClose_e__FixedBuffer
        {
            public bool e0;
        }

        [InlineArray(5)]
        public partial struct _MouseDownDuration_e__FixedBuffer
        {
            public float e0;
        }

        [InlineArray(5)]
        public partial struct _MouseDownDurationPrev_e__FixedBuffer
        {
            public float e0;
        }

        [InlineArray(5)]
        public partial struct _MouseDragMaxDistanceAbs_e__FixedBuffer
        {
            public System.Numerics.Vector2 e0;
        }

        [InlineArray(5)]
        public partial struct _MouseDragMaxDistanceSqr_e__FixedBuffer
        {
            public float e0;
        }
    }

    public unsafe partial struct ImGuiInputTextCallbackData
    {
        public ImGuiContext* Ctx;

        [NativeTypeName("ImGuiInputTextFlags")]
        public int EventFlag;

        [NativeTypeName("ImGuiInputTextFlags")]
        public int Flags;

        public void* UserData;

        [NativeTypeName("ImWchar")]
        public ushort EventChar;

        public ImGuiKey EventKey;

        [NativeTypeName("char *")]
        public sbyte* Buf;

        public int BufTextLen;

        public int BufSize;

        [NativeTypeName("_Bool")]
        public byte BufDirty;

        public int CursorPos;

        public int SelectionStart;

        public int SelectionEnd;
    }

    public unsafe partial struct ImGuiSizeCallbackData
    {
        public void* UserData;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 Pos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 CurrentSize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 DesiredSize;
    }

    public partial struct ImGuiWindowClass
    {
        [NativeTypeName("ImGuiID")]
        public uint ClassId;

        [NativeTypeName("ImGuiID")]
        public uint ParentViewportId;

        [NativeTypeName("ImGuiID")]
        public uint FocusRouteParentWindowId;

        [NativeTypeName("ImGuiViewportFlags")]
        public int ViewportFlagsOverrideSet;

        [NativeTypeName("ImGuiViewportFlags")]
        public int ViewportFlagsOverrideClear;

        [NativeTypeName("ImGuiTabItemFlags")]
        public int TabItemFlagsOverrideSet;

        [NativeTypeName("ImGuiDockNodeFlags")]
        public int DockNodeFlagsOverrideSet;

        [NativeTypeName("_Bool")]
        public byte DockingAlwaysTabBar;

        [NativeTypeName("_Bool")]
        public byte DockingAllowUnclassed;
    }

    public unsafe partial struct ImGuiPayload
    {
        public void* Data;

        public int DataSize;

        [NativeTypeName("ImGuiID")]
        public uint SourceId;

        [NativeTypeName("ImGuiID")]
        public uint SourceParentId;

        public int DataFrameCount;

        [NativeTypeName("char[33]")]
        public _DataType_e__FixedBuffer DataType;

        [NativeTypeName("_Bool")]
        public byte Preview;

        [NativeTypeName("_Bool")]
        public byte Delivery;

        [InlineArray(33)]
        public partial struct _DataType_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public partial struct ImGuiOnceUponAFrame
    {
        public int RefFrame;
    }

    public unsafe partial struct ImGuiTextRange
    {
        [NativeTypeName("const char *")]
        public sbyte* b;

        [NativeTypeName("const char *")]
        public sbyte* e;
    }

    public unsafe partial struct ImVector_ImGuiTextRange
    {
        public int Size;

        public int Capacity;

        public ImGuiTextRange* Data;
    }

    public partial struct ImGuiTextFilter
    {
        [NativeTypeName("char[256]")]
        public _InputBuf_e__FixedBuffer InputBuf;

        public ImVector_ImGuiTextRange Filters;

        public int CountGrep;

        [InlineArray(256)]
        public partial struct _InputBuf_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct ImVector_char
    {
        public int Size;

        public int Capacity;

        [NativeTypeName("char *")]
        public sbyte* Data;
    }

    public partial struct ImGuiTextBuffer
    {
        public ImVector_char Buf;
    }

    public unsafe partial struct ImGuiStoragePair
    {
        [NativeTypeName("ImGuiID")]
        public uint key;

        [NativeTypeName("__AnonymousRecord_cimgui_L1290_C5")]
        public _Anonymous_e__Union Anonymous;

        [UnscopedRef]
        public ref int val_i
        {
            get
            {
                return ref Anonymous.val_i;
            }
        }

        [UnscopedRef]
        public ref float val_f
        {
            get
            {
                return ref Anonymous.val_f;
            }
        }

        [UnscopedRef]
        public ref void* val_p
        {
            get
            {
                return ref Anonymous.val_p;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _Anonymous_e__Union
        {
            [FieldOffset(0)]
            public int val_i;

            [FieldOffset(0)]
            public float val_f;

            [FieldOffset(0)]
            public void* val_p;
        }
    }

    public unsafe partial struct ImVector_ImGuiStoragePair
    {
        public int Size;

        public int Capacity;

        public ImGuiStoragePair* Data;
    }

    public partial struct ImGuiStorage
    {
        public ImVector_ImGuiStoragePair Data;
    }

    public enum ImGuiListClipperFlags_
    {
        ImGuiListClipperFlags_None = 0,
        ImGuiListClipperFlags_NoSetTableRowCounters = 1 << 0,
    }

    public unsafe partial struct ImGuiListClipper
    {
        public ImGuiContext* Ctx;

        public int DisplayStart;

        public int DisplayEnd;

        public int ItemsCount;

        public float ItemsHeight;

        public double StartPosY;

        public double StartSeekOffsetY;

        public void* TempData;

        [NativeTypeName("ImGuiListClipperFlags")]
        public int Flags;
    }

    public partial struct ImColor
    {
        [NativeTypeName("ImVec4")]
        public System.Numerics.Vector4 Value;
    }

    public enum ImGuiMultiSelectFlags_
    {
        ImGuiMultiSelectFlags_None = 0,
        ImGuiMultiSelectFlags_SingleSelect = 1 << 0,
        ImGuiMultiSelectFlags_NoSelectAll = 1 << 1,
        ImGuiMultiSelectFlags_NoRangeSelect = 1 << 2,
        ImGuiMultiSelectFlags_NoAutoSelect = 1 << 3,
        ImGuiMultiSelectFlags_NoAutoClear = 1 << 4,
        ImGuiMultiSelectFlags_NoAutoClearOnReselect = 1 << 5,
        ImGuiMultiSelectFlags_BoxSelect1d = 1 << 6,
        ImGuiMultiSelectFlags_BoxSelect2d = 1 << 7,
        ImGuiMultiSelectFlags_BoxSelectNoScroll = 1 << 8,
        ImGuiMultiSelectFlags_ClearOnEscape = 1 << 9,
        ImGuiMultiSelectFlags_ClearOnClickVoid = 1 << 10,
        ImGuiMultiSelectFlags_ScopeWindow = 1 << 11,
        ImGuiMultiSelectFlags_ScopeRect = 1 << 12,
        ImGuiMultiSelectFlags_SelectOnClick = 1 << 13,
        ImGuiMultiSelectFlags_SelectOnClickRelease = 1 << 14,
        ImGuiMultiSelectFlags_NavWrapX = 1 << 16,
    }

    public unsafe partial struct ImVector_ImGuiSelectionRequest
    {
        public int Size;

        public int Capacity;

        public ImGuiSelectionRequest* Data;
    }

    public partial struct ImGuiMultiSelectIO
    {
        public ImVector_ImGuiSelectionRequest Requests;

        [NativeTypeName("ImGuiSelectionUserData")]
        public long RangeSrcItem;

        [NativeTypeName("ImGuiSelectionUserData")]
        public long NavIdItem;

        [NativeTypeName("_Bool")]
        public byte NavIdSelected;

        [NativeTypeName("_Bool")]
        public byte RangeSrcReset;

        public int ItemsCount;
    }

    public enum ImGuiSelectionRequestType
    {
        ImGuiSelectionRequestType_None = 0,
        ImGuiSelectionRequestType_SetAll,
        ImGuiSelectionRequestType_SetRange,
    }

    public partial struct ImGuiSelectionRequest
    {
        public ImGuiSelectionRequestType Type;

        [NativeTypeName("_Bool")]
        public byte Selected;

        [NativeTypeName("ImS8")]
        public sbyte RangeDirection;

        [NativeTypeName("ImGuiSelectionUserData")]
        public long RangeFirstItem;

        [NativeTypeName("ImGuiSelectionUserData")]
        public long RangeLastItem;
    }

    public unsafe partial struct ImGuiSelectionBasicStorage
    {
        public int Size;

        [NativeTypeName("_Bool")]
        public byte PreserveOrder;

        public void* UserData;

        [NativeTypeName("ImGuiID (*)(ImGuiSelectionBasicStorage *, int)")]
        public delegate* unmanaged[Cdecl]<ImGuiSelectionBasicStorage*, int, uint> AdapterIndexToStorageId;

        public int _SelectionOrder;

        public ImGuiStorage _Storage;
    }

    public unsafe partial struct ImGuiSelectionExternalStorage
    {
        public void* UserData;

        [NativeTypeName("void (*)(ImGuiSelectionExternalStorage *, int, _Bool)")]
        public delegate* unmanaged[Cdecl]<ImGuiSelectionExternalStorage*, int, byte, void> AdapterSetItemSelected;
    }

    public unsafe partial struct ImDrawCmd
    {
        [NativeTypeName("ImVec4")]
        public System.Numerics.Vector4 ClipRect;

        public ImTextureRef TexRef;

        [NativeTypeName("unsigned int")]
        public uint VtxOffset;

        [NativeTypeName("unsigned int")]
        public uint IdxOffset;

        [NativeTypeName("unsigned int")]
        public uint ElemCount;

        [NativeTypeName("ImDrawCallback")]
        public delegate* unmanaged[Cdecl]<ImDrawList*, ImDrawCmd*, void> UserCallback;

        public void* UserCallbackData;

        public int UserCallbackDataSize;

        public int UserCallbackDataOffset;
    }

    public partial struct ImDrawVert
    {
        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 pos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 uv;

        [NativeTypeName("ImU32")]
        public uint col;
    }

    public partial struct ImDrawCmdHeader
    {
        [NativeTypeName("ImVec4")]
        public System.Numerics.Vector4 ClipRect;

        public ImTextureRef TexRef;

        [NativeTypeName("unsigned int")]
        public uint VtxOffset;
    }

    public unsafe partial struct ImVector_ImDrawCmd
    {
        public int Size;

        public int Capacity;

        public ImDrawCmd* Data;
    }

    public unsafe partial struct ImVector_ImDrawIdx
    {
        public int Size;

        public int Capacity;

        [NativeTypeName("ImDrawIdx *")]
        public ushort* Data;
    }

    public partial struct ImDrawChannel
    {
        public ImVector_ImDrawCmd _CmdBuffer;

        public ImVector_ImDrawIdx _IdxBuffer;
    }

    public unsafe partial struct ImVector_ImDrawChannel
    {
        public int Size;

        public int Capacity;

        public ImDrawChannel* Data;
    }

    public partial struct ImDrawListSplitter
    {
        public int _Current;

        public int _Count;

        public ImVector_ImDrawChannel _Channels;
    }

    public enum ImDrawFlags_
    {
        ImDrawFlags_None = 0,
        ImDrawFlags_Closed = 1 << 0,
        ImDrawFlags_RoundCornersTopLeft = 1 << 4,
        ImDrawFlags_RoundCornersTopRight = 1 << 5,
        ImDrawFlags_RoundCornersBottomLeft = 1 << 6,
        ImDrawFlags_RoundCornersBottomRight = 1 << 7,
        ImDrawFlags_RoundCornersNone = 1 << 8,
        ImDrawFlags_RoundCornersTop = ImDrawFlags_RoundCornersTopLeft | ImDrawFlags_RoundCornersTopRight,
        ImDrawFlags_RoundCornersBottom = ImDrawFlags_RoundCornersBottomLeft | ImDrawFlags_RoundCornersBottomRight,
        ImDrawFlags_RoundCornersLeft = ImDrawFlags_RoundCornersBottomLeft | ImDrawFlags_RoundCornersTopLeft,
        ImDrawFlags_RoundCornersRight = ImDrawFlags_RoundCornersBottomRight | ImDrawFlags_RoundCornersTopRight,
        ImDrawFlags_RoundCornersAll = ImDrawFlags_RoundCornersTopLeft | ImDrawFlags_RoundCornersTopRight | ImDrawFlags_RoundCornersBottomLeft | ImDrawFlags_RoundCornersBottomRight,
        ImDrawFlags_RoundCornersDefault_ = ImDrawFlags_RoundCornersAll,
        ImDrawFlags_RoundCornersMask_ = ImDrawFlags_RoundCornersAll | ImDrawFlags_RoundCornersNone,
    }

    public enum ImDrawListFlags_
    {
        ImDrawListFlags_None = 0,
        ImDrawListFlags_AntiAliasedLines = 1 << 0,
        ImDrawListFlags_AntiAliasedLinesUseTex = 1 << 1,
        ImDrawListFlags_AntiAliasedFill = 1 << 2,
        ImDrawListFlags_AllowVtxOffset = 1 << 3,
    }

    public unsafe partial struct ImVector_ImDrawVert
    {
        public int Size;

        public int Capacity;

        public ImDrawVert* Data;
    }

    public unsafe partial struct ImVector_ImVec2
    {
        public int Size;

        public int Capacity;

        [NativeTypeName("ImVec2 *")]
        public System.Numerics.Vector2* Data;
    }

    public unsafe partial struct ImVector_ImVec4
    {
        public int Size;

        public int Capacity;

        [NativeTypeName("ImVec4 *")]
        public System.Numerics.Vector4* Data;
    }

    public unsafe partial struct ImVector_ImTextureRef
    {
        public int Size;

        public int Capacity;

        public ImTextureRef* Data;
    }

    public unsafe partial struct ImVector_ImU8
    {
        public int Size;

        public int Capacity;

        [NativeTypeName("ImU8 *")]
        public byte* Data;
    }

    public unsafe partial struct ImDrawList
    {
        public ImVector_ImDrawCmd CmdBuffer;

        public ImVector_ImDrawIdx IdxBuffer;

        public ImVector_ImDrawVert VtxBuffer;

        [NativeTypeName("ImDrawListFlags")]
        public int Flags;

        [NativeTypeName("unsigned int")]
        public uint _VtxCurrentIdx;

        public ImDrawListSharedData* _Data;

        public ImDrawVert* _VtxWritePtr;

        [NativeTypeName("ImDrawIdx *")]
        public ushort* _IdxWritePtr;

        public ImVector_ImVec2 _Path;

        public ImDrawCmdHeader _CmdHeader;

        public ImDrawListSplitter _Splitter;

        public ImVector_ImVec4 _ClipRectStack;

        public ImVector_ImTextureRef _TextureStack;

        public ImVector_ImU8 _CallbacksDataBuf;

        public float _FringeScale;

        [NativeTypeName("const char *")]
        public sbyte* _OwnerName;
    }

    public unsafe partial struct ImVector_ImDrawListPtr
    {
        public int Size;

        public int Capacity;

        public ImDrawList** Data;
    }

    public unsafe partial struct ImVector_ImTextureDataPtr
    {
        public int Size;

        public int Capacity;

        public ImTextureData** Data;
    }

    public unsafe partial struct ImDrawData
    {
        [NativeTypeName("_Bool")]
        public byte Valid;

        public int CmdListsCount;

        public int TotalIdxCount;

        public int TotalVtxCount;

        public ImVector_ImDrawListPtr CmdLists;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 DisplayPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 DisplaySize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 FramebufferScale;

        public ImGuiViewport* OwnerViewport;

        public ImVector_ImTextureDataPtr* Textures;
    }

    public enum ImTextureFormat
    {
        ImTextureFormat_RGBA32,
        ImTextureFormat_Alpha8,
    }

    public enum ImTextureStatus
    {
        ImTextureStatus_OK,
        ImTextureStatus_Destroyed,
        ImTextureStatus_WantCreate,
        ImTextureStatus_WantUpdates,
        ImTextureStatus_WantDestroy,
    }

    public partial struct ImTextureRect
    {
        [NativeTypeName("unsigned short")]
        public ushort x;

        [NativeTypeName("unsigned short")]
        public ushort y;

        [NativeTypeName("unsigned short")]
        public ushort w;

        [NativeTypeName("unsigned short")]
        public ushort h;
    }

    public unsafe partial struct ImVector_ImTextureRect
    {
        public int Size;

        public int Capacity;

        public ImTextureRect* Data;
    }

    public unsafe partial struct ImTextureData
    {
        public int UniqueID;

        public ImTextureStatus Status;

        public void* BackendUserData;

        [NativeTypeName("ImTextureID")]
        public ulong TexID;

        public ImTextureFormat Format;

        public int Width;

        public int Height;

        public int BytesPerPixel;

        [NativeTypeName("unsigned char *")]
        public byte* Pixels;

        public ImTextureRect UsedRect;

        public ImTextureRect UpdateRect;

        public ImVector_ImTextureRect Updates;

        public int UnusedFrames;

        [NativeTypeName("unsigned short")]
        public ushort RefCount;

        [NativeTypeName("_Bool")]
        public byte UseColors;

        [NativeTypeName("_Bool")]
        public byte WantDestroyNextFrame;
    }

    public unsafe partial struct ImFontConfig
    {
        [NativeTypeName("char[40]")]
        public _Name_e__FixedBuffer Name;

        public void* FontData;

        public int FontDataSize;

        [NativeTypeName("_Bool")]
        public byte FontDataOwnedByAtlas;

        [NativeTypeName("_Bool")]
        public byte MergeMode;

        [NativeTypeName("_Bool")]
        public byte PixelSnapH;

        [NativeTypeName("_Bool")]
        public byte PixelSnapV;

        [NativeTypeName("ImS8")]
        public sbyte OversampleH;

        [NativeTypeName("ImS8")]
        public sbyte OversampleV;

        [NativeTypeName("ImWchar")]
        public ushort EllipsisChar;

        public float SizePixels;

        [NativeTypeName("const ImWchar *")]
        public ushort* GlyphRanges;

        [NativeTypeName("const ImWchar *")]
        public ushort* GlyphExcludeRanges;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 GlyphOffset;

        public float GlyphMinAdvanceX;

        public float GlyphMaxAdvanceX;

        public float GlyphExtraAdvanceX;

        [NativeTypeName("ImU32")]
        public uint FontNo;

        [NativeTypeName("unsigned int")]
        public uint FontLoaderFlags;

        public float RasterizerMultiply;

        public float RasterizerDensity;

        [NativeTypeName("ImFontFlags")]
        public int Flags;

        public ImFont* DstFont;

        [NativeTypeName("const ImFontLoader *")]
        public ImFontLoader* FontLoader;

        public void* FontLoaderData;

        [InlineArray(40)]
        public partial struct _Name_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public partial struct ImFontGlyph
    {
        public uint _bitfield;

        [NativeTypeName("unsigned int : 1")]
        public uint Colored
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

        [NativeTypeName("unsigned int : 1")]
        public uint Visible
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

        [NativeTypeName("unsigned int : 4")]
        public uint SourceIdx
        {
            readonly get
            {
                return (_bitfield >> 2) & 0xFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFu << 2)) | ((value & 0xFu) << 2);
            }
        }

        [NativeTypeName("unsigned int : 26")]
        public uint Codepoint
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x3FFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFu << 6)) | ((value & 0x3FFFFFFu) << 6);
            }
        }

        public float AdvanceX;

        public float X0;

        public float Y0;

        public float X1;

        public float Y1;

        public float U0;

        public float V0;

        public float U1;

        public float V1;

        public int PackId;
    }

    public unsafe partial struct ImVector_ImU32
    {
        public int Size;

        public int Capacity;

        [NativeTypeName("ImU32 *")]
        public uint* Data;
    }

    public partial struct ImFontGlyphRangesBuilder
    {
        public ImVector_ImU32 UsedChars;
    }

    public partial struct ImFontAtlasRect
    {
        [NativeTypeName("unsigned short")]
        public ushort x;

        [NativeTypeName("unsigned short")]
        public ushort y;

        [NativeTypeName("unsigned short")]
        public ushort w;

        [NativeTypeName("unsigned short")]
        public ushort h;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 uv0;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 uv1;
    }

    public enum ImFontAtlasFlags_
    {
        ImFontAtlasFlags_None = 0,
        ImFontAtlasFlags_NoPowerOfTwoHeight = 1 << 0,
        ImFontAtlasFlags_NoMouseCursors = 1 << 1,
        ImFontAtlasFlags_NoBakedLines = 1 << 2,
    }

    public unsafe partial struct ImVector_ImFontPtr
    {
        public int Size;

        public int Capacity;

        public ImFont** Data;
    }

    public unsafe partial struct ImVector_ImFontConfig
    {
        public int Size;

        public int Capacity;

        public ImFontConfig* Data;
    }

    public unsafe partial struct ImVector_ImDrawListSharedDataPtr
    {
        public int Size;

        public int Capacity;

        public ImDrawListSharedData** Data;
    }

    public unsafe partial struct ImFontAtlas
    {
        [NativeTypeName("ImFontAtlasFlags")]
        public int Flags;

        public ImTextureFormat TexDesiredFormat;

        public int TexGlyphPadding;

        public int TexMinWidth;

        public int TexMinHeight;

        public int TexMaxWidth;

        public int TexMaxHeight;

        public void* UserData;

        public ImTextureRef TexRef;

        public ImTextureData* TexData;

        public ImVector_ImTextureDataPtr TexList;

        [NativeTypeName("_Bool")]
        public byte Locked;

        [NativeTypeName("_Bool")]
        public byte RendererHasTextures;

        [NativeTypeName("_Bool")]
        public byte TexIsBuilt;

        [NativeTypeName("_Bool")]
        public byte TexPixelsUseColors;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 TexUvScale;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 TexUvWhitePixel;

        public ImVector_ImFontPtr Fonts;

        public ImVector_ImFontConfig Sources;

        [NativeTypeName("ImVec4[33]")]
        public _TexUvLines_e__FixedBuffer TexUvLines;

        public int TexNextUniqueID;

        public int FontNextUniqueID;

        public ImVector_ImDrawListSharedDataPtr DrawListSharedDatas;

        public ImFontAtlasBuilder* Builder;

        [NativeTypeName("const ImFontLoader *")]
        public ImFontLoader* FontLoader;

        [NativeTypeName("const char *")]
        public sbyte* FontLoaderName;

        public void* FontLoaderData;

        [NativeTypeName("unsigned int")]
        public uint FontLoaderFlags;

        public int RefCount;

        public ImGuiContext* OwnerContext;

        [InlineArray(33)]
        public partial struct _TexUvLines_e__FixedBuffer
        {
            public System.Numerics.Vector4 e0;
        }
    }

    public unsafe partial struct ImVector_float
    {
        public int Size;

        public int Capacity;

        public float* Data;
    }

    public unsafe partial struct ImVector_ImU16
    {
        public int Size;

        public int Capacity;

        [NativeTypeName("ImU16 *")]
        public ushort* Data;
    }

    public unsafe partial struct ImVector_ImFontGlyph
    {
        public int Size;

        public int Capacity;

        public ImFontGlyph* Data;
    }

    public unsafe partial struct ImFontBaked
    {
        public ImVector_float IndexAdvanceX;

        public float FallbackAdvanceX;

        public float Size;

        public float RasterizerDensity;

        public ImVector_ImU16 IndexLookup;

        public ImVector_ImFontGlyph Glyphs;

        public int FallbackGlyphIndex;

        public float Ascent;

        public float Descent;

        public uint _bitfield;

        [NativeTypeName("unsigned int : 26")]
        public uint MetricsTotalSurface
        {
            readonly get
            {
                return _bitfield & 0x3FFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~0x3FFFFFFu) | (value & 0x3FFFFFFu);
            }
        }

        [NativeTypeName("unsigned int : 1")]
        public uint WantDestroy
        {
            readonly get
            {
                return (_bitfield >> 26) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 26)) | ((value & 0x1u) << 26);
            }
        }

        [NativeTypeName("unsigned int : 1")]
        public uint LoadNoFallback
        {
            readonly get
            {
                return (_bitfield >> 27) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 27)) | ((value & 0x1u) << 27);
            }
        }

        [NativeTypeName("unsigned int : 1")]
        public uint LoadNoRenderOnLayout
        {
            readonly get
            {
                return (_bitfield >> 28) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 28)) | ((value & 0x1u) << 28);
            }
        }

        public int LastUsedFrame;

        [NativeTypeName("ImGuiID")]
        public uint BakedId;

        public ImFont* ContainerFont;

        public void* FontLoaderDatas;
    }

    public enum ImFontFlags_
    {
        ImFontFlags_None = 0,
        ImFontFlags_NoLoadError = 1 << 1,
        ImFontFlags_NoLoadGlyphs = 1 << 2,
        ImFontFlags_LockBakedSizes = 1 << 3,
    }

    public unsafe partial struct ImVector_ImFontConfigPtr
    {
        public int Size;

        public int Capacity;

        public ImFontConfig** Data;
    }

    public unsafe partial struct ImFont
    {
        public ImFontBaked* LastBaked;

        public ImFontAtlas* ContainerAtlas;

        [NativeTypeName("ImFontFlags")]
        public int Flags;

        public float CurrentRasterizerDensity;

        [NativeTypeName("ImGuiID")]
        public uint FontId;

        public float LegacySize;

        public ImVector_ImFontConfigPtr Sources;

        [NativeTypeName("ImWchar")]
        public ushort EllipsisChar;

        [NativeTypeName("ImWchar")]
        public ushort FallbackChar;

        [NativeTypeName("ImU8[1]")]
        public _Used8kPagesMap_e__FixedBuffer Used8kPagesMap;

        [NativeTypeName("_Bool")]
        public byte EllipsisAutoBake;

        public ImGuiStorage RemapPairs;

        public partial struct _Used8kPagesMap_e__FixedBuffer
        {
            public byte e0;

            [UnscopedRef]
            public ref byte this[int index]
            {
                get
                {
                    return ref Unsafe.Add(ref e0, index);
                }
            }

            [UnscopedRef]
            public Span<byte> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
        }
    }

    public enum ImGuiViewportFlags_
    {
        ImGuiViewportFlags_None = 0,
        ImGuiViewportFlags_IsPlatformWindow = 1 << 0,
        ImGuiViewportFlags_IsPlatformMonitor = 1 << 1,
        ImGuiViewportFlags_OwnedByApp = 1 << 2,
        ImGuiViewportFlags_NoDecoration = 1 << 3,
        ImGuiViewportFlags_NoTaskBarIcon = 1 << 4,
        ImGuiViewportFlags_NoFocusOnAppearing = 1 << 5,
        ImGuiViewportFlags_NoFocusOnClick = 1 << 6,
        ImGuiViewportFlags_NoInputs = 1 << 7,
        ImGuiViewportFlags_NoRendererClear = 1 << 8,
        ImGuiViewportFlags_NoAutoMerge = 1 << 9,
        ImGuiViewportFlags_TopMost = 1 << 10,
        ImGuiViewportFlags_CanHostOtherWindows = 1 << 11,
        ImGuiViewportFlags_IsMinimized = 1 << 12,
        ImGuiViewportFlags_IsFocused = 1 << 13,
    }

    public unsafe partial struct ImGuiViewport
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("ImGuiViewportFlags")]
        public int Flags;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 Pos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 Size;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 FramebufferScale;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 WorkPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 WorkSize;

        public float DpiScale;

        [NativeTypeName("ImGuiID")]
        public uint ParentViewportId;

        public ImDrawData* DrawData;

        public void* RendererUserData;

        public void* PlatformUserData;

        public void* PlatformHandle;

        public void* PlatformHandleRaw;

        [NativeTypeName("_Bool")]
        public byte PlatformWindowCreated;

        [NativeTypeName("_Bool")]
        public byte PlatformRequestMove;

        [NativeTypeName("_Bool")]
        public byte PlatformRequestResize;

        [NativeTypeName("_Bool")]
        public byte PlatformRequestClose;
    }

    public unsafe partial struct ImVector_ImGuiPlatformMonitor
    {
        public int Size;

        public int Capacity;

        public ImGuiPlatformMonitor* Data;
    }

    public unsafe partial struct ImVector_ImGuiViewportPtr
    {
        public int Size;

        public int Capacity;

        public ImGuiViewport** Data;
    }

    public unsafe partial struct ImGuiPlatformIO
    {
        [NativeTypeName("const char *(*)(ImGuiContext *)")]
        public delegate* unmanaged[Cdecl]<ImGuiContext*, sbyte*> Platform_GetClipboardTextFn;

        [NativeTypeName("void (*)(ImGuiContext *, const char *)")]
        public delegate* unmanaged[Cdecl]<ImGuiContext*, sbyte*, void> Platform_SetClipboardTextFn;

        public void* Platform_ClipboardUserData;

        [NativeTypeName("_Bool (*)(ImGuiContext *, const char *)")]
        public delegate* unmanaged[Cdecl]<ImGuiContext*, sbyte*, byte> Platform_OpenInShellFn;

        public void* Platform_OpenInShellUserData;

        [NativeTypeName("void (*)(ImGuiContext *, ImGuiViewport *, ImGuiPlatformImeData *)")]
        public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiViewport*, ImGuiPlatformImeData*, void> Platform_SetImeDataFn;

        public void* Platform_ImeUserData;

        [NativeTypeName("ImWchar")]
        public ushort Platform_LocaleDecimalPoint;

        public int Renderer_TextureMaxWidth;

        public int Renderer_TextureMaxHeight;

        public void* Renderer_RenderState;

        [NativeTypeName("void (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_CreateWindow;

        [NativeTypeName("void (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_DestroyWindow;

        [NativeTypeName("void (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_ShowWindow;

        [NativeTypeName("void (*)(ImGuiViewport *, ImVec2)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, System.Numerics.Vector2, void> Platform_SetWindowPos;

        [NativeTypeName("ImVec2 (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, System.Numerics.Vector2> Platform_GetWindowPos;

        [NativeTypeName("void (*)(ImGuiViewport *, ImVec2)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, System.Numerics.Vector2, void> Platform_SetWindowSize;

        [NativeTypeName("ImVec2 (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, System.Numerics.Vector2> Platform_GetWindowSize;

        [NativeTypeName("ImVec2 (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, System.Numerics.Vector2> Platform_GetWindowFramebufferScale;

        [NativeTypeName("void (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_SetWindowFocus;

        [NativeTypeName("_Bool (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, byte> Platform_GetWindowFocus;

        [NativeTypeName("_Bool (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, byte> Platform_GetWindowMinimized;

        [NativeTypeName("void (*)(ImGuiViewport *, const char *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, sbyte*, void> Platform_SetWindowTitle;

        [NativeTypeName("void (*)(ImGuiViewport *, float)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, float, void> Platform_SetWindowAlpha;

        [NativeTypeName("void (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_UpdateWindow;

        [NativeTypeName("void (*)(ImGuiViewport *, void *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, void*, void> Platform_RenderWindow;

        [NativeTypeName("void (*)(ImGuiViewport *, void *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, void*, void> Platform_SwapBuffers;

        [NativeTypeName("float (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, float> Platform_GetWindowDpiScale;

        [NativeTypeName("void (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Platform_OnChangedViewport;

        [NativeTypeName("ImVec4 (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, System.Numerics.Vector4> Platform_GetWindowWorkAreaInsets;

        [NativeTypeName("int (*)(ImGuiViewport *, ImU64, const void *, ImU64 *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, ulong, void*, ulong*, int> Platform_CreateVkSurface;

        [NativeTypeName("void (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Renderer_CreateWindow;

        [NativeTypeName("void (*)(ImGuiViewport *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, void> Renderer_DestroyWindow;

        [NativeTypeName("void (*)(ImGuiViewport *, ImVec2)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, System.Numerics.Vector2, void> Renderer_SetWindowSize;

        [NativeTypeName("void (*)(ImGuiViewport *, void *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, void*, void> Renderer_RenderWindow;

        [NativeTypeName("void (*)(ImGuiViewport *, void *)")]
        public delegate* unmanaged[Cdecl]<ImGuiViewport*, void*, void> Renderer_SwapBuffers;

        public ImVector_ImGuiPlatformMonitor Monitors;

        public ImVector_ImTextureDataPtr Textures;

        public ImVector_ImGuiViewportPtr Viewports;
    }

    public unsafe partial struct ImGuiPlatformMonitor
    {
        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 MainPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 MainSize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 WorkPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 WorkSize;

        public float DpiScale;

        public void* PlatformHandle;
    }

    public partial struct ImGuiPlatformImeData
    {
        [NativeTypeName("_Bool")]
        public byte WantVisible;

        [NativeTypeName("_Bool")]
        public byte WantTextInput;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 InputPos;

        public float InputLineHeight;

        [NativeTypeName("ImGuiID")]
        public uint ViewportId;
    }

    public enum ImDrawTextFlags_
    {
        ImDrawTextFlags_None = 0,
        ImDrawTextFlags_CpuFineClip = 1 << 0,
        ImDrawTextFlags_WrapKeepBlanks = 1 << 1,
        ImDrawTextFlags_StopOnNewLine = 1 << 2,
    }

    public partial struct ImVec1
    {
        public float x;
    }

    public partial struct ImVec2i
    {
        public int x;

        public int y;
    }

    public partial struct ImVec2ih
    {
        public short x;

        public short y;
    }

    public partial struct ImRect
    {
        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 Min;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 Max;
    }

    public partial struct ImBitVector
    {
        public ImVector_ImU32 Storage;
    }

    public unsafe partial struct ImVector_int
    {
        public int Size;

        public int Capacity;

        public int* Data;
    }

    public partial struct ImGuiTextIndex
    {
        public ImVector_int Offsets;

        public int EndOffset;
    }

    public unsafe partial struct ImDrawListSharedData
    {
        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 TexUvWhitePixel;

        [NativeTypeName("const ImVec4 *")]
        public System.Numerics.Vector4* TexUvLines;

        public ImFontAtlas* FontAtlas;

        public ImFont* Font;

        public float FontSize;

        public float FontScale;

        public float CurveTessellationTol;

        public float CircleSegmentMaxError;

        public float InitialFringeScale;

        [NativeTypeName("ImDrawListFlags")]
        public int InitialFlags;

        [NativeTypeName("ImVec4")]
        public System.Numerics.Vector4 ClipRectFullscreen;

        public ImVector_ImVec2 TempBuffer;

        public ImVector_ImDrawListPtr DrawLists;

        public ImGuiContext* Context;

        [NativeTypeName("ImVec2[48]")]
        public _ArcFastVtx_e__FixedBuffer ArcFastVtx;

        public float ArcFastRadiusCutoff;

        [NativeTypeName("ImU8[64]")]
        public _CircleSegmentCounts_e__FixedBuffer CircleSegmentCounts;

        [InlineArray(48)]
        public partial struct _ArcFastVtx_e__FixedBuffer
        {
            public System.Numerics.Vector2 e0;
        }

        [InlineArray(64)]
        public partial struct _CircleSegmentCounts_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public partial struct ImDrawDataBuilder
    {
        [NativeTypeName("ImVector_ImDrawListPtr *[2]")]
        public _Layers_e__FixedBuffer Layers;

        public ImVector_ImDrawListPtr LayerData1;

        public unsafe partial struct _Layers_e__FixedBuffer
        {
            public ImVector_ImDrawListPtr* e0;
            public ImVector_ImDrawListPtr* e1;

            public ref ImVector_ImDrawListPtr* this[int index]
            {
                get
                {
                    fixed (ImVector_ImDrawListPtr** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public unsafe partial struct ImFontStackData
    {
        public ImFont* Font;

        public float FontSizeBeforeScaling;

        public float FontSizeAfterScaling;
    }

    public partial struct ImGuiStyleVarInfo
    {
        public uint _bitfield;

        [NativeTypeName("ImU32 : 8")]
        public uint Count
        {
            readonly get
            {
                return _bitfield & 0xFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~0xFFu) | (value & 0xFFu);
            }
        }

        [NativeTypeName("ImGuiDataType : 8")]
        public int DataType
        {
            readonly get
            {
                return (int)(_bitfield << 16) >> 24;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFu << 8)) | (uint)((value & 0xFF) << 8);
            }
        }

        [NativeTypeName("ImU32 : 16")]
        public uint Offset
        {
            readonly get
            {
                return (_bitfield >> 16) & 0xFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFFFu << 16)) | ((value & 0xFFFFu) << 16);
            }
        }
    }

    public partial struct ImGuiColorMod
    {
        [NativeTypeName("ImGuiCol")]
        public int Col;

        [NativeTypeName("ImVec4")]
        public System.Numerics.Vector4 BackupValue;
    }

    public partial struct ImGuiStyleMod
    {
        [NativeTypeName("ImGuiStyleVar")]
        public int VarIdx;

        [NativeTypeName("__AnonymousRecord_cimgui_L1930_C5")]
        public _Anonymous_e__Union Anonymous;

        [UnscopedRef]
        public Span<int> BackupInt
        {
            get
            {
                return Anonymous.BackupInt;
            }
        }

        [UnscopedRef]
        public Span<float> BackupFloat
        {
            get
            {
                return Anonymous.BackupFloat;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("int[2]")]
            public _BackupInt_e__FixedBuffer BackupInt;

            [FieldOffset(0)]
            [NativeTypeName("float[2]")]
            public _BackupFloat_e__FixedBuffer BackupFloat;

            [InlineArray(2)]
            public partial struct _BackupInt_e__FixedBuffer
            {
                public int e0;
            }

            [InlineArray(2)]
            public partial struct _BackupFloat_e__FixedBuffer
            {
                public float e0;
            }
        }
    }

    public partial struct ImGuiDataTypeStorage
    {
        [NativeTypeName("ImU8[8]")]
        public _Data_e__FixedBuffer Data;

        [InlineArray(8)]
        public partial struct _Data_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct ImGuiDataTypeInfo
    {
        [NativeTypeName("size_t")]
        public nuint Size;

        [NativeTypeName("const char *")]
        public sbyte* Name;

        [NativeTypeName("const char *")]
        public sbyte* PrintFmt;

        [NativeTypeName("const char *")]
        public sbyte* ScanFmt;
    }

    public enum ImGuiDataTypePrivate_
    {
        ImGuiDataType_Pointer = ImGuiDataType.COUNT,
        ImGuiDataType_ID,
    }

    public enum ImGuiItemFlagsPrivate_
    {
        ImGuiItemFlags_Disabled = 1 << 10,
        ImGuiItemFlags_ReadOnly = 1 << 11,
        ImGuiItemFlags_MixedValue = 1 << 12,
        ImGuiItemFlags_NoWindowHoverableCheck = 1 << 13,
        ImGuiItemFlags_AllowOverlap = 1 << 14,
        ImGuiItemFlags_NoNavDisableMouseHover = 1 << 15,
        ImGuiItemFlags_NoMarkEdited = 1 << 16,
        ImGuiItemFlags_NoFocus = 1 << 17,
        ImGuiItemFlags_Inputable = 1 << 20,
        ImGuiItemFlags_HasSelectionUserData = 1 << 21,
        ImGuiItemFlags_IsMultiSelect = 1 << 22,
        ImGuiItemFlags_Default_ = ImGuiItemFlags.AutoClosePopups,
    }

    public enum ImGuiItemStatusFlags_
    {
        ImGuiItemStatusFlags_None = 0,
        ImGuiItemStatusFlags_HoveredRect = 1 << 0,
        ImGuiItemStatusFlags_HasDisplayRect = 1 << 1,
        ImGuiItemStatusFlags_Edited = 1 << 2,
        ImGuiItemStatusFlags_ToggledSelection = 1 << 3,
        ImGuiItemStatusFlags_ToggledOpen = 1 << 4,
        ImGuiItemStatusFlags_HasDeactivated = 1 << 5,
        ImGuiItemStatusFlags_Deactivated = 1 << 6,
        ImGuiItemStatusFlags_HoveredWindow = 1 << 7,
        ImGuiItemStatusFlags_Visible = 1 << 8,
        ImGuiItemStatusFlags_HasClipRect = 1 << 9,
        ImGuiItemStatusFlags_HasShortcut = 1 << 10,
    }

    public enum ImGuiHoveredFlagsPrivate_
    {
        ImGuiHoveredFlags_DelayMask_ = ImGuiHoveredFlags.DelayNone | ImGuiHoveredFlags.DelayShort | ImGuiHoveredFlags.DelayNormal | ImGuiHoveredFlags.NoSharedDelay,
        ImGuiHoveredFlags_AllowedMaskForIsWindowHovered = ImGuiHoveredFlags.ChildWindows | ImGuiHoveredFlags.RootWindow | ImGuiHoveredFlags.AnyWindow | ImGuiHoveredFlags.NoPopupHierarchy | ImGuiHoveredFlags.DockHierarchy | ImGuiHoveredFlags.AllowWhenBlockedByPopup | ImGuiHoveredFlags.AllowWhenBlockedByActiveItem | ImGuiHoveredFlags.ForTooltip | ImGuiHoveredFlags.Stationary,
        ImGuiHoveredFlags_AllowedMaskForIsItemHovered = ImGuiHoveredFlags.AllowWhenBlockedByPopup | ImGuiHoveredFlags.AllowWhenBlockedByActiveItem | ImGuiHoveredFlags.AllowWhenOverlapped | ImGuiHoveredFlags.AllowWhenDisabled | ImGuiHoveredFlags.NoNavOverride | ImGuiHoveredFlags.ForTooltip | ImGuiHoveredFlags.Stationary | ImGuiHoveredFlags_DelayMask_,
    }

    public enum ImGuiInputTextFlagsPrivate_
    {
        ImGuiInputTextFlags_Multiline = 1 << 26,
        ImGuiInputTextFlags_MergedItem = 1 << 27,
        ImGuiInputTextFlags_LocalizeDecimalPoint = 1 << 28,
    }

    public enum ImGuiButtonFlagsPrivate_
    {
        ImGuiButtonFlags_PressedOnClick = 1 << 4,
        ImGuiButtonFlags_PressedOnClickRelease = 1 << 5,
        ImGuiButtonFlags_PressedOnClickReleaseAnywhere = 1 << 6,
        ImGuiButtonFlags_PressedOnRelease = 1 << 7,
        ImGuiButtonFlags_PressedOnDoubleClick = 1 << 8,
        ImGuiButtonFlags_PressedOnDragDropHold = 1 << 9,
        ImGuiButtonFlags_FlattenChildren = 1 << 11,
        ImGuiButtonFlags_AllowOverlap = 1 << 12,
        ImGuiButtonFlags_AlignTextBaseLine = 1 << 15,
        ImGuiButtonFlags_NoKeyModsAllowed = 1 << 16,
        ImGuiButtonFlags_NoHoldingActiveId = 1 << 17,
        ImGuiButtonFlags_NoNavFocus = 1 << 18,
        ImGuiButtonFlags_NoHoveredOnFocus = 1 << 19,
        ImGuiButtonFlags_NoSetKeyOwner = 1 << 20,
        ImGuiButtonFlags_NoTestKeyOwner = 1 << 21,
        ImGuiButtonFlags_NoFocus = 1 << 22,
        ImGuiButtonFlags_PressedOnMask_ = ImGuiButtonFlags_PressedOnClick | ImGuiButtonFlags_PressedOnClickRelease | ImGuiButtonFlags_PressedOnClickReleaseAnywhere | ImGuiButtonFlags_PressedOnRelease | ImGuiButtonFlags_PressedOnDoubleClick | ImGuiButtonFlags_PressedOnDragDropHold,
        ImGuiButtonFlags_PressedOnDefault_ = ImGuiButtonFlags_PressedOnClickRelease,
    }

    public enum ImGuiComboFlagsPrivate_
    {
        ImGuiComboFlags_CustomPreview = 1 << 20,
    }

    public enum ImGuiSliderFlagsPrivate_
    {
        ImGuiSliderFlags_Vertical = 1 << 20,
        ImGuiSliderFlags_ReadOnly = 1 << 21,
    }

    public enum ImGuiSelectableFlagsPrivate_
    {
        ImGuiSelectableFlags_NoHoldingActiveID = 1 << 20,
        ImGuiSelectableFlags_SelectOnClick = 1 << 22,
        ImGuiSelectableFlags_SelectOnRelease = 1 << 23,
        ImGuiSelectableFlags_SpanAvailWidth = 1 << 24,
        ImGuiSelectableFlags_SetNavIdOnHover = 1 << 25,
        ImGuiSelectableFlags_NoPadWithHalfSpacing = 1 << 26,
        ImGuiSelectableFlags_NoSetKeyOwner = 1 << 27,
    }

    public enum ImGuiTreeNodeFlagsPrivate_
    {
        ImGuiTreeNodeFlags_NoNavFocus = 1 << 27,
        ImGuiTreeNodeFlags_ClipLabelForTrailingButton = 1 << 28,
        ImGuiTreeNodeFlags_UpsideDownArrow = 1 << 29,
        ImGuiTreeNodeFlags_OpenOnMask_ = ImGuiTreeNodeFlags.OpenOnDoubleClick | ImGuiTreeNodeFlags.OpenOnArrow,
        ImGuiTreeNodeFlags_DrawLinesMask_ = ImGuiTreeNodeFlags.DrawLinesNone | ImGuiTreeNodeFlags.DrawLinesFull | ImGuiTreeNodeFlags.DrawLinesToNodes,
    }

    public enum ImGuiSeparatorFlags_
    {
        ImGuiSeparatorFlags_None = 0,
        ImGuiSeparatorFlags_Horizontal = 1 << 0,
        ImGuiSeparatorFlags_Vertical = 1 << 1,
        ImGuiSeparatorFlags_SpanAllColumns = 1 << 2,
    }

    public enum ImGuiFocusRequestFlags_
    {
        ImGuiFocusRequestFlags_None = 0,
        ImGuiFocusRequestFlags_RestoreFocusedChild = 1 << 0,
        ImGuiFocusRequestFlags_UnlessBelowModal = 1 << 1,
    }

    public enum ImGuiTextFlags_
    {
        ImGuiTextFlags_None = 0,
        ImGuiTextFlags_NoWidthForLargeClippedText = 1 << 0,
    }

    public enum ImGuiTooltipFlags_
    {
        ImGuiTooltipFlags_None = 0,
        ImGuiTooltipFlags_OverridePrevious = 1 << 1,
    }

    public enum ImGuiLayoutType_
    {
        ImGuiLayoutType_Horizontal = 0,
        ImGuiLayoutType_Vertical = 1,
    }

    public enum ImGuiLogFlags_
    {
        ImGuiLogFlags_None = 0,
        ImGuiLogFlags_OutputTTY = 1 << 0,
        ImGuiLogFlags_OutputFile = 1 << 1,
        ImGuiLogFlags_OutputBuffer = 1 << 2,
        ImGuiLogFlags_OutputClipboard = 1 << 3,
        ImGuiLogFlags_OutputMask_ = ImGuiLogFlags_OutputTTY | ImGuiLogFlags_OutputFile | ImGuiLogFlags_OutputBuffer | ImGuiLogFlags_OutputClipboard,
    }

    public enum ImGuiAxis
    {
        ImGuiAxis_None = -1,
        ImGuiAxis_X = 0,
        ImGuiAxis_Y = 1,
    }

    public enum ImGuiPlotType
    {
        ImGuiPlotType_Lines,
        ImGuiPlotType_Histogram,
    }

    public partial struct ImGuiComboPreviewData
    {
        public ImRect PreviewRect;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 BackupCursorPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 BackupCursorMaxPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 BackupCursorPosPrevLine;

        public float BackupPrevLineTextBaseOffset;

        [NativeTypeName("ImGuiLayoutType")]
        public int BackupLayout;
    }

    public partial struct ImGuiGroupData
    {
        [NativeTypeName("ImGuiID")]
        public uint WindowID;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 BackupCursorPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 BackupCursorMaxPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 BackupCursorPosPrevLine;

        public ImVec1 BackupIndent;

        public ImVec1 BackupGroupOffset;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 BackupCurrLineSize;

        public float BackupCurrLineTextBaseOffset;

        [NativeTypeName("ImGuiID")]
        public uint BackupActiveIdIsAlive;

        [NativeTypeName("_Bool")]
        public byte BackupDeactivatedIdIsAlive;

        [NativeTypeName("_Bool")]
        public byte BackupHoveredIdIsAlive;

        [NativeTypeName("_Bool")]
        public byte BackupIsSameLine;

        [NativeTypeName("_Bool")]
        public byte EmitItem;
    }

    public partial struct ImGuiMenuColumns
    {
        [NativeTypeName("ImU32")]
        public uint TotalWidth;

        [NativeTypeName("ImU32")]
        public uint NextTotalWidth;

        [NativeTypeName("ImU16")]
        public ushort Spacing;

        [NativeTypeName("ImU16")]
        public ushort OffsetIcon;

        [NativeTypeName("ImU16")]
        public ushort OffsetLabel;

        [NativeTypeName("ImU16")]
        public ushort OffsetShortcut;

        [NativeTypeName("ImU16")]
        public ushort OffsetMark;

        [NativeTypeName("ImU16[4]")]
        public _Widths_e__FixedBuffer Widths;

        [InlineArray(4)]
        public partial struct _Widths_e__FixedBuffer
        {
            public ushort e0;
        }
    }

    public partial struct ImGuiInputTextDeactivatedState
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        public ImVector_char TextA;
    }

    public unsafe partial struct ImGuiInputTextState
    {
        public ImGuiContext* Ctx;

        [NativeTypeName("ImStbTexteditState *")]
        public STB_TexteditState* Stb;

        [NativeTypeName("ImGuiInputTextFlags")]
        public int Flags;

        [NativeTypeName("ImGuiID")]
        public uint ID;

        public int TextLen;

        [NativeTypeName("const char *")]
        public sbyte* TextSrc;

        public ImVector_char TextA;

        public ImVector_char TextToRevertTo;

        public ImVector_char CallbackTextBackup;

        public int BufCapacity;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 Scroll;

        public int LineCount;

        public float WrapWidth;

        public float CursorAnim;

        [NativeTypeName("_Bool")]
        public byte CursorFollow;

        [NativeTypeName("_Bool")]
        public byte CursorCenterY;

        [NativeTypeName("_Bool")]
        public byte SelectedAllMouseLock;

        [NativeTypeName("_Bool")]
        public byte Edited;

        [NativeTypeName("_Bool")]
        public byte WantReloadUserBuf;

        [NativeTypeName("ImS8")]
        public sbyte LastMoveDirectionLR;

        public int ReloadSelectionStart;

        public int ReloadSelectionEnd;
    }

    public enum ImGuiWindowRefreshFlags_
    {
        ImGuiWindowRefreshFlags_None = 0,
        ImGuiWindowRefreshFlags_TryToAvoidRefresh = 1 << 0,
        ImGuiWindowRefreshFlags_RefreshOnHover = 1 << 1,
        ImGuiWindowRefreshFlags_RefreshOnFocus = 1 << 2,
    }

    public enum ImGuiNextWindowDataFlags_
    {
        ImGuiNextWindowDataFlags_None = 0,
        ImGuiNextWindowDataFlags_HasPos = 1 << 0,
        ImGuiNextWindowDataFlags_HasSize = 1 << 1,
        ImGuiNextWindowDataFlags_HasContentSize = 1 << 2,
        ImGuiNextWindowDataFlags_HasCollapsed = 1 << 3,
        ImGuiNextWindowDataFlags_HasSizeConstraint = 1 << 4,
        ImGuiNextWindowDataFlags_HasFocus = 1 << 5,
        ImGuiNextWindowDataFlags_HasBgAlpha = 1 << 6,
        ImGuiNextWindowDataFlags_HasScroll = 1 << 7,
        ImGuiNextWindowDataFlags_HasWindowFlags = 1 << 8,
        ImGuiNextWindowDataFlags_HasChildFlags = 1 << 9,
        ImGuiNextWindowDataFlags_HasRefreshPolicy = 1 << 10,
        ImGuiNextWindowDataFlags_HasViewport = 1 << 11,
        ImGuiNextWindowDataFlags_HasDock = 1 << 12,
        ImGuiNextWindowDataFlags_HasWindowClass = 1 << 13,
    }

    public unsafe partial struct ImGuiNextWindowData
    {
        [NativeTypeName("ImGuiNextWindowDataFlags")]
        public int HasFlags;

        [NativeTypeName("ImGuiCond")]
        public int PosCond;

        [NativeTypeName("ImGuiCond")]
        public int SizeCond;

        [NativeTypeName("ImGuiCond")]
        public int CollapsedCond;

        [NativeTypeName("ImGuiCond")]
        public int DockCond;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 PosVal;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 PosPivotVal;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 SizeVal;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ContentSizeVal;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ScrollVal;

        [NativeTypeName("ImGuiWindowFlags")]
        public int WindowFlags;

        [NativeTypeName("ImGuiChildFlags")]
        public int ChildFlags;

        [NativeTypeName("_Bool")]
        public byte PosUndock;

        [NativeTypeName("_Bool")]
        public byte CollapsedVal;

        public ImRect SizeConstraintRect;

        [NativeTypeName("ImGuiSizeCallback")]
        public delegate* unmanaged[Cdecl]<ImGuiSizeCallbackData*, void> SizeCallback;

        public void* SizeCallbackUserData;

        public float BgAlphaVal;

        [NativeTypeName("ImGuiID")]
        public uint ViewportId;

        [NativeTypeName("ImGuiID")]
        public uint DockId;

        public ImGuiWindowClass WindowClass;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 MenuBarOffsetMinVal;

        [NativeTypeName("ImGuiWindowRefreshFlags")]
        public int RefreshFlagsVal;
    }

    public enum ImGuiNextItemDataFlags_
    {
        ImGuiNextItemDataFlags_None = 0,
        ImGuiNextItemDataFlags_HasWidth = 1 << 0,
        ImGuiNextItemDataFlags_HasOpen = 1 << 1,
        ImGuiNextItemDataFlags_HasShortcut = 1 << 2,
        ImGuiNextItemDataFlags_HasRefVal = 1 << 3,
        ImGuiNextItemDataFlags_HasStorageID = 1 << 4,
    }

    public partial struct ImGuiNextItemData
    {
        [NativeTypeName("ImGuiNextItemDataFlags")]
        public int HasFlags;

        [NativeTypeName("ImGuiItemFlags")]
        public int ItemFlags;

        [NativeTypeName("ImGuiID")]
        public uint FocusScopeId;

        [NativeTypeName("ImGuiSelectionUserData")]
        public long SelectionUserData;

        public float Width;

        [NativeTypeName("ImGuiKeyChord")]
        public int Shortcut;

        [NativeTypeName("ImGuiInputFlags")]
        public int ShortcutFlags;

        [NativeTypeName("_Bool")]
        public byte OpenVal;

        [NativeTypeName("ImU8")]
        public byte OpenCond;

        public ImGuiDataTypeStorage RefVal;

        [NativeTypeName("ImGuiID")]
        public uint StorageId;
    }

    public partial struct ImGuiLastItemData
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("ImGuiItemFlags")]
        public int ItemFlags;

        [NativeTypeName("ImGuiItemStatusFlags")]
        public int StatusFlags;

        public ImRect Rect;

        public ImRect NavRect;

        public ImRect DisplayRect;

        public ImRect ClipRect;

        [NativeTypeName("ImGuiKeyChord")]
        public int Shortcut;
    }

    public partial struct ImGuiTreeNodeStackData
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("ImGuiTreeNodeFlags")]
        public int TreeFlags;

        [NativeTypeName("ImGuiItemFlags")]
        public int ItemFlags;

        public ImRect NavRect;

        public float DrawLinesX1;

        public float DrawLinesToNodesY2;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short DrawLinesTableColumn;
    }

    public partial struct ImGuiErrorRecoveryState
    {
        public short SizeOfWindowStack;

        public short SizeOfIDStack;

        public short SizeOfTreeStack;

        public short SizeOfColorStack;

        public short SizeOfStyleVarStack;

        public short SizeOfFontStack;

        public short SizeOfFocusScopeStack;

        public short SizeOfGroupStack;

        public short SizeOfItemFlagsStack;

        public short SizeOfBeginPopupStack;

        public short SizeOfDisabledStack;
    }

    public unsafe partial struct ImGuiWindowStackData
    {
        public ImGuiWindow* Window;

        public ImGuiLastItemData ParentLastItemDataBackup;

        public ImGuiErrorRecoveryState StackSizesInBegin;

        [NativeTypeName("_Bool")]
        public byte DisabledOverrideReenable;

        public float DisabledOverrideReenableAlphaBackup;
    }

    public partial struct ImGuiShrinkWidthItem
    {
        public int Index;

        public float Width;

        public float InitialWidth;
    }

    public unsafe partial struct ImGuiPtrOrIndex
    {
        public void* Ptr;

        public int Index;
    }

    public partial struct ImGuiDeactivatedItemData
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        public int ElapseFrame;

        [NativeTypeName("_Bool")]
        public byte HasBeenEditedBefore;

        [NativeTypeName("_Bool")]
        public byte IsAlive;
    }

    public enum ImGuiPopupPositionPolicy
    {
        ImGuiPopupPositionPolicy_Default,
        ImGuiPopupPositionPolicy_ComboBox,
        ImGuiPopupPositionPolicy_Tooltip,
    }

    public unsafe partial struct ImGuiPopupData
    {
        [NativeTypeName("ImGuiID")]
        public uint PopupId;

        public ImGuiWindow* Window;

        public ImGuiWindow* RestoreNavWindow;

        public int ParentNavLayer;

        public int OpenFrameCount;

        [NativeTypeName("ImGuiID")]
        public uint OpenParentId;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 OpenPopupPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 OpenMousePos;
    }

    public partial struct ImBitArray_ImGuiKey_NamedKey_COUNT__lessImGuiKey_NamedKey_BEGIN
    {
        [NativeTypeName("ImU32[5]")]
        public _Storage_e__FixedBuffer Storage;

        [InlineArray(5)]
        public partial struct _Storage_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public enum ImGuiInputEventType
    {
        ImGuiInputEventType_None = 0,
        ImGuiInputEventType_MousePos,
        ImGuiInputEventType_MouseWheel,
        ImGuiInputEventType_MouseButton,
        ImGuiInputEventType_MouseViewport,
        ImGuiInputEventType_Key,
        ImGuiInputEventType_Text,
        ImGuiInputEventType_Focus,
        ImGuiInputEventType_COUNT,
    }

    public enum ImGuiInputSource
    {
        ImGuiInputSource_None = 0,
        ImGuiInputSource_Mouse = 1,
        ImGuiInputSource_Keyboard = 2,
        ImGuiInputSource_Gamepad = 3,
        ImGuiInputSource_COUNT = 4,
    }

    public partial struct ImGuiInputEventMousePos
    {
        public float PosX;

        public float PosY;

        public ImGuiMouseSource MouseSource;
    }

    public partial struct ImGuiInputEventMouseWheel
    {
        public float WheelX;

        public float WheelY;

        public ImGuiMouseSource MouseSource;
    }

    public partial struct ImGuiInputEventMouseButton
    {
        public int Button;

        [NativeTypeName("_Bool")]
        public byte Down;

        public ImGuiMouseSource MouseSource;
    }

    public partial struct ImGuiInputEventMouseViewport
    {
        [NativeTypeName("ImGuiID")]
        public uint HoveredViewportID;
    }

    public partial struct ImGuiInputEventKey
    {
        public ImGuiKey Key;

        [NativeTypeName("_Bool")]
        public byte Down;

        public float AnalogValue;
    }

    public partial struct ImGuiInputEventText
    {
        [NativeTypeName("unsigned int")]
        public uint Char;
    }

    public partial struct ImGuiInputEventAppFocused
    {
        [NativeTypeName("_Bool")]
        public byte Focused;
    }

    public partial struct ImGuiInputEvent
    {
        public ImGuiInputEventType Type;

        public ImGuiInputSource Source;

        [NativeTypeName("ImU32")]
        public uint EventId;

        [NativeTypeName("__AnonymousRecord_cimgui_L2344_C5")]
        public _Anonymous_e__Union Anonymous;

        [NativeTypeName("_Bool")]
        public byte AddedByTestEngine;

        [UnscopedRef]
        public ref ImGuiInputEventMousePos MousePos
        {
            get
            {
                return ref Anonymous.MousePos;
            }
        }

        [UnscopedRef]
        public ref ImGuiInputEventMouseWheel MouseWheel
        {
            get
            {
                return ref Anonymous.MouseWheel;
            }
        }

        [UnscopedRef]
        public ref ImGuiInputEventMouseButton MouseButton
        {
            get
            {
                return ref Anonymous.MouseButton;
            }
        }

        [UnscopedRef]
        public ref ImGuiInputEventMouseViewport MouseViewport
        {
            get
            {
                return ref Anonymous.MouseViewport;
            }
        }

        [UnscopedRef]
        public ref ImGuiInputEventKey Key
        {
            get
            {
                return ref Anonymous.Key;
            }
        }

        [UnscopedRef]
        public ref ImGuiInputEventText Text
        {
            get
            {
                return ref Anonymous.Text;
            }
        }

        [UnscopedRef]
        public ref ImGuiInputEventAppFocused AppFocused
        {
            get
            {
                return ref Anonymous.AppFocused;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous_e__Union
        {
            [FieldOffset(0)]
            public ImGuiInputEventMousePos MousePos;

            [FieldOffset(0)]
            public ImGuiInputEventMouseWheel MouseWheel;

            [FieldOffset(0)]
            public ImGuiInputEventMouseButton MouseButton;

            [FieldOffset(0)]
            public ImGuiInputEventMouseViewport MouseViewport;

            [FieldOffset(0)]
            public ImGuiInputEventKey Key;

            [FieldOffset(0)]
            public ImGuiInputEventText Text;

            [FieldOffset(0)]
            public ImGuiInputEventAppFocused AppFocused;
        }
    }

    public partial struct ImGuiKeyRoutingData
    {
        [NativeTypeName("ImGuiKeyRoutingIndex")]
        public short NextEntryIndex;

        [NativeTypeName("ImU16")]
        public ushort Mods;

        [NativeTypeName("ImU8")]
        public byte RoutingCurrScore;

        [NativeTypeName("ImU8")]
        public byte RoutingNextScore;

        [NativeTypeName("ImGuiID")]
        public uint RoutingCurr;

        [NativeTypeName("ImGuiID")]
        public uint RoutingNext;
    }

    public unsafe partial struct ImVector_ImGuiKeyRoutingData
    {
        public int Size;

        public int Capacity;

        public ImGuiKeyRoutingData* Data;
    }

    public partial struct ImGuiKeyRoutingTable
    {
        [NativeTypeName("ImGuiKeyRoutingIndex[155]")]
        public _Index_e__FixedBuffer Index;

        public ImVector_ImGuiKeyRoutingData Entries;

        public ImVector_ImGuiKeyRoutingData EntriesNext;

        [InlineArray(155)]
        public partial struct _Index_e__FixedBuffer
        {
            public short e0;
        }
    }

    public partial struct ImGuiKeyOwnerData
    {
        [NativeTypeName("ImGuiID")]
        public uint OwnerCurr;

        [NativeTypeName("ImGuiID")]
        public uint OwnerNext;

        [NativeTypeName("_Bool")]
        public byte LockThisFrame;

        [NativeTypeName("_Bool")]
        public byte LockUntilRelease;
    }

    public enum ImGuiInputFlagsPrivate_
    {
        ImGuiInputFlags_RepeatRateDefault = 1 << 1,
        ImGuiInputFlags_RepeatRateNavMove = 1 << 2,
        ImGuiInputFlags_RepeatRateNavTweak = 1 << 3,
        ImGuiInputFlags_RepeatUntilRelease = 1 << 4,
        ImGuiInputFlags_RepeatUntilKeyModsChange = 1 << 5,
        ImGuiInputFlags_RepeatUntilKeyModsChangeFromNone = 1 << 6,
        ImGuiInputFlags_RepeatUntilOtherKeyPress = 1 << 7,
        ImGuiInputFlags_LockThisFrame = 1 << 20,
        ImGuiInputFlags_LockUntilRelease = 1 << 21,
        ImGuiInputFlags_CondHovered = 1 << 22,
        ImGuiInputFlags_CondActive = 1 << 23,
        ImGuiInputFlags_CondDefault_ = ImGuiInputFlags_CondHovered | ImGuiInputFlags_CondActive,
        ImGuiInputFlags_RepeatRateMask_ = ImGuiInputFlags_RepeatRateDefault | ImGuiInputFlags_RepeatRateNavMove | ImGuiInputFlags_RepeatRateNavTweak,
        ImGuiInputFlags_RepeatUntilMask_ = ImGuiInputFlags_RepeatUntilRelease | ImGuiInputFlags_RepeatUntilKeyModsChange | ImGuiInputFlags_RepeatUntilKeyModsChangeFromNone | ImGuiInputFlags_RepeatUntilOtherKeyPress,
        ImGuiInputFlags_RepeatMask_ = ImGuiInputFlags.Repeat | ImGuiInputFlags_RepeatRateMask_ | ImGuiInputFlags_RepeatUntilMask_,
        ImGuiInputFlags_CondMask_ = ImGuiInputFlags_CondHovered | ImGuiInputFlags_CondActive,
        ImGuiInputFlags_RouteTypeMask_ = ImGuiInputFlags.RouteActive | ImGuiInputFlags.RouteFocused | ImGuiInputFlags.RouteGlobal | ImGuiInputFlags.RouteAlways,
        ImGuiInputFlags_RouteOptionsMask_ = ImGuiInputFlags.RouteOverFocused | ImGuiInputFlags.RouteOverActive | ImGuiInputFlags.RouteUnlessBgFocused | ImGuiInputFlags.RouteFromRootWindow,
        ImGuiInputFlags_SupportedByIsKeyPressed = ImGuiInputFlags_RepeatMask_,
        ImGuiInputFlags_SupportedByIsMouseClicked = ImGuiInputFlags.Repeat,
        ImGuiInputFlags_SupportedByShortcut = ImGuiInputFlags_RepeatMask_ | ImGuiInputFlags_RouteTypeMask_ | ImGuiInputFlags_RouteOptionsMask_,
        ImGuiInputFlags_SupportedBySetNextItemShortcut = ImGuiInputFlags_RepeatMask_ | ImGuiInputFlags_RouteTypeMask_ | ImGuiInputFlags_RouteOptionsMask_ | ImGuiInputFlags.Tooltip,
        ImGuiInputFlags_SupportedBySetKeyOwner = ImGuiInputFlags_LockThisFrame | ImGuiInputFlags_LockUntilRelease,
        ImGuiInputFlags_SupportedBySetItemKeyOwner = ImGuiInputFlags_SupportedBySetKeyOwner | ImGuiInputFlags_CondMask_,
    }

    public partial struct ImGuiListClipperRange
    {
        public int Min;

        public int Max;

        [NativeTypeName("_Bool")]
        public byte PosToIndexConvert;

        [NativeTypeName("ImS8")]
        public sbyte PosToIndexOffsetMin;

        [NativeTypeName("ImS8")]
        public sbyte PosToIndexOffsetMax;
    }

    public unsafe partial struct ImVector_ImGuiListClipperRange
    {
        public int Size;

        public int Capacity;

        public ImGuiListClipperRange* Data;
    }

    public unsafe partial struct ImGuiListClipperData
    {
        public ImGuiListClipper* ListClipper;

        public float LossynessOffset;

        public int StepNo;

        public int ItemsFrozen;

        public ImVector_ImGuiListClipperRange Ranges;
    }

    public enum ImGuiActivateFlags_
    {
        ImGuiActivateFlags_None = 0,
        ImGuiActivateFlags_PreferInput = 1 << 0,
        ImGuiActivateFlags_PreferTweak = 1 << 1,
        ImGuiActivateFlags_TryToPreserveState = 1 << 2,
        ImGuiActivateFlags_FromTabbing = 1 << 3,
        ImGuiActivateFlags_FromShortcut = 1 << 4,
        ImGuiActivateFlags_FromFocusApi = 1 << 5,
    }

    public enum ImGuiScrollFlags_
    {
        ImGuiScrollFlags_None = 0,
        ImGuiScrollFlags_KeepVisibleEdgeX = 1 << 0,
        ImGuiScrollFlags_KeepVisibleEdgeY = 1 << 1,
        ImGuiScrollFlags_KeepVisibleCenterX = 1 << 2,
        ImGuiScrollFlags_KeepVisibleCenterY = 1 << 3,
        ImGuiScrollFlags_AlwaysCenterX = 1 << 4,
        ImGuiScrollFlags_AlwaysCenterY = 1 << 5,
        ImGuiScrollFlags_NoScrollParent = 1 << 6,
        ImGuiScrollFlags_MaskX_ = ImGuiScrollFlags_KeepVisibleEdgeX | ImGuiScrollFlags_KeepVisibleCenterX | ImGuiScrollFlags_AlwaysCenterX,
        ImGuiScrollFlags_MaskY_ = ImGuiScrollFlags_KeepVisibleEdgeY | ImGuiScrollFlags_KeepVisibleCenterY | ImGuiScrollFlags_AlwaysCenterY,
    }

    public enum ImGuiNavRenderCursorFlags_
    {
        ImGuiNavRenderCursorFlags_None = 0,
        ImGuiNavRenderCursorFlags_Compact = 1 << 1,
        ImGuiNavRenderCursorFlags_AlwaysDraw = 1 << 2,
        ImGuiNavRenderCursorFlags_NoRounding = 1 << 3,
    }

    public enum ImGuiNavMoveFlags_
    {
        ImGuiNavMoveFlags_None = 0,
        ImGuiNavMoveFlags_LoopX = 1 << 0,
        ImGuiNavMoveFlags_LoopY = 1 << 1,
        ImGuiNavMoveFlags_WrapX = 1 << 2,
        ImGuiNavMoveFlags_WrapY = 1 << 3,
        ImGuiNavMoveFlags_WrapMask_ = ImGuiNavMoveFlags_LoopX | ImGuiNavMoveFlags_LoopY | ImGuiNavMoveFlags_WrapX | ImGuiNavMoveFlags_WrapY,
        ImGuiNavMoveFlags_AllowCurrentNavId = 1 << 4,
        ImGuiNavMoveFlags_AlsoScoreVisibleSet = 1 << 5,
        ImGuiNavMoveFlags_ScrollToEdgeY = 1 << 6,
        ImGuiNavMoveFlags_Forwarded = 1 << 7,
        ImGuiNavMoveFlags_DebugNoResult = 1 << 8,
        ImGuiNavMoveFlags_FocusApi = 1 << 9,
        ImGuiNavMoveFlags_IsTabbing = 1 << 10,
        ImGuiNavMoveFlags_IsPageMove = 1 << 11,
        ImGuiNavMoveFlags_Activate = 1 << 12,
        ImGuiNavMoveFlags_NoSelect = 1 << 13,
        ImGuiNavMoveFlags_NoSetNavCursorVisible = 1 << 14,
        ImGuiNavMoveFlags_NoClearActiveId = 1 << 15,
    }

    public enum ImGuiNavLayer
    {
        ImGuiNavLayer_Main = 0,
        ImGuiNavLayer_Menu = 1,
        ImGuiNavLayer_COUNT,
    }

    public unsafe partial struct ImGuiNavItemData
    {
        public ImGuiWindow* Window;

        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("ImGuiID")]
        public uint FocusScopeId;

        public ImRect RectRel;

        [NativeTypeName("ImGuiItemFlags")]
        public int ItemFlags;

        public float DistBox;

        public float DistCenter;

        public float DistAxial;

        [NativeTypeName("ImGuiSelectionUserData")]
        public long SelectionUserData;
    }

    public partial struct ImGuiFocusScopeData
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("ImGuiID")]
        public uint WindowID;
    }

    public enum ImGuiTypingSelectFlags_
    {
        ImGuiTypingSelectFlags_None = 0,
        ImGuiTypingSelectFlags_AllowBackspace = 1 << 0,
        ImGuiTypingSelectFlags_AllowSingleCharMode = 1 << 1,
    }

    public unsafe partial struct ImGuiTypingSelectRequest
    {
        [NativeTypeName("ImGuiTypingSelectFlags")]
        public int Flags;

        public int SearchBufferLen;

        [NativeTypeName("const char *")]
        public sbyte* SearchBuffer;

        [NativeTypeName("_Bool")]
        public byte SelectRequest;

        [NativeTypeName("_Bool")]
        public byte SingleCharMode;

        [NativeTypeName("ImS8")]
        public sbyte SingleCharSize;
    }

    public partial struct ImGuiTypingSelectState
    {
        public ImGuiTypingSelectRequest Request;

        [NativeTypeName("char[64]")]
        public _SearchBuffer_e__FixedBuffer SearchBuffer;

        [NativeTypeName("ImGuiID")]
        public uint FocusScope;

        public int LastRequestFrame;

        public float LastRequestTime;

        [NativeTypeName("_Bool")]
        public byte SingleCharModeLock;

        [InlineArray(64)]
        public partial struct _SearchBuffer_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public enum ImGuiOldColumnFlags_
    {
        ImGuiOldColumnFlags_None = 0,
        ImGuiOldColumnFlags_NoBorder = 1 << 0,
        ImGuiOldColumnFlags_NoResize = 1 << 1,
        ImGuiOldColumnFlags_NoPreserveWidths = 1 << 2,
        ImGuiOldColumnFlags_NoForceWithinWindow = 1 << 3,
        ImGuiOldColumnFlags_GrowParentContentsSize = 1 << 4,
    }

    public partial struct ImGuiOldColumnData
    {
        public float OffsetNorm;

        public float OffsetNormBeforeResize;

        [NativeTypeName("ImGuiOldColumnFlags")]
        public int Flags;

        public ImRect ClipRect;
    }

    public unsafe partial struct ImVector_ImGuiOldColumnData
    {
        public int Size;

        public int Capacity;

        public ImGuiOldColumnData* Data;
    }

    public partial struct ImGuiOldColumns
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("ImGuiOldColumnFlags")]
        public int Flags;

        [NativeTypeName("_Bool")]
        public byte IsFirstFrame;

        [NativeTypeName("_Bool")]
        public byte IsBeingResized;

        public int Current;

        public int Count;

        public float OffMinX;

        public float OffMaxX;

        public float LineMinY;

        public float LineMaxY;

        public float HostCursorPosY;

        public float HostCursorMaxPosX;

        public ImRect HostInitialClipRect;

        public ImRect HostBackupClipRect;

        public ImRect HostBackupParentWorkRect;

        public ImVector_ImGuiOldColumnData Columns;

        public ImDrawListSplitter Splitter;
    }

    public unsafe partial struct ImGuiBoxSelectState
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("_Bool")]
        public byte IsActive;

        [NativeTypeName("_Bool")]
        public byte IsStarting;

        [NativeTypeName("_Bool")]
        public byte IsStartedFromVoid;

        [NativeTypeName("_Bool")]
        public byte IsStartedSetNavIdOnce;

        [NativeTypeName("_Bool")]
        public byte RequestClear;

        public int _bitfield;

        [NativeTypeName("ImGuiKeyChord : 16")]
        public int KeyMods
        {
            readonly get
            {
                return (_bitfield << 16) >> 16;
            }

            set
            {
                _bitfield = (_bitfield & ~0xFFFF) | (value & 0xFFFF);
            }
        }

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 StartPosRel;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 EndPosRel;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ScrollAccum;

        public ImGuiWindow* Window;

        [NativeTypeName("_Bool")]
        public byte UnclipMode;

        public ImRect UnclipRect;

        public ImRect BoxSelectRectPrev;

        public ImRect BoxSelectRectCurr;
    }

    public unsafe partial struct ImGuiMultiSelectTempData
    {
        public ImGuiMultiSelectIO IO;

        public ImGuiMultiSelectState* Storage;

        [NativeTypeName("ImGuiID")]
        public uint FocusScopeId;

        [NativeTypeName("ImGuiMultiSelectFlags")]
        public int Flags;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ScopeRectMin;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 BackupCursorMaxPos;

        [NativeTypeName("ImGuiSelectionUserData")]
        public long LastSubmittedItem;

        [NativeTypeName("ImGuiID")]
        public uint BoxSelectId;

        [NativeTypeName("ImGuiKeyChord")]
        public int KeyMods;

        [NativeTypeName("ImS8")]
        public sbyte LoopRequestSetAll;

        [NativeTypeName("_Bool")]
        public byte IsEndIO;

        [NativeTypeName("_Bool")]
        public byte IsFocused;

        [NativeTypeName("_Bool")]
        public byte IsKeyboardSetRange;

        [NativeTypeName("_Bool")]
        public byte NavIdPassedBy;

        [NativeTypeName("_Bool")]
        public byte RangeSrcPassedBy;

        [NativeTypeName("_Bool")]
        public byte RangeDstPassedBy;
    }

    public unsafe partial struct ImGuiMultiSelectState
    {
        public ImGuiWindow* Window;

        [NativeTypeName("ImGuiID")]
        public uint ID;

        public int LastFrameActive;

        public int LastSelectionSize;

        [NativeTypeName("ImS8")]
        public sbyte RangeSelected;

        [NativeTypeName("ImS8")]
        public sbyte NavIdSelected;

        [NativeTypeName("ImGuiSelectionUserData")]
        public long RangeSrcItem;

        [NativeTypeName("ImGuiSelectionUserData")]
        public long NavIdItem;
    }

    public enum ImGuiDockNodeFlagsPrivate_
    {
        ImGuiDockNodeFlags_DockSpace = 1 << 10,
        ImGuiDockNodeFlags_CentralNode = 1 << 11,
        ImGuiDockNodeFlags_NoTabBar = 1 << 12,
        ImGuiDockNodeFlags_HiddenTabBar = 1 << 13,
        ImGuiDockNodeFlags_NoWindowMenuButton = 1 << 14,
        ImGuiDockNodeFlags_NoCloseButton = 1 << 15,
        ImGuiDockNodeFlags_NoResizeX = 1 << 16,
        ImGuiDockNodeFlags_NoResizeY = 1 << 17,
        ImGuiDockNodeFlags_DockedWindowsInFocusRoute = 1 << 18,
        ImGuiDockNodeFlags_NoDockingSplitOther = 1 << 19,
        ImGuiDockNodeFlags_NoDockingOverMe = 1 << 20,
        ImGuiDockNodeFlags_NoDockingOverOther = 1 << 21,
        ImGuiDockNodeFlags_NoDockingOverEmpty = 1 << 22,
        ImGuiDockNodeFlags_NoDocking = ImGuiDockNodeFlags_NoDockingOverMe | ImGuiDockNodeFlags_NoDockingOverOther | ImGuiDockNodeFlags_NoDockingOverEmpty | ImGuiDockNodeFlags.NoDockingSplit | ImGuiDockNodeFlags_NoDockingSplitOther,
        ImGuiDockNodeFlags_SharedFlagsInheritMask_ = ~0,
        ImGuiDockNodeFlags_NoResizeFlagsMask_ = (int)(ImGuiDockNodeFlags.NoResize) | ImGuiDockNodeFlags_NoResizeX | ImGuiDockNodeFlags_NoResizeY,
        ImGuiDockNodeFlags_LocalFlagsTransferMask_ = (int)(ImGuiDockNodeFlags.NoDockingSplit) | ImGuiDockNodeFlags_NoResizeFlagsMask_ | (int)(ImGuiDockNodeFlags.AutoHideTabBar) | ImGuiDockNodeFlags_CentralNode | ImGuiDockNodeFlags_NoTabBar | ImGuiDockNodeFlags_HiddenTabBar | ImGuiDockNodeFlags_NoWindowMenuButton | ImGuiDockNodeFlags_NoCloseButton,
        ImGuiDockNodeFlags_SavedFlagsMask_ = ImGuiDockNodeFlags_NoResizeFlagsMask_ | ImGuiDockNodeFlags_DockSpace | ImGuiDockNodeFlags_CentralNode | ImGuiDockNodeFlags_NoTabBar | ImGuiDockNodeFlags_HiddenTabBar | ImGuiDockNodeFlags_NoWindowMenuButton | ImGuiDockNodeFlags_NoCloseButton,
    }

    public enum ImGuiDataAuthority_
    {
        ImGuiDataAuthority_Auto,
        ImGuiDataAuthority_DockNode,
        ImGuiDataAuthority_Window,
    }

    public enum ImGuiDockNodeState
    {
        ImGuiDockNodeState_Unknown,
        ImGuiDockNodeState_HostWindowHiddenBecauseSingleWindow,
        ImGuiDockNodeState_HostWindowHiddenBecauseWindowsAreResizing,
        ImGuiDockNodeState_HostWindowVisible,
    }

    public unsafe partial struct ImVector_ImGuiWindowPtr
    {
        public int Size;

        public int Capacity;

        public ImGuiWindow** Data;
    }

    public unsafe partial struct ImGuiDockNode
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("ImGuiDockNodeFlags")]
        public int SharedFlags;

        [NativeTypeName("ImGuiDockNodeFlags")]
        public int LocalFlags;

        [NativeTypeName("ImGuiDockNodeFlags")]
        public int LocalFlagsInWindows;

        [NativeTypeName("ImGuiDockNodeFlags")]
        public int MergedFlags;

        public ImGuiDockNodeState State;

        public ImGuiDockNode* ParentNode;

        [NativeTypeName("ImGuiDockNode *[2]")]
        public _ChildNodes_e__FixedBuffer ChildNodes;

        public ImVector_ImGuiWindowPtr Windows;

        public ImGuiTabBar* TabBar;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 Pos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 Size;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 SizeRef;

        public ImGuiAxis SplitAxis;

        public ImGuiWindowClass WindowClass;

        [NativeTypeName("ImU32")]
        public uint LastBgColor;

        public ImGuiWindow* HostWindow;

        public ImGuiWindow* VisibleWindow;

        public ImGuiDockNode* CentralNode;

        public ImGuiDockNode* OnlyNodeWithWindows;

        public int CountNodeWithWindows;

        public int LastFrameAlive;

        public int LastFrameActive;

        public int LastFrameFocused;

        [NativeTypeName("ImGuiID")]
        public uint LastFocusedNodeId;

        [NativeTypeName("ImGuiID")]
        public uint SelectedTabId;

        [NativeTypeName("ImGuiID")]
        public uint WantCloseTabId;

        [NativeTypeName("ImGuiID")]
        public uint RefViewportId;

        public int _bitfield1;

        [NativeTypeName("ImGuiDataAuthority : 3")]
        public int AuthorityForPos
        {
            readonly get
            {
                return (_bitfield1 << 29) >> 29;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~0x7) | (value & 0x7);
            }
        }

        [NativeTypeName("ImGuiDataAuthority : 3")]
        public int AuthorityForSize
        {
            readonly get
            {
                return (_bitfield1 << 26) >> 29;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0x7 << 3)) | ((value & 0x7) << 3);
            }
        }

        [NativeTypeName("ImGuiDataAuthority : 3")]
        public int AuthorityForViewport
        {
            readonly get
            {
                return (_bitfield1 << 23) >> 29;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0x7 << 6)) | ((value & 0x7) << 6);
            }
        }

        public byte _bitfield2;

        [NativeTypeName("_Bool : 1")]
        public bool IsVisible
        {
            readonly get
            {
                return (_bitfield2 & 0x1) > 0;
            }

            set
            {
                byte val = (byte)(value ? 1 : 0);
                _bitfield2 = (byte)((_bitfield2 & ~0x1) | (val & 0x1));
            }
        }

        [NativeTypeName("_Bool : 1")]
        public bool IsFocused
        {
            readonly get
            {
                return ((_bitfield2 >> 1) & 0x1) > 0;
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield2 = (byte)((_bitfield2 & ~(0x1 << 1)) | ((val & 0x1) << 1));
            }
        }

        [NativeTypeName("_Bool : 1")]
        public bool IsBgDrawnThisFrame
        {
            readonly get
            {
                return 0 < ((_bitfield2 >> 2) & 0x1);
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield2 = (byte)((_bitfield2 & ~(0x1 << 2)) | ((val & 0x1) << 2));
            }
        }

        [NativeTypeName("_Bool : 1")]
        public bool HasCloseButton
        {
            readonly get
            {
                return 0 < ((_bitfield2 >> 3) & 0x1);
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield2 = (byte)((_bitfield2 & ~(0x1 << 3)) | ((val & 0x1) << 3));
            }
        }

        [NativeTypeName("_Bool : 1")]
        public bool HasWindowMenuButton
        {
            readonly get
            {
                return 0 < ((_bitfield2 >> 4) & 0x1);
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield2 = (byte)((_bitfield2 & ~(0x1 << 4)) | ((val & 0x1) << 4));
            }
        }

        [NativeTypeName("_Bool : 1")]
        public bool HasCentralNodeChild
        {
            readonly get
            {
                return 0 < ((_bitfield2 >> 5) & 0x1);
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield2 = (byte)((_bitfield2 & ~(0x1 << 5)) | ((val & 0x1) << 5));
            }
        }

        [NativeTypeName("_Bool : 1")]
        public bool WantCloseAll
        {
            readonly get
            {
                return 0 < ((_bitfield2 >> 6) & 0x1);
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield2 = (byte)((_bitfield2 & ~(0x1 << 6)) | ((val & 0x1) << 6));
            }
        }

        [NativeTypeName("_Bool : 1")]
        public bool WantLockSizeOnce
        {
            readonly get
            {
                return 0 < ((_bitfield2 >> 7) & 0x1);
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield2 = (byte)((_bitfield2 & ~(0x1 << 7)) | ((val & 0x1) << 7));
            }
        }

        public byte _bitfield3;

        [NativeTypeName("_Bool : 1")]
        public bool WantMouseMove
        {
            readonly get
            {
                return 0 < (_bitfield3 & 0x1);
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield3 = (byte)((_bitfield3 & ~0x1) | (val & 0x1));
            }
        }

        [NativeTypeName("_Bool : 1")]
        public bool WantHiddenTabBarUpdate
        {
            readonly get
            {
                return 0 < ((_bitfield3 >> 1) & 0x1);
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield3 = (byte)((_bitfield3 & ~(0x1 << 1)) | ((val & 0x1) << 1));
            }
        }

        [NativeTypeName("_Bool : 1")]
        public bool WantHiddenTabBarToggle
        {
            readonly get
            {
                return 0 < ((_bitfield3 >> 2) & 0x1);
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield3 = (byte)((_bitfield3 & ~(0x1 << 2)) | ((val & 0x1) << 2));
            }
        }

        public unsafe partial struct _ChildNodes_e__FixedBuffer
        {
            public ImGuiDockNode* e0;
            public ImGuiDockNode* e1;

            public ref ImGuiDockNode* this[int index]
            {
                get
                {
                    fixed (ImGuiDockNode** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public enum ImGuiWindowDockStyleCol
    {
        ImGuiWindowDockStyleCol_Text,
        ImGuiWindowDockStyleCol_TabHovered,
        ImGuiWindowDockStyleCol_TabFocused,
        ImGuiWindowDockStyleCol_TabSelected,
        ImGuiWindowDockStyleCol_TabSelectedOverline,
        ImGuiWindowDockStyleCol_TabDimmed,
        ImGuiWindowDockStyleCol_TabDimmedSelected,
        ImGuiWindowDockStyleCol_TabDimmedSelectedOverline,
        ImGuiWindowDockStyleCol_COUNT,
    }

    public partial struct ImGuiWindowDockStyle
    {
        [NativeTypeName("ImU32[8]")]
        public _Colors_e__FixedBuffer Colors;

        [InlineArray(8)]
        public partial struct _Colors_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public unsafe partial struct ImVector_ImGuiDockRequest
    {
        public int Size;

        public int Capacity;

        public ImGuiDockRequest* Data;
    }

    public unsafe partial struct ImVector_ImGuiDockNodeSettings
    {
        public int Size;

        public int Capacity;

        public ImGuiDockNodeSettings* Data;
    }

    public partial struct ImGuiDockContext
    {
        public ImGuiStorage Nodes;

        public ImVector_ImGuiDockRequest Requests;

        public ImVector_ImGuiDockNodeSettings NodesSettings;

        [NativeTypeName("_Bool")]
        public byte WantFullRebuild;
    }

    public unsafe partial struct ImGuiViewportP
    {
        public ImGuiViewport _ImGuiViewport;

        public ImGuiWindow* Window;

        public int Idx;

        public int LastFrameActive;

        public int LastFocusedStampCount;

        [NativeTypeName("ImGuiID")]
        public uint LastNameHash;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 LastPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 LastSize;

        public float Alpha;

        public float LastAlpha;

        [NativeTypeName("_Bool")]
        public byte LastFocusedHadNavWindow;

        public short PlatformMonitor;

        [NativeTypeName("int[2]")]
        public _BgFgDrawListsLastFrame_e__FixedBuffer BgFgDrawListsLastFrame;

        [NativeTypeName("ImDrawList *[2]")]
        public _BgFgDrawLists_e__FixedBuffer BgFgDrawLists;

        public ImDrawData DrawDataP;

        public ImDrawDataBuilder DrawDataBuilder;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 LastPlatformPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 LastPlatformSize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 LastRendererSize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 WorkInsetMin;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 WorkInsetMax;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 BuildWorkInsetMin;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 BuildWorkInsetMax;

        [InlineArray(2)]
        public partial struct _BgFgDrawListsLastFrame_e__FixedBuffer
        {
            public int e0;
        }

        public unsafe partial struct _BgFgDrawLists_e__FixedBuffer
        {
            public ImDrawList* e0;
            public ImDrawList* e1;

            public ref ImDrawList* this[int index]
            {
                get
                {
                    fixed (ImDrawList** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public partial struct ImGuiWindowSettings
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        public ImVec2ih Pos;

        public ImVec2ih Size;

        public ImVec2ih ViewportPos;

        [NativeTypeName("ImGuiID")]
        public uint ViewportId;

        [NativeTypeName("ImGuiID")]
        public uint DockId;

        [NativeTypeName("ImGuiID")]
        public uint ClassId;

        public short DockOrder;

        [NativeTypeName("_Bool")]
        public byte Collapsed;

        [NativeTypeName("_Bool")]
        public byte IsChild;

        [NativeTypeName("_Bool")]
        public byte WantApply;

        [NativeTypeName("_Bool")]
        public byte WantDelete;
    }

    public unsafe partial struct ImGuiSettingsHandler
    {
        [NativeTypeName("const char *")]
        public sbyte* TypeName;

        [NativeTypeName("ImGuiID")]
        public uint TypeHash;

        [NativeTypeName("void (*)(ImGuiContext *, ImGuiSettingsHandler *)")]
        public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, void> ClearAllFn;

        [NativeTypeName("void (*)(ImGuiContext *, ImGuiSettingsHandler *)")]
        public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, void> ReadInitFn;

        [NativeTypeName("void *(*)(ImGuiContext *, ImGuiSettingsHandler *, const char *)")]
        public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, sbyte*, void*> ReadOpenFn;

        [NativeTypeName("void (*)(ImGuiContext *, ImGuiSettingsHandler *, void *, const char *)")]
        public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, void*, sbyte*, void> ReadLineFn;

        [NativeTypeName("void (*)(ImGuiContext *, ImGuiSettingsHandler *)")]
        public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, void> ApplyAllFn;

        [NativeTypeName("void (*)(ImGuiContext *, ImGuiSettingsHandler *, ImGuiTextBuffer *)")]
        public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, ImGuiTextBuffer*, void> WriteAllFn;

        public void* UserData;
    }

    public enum ImGuiLocKey
    {
        ImGuiLocKey_VersionStr = 0,
        ImGuiLocKey_TableSizeOne = 1,
        ImGuiLocKey_TableSizeAllFit = 2,
        ImGuiLocKey_TableSizeAllDefault = 3,
        ImGuiLocKey_TableResetOrder = 4,
        ImGuiLocKey_WindowingMainMenuBar = 5,
        ImGuiLocKey_WindowingPopup = 6,
        ImGuiLocKey_WindowingUntitled = 7,
        ImGuiLocKey_OpenLink_s = 8,
        ImGuiLocKey_CopyLink = 9,
        ImGuiLocKey_DockingHideTabBar = 10,
        ImGuiLocKey_DockingHoldShiftToDock = 11,
        ImGuiLocKey_DockingDragToUndockOrMoveNode = 12,
        ImGuiLocKey_COUNT = 13,
    }

    public unsafe partial struct ImGuiLocEntry
    {
        public ImGuiLocKey Key;

        [NativeTypeName("const char *")]
        public sbyte* Text;
    }

    public enum ImGuiDebugLogFlags_
    {
        ImGuiDebugLogFlags_None = 0,
        ImGuiDebugLogFlags_EventError = 1 << 0,
        ImGuiDebugLogFlags_EventActiveId = 1 << 1,
        ImGuiDebugLogFlags_EventFocus = 1 << 2,
        ImGuiDebugLogFlags_EventPopup = 1 << 3,
        ImGuiDebugLogFlags_EventNav = 1 << 4,
        ImGuiDebugLogFlags_EventClipper = 1 << 5,
        ImGuiDebugLogFlags_EventSelection = 1 << 6,
        ImGuiDebugLogFlags_EventIO = 1 << 7,
        ImGuiDebugLogFlags_EventFont = 1 << 8,
        ImGuiDebugLogFlags_EventInputRouting = 1 << 9,
        ImGuiDebugLogFlags_EventDocking = 1 << 10,
        ImGuiDebugLogFlags_EventViewport = 1 << 11,
        ImGuiDebugLogFlags_EventMask_ = ImGuiDebugLogFlags_EventError | ImGuiDebugLogFlags_EventActiveId | ImGuiDebugLogFlags_EventFocus | ImGuiDebugLogFlags_EventPopup | ImGuiDebugLogFlags_EventNav | ImGuiDebugLogFlags_EventClipper | ImGuiDebugLogFlags_EventSelection | ImGuiDebugLogFlags_EventIO | ImGuiDebugLogFlags_EventFont | ImGuiDebugLogFlags_EventInputRouting | ImGuiDebugLogFlags_EventDocking | ImGuiDebugLogFlags_EventViewport,
        ImGuiDebugLogFlags_OutputToTTY = 1 << 20,
        ImGuiDebugLogFlags_OutputToTestEngine = 1 << 21,
    }

    public partial struct ImGuiDebugAllocEntry
    {
        public int FrameCount;

        [NativeTypeName("ImS16")]
        public short AllocCount;

        [NativeTypeName("ImS16")]
        public short FreeCount;
    }

    public partial struct ImGuiDebugAllocInfo
    {
        public int TotalAllocCount;

        public int TotalFreeCount;

        [NativeTypeName("ImS16")]
        public short LastEntriesIdx;

        [NativeTypeName("ImGuiDebugAllocEntry[6]")]
        public _LastEntriesBuf_e__FixedBuffer LastEntriesBuf;

        [InlineArray(6)]
        public partial struct _LastEntriesBuf_e__FixedBuffer
        {
            public ImGuiDebugAllocEntry e0;
        }
    }

    public partial struct ImGuiMetricsConfig
    {
        [NativeTypeName("_Bool")]
        public byte ShowDebugLog;

        [NativeTypeName("_Bool")]
        public byte ShowIDStackTool;

        [NativeTypeName("_Bool")]
        public byte ShowWindowsRects;

        [NativeTypeName("_Bool")]
        public byte ShowWindowsBeginOrder;

        [NativeTypeName("_Bool")]
        public byte ShowTablesRects;

        [NativeTypeName("_Bool")]
        public byte ShowDrawCmdMesh;

        [NativeTypeName("_Bool")]
        public byte ShowDrawCmdBoundingBoxes;

        [NativeTypeName("_Bool")]
        public byte ShowTextEncodingViewer;

        [NativeTypeName("_Bool")]
        public byte ShowTextureUsedRect;

        [NativeTypeName("_Bool")]
        public byte ShowDockingNodes;

        public int ShowWindowsRectsType;

        public int ShowTablesRectsType;

        public int HighlightMonitorIdx;

        [NativeTypeName("ImGuiID")]
        public uint HighlightViewportID;

        [NativeTypeName("_Bool")]
        public byte ShowFontPreview;
    }

    public partial struct ImGuiStackLevelInfo
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("ImS8")]
        public sbyte QueryFrameCount;

        [NativeTypeName("_Bool")]
        public byte QuerySuccess;

        [NativeTypeName("ImS8")]
        public sbyte DataType;

        public int DescOffset;
    }

    public unsafe partial struct ImVector_ImGuiStackLevelInfo
    {
        public int Size;

        public int Capacity;

        public ImGuiStackLevelInfo* Data;
    }

    public partial struct ImGuiIDStackTool
    {
        public int LastActiveFrame;

        public int StackLevel;

        [NativeTypeName("ImGuiID")]
        public uint QueryMainId;

        public ImVector_ImGuiStackLevelInfo Results;

        [NativeTypeName("_Bool")]
        public byte QueryHookActive;

        [NativeTypeName("_Bool")]
        public byte OptHexEncodeNonAsciiChars;

        [NativeTypeName("_Bool")]
        public byte OptCopyToClipboardOnCtrlC;

        public float CopyToClipboardLastTime;

        public ImGuiTextBuffer ResultPathsBuf;

        public ImGuiTextBuffer ResultTempBuf;
    }

    public enum ImGuiContextHookType
    {
        ImGuiContextHookType_NewFramePre,
        ImGuiContextHookType_NewFramePost,
        ImGuiContextHookType_EndFramePre,
        ImGuiContextHookType_EndFramePost,
        ImGuiContextHookType_RenderPre,
        ImGuiContextHookType_RenderPost,
        ImGuiContextHookType_Shutdown,
        ImGuiContextHookType_PendingRemoval_,
    }

    public unsafe partial struct ImGuiContextHook
    {
        [NativeTypeName("ImGuiID")]
        public uint HookId;

        public ImGuiContextHookType Type;

        [NativeTypeName("ImGuiID")]
        public uint Owner;

        [NativeTypeName("ImGuiContextHookCallback")]
        public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiContextHook*, void> Callback;

        public void* UserData;
    }

    public unsafe partial struct ImVector_ImFontAtlasPtr
    {
        public int Size;

        public int Capacity;

        public ImFontAtlas** Data;
    }

    public unsafe partial struct ImVector_ImGuiInputEvent
    {
        public int Size;

        public int Capacity;

        public ImGuiInputEvent* Data;
    }

    public unsafe partial struct ImVector_ImGuiWindowStackData
    {
        public int Size;

        public int Capacity;

        public ImGuiWindowStackData* Data;
    }

    public unsafe partial struct ImVector_ImGuiColorMod
    {
        public int Size;

        public int Capacity;

        public ImGuiColorMod* Data;
    }

    public unsafe partial struct ImVector_ImGuiStyleMod
    {
        public int Size;

        public int Capacity;

        public ImGuiStyleMod* Data;
    }

    public unsafe partial struct ImVector_ImFontStackData
    {
        public int Size;

        public int Capacity;

        public ImFontStackData* Data;
    }

    public unsafe partial struct ImVector_ImGuiFocusScopeData
    {
        public int Size;

        public int Capacity;

        public ImGuiFocusScopeData* Data;
    }

    public unsafe partial struct ImVector_ImGuiItemFlags
    {
        public int Size;

        public int Capacity;

        [NativeTypeName("ImGuiItemFlags *")]
        public int* Data;
    }

    public unsafe partial struct ImVector_ImGuiGroupData
    {
        public int Size;

        public int Capacity;

        public ImGuiGroupData* Data;
    }

    public unsafe partial struct ImVector_ImGuiPopupData
    {
        public int Size;

        public int Capacity;

        public ImGuiPopupData* Data;
    }

    public unsafe partial struct ImVector_ImGuiTreeNodeStackData
    {
        public int Size;

        public int Capacity;

        public ImGuiTreeNodeStackData* Data;
    }

    public unsafe partial struct ImVector_ImGuiViewportPPtr
    {
        public int Size;

        public int Capacity;

        public ImGuiViewportP** Data;
    }

    public unsafe partial struct ImVector_unsigned_char
    {
        public int Size;

        public int Capacity;

        [NativeTypeName("unsigned char *")]
        public byte* Data;
    }

    public unsafe partial struct ImVector_ImGuiListClipperData
    {
        public int Size;

        public int Capacity;

        public ImGuiListClipperData* Data;
    }

    public unsafe partial struct ImVector_ImGuiTableTempData
    {
        public int Size;

        public int Capacity;

        public ImGuiTableTempData* Data;
    }

    public unsafe partial struct ImVector_ImGuiTable
    {
        public int Size;

        public int Capacity;

        public ImGuiTable* Data;
    }

    public partial struct ImPool_ImGuiTable
    {
        public ImVector_ImGuiTable Buf;

        public ImGuiStorage Map;

        [NativeTypeName("ImPoolIdx")]
        public int FreeIdx;

        [NativeTypeName("ImPoolIdx")]
        public int AliveCount;
    }

    public unsafe partial struct ImVector_ImGuiTabBar
    {
        public int Size;

        public int Capacity;

        public ImGuiTabBar* Data;
    }

    public partial struct ImPool_ImGuiTabBar
    {
        public ImVector_ImGuiTabBar Buf;

        public ImGuiStorage Map;

        [NativeTypeName("ImPoolIdx")]
        public int FreeIdx;

        [NativeTypeName("ImPoolIdx")]
        public int AliveCount;
    }

    public unsafe partial struct ImVector_ImGuiPtrOrIndex
    {
        public int Size;

        public int Capacity;

        public ImGuiPtrOrIndex* Data;
    }

    public unsafe partial struct ImVector_ImGuiShrinkWidthItem
    {
        public int Size;

        public int Capacity;

        public ImGuiShrinkWidthItem* Data;
    }

    public unsafe partial struct ImVector_ImGuiMultiSelectTempData
    {
        public int Size;

        public int Capacity;

        public ImGuiMultiSelectTempData* Data;
    }

    public unsafe partial struct ImVector_ImGuiMultiSelectState
    {
        public int Size;

        public int Capacity;

        public ImGuiMultiSelectState* Data;
    }

    public partial struct ImPool_ImGuiMultiSelectState
    {
        public ImVector_ImGuiMultiSelectState Buf;

        public ImGuiStorage Map;

        [NativeTypeName("ImPoolIdx")]
        public int FreeIdx;

        [NativeTypeName("ImPoolIdx")]
        public int AliveCount;
    }

    public unsafe partial struct ImVector_ImGuiID
    {
        public int Size;

        public int Capacity;

        [NativeTypeName("ImGuiID *")]
        public uint* Data;
    }

    public unsafe partial struct ImVector_ImGuiSettingsHandler
    {
        public int Size;

        public int Capacity;

        public ImGuiSettingsHandler* Data;
    }

    public partial struct ImChunkStream_ImGuiWindowSettings
    {
        public ImVector_char Buf;
    }

    public partial struct ImChunkStream_ImGuiTableSettings
    {
        public ImVector_char Buf;
    }

    public unsafe partial struct ImVector_ImGuiContextHook
    {
        public int Size;

        public int Capacity;

        public ImGuiContextHook* Data;
    }

    public unsafe partial struct ImGuiContext
    {
        [NativeTypeName("_Bool")]
        public byte Initialized;

        public ImGuiIO IO;

        public ImGuiPlatformIO PlatformIO;

        public ImGuiStyle Style;

        [NativeTypeName("ImGuiConfigFlags")]
        public int ConfigFlagsCurrFrame;

        [NativeTypeName("ImGuiConfigFlags")]
        public int ConfigFlagsLastFrame;

        public ImVector_ImFontAtlasPtr FontAtlases;

        public ImFont* Font;

        public ImFontBaked* FontBaked;

        public float FontSize;

        public float FontSizeBase;

        public float FontBakedScale;

        public float FontRasterizerDensity;

        public float CurrentDpiScale;

        public ImDrawListSharedData DrawListSharedData;

        public double Time;

        public int FrameCount;

        public int FrameCountEnded;

        public int FrameCountPlatformEnded;

        public int FrameCountRendered;

        [NativeTypeName("ImGuiID")]
        public uint WithinEndChildID;

        [NativeTypeName("_Bool")]
        public byte WithinFrameScope;

        [NativeTypeName("_Bool")]
        public byte WithinFrameScopeWithImplicitWindow;

        [NativeTypeName("_Bool")]
        public byte GcCompactAll;

        [NativeTypeName("_Bool")]
        public byte TestEngineHookItems;

        public void* TestEngine;

        [NativeTypeName("char[16]")]
        public _ContextName_e__FixedBuffer ContextName;

        public ImVector_ImGuiInputEvent InputEventsQueue;

        public ImVector_ImGuiInputEvent InputEventsTrail;

        public ImGuiMouseSource InputEventsNextMouseSource;

        [NativeTypeName("ImU32")]
        public uint InputEventsNextEventId;

        public ImVector_ImGuiWindowPtr Windows;

        public ImVector_ImGuiWindowPtr WindowsFocusOrder;

        public ImVector_ImGuiWindowPtr WindowsTempSortBuffer;

        public ImVector_ImGuiWindowStackData CurrentWindowStack;

        public ImGuiStorage WindowsById;

        public int WindowsActiveCount;

        public float WindowsBorderHoverPadding;

        [NativeTypeName("ImGuiID")]
        public uint DebugBreakInWindow;

        public ImGuiWindow* CurrentWindow;

        public ImGuiWindow* HoveredWindow;

        public ImGuiWindow* HoveredWindowUnderMovingWindow;

        public ImGuiWindow* HoveredWindowBeforeClear;

        public ImGuiWindow* MovingWindow;

        public ImGuiWindow* WheelingWindow;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 WheelingWindowRefMousePos;

        public int WheelingWindowStartFrame;

        public int WheelingWindowScrolledFrame;

        public float WheelingWindowReleaseTimer;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 WheelingWindowWheelRemainder;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 WheelingAxisAvg;

        [NativeTypeName("ImGuiID")]
        public uint DebugDrawIdConflictsId;

        [NativeTypeName("ImGuiID")]
        public uint DebugHookIdInfoId;

        [NativeTypeName("ImGuiID")]
        public uint HoveredId;

        [NativeTypeName("ImGuiID")]
        public uint HoveredIdPreviousFrame;

        public int HoveredIdPreviousFrameItemCount;

        public float HoveredIdTimer;

        public float HoveredIdNotActiveTimer;

        [NativeTypeName("_Bool")]
        public byte HoveredIdAllowOverlap;

        [NativeTypeName("_Bool")]
        public byte HoveredIdIsDisabled;

        [NativeTypeName("_Bool")]
        public byte ItemUnclipByLog;

        [NativeTypeName("ImGuiID")]
        public uint ActiveId;

        [NativeTypeName("ImGuiID")]
        public uint ActiveIdIsAlive;

        public float ActiveIdTimer;

        [NativeTypeName("_Bool")]
        public byte ActiveIdIsJustActivated;

        [NativeTypeName("_Bool")]
        public byte ActiveIdAllowOverlap;

        [NativeTypeName("_Bool")]
        public byte ActiveIdNoClearOnFocusLoss;

        [NativeTypeName("_Bool")]
        public byte ActiveIdHasBeenPressedBefore;

        [NativeTypeName("_Bool")]
        public byte ActiveIdHasBeenEditedBefore;

        [NativeTypeName("_Bool")]
        public byte ActiveIdHasBeenEditedThisFrame;

        [NativeTypeName("_Bool")]
        public byte ActiveIdFromShortcut;

        [NativeTypeName("ImGuiID")]
        public uint ActiveIdDisabledId;

        public int _bitfield;

        [NativeTypeName("int : 8")]
        public int ActiveIdMouseButton
        {
            readonly get
            {
                return (_bitfield << 24) >> 24;
            }

            set
            {
                _bitfield = (_bitfield & ~0xFF) | (value & 0xFF);
            }
        }

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ActiveIdClickOffset;

        public ImGuiWindow* ActiveIdWindow;

        public ImGuiInputSource ActiveIdSource;

        [NativeTypeName("ImGuiID")]
        public uint ActiveIdPreviousFrame;

        public ImGuiDeactivatedItemData DeactivatedItemData;

        public ImGuiDataTypeStorage ActiveIdValueOnActivation;

        [NativeTypeName("ImGuiID")]
        public uint LastActiveId;

        public float LastActiveIdTimer;

        public double LastKeyModsChangeTime;

        public double LastKeyModsChangeFromNoneTime;

        public double LastKeyboardKeyPressTime;

        [NativeTypeName("ImBitArrayForNamedKeys")]
        public ImBitArray_ImGuiKey_NamedKey_COUNT__lessImGuiKey_NamedKey_BEGIN KeysMayBeCharInput;

        [NativeTypeName("ImGuiKeyOwnerData[155]")]
        public _KeysOwnerData_e__FixedBuffer KeysOwnerData;

        public ImGuiKeyRoutingTable KeysRoutingTable;

        [NativeTypeName("ImU32")]
        public uint ActiveIdUsingNavDirMask;

        [NativeTypeName("_Bool")]
        public byte ActiveIdUsingAllKeyboardKeys;

        [NativeTypeName("ImGuiKeyChord")]
        public int DebugBreakInShortcutRouting;

        [NativeTypeName("ImGuiID")]
        public uint CurrentFocusScopeId;

        [NativeTypeName("ImGuiItemFlags")]
        public int CurrentItemFlags;

        [NativeTypeName("ImGuiID")]
        public uint DebugLocateId;

        public ImGuiNextItemData NextItemData;

        public ImGuiLastItemData LastItemData;

        public ImGuiNextWindowData NextWindowData;

        [NativeTypeName("_Bool")]
        public byte DebugShowGroupRects;

        [NativeTypeName("ImGuiCol")]
        public int DebugFlashStyleColorIdx;

        public ImVector_ImGuiColorMod ColorStack;

        public ImVector_ImGuiStyleMod StyleVarStack;

        public ImVector_ImFontStackData FontStack;

        public ImVector_ImGuiFocusScopeData FocusScopeStack;

        public ImVector_ImGuiItemFlags ItemFlagsStack;

        public ImVector_ImGuiGroupData GroupStack;

        public ImVector_ImGuiPopupData OpenPopupStack;

        public ImVector_ImGuiPopupData BeginPopupStack;

        public ImVector_ImGuiTreeNodeStackData TreeNodeStack;

        public ImVector_ImGuiViewportPPtr Viewports;

        public ImGuiViewportP* CurrentViewport;

        public ImGuiViewportP* MouseViewport;

        public ImGuiViewportP* MouseLastHoveredViewport;

        [NativeTypeName("ImGuiID")]
        public uint PlatformLastFocusedViewportId;

        public ImGuiPlatformMonitor FallbackMonitor;

        public ImRect PlatformMonitorsFullWorkRect;

        public int ViewportCreatedCount;

        public int PlatformWindowsCreatedCount;

        public int ViewportFocusedStampCount;

        [NativeTypeName("_Bool")]
        public byte NavCursorVisible;

        [NativeTypeName("_Bool")]
        public byte NavHighlightItemUnderNav;

        [NativeTypeName("_Bool")]
        public byte NavMousePosDirty;

        [NativeTypeName("_Bool")]
        public byte NavIdIsAlive;

        [NativeTypeName("ImGuiID")]
        public uint NavId;

        public ImGuiWindow* NavWindow;

        [NativeTypeName("ImGuiID")]
        public uint NavFocusScopeId;

        public ImGuiNavLayer NavLayer;

        [NativeTypeName("ImGuiID")]
        public uint NavActivateId;

        [NativeTypeName("ImGuiID")]
        public uint NavActivateDownId;

        [NativeTypeName("ImGuiID")]
        public uint NavActivatePressedId;

        [NativeTypeName("ImGuiActivateFlags")]
        public int NavActivateFlags;

        public ImVector_ImGuiFocusScopeData NavFocusRoute;

        [NativeTypeName("ImGuiID")]
        public uint NavHighlightActivatedId;

        public float NavHighlightActivatedTimer;

        [NativeTypeName("ImGuiID")]
        public uint NavNextActivateId;

        [NativeTypeName("ImGuiActivateFlags")]
        public int NavNextActivateFlags;

        public ImGuiInputSource NavInputSource;

        [NativeTypeName("ImGuiSelectionUserData")]
        public long NavLastValidSelectionUserData;

        [NativeTypeName("ImS8")]
        public sbyte NavCursorHideFrames;

        [NativeTypeName("_Bool")]
        public byte NavAnyRequest;

        [NativeTypeName("_Bool")]
        public byte NavInitRequest;

        [NativeTypeName("_Bool")]
        public byte NavInitRequestFromMove;

        public ImGuiNavItemData NavInitResult;

        [NativeTypeName("_Bool")]
        public byte NavMoveSubmitted;

        [NativeTypeName("_Bool")]
        public byte NavMoveScoringItems;

        [NativeTypeName("_Bool")]
        public byte NavMoveForwardToNextFrame;

        [NativeTypeName("ImGuiNavMoveFlags")]
        public int NavMoveFlags;

        [NativeTypeName("ImGuiScrollFlags")]
        public int NavMoveScrollFlags;

        [NativeTypeName("ImGuiKeyChord")]
        public int NavMoveKeyMods;

        public ImGuiDir NavMoveDir;

        public ImGuiDir NavMoveDirForDebug;

        public ImGuiDir NavMoveClipDir;

        public ImRect NavScoringRect;

        public ImRect NavScoringNoClipRect;

        public int NavScoringDebugCount;

        public int NavTabbingDir;

        public int NavTabbingCounter;

        public ImGuiNavItemData NavMoveResultLocal;

        public ImGuiNavItemData NavMoveResultLocalVisible;

        public ImGuiNavItemData NavMoveResultOther;

        public ImGuiNavItemData NavTabbingResultFirst;

        [NativeTypeName("ImGuiID")]
        public uint NavJustMovedFromFocusScopeId;

        [NativeTypeName("ImGuiID")]
        public uint NavJustMovedToId;

        [NativeTypeName("ImGuiID")]
        public uint NavJustMovedToFocusScopeId;

        [NativeTypeName("ImGuiKeyChord")]
        public int NavJustMovedToKeyMods;

        [NativeTypeName("_Bool")]
        public byte NavJustMovedToIsTabbing;

        [NativeTypeName("_Bool")]
        public byte NavJustMovedToHasSelectionData;

        [NativeTypeName("_Bool")]
        public byte ConfigNavWindowingWithGamepad;

        [NativeTypeName("ImGuiKeyChord")]
        public int ConfigNavWindowingKeyNext;

        [NativeTypeName("ImGuiKeyChord")]
        public int ConfigNavWindowingKeyPrev;

        public ImGuiWindow* NavWindowingTarget;

        public ImGuiWindow* NavWindowingTargetAnim;

        public ImGuiWindow* NavWindowingListWindow;

        public float NavWindowingTimer;

        public float NavWindowingHighlightAlpha;

        public ImGuiInputSource NavWindowingInputSource;

        [NativeTypeName("_Bool")]
        public byte NavWindowingToggleLayer;

        public ImGuiKey NavWindowingToggleKey;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 NavWindowingAccumDeltaPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 NavWindowingAccumDeltaSize;

        public float DimBgRatio;

        [NativeTypeName("_Bool")]
        public byte DragDropActive;

        [NativeTypeName("_Bool")]
        public byte DragDropWithinSource;

        [NativeTypeName("_Bool")]
        public byte DragDropWithinTarget;

        [NativeTypeName("ImGuiDragDropFlags")]
        public int DragDropSourceFlags;

        public int DragDropSourceFrameCount;

        public int DragDropMouseButton;

        public ImGuiPayload DragDropPayload;

        public ImRect DragDropTargetRect;

        public ImRect DragDropTargetClipRect;

        [NativeTypeName("ImGuiID")]
        public uint DragDropTargetId;

        [NativeTypeName("ImGuiDragDropFlags")]
        public int DragDropAcceptFlags;

        public float DragDropAcceptIdCurrRectSurface;

        [NativeTypeName("ImGuiID")]
        public uint DragDropAcceptIdCurr;

        [NativeTypeName("ImGuiID")]
        public uint DragDropAcceptIdPrev;

        public int DragDropAcceptFrameCount;

        [NativeTypeName("ImGuiID")]
        public uint DragDropHoldJustPressedId;

        public ImVector_unsigned_char DragDropPayloadBufHeap;

        [NativeTypeName("unsigned char[16]")]
        public _DragDropPayloadBufLocal_e__FixedBuffer DragDropPayloadBufLocal;

        public int ClipperTempDataStacked;

        public ImVector_ImGuiListClipperData ClipperTempData;

        public ImGuiTable* CurrentTable;

        [NativeTypeName("ImGuiID")]
        public uint DebugBreakInTable;

        public int TablesTempDataStacked;

        public ImVector_ImGuiTableTempData TablesTempData;

        public ImPool_ImGuiTable Tables;

        public ImVector_float TablesLastTimeActive;

        public ImVector_ImDrawChannel DrawChannelsTempMergeBuffer;

        public ImGuiTabBar* CurrentTabBar;

        public ImPool_ImGuiTabBar TabBars;

        public ImVector_ImGuiPtrOrIndex CurrentTabBarStack;

        public ImVector_ImGuiShrinkWidthItem ShrinkWidthBuffer;

        public ImGuiBoxSelectState BoxSelectState;

        public ImGuiMultiSelectTempData* CurrentMultiSelect;

        public int MultiSelectTempDataStacked;

        public ImVector_ImGuiMultiSelectTempData MultiSelectTempData;

        public ImPool_ImGuiMultiSelectState MultiSelectStorage;

        [NativeTypeName("ImGuiID")]
        public uint HoverItemDelayId;

        [NativeTypeName("ImGuiID")]
        public uint HoverItemDelayIdPreviousFrame;

        public float HoverItemDelayTimer;

        public float HoverItemDelayClearTimer;

        [NativeTypeName("ImGuiID")]
        public uint HoverItemUnlockedStationaryId;

        [NativeTypeName("ImGuiID")]
        public uint HoverWindowUnlockedStationaryId;

        [NativeTypeName("ImGuiMouseCursor")]
        public int MouseCursor;

        public float MouseStationaryTimer;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 MouseLastValidPos;

        public ImGuiInputTextState InputTextState;

        public ImGuiTextIndex InputTextLineIndex;

        public ImGuiInputTextDeactivatedState InputTextDeactivatedState;

        public ImFontBaked InputTextPasswordFontBackupBaked;

        [NativeTypeName("ImFontFlags")]
        public int InputTextPasswordFontBackupFlags;

        [NativeTypeName("ImGuiID")]
        public uint TempInputId;

        public ImGuiDataTypeStorage DataTypeZeroValue;

        public int BeginMenuDepth;

        public int BeginComboDepth;

        [NativeTypeName("ImGuiColorEditFlags")]
        public int ColorEditOptions;

        [NativeTypeName("ImGuiID")]
        public uint ColorEditCurrentID;

        [NativeTypeName("ImGuiID")]
        public uint ColorEditSavedID;

        public float ColorEditSavedHue;

        public float ColorEditSavedSat;

        [NativeTypeName("ImU32")]
        public uint ColorEditSavedColor;

        [NativeTypeName("ImVec4")]
        public System.Numerics.Vector4 ColorPickerRef;

        public ImGuiComboPreviewData ComboPreviewData;

        public ImRect WindowResizeBorderExpectedRect;

        [NativeTypeName("_Bool")]
        public byte WindowResizeRelativeMode;

        public short ScrollbarSeekMode;

        public float ScrollbarClickDeltaToGrabCenter;

        public float SliderGrabClickOffset;

        public float SliderCurrentAccum;

        [NativeTypeName("_Bool")]
        public byte SliderCurrentAccumDirty;

        [NativeTypeName("_Bool")]
        public byte DragCurrentAccumDirty;

        public float DragCurrentAccum;

        public float DragSpeedDefaultRatio;

        public float DisabledAlphaBackup;

        public short DisabledStackSize;

        public short TooltipOverrideCount;

        public ImGuiWindow* TooltipPreviousWindow;

        public ImVector_char ClipboardHandlerData;

        public ImVector_ImGuiID MenusIdSubmittedThisFrame;

        public ImGuiTypingSelectState TypingSelectState;

        public ImGuiPlatformImeData PlatformImeData;

        public ImGuiPlatformImeData PlatformImeDataPrev;

        public ImVector_ImTextureDataPtr UserTextures;

        public ImGuiDockContext DockContext;

        [NativeTypeName("void (*)(ImGuiContext *, ImGuiDockNode *, ImGuiTabBar *)")]
        public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiDockNode*, ImGuiTabBar*, void> DockNodeWindowMenuHandler;

        [NativeTypeName("_Bool")]
        public byte SettingsLoaded;

        public float SettingsDirtyTimer;

        public ImGuiTextBuffer SettingsIniData;

        public ImVector_ImGuiSettingsHandler SettingsHandlers;

        public ImChunkStream_ImGuiWindowSettings SettingsWindows;

        public ImChunkStream_ImGuiTableSettings SettingsTables;

        public ImVector_ImGuiContextHook Hooks;

        [NativeTypeName("ImGuiID")]
        public uint HookIdNext;

        [NativeTypeName("const char *[13]")]
        public _LocalizationTable_e__FixedBuffer LocalizationTable;

        [NativeTypeName("_Bool")]
        public byte LogEnabled;

        [NativeTypeName("ImGuiLogFlags")]
        public int LogFlags;

        public ImGuiWindow* LogWindow;

        [NativeTypeName("ImFileHandle")]
        public void* LogFile;

        public ImGuiTextBuffer LogBuffer;

        [NativeTypeName("const char *")]
        public sbyte* LogNextPrefix;

        [NativeTypeName("const char *")]
        public sbyte* LogNextSuffix;

        public float LogLinePosY;

        [NativeTypeName("_Bool")]
        public byte LogLineFirstItem;

        public int LogDepthRef;

        public int LogDepthToExpand;

        public int LogDepthToExpandDefault;

        [NativeTypeName("ImGuiErrorCallback")]
        public delegate* unmanaged[Cdecl]<ImGuiContext*, void*, sbyte*, void> ErrorCallback;

        public void* ErrorCallbackUserData;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ErrorTooltipLockedPos;

        [NativeTypeName("_Bool")]
        public byte ErrorFirst;

        public int ErrorCountCurrentFrame;

        public ImGuiErrorRecoveryState StackSizesInNewFrame;

        public ImGuiErrorRecoveryState* StackSizesInBeginForCurrentWindow;

        public int DebugDrawIdConflictsCount;

        [NativeTypeName("ImGuiDebugLogFlags")]
        public int DebugLogFlags;

        public ImGuiTextBuffer DebugLogBuf;

        public ImGuiTextIndex DebugLogIndex;

        public int DebugLogSkippedErrors;

        [NativeTypeName("ImGuiDebugLogFlags")]
        public int DebugLogAutoDisableFlags;

        [NativeTypeName("ImU8")]
        public byte DebugLogAutoDisableFrames;

        [NativeTypeName("ImU8")]
        public byte DebugLocateFrames;

        [NativeTypeName("_Bool")]
        public byte DebugBreakInLocateId;

        [NativeTypeName("ImGuiKeyChord")]
        public int DebugBreakKeyChord;

        [NativeTypeName("ImS8")]
        public sbyte DebugBeginReturnValueCullDepth;

        [NativeTypeName("_Bool")]
        public byte DebugItemPickerActive;

        [NativeTypeName("ImU8")]
        public byte DebugItemPickerMouseButton;

        [NativeTypeName("ImGuiID")]
        public uint DebugItemPickerBreakId;

        public float DebugFlashStyleColorTime;

        [NativeTypeName("ImVec4")]
        public System.Numerics.Vector4 DebugFlashStyleColorBackup;

        public ImGuiMetricsConfig DebugMetricsConfig;

        public ImGuiIDStackTool DebugIDStackTool;

        public ImGuiDebugAllocInfo DebugAllocInfo;

        public ImGuiDockNode* DebugHoveredDockNode;

        [NativeTypeName("float[60]")]
        public _FramerateSecPerFrame_e__FixedBuffer FramerateSecPerFrame;

        public int FramerateSecPerFrameIdx;

        public int FramerateSecPerFrameCount;

        public float FramerateSecPerFrameAccum;

        public int WantCaptureMouseNextFrame;

        public int WantCaptureKeyboardNextFrame;

        public int WantTextInputNextFrame;

        public ImVector_char TempBuffer;

        [NativeTypeName("char[64]")]
        public _TempKeychordName_e__FixedBuffer TempKeychordName;

        [InlineArray(16)]
        public partial struct _ContextName_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(155)]
        public partial struct _KeysOwnerData_e__FixedBuffer
        {
            public ImGuiKeyOwnerData e0;
        }

        [InlineArray(16)]
        public partial struct _DragDropPayloadBufLocal_e__FixedBuffer
        {
            public byte e0;
        }

        public unsafe partial struct _LocalizationTable_e__FixedBuffer
        {
            public sbyte* e0;
            public sbyte* e1;
            public sbyte* e2;
            public sbyte* e3;
            public sbyte* e4;
            public sbyte* e5;
            public sbyte* e6;
            public sbyte* e7;
            public sbyte* e8;
            public sbyte* e9;
            public sbyte* e10;
            public sbyte* e11;
            public sbyte* e12;

            public ref sbyte* this[int index]
            {
                get
                {
                    fixed (sbyte** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }

        [InlineArray(60)]
        public partial struct _FramerateSecPerFrame_e__FixedBuffer
        {
            public float e0;
        }

        [InlineArray(64)]
        public partial struct _TempKeychordName_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct ImGuiWindowTempData
    {
        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 CursorPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 CursorPosPrevLine;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 CursorStartPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 CursorMaxPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 IdealMaxPos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 CurrLineSize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 PrevLineSize;

        public float CurrLineTextBaseOffset;

        public float PrevLineTextBaseOffset;

        [NativeTypeName("_Bool")]
        public byte IsSameLine;

        [NativeTypeName("_Bool")]
        public byte IsSetPos;

        public ImVec1 Indent;

        public ImVec1 ColumnsOffset;

        public ImVec1 GroupOffset;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 CursorStartPosLossyness;

        public ImGuiNavLayer NavLayerCurrent;

        public short NavLayersActiveMask;

        public short NavLayersActiveMaskNext;

        [NativeTypeName("_Bool")]
        public byte NavIsScrollPushableX;

        [NativeTypeName("_Bool")]
        public byte NavHideHighlightOneFrame;

        [NativeTypeName("_Bool")]
        public byte NavWindowHasScrollY;

        [NativeTypeName("_Bool")]
        public byte MenuBarAppending;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 MenuBarOffset;

        public ImGuiMenuColumns MenuColumns;

        public int TreeDepth;

        [NativeTypeName("ImU32")]
        public uint TreeHasStackDataDepthMask;

        [NativeTypeName("ImU32")]
        public uint TreeRecordsClippedNodesY2Mask;

        public ImVector_ImGuiWindowPtr ChildWindows;

        public ImGuiStorage* StateStorage;

        public ImGuiOldColumns* CurrentColumns;

        public int CurrentTableIdx;

        [NativeTypeName("ImGuiLayoutType")]
        public int LayoutType;

        [NativeTypeName("ImGuiLayoutType")]
        public int ParentLayoutType;

        [NativeTypeName("ImU32")]
        public uint ModalDimBgColor;

        [NativeTypeName("ImGuiItemStatusFlags")]
        public int WindowItemStatusFlags;

        [NativeTypeName("ImGuiItemStatusFlags")]
        public int ChildItemStatusFlags;

        [NativeTypeName("ImGuiItemStatusFlags")]
        public int DockTabItemStatusFlags;

        public ImRect DockTabItemRect;

        public float ItemWidth;

        public float TextWrapPos;

        public ImVector_float ItemWidthStack;

        public ImVector_float TextWrapPosStack;
    }

    public unsafe partial struct ImVector_ImGuiOldColumns
    {
        public int Size;

        public int Capacity;

        public ImGuiOldColumns* Data;
    }

    public unsafe partial struct ImGuiWindow
    {
        public ImGuiContext* Ctx;

        [NativeTypeName("char *")]
        public sbyte* Name;

        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("ImGuiWindowFlags")]
        public int Flags;

        [NativeTypeName("ImGuiWindowFlags")]
        public int FlagsPreviousFrame;

        [NativeTypeName("ImGuiChildFlags")]
        public int ChildFlags;

        public ImGuiWindowClass WindowClass;

        public ImGuiViewportP* Viewport;

        [NativeTypeName("ImGuiID")]
        public uint ViewportId;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ViewportPos;

        public int ViewportAllowPlatformMonitorExtend;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 Pos;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 Size;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 SizeFull;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ContentSize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ContentSizeIdeal;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ContentSizeExplicit;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 WindowPadding;

        public float WindowRounding;

        public float WindowBorderSize;

        public float TitleBarHeight;

        public float MenuBarHeight;

        public float DecoOuterSizeX1;

        public float DecoOuterSizeY1;

        public float DecoOuterSizeX2;

        public float DecoOuterSizeY2;

        public float DecoInnerSizeX1;

        public float DecoInnerSizeY1;

        public int NameBufLen;

        [NativeTypeName("ImGuiID")]
        public uint MoveId;

        [NativeTypeName("ImGuiID")]
        public uint TabId;

        [NativeTypeName("ImGuiID")]
        public uint ChildId;

        [NativeTypeName("ImGuiID")]
        public uint PopupId;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 Scroll;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ScrollMax;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ScrollTarget;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ScrollTargetCenterRatio;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ScrollTargetEdgeSnapDist;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 ScrollbarSizes;

        [NativeTypeName("_Bool")]
        public byte ScrollbarX;

        [NativeTypeName("_Bool")]
        public byte ScrollbarY;

        [NativeTypeName("_Bool")]
        public byte ScrollbarXStabilizeEnabled;

        [NativeTypeName("ImU8")]
        public byte ScrollbarXStabilizeToggledHistory;

        [NativeTypeName("_Bool")]
        public byte ViewportOwned;

        [NativeTypeName("_Bool")]
        public byte Active;

        [NativeTypeName("_Bool")]
        public byte WasActive;

        [NativeTypeName("_Bool")]
        public byte WriteAccessed;

        [NativeTypeName("_Bool")]
        public byte Collapsed;

        [NativeTypeName("_Bool")]
        public byte WantCollapseToggle;

        [NativeTypeName("_Bool")]
        public byte SkipItems;

        [NativeTypeName("_Bool")]
        public byte SkipRefresh;

        [NativeTypeName("_Bool")]
        public byte Appearing;

        [NativeTypeName("_Bool")]
        public byte Hidden;

        [NativeTypeName("_Bool")]
        public byte IsFallbackWindow;

        [NativeTypeName("_Bool")]
        public byte IsExplicitChild;

        [NativeTypeName("_Bool")]
        public byte HasCloseButton;

        [NativeTypeName("signed char")]
        public sbyte ResizeBorderHovered;

        [NativeTypeName("signed char")]
        public sbyte ResizeBorderHeld;

        public short BeginCount;

        public short BeginCountPreviousFrame;

        public short BeginOrderWithinParent;

        public short BeginOrderWithinContext;

        public short FocusOrder;

        [NativeTypeName("ImS8")]
        public sbyte AutoFitFramesX;

        [NativeTypeName("ImS8")]
        public sbyte AutoFitFramesY;

        [NativeTypeName("_Bool")]
        public byte AutoFitOnlyGrows;

        public ImGuiDir AutoPosLastDirection;

        [NativeTypeName("ImS8")]
        public sbyte HiddenFramesCanSkipItems;

        [NativeTypeName("ImS8")]
        public sbyte HiddenFramesCannotSkipItems;

        [NativeTypeName("ImS8")]
        public sbyte HiddenFramesForRenderOnly;

        [NativeTypeName("ImS8")]
        public sbyte DisableInputsFrames;

        public int _bitfield1;

        [NativeTypeName("ImGuiCond : 8")]
        public int SetWindowPosAllowFlags
        {
            readonly get
            {
                return (_bitfield1 << 24) >> 24;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~0xFF) | (value & 0xFF);
            }
        }

        [NativeTypeName("ImGuiCond : 8")]
        public int SetWindowSizeAllowFlags
        {
            readonly get
            {
                return (_bitfield1 << 16) >> 24;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0xFF << 8)) | ((value & 0xFF) << 8);
            }
        }

        [NativeTypeName("ImGuiCond : 8")]
        public int SetWindowCollapsedAllowFlags
        {
            readonly get
            {
                return (_bitfield1 << 8) >> 24;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0xFF << 16)) | ((value & 0xFF) << 16);
            }
        }

        [NativeTypeName("ImGuiCond : 8")]
        public int SetWindowDockAllowFlags
        {
            readonly get
            {
                return (_bitfield1 << 0) >> 24;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0xFF << 24)) | ((value & 0xFF) << 24);
            }
        }

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 SetWindowPosVal;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 SetWindowPosPivot;

        public ImVector_ImGuiID IDStack;

        public ImGuiWindowTempData DC;

        public ImRect OuterRectClipped;

        public ImRect InnerRect;

        public ImRect InnerClipRect;

        public ImRect WorkRect;

        public ImRect ParentWorkRect;

        public ImRect ClipRect;

        public ImRect ContentRegionRect;

        public ImVec2ih HitTestHoleSize;

        public ImVec2ih HitTestHoleOffset;

        public int LastFrameActive;

        public int LastFrameJustFocused;

        public float LastTimeActive;

        public float ItemWidthDefault;

        public ImGuiStorage StateStorage;

        public ImVector_ImGuiOldColumns ColumnsStorage;

        public float FontWindowScale;

        public float FontWindowScaleParents;

        public float FontRefSize;

        public int SettingsOffset;

        public ImDrawList* DrawList;

        public ImDrawList DrawListInst;

        public ImGuiWindow* ParentWindow;

        public ImGuiWindow* ParentWindowInBeginStack;

        public ImGuiWindow* RootWindow;

        public ImGuiWindow* RootWindowPopupTree;

        public ImGuiWindow* RootWindowDockTree;

        public ImGuiWindow* RootWindowForTitleBarHighlight;

        public ImGuiWindow* RootWindowForNav;

        public ImGuiWindow* ParentWindowForFocusRoute;

        public ImGuiWindow* NavLastChildNavWindow;

        [NativeTypeName("ImGuiID[2]")]
        public _NavLastIds_e__FixedBuffer NavLastIds;

        [NativeTypeName("ImRect[2]")]
        public _NavRectRel_e__FixedBuffer NavRectRel;

        [NativeTypeName("ImVec2[2]")]
        public _NavPreferredScoringPosRel_e__FixedBuffer NavPreferredScoringPosRel;

        [NativeTypeName("ImGuiID")]
        public uint NavRootFocusScopeId;

        public int MemoryDrawListIdxCapacity;

        public int MemoryDrawListVtxCapacity;

        [NativeTypeName("_Bool")]
        public byte MemoryCompacted;

        public byte _bitfield2;

        [NativeTypeName("_Bool : 1")]
        public bool DockIsActive
        {
            readonly get
            {
                return (_bitfield2 & 0x1) > 0;
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield2 = (byte)((_bitfield2 & ~0x1) | (val & 0x1));
            }
        }

        [NativeTypeName("_Bool : 1")]
        public bool DockNodeIsVisible
        {
            readonly get
            {
                return ((_bitfield2 >> 1) & 0x1) > 0;
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield2 = (byte)((_bitfield2 & ~(0x1 << 1)) | ((val & 0x1) << 1));
            }
        }

        [NativeTypeName("_Bool : 1")]
        public bool DockTabIsVisible
        {
            readonly get
            {
                return 0 < ((_bitfield2 >> 2) & 0x1);
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield2 = (byte)((_bitfield2 & ~(0x1 << 2)) | ((val & 0x1) << 2));
            }
        }

        [NativeTypeName("_Bool : 1")]
        public bool DockTabWantClose
        {
            readonly get
            {
                return 0 < ((_bitfield2 >> 3) & 0x1);
            }

            set
            {
                byte val = value ? (byte)0 : (byte)1; 
                _bitfield2 = (byte)((_bitfield2 & ~(0x1 << 3)) | ((val & 0x1) << 3));
            }
        }

        public short DockOrder;

        public ImGuiWindowDockStyle DockStyle;

        public ImGuiDockNode* DockNode;

        public ImGuiDockNode* DockNodeAsHost;

        [NativeTypeName("ImGuiID")]
        public uint DockId;

        [InlineArray(2)]
        public partial struct _NavLastIds_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(2)]
        public partial struct _NavRectRel_e__FixedBuffer
        {
            public ImRect e0;
        }

        [InlineArray(2)]
        public partial struct _NavPreferredScoringPosRel_e__FixedBuffer
        {
            public System.Numerics.Vector2 e0;
        }
    }

    public enum ImGuiTabBarFlagsPrivate_
    {
        ImGuiTabBarFlags_DockNode = 1 << 20,
        ImGuiTabBarFlags_IsFocused = 1 << 21,
        ImGuiTabBarFlags_SaveSettings = 1 << 22,
    }

    public enum ImGuiTabItemFlagsPrivate_
    {
        ImGuiTabItemFlags_SectionMask_ = ImGuiTabItemFlags.Leading | ImGuiTabItemFlags.Trailing,
        ImGuiTabItemFlags_NoCloseButton = 1 << 20,
        ImGuiTabItemFlags_Button = 1 << 21,
        ImGuiTabItemFlags_Invisible = 1 << 22,
        ImGuiTabItemFlags_Unsorted = 1 << 23,
    }

    public unsafe partial struct ImGuiTabItem
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("ImGuiTabItemFlags")]
        public int Flags;

        public ImGuiWindow* Window;

        public int LastFrameVisible;

        public int LastFrameSelected;

        public float Offset;

        public float Width;

        public float ContentWidth;

        public float RequestedWidth;

        [NativeTypeName("ImS32")]
        public int NameOffset;

        [NativeTypeName("ImS16")]
        public short BeginOrder;

        [NativeTypeName("ImS16")]
        public short IndexDuringLayout;

        [NativeTypeName("_Bool")]
        public byte WantClose;
    }

    public unsafe partial struct ImVector_ImGuiTabItem
    {
        public int Size;

        public int Capacity;

        public ImGuiTabItem* Data;
    }

    public unsafe partial struct ImGuiTabBar
    {
        public ImGuiWindow* Window;

        public ImVector_ImGuiTabItem Tabs;

        [NativeTypeName("ImGuiTabBarFlags")]
        public int Flags;

        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("ImGuiID")]
        public uint SelectedTabId;

        [NativeTypeName("ImGuiID")]
        public uint NextSelectedTabId;

        [NativeTypeName("ImGuiID")]
        public uint VisibleTabId;

        public int CurrFrameVisible;

        public int PrevFrameVisible;

        public ImRect BarRect;

        public float BarRectPrevWidth;

        public float CurrTabsContentsHeight;

        public float PrevTabsContentsHeight;

        public float WidthAllTabs;

        public float WidthAllTabsIdeal;

        public float ScrollingAnim;

        public float ScrollingTarget;

        public float ScrollingTargetDistToVisibility;

        public float ScrollingSpeed;

        public float ScrollingRectMinX;

        public float ScrollingRectMaxX;

        public float SeparatorMinX;

        public float SeparatorMaxX;

        [NativeTypeName("ImGuiID")]
        public uint ReorderRequestTabId;

        [NativeTypeName("ImS16")]
        public short ReorderRequestOffset;

        [NativeTypeName("ImS8")]
        public sbyte BeginCount;

        [NativeTypeName("_Bool")]
        public byte WantLayout;

        [NativeTypeName("_Bool")]
        public byte VisibleTabWasSubmitted;

        [NativeTypeName("_Bool")]
        public byte TabsAddedNew;

        [NativeTypeName("_Bool")]
        public byte ScrollButtonEnabled;

        [NativeTypeName("ImS16")]
        public short TabsActiveCount;

        [NativeTypeName("ImS16")]
        public short LastTabItemIdx;

        public float ItemSpacingY;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 FramePadding;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 BackupCursorPos;

        public ImGuiTextBuffer TabsNames;
    }

    public partial struct ImGuiTableColumn
    {
        [NativeTypeName("ImGuiTableColumnFlags")]
        public int Flags;

        public float WidthGiven;

        public float MinX;

        public float MaxX;

        public float WidthRequest;

        public float WidthAuto;

        public float WidthMax;

        public float StretchWeight;

        public float InitStretchWeightOrWidth;

        public ImRect ClipRect;

        [NativeTypeName("ImGuiID")]
        public uint UserID;

        public float WorkMinX;

        public float WorkMaxX;

        public float ItemWidth;

        public float ContentMaxXFrozen;

        public float ContentMaxXUnfrozen;

        public float ContentMaxXHeadersUsed;

        public float ContentMaxXHeadersIdeal;

        [NativeTypeName("ImS16")]
        public short NameOffset;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short DisplayOrder;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short IndexWithinEnabledSet;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short PrevEnabledColumn;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short NextEnabledColumn;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short SortOrder;

        [NativeTypeName("ImGuiTableDrawChannelIdx")]
        public ushort DrawChannelCurrent;

        [NativeTypeName("ImGuiTableDrawChannelIdx")]
        public ushort DrawChannelFrozen;

        [NativeTypeName("ImGuiTableDrawChannelIdx")]
        public ushort DrawChannelUnfrozen;

        [NativeTypeName("_Bool")]
        public byte IsEnabled;

        [NativeTypeName("_Bool")]
        public byte IsUserEnabled;

        [NativeTypeName("_Bool")]
        public byte IsUserEnabledNextFrame;

        [NativeTypeName("_Bool")]
        public byte IsVisibleX;

        [NativeTypeName("_Bool")]
        public byte IsVisibleY;

        [NativeTypeName("_Bool")]
        public byte IsRequestOutput;

        [NativeTypeName("_Bool")]
        public byte IsSkipItems;

        [NativeTypeName("_Bool")]
        public byte IsPreserveWidthAuto;

        [NativeTypeName("ImS8")]
        public sbyte NavLayerCurrent;

        [NativeTypeName("ImU8")]
        public byte AutoFitQueue;

        [NativeTypeName("ImU8")]
        public byte CannotSkipItemsQueue;

        public byte _bitfield;

        [NativeTypeName("ImU8 : 2")]
        public byte SortDirection
        {
            readonly get
            {
                return (byte)(_bitfield & 0x3u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~0x3u) | (value & 0x3u));
            }
        }

        [NativeTypeName("ImU8 : 2")]
        public byte SortDirectionsAvailCount
        {
            readonly get
            {
                return (byte)((_bitfield >> 2) & 0x3u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~(0x3u << 2)) | ((value & 0x3u) << 2));
            }
        }

        [NativeTypeName("ImU8 : 4")]
        public byte SortDirectionsAvailMask
        {
            readonly get
            {
                return (byte)((_bitfield >> 4) & 0xFu);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~(0xFu << 4)) | ((value & 0xFu) << 4));
            }
        }

        [NativeTypeName("ImU8")]
        public byte SortDirectionsAvailList;
    }

    public partial struct ImGuiTableCellData
    {
        [NativeTypeName("ImU32")]
        public uint BgColor;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short Column;
    }

    public partial struct ImGuiTableHeaderData
    {
        [NativeTypeName("ImGuiTableColumnIdx")]
        public short Index;

        [NativeTypeName("ImU32")]
        public uint TextColor;

        [NativeTypeName("ImU32")]
        public uint BgColor0;

        [NativeTypeName("ImU32")]
        public uint BgColor1;
    }

    public partial struct ImGuiTableInstanceData
    {
        [NativeTypeName("ImGuiID")]
        public uint TableInstanceID;

        public float LastOuterHeight;

        public float LastTopHeadersRowHeight;

        public float LastFrozenHeight;

        public int HoveredRowLast;

        public int HoveredRowNext;
    }

    public unsafe partial struct ImSpan_ImGuiTableColumn
    {
        public ImGuiTableColumn* Data;

        public ImGuiTableColumn* DataEnd;
    }

    public unsafe partial struct ImSpan_ImGuiTableColumnIdx
    {
        [NativeTypeName("ImGuiTableColumnIdx *")]
        public short* Data;

        [NativeTypeName("ImGuiTableColumnIdx *")]
        public short* DataEnd;
    }

    public unsafe partial struct ImSpan_ImGuiTableCellData
    {
        public ImGuiTableCellData* Data;

        public ImGuiTableCellData* DataEnd;
    }

    public unsafe partial struct ImVector_ImGuiTableInstanceData
    {
        public int Size;

        public int Capacity;

        public ImGuiTableInstanceData* Data;
    }

    public unsafe partial struct ImVector_ImGuiTableColumnSortSpecs
    {
        public int Size;

        public int Capacity;

        public ImGuiTableColumnSortSpecs* Data;
    }

    public unsafe partial struct ImGuiTable
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("ImGuiTableFlags")]
        public int Flags;

        public void* RawData;

        public ImGuiTableTempData* TempData;

        public ImSpan_ImGuiTableColumn Columns;

        public ImSpan_ImGuiTableColumnIdx DisplayOrderToIndex;

        public ImSpan_ImGuiTableCellData RowCellData;

        [NativeTypeName("ImBitArrayPtr")]
        public uint* EnabledMaskByDisplayOrder;

        [NativeTypeName("ImBitArrayPtr")]
        public uint* EnabledMaskByIndex;

        [NativeTypeName("ImBitArrayPtr")]
        public uint* VisibleMaskByIndex;

        [NativeTypeName("ImGuiTableFlags")]
        public int SettingsLoadedFlags;

        public int SettingsOffset;

        public int LastFrameActive;

        public int ColumnsCount;

        public int CurrentRow;

        public int CurrentColumn;

        [NativeTypeName("ImS16")]
        public short InstanceCurrent;

        [NativeTypeName("ImS16")]
        public short InstanceInteracted;

        public float RowPosY1;

        public float RowPosY2;

        public float RowMinHeight;

        public float RowCellPaddingY;

        public float RowTextBaseline;

        public float RowIndentOffsetX;

        public int _bitfield;

        [NativeTypeName("ImGuiTableRowFlags : 16")]
        public int RowFlags
        {
            readonly get
            {
                return (_bitfield << 16) >> 16;
            }

            set
            {
                _bitfield = (_bitfield & ~0xFFFF) | (value & 0xFFFF);
            }
        }

        [NativeTypeName("ImGuiTableRowFlags : 16")]
        public int LastRowFlags
        {
            readonly get
            {
                return (_bitfield << 0) >> 16;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFFF << 16)) | ((value & 0xFFFF) << 16);
            }
        }

        public int RowBgColorCounter;

        [NativeTypeName("ImU32[2]")]
        public _RowBgColor_e__FixedBuffer RowBgColor;

        [NativeTypeName("ImU32")]
        public uint BorderColorStrong;

        [NativeTypeName("ImU32")]
        public uint BorderColorLight;

        public float BorderX1;

        public float BorderX2;

        public float HostIndentX;

        public float MinColumnWidth;

        public float OuterPaddingX;

        public float CellPaddingX;

        public float CellSpacingX1;

        public float CellSpacingX2;

        public float InnerWidth;

        public float ColumnsGivenWidth;

        public float ColumnsAutoFitWidth;

        public float ColumnsStretchSumWeights;

        public float ResizedColumnNextWidth;

        public float ResizeLockMinContentsX2;

        public float RefScale;

        public float AngledHeadersHeight;

        public float AngledHeadersSlope;

        public ImRect OuterRect;

        public ImRect InnerRect;

        public ImRect WorkRect;

        public ImRect InnerClipRect;

        public ImRect BgClipRect;

        public ImRect Bg0ClipRectForDrawCmd;

        public ImRect Bg2ClipRectForDrawCmd;

        public ImRect HostClipRect;

        public ImRect HostBackupInnerClipRect;

        public ImGuiWindow* OuterWindow;

        public ImGuiWindow* InnerWindow;

        public ImGuiTextBuffer ColumnsNames;

        public ImDrawListSplitter* DrawSplitter;

        public ImGuiTableInstanceData InstanceDataFirst;

        public ImVector_ImGuiTableInstanceData InstanceDataExtra;

        public ImGuiTableColumnSortSpecs SortSpecsSingle;

        public ImVector_ImGuiTableColumnSortSpecs SortSpecsMulti;

        public ImGuiTableSortSpecs SortSpecs;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short SortSpecsCount;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short ColumnsEnabledCount;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short ColumnsEnabledFixedCount;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short DeclColumnsCount;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short AngledHeadersCount;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short HoveredColumnBody;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short HoveredColumnBorder;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short HighlightColumnHeader;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short AutoFitSingleColumn;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short ResizedColumn;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short LastResizedColumn;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short HeldHeaderColumn;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short ReorderColumn;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short ReorderColumnDir;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short LeftMostEnabledColumn;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short RightMostEnabledColumn;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short LeftMostStretchedColumn;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short RightMostStretchedColumn;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short ContextPopupColumn;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short FreezeRowsRequest;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short FreezeRowsCount;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short FreezeColumnsRequest;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short FreezeColumnsCount;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short RowCellDataCurrent;

        [NativeTypeName("ImGuiTableDrawChannelIdx")]
        public ushort DummyDrawChannel;

        [NativeTypeName("ImGuiTableDrawChannelIdx")]
        public ushort Bg2DrawChannelCurrent;

        [NativeTypeName("ImGuiTableDrawChannelIdx")]
        public ushort Bg2DrawChannelUnfrozen;

        [NativeTypeName("ImS8")]
        public sbyte NavLayer;

        [NativeTypeName("_Bool")]
        public byte IsLayoutLocked;

        [NativeTypeName("_Bool")]
        public byte IsInsideRow;

        [NativeTypeName("_Bool")]
        public byte IsInitializing;

        [NativeTypeName("_Bool")]
        public byte IsSortSpecsDirty;

        [NativeTypeName("_Bool")]
        public byte IsUsingHeaders;

        [NativeTypeName("_Bool")]
        public byte IsContextPopupOpen;

        [NativeTypeName("_Bool")]
        public byte DisableDefaultContextMenu;

        [NativeTypeName("_Bool")]
        public byte IsSettingsRequestLoad;

        [NativeTypeName("_Bool")]
        public byte IsSettingsDirty;

        [NativeTypeName("_Bool")]
        public byte IsDefaultDisplayOrder;

        [NativeTypeName("_Bool")]
        public byte IsResetAllRequest;

        [NativeTypeName("_Bool")]
        public byte IsResetDisplayOrderRequest;

        [NativeTypeName("_Bool")]
        public byte IsUnfrozenRows;

        [NativeTypeName("_Bool")]
        public byte IsDefaultSizingPolicy;

        [NativeTypeName("_Bool")]
        public byte IsActiveIdAliveBeforeTable;

        [NativeTypeName("_Bool")]
        public byte IsActiveIdInTable;

        [NativeTypeName("_Bool")]
        public byte HasScrollbarYCurr;

        [NativeTypeName("_Bool")]
        public byte HasScrollbarYPrev;

        [NativeTypeName("_Bool")]
        public byte MemoryCompacted;

        [NativeTypeName("_Bool")]
        public byte HostSkipItems;

        [InlineArray(2)]
        public partial struct _RowBgColor_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public unsafe partial struct ImVector_ImGuiTableHeaderData
    {
        public int Size;

        public int Capacity;

        public ImGuiTableHeaderData* Data;
    }

    public partial struct ImGuiTableTempData
    {
        public int TableIndex;

        public float LastTimeActive;

        public float AngledHeadersExtraWidth;

        public ImVector_ImGuiTableHeaderData AngledHeadersRequests;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 UserOuterSize;

        public ImDrawListSplitter DrawSplitter;

        public ImRect HostBackupWorkRect;

        public ImRect HostBackupParentWorkRect;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 HostBackupPrevLineSize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 HostBackupCurrLineSize;

        [NativeTypeName("ImVec2")]
        public System.Numerics.Vector2 HostBackupCursorMaxPos;

        public ImVec1 HostBackupColumnsOffset;

        public float HostBackupItemWidth;

        public int HostBackupItemWidthStackSize;
    }

    public partial struct ImGuiTableColumnSettings
    {
        public float WidthOrWeight;

        [NativeTypeName("ImGuiID")]
        public uint UserID;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short Index;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short DisplayOrder;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short SortOrder;

        public byte _bitfield;

        [NativeTypeName("ImU8 : 2")]
        public byte SortDirection
        {
            readonly get
            {
                return (byte)(_bitfield & 0x3u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~0x3u) | (value & 0x3u));
            }
        }

        [NativeTypeName("ImS8 : 2")]
        public sbyte IsEnabled
        {
            readonly get
            {
                return (sbyte)((_bitfield << 4) >> 6);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~(0x3u << 2)) | (byte)((value & 0x3) << 2));
            }
        }

        [NativeTypeName("ImU8 : 1")]
        public byte IsStretch
        {
            readonly get
            {
                return (byte)((_bitfield >> 4) & 0x1u);
            }

            set
            {
                _bitfield = (byte)((_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4));
            }
        }
    }

    public partial struct ImGuiTableSettings
    {
        [NativeTypeName("ImGuiID")]
        public uint ID;

        [NativeTypeName("ImGuiTableFlags")]
        public int SaveFlags;

        public float RefScale;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short ColumnsCount;

        [NativeTypeName("ImGuiTableColumnIdx")]
        public short ColumnsCountMax;

        [NativeTypeName("_Bool")]
        public byte WantApply;
    }

    public unsafe partial struct ImFontLoader
    {
        [NativeTypeName("const char *")]
        public sbyte* Name;

        [NativeTypeName("_Bool (*)(ImFontAtlas *)")]
        public delegate* unmanaged[Cdecl]<ImFontAtlas*, byte> LoaderInit;

        [NativeTypeName("void (*)(ImFontAtlas *)")]
        public delegate* unmanaged[Cdecl]<ImFontAtlas*, void> LoaderShutdown;

        [NativeTypeName("_Bool (*)(ImFontAtlas *, ImFontConfig *)")]
        public delegate* unmanaged[Cdecl]<ImFontAtlas*, ImFontConfig*, byte> FontSrcInit;

        [NativeTypeName("void (*)(ImFontAtlas *, ImFontConfig *)")]
        public delegate* unmanaged[Cdecl]<ImFontAtlas*, ImFontConfig*, void> FontSrcDestroy;

        [NativeTypeName("_Bool (*)(ImFontAtlas *, ImFontConfig *, ImWchar)")]
        public delegate* unmanaged[Cdecl]<ImFontAtlas*, ImFontConfig*, ushort, byte> FontSrcContainsGlyph;

        [NativeTypeName("_Bool (*)(ImFontAtlas *, ImFontConfig *, ImFontBaked *, void *)")]
        public delegate* unmanaged[Cdecl]<ImFontAtlas*, ImFontConfig*, ImFontBaked*, void*, byte> FontBakedInit;

        [NativeTypeName("void (*)(ImFontAtlas *, ImFontConfig *, ImFontBaked *, void *)")]
        public delegate* unmanaged[Cdecl]<ImFontAtlas*, ImFontConfig*, ImFontBaked*, void*, void> FontBakedDestroy;

        [NativeTypeName("_Bool (*)(ImFontAtlas *, ImFontConfig *, ImFontBaked *, void *, ImWchar, ImFontGlyph *, float *)")]
        public delegate* unmanaged[Cdecl]<ImFontAtlas*, ImFontConfig*, ImFontBaked*, void*, ushort, ImFontGlyph*, float*, byte> FontBakedLoadGlyph;

        [NativeTypeName("size_t")]
        public nuint FontBakedSrcLoaderDataSize;
    }

    public partial struct ImFontAtlasRectEntry
    {
        public int _bitfield;

        [NativeTypeName("int : 20")]
        public int TargetIndex
        {
            readonly get
            {
                return (_bitfield << 12) >> 12;
            }

            set
            {
                _bitfield = (_bitfield & ~0xFFFFF) | (value & 0xFFFFF);
            }
        }

        [NativeTypeName("unsigned int : 10")]
        public uint Generation
        {
            readonly get
            {
                return (uint)((_bitfield >> 20) & 0x3FF);
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FF << 20)) | (int)((value & 0x3FFu) << 20);
            }
        }

        [NativeTypeName("unsigned int : 1")]
        public uint IsUsed
        {
            readonly get
            {
                return (uint)((_bitfield >> 30) & 0x1);
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1 << 30)) | (int)((value & 0x1u) << 30);
            }
        }
    }

    public unsafe partial struct ImFontAtlasPostProcessData
    {
        public ImFontAtlas* FontAtlas;

        public ImFont* Font;

        public ImFontConfig* FontSrc;

        public ImFontBaked* FontBaked;

        public ImFontGlyph* Glyph;

        public void* Pixels;

        public ImTextureFormat Format;

        public int Pitch;

        public int Width;

        public int Height;
    }

    public partial struct stbrp_context_opaque
    {
        [NativeTypeName("char[80]")]
        public _data_e__FixedBuffer data;

        [InlineArray(80)]
        public partial struct _data_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct ImVector_stbrp_node_im
    {
        public int Size;

        public int Capacity;

        [NativeTypeName("stbrp_node_im *")]
        public stbrp_node* Data;
    }

    public unsafe partial struct ImVector_ImFontAtlasRectEntry
    {
        public int Size;

        public int Capacity;

        public ImFontAtlasRectEntry* Data;
    }

    public unsafe partial struct ImVector_ImFontBakedPtr
    {
        public int Size;

        public int Capacity;

        public ImFontBaked** Data;
    }

    public partial struct ImStableVector_ImFontBaked__32
    {
        public int Size;

        public int Capacity;

        public ImVector_ImFontBakedPtr Blocks;
    }

    public partial struct ImFontAtlasBuilder
    {
        public stbrp_context_opaque PackContext;

        public ImVector_stbrp_node_im PackNodes;

        public ImVector_ImTextureRect Rects;

        public ImVector_ImFontAtlasRectEntry RectsIndex;

        public ImVector_unsigned_char TempBuffer;

        public int RectsIndexFreeListStart;

        public int RectsPackedCount;

        public int RectsPackedSurface;

        public int RectsDiscardedCount;

        public int RectsDiscardedSurface;

        public int FrameCount;

        public ImVec2i MaxRectSize;

        public ImVec2i MaxRectBounds;

        [NativeTypeName("_Bool")]
        public byte LockDisableResize;

        [NativeTypeName("_Bool")]
        public byte PreloadedAllGlyphsRanges;

        public ImStableVector_ImFontBaked__32 BakedPool;

        public ImGuiStorage BakedMap;

        public int BakedDiscardedCount;

        [NativeTypeName("ImFontAtlasRectId")]
        public int PackIdMouseCursors;

        [NativeTypeName("ImFontAtlasRectId")]
        public int PackIdLinesTexData;
    }

    public static unsafe partial class ImguiNative
    {
        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImVec2 *")]
        public static extern System.Numerics.Vector2* ImVec2_ImVec2_Nil();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImVec2_destroy([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImVec2 *")]
        public static extern System.Numerics.Vector2* ImVec2_ImVec2_Float(float _x, float _y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImVec4 *")]
        public static extern System.Numerics.Vector4* ImVec4_ImVec4_Nil();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImVec4_destroy([NativeTypeName("ImVec4 *")] System.Numerics.Vector4* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImVec4 *")]
        public static extern System.Numerics.Vector4* ImVec4_ImVec4_Float(float _x, float _y, float _z, float _w);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImTextureRef* ImTextureRef_ImTextureRef_Nil();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImTextureRef_destroy(ImTextureRef* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImTextureRef* ImTextureRef_ImTextureRef_TextureID([NativeTypeName("ImTextureID")] ulong tex_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImTextureID")]
        public static extern ulong ImTextureRef_GetTexID(ImTextureRef* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCreateContext", ExactSpelling = true)]
        public static extern ImGuiContext* CreateContext(ImFontAtlas* shared_font_atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDestroyContext", ExactSpelling = true)]
        public static extern void DestroyContext(ImGuiContext* ctx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCurrentContext", ExactSpelling = true)]
        public static extern ImGuiContext* GetCurrentContext();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetCurrentContext", ExactSpelling = true)]
        public static extern void SetCurrentContext(ImGuiContext* ctx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetIO_Nil", ExactSpelling = true)]
        public static extern ImGuiIO* GetIO_Nil();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetPlatformIO_Nil", ExactSpelling = true)]
        public static extern ImGuiPlatformIO* GetPlatformIO_Nil();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetStyle", ExactSpelling = true)]
        public static extern ImGuiStyle* GetStyle();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNewFrame", ExactSpelling = true)]
        public static extern void NewFrame();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndFrame", ExactSpelling = true)]
        public static extern void EndFrame();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRender", ExactSpelling = true)]
        public static extern void Render();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetDrawData", ExactSpelling = true)]
        public static extern ImDrawData* GetDrawData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShowDemoWindow", ExactSpelling = true)]
        public static extern void ShowDemoWindow([NativeTypeName("_Bool *")] bool* p_open);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShowMetricsWindow", ExactSpelling = true)]
        public static extern void ShowMetricsWindow([NativeTypeName("_Bool *")] bool* p_open);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShowDebugLogWindow", ExactSpelling = true)]
        public static extern void ShowDebugLogWindow([NativeTypeName("_Bool *")] bool* p_open);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShowIDStackToolWindow", ExactSpelling = true)]
        public static extern void ShowIDStackToolWindow([NativeTypeName("_Bool *")] bool* p_open);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShowAboutWindow", ExactSpelling = true)]
        public static extern void ShowAboutWindow([NativeTypeName("_Bool *")] bool* p_open);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShowStyleEditor", ExactSpelling = true)]
        public static extern void ShowStyleEditor(ImGuiStyle* @ref);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShowStyleSelector", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ShowStyleSelector([NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShowFontSelector", ExactSpelling = true)]
        public static extern void ShowFontSelector([NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShowUserGuide", ExactSpelling = true)]
        public static extern void ShowUserGuide();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetVersion", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetVersion();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igStyleColorsDark", ExactSpelling = true)]
        public static extern void StyleColorsDark(ImGuiStyle* dst);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igStyleColorsLight", ExactSpelling = true)]
        public static extern void StyleColorsLight(ImGuiStyle* dst);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igStyleColorsClassic", ExactSpelling = true)]
        public static extern void StyleColorsClassic(ImGuiStyle* dst);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBegin", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte Begin([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("_Bool *")] bool* p_open, [NativeTypeName("ImGuiWindowFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEnd", ExactSpelling = true)]
        public static extern void End();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginChild_Str", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginChild_Str([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, [NativeTypeName("ImGuiChildFlags")] int child_flags, [NativeTypeName("ImGuiWindowFlags")] int window_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginChild_ID", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginChild_ID([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, [NativeTypeName("ImGuiChildFlags")] int child_flags, [NativeTypeName("ImGuiWindowFlags")] int window_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndChild", ExactSpelling = true)]
        public static extern void EndChild();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsWindowAppearing", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsWindowAppearing();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsWindowCollapsed", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsWindowCollapsed();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsWindowFocused", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsWindowFocused([NativeTypeName("ImGuiFocusedFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsWindowHovered", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsWindowHovered([NativeTypeName("ImGuiHoveredFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowDrawList", ExactSpelling = true)]
        public static extern ImDrawList* GetWindowDrawList();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowDpiScale", ExactSpelling = true)]
        public static extern float GetWindowDpiScale();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowPos", ExactSpelling = true)]
        public static extern void GetWindowPos([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowSize", ExactSpelling = true)]
        public static extern void GetWindowSize([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowWidth", ExactSpelling = true)]
        public static extern float GetWindowWidth();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowHeight", ExactSpelling = true)]
        public static extern float GetWindowHeight();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowViewport", ExactSpelling = true)]
        public static extern ImGuiViewport* GetWindowViewport();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextWindowPos", ExactSpelling = true)]
        public static extern void SetNextWindowPos([NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("ImGuiCond")] int cond, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pivot);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextWindowSize", ExactSpelling = true)]
        public static extern void SetNextWindowSize([NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextWindowSizeConstraints", ExactSpelling = true)]
        public static extern void SetNextWindowSizeConstraints([NativeTypeName("const ImVec2")] System.Numerics.Vector2 size_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size_max, [NativeTypeName("ImGuiSizeCallback")] delegate* unmanaged[Cdecl]<ImGuiSizeCallbackData*, void> custom_callback, void* custom_callback_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextWindowContentSize", ExactSpelling = true)]
        public static extern void SetNextWindowContentSize([NativeTypeName("const ImVec2")] System.Numerics.Vector2 size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextWindowCollapsed", ExactSpelling = true)]
        public static extern void SetNextWindowCollapsed([NativeTypeName("_Bool")] byte collapsed, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextWindowFocus", ExactSpelling = true)]
        public static extern void SetNextWindowFocus();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextWindowScroll", ExactSpelling = true)]
        public static extern void SetNextWindowScroll([NativeTypeName("const ImVec2")] System.Numerics.Vector2 scroll);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextWindowBgAlpha", ExactSpelling = true)]
        public static extern void SetNextWindowBgAlpha(float alpha);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextWindowViewport", ExactSpelling = true)]
        public static extern void SetNextWindowViewport([NativeTypeName("ImGuiID")] uint viewport_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowPos_Vec2", ExactSpelling = true)]
        public static extern void SetWindowPos_Vec2([NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowSize_Vec2", ExactSpelling = true)]
        public static extern void SetWindowSize_Vec2([NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowCollapsed_Bool", ExactSpelling = true)]
        public static extern void SetWindowCollapsed_Bool([NativeTypeName("_Bool")] byte collapsed, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowFocus_Nil", ExactSpelling = true)]
        public static extern void SetWindowFocus_Nil();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowPos_Str", ExactSpelling = true)]
        public static extern void SetWindowPos_Str([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowSize_Str", ExactSpelling = true)]
        public static extern void SetWindowSize_Str([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowCollapsed_Str", ExactSpelling = true)]
        public static extern void SetWindowCollapsed_Str([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("_Bool")] byte collapsed, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowFocus_Str", ExactSpelling = true)]
        public static extern void SetWindowFocus_Str([NativeTypeName("const char *")] sbyte* name);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetScrollX", ExactSpelling = true)]
        public static extern float GetScrollX();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetScrollY", ExactSpelling = true)]
        public static extern float GetScrollY();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetScrollX_Float", ExactSpelling = true)]
        public static extern void SetScrollX_Float(float scroll_x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetScrollY_Float", ExactSpelling = true)]
        public static extern void SetScrollY_Float(float scroll_y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetScrollMaxX", ExactSpelling = true)]
        public static extern float GetScrollMaxX();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetScrollMaxY", ExactSpelling = true)]
        public static extern float GetScrollMaxY();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetScrollHereX", ExactSpelling = true)]
        public static extern void SetScrollHereX(float center_x_ratio);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetScrollHereY", ExactSpelling = true)]
        public static extern void SetScrollHereY(float center_y_ratio);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetScrollFromPosX_Float", ExactSpelling = true)]
        public static extern void SetScrollFromPosX_Float(float local_x, float center_x_ratio);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetScrollFromPosY_Float", ExactSpelling = true)]
        public static extern void SetScrollFromPosY_Float(float local_y, float center_y_ratio);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushFont", ExactSpelling = true)]
        public static extern void PushFont(ImFont* font, float font_size_base_unscaled);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPopFont", ExactSpelling = true)]
        public static extern void PopFont();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFont", ExactSpelling = true)]
        public static extern ImFont* GetFont();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFontSize", ExactSpelling = true)]
        public static extern float GetFontSize();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFontBaked", ExactSpelling = true)]
        public static extern ImFontBaked* GetFontBaked();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushStyleColor_U32", ExactSpelling = true)]
        public static extern void PushStyleColor_U32([NativeTypeName("ImGuiCol")] int idx, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushStyleColor_Vec4", ExactSpelling = true)]
        public static extern void PushStyleColor_Vec4([NativeTypeName("ImGuiCol")] int idx, [NativeTypeName("const ImVec4")] System.Numerics.Vector4 col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPopStyleColor", ExactSpelling = true)]
        public static extern void PopStyleColor(int count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushStyleVar_Float", ExactSpelling = true)]
        public static extern void PushStyleVar_Float([NativeTypeName("ImGuiStyleVar")] int idx, float val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushStyleVar_Vec2", ExactSpelling = true)]
        public static extern void PushStyleVar_Vec2([NativeTypeName("ImGuiStyleVar")] int idx, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushStyleVarX", ExactSpelling = true)]
        public static extern void PushStyleVarX([NativeTypeName("ImGuiStyleVar")] int idx, float val_x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushStyleVarY", ExactSpelling = true)]
        public static extern void PushStyleVarY([NativeTypeName("ImGuiStyleVar")] int idx, float val_y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPopStyleVar", ExactSpelling = true)]
        public static extern void PopStyleVar(int count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushItemFlag", ExactSpelling = true)]
        public static extern void PushItemFlag([NativeTypeName("ImGuiItemFlags")] int option, [NativeTypeName("_Bool")] byte enabled);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPopItemFlag", ExactSpelling = true)]
        public static extern void PopItemFlag();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushItemWidth", ExactSpelling = true)]
        public static extern void PushItemWidth(float item_width);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPopItemWidth", ExactSpelling = true)]
        public static extern void PopItemWidth();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextItemWidth", ExactSpelling = true)]
        public static extern void SetNextItemWidth(float item_width);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCalcItemWidth", ExactSpelling = true)]
        public static extern float CalcItemWidth();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushTextWrapPos", ExactSpelling = true)]
        public static extern void PushTextWrapPos(float wrap_local_pos_x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPopTextWrapPos", ExactSpelling = true)]
        public static extern void PopTextWrapPos();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFontTexUvWhitePixel", ExactSpelling = true)]
        public static extern void GetFontTexUvWhitePixel([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColorU32_Col", ExactSpelling = true)]
        [return: NativeTypeName("ImU32")]
        public static extern uint GetColorU32_Col([NativeTypeName("ImGuiCol")] int idx, float alpha_mul);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColorU32_Vec4", ExactSpelling = true)]
        [return: NativeTypeName("ImU32")]
        public static extern uint GetColorU32_Vec4([NativeTypeName("const ImVec4")] System.Numerics.Vector4 col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColorU32_U32", ExactSpelling = true)]
        [return: NativeTypeName("ImU32")]
        public static extern uint GetColorU32_U32([NativeTypeName("ImU32")] uint col, float alpha_mul);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetStyleColorVec4", ExactSpelling = true)]
        [return: NativeTypeName("const ImVec4 *")]
        public static extern System.Numerics.Vector4* GetStyleColorVec4([NativeTypeName("ImGuiCol")] int idx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCursorScreenPos", ExactSpelling = true)]
        public static extern void GetCursorScreenPos([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetCursorScreenPos", ExactSpelling = true)]
        public static extern void SetCursorScreenPos([NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetContentRegionAvail", ExactSpelling = true)]
        public static extern void GetContentRegionAvail([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCursorPos", ExactSpelling = true)]
        public static extern void GetCursorPos([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCursorPosX", ExactSpelling = true)]
        public static extern float GetCursorPosX();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCursorPosY", ExactSpelling = true)]
        public static extern float GetCursorPosY();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetCursorPos", ExactSpelling = true)]
        public static extern void SetCursorPos([NativeTypeName("const ImVec2")] System.Numerics.Vector2 local_pos);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetCursorPosX", ExactSpelling = true)]
        public static extern void SetCursorPosX(float local_x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetCursorPosY", ExactSpelling = true)]
        public static extern void SetCursorPosY(float local_y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCursorStartPos", ExactSpelling = true)]
        public static extern void GetCursorStartPos([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSeparator", ExactSpelling = true)]
        public static extern void Separator();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSameLine", ExactSpelling = true)]
        public static extern void SameLine(float offset_from_start_x, float spacing);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNewLine", ExactSpelling = true)]
        public static extern void NewLine();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSpacing", ExactSpelling = true)]
        public static extern void Spacing();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDummy", ExactSpelling = true)]
        public static extern void Dummy([NativeTypeName("const ImVec2")] System.Numerics.Vector2 size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIndent", ExactSpelling = true)]
        public static extern void Indent(float indent_w);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igUnindent", ExactSpelling = true)]
        public static extern void Unindent(float indent_w);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginGroup", ExactSpelling = true)]
        public static extern void BeginGroup();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndGroup", ExactSpelling = true)]
        public static extern void EndGroup();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igAlignTextToFramePadding", ExactSpelling = true)]
        public static extern void AlignTextToFramePadding();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetTextLineHeight", ExactSpelling = true)]
        public static extern float GetTextLineHeight();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetTextLineHeightWithSpacing", ExactSpelling = true)]
        public static extern float GetTextLineHeightWithSpacing();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFrameHeight", ExactSpelling = true)]
        public static extern float GetFrameHeight();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFrameHeightWithSpacing", ExactSpelling = true)]
        public static extern float GetFrameHeightWithSpacing();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushID_Str", ExactSpelling = true)]
        public static extern void PushID_Str([NativeTypeName("const char *")] sbyte* str_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushID_StrStr", ExactSpelling = true)]
        public static extern void PushID_StrStr([NativeTypeName("const char *")] sbyte* str_id_begin, [NativeTypeName("const char *")] sbyte* str_id_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushID_Ptr", ExactSpelling = true)]
        public static extern void PushID_Ptr([NativeTypeName("const void *")] void* ptr_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushID_Int", ExactSpelling = true)]
        public static extern void PushID_Int(int int_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPopID", ExactSpelling = true)]
        public static extern void PopID();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetID_Str", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetID_Str([NativeTypeName("const char *")] sbyte* str_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetID_StrStr", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetID_StrStr([NativeTypeName("const char *")] sbyte* str_id_begin, [NativeTypeName("const char *")] sbyte* str_id_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetID_Ptr", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetID_Ptr([NativeTypeName("const void *")] void* ptr_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetID_Int", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetID_Int(int int_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTextUnformatted", ExactSpelling = true)]
        public static extern void TextUnformatted([NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igText", ExactSpelling = true)]
        public static extern void Text([NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTextV", ExactSpelling = true)]
        public static extern void TextV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTextColored", ExactSpelling = true)]
        public static extern void TextColored([NativeTypeName("const ImVec4")] System.Numerics.Vector4 col, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTextColoredV", ExactSpelling = true)]
        public static extern void TextColoredV([NativeTypeName("const ImVec4")] System.Numerics.Vector4 col, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTextDisabled", ExactSpelling = true)]
        public static extern void TextDisabled([NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTextDisabledV", ExactSpelling = true)]
        public static extern void TextDisabledV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTextWrapped", ExactSpelling = true)]
        public static extern void TextWrapped([NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTextWrappedV", ExactSpelling = true)]
        public static extern void TextWrappedV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLabelText", ExactSpelling = true)]
        public static extern void LabelText([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLabelTextV", ExactSpelling = true)]
        public static extern void LabelTextV([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBulletText", ExactSpelling = true)]
        public static extern void BulletText([NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBulletTextV", ExactSpelling = true)]
        public static extern void BulletTextV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSeparatorText", ExactSpelling = true)]
        public static extern void SeparatorText([NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igButton", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte Button([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSmallButton", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SmallButton([NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInvisibleButton", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InvisibleButton([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, [NativeTypeName("ImGuiButtonFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igArrowButton", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ArrowButton([NativeTypeName("const char *")] sbyte* str_id, ImGuiDir dir);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCheckbox", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte Checkbox([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("_Bool *")] bool* v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCheckboxFlags_IntPtr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte CheckboxFlags_IntPtr([NativeTypeName("const char *")] sbyte* label, int* flags, int flags_value);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCheckboxFlags_UintPtr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte CheckboxFlags_UintPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("unsigned int *")] uint* flags, [NativeTypeName("unsigned int")] uint flags_value);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRadioButton_Bool", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte RadioButton_Bool([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("_Bool")] byte active);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRadioButton_IntPtr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte RadioButton_IntPtr([NativeTypeName("const char *")] sbyte* label, int* v, int v_button);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igProgressBar", ExactSpelling = true)]
        public static extern void ProgressBar(float fraction, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size_arg, [NativeTypeName("const char *")] sbyte* overlay);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBullet", ExactSpelling = true)]
        public static extern void Bullet();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTextLink", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TextLink([NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTextLinkOpenURL", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TextLinkOpenURL([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* url);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImage", ExactSpelling = true)]
        public static extern void Image(ImTextureRef tex_ref, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 image_size, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv0, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv1);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImageWithBg", ExactSpelling = true)]
        public static extern void ImageWithBg(ImTextureRef tex_ref, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 image_size, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv0, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv1, [NativeTypeName("const ImVec4")] System.Numerics.Vector4 bg_col, [NativeTypeName("const ImVec4")] System.Numerics.Vector4 tint_col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImageButton", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImageButton([NativeTypeName("const char *")] sbyte* str_id, ImTextureRef tex_ref, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 image_size, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv0, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv1, [NativeTypeName("const ImVec4")] System.Numerics.Vector4 bg_col, [NativeTypeName("const ImVec4")] System.Numerics.Vector4 tint_col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginCombo", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginCombo([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* preview_value, [NativeTypeName("ImGuiComboFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndCombo", ExactSpelling = true)]
        public static extern void EndCombo();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCombo_Str_arr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte Combo_Str_arr([NativeTypeName("const char *")] sbyte* label, int* current_item, [NativeTypeName("const char *const[]")] sbyte** items, int items_count, int popup_max_height_in_items);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCombo_Str", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte Combo_Str([NativeTypeName("const char *")] sbyte* label, int* current_item, [NativeTypeName("const char *")] sbyte* items_separated_by_zeros, int popup_max_height_in_items);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCombo_FnStrPtr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte Combo_FnStrPtr([NativeTypeName("const char *")] sbyte* label, int* current_item, [NativeTypeName("const char *(*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, sbyte*> getter, void* user_data, int items_count, int popup_max_height_in_items);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragFloat", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DragFloat([NativeTypeName("const char *")] sbyte* label, float* v, float v_speed, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragFloat2", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DragFloat2([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[2]")] float* v, float v_speed, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragFloat3", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DragFloat3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[3]")] float* v, float v_speed, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragFloat4", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DragFloat4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[4]")] float* v, float v_speed, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragFloatRange2", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DragFloatRange2([NativeTypeName("const char *")] sbyte* label, float* v_current_min, float* v_current_max, float v_speed, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("const char *")] sbyte* format_max, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragInt", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DragInt([NativeTypeName("const char *")] sbyte* label, int* v, float v_speed, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragInt2", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DragInt2([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[2]")] int* v, float v_speed, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragInt3", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DragInt3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[3]")] int* v, float v_speed, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragInt4", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DragInt4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[4]")] int* v, float v_speed, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragIntRange2", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DragIntRange2([NativeTypeName("const char *")] sbyte* label, int* v_current_min, int* v_current_max, float v_speed, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("const char *")] sbyte* format_max, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragScalar", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DragScalar([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, float v_speed, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragScalarN", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DragScalarN([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, int components, float v_speed, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSliderFloat", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SliderFloat([NativeTypeName("const char *")] sbyte* label, float* v, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSliderFloat2", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SliderFloat2([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[2]")] float* v, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSliderFloat3", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SliderFloat3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[3]")] float* v, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSliderFloat4", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SliderFloat4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[4]")] float* v, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSliderAngle", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SliderAngle([NativeTypeName("const char *")] sbyte* label, float* v_rad, float v_degrees_min, float v_degrees_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSliderInt", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SliderInt([NativeTypeName("const char *")] sbyte* label, int* v, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSliderInt2", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SliderInt2([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[2]")] int* v, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSliderInt3", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SliderInt3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[3]")] int* v, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSliderInt4", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SliderInt4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[4]")] int* v, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSliderScalar", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SliderScalar([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSliderScalarN", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SliderScalarN([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, int components, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igVSliderFloat", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte VSliderFloat([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, float* v, float v_min, float v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igVSliderInt", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte VSliderInt([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, int* v, int v_min, int v_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igVSliderScalar", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte VSliderScalar([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputText", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputText([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("char *")] sbyte* buf, [NativeTypeName("size_t")] nuint buf_size, [NativeTypeName("ImGuiInputTextFlags")] int flags, [NativeTypeName("ImGuiInputTextCallback")] delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback, void* user_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputTextMultiline", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputTextMultiline([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("char *")] sbyte* buf, [NativeTypeName("size_t")] nuint buf_size, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, [NativeTypeName("ImGuiInputTextFlags")] int flags, [NativeTypeName("ImGuiInputTextCallback")] delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback, void* user_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputTextWithHint", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputTextWithHint([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* hint, [NativeTypeName("char *")] sbyte* buf, [NativeTypeName("size_t")] nuint buf_size, [NativeTypeName("ImGuiInputTextFlags")] int flags, [NativeTypeName("ImGuiInputTextCallback")] delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback, void* user_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputFloat", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputFloat([NativeTypeName("const char *")] sbyte* label, float* v, float step, float step_fast, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputFloat2", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputFloat2([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[2]")] float* v, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputFloat3", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputFloat3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[3]")] float* v, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputFloat4", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputFloat4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[4]")] float* v, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputInt", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputInt([NativeTypeName("const char *")] sbyte* label, int* v, int step, int step_fast, [NativeTypeName("ImGuiInputTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputInt2", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputInt2([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[2]")] int* v, [NativeTypeName("ImGuiInputTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputInt3", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputInt3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[3]")] int* v, [NativeTypeName("ImGuiInputTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputInt4", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputInt4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("int[4]")] int* v, [NativeTypeName("ImGuiInputTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputDouble", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputDouble([NativeTypeName("const char *")] sbyte* label, double* v, double step, double step_fast, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputScalar", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputScalar([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, [NativeTypeName("const void *")] void* p_step, [NativeTypeName("const void *")] void* p_step_fast, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputScalarN", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputScalarN([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, int components, [NativeTypeName("const void *")] void* p_step, [NativeTypeName("const void *")] void* p_step_fast, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiInputTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorEdit3", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ColorEdit3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[3]")] float* col, [NativeTypeName("ImGuiColorEditFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorEdit4", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ColorEdit4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[4]")] float* col, [NativeTypeName("ImGuiColorEditFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorPicker3", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ColorPicker3([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[3]")] float* col, [NativeTypeName("ImGuiColorEditFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorPicker4", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ColorPicker4([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float[4]")] float* col, [NativeTypeName("ImGuiColorEditFlags")] int flags, [NativeTypeName("const float *")] float* ref_col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorButton", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ColorButton([NativeTypeName("const char *")] sbyte* desc_id, [NativeTypeName("const ImVec4")] System.Numerics.Vector4 col, [NativeTypeName("ImGuiColorEditFlags")] int flags, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetColorEditOptions", ExactSpelling = true)]
        public static extern void SetColorEditOptions([NativeTypeName("ImGuiColorEditFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNode_Str", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TreeNode_Str([NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNode_StrStr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TreeNode_StrStr([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNode_Ptr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TreeNode_Ptr([NativeTypeName("const void *")] void* ptr_id, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNodeV_Str", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TreeNodeV_Str([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNodeV_Ptr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TreeNodeV_Ptr([NativeTypeName("const void *")] void* ptr_id, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNodeEx_Str", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TreeNodeEx_Str([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiTreeNodeFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNodeEx_StrStr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TreeNodeEx_StrStr([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiTreeNodeFlags")] int flags, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNodeEx_Ptr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TreeNodeEx_Ptr([NativeTypeName("const void *")] void* ptr_id, [NativeTypeName("ImGuiTreeNodeFlags")] int flags, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNodeExV_Str", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TreeNodeExV_Str([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiTreeNodeFlags")] int flags, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNodeExV_Ptr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TreeNodeExV_Ptr([NativeTypeName("const void *")] void* ptr_id, [NativeTypeName("ImGuiTreeNodeFlags")] int flags, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreePush_Str", ExactSpelling = true)]
        public static extern void TreePush_Str([NativeTypeName("const char *")] sbyte* str_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreePush_Ptr", ExactSpelling = true)]
        public static extern void TreePush_Ptr([NativeTypeName("const void *")] void* ptr_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreePop", ExactSpelling = true)]
        public static extern void TreePop();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetTreeNodeToLabelSpacing", ExactSpelling = true)]
        public static extern float GetTreeNodeToLabelSpacing();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCollapsingHeader_TreeNodeFlags", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte CollapsingHeader_TreeNodeFlags([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiTreeNodeFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCollapsingHeader_BoolPtr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte CollapsingHeader_BoolPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("_Bool *")] bool* p_visible, [NativeTypeName("ImGuiTreeNodeFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextItemOpen", ExactSpelling = true)]
        public static extern void SetNextItemOpen([NativeTypeName("_Bool")] byte is_open, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextItemStorageID", ExactSpelling = true)]
        public static extern void SetNextItemStorageID([NativeTypeName("ImGuiID")] uint storage_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSelectable_Bool", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte Selectable_Bool([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("_Bool")] byte selected, [NativeTypeName("ImGuiSelectableFlags")] int flags, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSelectable_BoolPtr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte Selectable_BoolPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("_Bool *")] bool* p_selected, [NativeTypeName("ImGuiSelectableFlags")] int flags, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginMultiSelect", ExactSpelling = true)]
        public static extern ImGuiMultiSelectIO* BeginMultiSelect([NativeTypeName("ImGuiMultiSelectFlags")] int flags, int selection_size, int items_count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndMultiSelect", ExactSpelling = true)]
        public static extern ImGuiMultiSelectIO* EndMultiSelect();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextItemSelectionUserData", ExactSpelling = true)]
        public static extern void SetNextItemSelectionUserData([NativeTypeName("ImGuiSelectionUserData")] long selection_user_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsItemToggledSelection", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsItemToggledSelection();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginListBox", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginListBox([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndListBox", ExactSpelling = true)]
        public static extern void EndListBox();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igListBox_Str_arr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ListBox_Str_arr([NativeTypeName("const char *")] sbyte* label, int* current_item, [NativeTypeName("const char *const[]")] sbyte** items, int items_count, int height_in_items);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igListBox_FnStrPtr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ListBox_FnStrPtr([NativeTypeName("const char *")] sbyte* label, int* current_item, [NativeTypeName("const char *(*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, sbyte*> getter, void* user_data, int items_count, int height_in_items);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPlotLines_FloatPtr", ExactSpelling = true)]
        public static extern void PlotLines_FloatPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const float *")] float* values, int values_count, int values_offset, [NativeTypeName("const char *")] sbyte* overlay_text, float scale_min, float scale_max, [NativeTypeName("ImVec2")] System.Numerics.Vector2 graph_size, int stride);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPlotLines_FnFloatPtr", ExactSpelling = true)]
        public static extern void PlotLines_FnFloatPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float (*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, float> values_getter, void* data, int values_count, int values_offset, [NativeTypeName("const char *")] sbyte* overlay_text, float scale_min, float scale_max, [NativeTypeName("ImVec2")] System.Numerics.Vector2 graph_size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPlotHistogram_FloatPtr", ExactSpelling = true)]
        public static extern void PlotHistogram_FloatPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const float *")] float* values, int values_count, int values_offset, [NativeTypeName("const char *")] sbyte* overlay_text, float scale_min, float scale_max, [NativeTypeName("ImVec2")] System.Numerics.Vector2 graph_size, int stride);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPlotHistogram_FnFloatPtr", ExactSpelling = true)]
        public static extern void PlotHistogram_FnFloatPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float (*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, float> values_getter, void* data, int values_count, int values_offset, [NativeTypeName("const char *")] sbyte* overlay_text, float scale_min, float scale_max, [NativeTypeName("ImVec2")] System.Numerics.Vector2 graph_size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igValue_Bool", ExactSpelling = true)]
        public static extern void Value_Bool([NativeTypeName("const char *")] sbyte* prefix, [NativeTypeName("_Bool")] byte b);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igValue_Int", ExactSpelling = true)]
        public static extern void Value_Int([NativeTypeName("const char *")] sbyte* prefix, int v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igValue_Uint", ExactSpelling = true)]
        public static extern void Value_Uint([NativeTypeName("const char *")] sbyte* prefix, [NativeTypeName("unsigned int")] uint v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igValue_Float", ExactSpelling = true)]
        public static extern void Value_Float([NativeTypeName("const char *")] sbyte* prefix, float v, [NativeTypeName("const char *")] sbyte* float_format);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginMenuBar", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginMenuBar();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndMenuBar", ExactSpelling = true)]
        public static extern void EndMenuBar();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginMainMenuBar", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginMainMenuBar();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndMainMenuBar", ExactSpelling = true)]
        public static extern void EndMainMenuBar();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginMenu", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginMenu([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("_Bool")] byte enabled);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndMenu", ExactSpelling = true)]
        public static extern void EndMenu();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igMenuItem_Bool", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte MenuItem_Bool([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* shortcut, [NativeTypeName("_Bool")] byte selected, [NativeTypeName("_Bool")] byte enabled);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igMenuItem_BoolPtr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte MenuItem_BoolPtr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* shortcut, [NativeTypeName("_Bool *")] bool* p_selected, [NativeTypeName("_Bool")] byte enabled);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginTooltip", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginTooltip();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndTooltip", ExactSpelling = true)]
        public static extern void EndTooltip();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetTooltip", ExactSpelling = true)]
        public static extern void SetTooltip([NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetTooltipV", ExactSpelling = true)]
        public static extern void SetTooltipV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginItemTooltip", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginItemTooltip();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetItemTooltip", ExactSpelling = true)]
        public static extern void SetItemTooltip([NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetItemTooltipV", ExactSpelling = true)]
        public static extern void SetItemTooltipV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginPopup", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginPopup([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiWindowFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginPopupModal", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginPopupModal([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("_Bool *")] bool* p_open, [NativeTypeName("ImGuiWindowFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndPopup", ExactSpelling = true)]
        public static extern void EndPopup();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igOpenPopup_Str", ExactSpelling = true)]
        public static extern void OpenPopup_Str([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igOpenPopup_ID", ExactSpelling = true)]
        public static extern void OpenPopup_ID([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igOpenPopupOnItemClick", ExactSpelling = true)]
        public static extern void OpenPopupOnItemClick([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCloseCurrentPopup", ExactSpelling = true)]
        public static extern void CloseCurrentPopup();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginPopupContextItem", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginPopupContextItem([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginPopupContextWindow", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginPopupContextWindow([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginPopupContextVoid", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginPopupContextVoid([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsPopupOpen_Str", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsPopupOpen_Str([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiPopupFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginTable", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginTable([NativeTypeName("const char *")] sbyte* str_id, int columns, [NativeTypeName("ImGuiTableFlags")] int flags, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 outer_size, float inner_width);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndTable", ExactSpelling = true)]
        public static extern void EndTable();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableNextRow", ExactSpelling = true)]
        public static extern void TableNextRow([NativeTypeName("ImGuiTableRowFlags")] int row_flags, float min_row_height);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableNextColumn", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TableNextColumn();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSetColumnIndex", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TableSetColumnIndex(int column_n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSetupColumn", ExactSpelling = true)]
        public static extern void TableSetupColumn([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiTableColumnFlags")] int flags, float init_width_or_weight, [NativeTypeName("ImGuiID")] uint user_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSetupScrollFreeze", ExactSpelling = true)]
        public static extern void TableSetupScrollFreeze(int cols, int rows);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableHeader", ExactSpelling = true)]
        public static extern void TableHeader([NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableHeadersRow", ExactSpelling = true)]
        public static extern void TableHeadersRow();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableAngledHeadersRow", ExactSpelling = true)]
        public static extern void TableAngledHeadersRow();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetSortSpecs", ExactSpelling = true)]
        public static extern ImGuiTableSortSpecs* TableGetSortSpecs();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetColumnCount", ExactSpelling = true)]
        public static extern int TableGetColumnCount();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetColumnIndex", ExactSpelling = true)]
        public static extern int TableGetColumnIndex();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetRowIndex", ExactSpelling = true)]
        public static extern int TableGetRowIndex();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetColumnName_Int", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* TableGetColumnName_Int(int column_n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetColumnFlags", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiTableColumnFlags")]
        public static extern int TableGetColumnFlags(int column_n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSetColumnEnabled", ExactSpelling = true)]
        public static extern void TableSetColumnEnabled(int column_n, [NativeTypeName("_Bool")] byte v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetHoveredColumn", ExactSpelling = true)]
        public static extern int TableGetHoveredColumn();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSetBgColor", ExactSpelling = true)]
        public static extern void TableSetBgColor([NativeTypeName("ImGuiTableBgTarget")] int target, [NativeTypeName("ImU32")] uint color, int column_n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColumns", ExactSpelling = true)]
        public static extern void Columns(int count, [NativeTypeName("const char *")] sbyte* id, [NativeTypeName("_Bool")] byte borders);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNextColumn", ExactSpelling = true)]
        public static extern void NextColumn();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColumnIndex", ExactSpelling = true)]
        public static extern int GetColumnIndex();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColumnWidth", ExactSpelling = true)]
        public static extern float GetColumnWidth(int column_index);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetColumnWidth", ExactSpelling = true)]
        public static extern void SetColumnWidth(int column_index, float width);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColumnOffset", ExactSpelling = true)]
        public static extern float GetColumnOffset(int column_index);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetColumnOffset", ExactSpelling = true)]
        public static extern void SetColumnOffset(int column_index, float offset_x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColumnsCount", ExactSpelling = true)]
        public static extern int GetColumnsCount();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginTabBar", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginTabBar([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiTabBarFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndTabBar", ExactSpelling = true)]
        public static extern void EndTabBar();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginTabItem", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginTabItem([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("_Bool *")] bool* p_open, [NativeTypeName("ImGuiTabItemFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndTabItem", ExactSpelling = true)]
        public static extern void EndTabItem();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabItemButton", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TabItemButton([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiTabItemFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetTabItemClosed", ExactSpelling = true)]
        public static extern void SetTabItemClosed([NativeTypeName("const char *")] sbyte* tab_or_docked_window_label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockSpace", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint DockSpace([NativeTypeName("ImGuiID")] uint dockspace_id, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, [NativeTypeName("ImGuiDockNodeFlags")] int flags, [NativeTypeName("const ImGuiWindowClass *")] ImGuiWindowClass* window_class);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockSpaceOverViewport", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint DockSpaceOverViewport([NativeTypeName("ImGuiID")] uint dockspace_id, [NativeTypeName("const ImGuiViewport *")] ImGuiViewport* viewport, [NativeTypeName("ImGuiDockNodeFlags")] int flags, [NativeTypeName("const ImGuiWindowClass *")] ImGuiWindowClass* window_class);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextWindowDockID", ExactSpelling = true)]
        public static extern void SetNextWindowDockID([NativeTypeName("ImGuiID")] uint dock_id, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextWindowClass", ExactSpelling = true)]
        public static extern void SetNextWindowClass([NativeTypeName("const ImGuiWindowClass *")] ImGuiWindowClass* window_class);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowDockID", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetWindowDockID();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsWindowDocked", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsWindowDocked();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLogToTTY", ExactSpelling = true)]
        public static extern void LogToTTY(int auto_open_depth);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLogToFile", ExactSpelling = true)]
        public static extern void LogToFile(int auto_open_depth, [NativeTypeName("const char *")] sbyte* filename);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLogToClipboard", ExactSpelling = true)]
        public static extern void LogToClipboard(int auto_open_depth);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLogFinish", ExactSpelling = true)]
        public static extern void LogFinish();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLogButtons", ExactSpelling = true)]
        public static extern void LogButtons();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLogText", ExactSpelling = true)]
        public static extern void LogText([NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLogTextV", ExactSpelling = true)]
        public static extern void LogTextV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginDragDropSource", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginDragDropSource([NativeTypeName("ImGuiDragDropFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetDragDropPayload", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SetDragDropPayload([NativeTypeName("const char *")] sbyte* type, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint sz, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndDragDropSource", ExactSpelling = true)]
        public static extern void EndDragDropSource();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginDragDropTarget", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginDragDropTarget();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igAcceptDragDropPayload", ExactSpelling = true)]
        [return: NativeTypeName("const ImGuiPayload *")]
        public static extern ImGuiPayload* AcceptDragDropPayload([NativeTypeName("const char *")] sbyte* type, [NativeTypeName("ImGuiDragDropFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndDragDropTarget", ExactSpelling = true)]
        public static extern void EndDragDropTarget();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetDragDropPayload", ExactSpelling = true)]
        [return: NativeTypeName("const ImGuiPayload *")]
        public static extern ImGuiPayload* GetDragDropPayload();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginDisabled", ExactSpelling = true)]
        public static extern void BeginDisabled([NativeTypeName("_Bool")] byte disabled);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndDisabled", ExactSpelling = true)]
        public static extern void EndDisabled();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushClipRect", ExactSpelling = true)]
        public static extern void PushClipRect([NativeTypeName("const ImVec2")] System.Numerics.Vector2 clip_rect_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 clip_rect_max, [NativeTypeName("_Bool")] byte intersect_with_current_clip_rect);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPopClipRect", ExactSpelling = true)]
        public static extern void PopClipRect();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetItemDefaultFocus", ExactSpelling = true)]
        public static extern void SetItemDefaultFocus();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetKeyboardFocusHere", ExactSpelling = true)]
        public static extern void SetKeyboardFocusHere(int offset);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNavCursorVisible", ExactSpelling = true)]
        public static extern void SetNavCursorVisible([NativeTypeName("_Bool")] byte visible);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextItemAllowOverlap", ExactSpelling = true)]
        public static extern void SetNextItemAllowOverlap();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsItemHovered", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsItemHovered([NativeTypeName("ImGuiHoveredFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsItemActive", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsItemActive();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsItemFocused", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsItemFocused();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsItemClicked", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsItemClicked([NativeTypeName("ImGuiMouseButton")] int mouse_button);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsItemVisible", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsItemVisible();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsItemEdited", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsItemEdited();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsItemActivated", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsItemActivated();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsItemDeactivated", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsItemDeactivated();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsItemDeactivatedAfterEdit", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsItemDeactivatedAfterEdit();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsItemToggledOpen", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsItemToggledOpen();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsAnyItemHovered", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsAnyItemHovered();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsAnyItemActive", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsAnyItemActive();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsAnyItemFocused", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsAnyItemFocused();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetItemID", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetItemID();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetItemRectMin", ExactSpelling = true)]
        public static extern void GetItemRectMin([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetItemRectMax", ExactSpelling = true)]
        public static extern void GetItemRectMax([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetItemRectSize", ExactSpelling = true)]
        public static extern void GetItemRectSize([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetMainViewport", ExactSpelling = true)]
        public static extern ImGuiViewport* GetMainViewport();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetBackgroundDrawList", ExactSpelling = true)]
        public static extern ImDrawList* GetBackgroundDrawList(ImGuiViewport* viewport);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetForegroundDrawList_ViewportPtr", ExactSpelling = true)]
        public static extern ImDrawList* GetForegroundDrawList_ViewportPtr(ImGuiViewport* viewport);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsRectVisible_Nil", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsRectVisible_Nil([NativeTypeName("const ImVec2")] System.Numerics.Vector2 size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsRectVisible_Vec2", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsRectVisible_Vec2([NativeTypeName("const ImVec2")] System.Numerics.Vector2 rect_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 rect_max);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetTime", ExactSpelling = true)]
        public static extern double GetTime();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFrameCount", ExactSpelling = true)]
        public static extern int GetFrameCount();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetDrawListSharedData", ExactSpelling = true)]
        public static extern ImDrawListSharedData* GetDrawListSharedData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetStyleColorName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetStyleColorName([NativeTypeName("ImGuiCol")] int idx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetStateStorage", ExactSpelling = true)]
        public static extern void SetStateStorage(ImGuiStorage* storage);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetStateStorage", ExactSpelling = true)]
        public static extern ImGuiStorage* GetStateStorage();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCalcTextSize", ExactSpelling = true)]
        public static extern void CalcTextSize([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("_Bool")] byte hide_text_after_double_hash, float wrap_width);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorConvertU32ToFloat4", ExactSpelling = true)]
        public static extern void ColorConvertU32ToFloat4([NativeTypeName("ImVec4 *")] System.Numerics.Vector4* pOut, [NativeTypeName("ImU32")] uint @in);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorConvertFloat4ToU32", ExactSpelling = true)]
        [return: NativeTypeName("ImU32")]
        public static extern uint ColorConvertFloat4ToU32([NativeTypeName("const ImVec4")] System.Numerics.Vector4 @in);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorConvertRGBtoHSV", ExactSpelling = true)]
        public static extern void ColorConvertRGBtoHSV(float r, float g, float b, float* out_h, float* out_s, float* out_v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorConvertHSVtoRGB", ExactSpelling = true)]
        public static extern void ColorConvertHSVtoRGB(float h, float s, float v, float* out_r, float* out_g, float* out_b);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsKeyDown_Nil", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsKeyDown_Nil(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsKeyPressed_Bool", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsKeyPressed_Bool(ImGuiKey key, [NativeTypeName("_Bool")] byte repeat);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsKeyReleased_Nil", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsKeyReleased_Nil(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsKeyChordPressed_Nil", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsKeyChordPressed_Nil([NativeTypeName("ImGuiKeyChord")] int key_chord);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetKeyPressedAmount", ExactSpelling = true)]
        public static extern int GetKeyPressedAmount(ImGuiKey key, float repeat_delay, float rate);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetKeyName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetKeyName(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextFrameWantCaptureKeyboard", ExactSpelling = true)]
        public static extern void SetNextFrameWantCaptureKeyboard([NativeTypeName("_Bool")] byte want_capture_keyboard);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShortcut_Nil", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte Shortcut_Nil([NativeTypeName("ImGuiKeyChord")] int key_chord, [NativeTypeName("ImGuiInputFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextItemShortcut", ExactSpelling = true)]
        public static extern void SetNextItemShortcut([NativeTypeName("ImGuiKeyChord")] int key_chord, [NativeTypeName("ImGuiInputFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetItemKeyOwner_Nil", ExactSpelling = true)]
        public static extern void SetItemKeyOwner_Nil(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMouseDown_Nil", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMouseDown_Nil([NativeTypeName("ImGuiMouseButton")] int button);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMouseClicked_Bool", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMouseClicked_Bool([NativeTypeName("ImGuiMouseButton")] int button, [NativeTypeName("_Bool")] byte repeat);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMouseReleased_Nil", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMouseReleased_Nil([NativeTypeName("ImGuiMouseButton")] int button);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMouseDoubleClicked_Nil", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMouseDoubleClicked_Nil([NativeTypeName("ImGuiMouseButton")] int button);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMouseReleasedWithDelay", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMouseReleasedWithDelay([NativeTypeName("ImGuiMouseButton")] int button, float delay);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetMouseClickedCount", ExactSpelling = true)]
        public static extern int GetMouseClickedCount([NativeTypeName("ImGuiMouseButton")] int button);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMouseHoveringRect", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMouseHoveringRect([NativeTypeName("const ImVec2")] System.Numerics.Vector2 r_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 r_max, [NativeTypeName("_Bool")] byte clip);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMousePosValid", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMousePosValid([NativeTypeName("const ImVec2 *")] System.Numerics.Vector2* mouse_pos);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsAnyMouseDown", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsAnyMouseDown();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetMousePos", ExactSpelling = true)]
        public static extern void GetMousePos([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetMousePosOnOpeningCurrentPopup", ExactSpelling = true)]
        public static extern void GetMousePosOnOpeningCurrentPopup([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMouseDragging", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMouseDragging([NativeTypeName("ImGuiMouseButton")] int button, float lock_threshold);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetMouseDragDelta", ExactSpelling = true)]
        public static extern void GetMouseDragDelta([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("ImGuiMouseButton")] int button, float lock_threshold);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igResetMouseDragDelta", ExactSpelling = true)]
        public static extern void ResetMouseDragDelta([NativeTypeName("ImGuiMouseButton")] int button);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetMouseCursor", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiMouseCursor")]
        public static extern int GetMouseCursor();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetMouseCursor", ExactSpelling = true)]
        public static extern void SetMouseCursor([NativeTypeName("ImGuiMouseCursor")] int cursor_type);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextFrameWantCaptureMouse", ExactSpelling = true)]
        public static extern void SetNextFrameWantCaptureMouse([NativeTypeName("_Bool")] byte want_capture_mouse);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetClipboardText", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetClipboardText();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetClipboardText", ExactSpelling = true)]
        public static extern void SetClipboardText([NativeTypeName("const char *")] sbyte* text);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLoadIniSettingsFromDisk", ExactSpelling = true)]
        public static extern void LoadIniSettingsFromDisk([NativeTypeName("const char *")] sbyte* ini_filename);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLoadIniSettingsFromMemory", ExactSpelling = true)]
        public static extern void LoadIniSettingsFromMemory([NativeTypeName("const char *")] sbyte* ini_data, [NativeTypeName("size_t")] nuint ini_size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSaveIniSettingsToDisk", ExactSpelling = true)]
        public static extern void SaveIniSettingsToDisk([NativeTypeName("const char *")] sbyte* ini_filename);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSaveIniSettingsToMemory", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* SaveIniSettingsToMemory([NativeTypeName("size_t *")] nuint* out_ini_size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugTextEncoding", ExactSpelling = true)]
        public static extern void DebugTextEncoding([NativeTypeName("const char *")] sbyte* text);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugFlashStyleColor", ExactSpelling = true)]
        public static extern void DebugFlashStyleColor([NativeTypeName("ImGuiCol")] int idx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugStartItemPicker", ExactSpelling = true)]
        public static extern void DebugStartItemPicker();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugCheckVersionAndDataLayout", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DebugCheckVersionAndDataLayout([NativeTypeName("const char *")] sbyte* version_str, [NativeTypeName("size_t")] nuint sz_io, [NativeTypeName("size_t")] nuint sz_style, [NativeTypeName("size_t")] nuint sz_vec2, [NativeTypeName("size_t")] nuint sz_vec4, [NativeTypeName("size_t")] nuint sz_drawvert, [NativeTypeName("size_t")] nuint sz_drawidx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugLog", ExactSpelling = true)]
        public static extern void DebugLog([NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugLogV", ExactSpelling = true)]
        public static extern void DebugLogV([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetAllocatorFunctions", ExactSpelling = true)]
        public static extern void SetAllocatorFunctions([NativeTypeName("ImGuiMemAllocFunc")] delegate* unmanaged[Cdecl]<nuint, void*, void*> alloc_func, [NativeTypeName("ImGuiMemFreeFunc")] delegate* unmanaged[Cdecl]<void*, void*, void> free_func, void* user_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetAllocatorFunctions", ExactSpelling = true)]
        public static extern void GetAllocatorFunctions([NativeTypeName("ImGuiMemAllocFunc *")] delegate* unmanaged[Cdecl]<nuint, void*, void*>* p_alloc_func, [NativeTypeName("ImGuiMemFreeFunc *")] delegate* unmanaged[Cdecl]<void*, void*, void>* p_free_func, void** p_user_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igMemAlloc", ExactSpelling = true)]
        public static extern void* MemAlloc([NativeTypeName("size_t")] nuint size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igMemFree", ExactSpelling = true)]
        public static extern void MemFree(void* ptr);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igUpdatePlatformWindows", ExactSpelling = true)]
        public static extern void UpdatePlatformWindows();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderPlatformWindowsDefault", ExactSpelling = true)]
        public static extern void RenderPlatformWindowsDefault(void* platform_render_arg, void* renderer_render_arg);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDestroyPlatformWindows", ExactSpelling = true)]
        public static extern void DestroyPlatformWindows();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindViewportByID", ExactSpelling = true)]
        public static extern ImGuiViewport* FindViewportByID([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindViewportByPlatformHandle", ExactSpelling = true)]
        public static extern ImGuiViewport* FindViewportByPlatformHandle(void* platform_handle);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTableSortSpecs* ImGuiTableSortSpecs_ImGuiTableSortSpecs();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTableSortSpecs_destroy(ImGuiTableSortSpecs* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTableColumnSortSpecs* ImGuiTableColumnSortSpecs_ImGuiTableColumnSortSpecs();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTableColumnSortSpecs_destroy(ImGuiTableColumnSortSpecs* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiStyle* ImGuiStyle_ImGuiStyle();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiStyle_destroy(ImGuiStyle* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiStyle_ScaleAllSizes(ImGuiStyle* self, float scale_factor);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_AddKeyEvent(ImGuiIO* self, ImGuiKey key, [NativeTypeName("_Bool")] byte down);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_AddKeyAnalogEvent(ImGuiIO* self, ImGuiKey key, [NativeTypeName("_Bool")] byte down, float v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_AddMousePosEvent(ImGuiIO* self, float x, float y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_AddMouseButtonEvent(ImGuiIO* self, int button, [NativeTypeName("_Bool")] byte down);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_AddMouseWheelEvent(ImGuiIO* self, float wheel_x, float wheel_y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_AddMouseSourceEvent(ImGuiIO* self, ImGuiMouseSource source);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_AddMouseViewportEvent(ImGuiIO* self, [NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_AddFocusEvent(ImGuiIO* self, [NativeTypeName("_Bool")] byte focused);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_AddInputCharacter(ImGuiIO* self, [NativeTypeName("unsigned int")] uint c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_AddInputCharacterUTF16(ImGuiIO* self, [NativeTypeName("ImWchar16")] ushort c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_AddInputCharactersUTF8(ImGuiIO* self, [NativeTypeName("const char *")] sbyte* str);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_SetKeyEventNativeData(ImGuiIO* self, ImGuiKey key, int native_keycode, int native_scancode, int native_legacy_index);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_SetAppAcceptingEvents(ImGuiIO* self, [NativeTypeName("_Bool")] byte accepting_events);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_ClearEventsQueue(ImGuiIO* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_ClearInputKeys(ImGuiIO* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_ClearInputMouse(ImGuiIO* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiIO* ImGuiIO_ImGuiIO();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIO_destroy(ImGuiIO* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiInputTextCallbackData* ImGuiInputTextCallbackData_ImGuiInputTextCallbackData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextCallbackData_destroy(ImGuiInputTextCallbackData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextCallbackData_DeleteChars(ImGuiInputTextCallbackData* self, int pos, int bytes_count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextCallbackData_InsertChars(ImGuiInputTextCallbackData* self, int pos, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextCallbackData_SelectAll(ImGuiInputTextCallbackData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextCallbackData_ClearSelection(ImGuiInputTextCallbackData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiInputTextCallbackData_HasSelection(ImGuiInputTextCallbackData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiWindowClass* ImGuiWindowClass_ImGuiWindowClass();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiWindowClass_destroy(ImGuiWindowClass* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiPayload* ImGuiPayload_ImGuiPayload();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiPayload_destroy(ImGuiPayload* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiPayload_Clear(ImGuiPayload* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiPayload_IsDataType(ImGuiPayload* self, [NativeTypeName("const char *")] sbyte* type);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiPayload_IsPreview(ImGuiPayload* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiPayload_IsDelivery(ImGuiPayload* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiOnceUponAFrame* ImGuiOnceUponAFrame_ImGuiOnceUponAFrame();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiOnceUponAFrame_destroy(ImGuiOnceUponAFrame* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTextFilter* ImGuiTextFilter_ImGuiTextFilter([NativeTypeName("const char *")] sbyte* default_filter);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextFilter_destroy(ImGuiTextFilter* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiTextFilter_Draw(ImGuiTextFilter* self, [NativeTypeName("const char *")] sbyte* label, float width);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiTextFilter_PassFilter(ImGuiTextFilter* self, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextFilter_Build(ImGuiTextFilter* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextFilter_Clear(ImGuiTextFilter* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiTextFilter_IsActive(ImGuiTextFilter* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTextRange* ImGuiTextRange_ImGuiTextRange_Nil();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextRange_destroy(ImGuiTextRange* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTextRange* ImGuiTextRange_ImGuiTextRange_Str([NativeTypeName("const char *")] sbyte* _b, [NativeTypeName("const char *")] sbyte* _e);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiTextRange_empty(ImGuiTextRange* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextRange_split(ImGuiTextRange* self, [NativeTypeName("char")] sbyte separator, ImVector_ImGuiTextRange* @out);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTextBuffer* ImGuiTextBuffer_ImGuiTextBuffer();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextBuffer_destroy(ImGuiTextBuffer* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImGuiTextBuffer_begin(ImGuiTextBuffer* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImGuiTextBuffer_end(ImGuiTextBuffer* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ImGuiTextBuffer_size(ImGuiTextBuffer* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiTextBuffer_empty(ImGuiTextBuffer* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextBuffer_clear(ImGuiTextBuffer* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextBuffer_resize(ImGuiTextBuffer* self, int size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextBuffer_reserve(ImGuiTextBuffer* self, int capacity);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImGuiTextBuffer_c_str(ImGuiTextBuffer* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextBuffer_append(ImGuiTextBuffer* self, [NativeTypeName("const char *")] sbyte* str, [NativeTypeName("const char *")] sbyte* str_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextBuffer_appendfv(ImGuiTextBuffer* self, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Int([NativeTypeName("ImGuiID")] uint _key, int _val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiStoragePair_destroy(ImGuiStoragePair* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Float([NativeTypeName("ImGuiID")] uint _key, float _val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Ptr([NativeTypeName("ImGuiID")] uint _key, void* _val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiStorage_Clear(ImGuiStorage* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ImGuiStorage_GetInt(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, int default_val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiStorage_SetInt(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, int val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiStorage_GetBool(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, [NativeTypeName("_Bool")] byte default_val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiStorage_SetBool(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, [NativeTypeName("_Bool")] byte val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ImGuiStorage_GetFloat(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, float default_val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiStorage_SetFloat(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, float val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* ImGuiStorage_GetVoidPtr(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiStorage_SetVoidPtr(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, void* val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int* ImGuiStorage_GetIntRef(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, int default_val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool *")]
        public static extern bool* ImGuiStorage_GetBoolRef(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, [NativeTypeName("_Bool")] byte default_val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float* ImGuiStorage_GetFloatRef(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, float default_val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void** ImGuiStorage_GetVoidPtrRef(ImGuiStorage* self, [NativeTypeName("ImGuiID")] uint key, void* default_val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiStorage_BuildSortByKey(ImGuiStorage* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiStorage_SetAllInt(ImGuiStorage* self, int val);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiListClipper* ImGuiListClipper_ImGuiListClipper();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiListClipper_destroy(ImGuiListClipper* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiListClipper_Begin(ImGuiListClipper* self, int items_count, float items_height);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiListClipper_End(ImGuiListClipper* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiListClipper_Step(ImGuiListClipper* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiListClipper_IncludeItemByIndex(ImGuiListClipper* self, int item_index);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiListClipper_IncludeItemsByIndex(ImGuiListClipper* self, int item_begin, int item_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiListClipper_SeekCursorForItem(ImGuiListClipper* self, int item_index);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImColor* ImColor_ImColor_Nil();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImColor_destroy(ImColor* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImColor* ImColor_ImColor_Float(float r, float g, float b, float a);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImColor* ImColor_ImColor_Vec4([NativeTypeName("const ImVec4")] System.Numerics.Vector4 col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImColor* ImColor_ImColor_Int(int r, int g, int b, int a);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImColor* ImColor_ImColor_U32([NativeTypeName("ImU32")] uint rgba);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImColor_SetHSV(ImColor* self, float h, float s, float v, float a);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImColor_HSV(ImColor* pOut, float h, float s, float v, float a);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiSelectionBasicStorage* ImGuiSelectionBasicStorage_ImGuiSelectionBasicStorage();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiSelectionBasicStorage_destroy(ImGuiSelectionBasicStorage* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiSelectionBasicStorage_ApplyRequests(ImGuiSelectionBasicStorage* self, ImGuiMultiSelectIO* ms_io);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiSelectionBasicStorage_Contains(ImGuiSelectionBasicStorage* self, [NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiSelectionBasicStorage_Clear(ImGuiSelectionBasicStorage* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiSelectionBasicStorage_Swap(ImGuiSelectionBasicStorage* self, ImGuiSelectionBasicStorage* r);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiSelectionBasicStorage_SetItemSelected(ImGuiSelectionBasicStorage* self, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("_Bool")] byte selected);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiSelectionBasicStorage_GetNextSelectedItem(ImGuiSelectionBasicStorage* self, void** opaque_it, [NativeTypeName("ImGuiID *")] uint* out_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint ImGuiSelectionBasicStorage_GetStorageIdFromIndex(ImGuiSelectionBasicStorage* self, int idx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiSelectionExternalStorage* ImGuiSelectionExternalStorage_ImGuiSelectionExternalStorage();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiSelectionExternalStorage_destroy(ImGuiSelectionExternalStorage* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiSelectionExternalStorage_ApplyRequests(ImGuiSelectionExternalStorage* self, ImGuiMultiSelectIO* ms_io);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImDrawCmd* ImDrawCmd_ImDrawCmd();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawCmd_destroy(ImDrawCmd* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImTextureID")]
        public static extern ulong ImDrawCmd_GetTexID(ImDrawCmd* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImDrawListSplitter* ImDrawListSplitter_ImDrawListSplitter();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawListSplitter_destroy(ImDrawListSplitter* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawListSplitter_Clear(ImDrawListSplitter* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawListSplitter_ClearFreeMemory(ImDrawListSplitter* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawListSplitter_Split(ImDrawListSplitter* self, ImDrawList* draw_list, int count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawListSplitter_Merge(ImDrawListSplitter* self, ImDrawList* draw_list);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawListSplitter_SetCurrentChannel(ImDrawListSplitter* self, ImDrawList* draw_list, int channel_idx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImDrawList* ImDrawList_ImDrawList(ImDrawListSharedData* shared_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_destroy(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PushClipRect(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 clip_rect_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 clip_rect_max, [NativeTypeName("_Bool")] byte intersect_with_current_clip_rect);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PushClipRectFullScreen(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PopClipRect(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PushTexture(ImDrawList* self, ImTextureRef tex_ref);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PopTexture(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_GetClipRectMin([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_GetClipRectMax([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddLine(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p1, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("ImU32")] uint col, float thickness);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddRect(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p_max, [NativeTypeName("ImU32")] uint col, float rounding, [NativeTypeName("ImDrawFlags")] int flags, float thickness);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddRectFilled(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p_max, [NativeTypeName("ImU32")] uint col, float rounding, [NativeTypeName("ImDrawFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddRectFilledMultiColor(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p_max, [NativeTypeName("ImU32")] uint col_upr_left, [NativeTypeName("ImU32")] uint col_upr_right, [NativeTypeName("ImU32")] uint col_bot_right, [NativeTypeName("ImU32")] uint col_bot_left);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddQuad(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p1, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p3, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p4, [NativeTypeName("ImU32")] uint col, float thickness);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddQuadFilled(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p1, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p3, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p4, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddTriangle(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p1, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p3, [NativeTypeName("ImU32")] uint col, float thickness);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddTriangleFilled(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p1, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p3, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddCircle(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 center, float radius, [NativeTypeName("ImU32")] uint col, int num_segments, float thickness);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddCircleFilled(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 center, float radius, [NativeTypeName("ImU32")] uint col, int num_segments);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddNgon(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 center, float radius, [NativeTypeName("ImU32")] uint col, int num_segments, float thickness);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddNgonFilled(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 center, float radius, [NativeTypeName("ImU32")] uint col, int num_segments);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddEllipse(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 center, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 radius, [NativeTypeName("ImU32")] uint col, float rot, int num_segments, float thickness);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddEllipseFilled(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 center, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 radius, [NativeTypeName("ImU32")] uint col, float rot, int num_segments);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddText_Vec2(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("ImU32")] uint col, [NativeTypeName("const char *")] sbyte* text_begin, [NativeTypeName("const char *")] sbyte* text_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddText_FontPtr(ImDrawList* self, ImFont* font, float font_size, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("ImU32")] uint col, [NativeTypeName("const char *")] sbyte* text_begin, [NativeTypeName("const char *")] sbyte* text_end, float wrap_width, [NativeTypeName("const ImVec4 *")] System.Numerics.Vector4* cpu_fine_clip_rect);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddBezierCubic(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p1, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p3, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p4, [NativeTypeName("ImU32")] uint col, float thickness, int num_segments);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddBezierQuadratic(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p1, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p3, [NativeTypeName("ImU32")] uint col, float thickness, int num_segments);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddPolyline(ImDrawList* self, [NativeTypeName("const ImVec2 *")] System.Numerics.Vector2* points, int num_points, [NativeTypeName("ImU32")] uint col, [NativeTypeName("ImDrawFlags")] int flags, float thickness);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddConvexPolyFilled(ImDrawList* self, [NativeTypeName("const ImVec2 *")] System.Numerics.Vector2* points, int num_points, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddConcavePolyFilled(ImDrawList* self, [NativeTypeName("const ImVec2 *")] System.Numerics.Vector2* points, int num_points, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddImage(ImDrawList* self, ImTextureRef tex_ref, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p_max, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv_max, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddImageQuad(ImDrawList* self, ImTextureRef tex_ref, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p1, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p3, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p4, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv1, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv3, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv4, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddImageRounded(ImDrawList* self, ImTextureRef tex_ref, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p_max, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv_max, [NativeTypeName("ImU32")] uint col, float rounding, [NativeTypeName("ImDrawFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PathClear(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PathLineTo(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PathLineToMergeDuplicate(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PathFillConvex(ImDrawList* self, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PathFillConcave(ImDrawList* self, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PathStroke(ImDrawList* self, [NativeTypeName("ImU32")] uint col, [NativeTypeName("ImDrawFlags")] int flags, float thickness);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PathArcTo(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 center, float radius, float a_min, float a_max, int num_segments);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PathArcToFast(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 center, float radius, int a_min_of_12, int a_max_of_12);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PathEllipticalArcTo(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 center, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 radius, float rot, float a_min, float a_max, int num_segments);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PathBezierCubicCurveTo(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p3, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p4, int num_segments);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PathBezierQuadraticCurveTo(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p3, int num_segments);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PathRect(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 rect_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 rect_max, float rounding, [NativeTypeName("ImDrawFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddCallback(ImDrawList* self, [NativeTypeName("ImDrawCallback")] delegate* unmanaged[Cdecl]<ImDrawList*, ImDrawCmd*, void> callback, void* userdata, [NativeTypeName("size_t")] nuint userdata_size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_AddDrawCmd(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImDrawList* ImDrawList_CloneOutput(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_ChannelsSplit(ImDrawList* self, int count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_ChannelsMerge(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_ChannelsSetCurrent(ImDrawList* self, int n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PrimReserve(ImDrawList* self, int idx_count, int vtx_count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PrimUnreserve(ImDrawList* self, int idx_count, int vtx_count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PrimRect(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 b, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PrimRectUV(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 b, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv_a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv_b, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PrimQuadUV(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 b, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 c, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 d, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv_a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv_b, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv_c, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv_d, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PrimWriteVtx(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PrimWriteIdx(ImDrawList* self, [NativeTypeName("ImDrawIdx")] ushort idx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList_PrimVtx(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList__SetDrawListSharedData(ImDrawList* self, ImDrawListSharedData* data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList__ResetForNewFrame(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList__ClearFreeMemory(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList__PopUnusedDrawCmd(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList__TryMergeDrawCmds(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList__OnChangedClipRect(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList__OnChangedTexture(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList__OnChangedVtxOffset(ImDrawList* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList__SetTexture(ImDrawList* self, ImTextureRef tex_ref);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ImDrawList__CalcCircleAutoSegmentCount(ImDrawList* self, float radius);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList__PathArcToFastEx(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 center, float radius, int a_min_sample, int a_max_sample, int a_step);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawList__PathArcToN(ImDrawList* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 center, float radius, float a_min, float a_max, int num_segments);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImDrawData* ImDrawData_ImDrawData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawData_destroy(ImDrawData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawData_Clear(ImDrawData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawData_AddDrawList(ImDrawData* self, ImDrawList* draw_list);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawData_DeIndexAllBuffers(ImDrawData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawData_ScaleClipRects(ImDrawData* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 fb_scale);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImTextureData* ImTextureData_ImTextureData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImTextureData_destroy(ImTextureData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImTextureData_Create(ImTextureData* self, ImTextureFormat format, int w, int h);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImTextureData_DestroyPixels(ImTextureData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* ImTextureData_GetPixels(ImTextureData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* ImTextureData_GetPixelsAt(ImTextureData* self, int x, int y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ImTextureData_GetSizeInBytes(ImTextureData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ImTextureData_GetPitch(ImTextureData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImTextureData_GetTexRef(ImTextureRef* pOut, ImTextureData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImTextureID")]
        public static extern ulong ImTextureData_GetTexID(ImTextureData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImTextureData_SetTexID(ImTextureData* self, [NativeTypeName("ImTextureID")] ulong tex_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImTextureData_SetStatus(ImTextureData* self, ImTextureStatus status);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFontConfig* ImFontConfig_ImFontConfig();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontConfig_destroy(ImFontConfig* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFontGlyph* ImFontGlyph_ImFontGlyph();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontGlyph_destroy(ImFontGlyph* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFontGlyphRangesBuilder* ImFontGlyphRangesBuilder_ImFontGlyphRangesBuilder();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontGlyphRangesBuilder_destroy(ImFontGlyphRangesBuilder* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontGlyphRangesBuilder_Clear(ImFontGlyphRangesBuilder* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImFontGlyphRangesBuilder_GetBit(ImFontGlyphRangesBuilder* self, [NativeTypeName("size_t")] nuint n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontGlyphRangesBuilder_SetBit(ImFontGlyphRangesBuilder* self, [NativeTypeName("size_t")] nuint n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontGlyphRangesBuilder_AddChar(ImFontGlyphRangesBuilder* self, [NativeTypeName("ImWchar")] ushort c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontGlyphRangesBuilder_AddText(ImFontGlyphRangesBuilder* self, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontGlyphRangesBuilder_AddRanges(ImFontGlyphRangesBuilder* self, [NativeTypeName("const ImWchar *")] ushort* ranges);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontGlyphRangesBuilder_BuildRanges(ImFontGlyphRangesBuilder* self, ImVector_ImWchar* out_ranges);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFontAtlasRect* ImFontAtlasRect_ImFontAtlasRect();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontAtlasRect_destroy(ImFontAtlasRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFontAtlas* ImFontAtlas_ImFontAtlas();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontAtlas_destroy(ImFontAtlas* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFont* ImFontAtlas_AddFont(ImFontAtlas* self, [NativeTypeName("const ImFontConfig *")] ImFontConfig* font_cfg);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFont* ImFontAtlas_AddFontDefault(ImFontAtlas* self, [NativeTypeName("const ImFontConfig *")] ImFontConfig* font_cfg);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFont* ImFontAtlas_AddFontFromFileTTF(ImFontAtlas* self, [NativeTypeName("const char *")] sbyte* filename, float size_pixels, [NativeTypeName("const ImFontConfig *")] ImFontConfig* font_cfg, [NativeTypeName("const ImWchar *")] ushort* glyph_ranges);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFont* ImFontAtlas_AddFontFromMemoryTTF(ImFontAtlas* self, void* font_data, int font_data_size, float size_pixels, [NativeTypeName("const ImFontConfig *")] ImFontConfig* font_cfg, [NativeTypeName("const ImWchar *")] ushort* glyph_ranges);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFont* ImFontAtlas_AddFontFromMemoryCompressedTTF(ImFontAtlas* self, [NativeTypeName("const void *")] void* compressed_font_data, int compressed_font_data_size, float size_pixels, [NativeTypeName("const ImFontConfig *")] ImFontConfig* font_cfg, [NativeTypeName("const ImWchar *")] ushort* glyph_ranges);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFont* ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(ImFontAtlas* self, [NativeTypeName("const char *")] sbyte* compressed_font_data_base85, float size_pixels, [NativeTypeName("const ImFontConfig *")] ImFontConfig* font_cfg, [NativeTypeName("const ImWchar *")] ushort* glyph_ranges);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontAtlas_RemoveFont(ImFontAtlas* self, ImFont* font);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontAtlas_Clear(ImFontAtlas* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontAtlas_CompactCache(ImFontAtlas* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontAtlas_SetFontLoader(ImFontAtlas* self, [NativeTypeName("const ImFontLoader *")] ImFontLoader* font_loader);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontAtlas_ClearInputData(ImFontAtlas* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontAtlas_ClearFonts(ImFontAtlas* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontAtlas_ClearTexData(ImFontAtlas* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const ImWchar *")]
        public static extern ushort* ImFontAtlas_GetGlyphRangesDefault(ImFontAtlas* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImFontAtlasRectId")]
        public static extern int ImFontAtlas_AddCustomRect(ImFontAtlas* self, int width, int height, ImFontAtlasRect* out_r);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontAtlas_RemoveCustomRect(ImFontAtlas* self, [NativeTypeName("ImFontAtlasRectId")] int id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImFontAtlas_GetCustomRect(ImFontAtlas* self, [NativeTypeName("ImFontAtlasRectId")] int id, ImFontAtlasRect* out_r);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFontBaked* ImFontBaked_ImFontBaked();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontBaked_destroy(ImFontBaked* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontBaked_ClearOutputData(ImFontBaked* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFontGlyph* ImFontBaked_FindGlyph(ImFontBaked* self, [NativeTypeName("ImWchar")] ushort c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFontGlyph* ImFontBaked_FindGlyphNoFallback(ImFontBaked* self, [NativeTypeName("ImWchar")] ushort c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ImFontBaked_GetCharAdvance(ImFontBaked* self, [NativeTypeName("ImWchar")] ushort c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImFontBaked_IsGlyphLoaded(ImFontBaked* self, [NativeTypeName("ImWchar")] ushort c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFont* ImFont_ImFont();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFont_destroy(ImFont* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImFont_IsGlyphInFont(ImFont* self, [NativeTypeName("ImWchar")] ushort c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImFont_IsLoaded(ImFont* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImFont_GetDebugName(ImFont* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFontBaked* ImFont_GetFontBaked(ImFont* self, float font_size, float density);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFont_CalcTextSizeA([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImFont* self, float size, float max_width, float wrap_width, [NativeTypeName("const char *")] sbyte* text_begin, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("const char **")] sbyte** out_remaining);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImFont_CalcWordWrapPosition(ImFont* self, float size, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, float wrap_width);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFont_RenderChar(ImFont* self, ImDrawList* draw_list, float size, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("ImU32")] uint col, [NativeTypeName("ImWchar")] ushort c, [NativeTypeName("const ImVec4 *")] System.Numerics.Vector4* cpu_fine_clip);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFont_RenderText(ImFont* self, ImDrawList* draw_list, float size, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("ImU32")] uint col, [NativeTypeName("const ImVec4")] System.Numerics.Vector4 clip_rect, [NativeTypeName("const char *")] sbyte* text_begin, [NativeTypeName("const char *")] sbyte* text_end, float wrap_width, [NativeTypeName("ImDrawTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFont_ClearOutputData(ImFont* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFont_AddRemapChar(ImFont* self, [NativeTypeName("ImWchar")] ushort from_codepoint, [NativeTypeName("ImWchar")] ushort to_codepoint);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImFont_IsGlyphRangeUnused(ImFont* self, [NativeTypeName("unsigned int")] uint c_begin, [NativeTypeName("unsigned int")] uint c_last);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiViewport* ImGuiViewport_ImGuiViewport();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiViewport_destroy(ImGuiViewport* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiViewport_GetCenter([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImGuiViewport* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiViewport_GetWorkCenter([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImGuiViewport* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiPlatformIO* ImGuiPlatformIO_ImGuiPlatformIO();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiPlatformIO_destroy(ImGuiPlatformIO* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiPlatformMonitor* ImGuiPlatformMonitor_ImGuiPlatformMonitor();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiPlatformMonitor_destroy(ImGuiPlatformMonitor* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiPlatformImeData* ImGuiPlatformImeData_ImGuiPlatformImeData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiPlatformImeData_destroy(ImGuiPlatformImeData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImHashData", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint ImHashData([NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint data_size, [NativeTypeName("ImGuiID")] uint seed);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImHashStr", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint ImHashStr([NativeTypeName("const char *")] sbyte* data, [NativeTypeName("size_t")] nuint data_size, [NativeTypeName("ImGuiID")] uint seed);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImHashSkipUncontributingPrefix", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImHashSkipUncontributingPrefix([NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImQsort", ExactSpelling = true)]
        public static extern void ImQsort(void* @base, [NativeTypeName("size_t")] nuint count, [NativeTypeName("size_t")] nuint size_of_element, [NativeTypeName("int (*)(const void *, const void *)")] delegate* unmanaged[Cdecl]<void*, void*, int> compare_func);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImAlphaBlendColors", ExactSpelling = true)]
        [return: NativeTypeName("ImU32")]
        public static extern uint ImAlphaBlendColors([NativeTypeName("ImU32")] uint col_a, [NativeTypeName("ImU32")] uint col_b);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImIsPowerOfTwo_Int", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImIsPowerOfTwo_Int(int v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImIsPowerOfTwo_U64", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImIsPowerOfTwo_U64([NativeTypeName("ImU64")] ulong v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImUpperPowerOfTwo", ExactSpelling = true)]
        public static extern int ImUpperPowerOfTwo(int v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImCountSetBits", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint ImCountSetBits([NativeTypeName("unsigned int")] uint v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImStricmp", ExactSpelling = true)]
        public static extern int ImStricmp([NativeTypeName("const char *")] sbyte* str1, [NativeTypeName("const char *")] sbyte* str2);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImStrnicmp", ExactSpelling = true)]
        public static extern int ImStrnicmp([NativeTypeName("const char *")] sbyte* str1, [NativeTypeName("const char *")] sbyte* str2, [NativeTypeName("size_t")] nuint count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImStrncpy", ExactSpelling = true)]
        public static extern void ImStrncpy([NativeTypeName("char *")] sbyte* dst, [NativeTypeName("const char *")] sbyte* src, [NativeTypeName("size_t")] nuint count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImStrdup", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* ImStrdup([NativeTypeName("const char *")] sbyte* str);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImMemdup", ExactSpelling = true)]
        public static extern void* ImMemdup([NativeTypeName("const void *")] void* src, [NativeTypeName("size_t")] nuint size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImStrdupcpy", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* ImStrdupcpy([NativeTypeName("char *")] sbyte* dst, [NativeTypeName("size_t *")] nuint* p_dst_size, [NativeTypeName("const char *")] sbyte* str);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImStrchrRange", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImStrchrRange([NativeTypeName("const char *")] sbyte* str_begin, [NativeTypeName("const char *")] sbyte* str_end, [NativeTypeName("char")] sbyte c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImStreolRange", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImStreolRange([NativeTypeName("const char *")] sbyte* str, [NativeTypeName("const char *")] sbyte* str_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImStristr", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImStristr([NativeTypeName("const char *")] sbyte* haystack, [NativeTypeName("const char *")] sbyte* haystack_end, [NativeTypeName("const char *")] sbyte* needle, [NativeTypeName("const char *")] sbyte* needle_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImStrTrimBlanks", ExactSpelling = true)]
        public static extern void ImStrTrimBlanks([NativeTypeName("char *")] sbyte* str);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImStrSkipBlank", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImStrSkipBlank([NativeTypeName("const char *")] sbyte* str);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImStrlenW", ExactSpelling = true)]
        public static extern int ImStrlenW([NativeTypeName("const ImWchar *")] ushort* str);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImStrbol", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImStrbol([NativeTypeName("const char *")] sbyte* buf_mid_line, [NativeTypeName("const char *")] sbyte* buf_begin);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImToUpper", ExactSpelling = true)]
        [return: NativeTypeName("char")]
        public static extern sbyte ImToUpper([NativeTypeName("char")] sbyte c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImCharIsBlankA", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImCharIsBlankA([NativeTypeName("char")] sbyte c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImCharIsBlankW", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImCharIsBlankW([NativeTypeName("unsigned int")] uint c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImCharIsXdigitA", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImCharIsXdigitA([NativeTypeName("char")] sbyte c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFormatString", ExactSpelling = true)]
        public static extern int ImFormatString([NativeTypeName("char *")] sbyte* buf, [NativeTypeName("size_t")] nuint buf_size, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFormatStringV", ExactSpelling = true)]
        public static extern int ImFormatStringV([NativeTypeName("char *")] sbyte* buf, [NativeTypeName("size_t")] nuint buf_size, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFormatStringToTempBuffer", ExactSpelling = true)]
        public static extern void ImFormatStringToTempBuffer([NativeTypeName("const char **")] sbyte** out_buf, [NativeTypeName("const char **")] sbyte** out_buf_end, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFormatStringToTempBufferV", ExactSpelling = true)]
        public static extern void ImFormatStringToTempBufferV([NativeTypeName("const char **")] sbyte** out_buf, [NativeTypeName("const char **")] sbyte** out_buf_end, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImParseFormatFindStart", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImParseFormatFindStart([NativeTypeName("const char *")] sbyte* format);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImParseFormatFindEnd", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImParseFormatFindEnd([NativeTypeName("const char *")] sbyte* format);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImParseFormatTrimDecorations", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImParseFormatTrimDecorations([NativeTypeName("const char *")] sbyte* format, [NativeTypeName("char *")] sbyte* buf, [NativeTypeName("size_t")] nuint buf_size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImParseFormatSanitizeForPrinting", ExactSpelling = true)]
        public static extern void ImParseFormatSanitizeForPrinting([NativeTypeName("const char *")] sbyte* fmt_in, [NativeTypeName("char *")] sbyte* fmt_out, [NativeTypeName("size_t")] nuint fmt_out_size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImParseFormatSanitizeForScanning", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImParseFormatSanitizeForScanning([NativeTypeName("const char *")] sbyte* fmt_in, [NativeTypeName("char *")] sbyte* fmt_out, [NativeTypeName("size_t")] nuint fmt_out_size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImParseFormatPrecision", ExactSpelling = true)]
        public static extern int ImParseFormatPrecision([NativeTypeName("const char *")] sbyte* format, int default_value);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTextCharToUtf8", ExactSpelling = true)]
        public static extern int ImTextCharToUtf8([NativeTypeName("char[5]")] sbyte* out_buf, [NativeTypeName("unsigned int")] uint c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTextStrToUtf8", ExactSpelling = true)]
        public static extern int ImTextStrToUtf8([NativeTypeName("char *")] sbyte* out_buf, int out_buf_size, [NativeTypeName("const ImWchar *")] ushort* in_text, [NativeTypeName("const ImWchar *")] ushort* in_text_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTextCharFromUtf8", ExactSpelling = true)]
        public static extern int ImTextCharFromUtf8([NativeTypeName("unsigned int *")] uint* out_char, [NativeTypeName("const char *")] sbyte* in_text, [NativeTypeName("const char *")] sbyte* in_text_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTextStrFromUtf8", ExactSpelling = true)]
        public static extern int ImTextStrFromUtf8([NativeTypeName("ImWchar *")] ushort* out_buf, int out_buf_size, [NativeTypeName("const char *")] sbyte* in_text, [NativeTypeName("const char *")] sbyte* in_text_end, [NativeTypeName("const char **")] sbyte** in_remaining);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTextCountCharsFromUtf8", ExactSpelling = true)]
        public static extern int ImTextCountCharsFromUtf8([NativeTypeName("const char *")] sbyte* in_text, [NativeTypeName("const char *")] sbyte* in_text_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTextCountUtf8BytesFromChar", ExactSpelling = true)]
        public static extern int ImTextCountUtf8BytesFromChar([NativeTypeName("const char *")] sbyte* in_text, [NativeTypeName("const char *")] sbyte* in_text_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTextCountUtf8BytesFromStr", ExactSpelling = true)]
        public static extern int ImTextCountUtf8BytesFromStr([NativeTypeName("const ImWchar *")] ushort* in_text, [NativeTypeName("const ImWchar *")] ushort* in_text_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTextFindPreviousUtf8Codepoint", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImTextFindPreviousUtf8Codepoint([NativeTypeName("const char *")] sbyte* in_text_start, [NativeTypeName("const char *")] sbyte* in_text_curr);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTextCountLines", ExactSpelling = true)]
        public static extern int ImTextCountLines([NativeTypeName("const char *")] sbyte* in_text, [NativeTypeName("const char *")] sbyte* in_text_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontCalcTextSizeEx", ExactSpelling = true)]
        public static extern void ImFontCalcTextSizeEx([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImFont* font, float size, float max_width, float wrap_width, [NativeTypeName("const char *")] sbyte* text_begin, [NativeTypeName("const char *")] sbyte* text_end_display, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("const char **")] sbyte** out_remaining, [NativeTypeName("ImVec2 *")] System.Numerics.Vector2* out_offset, [NativeTypeName("ImDrawTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontCalcWordWrapPositionEx", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImFontCalcWordWrapPositionEx(ImFont* font, float size, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, float wrap_width, [NativeTypeName("ImDrawTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTextCalcWordWrapNextLineStart", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImTextCalcWordWrapNextLineStart([NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("ImDrawTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFileOpen", ExactSpelling = true)]
        [return: NativeTypeName("ImFileHandle")]
        public static extern void* ImFileOpen([NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("const char *")] sbyte* mode);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFileClose", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImFileClose([NativeTypeName("ImFileHandle")] void* file);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFileGetSize", ExactSpelling = true)]
        [return: NativeTypeName("ImU64")]
        public static extern ulong ImFileGetSize([NativeTypeName("ImFileHandle")] void* file);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFileRead", ExactSpelling = true)]
        [return: NativeTypeName("ImU64")]
        public static extern ulong ImFileRead(void* data, [NativeTypeName("ImU64")] ulong size, [NativeTypeName("ImU64")] ulong count, [NativeTypeName("ImFileHandle")] void* file);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFileWrite", ExactSpelling = true)]
        [return: NativeTypeName("ImU64")]
        public static extern ulong ImFileWrite([NativeTypeName("const void *")] void* data, [NativeTypeName("ImU64")] ulong size, [NativeTypeName("ImU64")] ulong count, [NativeTypeName("ImFileHandle")] void* file);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFileLoadToMemory", ExactSpelling = true)]
        public static extern void* ImFileLoadToMemory([NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("const char *")] sbyte* mode, [NativeTypeName("size_t *")] nuint* out_file_size, int padding_bytes);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImPow_Float", ExactSpelling = true)]
        public static extern float ImPow_Float(float x, float y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImPow_double", ExactSpelling = true)]
        public static extern double ImPow_double(double x, double y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImLog_Float", ExactSpelling = true)]
        public static extern float ImLog_Float(float x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImLog_double", ExactSpelling = true)]
        public static extern double ImLog_double(double x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImAbs_Int", ExactSpelling = true)]
        public static extern int ImAbs_Int(int x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImAbs_Float", ExactSpelling = true)]
        public static extern float ImAbs_Float(float x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImAbs_double", ExactSpelling = true)]
        public static extern double ImAbs_double(double x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImSign_Float", ExactSpelling = true)]
        public static extern float ImSign_Float(float x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImSign_double", ExactSpelling = true)]
        public static extern double ImSign_double(double x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImRsqrt_Float", ExactSpelling = true)]
        public static extern float ImRsqrt_Float(float x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImRsqrt_double", ExactSpelling = true)]
        public static extern double ImRsqrt_double(double x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImMin", ExactSpelling = true)]
        public static extern void ImMin([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 lhs, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 rhs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImMax", ExactSpelling = true)]
        public static extern void ImMax([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 lhs, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 rhs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImClamp", ExactSpelling = true)]
        public static extern void ImClamp([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 v, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 mn, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 mx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImLerp_Vec2Float", ExactSpelling = true)]
        public static extern void ImLerp_Vec2Float([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 b, float t);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImLerp_Vec2Vec2", ExactSpelling = true)]
        public static extern void ImLerp_Vec2Vec2([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 b, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 t);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImLerp_Vec4", ExactSpelling = true)]
        public static extern void ImLerp_Vec4([NativeTypeName("ImVec4 *")] System.Numerics.Vector4* pOut, [NativeTypeName("const ImVec4")] System.Numerics.Vector4 a, [NativeTypeName("const ImVec4")] System.Numerics.Vector4 b, float t);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImSaturate", ExactSpelling = true)]
        public static extern float ImSaturate(float f);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImLengthSqr_Vec2", ExactSpelling = true)]
        public static extern float ImLengthSqr_Vec2([NativeTypeName("const ImVec2")] System.Numerics.Vector2 lhs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImLengthSqr_Vec4", ExactSpelling = true)]
        public static extern float ImLengthSqr_Vec4([NativeTypeName("const ImVec4")] System.Numerics.Vector4 lhs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImInvLength", ExactSpelling = true)]
        public static extern float ImInvLength([NativeTypeName("const ImVec2")] System.Numerics.Vector2 lhs, float fail_value);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTrunc_Float", ExactSpelling = true)]
        public static extern float ImTrunc_Float(float f);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTrunc_Vec2", ExactSpelling = true)]
        public static extern void ImTrunc_Vec2([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFloor_Float", ExactSpelling = true)]
        public static extern float ImFloor_Float(float f);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFloor_Vec2", ExactSpelling = true)]
        public static extern void ImFloor_Vec2([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTrunc64", ExactSpelling = true)]
        public static extern float ImTrunc64(float f);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImRound64", ExactSpelling = true)]
        public static extern float ImRound64(float f);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImModPositive", ExactSpelling = true)]
        public static extern int ImModPositive(int a, int b);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImDot", ExactSpelling = true)]
        public static extern float ImDot([NativeTypeName("const ImVec2")] System.Numerics.Vector2 a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 b);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImRotate", ExactSpelling = true)]
        public static extern void ImRotate([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 v, float cos_a, float sin_a);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImLinearSweep", ExactSpelling = true)]
        public static extern float ImLinearSweep(float current, float target, float speed);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImLinearRemapClamp", ExactSpelling = true)]
        public static extern float ImLinearRemapClamp(float s0, float s1, float d0, float d1, float x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImMul", ExactSpelling = true)]
        public static extern void ImMul([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 lhs, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 rhs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImIsFloatAboveGuaranteedIntegerPrecision", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImIsFloatAboveGuaranteedIntegerPrecision(float f);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImExponentialMovingAverage", ExactSpelling = true)]
        public static extern float ImExponentialMovingAverage(float avg, float sample, int n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImBezierCubicCalc", ExactSpelling = true)]
        public static extern void ImBezierCubicCalc([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p1, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p3, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p4, float t);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImBezierCubicClosestPoint", ExactSpelling = true)]
        public static extern void ImBezierCubicClosestPoint([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p1, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p3, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p4, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p, int num_segments);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImBezierCubicClosestPointCasteljau", ExactSpelling = true)]
        public static extern void ImBezierCubicClosestPointCasteljau([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p1, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p3, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p4, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p, float tess_tol);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImBezierQuadraticCalc", ExactSpelling = true)]
        public static extern void ImBezierQuadraticCalc([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p1, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p2, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p3, float t);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImLineClosestPoint", ExactSpelling = true)]
        public static extern void ImLineClosestPoint([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 b, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTriangleContainsPoint", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImTriangleContainsPoint([NativeTypeName("const ImVec2")] System.Numerics.Vector2 a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 b, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 c, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTriangleClosestPoint", ExactSpelling = true)]
        public static extern void ImTriangleClosestPoint([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 b, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 c, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTriangleBarycentricCoords", ExactSpelling = true)]
        public static extern void ImTriangleBarycentricCoords([NativeTypeName("const ImVec2")] System.Numerics.Vector2 a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 b, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 c, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p, float* out_u, float* out_v, float* out_w);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTriangleArea", ExactSpelling = true)]
        public static extern float ImTriangleArea([NativeTypeName("const ImVec2")] System.Numerics.Vector2 a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 b, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTriangleIsClockwise", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImTriangleIsClockwise([NativeTypeName("const ImVec2")] System.Numerics.Vector2 a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 b, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImVec1* ImVec1_ImVec1_Nil();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImVec1_destroy(ImVec1* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImVec1* ImVec1_ImVec1_Float(float _x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImVec2i* ImVec2i_ImVec2i_Nil();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImVec2i_destroy(ImVec2i* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImVec2i* ImVec2i_ImVec2i_Int(int _x, int _y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImVec2ih* ImVec2ih_ImVec2ih_Nil();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImVec2ih_destroy(ImVec2ih* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImVec2ih* ImVec2ih_ImVec2ih_short(short _x, short _y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImVec2ih* ImVec2ih_ImVec2ih_Vec2([NativeTypeName("const ImVec2")] System.Numerics.Vector2 rhs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImRect* ImRect_ImRect_Nil();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_destroy(ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImRect* ImRect_ImRect_Vec2([NativeTypeName("const ImVec2")] System.Numerics.Vector2 min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 max);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImRect* ImRect_ImRect_Vec4([NativeTypeName("const ImVec4")] System.Numerics.Vector4 v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImRect* ImRect_ImRect_Float(float x1, float y1, float x2, float y2);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_GetCenter([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_GetSize([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ImRect_GetWidth(ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ImRect_GetHeight(ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ImRect_GetArea(ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_GetTL([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_GetTR([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_GetBL([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_GetBR([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImRect_Contains_Vec2(ImRect* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImRect_Contains_Rect(ImRect* self, [NativeTypeName("const ImRect")] ImRect r);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImRect_ContainsWithPad(ImRect* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pad);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImRect_Overlaps(ImRect* self, [NativeTypeName("const ImRect")] ImRect r);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_Add_Vec2(ImRect* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_Add_Rect(ImRect* self, [NativeTypeName("const ImRect")] ImRect r);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_Expand_Float(ImRect* self, [NativeTypeName("const float")] float amount);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_Expand_Vec2(ImRect* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 amount);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_Translate(ImRect* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 d);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_TranslateX(ImRect* self, float dx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_TranslateY(ImRect* self, float dy);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_ClipWith(ImRect* self, [NativeTypeName("const ImRect")] ImRect r);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_ClipWithFull(ImRect* self, [NativeTypeName("const ImRect")] ImRect r);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_Floor(ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImRect_IsInverted(ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImRect_ToVec4([NativeTypeName("ImVec4 *")] System.Numerics.Vector4* pOut, ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const ImVec4 *")]
        public static extern System.Numerics.Vector4* ImRect_AsVec4(ImRect* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImBitArrayGetStorageSizeInBytes", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint ImBitArrayGetStorageSizeInBytes(int bitcount);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImBitArrayClearAllBits", ExactSpelling = true)]
        public static extern void ImBitArrayClearAllBits([NativeTypeName("ImU32 *")] uint* arr, int bitcount);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImBitArrayTestBit", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImBitArrayTestBit([NativeTypeName("const ImU32 *")] uint* arr, int n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImBitArrayClearBit", ExactSpelling = true)]
        public static extern void ImBitArrayClearBit([NativeTypeName("ImU32 *")] uint* arr, int n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImBitArraySetBit", ExactSpelling = true)]
        public static extern void ImBitArraySetBit([NativeTypeName("ImU32 *")] uint* arr, int n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImBitArraySetBitRange", ExactSpelling = true)]
        public static extern void ImBitArraySetBitRange([NativeTypeName("ImU32 *")] uint* arr, int n, int n2);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImBitVector_Create(ImBitVector* self, int sz);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImBitVector_Clear(ImBitVector* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImBitVector_TestBit(ImBitVector* self, int n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImBitVector_SetBit(ImBitVector* self, int n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImBitVector_ClearBit(ImBitVector* self, int n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextIndex_clear(ImGuiTextIndex* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ImGuiTextIndex_size(ImGuiTextIndex* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImGuiTextIndex_get_line_begin(ImGuiTextIndex* self, [NativeTypeName("const char *")] sbyte* @base, int n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImGuiTextIndex_get_line_end(ImGuiTextIndex* self, [NativeTypeName("const char *")] sbyte* @base, int n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextIndex_append(ImGuiTextIndex* self, [NativeTypeName("const char *")] sbyte* @base, int old_size, int new_size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImLowerBound", ExactSpelling = true)]
        public static extern ImGuiStoragePair* ImLowerBound(ImGuiStoragePair* in_begin, ImGuiStoragePair* in_end, [NativeTypeName("ImGuiID")] uint key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImDrawListSharedData* ImDrawListSharedData_ImDrawListSharedData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawListSharedData_destroy(ImDrawListSharedData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawListSharedData_SetCircleTessellationMaxError(ImDrawListSharedData* self, float max_error);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImDrawDataBuilder* ImDrawDataBuilder_ImDrawDataBuilder();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImDrawDataBuilder_destroy(ImDrawDataBuilder* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* ImGuiStyleVarInfo_GetVarPtr(ImGuiStyleVarInfo* self, void* parent);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiStyleMod* ImGuiStyleMod_ImGuiStyleMod_Int([NativeTypeName("ImGuiStyleVar")] int idx, int v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiStyleMod_destroy(ImGuiStyleMod* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiStyleMod* ImGuiStyleMod_ImGuiStyleMod_Float([NativeTypeName("ImGuiStyleVar")] int idx, float v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiStyleMod* ImGuiStyleMod_ImGuiStyleMod_Vec2([NativeTypeName("ImGuiStyleVar")] int idx, [NativeTypeName("ImVec2")] System.Numerics.Vector2 v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiComboPreviewData* ImGuiComboPreviewData_ImGuiComboPreviewData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiComboPreviewData_destroy(ImGuiComboPreviewData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiMenuColumns* ImGuiMenuColumns_ImGuiMenuColumns();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiMenuColumns_destroy(ImGuiMenuColumns* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiMenuColumns_Update(ImGuiMenuColumns* self, float spacing, [NativeTypeName("_Bool")] byte window_reappearing);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ImGuiMenuColumns_DeclColumns(ImGuiMenuColumns* self, float w_icon, float w_label, float w_shortcut, float w_mark);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiMenuColumns_CalcNextTotalWidth(ImGuiMenuColumns* self, [NativeTypeName("_Bool")] byte update_offsets);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiInputTextDeactivatedState* ImGuiInputTextDeactivatedState_ImGuiInputTextDeactivatedState();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextDeactivatedState_destroy(ImGuiInputTextDeactivatedState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextDeactivatedState_ClearFreeMemory(ImGuiInputTextDeactivatedState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiInputTextState* ImGuiInputTextState_ImGuiInputTextState();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextState_destroy(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextState_ClearText(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextState_ClearFreeMemory(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextState_OnKeyPressed(ImGuiInputTextState* self, int key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextState_OnCharPressed(ImGuiInputTextState* self, [NativeTypeName("unsigned int")] uint c);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ImGuiInputTextState_GetPreferredOffsetX(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextState_CursorAnimReset(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextState_CursorClamp(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiInputTextState_HasSelection(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextState_ClearSelection(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ImGuiInputTextState_GetCursorPos(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ImGuiInputTextState_GetSelectionStart(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ImGuiInputTextState_GetSelectionEnd(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextState_SelectAll(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextState_ReloadUserBufAndSelectAll(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextState_ReloadUserBufAndKeepSelection(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputTextState_ReloadUserBufAndMoveToEnd(ImGuiInputTextState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiNextWindowData* ImGuiNextWindowData_ImGuiNextWindowData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiNextWindowData_destroy(ImGuiNextWindowData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiNextWindowData_ClearFlags(ImGuiNextWindowData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiNextItemData* ImGuiNextItemData_ImGuiNextItemData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiNextItemData_destroy(ImGuiNextItemData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiNextItemData_ClearFlags(ImGuiNextItemData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiLastItemData* ImGuiLastItemData_ImGuiLastItemData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiLastItemData_destroy(ImGuiLastItemData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiErrorRecoveryState* ImGuiErrorRecoveryState_ImGuiErrorRecoveryState();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiErrorRecoveryState_destroy(ImGuiErrorRecoveryState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiPtrOrIndex* ImGuiPtrOrIndex_ImGuiPtrOrIndex_Ptr(void* ptr);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiPtrOrIndex_destroy(ImGuiPtrOrIndex* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiPtrOrIndex* ImGuiPtrOrIndex_ImGuiPtrOrIndex_Int(int index);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiPopupData* ImGuiPopupData_ImGuiPopupData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiPopupData_destroy(ImGuiPopupData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiInputEvent* ImGuiInputEvent_ImGuiInputEvent();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiInputEvent_destroy(ImGuiInputEvent* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiKeyRoutingData* ImGuiKeyRoutingData_ImGuiKeyRoutingData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiKeyRoutingData_destroy(ImGuiKeyRoutingData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiKeyRoutingTable* ImGuiKeyRoutingTable_ImGuiKeyRoutingTable();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiKeyRoutingTable_destroy(ImGuiKeyRoutingTable* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiKeyRoutingTable_Clear(ImGuiKeyRoutingTable* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiKeyOwnerData* ImGuiKeyOwnerData_ImGuiKeyOwnerData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiKeyOwnerData_destroy(ImGuiKeyOwnerData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiListClipperRange ImGuiListClipperRange_FromIndices(int min, int max);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiListClipperRange ImGuiListClipperRange_FromPositions(float y1, float y2, int off_min, int off_max);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiListClipperData* ImGuiListClipperData_ImGuiListClipperData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiListClipperData_destroy(ImGuiListClipperData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiListClipperData_Reset(ImGuiListClipperData* self, ImGuiListClipper* clipper);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiNavItemData* ImGuiNavItemData_ImGuiNavItemData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiNavItemData_destroy(ImGuiNavItemData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiNavItemData_Clear(ImGuiNavItemData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTypingSelectState* ImGuiTypingSelectState_ImGuiTypingSelectState();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTypingSelectState_destroy(ImGuiTypingSelectState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTypingSelectState_Clear(ImGuiTypingSelectState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiOldColumnData* ImGuiOldColumnData_ImGuiOldColumnData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiOldColumnData_destroy(ImGuiOldColumnData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiOldColumns* ImGuiOldColumns_ImGuiOldColumns();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiOldColumns_destroy(ImGuiOldColumns* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiBoxSelectState* ImGuiBoxSelectState_ImGuiBoxSelectState();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiBoxSelectState_destroy(ImGuiBoxSelectState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiMultiSelectTempData* ImGuiMultiSelectTempData_ImGuiMultiSelectTempData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiMultiSelectTempData_destroy(ImGuiMultiSelectTempData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiMultiSelectTempData_Clear(ImGuiMultiSelectTempData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiMultiSelectTempData_ClearIO(ImGuiMultiSelectTempData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiMultiSelectState* ImGuiMultiSelectState_ImGuiMultiSelectState();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiMultiSelectState_destroy(ImGuiMultiSelectState* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiDockNode* ImGuiDockNode_ImGuiDockNode([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiDockNode_destroy(ImGuiDockNode* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiDockNode_IsRootNode(ImGuiDockNode* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiDockNode_IsDockSpace(ImGuiDockNode* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiDockNode_IsFloatingNode(ImGuiDockNode* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiDockNode_IsCentralNode(ImGuiDockNode* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiDockNode_IsHiddenTabBar(ImGuiDockNode* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiDockNode_IsNoTabBar(ImGuiDockNode* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiDockNode_IsSplitNode(ImGuiDockNode* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiDockNode_IsLeafNode(ImGuiDockNode* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImGuiDockNode_IsEmpty(ImGuiDockNode* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiDockNode_Rect(ImRect* pOut, ImGuiDockNode* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiDockNode_SetLocalFlags(ImGuiDockNode* self, [NativeTypeName("ImGuiDockNodeFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiDockNode_UpdateMergedFlags(ImGuiDockNode* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiDockContext* ImGuiDockContext_ImGuiDockContext();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiDockContext_destroy(ImGuiDockContext* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiViewportP* ImGuiViewportP_ImGuiViewportP();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiViewportP_destroy(ImGuiViewportP* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiViewportP_ClearRequestFlags(ImGuiViewportP* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiViewportP_CalcWorkRectPos([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImGuiViewportP* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 inset_min);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiViewportP_CalcWorkRectSize([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImGuiViewportP* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 inset_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 inset_max);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiViewportP_UpdateWorkRect(ImGuiViewportP* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiViewportP_GetMainRect(ImRect* pOut, ImGuiViewportP* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiViewportP_GetWorkRect(ImRect* pOut, ImGuiViewportP* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiViewportP_GetBuildWorkRect(ImRect* pOut, ImGuiViewportP* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiWindowSettings* ImGuiWindowSettings_ImGuiWindowSettings();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiWindowSettings_destroy(ImGuiWindowSettings* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* ImGuiWindowSettings_GetName(ImGuiWindowSettings* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiSettingsHandler* ImGuiSettingsHandler_ImGuiSettingsHandler();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiSettingsHandler_destroy(ImGuiSettingsHandler* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiDebugAllocInfo* ImGuiDebugAllocInfo_ImGuiDebugAllocInfo();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiDebugAllocInfo_destroy(ImGuiDebugAllocInfo* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiStackLevelInfo* ImGuiStackLevelInfo_ImGuiStackLevelInfo();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiStackLevelInfo_destroy(ImGuiStackLevelInfo* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiIDStackTool* ImGuiIDStackTool_ImGuiIDStackTool();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiIDStackTool_destroy(ImGuiIDStackTool* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiContextHook* ImGuiContextHook_ImGuiContextHook();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiContextHook_destroy(ImGuiContextHook* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiContext* ImGuiContext_ImGuiContext(ImFontAtlas* shared_font_atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiContext_destroy(ImGuiContext* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiWindow* ImGuiWindow_ImGuiWindow(ImGuiContext* context, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiWindow_destroy(ImGuiWindow* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint ImGuiWindow_GetID_Str(ImGuiWindow* self, [NativeTypeName("const char *")] sbyte* str, [NativeTypeName("const char *")] sbyte* str_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint ImGuiWindow_GetID_Ptr(ImGuiWindow* self, [NativeTypeName("const void *")] void* ptr);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint ImGuiWindow_GetID_Int(ImGuiWindow* self, int n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint ImGuiWindow_GetIDFromPos(ImGuiWindow* self, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p_abs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint ImGuiWindow_GetIDFromRectangle(ImGuiWindow* self, [NativeTypeName("const ImRect")] ImRect r_abs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiWindow_Rect(ImRect* pOut, ImGuiWindow* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiWindow_TitleBarRect(ImRect* pOut, ImGuiWindow* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiWindow_MenuBarRect(ImRect* pOut, ImGuiWindow* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTabItem* ImGuiTabItem_ImGuiTabItem();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTabItem_destroy(ImGuiTabItem* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTabBar* ImGuiTabBar_ImGuiTabBar();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTabBar_destroy(ImGuiTabBar* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTableColumn* ImGuiTableColumn_ImGuiTableColumn();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTableColumn_destroy(ImGuiTableColumn* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTableInstanceData* ImGuiTableInstanceData_ImGuiTableInstanceData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTableInstanceData_destroy(ImGuiTableInstanceData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTable* ImGuiTable_ImGuiTable();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTable_destroy(ImGuiTable* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTableTempData* ImGuiTableTempData_ImGuiTableTempData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTableTempData_destroy(ImGuiTableTempData* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTableColumnSettings* ImGuiTableColumnSettings_ImGuiTableColumnSettings();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTableColumnSettings_destroy(ImGuiTableColumnSettings* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTableSettings* ImGuiTableSettings_ImGuiTableSettings();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTableSettings_destroy(ImGuiTableSettings* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImGuiTableColumnSettings* ImGuiTableSettings_GetColumnSettings(ImGuiTableSettings* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetIO_ContextPtr", ExactSpelling = true)]
        public static extern ImGuiIO* GetIO_ContextPtr(ImGuiContext* ctx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetPlatformIO_ContextPtr", ExactSpelling = true)]
        public static extern ImGuiPlatformIO* GetPlatformIO_ContextPtr(ImGuiContext* ctx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCurrentWindowRead", ExactSpelling = true)]
        public static extern ImGuiWindow* GetCurrentWindowRead();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCurrentWindow", ExactSpelling = true)]
        public static extern ImGuiWindow* GetCurrentWindow();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindWindowByID", ExactSpelling = true)]
        public static extern ImGuiWindow* FindWindowByID([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindWindowByName", ExactSpelling = true)]
        public static extern ImGuiWindow* FindWindowByName([NativeTypeName("const char *")] sbyte* name);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igUpdateWindowParentAndRootLinks", ExactSpelling = true)]
        public static extern void UpdateWindowParentAndRootLinks(ImGuiWindow* window, [NativeTypeName("ImGuiWindowFlags")] int flags, ImGuiWindow* parent_window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igUpdateWindowSkipRefresh", ExactSpelling = true)]
        public static extern void UpdateWindowSkipRefresh(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCalcWindowNextAutoFitSize", ExactSpelling = true)]
        public static extern void CalcWindowNextAutoFitSize([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsWindowChildOf", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsWindowChildOf(ImGuiWindow* window, ImGuiWindow* potential_parent, [NativeTypeName("_Bool")] byte popup_hierarchy, [NativeTypeName("_Bool")] byte dock_hierarchy);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsWindowWithinBeginStackOf", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsWindowWithinBeginStackOf(ImGuiWindow* window, ImGuiWindow* potential_parent);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsWindowAbove", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsWindowAbove(ImGuiWindow* potential_above, ImGuiWindow* potential_below);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsWindowNavFocusable", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsWindowNavFocusable(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowPos_WindowPtr", ExactSpelling = true)]
        public static extern void SetWindowPos_WindowPtr(ImGuiWindow* window, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowSize_WindowPtr", ExactSpelling = true)]
        public static extern void SetWindowSize_WindowPtr(ImGuiWindow* window, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowCollapsed_WindowPtr", ExactSpelling = true)]
        public static extern void SetWindowCollapsed_WindowPtr(ImGuiWindow* window, [NativeTypeName("_Bool")] byte collapsed, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowHitTestHole", ExactSpelling = true)]
        public static extern void SetWindowHitTestHole(ImGuiWindow* window, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowHiddenAndSkipItemsForCurrentFrame", ExactSpelling = true)]
        public static extern void SetWindowHiddenAndSkipItemsForCurrentFrame(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowParentWindowForFocusRoute", ExactSpelling = true)]
        public static extern void SetWindowParentWindowForFocusRoute(ImGuiWindow* window, ImGuiWindow* parent_window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igWindowRectAbsToRel", ExactSpelling = true)]
        public static extern void WindowRectAbsToRel(ImRect* pOut, ImGuiWindow* window, [NativeTypeName("const ImRect")] ImRect r);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igWindowRectRelToAbs", ExactSpelling = true)]
        public static extern void WindowRectRelToAbs(ImRect* pOut, ImGuiWindow* window, [NativeTypeName("const ImRect")] ImRect r);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igWindowPosAbsToRel", ExactSpelling = true)]
        public static extern void WindowPosAbsToRel([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImGuiWindow* window, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igWindowPosRelToAbs", ExactSpelling = true)]
        public static extern void WindowPosRelToAbs([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImGuiWindow* window, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 p);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFocusWindow", ExactSpelling = true)]
        public static extern void FocusWindow(ImGuiWindow* window, [NativeTypeName("ImGuiFocusRequestFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFocusTopMostWindowUnderOne", ExactSpelling = true)]
        public static extern void FocusTopMostWindowUnderOne(ImGuiWindow* under_this_window, ImGuiWindow* ignore_window, ImGuiViewport* filter_viewport, [NativeTypeName("ImGuiFocusRequestFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBringWindowToFocusFront", ExactSpelling = true)]
        public static extern void BringWindowToFocusFront(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBringWindowToDisplayFront", ExactSpelling = true)]
        public static extern void BringWindowToDisplayFront(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBringWindowToDisplayBack", ExactSpelling = true)]
        public static extern void BringWindowToDisplayBack(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBringWindowToDisplayBehind", ExactSpelling = true)]
        public static extern void BringWindowToDisplayBehind(ImGuiWindow* window, ImGuiWindow* above_window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindWindowDisplayIndex", ExactSpelling = true)]
        public static extern int FindWindowDisplayIndex(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindBottomMostVisibleWindowWithinBeginStack", ExactSpelling = true)]
        public static extern ImGuiWindow* FindBottomMostVisibleWindowWithinBeginStack(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextWindowRefreshPolicy", ExactSpelling = true)]
        public static extern void SetNextWindowRefreshPolicy([NativeTypeName("ImGuiWindowRefreshFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRegisterUserTexture", ExactSpelling = true)]
        public static extern void RegisterUserTexture(ImTextureData* tex);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igUnregisterUserTexture", ExactSpelling = true)]
        public static extern void UnregisterUserTexture(ImTextureData* tex);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRegisterFontAtlas", ExactSpelling = true)]
        public static extern void RegisterFontAtlas(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igUnregisterFontAtlas", ExactSpelling = true)]
        public static extern void UnregisterFontAtlas(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetCurrentFont", ExactSpelling = true)]
        public static extern void SetCurrentFont(ImFont* font, float font_size_before_scaling, float font_size_after_scaling);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igUpdateCurrentFontSize", ExactSpelling = true)]
        public static extern void UpdateCurrentFontSize(float restore_font_size_after_scaling);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetFontRasterizerDensity", ExactSpelling = true)]
        public static extern void SetFontRasterizerDensity(float rasterizer_density);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFontRasterizerDensity", ExactSpelling = true)]
        public static extern float GetFontRasterizerDensity();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetRoundedFontSize", ExactSpelling = true)]
        public static extern float GetRoundedFontSize(float size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetDefaultFont", ExactSpelling = true)]
        public static extern ImFont* GetDefaultFont();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushPasswordFont", ExactSpelling = true)]
        public static extern void PushPasswordFont();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPopPasswordFont", ExactSpelling = true)]
        public static extern void PopPasswordFont();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetForegroundDrawList_WindowPtr", ExactSpelling = true)]
        public static extern ImDrawList* GetForegroundDrawList_WindowPtr(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igAddDrawListToDrawDataEx", ExactSpelling = true)]
        public static extern void AddDrawListToDrawDataEx(ImDrawData* draw_data, ImVector_ImDrawListPtr* out_list, ImDrawList* draw_list);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInitialize", ExactSpelling = true)]
        public static extern void Initialize();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShutdown", ExactSpelling = true)]
        public static extern void Shutdown();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igUpdateInputEvents", ExactSpelling = true)]
        public static extern void UpdateInputEvents([NativeTypeName("_Bool")] byte trickle_fast_inputs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igUpdateHoveredWindowAndCaptureFlags", ExactSpelling = true)]
        public static extern void UpdateHoveredWindowAndCaptureFlags([NativeTypeName("const ImVec2")] System.Numerics.Vector2 mouse_pos);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindHoveredWindowEx", ExactSpelling = true)]
        public static extern void FindHoveredWindowEx([NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("_Bool")] byte find_first_and_in_any_viewport, ImGuiWindow** out_hovered_window, ImGuiWindow** out_hovered_window_under_moving_window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igStartMouseMovingWindow", ExactSpelling = true)]
        public static extern void StartMouseMovingWindow(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igStartMouseMovingWindowOrNode", ExactSpelling = true)]
        public static extern void StartMouseMovingWindowOrNode(ImGuiWindow* window, ImGuiDockNode* node, [NativeTypeName("_Bool")] byte undock);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igStopMouseMovingWindow", ExactSpelling = true)]
        public static extern void StopMouseMovingWindow();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igUpdateMouseMovingWindowNewFrame", ExactSpelling = true)]
        public static extern void UpdateMouseMovingWindowNewFrame();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igUpdateMouseMovingWindowEndFrame", ExactSpelling = true)]
        public static extern void UpdateMouseMovingWindowEndFrame();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igAddContextHook", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint AddContextHook(ImGuiContext* context, [NativeTypeName("const ImGuiContextHook *")] ImGuiContextHook* hook);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRemoveContextHook", ExactSpelling = true)]
        public static extern void RemoveContextHook(ImGuiContext* context, [NativeTypeName("ImGuiID")] uint hook_to_remove);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCallContextHooks", ExactSpelling = true)]
        public static extern void CallContextHooks(ImGuiContext* context, ImGuiContextHookType type);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTranslateWindowsInViewport", ExactSpelling = true)]
        public static extern void TranslateWindowsInViewport(ImGuiViewportP* viewport, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 old_pos, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 new_pos, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 old_size, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 new_size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igScaleWindowsInViewport", ExactSpelling = true)]
        public static extern void ScaleWindowsInViewport(ImGuiViewportP* viewport, float scale);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDestroyPlatformWindow", ExactSpelling = true)]
        public static extern void DestroyPlatformWindow(ImGuiViewportP* viewport);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowViewport", ExactSpelling = true)]
        public static extern void SetWindowViewport(ImGuiWindow* window, ImGuiViewportP* viewport);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetCurrentViewport", ExactSpelling = true)]
        public static extern void SetCurrentViewport(ImGuiWindow* window, ImGuiViewportP* viewport);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetViewportPlatformMonitor", ExactSpelling = true)]
        [return: NativeTypeName("const ImGuiPlatformMonitor *")]
        public static extern ImGuiPlatformMonitor* GetViewportPlatformMonitor(ImGuiViewport* viewport);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindHoveredViewportFromPlatformWindowStack", ExactSpelling = true)]
        public static extern ImGuiViewportP* FindHoveredViewportFromPlatformWindowStack([NativeTypeName("const ImVec2")] System.Numerics.Vector2 mouse_platform_pos);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igMarkIniSettingsDirty_Nil", ExactSpelling = true)]
        public static extern void MarkIniSettingsDirty_Nil();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igMarkIniSettingsDirty_WindowPtr", ExactSpelling = true)]
        public static extern void MarkIniSettingsDirty_WindowPtr(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igClearIniSettings", ExactSpelling = true)]
        public static extern void ClearIniSettings();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igAddSettingsHandler", ExactSpelling = true)]
        public static extern void AddSettingsHandler([NativeTypeName("const ImGuiSettingsHandler *")] ImGuiSettingsHandler* handler);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRemoveSettingsHandler", ExactSpelling = true)]
        public static extern void RemoveSettingsHandler([NativeTypeName("const char *")] sbyte* type_name);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindSettingsHandler", ExactSpelling = true)]
        public static extern ImGuiSettingsHandler* FindSettingsHandler([NativeTypeName("const char *")] sbyte* type_name);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCreateNewWindowSettings", ExactSpelling = true)]
        public static extern ImGuiWindowSettings* CreateNewWindowSettings([NativeTypeName("const char *")] sbyte* name);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindWindowSettingsByID", ExactSpelling = true)]
        public static extern ImGuiWindowSettings* FindWindowSettingsByID([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindWindowSettingsByWindow", ExactSpelling = true)]
        public static extern ImGuiWindowSettings* FindWindowSettingsByWindow(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igClearWindowSettings", ExactSpelling = true)]
        public static extern void ClearWindowSettings([NativeTypeName("const char *")] sbyte* name);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLocalizeRegisterEntries", ExactSpelling = true)]
        public static extern void LocalizeRegisterEntries([NativeTypeName("const ImGuiLocEntry *")] ImGuiLocEntry* entries, int count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLocalizeGetMsg", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* LocalizeGetMsg(ImGuiLocKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetScrollX_WindowPtr", ExactSpelling = true)]
        public static extern void SetScrollX_WindowPtr(ImGuiWindow* window, float scroll_x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetScrollY_WindowPtr", ExactSpelling = true)]
        public static extern void SetScrollY_WindowPtr(ImGuiWindow* window, float scroll_y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetScrollFromPosX_WindowPtr", ExactSpelling = true)]
        public static extern void SetScrollFromPosX_WindowPtr(ImGuiWindow* window, float local_x, float center_x_ratio);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetScrollFromPosY_WindowPtr", ExactSpelling = true)]
        public static extern void SetScrollFromPosY_WindowPtr(ImGuiWindow* window, float local_y, float center_y_ratio);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igScrollToItem", ExactSpelling = true)]
        public static extern void ScrollToItem([NativeTypeName("ImGuiScrollFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igScrollToRect", ExactSpelling = true)]
        public static extern void ScrollToRect(ImGuiWindow* window, [NativeTypeName("const ImRect")] ImRect rect, [NativeTypeName("ImGuiScrollFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igScrollToRectEx", ExactSpelling = true)]
        public static extern void ScrollToRectEx([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImGuiWindow* window, [NativeTypeName("const ImRect")] ImRect rect, [NativeTypeName("ImGuiScrollFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igScrollToBringRectIntoView", ExactSpelling = true)]
        public static extern void ScrollToBringRectIntoView(ImGuiWindow* window, [NativeTypeName("const ImRect")] ImRect rect);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetItemStatusFlags", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiItemStatusFlags")]
        public static extern int GetItemStatusFlags();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetItemFlags", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiItemFlags")]
        public static extern int GetItemFlags();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetActiveID", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetActiveID();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFocusID", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetFocusID();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetActiveID", ExactSpelling = true)]
        public static extern void SetActiveID([NativeTypeName("ImGuiID")] uint id, ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetFocusID", ExactSpelling = true)]
        public static extern void SetFocusID([NativeTypeName("ImGuiID")] uint id, ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igClearActiveID", ExactSpelling = true)]
        public static extern void ClearActiveID();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetHoveredID", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetHoveredID();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetHoveredID", ExactSpelling = true)]
        public static extern void SetHoveredID([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igKeepAliveID", ExactSpelling = true)]
        public static extern void KeepAliveID([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igMarkItemEdited", ExactSpelling = true)]
        public static extern void MarkItemEdited([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushOverrideID", ExactSpelling = true)]
        public static extern void PushOverrideID([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetIDWithSeed_Str", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetIDWithSeed_Str([NativeTypeName("const char *")] sbyte* str_id_begin, [NativeTypeName("const char *")] sbyte* str_id_end, [NativeTypeName("ImGuiID")] uint seed);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetIDWithSeed_Int", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetIDWithSeed_Int(int n, [NativeTypeName("ImGuiID")] uint seed);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igItemSize_Vec2", ExactSpelling = true)]
        public static extern void ItemSize_Vec2([NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, float text_baseline_y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igItemSize_Rect", ExactSpelling = true)]
        public static extern void ItemSize_Rect([NativeTypeName("const ImRect")] ImRect bb, float text_baseline_y);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igItemAdd", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ItemAdd([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const ImRect *")] ImRect* nav_bb, [NativeTypeName("ImGuiItemFlags")] int extra_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igItemHoverable", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ItemHoverable([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiItemFlags")] int item_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsWindowContentHoverable", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsWindowContentHoverable(ImGuiWindow* window, [NativeTypeName("ImGuiHoveredFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsClippedEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsClippedEx([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetLastItemData", ExactSpelling = true)]
        public static extern void SetLastItemData([NativeTypeName("ImGuiID")] uint item_id, [NativeTypeName("ImGuiItemFlags")] int item_flags, [NativeTypeName("ImGuiItemStatusFlags")] int status_flags, [NativeTypeName("const ImRect")] ImRect item_rect);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCalcItemSize", ExactSpelling = true)]
        public static extern void CalcItemSize([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("ImVec2")] System.Numerics.Vector2 size, float default_w, float default_h);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCalcWrapWidthForPos", ExactSpelling = true)]
        public static extern float CalcWrapWidthForPos([NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, float wrap_pos_x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushMultiItemsWidths", ExactSpelling = true)]
        public static extern void PushMultiItemsWidths(int components, float width_full);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShrinkWidths", ExactSpelling = true)]
        public static extern void ShrinkWidths(ImGuiShrinkWidthItem* items, int count, float width_excess, float width_min);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCalcClipRectVisibleItemsY", ExactSpelling = true)]
        public static extern void CalcClipRectVisibleItemsY([NativeTypeName("const ImRect")] ImRect clip_rect, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, float items_height, int* out_visible_start, int* out_visible_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetStyleVarInfo", ExactSpelling = true)]
        [return: NativeTypeName("const ImGuiStyleVarInfo *")]
        public static extern ImGuiStyleVarInfo* GetStyleVarInfo([NativeTypeName("ImGuiStyleVar")] int idx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginDisabledOverrideReenable", ExactSpelling = true)]
        public static extern void BeginDisabledOverrideReenable();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndDisabledOverrideReenable", ExactSpelling = true)]
        public static extern void EndDisabledOverrideReenable();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLogBegin", ExactSpelling = true)]
        public static extern void LogBegin([NativeTypeName("ImGuiLogFlags")] int flags, int auto_open_depth);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLogToBuffer", ExactSpelling = true)]
        public static extern void LogToBuffer(int auto_open_depth);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLogRenderedText", ExactSpelling = true)]
        public static extern void LogRenderedText([NativeTypeName("const ImVec2 *")] System.Numerics.Vector2* ref_pos, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igLogSetNextTextDecoration", ExactSpelling = true)]
        public static extern void LogSetNextTextDecoration([NativeTypeName("const char *")] sbyte* prefix, [NativeTypeName("const char *")] sbyte* suffix);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginChildEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginChildEx([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size_arg, [NativeTypeName("ImGuiChildFlags")] int child_flags, [NativeTypeName("ImGuiWindowFlags")] int window_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginPopupEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginPopupEx([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiWindowFlags")] int extra_window_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginPopupMenuEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginPopupMenuEx([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiWindowFlags")] int extra_window_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igOpenPopupEx", ExactSpelling = true)]
        public static extern void OpenPopupEx([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igClosePopupToLevel", ExactSpelling = true)]
        public static extern void ClosePopupToLevel(int remaining, [NativeTypeName("_Bool")] byte restore_focus_to_window_under_popup);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igClosePopupsOverWindow", ExactSpelling = true)]
        public static extern void ClosePopupsOverWindow(ImGuiWindow* ref_window, [NativeTypeName("_Bool")] byte restore_focus_to_window_under_popup);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igClosePopupsExceptModals", ExactSpelling = true)]
        public static extern void ClosePopupsExceptModals();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsPopupOpen_ID", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsPopupOpen_ID([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiPopupFlags")] int popup_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetPopupAllowedExtentRect", ExactSpelling = true)]
        public static extern void GetPopupAllowedExtentRect(ImRect* pOut, ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetTopMostPopupModal", ExactSpelling = true)]
        public static extern ImGuiWindow* GetTopMostPopupModal();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetTopMostAndVisiblePopupModal", ExactSpelling = true)]
        public static extern ImGuiWindow* GetTopMostAndVisiblePopupModal();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindBlockingModal", ExactSpelling = true)]
        public static extern ImGuiWindow* FindBlockingModal(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindBestWindowPosForPopup", ExactSpelling = true)]
        public static extern void FindBestWindowPosForPopup([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindBestWindowPosForPopupEx", ExactSpelling = true)]
        public static extern void FindBestWindowPosForPopupEx([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 ref_pos, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size, ImGuiDir* last_dir, [NativeTypeName("const ImRect")] ImRect r_outer, [NativeTypeName("const ImRect")] ImRect r_avoid, ImGuiPopupPositionPolicy policy);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginTooltipEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginTooltipEx([NativeTypeName("ImGuiTooltipFlags")] int tooltip_flags, [NativeTypeName("ImGuiWindowFlags")] int extra_window_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginTooltipHidden", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginTooltipHidden();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginViewportSideBar", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginViewportSideBar([NativeTypeName("const char *")] sbyte* name, ImGuiViewport* viewport, ImGuiDir dir, float size, [NativeTypeName("ImGuiWindowFlags")] int window_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginMenuEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginMenuEx([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* icon, [NativeTypeName("_Bool")] byte enabled);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igMenuItemEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte MenuItemEx([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* icon, [NativeTypeName("const char *")] sbyte* shortcut, [NativeTypeName("_Bool")] byte selected, [NativeTypeName("_Bool")] byte enabled);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginComboPopup", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginComboPopup([NativeTypeName("ImGuiID")] uint popup_id, [NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiComboFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginComboPreview", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginComboPreview();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndComboPreview", ExactSpelling = true)]
        public static extern void EndComboPreview();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNavInitWindow", ExactSpelling = true)]
        public static extern void NavInitWindow(ImGuiWindow* window, [NativeTypeName("_Bool")] byte force_reinit);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNavInitRequestApplyResult", ExactSpelling = true)]
        public static extern void NavInitRequestApplyResult();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNavMoveRequestButNoResultYet", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte NavMoveRequestButNoResultYet();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNavMoveRequestSubmit", ExactSpelling = true)]
        public static extern void NavMoveRequestSubmit(ImGuiDir move_dir, ImGuiDir clip_dir, [NativeTypeName("ImGuiNavMoveFlags")] int move_flags, [NativeTypeName("ImGuiScrollFlags")] int scroll_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNavMoveRequestForward", ExactSpelling = true)]
        public static extern void NavMoveRequestForward(ImGuiDir move_dir, ImGuiDir clip_dir, [NativeTypeName("ImGuiNavMoveFlags")] int move_flags, [NativeTypeName("ImGuiScrollFlags")] int scroll_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNavMoveRequestResolveWithLastItem", ExactSpelling = true)]
        public static extern void NavMoveRequestResolveWithLastItem(ImGuiNavItemData* result);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNavMoveRequestResolveWithPastTreeNode", ExactSpelling = true)]
        public static extern void NavMoveRequestResolveWithPastTreeNode(ImGuiNavItemData* result, [NativeTypeName("const ImGuiTreeNodeStackData *")] ImGuiTreeNodeStackData* tree_node_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNavMoveRequestCancel", ExactSpelling = true)]
        public static extern void NavMoveRequestCancel();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNavMoveRequestApplyResult", ExactSpelling = true)]
        public static extern void NavMoveRequestApplyResult();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNavMoveRequestTryWrapping", ExactSpelling = true)]
        public static extern void NavMoveRequestTryWrapping(ImGuiWindow* window, [NativeTypeName("ImGuiNavMoveFlags")] int move_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNavHighlightActivated", ExactSpelling = true)]
        public static extern void NavHighlightActivated([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNavClearPreferredPosForAxis", ExactSpelling = true)]
        public static extern void NavClearPreferredPosForAxis(ImGuiAxis axis);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNavCursorVisibleAfterMove", ExactSpelling = true)]
        public static extern void SetNavCursorVisibleAfterMove();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igNavUpdateCurrentWindowIsScrollPushableX", ExactSpelling = true)]
        public static extern void NavUpdateCurrentWindowIsScrollPushableX();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNavWindow", ExactSpelling = true)]
        public static extern void SetNavWindow(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNavID", ExactSpelling = true)]
        public static extern void SetNavID([NativeTypeName("ImGuiID")] uint id, ImGuiNavLayer nav_layer, [NativeTypeName("ImGuiID")] uint focus_scope_id, [NativeTypeName("const ImRect")] ImRect rect_rel);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNavFocusScope", ExactSpelling = true)]
        public static extern void SetNavFocusScope([NativeTypeName("ImGuiID")] uint focus_scope_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFocusItem", ExactSpelling = true)]
        public static extern void FocusItem();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igActivateItemByID", ExactSpelling = true)]
        public static extern void ActivateItemByID([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsNamedKey", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsNamedKey(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsNamedKeyOrMod", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsNamedKeyOrMod(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsLegacyKey", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsLegacyKey(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsKeyboardKey", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsKeyboardKey(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsGamepadKey", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsGamepadKey(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMouseKey", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMouseKey(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsAliasKey", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsAliasKey(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsLRModKey", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsLRModKey(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFixupKeyChord", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiKeyChord")]
        public static extern int FixupKeyChord([NativeTypeName("ImGuiKeyChord")] int key_chord);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igConvertSingleModFlagToKey", ExactSpelling = true)]
        public static extern ImGuiKey ConvertSingleModFlagToKey(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetKeyData_ContextPtr", ExactSpelling = true)]
        public static extern ImGuiKeyData* GetKeyData_ContextPtr(ImGuiContext* ctx, ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetKeyData_Key", ExactSpelling = true)]
        public static extern ImGuiKeyData* GetKeyData_Key(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetKeyChordName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetKeyChordName([NativeTypeName("ImGuiKeyChord")] int key_chord);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igMouseButtonToKey", ExactSpelling = true)]
        public static extern ImGuiKey MouseButtonToKey([NativeTypeName("ImGuiMouseButton")] int button);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMouseDragPastThreshold", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMouseDragPastThreshold([NativeTypeName("ImGuiMouseButton")] int button, float lock_threshold);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetKeyMagnitude2d", ExactSpelling = true)]
        public static extern void GetKeyMagnitude2d([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImGuiKey key_left, ImGuiKey key_right, ImGuiKey key_up, ImGuiKey key_down);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetNavTweakPressedAmount", ExactSpelling = true)]
        public static extern float GetNavTweakPressedAmount(ImGuiAxis axis);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCalcTypematicRepeatAmount", ExactSpelling = true)]
        public static extern int CalcTypematicRepeatAmount(float t0, float t1, float repeat_delay, float repeat_rate);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetTypematicRepeatRate", ExactSpelling = true)]
        public static extern void GetTypematicRepeatRate([NativeTypeName("ImGuiInputFlags")] int flags, float* repeat_delay, float* repeat_rate);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTeleportMousePos", ExactSpelling = true)]
        public static extern void TeleportMousePos([NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetActiveIdUsingAllKeyboardKeys", ExactSpelling = true)]
        public static extern void SetActiveIdUsingAllKeyboardKeys();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsActiveIdUsingNavDir", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsActiveIdUsingNavDir(ImGuiDir dir);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetKeyOwner", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetKeyOwner(ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetKeyOwner", ExactSpelling = true)]
        public static extern void SetKeyOwner(ImGuiKey key, [NativeTypeName("ImGuiID")] uint owner_id, [NativeTypeName("ImGuiInputFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetKeyOwnersForKeyChord", ExactSpelling = true)]
        public static extern void SetKeyOwnersForKeyChord([NativeTypeName("ImGuiKeyChord")] int key, [NativeTypeName("ImGuiID")] uint owner_id, [NativeTypeName("ImGuiInputFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetItemKeyOwner_InputFlags", ExactSpelling = true)]
        public static extern void SetItemKeyOwner_InputFlags(ImGuiKey key, [NativeTypeName("ImGuiInputFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTestKeyOwner", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TestKeyOwner(ImGuiKey key, [NativeTypeName("ImGuiID")] uint owner_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetKeyOwnerData", ExactSpelling = true)]
        public static extern ImGuiKeyOwnerData* GetKeyOwnerData(ImGuiContext* ctx, ImGuiKey key);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsKeyDown_ID", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsKeyDown_ID(ImGuiKey key, [NativeTypeName("ImGuiID")] uint owner_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsKeyPressed_InputFlags", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsKeyPressed_InputFlags(ImGuiKey key, [NativeTypeName("ImGuiInputFlags")] int flags, [NativeTypeName("ImGuiID")] uint owner_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsKeyReleased_ID", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsKeyReleased_ID(ImGuiKey key, [NativeTypeName("ImGuiID")] uint owner_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsKeyChordPressed_InputFlags", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsKeyChordPressed_InputFlags([NativeTypeName("ImGuiKeyChord")] int key_chord, [NativeTypeName("ImGuiInputFlags")] int flags, [NativeTypeName("ImGuiID")] uint owner_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMouseDown_ID", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMouseDown_ID([NativeTypeName("ImGuiMouseButton")] int button, [NativeTypeName("ImGuiID")] uint owner_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMouseClicked_InputFlags", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMouseClicked_InputFlags([NativeTypeName("ImGuiMouseButton")] int button, [NativeTypeName("ImGuiInputFlags")] int flags, [NativeTypeName("ImGuiID")] uint owner_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMouseReleased_ID", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMouseReleased_ID([NativeTypeName("ImGuiMouseButton")] int button, [NativeTypeName("ImGuiID")] uint owner_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsMouseDoubleClicked_ID", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsMouseDoubleClicked_ID([NativeTypeName("ImGuiMouseButton")] int button, [NativeTypeName("ImGuiID")] uint owner_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShortcut_ID", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte Shortcut_ID([NativeTypeName("ImGuiKeyChord")] int key_chord, [NativeTypeName("ImGuiInputFlags")] int flags, [NativeTypeName("ImGuiID")] uint owner_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetShortcutRouting", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SetShortcutRouting([NativeTypeName("ImGuiKeyChord")] int key_chord, [NativeTypeName("ImGuiInputFlags")] int flags, [NativeTypeName("ImGuiID")] uint owner_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTestShortcutRouting", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TestShortcutRouting([NativeTypeName("ImGuiKeyChord")] int key_chord, [NativeTypeName("ImGuiID")] uint owner_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetShortcutRoutingData", ExactSpelling = true)]
        public static extern ImGuiKeyRoutingData* GetShortcutRoutingData([NativeTypeName("ImGuiKeyChord")] int key_chord);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextInitialize", ExactSpelling = true)]
        public static extern void DockContextInitialize(ImGuiContext* ctx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextShutdown", ExactSpelling = true)]
        public static extern void DockContextShutdown(ImGuiContext* ctx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextClearNodes", ExactSpelling = true)]
        public static extern void DockContextClearNodes(ImGuiContext* ctx, [NativeTypeName("ImGuiID")] uint root_id, [NativeTypeName("_Bool")] byte clear_settings_refs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextRebuildNodes", ExactSpelling = true)]
        public static extern void DockContextRebuildNodes(ImGuiContext* ctx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextNewFrameUpdateUndocking", ExactSpelling = true)]
        public static extern void DockContextNewFrameUpdateUndocking(ImGuiContext* ctx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextNewFrameUpdateDocking", ExactSpelling = true)]
        public static extern void DockContextNewFrameUpdateDocking(ImGuiContext* ctx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextEndFrame", ExactSpelling = true)]
        public static extern void DockContextEndFrame(ImGuiContext* ctx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextGenNodeID", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint DockContextGenNodeID(ImGuiContext* ctx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextQueueDock", ExactSpelling = true)]
        public static extern void DockContextQueueDock(ImGuiContext* ctx, ImGuiWindow* target, ImGuiDockNode* target_node, ImGuiWindow* payload, ImGuiDir split_dir, float split_ratio, [NativeTypeName("_Bool")] byte split_outer);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextQueueUndockWindow", ExactSpelling = true)]
        public static extern void DockContextQueueUndockWindow(ImGuiContext* ctx, ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextQueueUndockNode", ExactSpelling = true)]
        public static extern void DockContextQueueUndockNode(ImGuiContext* ctx, ImGuiDockNode* node);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextProcessUndockWindow", ExactSpelling = true)]
        public static extern void DockContextProcessUndockWindow(ImGuiContext* ctx, ImGuiWindow* window, [NativeTypeName("_Bool")] byte clear_persistent_docking_ref);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextProcessUndockNode", ExactSpelling = true)]
        public static extern void DockContextProcessUndockNode(ImGuiContext* ctx, ImGuiDockNode* node);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextCalcDropPosForDocking", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DockContextCalcDropPosForDocking(ImGuiWindow* target, ImGuiDockNode* target_node, ImGuiWindow* payload_window, ImGuiDockNode* payload_node, ImGuiDir split_dir, [NativeTypeName("_Bool")] byte split_outer, [NativeTypeName("ImVec2 *")] System.Numerics.Vector2* out_pos);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockContextFindNodeByID", ExactSpelling = true)]
        public static extern ImGuiDockNode* DockContextFindNodeByID(ImGuiContext* ctx, [NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockNodeWindowMenuHandler_Default", ExactSpelling = true)]
        public static extern void DockNodeWindowMenuHandler_Default(ImGuiContext* ctx, ImGuiDockNode* node, ImGuiTabBar* tab_bar);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockNodeBeginAmendTabBar", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DockNodeBeginAmendTabBar(ImGuiDockNode* node);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockNodeEndAmendTabBar", ExactSpelling = true)]
        public static extern void DockNodeEndAmendTabBar();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockNodeGetRootNode", ExactSpelling = true)]
        public static extern ImGuiDockNode* DockNodeGetRootNode(ImGuiDockNode* node);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockNodeIsInHierarchyOf", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DockNodeIsInHierarchyOf(ImGuiDockNode* node, ImGuiDockNode* parent);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockNodeGetDepth", ExactSpelling = true)]
        public static extern int DockNodeGetDepth([NativeTypeName("const ImGuiDockNode *")] ImGuiDockNode* node);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockNodeGetWindowMenuButtonId", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint DockNodeGetWindowMenuButtonId([NativeTypeName("const ImGuiDockNode *")] ImGuiDockNode* node);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowDockNode", ExactSpelling = true)]
        public static extern ImGuiDockNode* GetWindowDockNode();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowAlwaysWantOwnTabBar", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte GetWindowAlwaysWantOwnTabBar(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginDocked", ExactSpelling = true)]
        public static extern void BeginDocked(ImGuiWindow* window, [NativeTypeName("_Bool *")] bool* p_open);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginDockableDragDropSource", ExactSpelling = true)]
        public static extern void BeginDockableDragDropSource(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginDockableDragDropTarget", ExactSpelling = true)]
        public static extern void BeginDockableDragDropTarget(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowDock", ExactSpelling = true)]
        public static extern void SetWindowDock(ImGuiWindow* window, [NativeTypeName("ImGuiID")] uint dock_id, [NativeTypeName("ImGuiCond")] int cond);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderDockWindow", ExactSpelling = true)]
        public static extern void DockBuilderDockWindow([NativeTypeName("const char *")] sbyte* window_name, [NativeTypeName("ImGuiID")] uint node_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderGetNode", ExactSpelling = true)]
        public static extern ImGuiDockNode* DockBuilderGetNode([NativeTypeName("ImGuiID")] uint node_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderGetCentralNode", ExactSpelling = true)]
        public static extern ImGuiDockNode* DockBuilderGetCentralNode([NativeTypeName("ImGuiID")] uint node_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderAddNode", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint DockBuilderAddNode([NativeTypeName("ImGuiID")] uint node_id, [NativeTypeName("ImGuiDockNodeFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderRemoveNode", ExactSpelling = true)]
        public static extern void DockBuilderRemoveNode([NativeTypeName("ImGuiID")] uint node_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderRemoveNodeDockedWindows", ExactSpelling = true)]
        public static extern void DockBuilderRemoveNodeDockedWindows([NativeTypeName("ImGuiID")] uint node_id, [NativeTypeName("_Bool")] byte clear_settings_refs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderRemoveNodeChildNodes", ExactSpelling = true)]
        public static extern void DockBuilderRemoveNodeChildNodes([NativeTypeName("ImGuiID")] uint node_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderSetNodePos", ExactSpelling = true)]
        public static extern void DockBuilderSetNodePos([NativeTypeName("ImGuiID")] uint node_id, [NativeTypeName("ImVec2")] System.Numerics.Vector2 pos);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderSetNodeSize", ExactSpelling = true)]
        public static extern void DockBuilderSetNodeSize([NativeTypeName("ImGuiID")] uint node_id, [NativeTypeName("ImVec2")] System.Numerics.Vector2 size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderSplitNode", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint DockBuilderSplitNode([NativeTypeName("ImGuiID")] uint node_id, ImGuiDir split_dir, float size_ratio_for_node_at_dir, [NativeTypeName("ImGuiID *")] uint* out_id_at_dir, [NativeTypeName("ImGuiID *")] uint* out_id_at_opposite_dir);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderCopyDockSpace", ExactSpelling = true)]
        public static extern void DockBuilderCopyDockSpace([NativeTypeName("ImGuiID")] uint src_dockspace_id, [NativeTypeName("ImGuiID")] uint dst_dockspace_id, ImVector_const_charPtr* in_window_remap_pairs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderCopyNode", ExactSpelling = true)]
        public static extern void DockBuilderCopyNode([NativeTypeName("ImGuiID")] uint src_node_id, [NativeTypeName("ImGuiID")] uint dst_node_id, ImVector_ImGuiID* out_node_remap_pairs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderCopyWindowSettings", ExactSpelling = true)]
        public static extern void DockBuilderCopyWindowSettings([NativeTypeName("const char *")] sbyte* src_name, [NativeTypeName("const char *")] sbyte* dst_name);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockBuilderFinish", ExactSpelling = true)]
        public static extern void DockBuilderFinish([NativeTypeName("ImGuiID")] uint node_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushFocusScope", ExactSpelling = true)]
        public static extern void PushFocusScope([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPopFocusScope", ExactSpelling = true)]
        public static extern void PopFocusScope();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCurrentFocusScope", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetCurrentFocusScope();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsDragDropActive", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsDragDropActive();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginDragDropTargetCustom", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginDragDropTargetCustom([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igClearDragDrop", ExactSpelling = true)]
        public static extern void ClearDragDrop();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsDragDropPayloadBeingAccepted", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsDragDropPayloadBeingAccepted();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderDragDropTargetRect", ExactSpelling = true)]
        public static extern void RenderDragDropTargetRect([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("const ImRect")] ImRect item_clip_rect);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetTypingSelectRequest", ExactSpelling = true)]
        public static extern ImGuiTypingSelectRequest* GetTypingSelectRequest([NativeTypeName("ImGuiTypingSelectFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTypingSelectFindMatch", ExactSpelling = true)]
        public static extern int TypingSelectFindMatch(ImGuiTypingSelectRequest* req, int items_count, [NativeTypeName("const char *(*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, sbyte*> get_item_name_func, void* user_data, int nav_item_idx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTypingSelectFindNextSingleCharMatch", ExactSpelling = true)]
        public static extern int TypingSelectFindNextSingleCharMatch(ImGuiTypingSelectRequest* req, int items_count, [NativeTypeName("const char *(*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, sbyte*> get_item_name_func, void* user_data, int nav_item_idx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTypingSelectFindBestLeadingMatch", ExactSpelling = true)]
        public static extern int TypingSelectFindBestLeadingMatch(ImGuiTypingSelectRequest* req, int items_count, [NativeTypeName("const char *(*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, sbyte*> get_item_name_func, void* user_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginBoxSelect", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginBoxSelect([NativeTypeName("const ImRect")] ImRect scope_rect, ImGuiWindow* window, [NativeTypeName("ImGuiID")] uint box_select_id, [NativeTypeName("ImGuiMultiSelectFlags")] int ms_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndBoxSelect", ExactSpelling = true)]
        public static extern void EndBoxSelect([NativeTypeName("const ImRect")] ImRect scope_rect, [NativeTypeName("ImGuiMultiSelectFlags")] int ms_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igMultiSelectItemHeader", ExactSpelling = true)]
        public static extern void MultiSelectItemHeader([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("_Bool *")] bool* p_selected, [NativeTypeName("ImGuiButtonFlags *")] int* p_button_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igMultiSelectItemFooter", ExactSpelling = true)]
        public static extern void MultiSelectItemFooter([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("_Bool *")] bool* p_selected, [NativeTypeName("_Bool *")] bool* p_pressed);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igMultiSelectAddSetAll", ExactSpelling = true)]
        public static extern void MultiSelectAddSetAll(ImGuiMultiSelectTempData* ms, [NativeTypeName("_Bool")] byte selected);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igMultiSelectAddSetRange", ExactSpelling = true)]
        public static extern void MultiSelectAddSetRange(ImGuiMultiSelectTempData* ms, [NativeTypeName("_Bool")] byte selected, int range_dir, [NativeTypeName("ImGuiSelectionUserData")] long first_item, [NativeTypeName("ImGuiSelectionUserData")] long last_item);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetBoxSelectState", ExactSpelling = true)]
        public static extern ImGuiBoxSelectState* GetBoxSelectState([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetMultiSelectState", ExactSpelling = true)]
        public static extern ImGuiMultiSelectState* GetMultiSelectState([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetWindowClipRectBeforeSetChannel", ExactSpelling = true)]
        public static extern void SetWindowClipRectBeforeSetChannel(ImGuiWindow* window, [NativeTypeName("const ImRect")] ImRect clip_rect);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginColumns", ExactSpelling = true)]
        public static extern void BeginColumns([NativeTypeName("const char *")] sbyte* str_id, int count, [NativeTypeName("ImGuiOldColumnFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndColumns", ExactSpelling = true)]
        public static extern void EndColumns();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushColumnClipRect", ExactSpelling = true)]
        public static extern void PushColumnClipRect(int column_index);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPushColumnsBackground", ExactSpelling = true)]
        public static extern void PushColumnsBackground();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPopColumnsBackground", ExactSpelling = true)]
        public static extern void PopColumnsBackground();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColumnsID", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetColumnsID([NativeTypeName("const char *")] sbyte* str_id, int count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindOrCreateColumns", ExactSpelling = true)]
        public static extern ImGuiOldColumns* FindOrCreateColumns(ImGuiWindow* window, [NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColumnOffsetFromNorm", ExactSpelling = true)]
        public static extern float GetColumnOffsetFromNorm([NativeTypeName("const ImGuiOldColumns *")] ImGuiOldColumns* columns, float offset_norm);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColumnNormFromOffset", ExactSpelling = true)]
        public static extern float GetColumnNormFromOffset([NativeTypeName("const ImGuiOldColumns *")] ImGuiOldColumns* columns, float offset);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableOpenContextMenu", ExactSpelling = true)]
        public static extern void TableOpenContextMenu(int column_n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSetColumnWidth", ExactSpelling = true)]
        public static extern void TableSetColumnWidth(int column_n, float width);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSetColumnSortDirection", ExactSpelling = true)]
        public static extern void TableSetColumnSortDirection(int column_n, ImGuiSortDirection sort_direction, [NativeTypeName("_Bool")] byte append_to_sort_specs);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetHoveredRow", ExactSpelling = true)]
        public static extern int TableGetHoveredRow();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetHeaderRowHeight", ExactSpelling = true)]
        public static extern float TableGetHeaderRowHeight();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetHeaderAngledMaxLabelWidth", ExactSpelling = true)]
        public static extern float TableGetHeaderAngledMaxLabelWidth();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTablePushBackgroundChannel", ExactSpelling = true)]
        public static extern void TablePushBackgroundChannel();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTablePopBackgroundChannel", ExactSpelling = true)]
        public static extern void TablePopBackgroundChannel();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTablePushColumnChannel", ExactSpelling = true)]
        public static extern void TablePushColumnChannel(int column_n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTablePopColumnChannel", ExactSpelling = true)]
        public static extern void TablePopColumnChannel();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableAngledHeadersRowEx", ExactSpelling = true)]
        public static extern void TableAngledHeadersRowEx([NativeTypeName("ImGuiID")] uint row_id, float angle, float max_label_width, [NativeTypeName("const ImGuiTableHeaderData *")] ImGuiTableHeaderData* data, int data_count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCurrentTable", ExactSpelling = true)]
        public static extern ImGuiTable* GetCurrentTable();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableFindByID", ExactSpelling = true)]
        public static extern ImGuiTable* TableFindByID([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginTableEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginTableEx([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("ImGuiID")] uint id, int columns_count, [NativeTypeName("ImGuiTableFlags")] int flags, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 outer_size, float inner_width);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableBeginInitMemory", ExactSpelling = true)]
        public static extern void TableBeginInitMemory(ImGuiTable* table, int columns_count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableBeginApplyRequests", ExactSpelling = true)]
        public static extern void TableBeginApplyRequests(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSetupDrawChannels", ExactSpelling = true)]
        public static extern void TableSetupDrawChannels(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableUpdateLayout", ExactSpelling = true)]
        public static extern void TableUpdateLayout(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableUpdateBorders", ExactSpelling = true)]
        public static extern void TableUpdateBorders(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableUpdateColumnsWeightFromWidth", ExactSpelling = true)]
        public static extern void TableUpdateColumnsWeightFromWidth(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableDrawBorders", ExactSpelling = true)]
        public static extern void TableDrawBorders(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableDrawDefaultContextMenu", ExactSpelling = true)]
        public static extern void TableDrawDefaultContextMenu(ImGuiTable* table, [NativeTypeName("ImGuiTableFlags")] int flags_for_section_to_display);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableBeginContextMenuPopup", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TableBeginContextMenuPopup(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableMergeDrawChannels", ExactSpelling = true)]
        public static extern void TableMergeDrawChannels(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetInstanceData", ExactSpelling = true)]
        public static extern ImGuiTableInstanceData* TableGetInstanceData(ImGuiTable* table, int instance_no);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetInstanceID", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint TableGetInstanceID(ImGuiTable* table, int instance_no);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSortSpecsSanitize", ExactSpelling = true)]
        public static extern void TableSortSpecsSanitize(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSortSpecsBuild", ExactSpelling = true)]
        public static extern void TableSortSpecsBuild(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetColumnNextSortDirection", ExactSpelling = true)]
        public static extern ImGuiSortDirection TableGetColumnNextSortDirection(ImGuiTableColumn* column);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableFixColumnSortDirection", ExactSpelling = true)]
        public static extern void TableFixColumnSortDirection(ImGuiTable* table, ImGuiTableColumn* column);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetColumnWidthAuto", ExactSpelling = true)]
        public static extern float TableGetColumnWidthAuto(ImGuiTable* table, ImGuiTableColumn* column);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableBeginRow", ExactSpelling = true)]
        public static extern void TableBeginRow(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableEndRow", ExactSpelling = true)]
        public static extern void TableEndRow(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableBeginCell", ExactSpelling = true)]
        public static extern void TableBeginCell(ImGuiTable* table, int column_n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableEndCell", ExactSpelling = true)]
        public static extern void TableEndCell(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetCellBgRect", ExactSpelling = true)]
        public static extern void TableGetCellBgRect(ImRect* pOut, [NativeTypeName("const ImGuiTable *")] ImGuiTable* table, int column_n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetColumnName_TablePtr", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* TableGetColumnName_TablePtr([NativeTypeName("const ImGuiTable *")] ImGuiTable* table, int column_n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetColumnResizeID", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint TableGetColumnResizeID(ImGuiTable* table, int column_n, int instance_no);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableCalcMaxColumnWidth", ExactSpelling = true)]
        public static extern float TableCalcMaxColumnWidth([NativeTypeName("const ImGuiTable *")] ImGuiTable* table, int column_n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSetColumnWidthAutoSingle", ExactSpelling = true)]
        public static extern void TableSetColumnWidthAutoSingle(ImGuiTable* table, int column_n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSetColumnWidthAutoAll", ExactSpelling = true)]
        public static extern void TableSetColumnWidthAutoAll(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableRemove", ExactSpelling = true)]
        public static extern void TableRemove(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGcCompactTransientBuffers_TablePtr", ExactSpelling = true)]
        public static extern void TableGcCompactTransientBuffers_TablePtr(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGcCompactTransientBuffers_TableTempDataPtr", ExactSpelling = true)]
        public static extern void TableGcCompactTransientBuffers_TableTempDataPtr(ImGuiTableTempData* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGcCompactSettings", ExactSpelling = true)]
        public static extern void TableGcCompactSettings();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableLoadSettings", ExactSpelling = true)]
        public static extern void TableLoadSettings(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSaveSettings", ExactSpelling = true)]
        public static extern void TableSaveSettings(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableResetSettings", ExactSpelling = true)]
        public static extern void TableResetSettings(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableGetBoundSettings", ExactSpelling = true)]
        public static extern ImGuiTableSettings* TableGetBoundSettings(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSettingsAddSettingsHandler", ExactSpelling = true)]
        public static extern void TableSettingsAddSettingsHandler();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSettingsCreate", ExactSpelling = true)]
        public static extern ImGuiTableSettings* TableSettingsCreate([NativeTypeName("ImGuiID")] uint id, int columns_count);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTableSettingsFindByID", ExactSpelling = true)]
        public static extern ImGuiTableSettings* TableSettingsFindByID([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCurrentTabBar", ExactSpelling = true)]
        public static extern ImGuiTabBar* GetCurrentTabBar();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarFindByID", ExactSpelling = true)]
        public static extern ImGuiTabBar* TabBarFindByID([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarRemove", ExactSpelling = true)]
        public static extern void TabBarRemove(ImGuiTabBar* tab_bar);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginTabBarEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginTabBarEx(ImGuiTabBar* tab_bar, [NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiTabBarFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarFindTabByID", ExactSpelling = true)]
        public static extern ImGuiTabItem* TabBarFindTabByID(ImGuiTabBar* tab_bar, [NativeTypeName("ImGuiID")] uint tab_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarFindTabByOrder", ExactSpelling = true)]
        public static extern ImGuiTabItem* TabBarFindTabByOrder(ImGuiTabBar* tab_bar, int order);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarFindMostRecentlySelectedTabForActiveWindow", ExactSpelling = true)]
        public static extern ImGuiTabItem* TabBarFindMostRecentlySelectedTabForActiveWindow(ImGuiTabBar* tab_bar);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarGetCurrentTab", ExactSpelling = true)]
        public static extern ImGuiTabItem* TabBarGetCurrentTab(ImGuiTabBar* tab_bar);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarGetTabOrder", ExactSpelling = true)]
        public static extern int TabBarGetTabOrder(ImGuiTabBar* tab_bar, ImGuiTabItem* tab);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarGetTabName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* TabBarGetTabName(ImGuiTabBar* tab_bar, ImGuiTabItem* tab);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarAddTab", ExactSpelling = true)]
        public static extern void TabBarAddTab(ImGuiTabBar* tab_bar, [NativeTypeName("ImGuiTabItemFlags")] int tab_flags, ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarRemoveTab", ExactSpelling = true)]
        public static extern void TabBarRemoveTab(ImGuiTabBar* tab_bar, [NativeTypeName("ImGuiID")] uint tab_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarCloseTab", ExactSpelling = true)]
        public static extern void TabBarCloseTab(ImGuiTabBar* tab_bar, ImGuiTabItem* tab);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarQueueFocus_TabItemPtr", ExactSpelling = true)]
        public static extern void TabBarQueueFocus_TabItemPtr(ImGuiTabBar* tab_bar, ImGuiTabItem* tab);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarQueueFocus_Str", ExactSpelling = true)]
        public static extern void TabBarQueueFocus_Str(ImGuiTabBar* tab_bar, [NativeTypeName("const char *")] sbyte* tab_name);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarQueueReorder", ExactSpelling = true)]
        public static extern void TabBarQueueReorder(ImGuiTabBar* tab_bar, ImGuiTabItem* tab, int offset);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarQueueReorderFromMousePos", ExactSpelling = true)]
        public static extern void TabBarQueueReorderFromMousePos(ImGuiTabBar* tab_bar, ImGuiTabItem* tab, [NativeTypeName("ImVec2")] System.Numerics.Vector2 mouse_pos);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabBarProcessReorder", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TabBarProcessReorder(ImGuiTabBar* tab_bar);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabItemEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TabItemEx(ImGuiTabBar* tab_bar, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("_Bool *")] bool* p_open, [NativeTypeName("ImGuiTabItemFlags")] int flags, ImGuiWindow* docked_window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabItemSpacing", ExactSpelling = true)]
        public static extern void TabItemSpacing([NativeTypeName("const char *")] sbyte* str_id, [NativeTypeName("ImGuiTabItemFlags")] int flags, float width);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabItemCalcSize_Str", ExactSpelling = true)]
        public static extern void TabItemCalcSize_Str([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("_Bool")] byte has_close_button_or_unsaved_marker);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabItemCalcSize_WindowPtr", ExactSpelling = true)]
        public static extern void TabItemCalcSize_WindowPtr([NativeTypeName("ImVec2 *")] System.Numerics.Vector2* pOut, ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabItemBackground", ExactSpelling = true)]
        public static extern void TabItemBackground(ImDrawList* draw_list, [NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiTabItemFlags")] int flags, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTabItemLabelAndCloseButton", ExactSpelling = true)]
        public static extern void TabItemLabelAndCloseButton(ImDrawList* draw_list, [NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiTabItemFlags")] int flags, [NativeTypeName("ImVec2")] System.Numerics.Vector2 frame_padding, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiID")] uint tab_id, [NativeTypeName("ImGuiID")] uint close_button_id, [NativeTypeName("_Bool")] byte is_contents_visible, [NativeTypeName("_Bool *")] bool* out_just_closed, [NativeTypeName("_Bool *")] bool* out_text_clipped);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderText", ExactSpelling = true)]
        public static extern void RenderText([NativeTypeName("ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("_Bool")] byte hide_text_after_hash);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderTextWrapped", ExactSpelling = true)]
        public static extern void RenderTextWrapped([NativeTypeName("ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, float wrap_width);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderTextClipped", ExactSpelling = true)]
        public static extern void RenderTextClipped([NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos_max, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("const ImVec2 *")] System.Numerics.Vector2* text_size_if_known, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 align, [NativeTypeName("const ImRect *")] ImRect* clip_rect);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderTextClippedEx", ExactSpelling = true)]
        public static extern void RenderTextClippedEx(ImDrawList* draw_list, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos_max, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("const ImVec2 *")] System.Numerics.Vector2* text_size_if_known, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 align, [NativeTypeName("const ImRect *")] ImRect* clip_rect);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderTextEllipsis", ExactSpelling = true)]
        public static extern void RenderTextEllipsis(ImDrawList* draw_list, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos_min, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos_max, float ellipsis_max_x, [NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("const ImVec2 *")] System.Numerics.Vector2* text_size_if_known);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderFrame", ExactSpelling = true)]
        public static extern void RenderFrame([NativeTypeName("ImVec2")] System.Numerics.Vector2 p_min, [NativeTypeName("ImVec2")] System.Numerics.Vector2 p_max, [NativeTypeName("ImU32")] uint fill_col, [NativeTypeName("_Bool")] byte borders, float rounding);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderFrameBorder", ExactSpelling = true)]
        public static extern void RenderFrameBorder([NativeTypeName("ImVec2")] System.Numerics.Vector2 p_min, [NativeTypeName("ImVec2")] System.Numerics.Vector2 p_max, float rounding);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderColorRectWithAlphaCheckerboard", ExactSpelling = true)]
        public static extern void RenderColorRectWithAlphaCheckerboard(ImDrawList* draw_list, [NativeTypeName("ImVec2")] System.Numerics.Vector2 p_min, [NativeTypeName("ImVec2")] System.Numerics.Vector2 p_max, [NativeTypeName("ImU32")] uint fill_col, float grid_step, [NativeTypeName("ImVec2")] System.Numerics.Vector2 grid_off, float rounding, [NativeTypeName("ImDrawFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderNavCursor", ExactSpelling = true)]
        public static extern void RenderNavCursor([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiNavRenderCursorFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindRenderedTextEnd", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* FindRenderedTextEnd([NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderMouseCursor", ExactSpelling = true)]
        public static extern void RenderMouseCursor([NativeTypeName("ImVec2")] System.Numerics.Vector2 pos, float scale, [NativeTypeName("ImGuiMouseCursor")] int mouse_cursor, [NativeTypeName("ImU32")] uint col_fill, [NativeTypeName("ImU32")] uint col_border, [NativeTypeName("ImU32")] uint col_shadow);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderArrow", ExactSpelling = true)]
        public static extern void RenderArrow(ImDrawList* draw_list, [NativeTypeName("ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("ImU32")] uint col, ImGuiDir dir, float scale);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderBullet", ExactSpelling = true)]
        public static extern void RenderBullet(ImDrawList* draw_list, [NativeTypeName("ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderCheckMark", ExactSpelling = true)]
        public static extern void RenderCheckMark(ImDrawList* draw_list, [NativeTypeName("ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("ImU32")] uint col, float sz);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderArrowPointingAt", ExactSpelling = true)]
        public static extern void RenderArrowPointingAt(ImDrawList* draw_list, [NativeTypeName("ImVec2")] System.Numerics.Vector2 pos, [NativeTypeName("ImVec2")] System.Numerics.Vector2 half_sz, ImGuiDir direction, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderArrowDockMenu", ExactSpelling = true)]
        public static extern void RenderArrowDockMenu(ImDrawList* draw_list, [NativeTypeName("ImVec2")] System.Numerics.Vector2 p_min, float sz, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderRectFilledRangeH", ExactSpelling = true)]
        public static extern void RenderRectFilledRangeH(ImDrawList* draw_list, [NativeTypeName("const ImRect")] ImRect rect, [NativeTypeName("ImU32")] uint col, float x_start_norm, float x_end_norm, float rounding);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igRenderRectFilledWithHole", ExactSpelling = true)]
        public static extern void RenderRectFilledWithHole(ImDrawList* draw_list, [NativeTypeName("const ImRect")] ImRect outer, [NativeTypeName("const ImRect")] ImRect inner, [NativeTypeName("ImU32")] uint col, float rounding);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCalcRoundingFlagsForRectInRect", ExactSpelling = true)]
        [return: NativeTypeName("ImDrawFlags")]
        public static extern int CalcRoundingFlagsForRectInRect([NativeTypeName("const ImRect")] ImRect r_in, [NativeTypeName("const ImRect")] ImRect r_outer, float threshold);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTextEx", ExactSpelling = true)]
        public static extern void TextEx([NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const char *")] sbyte* text_end, [NativeTypeName("ImGuiTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTextAligned", ExactSpelling = true)]
        public static extern void TextAligned(float align_x, float size_x, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTextAlignedV", ExactSpelling = true)]
        public static extern void TextAlignedV(float align_x, float size_x, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igButtonEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ButtonEx([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size_arg, [NativeTypeName("ImGuiButtonFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igArrowButtonEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ArrowButtonEx([NativeTypeName("const char *")] sbyte* str_id, ImGuiDir dir, [NativeTypeName("ImVec2")] System.Numerics.Vector2 size_arg, [NativeTypeName("ImGuiButtonFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImageButtonEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImageButtonEx([NativeTypeName("ImGuiID")] uint id, ImTextureRef tex_ref, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 image_size, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv0, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv1, [NativeTypeName("const ImVec4")] System.Numerics.Vector4 bg_col, [NativeTypeName("const ImVec4")] System.Numerics.Vector4 tint_col, [NativeTypeName("ImGuiButtonFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSeparatorEx", ExactSpelling = true)]
        public static extern void SeparatorEx([NativeTypeName("ImGuiSeparatorFlags")] int flags, float thickness);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSeparatorTextEx", ExactSpelling = true)]
        public static extern void SeparatorTextEx([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* label_end, float extra_width);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCheckboxFlags_S64Ptr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte CheckboxFlags_S64Ptr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImS64 *")] long* flags, [NativeTypeName("ImS64")] long flags_value);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCheckboxFlags_U64Ptr", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte CheckboxFlags_U64Ptr([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImU64 *")] ulong* flags, [NativeTypeName("ImU64")] ulong flags_value);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCloseButton", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte CloseButton([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCollapseButton", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte CollapseButton([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pos, ImGuiDockNode* dock_node);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igScrollbar", ExactSpelling = true)]
        public static extern void Scrollbar(ImGuiAxis axis);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igScrollbarEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ScrollbarEx([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, ImGuiAxis axis, [NativeTypeName("ImS64 *")] long* p_scroll_v, [NativeTypeName("ImS64")] long avail_v, [NativeTypeName("ImS64")] long contents_v, [NativeTypeName("ImDrawFlags")] int draw_rounding_flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowScrollbarRect", ExactSpelling = true)]
        public static extern void GetWindowScrollbarRect(ImRect* pOut, ImGuiWindow* window, ImGuiAxis axis);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowScrollbarID", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetWindowScrollbarID(ImGuiWindow* window, ImGuiAxis axis);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowResizeCornerID", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetWindowResizeCornerID(ImGuiWindow* window, int n);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetWindowResizeBorderID", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint GetWindowResizeBorderID(ImGuiWindow* window, ImGuiDir dir);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igButtonBehavior", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ButtonBehavior([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("_Bool *")] bool* out_hovered, [NativeTypeName("_Bool *")] bool* out_held, [NativeTypeName("ImGuiButtonFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragBehavior", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DragBehavior([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiDataType")] int data_type, void* p_v, float v_speed, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSliderBehavior", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SliderBehavior([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiDataType")] int data_type, void* p_v, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("ImGuiSliderFlags")] int flags, ImRect* out_grab_bb);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSplitterBehavior", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte SplitterBehavior([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, ImGuiAxis axis, float* size1, float* size2, float min_size1, float min_size2, float hover_extend, float hover_visibility_delay, [NativeTypeName("ImU32")] uint bg_col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNodeBehavior", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TreeNodeBehavior([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiTreeNodeFlags")] int flags, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* label_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNodeDrawLineToChildNode", ExactSpelling = true)]
        public static extern void TreeNodeDrawLineToChildNode([NativeTypeName("const ImVec2")] System.Numerics.Vector2 target_pos);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNodeDrawLineToTreePop", ExactSpelling = true)]
        public static extern void TreeNodeDrawLineToTreePop([NativeTypeName("const ImGuiTreeNodeStackData *")] ImGuiTreeNodeStackData* data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreePushOverrideID", ExactSpelling = true)]
        public static extern void TreePushOverrideID([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNodeGetOpen", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TreeNodeGetOpen([NativeTypeName("ImGuiID")] uint storage_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNodeSetOpen", ExactSpelling = true)]
        public static extern void TreeNodeSetOpen([NativeTypeName("ImGuiID")] uint storage_id, [NativeTypeName("_Bool")] byte open);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTreeNodeUpdateNextOpen", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TreeNodeUpdateNextOpen([NativeTypeName("ImGuiID")] uint storage_id, [NativeTypeName("ImGuiTreeNodeFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDataTypeGetInfo", ExactSpelling = true)]
        [return: NativeTypeName("const ImGuiDataTypeInfo *")]
        public static extern ImGuiDataTypeInfo* DataTypeGetInfo([NativeTypeName("ImGuiDataType")] int data_type);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDataTypeFormatString", ExactSpelling = true)]
        public static extern int DataTypeFormatString([NativeTypeName("char *")] sbyte* buf, int buf_size, [NativeTypeName("ImGuiDataType")] int data_type, [NativeTypeName("const void *")] void* p_data, [NativeTypeName("const char *")] sbyte* format);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDataTypeApplyOp", ExactSpelling = true)]
        public static extern void DataTypeApplyOp([NativeTypeName("ImGuiDataType")] int data_type, int op, void* output, [NativeTypeName("const void *")] void* arg_1, [NativeTypeName("const void *")] void* arg_2);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDataTypeApplyFromText", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DataTypeApplyFromText([NativeTypeName("const char *")] sbyte* buf, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, [NativeTypeName("const char *")] sbyte* format, void* p_data_when_empty);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDataTypeCompare", ExactSpelling = true)]
        public static extern int DataTypeCompare([NativeTypeName("ImGuiDataType")] int data_type, [NativeTypeName("const void *")] void* arg_1, [NativeTypeName("const void *")] void* arg_2);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDataTypeClamp", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DataTypeClamp([NativeTypeName("ImGuiDataType")] int data_type, void* p_data, [NativeTypeName("const void *")] void* p_min, [NativeTypeName("const void *")] void* p_max);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDataTypeIsZero", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DataTypeIsZero([NativeTypeName("ImGuiDataType")] int data_type, [NativeTypeName("const void *")] void* p_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputTextEx", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte InputTextEx([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* hint, [NativeTypeName("char *")] sbyte* buf, int buf_size, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size_arg, [NativeTypeName("ImGuiInputTextFlags")] int flags, [NativeTypeName("ImGuiInputTextCallback")] delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback, void* user_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igInputTextDeactivateHook", ExactSpelling = true)]
        public static extern void InputTextDeactivateHook([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTempInputText", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TempInputText([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("char *")] sbyte* buf, int buf_size, [NativeTypeName("ImGuiInputTextFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTempInputScalar", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TempInputScalar([NativeTypeName("const ImRect")] ImRect bb, [NativeTypeName("ImGuiID")] uint id, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("ImGuiDataType")] int data_type, void* p_data, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("const void *")] void* p_clamp_min, [NativeTypeName("const void *")] void* p_clamp_max);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igTempInputIsActive", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TempInputIsActive([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetInputTextState", ExactSpelling = true)]
        public static extern ImGuiInputTextState* GetInputTextState([NativeTypeName("ImGuiID")] uint id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igSetNextItemRefVal", ExactSpelling = true)]
        public static extern void SetNextItemRefVal([NativeTypeName("ImGuiDataType")] int data_type, void* p_data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igIsItemActiveAsInputText", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte IsItemActiveAsInputText();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorTooltip", ExactSpelling = true)]
        public static extern void ColorTooltip([NativeTypeName("const char *")] sbyte* text, [NativeTypeName("const float *")] float* col, [NativeTypeName("ImGuiColorEditFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorEditOptionsPopup", ExactSpelling = true)]
        public static extern void ColorEditOptionsPopup([NativeTypeName("const float *")] float* col, [NativeTypeName("ImGuiColorEditFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorPickerOptionsPopup", ExactSpelling = true)]
        public static extern void ColorPickerOptionsPopup([NativeTypeName("const float *")] float* ref_col, [NativeTypeName("ImGuiColorEditFlags")] int flags);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igPlotEx", ExactSpelling = true)]
        public static extern int PlotEx(ImGuiPlotType plot_type, [NativeTypeName("const char *")] sbyte* label, [NativeTypeName("float (*)(void *, int)")] delegate* unmanaged[Cdecl]<void*, int, float> values_getter, void* data, int values_count, int values_offset, [NativeTypeName("const char *")] sbyte* overlay_text, float scale_min, float scale_max, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 size_arg);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShadeVertsLinearColorGradientKeepAlpha", ExactSpelling = true)]
        public static extern void ShadeVertsLinearColorGradientKeepAlpha(ImDrawList* draw_list, int vert_start_idx, int vert_end_idx, [NativeTypeName("ImVec2")] System.Numerics.Vector2 gradient_p0, [NativeTypeName("ImVec2")] System.Numerics.Vector2 gradient_p1, [NativeTypeName("ImU32")] uint col0, [NativeTypeName("ImU32")] uint col1);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShadeVertsLinearUV", ExactSpelling = true)]
        public static extern void ShadeVertsLinearUV(ImDrawList* draw_list, int vert_start_idx, int vert_end_idx, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 b, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv_a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 uv_b, [NativeTypeName("_Bool")] byte clamp);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShadeVertsTransformPos", ExactSpelling = true)]
        public static extern void ShadeVertsTransformPos(ImDrawList* draw_list, int vert_start_idx, int vert_end_idx, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pivot_in, float cos_a, float sin_a, [NativeTypeName("const ImVec2")] System.Numerics.Vector2 pivot_out);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGcCompactTransientMiscBuffers", ExactSpelling = true)]
        public static extern void GcCompactTransientMiscBuffers();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGcCompactTransientWindowBuffers", ExactSpelling = true)]
        public static extern void GcCompactTransientWindowBuffers(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGcAwakeTransientWindowBuffers", ExactSpelling = true)]
        public static extern void GcAwakeTransientWindowBuffers(ImGuiWindow* window);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igErrorLog", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ErrorLog([NativeTypeName("const char *")] sbyte* msg);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igErrorRecoveryStoreState", ExactSpelling = true)]
        public static extern void ErrorRecoveryStoreState(ImGuiErrorRecoveryState* state_out);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igErrorRecoveryTryToRecoverState", ExactSpelling = true)]
        public static extern void ErrorRecoveryTryToRecoverState([NativeTypeName("const ImGuiErrorRecoveryState *")] ImGuiErrorRecoveryState* state_in);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igErrorRecoveryTryToRecoverWindowState", ExactSpelling = true)]
        public static extern void ErrorRecoveryTryToRecoverWindowState([NativeTypeName("const ImGuiErrorRecoveryState *")] ImGuiErrorRecoveryState* state_in);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igErrorCheckUsingSetCursorPosToExtendParentBoundaries", ExactSpelling = true)]
        public static extern void ErrorCheckUsingSetCursorPosToExtendParentBoundaries();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igErrorCheckEndFrameFinalizeErrorTooltip", ExactSpelling = true)]
        public static extern void ErrorCheckEndFrameFinalizeErrorTooltip();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginErrorTooltip", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte BeginErrorTooltip();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndErrorTooltip", ExactSpelling = true)]
        public static extern void EndErrorTooltip();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugAllocHook", ExactSpelling = true)]
        public static extern void DebugAllocHook(ImGuiDebugAllocInfo* info, int frame_count, void* ptr, [NativeTypeName("size_t")] nuint size);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugDrawCursorPos", ExactSpelling = true)]
        public static extern void DebugDrawCursorPos([NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugDrawLineExtents", ExactSpelling = true)]
        public static extern void DebugDrawLineExtents([NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugDrawItemRect", ExactSpelling = true)]
        public static extern void DebugDrawItemRect([NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugTextUnformattedWithLocateItem", ExactSpelling = true)]
        public static extern void DebugTextUnformattedWithLocateItem([NativeTypeName("const char *")] sbyte* line_begin, [NativeTypeName("const char *")] sbyte* line_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugLocateItem", ExactSpelling = true)]
        public static extern void DebugLocateItem([NativeTypeName("ImGuiID")] uint target_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugLocateItemOnHover", ExactSpelling = true)]
        public static extern void DebugLocateItemOnHover([NativeTypeName("ImGuiID")] uint target_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugLocateItemResolveWithLastItem", ExactSpelling = true)]
        public static extern void DebugLocateItemResolveWithLastItem();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugBreakClearData", ExactSpelling = true)]
        public static extern void DebugBreakClearData();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugBreakButton", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte DebugBreakButton([NativeTypeName("const char *")] sbyte* label, [NativeTypeName("const char *")] sbyte* description_of_location);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugBreakButtonTooltip", ExactSpelling = true)]
        public static extern void DebugBreakButtonTooltip([NativeTypeName("_Bool")] byte keyboard_only, [NativeTypeName("const char *")] sbyte* description_of_location);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igShowFontAtlas", ExactSpelling = true)]
        public static extern void ShowFontAtlas(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugHookIdInfo", ExactSpelling = true)]
        public static extern void DebugHookIdInfo([NativeTypeName("ImGuiID")] uint id, [NativeTypeName("ImGuiDataType")] int data_type, [NativeTypeName("const void *")] void* data_id, [NativeTypeName("const void *")] void* data_id_end);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeColumns", ExactSpelling = true)]
        public static extern void DebugNodeColumns(ImGuiOldColumns* columns);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeDockNode", ExactSpelling = true)]
        public static extern void DebugNodeDockNode(ImGuiDockNode* node, [NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeDrawList", ExactSpelling = true)]
        public static extern void DebugNodeDrawList(ImGuiWindow* window, ImGuiViewportP* viewport, [NativeTypeName("const ImDrawList *")] ImDrawList* draw_list, [NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeDrawCmdShowMeshAndBoundingBox", ExactSpelling = true)]
        public static extern void DebugNodeDrawCmdShowMeshAndBoundingBox(ImDrawList* out_draw_list, [NativeTypeName("const ImDrawList *")] ImDrawList* draw_list, [NativeTypeName("const ImDrawCmd *")] ImDrawCmd* draw_cmd, [NativeTypeName("_Bool")] byte show_mesh, [NativeTypeName("_Bool")] byte show_aabb);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeFont", ExactSpelling = true)]
        public static extern void DebugNodeFont(ImFont* font);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeFontGlyphesForSrcMask", ExactSpelling = true)]
        public static extern void DebugNodeFontGlyphesForSrcMask(ImFont* font, ImFontBaked* baked, int src_mask);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeFontGlyph", ExactSpelling = true)]
        public static extern void DebugNodeFontGlyph(ImFont* font, [NativeTypeName("const ImFontGlyph *")] ImFontGlyph* glyph);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeTexture", ExactSpelling = true)]
        public static extern void DebugNodeTexture(ImTextureData* tex, int int_id, [NativeTypeName("const ImFontAtlasRect *")] ImFontAtlasRect* highlight_rect);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeStorage", ExactSpelling = true)]
        public static extern void DebugNodeStorage(ImGuiStorage* storage, [NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeTabBar", ExactSpelling = true)]
        public static extern void DebugNodeTabBar(ImGuiTabBar* tab_bar, [NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeTable", ExactSpelling = true)]
        public static extern void DebugNodeTable(ImGuiTable* table);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeTableSettings", ExactSpelling = true)]
        public static extern void DebugNodeTableSettings(ImGuiTableSettings* settings);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeInputTextState", ExactSpelling = true)]
        public static extern void DebugNodeInputTextState(ImGuiInputTextState* state);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeTypingSelectState", ExactSpelling = true)]
        public static extern void DebugNodeTypingSelectState(ImGuiTypingSelectState* state);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeMultiSelectState", ExactSpelling = true)]
        public static extern void DebugNodeMultiSelectState(ImGuiMultiSelectState* state);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeWindow", ExactSpelling = true)]
        public static extern void DebugNodeWindow(ImGuiWindow* window, [NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeWindowSettings", ExactSpelling = true)]
        public static extern void DebugNodeWindowSettings(ImGuiWindowSettings* settings);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeWindowsList", ExactSpelling = true)]
        public static extern void DebugNodeWindowsList(ImVector_ImGuiWindowPtr* windows, [NativeTypeName("const char *")] sbyte* label);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeWindowsListByBeginStackParent", ExactSpelling = true)]
        public static extern void DebugNodeWindowsListByBeginStackParent(ImGuiWindow** windows, int windows_size, ImGuiWindow* parent_in_begin_stack);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodeViewport", ExactSpelling = true)]
        public static extern void DebugNodeViewport(ImGuiViewportP* viewport);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugNodePlatformMonitor", ExactSpelling = true)]
        public static extern void DebugNodePlatformMonitor(ImGuiPlatformMonitor* monitor, [NativeTypeName("const char *")] sbyte* label, int idx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugRenderKeyboardPreview", ExactSpelling = true)]
        public static extern void DebugRenderKeyboardPreview(ImDrawList* draw_list);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugRenderViewportThumbnail", ExactSpelling = true)]
        public static extern void DebugRenderViewportThumbnail(ImDrawList* draw_list, ImGuiViewportP* viewport, [NativeTypeName("const ImRect")] ImRect bb);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFontLoader* ImFontLoader_ImFontLoader();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontLoader_destroy(ImFontLoader* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasGetFontLoaderForStbTruetype", ExactSpelling = true)]
        [return: NativeTypeName("const ImFontLoader *")]
        public static extern ImFontLoader* ImFontAtlasGetFontLoaderForStbTruetype();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasRectId_GetIndex", ExactSpelling = true)]
        public static extern int ImFontAtlasRectId_GetIndex([NativeTypeName("ImFontAtlasRectId")] int id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasRectId_GetGeneration", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint ImFontAtlasRectId_GetGeneration([NativeTypeName("ImFontAtlasRectId")] int id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasRectId_Make", ExactSpelling = true)]
        [return: NativeTypeName("ImFontAtlasRectId")]
        public static extern int ImFontAtlasRectId_Make(int index_idx, int gen_idx);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImFontAtlasBuilder* ImFontAtlasBuilder_ImFontAtlasBuilder();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImFontAtlasBuilder_destroy(ImFontAtlasBuilder* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBuildInit", ExactSpelling = true)]
        public static extern void ImFontAtlasBuildInit(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBuildDestroy", ExactSpelling = true)]
        public static extern void ImFontAtlasBuildDestroy(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBuildMain", ExactSpelling = true)]
        public static extern void ImFontAtlasBuildMain(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBuildSetupFontLoader", ExactSpelling = true)]
        public static extern void ImFontAtlasBuildSetupFontLoader(ImFontAtlas* atlas, [NativeTypeName("const ImFontLoader *")] ImFontLoader* font_loader);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBuildUpdatePointers", ExactSpelling = true)]
        public static extern void ImFontAtlasBuildUpdatePointers(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBuildRenderBitmapFromString", ExactSpelling = true)]
        public static extern void ImFontAtlasBuildRenderBitmapFromString(ImFontAtlas* atlas, int x, int y, int w, int h, [NativeTypeName("const char *")] sbyte* in_str, [NativeTypeName("char")] sbyte in_marker_char);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBuildClear", ExactSpelling = true)]
        public static extern void ImFontAtlasBuildClear(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasTextureAdd", ExactSpelling = true)]
        public static extern ImTextureData* ImFontAtlasTextureAdd(ImFontAtlas* atlas, int w, int h);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasTextureMakeSpace", ExactSpelling = true)]
        public static extern void ImFontAtlasTextureMakeSpace(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasTextureRepack", ExactSpelling = true)]
        public static extern void ImFontAtlasTextureRepack(ImFontAtlas* atlas, int w, int h);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasTextureGrow", ExactSpelling = true)]
        public static extern void ImFontAtlasTextureGrow(ImFontAtlas* atlas, int old_w, int old_h);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasTextureCompact", ExactSpelling = true)]
        public static extern void ImFontAtlasTextureCompact(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasTextureGetSizeEstimate", ExactSpelling = true)]
        public static extern void ImFontAtlasTextureGetSizeEstimate(ImVec2i* pOut, ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBuildSetupFontSpecialGlyphs", ExactSpelling = true)]
        public static extern void ImFontAtlasBuildSetupFontSpecialGlyphs(ImFontAtlas* atlas, ImFont* font, ImFontConfig* src);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBuildLegacyPreloadAllGlyphRanges", ExactSpelling = true)]
        public static extern void ImFontAtlasBuildLegacyPreloadAllGlyphRanges(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBuildGetOversampleFactors", ExactSpelling = true)]
        public static extern void ImFontAtlasBuildGetOversampleFactors(ImFontConfig* src, ImFontBaked* baked, int* out_oversample_h, int* out_oversample_v);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBuildDiscardBakes", ExactSpelling = true)]
        public static extern void ImFontAtlasBuildDiscardBakes(ImFontAtlas* atlas, int unused_frames);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasFontSourceInit", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImFontAtlasFontSourceInit(ImFontAtlas* atlas, ImFontConfig* src);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasFontSourceAddToFont", ExactSpelling = true)]
        public static extern void ImFontAtlasFontSourceAddToFont(ImFontAtlas* atlas, ImFont* font, ImFontConfig* src);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasFontDestroySourceData", ExactSpelling = true)]
        public static extern void ImFontAtlasFontDestroySourceData(ImFontAtlas* atlas, ImFontConfig* src);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasFontInitOutput", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImFontAtlasFontInitOutput(ImFontAtlas* atlas, ImFont* font);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasFontDestroyOutput", ExactSpelling = true)]
        public static extern void ImFontAtlasFontDestroyOutput(ImFontAtlas* atlas, ImFont* font);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasFontDiscardBakes", ExactSpelling = true)]
        public static extern void ImFontAtlasFontDiscardBakes(ImFontAtlas* atlas, ImFont* font, int unused_frames);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBakedGetId", ExactSpelling = true)]
        [return: NativeTypeName("ImGuiID")]
        public static extern uint ImFontAtlasBakedGetId([NativeTypeName("ImGuiID")] uint font_id, float baked_size, float rasterizer_density);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBakedGetOrAdd", ExactSpelling = true)]
        public static extern ImFontBaked* ImFontAtlasBakedGetOrAdd(ImFontAtlas* atlas, ImFont* font, float font_size, float font_rasterizer_density);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBakedGetClosestMatch", ExactSpelling = true)]
        public static extern ImFontBaked* ImFontAtlasBakedGetClosestMatch(ImFontAtlas* atlas, ImFont* font, float font_size, float font_rasterizer_density);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBakedAdd", ExactSpelling = true)]
        public static extern ImFontBaked* ImFontAtlasBakedAdd(ImFontAtlas* atlas, ImFont* font, float font_size, float font_rasterizer_density, [NativeTypeName("ImGuiID")] uint baked_id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBakedDiscard", ExactSpelling = true)]
        public static extern void ImFontAtlasBakedDiscard(ImFontAtlas* atlas, ImFont* font, ImFontBaked* baked);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBakedAddFontGlyph", ExactSpelling = true)]
        public static extern ImFontGlyph* ImFontAtlasBakedAddFontGlyph(ImFontAtlas* atlas, ImFontBaked* baked, ImFontConfig* src, [NativeTypeName("const ImFontGlyph *")] ImFontGlyph* in_glyph);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBakedAddFontGlyphAdvancedX", ExactSpelling = true)]
        public static extern void ImFontAtlasBakedAddFontGlyphAdvancedX(ImFontAtlas* atlas, ImFontBaked* baked, ImFontConfig* src, [NativeTypeName("ImWchar")] ushort codepoint, float advance_x);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBakedDiscardFontGlyph", ExactSpelling = true)]
        public static extern void ImFontAtlasBakedDiscardFontGlyph(ImFontAtlas* atlas, ImFont* font, ImFontBaked* baked, ImFontGlyph* glyph);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasBakedSetFontGlyphBitmap", ExactSpelling = true)]
        public static extern void ImFontAtlasBakedSetFontGlyphBitmap(ImFontAtlas* atlas, ImFontBaked* baked, ImFontConfig* src, ImFontGlyph* glyph, ImTextureRect* r, [NativeTypeName("const unsigned char *")] byte* src_pixels, ImTextureFormat src_fmt, int src_pitch);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasPackInit", ExactSpelling = true)]
        public static extern void ImFontAtlasPackInit(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasPackAddRect", ExactSpelling = true)]
        [return: NativeTypeName("ImFontAtlasRectId")]
        public static extern int ImFontAtlasPackAddRect(ImFontAtlas* atlas, int w, int h, ImFontAtlasRectEntry* overwrite_entry);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasPackGetRect", ExactSpelling = true)]
        public static extern ImTextureRect* ImFontAtlasPackGetRect(ImFontAtlas* atlas, [NativeTypeName("ImFontAtlasRectId")] int id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasPackGetRectSafe", ExactSpelling = true)]
        public static extern ImTextureRect* ImFontAtlasPackGetRectSafe(ImFontAtlas* atlas, [NativeTypeName("ImFontAtlasRectId")] int id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasPackDiscardRect", ExactSpelling = true)]
        public static extern void ImFontAtlasPackDiscardRect(ImFontAtlas* atlas, [NativeTypeName("ImFontAtlasRectId")] int id);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasUpdateNewFrame", ExactSpelling = true)]
        public static extern void ImFontAtlasUpdateNewFrame(ImFontAtlas* atlas, int frame_count, [NativeTypeName("_Bool")] byte renderer_has_textures);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasAddDrawListSharedData", ExactSpelling = true)]
        public static extern void ImFontAtlasAddDrawListSharedData(ImFontAtlas* atlas, ImDrawListSharedData* data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasRemoveDrawListSharedData", ExactSpelling = true)]
        public static extern void ImFontAtlasRemoveDrawListSharedData(ImFontAtlas* atlas, ImDrawListSharedData* data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasUpdateDrawListsTextures", ExactSpelling = true)]
        public static extern void ImFontAtlasUpdateDrawListsTextures(ImFontAtlas* atlas, ImTextureRef old_tex, ImTextureRef new_tex);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasUpdateDrawListsSharedData", ExactSpelling = true)]
        public static extern void ImFontAtlasUpdateDrawListsSharedData(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasTextureBlockConvert", ExactSpelling = true)]
        public static extern void ImFontAtlasTextureBlockConvert([NativeTypeName("const unsigned char *")] byte* src_pixels, ImTextureFormat src_fmt, int src_pitch, [NativeTypeName("unsigned char *")] byte* dst_pixels, ImTextureFormat dst_fmt, int dst_pitch, int w, int h);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasTextureBlockPostProcess", ExactSpelling = true)]
        public static extern void ImFontAtlasTextureBlockPostProcess(ImFontAtlasPostProcessData* data);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasTextureBlockPostProcessMultiply", ExactSpelling = true)]
        public static extern void ImFontAtlasTextureBlockPostProcessMultiply(ImFontAtlasPostProcessData* data, float multiply_factor);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasTextureBlockFill", ExactSpelling = true)]
        public static extern void ImFontAtlasTextureBlockFill(ImTextureData* dst_tex, int dst_x, int dst_y, int w, int h, [NativeTypeName("ImU32")] uint col);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasTextureBlockCopy", ExactSpelling = true)]
        public static extern void ImFontAtlasTextureBlockCopy(ImTextureData* src_tex, int src_x, int src_y, ImTextureData* dst_tex, int dst_x, int dst_y, int w, int h);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasTextureBlockQueueUpload", ExactSpelling = true)]
        public static extern void ImFontAtlasTextureBlockQueueUpload(ImFontAtlas* atlas, ImTextureData* tex, int x, int y, int w, int h);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTextureDataGetFormatBytesPerPixel", ExactSpelling = true)]
        public static extern int ImTextureDataGetFormatBytesPerPixel(ImTextureFormat format);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTextureDataGetStatusName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImTextureDataGetStatusName(ImTextureStatus status);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImTextureDataGetFormatName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ImTextureDataGetFormatName(ImTextureFormat format);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasDebugLogTextureRequests", ExactSpelling = true)]
        public static extern void ImFontAtlasDebugLogTextureRequests(ImFontAtlas* atlas);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImFontAtlasGetMouseCursorTexData", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte ImFontAtlasGetMouseCursorTexData(ImFontAtlas* atlas, [NativeTypeName("ImGuiMouseCursor")] int cursor_type, [NativeTypeName("ImVec2 *")] System.Numerics.Vector2* out_offset, [NativeTypeName("ImVec2 *")] System.Numerics.Vector2* out_size, [NativeTypeName("ImVec2[2]")] System.Numerics.Vector2* out_uv_border, [NativeTypeName("ImVec2[2]")] System.Numerics.Vector2* out_uv_fill);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiTextBuffer_appendf(ImGuiTextBuffer* self, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGET_FLT_MAX", ExactSpelling = true)]
        public static extern float GET_FLT_MAX();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGET_FLT_MIN", ExactSpelling = true)]
        public static extern float GET_FLT_MIN();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ImVector_ImWchar* ImVector_ImWchar_create();

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImVector_ImWchar_destroy(ImVector_ImWchar* self);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImVector_ImWchar_Init(ImVector_ImWchar* p);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImVector_ImWchar_UnInit(ImVector_ImWchar* p);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiPlatformIO_Set_Platform_GetWindowPos(ImGuiPlatformIO* platform_io, [NativeTypeName("void (*)(ImGuiViewport *, ImVec2 *)")] delegate* unmanaged[Cdecl]<ImGuiViewport*, System.Numerics.Vector2*, void> user_callback);

        [DllImport("cimgui2.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ImGuiPlatformIO_Set_Platform_GetWindowSize(ImGuiPlatformIO* platform_io, [NativeTypeName("void (*)(ImGuiViewport *, ImVec2 *)")] delegate* unmanaged[Cdecl]<ImGuiViewport*, System.Numerics.Vector2*, void> user_callback);
    }
}
