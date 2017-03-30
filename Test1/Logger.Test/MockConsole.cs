using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Test
{
    public class MockConsole : IConsole
    {
        private ConsoleColor backgroundColor;

        private ConsoleColor foregroundColor;

        public StringBuilder ConsoleMemory { get; private set; }

        public ConsoleColor BackgroundColor
        {
            get
            {
                return this.backgroundColor;
            }
            set
            {
                this.backgroundColor = value;
                this.IsBackGroundColorSet = true;
            }
        }

        public ConsoleColor ForegroundColor
        {
            get
            {
                return this.foregroundColor;
            }
            set
            {
                this.foregroundColor = value;
                this.IsForgroundColorSet = true;
            }
        }

        public bool IsBackGroundColorSet { get; private set; }

        public bool IsForgroundColorSet { get; private set; }

        public MockConsole()
        {
            this.ConsoleMemory = new StringBuilder();
        }

        public void WriteLine(string input)
        {
            ConsoleMemory.AppendLine(input);
        }
    }
}
