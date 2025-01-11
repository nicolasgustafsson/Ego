using MessagePack;

namespace Ego;

[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct SerializedMember<T>(bool IsInitialized, T SerializedObject)
{
    public readonly bool IsInitialized = IsInitialized;
    public readonly T SerializedObject = SerializedObject;
    
    public static implicit operator T(SerializedMember<T> aMember)
    {
        return aMember.SerializedObject;
    }
}