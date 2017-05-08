using System;
using System.IO;
using Logger.Common.Enum;
using Logger.Common.Formatters;
using Logger.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Test.IntergrationTests
{
    [TestClass]
    public class LeapYearFormatterTests
    {
        [TestInitialize]
        public void Initialize()
        {
            File.Delete(@"..\Log.txt");
        }

        [TestMethod]
        public void CreateDefaultFileLoggerWithLeapYearFormatter()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.FileLogger;
            LoggerFactory.Configuration.Formatter = new LeapYearFormatter();
            string inputLog = "Logs";
            string timeOfLog = DateTime.Now.ToString("M/dd/yyyy hh:mm:ss");
            string leapYear = "is not a leapyear";
            string expected = string.Format("Log - {0} : {1} - {2}", timeOfLog, leapYear, inputLog + Environment.NewLine);

            //Act
            var testFileLogger = LoggerFactory.GetLogger();
            testFileLogger.Log(inputLog);

            //Assert
            string result = File.ReadAllText(@"..\Log.txt");
            Assert.AreEqual(expected, result);
            File.Delete(@"..\Log.txt");
        }

        [TestCleanup]
        public void Cleanup()
        {
            LoggerFactory.ClearLoggers();
        }
    }
}
