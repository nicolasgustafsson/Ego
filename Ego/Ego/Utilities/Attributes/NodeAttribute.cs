namespace Ego
{
    [System.AttributeUsage(System.AttributeTargets.Class, Inherited = false)]
    public class NodeAttribute : System.Attribute
    {
        public bool AllowAddingToScene;
    }
}
