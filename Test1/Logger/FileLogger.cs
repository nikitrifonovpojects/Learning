using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    public class FileLogger : ILogger
    {
        private string fullFileName;

        public FileLogger() : this("Log.txt","../../") // default
        {
            
        }

        public FileLogger(string fileName, string filePath)
        {
            this.fullFileName = filePath + fileName;
        }
        public void Log(string message)
        {
            File.AppendAllText(this.fullFileName, string.Format("{0}-{1}", DateTime.Now.ToString(), message) + Environment.NewLine);
        }
    }
}
