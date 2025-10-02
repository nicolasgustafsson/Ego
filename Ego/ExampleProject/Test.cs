using Rendering;

namespace ExampleProject;

[Node(AllowAddingToScene = true)]
public partial class TestNode : Node3D
{
    [Inspect] private partial int Hello { get; set; }
    
    public override void Start()
    {
        base.Start();   

        AddChild(new MeshRenderer(MeshData.LoadGltf(RendererApi.Renderer, "Models/basicmesh.glb").First())).LocalPosition.X += 5;
        AddChild(new MeshRenderer(MeshData.LoadGltf(RendererApi.Renderer, "Models/basicmesh.glb").First())).LocalPosition.X += 2.5f;
        AddChild(new MeshRenderer(MeshData.LoadGltf(RendererApi.Renderer, "Models/basicmesh.glb").First())).LocalPosition.X += 0;
        AddChild(new MeshRenderer(MeshData.LoadGltf(RendererApi.Renderer, "Models/basicmesh.glb").First())).LocalPosition.X += -2.5f;
        AddChild(new MeshRenderer(MeshData.LoadGltf(RendererApi.Renderer, "Models/basicmesh.glb").First())).LocalPosition.X += -5;
    }
    
    protected override void Update()
    { 
        LocalPosition = new(LocalPosition.X, (float)Math.Sin(Time.ElapsedTime.TotalSeconds) * 3f, LocalPosition.Z);
    }
}