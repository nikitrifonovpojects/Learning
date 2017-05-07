using System;
using Logger.Contracts;

namespace Logger.Common.Formatters
{
    public class LeapYearFormatter : IFormatter
    {
        public string Format(string message)
        {
            string leapYear = string.Empty;
            if (DateTime.IsLeapYear(DateTime.Now.Year))
            {
                leapYear = "is leapyear";
            }
            else
            {
                leapYear = "is not a leapyear";
            }

            return string.Format("Log - {0} : {1} - {2}", DateTime.Now.ToString("M/dd/yyyy hh:mm:ss"), leapYear, message);
        }
    }
}
