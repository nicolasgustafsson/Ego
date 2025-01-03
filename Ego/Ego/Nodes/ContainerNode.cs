namespace Ego;

//Node containing an object. Wrapper class to handle parallel branches
public class ContainerNode<T>(T ContainedObject) : Node
{
    public required T ContainedObject;
    
    
}