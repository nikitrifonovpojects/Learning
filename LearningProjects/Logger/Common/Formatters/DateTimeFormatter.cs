using System;
using Logger.Contracts;

namespace Logger.Common.Formatters
{
    public class DateTimeFormatter : IFormatter
    {
        public string Format(string message)
        {
            return string.Format("{0}-{1}", DateTime.Now, message);
        }
    }
}
