using Logger.Common.Enum;
using Logger.Contracts;

namespace Logger.Configuration
{
    public class FactoryOptions
    {
        public LoggerType DefaultLoggerType { get; set; }

        public ConsoleLoggerOptions ConsoleOptions { get; set; }

        public FileLoggerOptions FileOptions { get; set; }

        public ISerializer Serializer { get; set; }

        public IFormatter Formatter { get; set; }

    }
}
