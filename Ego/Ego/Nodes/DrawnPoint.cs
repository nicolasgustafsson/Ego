using System.Drawing;

namespace Ego;

[Node(AllowAddingToScene = true)]
public partial class DrawnPoint : Node3D
{
    [Inspect] private float Thickness = 0.5f;
    [Inspect] private Color Color = System.Drawing.Color.White;
    
    protected override void Update()
    {
        Shapes.DrawPoint(WorldMatrix.Translation, Color.ToVec4(), Thickness);
    }
}