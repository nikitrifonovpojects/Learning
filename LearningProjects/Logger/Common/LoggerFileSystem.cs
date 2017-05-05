using System.IO;
using Logger.Contracts;

namespace Logger.Common
{
    public class LoggerFileSystem : IFileSystem
    {
        public void AppendAllText(string path, string message)
        {
            File.AppendAllText(path, message);
        }
    }
}
