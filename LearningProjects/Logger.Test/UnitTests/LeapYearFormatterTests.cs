using System;
using Logger.Common.Formatters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Test.UnitTests
{
    [TestClass]
    public class LeapYearFormatterTests
    {
        [TestMethod]
        public void LeapYearFormatterWorksCorrectly()
        {
            //Arrange
            var formatter = new LeapYearFormatter();
            string inputLog = "Logs";
            string timeOfLog = DateTime.Now.ToString("M/dd/yyyy hh:mm:ss");
            string leapYear = "is not a leapyear";
            string expected = string.Format("Log - {0} : {1} - {2}", timeOfLog, leapYear, inputLog);

            //Act
            var result = formatter.Format(inputLog);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
