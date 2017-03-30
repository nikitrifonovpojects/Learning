using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class LoggerFactory
    {
        public readonly static Configuration Configuration = new Configuration();


        public static ILogger CreateLogger(LoggerType type)
        {
            if (type == LoggerType.ConsoleLogger)
            {
                if (Configuration.ConsoleOptions != null)
                {
                    IConsole console = new LoggerConsole();
                    if (Configuration.ConsoleOptions.Console != null)
                    {
                        console = Configuration.ConsoleOptions.Console;
                    }

                    return new ConsoleLogger(console, Configuration.ConsoleOptions.ForegroundColor, Configuration.ConsoleOptions.BackgroundColor);
                }
                else
                {
                    return new ConsoleLogger(new LoggerConsole());
                }
            }
            else if (type == LoggerType.FileLogger)
            {
                if (Configuration.FileOptions != null)
                {
                    return new FileLogger(Configuration.FileOptions.FileName, Configuration.FileOptions.FilePath);
                }
                else
                {
                    return new FileLogger();
                }
            }
            else
            {
                throw new NotSupportedException(string.Format("{0} is not supported", type));
            }
        }

        public static ILogger CreateLogger()
        {
            if (Configuration == null)
            {
                throw new NotSupportedException(string.Format("The default logger wasn't configurated"));
            }
            else
            {
                return CreateLogger(Configuration.DefaultLoggerType);
            }
        }
    }
}
