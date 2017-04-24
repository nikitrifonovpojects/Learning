using Logger.Common;

namespace Logger.Configuration
{
    public class FileLoggerOptions
    {
        public string FileName { get; set; }

        public string FilePath { get; set; }

        public IFileSystem File { get; set; }
    }
}
