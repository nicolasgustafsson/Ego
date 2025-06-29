namespace Ego;

public class AssetFile
{
    public FileHeader Header = null!;
    public byte[] Data = null!;
    
    private AssetFile(string aPath)
    {
        
    }
    
    public static async Task<AssetFile> Load(string aPath)
    {
        return new AssetFile("");
    }
}