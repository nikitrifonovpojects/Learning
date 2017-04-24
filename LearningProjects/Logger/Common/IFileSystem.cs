namespace Logger.Common
{
    public interface IFileSystem
    {
        void AppendAllText(string path, string message);
    }
}
