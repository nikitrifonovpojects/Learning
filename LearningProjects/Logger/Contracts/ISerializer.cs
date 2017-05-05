namespace Logger.Contracts
{
    public interface ISerializer
    {
        string Serialize<T>(T input);
    }
}
