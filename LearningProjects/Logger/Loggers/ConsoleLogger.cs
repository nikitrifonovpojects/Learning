using System;
using Logger.Contracts;

namespace Logger.Loggers
{
    public class ConsoleLogger : AbstractLogger, ILogger
    {
        private IConsole console;

        public ConsoleLogger(ISerializer serializer, IConsole console, IFormatter formatter, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
            : base(serializer, formatter)
        {
            this.console = console;
            if (backgroundColor.HasValue)
            {
                this.console.BackgroundColor = backgroundColor.Value;
            }

            if (foregroundColor.HasValue)
            {
                this.console.ForegroundColor = foregroundColor.Value;
            }
        }

        protected override void Write(string message)
        {
            this.console.WriteLine(message);
        }
    }
}
