using System;
using Logger.Common.Formatters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Test.UnitTests
{
    [TestClass]
    public class DateTimeFormatterTests
    {
        [TestMethod]
        public void DateTimeFormatterWorksCorrectly()
        {
            //Arrange
            var formatter = new DateTimeFormatter();
            string inputLog = "Logs";
            string timeOfLog = DateTime.Now.ToString();
            string expected = string.Join("-", timeOfLog, inputLog);

            //Act
            var result = formatter.Format(inputLog);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
