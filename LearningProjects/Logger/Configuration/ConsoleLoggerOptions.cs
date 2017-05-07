using System;
using Logger.Contracts;

namespace Logger.Configuration
{
    public class ConsoleLoggerOptions
    {
        public IConsole Console { get; set; }

        public ConsoleColor? ForegroundColor { get; set; }

        public ConsoleColor? BackgroundColor { get; set; }
    }
}
