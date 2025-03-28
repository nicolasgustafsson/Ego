﻿using MessagePack;

namespace Ego;

[MessagePackObject(keyAsPropertyName:true)]
public struct Transform
{
    public Quaternion Rotation = Quaternion.Identity;
    public Vector3 Position = Vector3.Zero;
    public Vector3 Scale = Vector3.One;

    public Transform()
    {
    }
    
    public Matrix4x4 Matrix => Matrix4x4.CreateFromQuaternion(Rotation) * Matrix4x4.CreateTranslation((Vector3)Position) * Matrix4x4.CreateScale(Scale);   
}