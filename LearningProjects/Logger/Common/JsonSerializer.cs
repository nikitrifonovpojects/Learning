using Newtonsoft.Json;


namespace Logger.Common
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize<T>(T input)
        {
            return JsonConvert.SerializeObject(input);
        }
    }
}
