using System;
using Logger.Contracts;

namespace Logger.Loggers
{
    public class FileLogger : AbstractLogger, ILogger
    {
        private string fullFileName;

        private IFileSystem file;

        public FileLogger(ISerializer serializer, IFileSystem file)
            : this(serializer, file, "Log.txt", "../") // default
        {

        }

        public FileLogger(ISerializer serializer, IFileSystem file, string fileName, string filePath)
            : base(serializer)
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
