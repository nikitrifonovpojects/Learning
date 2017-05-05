namespace Logger.Contracts
{
    public interface IFileSystem
    {
        void AppendAllText(string path, string message);
    }
}
