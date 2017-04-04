using Logger.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Loggers
{
    public abstract class AbstractLogger : ILogger
    {
        private ISerializer serializer;

        protected AbstractLogger(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        public void Log(string message)
        {
            message = string.Format("{0}-{1}", DateTime.Now, message);
            Write(message);
        }

        public void Log<T>(T message)
        {
            Log(serializer.Serialize(message));
        }

        protected abstract void Write(string message);
    }
}
