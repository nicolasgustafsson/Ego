using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Rendering;
using ZLogger;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace ExampleProject;  

[Node(AllowAddingToScene = true)]
public partial class TestNode : Node
{
    public override void Start()
    {
        base.Start();

        MeshRenderer meshRenderer = new MeshRenderer(MeshData.LoadGltf(RendererApi.Renderer, "Models/basicmesh.glb").First());
        AddChild(meshRenderer);
    }
    
    protected override void Update()
    {
        if (Window.IsKeyboardKeyDown(KeyboardKey.A))
        {
        }
    }
}