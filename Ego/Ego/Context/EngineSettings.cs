using Rendering;

namespace Ego;

public struct EngineInitSettings()
{
    public RendererInitSettings RendererInitSettings = new();
    public string Name = "Game";
    public Vector2 WindowSize = new(1600, 900);
}