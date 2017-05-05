using System;
using Logger.Contracts;

namespace Logger.Common
{
    public class LoggerConsole : IConsole
    {
        public ConsoleColor BackgroundColor
        {
            get
            {
                return Console.BackgroundColor;
            }

            set
            {
                 Console.BackgroundColor = value;
            }
        }

        public ConsoleColor ForegroundColor
        {
            get
            {
                return Console.ForegroundColor;
            }

            set
            {
                Console.ForegroundColor = value;
            }
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
