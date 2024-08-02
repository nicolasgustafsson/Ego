public class Context : Node
{
    public Action EUpdate = ()=>{};
    public new T? Get<T>() where T : Node
    {
        if (Children.FirstOrDefault(node => node is T) is T nodeOfType)
            return nodeOfType;
        
        if (Context is {} parentContext)
            return parentContext.Get<T>();

        return null;
    }
}