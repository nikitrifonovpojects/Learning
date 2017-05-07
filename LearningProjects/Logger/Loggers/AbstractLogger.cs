using System;
using Logger.Contracts;

namespace Logger.Loggers
{
    public abstract class AbstractLogger : ILogger
    {
        protected AbstractLogger(ISerializer serializer, IFormatter formatter)
        {
            this.Serializer = serializer;
            this.Formatter = formatter;
        }

        protected ISerializer Serializer { get; private set; }

        protected IFormatter Formatter { get; private set; }

        public void Log(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(message);
            }

            Write(this.Formatter.Format(message));
        }

        public void Log<T>(T message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            Log(this.Serializer.Serialize(message));
        }

        protected abstract void Write(string message);
    }
}
