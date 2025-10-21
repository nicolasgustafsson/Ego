namespace Ego;

public class Context
{
    public TimeKeeper Time = null!;
    public Window Window = null!;
    public Debug Debug = null!;
    public RendererApi RendererApi = null!;
    public AssetManager AssetManager = null!;
    public TreeInspector TreeInspector = null!;
    public MultithreadingManager MultithreadingManager = null!;
    public PerformanceMonitor PerformanceMonitor = null!;
    public NodeTypeDatabase NodeTypeDatabase = null!;
    public MaterialBuilder MaterialBuilder = null!;
    public ShaderCompiler ShaderCompiler = null!;
    public Shapes Shapes = null!;
}