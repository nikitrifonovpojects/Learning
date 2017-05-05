using System;
using Logger.Contracts;

namespace Logger.Loggers
{
    public class ConsoleLogger : AbstractLogger, ILogger
    {
        private IConsole console;

        public ConsoleLogger(ISerializer serializer, IConsole console) 
            : base(serializer)
        {
            this.console = console;
        }

        public ConsoleLogger(ISerializer serializer,IConsole console, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
            : this(serializer,console)
        {
            this.console.BackgroundColor = backgroundColor;
            this.console.ForegroundColor = foregroundColor;
        }

        protected override void Write(string message)
        {
            this.console.WriteLine(message);
        }
    }
}
