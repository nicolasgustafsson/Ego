﻿using ImGuiNET;

namespace Ego;

public class SinusoidalMovement : Node3D
{
    public Vector3 Movement = new Vector3(1f, 0f, 0f);
    
    protected override void Update()
    {
        LocalPosition = Movement * (float)Math.Sin(((EgoContext)Context).Time.ElapsedSeconds);
    }
    
    public override void Inspect()
    {
        base.Inspect();

        ImGui.SliderFloat3("Movement", ref Movement, -10f, 10f);
    }
}