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
            else
            {
                throw new NotSupportedException(string.Format("{0} is not supported", type));
            }

            return loggers[type];
        }

        private static ILogger CreateFileLogger()
        {
            if (Configuration.FileOptions != null)
            {
                ISerializer serializer = new JsonSerializer();
                return new FileLogger(serializer, Configuration.FileOptions.FileName, Configuration.FileOptions.FilePath);
            }
            else
            {
                return new FileLogger(Configuration.Serializer);
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

        public static ILogger GetLogger()
        {
            if (Configuration == null)
            {
                throw new NotSupportedException(string.Format("The default logger wasn't configurated"));
            }
            else
            {
                return GetLogger(Configuration.DefaultLoggerType);
            }
        }

        public static void ClearLoggers()
        {
            loggers.Clear();
        }
    }
}
