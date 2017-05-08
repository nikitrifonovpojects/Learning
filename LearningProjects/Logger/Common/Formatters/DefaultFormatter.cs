using Logger.Contracts;

namespace Logger.Common.Formatters
{
    public class DefaultFormatter : IFormatter
    {
        public string Format(string message)
        {
            return message;
        }
    }
}
