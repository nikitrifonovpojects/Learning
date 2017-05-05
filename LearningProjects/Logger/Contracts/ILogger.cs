namespace Logger.Contracts
{
    public interface ILogger
    {
        void Log(string message);

        void Log<T>(T message);
    }
}
