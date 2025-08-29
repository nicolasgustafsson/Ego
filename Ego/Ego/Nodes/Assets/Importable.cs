namespace Ego;

public interface IImportable
{
    public Task Import(string aFilePath);
}