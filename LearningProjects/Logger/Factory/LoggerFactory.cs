using System;
using System.Collections.Generic;
using Logger.Common;
using Logger.Common.Enum;
using Logger.Common.Formatters;
using Logger.Common.Serializers;
using Logger.Configuration;
using Logger.Contracts;
using Logger.Loggers;

namespace Logger
{
    public static class LoggerFactory
    {
        public static FactoryOptions Configuration = new FactoryOptions();

        private static Dictionary<LoggerType, ILogger> loggers = new Dictionary<LoggerType, ILogger>();

        public static ILogger GetLogger(LoggerType type)
        {
            if (type == LoggerType.ConsoleLogger && !loggers.ContainsKey(type))
            {
                loggers.Add(type, CreateConsoleLogger());
            }
            else if (type == LoggerType.FileLogger && !loggers.ContainsKey(type))
            {
                loggers.Add(type, CreateFileLogger());
            }
            else if (!loggers.ContainsKey(type))
            {
                throw new NotSupportedException(string.Format("{0} is not supported", type));
            }

            return loggers[type];
        }

        public static ILogger GetLogger()
        {
            return GetLogger(Configuration.DefaultLoggerType);
        }

        public static void ClearLoggers()
        {
            loggers.Clear();
        }

        private static ILogger CreateFileLogger()
        {
            SetDefaultOptions();
            Configuration.FileOptions = Configuration.FileOptions ?? new FileLoggerOptions();
            Configuration.FileOptions.File = Configuration.FileOptions.File ?? new LoggerFileSystem();
            Configuration.FileOptions.FileName = Configuration.FileOptions.FileName ?? "Log.txt";
            Configuration.FileOptions.FilePath = Configuration.FileOptions.FilePath ?? "../";

            return new FileLogger(Configuration.Serializer,
                                  Configuration.Formatter,
                                  Configuration.FileOptions.File,
                                  Configuration.FileOptions.FileName,
                                  Configuration.FileOptions.FilePath);
        }

        private static ILogger CreateConsoleLogger()
        {
            SetDefaultOptions();
            Configuration.ConsoleOptions = Configuration.ConsoleOptions ?? new ConsoleLoggerOptions();
            Configuration.ConsoleOptions.Console = Configuration.ConsoleOptions.Console ?? new LoggerConsole();

            return new ConsoleLogger(Configuration.Serializer,
                                      Configuration.ConsoleOptions.Console,
                                      Configuration.Formatter,
                                      Configuration.ConsoleOptions.ForegroundColor,
                                      Configuration.ConsoleOptions.BackgroundColor);
        }

        private static void SetDefaultOptions()
        {
            Configuration.Serializer = Configuration.Serializer ?? new JsonSerializer();
            Configuration.Formatter = Configuration.Formatter ?? new DefaultFormatter();
        }
    }
}
