using MessagePack;

namespace Ego;

[MessagePackObject(true)]
public class FileHeader
{
    public string? ImportPath;
    public List<Guid> Dependencies = new();
    public int Checksum = 0;
    public int Version;
    public List<string> Tags = new();
}