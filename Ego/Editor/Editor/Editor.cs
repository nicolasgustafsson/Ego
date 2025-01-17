﻿using MessagePack;
using NativeFileDialogs.Net;

namespace Editor;

[Node]
public partial class Editor : Node
{
    private ProjectEditor ProjectEditor = null!;
    public LandingArea? LandingArea = null!;
    public TopMenu TopMenu = null!;

    public static Editor Instance;
    public override void Start()
    {
        Instance = this;
        base.Start();
        
        MessagePackSerializer.DefaultOptions = MessagePack.Resolvers.ContractlessStandardResolver.Options;
        ProjectEditor = AddChild(new ProjectEditor());
        LandingArea = AddChild(new LandingArea());
        TopMenu = AddChild(new TopMenu());
    }
    
    public void SelectProject()
    {
        if (Nfd.OpenDialog(out string? outPath, new Dictionary<string, string>()
        {
            { "Project File", "csproj" },
        }) == NfdStatus.Ok && outPath != null)
        {
            ProjectEditor.Instance.SelectProject(outPath);
        }
    }
}
