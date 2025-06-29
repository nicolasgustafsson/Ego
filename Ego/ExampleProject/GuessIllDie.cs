namespace ExampleProject;

[Node(AllowAddingToScene = true)]
public partial class GuessIllDie : Node
{
    public override void Start()
    {
        base.Start();
        KillSelfInTime();
    }
    
    private async Task KillSelfInTime()
    {
        await Task.Delay(3000);
        Destroy();
    }
}