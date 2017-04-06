using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Common
{
    public interface IFileSystem
    {
        void AppendAllText(string path, string message);
    }
}
