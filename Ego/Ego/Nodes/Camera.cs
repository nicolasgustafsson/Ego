﻿namespace Ego;

[Node]
public partial class Camera : Node3D
{
    protected override void Update()
    {
        RendererApi.SetCameraView(WorldMatrix);
   
    }

    public override char GetIcon()
    {
        return (char)59403;
    }
}