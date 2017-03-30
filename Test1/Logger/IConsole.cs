using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public interface IConsole
    {
        ConsoleColor ForegroundColor { get; set; }

        ConsoleColor BackgroundColor { get; set; }

        void WriteLine(string input);
    }
}
