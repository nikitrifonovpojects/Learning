using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
