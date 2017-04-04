using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Logger.Common;

namespace Logger.Loggers
{
    public class FileLogger : AbstractLogger, ILogger
    {
        private string fullFileName;

        public FileLogger(ISerializer serializer)
            : this(serializer, "Log.txt", "../../") // default
        {
            ;
        }

        public FileLogger(ISerializer serializer, string fileName, string filePath)
            : base(serializer)
        {
            this.fullFileName = filePath + fileName;
        }

        protected override void Write(string message)
        {
            File.AppendAllText(this.fullFileName, message + Environment.NewLine);
        }
    }
}
