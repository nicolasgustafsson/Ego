namespace Ego
{
    [System.AttributeUsage(System.AttributeTargets.Class, Inherited = false)]
    public class NodeAttribute : System.Attribute
    {
        public bool DisableEditorAdd = false;

        public NodeAttribute(bool aDisableEditorAdd = false) => DisableEditorAdd = aDisableEditorAdd;
    }
}
