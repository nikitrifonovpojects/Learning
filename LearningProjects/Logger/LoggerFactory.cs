using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Common;
using Logger.Configuration;
using Logger.Loggers;

namespace Logger
{
    public static class LoggerFactory
    {
        public readonly static FactoryOptions Configuration = new FactoryOptions();

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
            if (Configuration.FileOptions != null)
            {
                ISerializer serializer = new JsonSerializer();
                IFileSystem file = new LoggerFileSystem();

                if (Configuration.FileOptions.File != null)
                {
                    file = Configuration.FileOptions.File;
                }

                return new FileLogger(serializer, file, Configuration.FileOptions.FileName, Configuration.FileOptions.FilePath);
            }

            else
            {
                return new FileLogger(Configuration.Serializer, new LoggerFileSystem());
            }
        }

        private static ILogger CreateConsoleLogger()
        {
            if (Configuration.ConsoleOptions != null)
            {
                IConsole console = new LoggerConsole();
                ISerializer serializer = new JsonSerializer();

                if (Configuration.ConsoleOptions.Console != null)
                {
                    console = Configuration.ConsoleOptions.Console;
                }

                return new ConsoleLogger(serializer, console, Configuration.ConsoleOptions.ForegroundColor, Configuration.ConsoleOptions.BackgroundColor);
            }

            else
            {
                return new ConsoleLogger(Configuration.Serializer, new LoggerConsole());
            }
        }


    }
}
