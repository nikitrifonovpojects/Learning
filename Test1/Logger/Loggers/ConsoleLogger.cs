using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Logger.Common;

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
