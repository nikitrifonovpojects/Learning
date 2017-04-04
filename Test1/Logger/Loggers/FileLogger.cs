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

        private IFileSystem file;

        public FileLogger(ISerializer serializer, IFileSystem file)
            : this(serializer, file, "Log.txt", "../") // default
        {
            this.file = file;
        }

        public FileLogger(ISerializer serializer, IFileSystem file, string fileName, string filePath)
            : base(serializer)
        {
            this.fullFileName = filePath + fileName;
            this.file = file;
        }

        protected override void Write(string message)
        {
            file.AppendAllText(this.fullFileName, message + Environment.NewLine);
        }
    }
}
