using System;

namespace Logger.Common
{
    public interface IConsole
    {
        ConsoleColor ForegroundColor { get; set; }

        ConsoleColor BackgroundColor { get; set; }

        void WriteLine(string input);
    }
}
