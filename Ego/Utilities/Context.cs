public partial class Context : BaseNode
{
    public new T? Get<T>() where T : BaseNode
    {
        if (Children.FirstOrDefault(node => node is T) is T nodeOfType)
            return nodeOfType;
        
        if (Context is {} parentContext)
            return parentContext.Get<T>();

        return null;
    }
}
