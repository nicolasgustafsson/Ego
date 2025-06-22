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
            Stopwatch watch = new();

            watch.Start();
            for(int i = 0; i < 10000; i++)
            {
                Log.Debug($"yep {i}"); 
            }

            watch.Stop();

            Log.Debug($"Time taken to print 10000 logs: {watch.Elapsed}");
        }
    }
}