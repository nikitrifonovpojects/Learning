using System;
using Logger.Contracts;

namespace Logger.Loggers
{
    public class FileLogger : AbstractLogger, ILogger
    {
        private string fullFileName;
        private IFileSystem file;

        public FileLogger(ISerializer serializer, IFormatter formatter, IFileSystem file, string fileName, string filePath)
            : base(serializer, formatter)
        {
            this.fullFileName = filePath + fileName;
            this.file = file;
        }

        protected override void Write(string message)
        {
            this.file.AppendAllText(this.fullFileName, message + Environment.NewLine);
        }
    }
}
