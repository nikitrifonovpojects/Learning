using System;

namespace Logger.Contracts
{
    public interface IConsole
    {
        ConsoleColor ForegroundColor { get; set; }

        ConsoleColor BackgroundColor { get; set; }

        void WriteLine(string input);
    }
}
