using System.Diagnostics;
using Microsoft.Extensions.Logging;
using ZLogger;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace ExampleProject;  

[Node(AllowAddingToScene = true)]
public partial class TestNode : Node
{
    public override void Start()
    {
        base.Start();
    }
    
    protected override void Update()
    {
        if (Window.IsKeyboardKeyDown(KeyboardKey.A))
        {
        }
    }
}