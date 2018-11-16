namespace ServiceUtils.Interfaces
{
    public interface IFileService
    {
        void WriteFile(string filePath, string content);

        string ReadFile(string filePath);
    }
}
