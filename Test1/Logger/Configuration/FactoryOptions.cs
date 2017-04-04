using Logger.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Configuration
{
    public class FactoryOptions
    {
        public LoggerType DefaultLoggerType { get; set; }

        public ConsoleLoggerOptions ConsoleOptions { get; set; }

        public FileLoggerOptions FileOptions { get; set; }

        public ISerializer Serializer { get; set; }

    }
}
