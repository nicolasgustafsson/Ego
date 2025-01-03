﻿using ImGuiNET;
using Rendering;
namespace Ego;

public class MeshRenderer(string ModelPath = "Models/basicmesh.glb") : Node3D
{
    private MeshCollection MeshCollection = null!;

    private int MeshIndex = 0;

    public override void Start()
    {
        base.Start();
        MeshCollection = AssetManager.GetAsset<MeshCollection>(ModelPath);
    }

    protected override void Update()
    {
        RendererApi.RenderMesh(new(){MyMeshData = MeshCollection.Meshes[MeshIndex], WorldMatrix = WorldMatrix});
    }

    public override void Inspect()
    {
        base.Inspect();
        ImGui.SliderInt("Mesh Index", ref MeshIndex, 0, MeshCollection.Meshes.Count - 1);
    }
}