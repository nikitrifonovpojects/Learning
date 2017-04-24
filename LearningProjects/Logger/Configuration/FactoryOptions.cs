using Logger.Common;

namespace Logger.Configuration
{
    public class FactoryOptions
    {
        public LoggerType DefaultLoggerType { get; set; }

        public ConsoleLoggerOptions ConsoleOptions { get; set; }

        public FileLoggerOptions FileOptions { get; set; }

        public ISerializer Serializer { get; set; }

    }
}
