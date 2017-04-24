namespace Logger.Common
{
    public interface ISerializer
    {
        string Serialize<T>(T input);
    }
}
