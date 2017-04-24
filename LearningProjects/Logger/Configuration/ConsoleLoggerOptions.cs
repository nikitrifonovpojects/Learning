using Logger.Common;
using System;

namespace Logger.Configuration
{
    public class ConsoleLoggerOptions
    {
        public IConsole Console { get; set; }

        public ConsoleColor ForegroundColor { get; set; }

        public ConsoleColor BackgroundColor { get; set; }
    }
}
