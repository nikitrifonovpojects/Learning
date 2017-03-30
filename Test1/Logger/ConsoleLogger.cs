using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class ConsoleLogger : ILogger
    {
        private IConsole console;

        public ConsoleLogger(IConsole console)
        {
            this.console = console;
        }

        public ConsoleLogger(IConsole console, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
            : this(console)
        {
            this.console.BackgroundColor = backgroundColor;
            this.console.ForegroundColor = foregroundColor;
        }

        public void Log(string message)
        {
            this.console.WriteLine(string.Format("{0}-{1}", DateTime.Now, message));
        }
    }
}
