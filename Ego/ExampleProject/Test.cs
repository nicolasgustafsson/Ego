using Microsoft.Extensions.Logging;
using ZLogger;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace ExampleProject;  

[Node(AllowAddingToScene = true)]
public partial class TestNode : Node
{
    private ILogger logger;
    public override void Start()
    {
        base.Start();

        var factory = LoggerFactory.Create(logging =>
        {
            logging.SetMinimumLevel(LogLevel.Trace);
            logging.AddZLoggerConsole();
            logging.AddZLoggerConsole(options => options.UseJsonFormatter());
        });

        logger = factory.CreateLogger("Game");    
        
    }
    
    protected override void Update()
    {
        if (MyContext.Window.IsKeyboardKeyDown(KeyboardKey.A))
        {
            int i = 10;
            logger.ZLogInformation($"yep {i}");
        }
    }
}