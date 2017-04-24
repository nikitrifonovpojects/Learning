using Logger.Common;
using System;

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
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            message = string.Format("{0}-{1}", DateTime.Now, message);
            Write(message);
        }

        public void Log<T>(T message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            Log(serializer.Serialize(message));
        }

        protected abstract void Write(string message);
    }
}
