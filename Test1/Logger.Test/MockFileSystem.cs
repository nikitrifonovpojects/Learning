using Logger.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Test
{
    class MockFileSystem : IFileSystem
    {
        public void WriteText(string path, string message)
        {
            File.AppendAllText(path, message + Environment.NewLine);
        }

        public string ReadText(string path)
        {
            return File.ReadAllText(path);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }
    }
}
