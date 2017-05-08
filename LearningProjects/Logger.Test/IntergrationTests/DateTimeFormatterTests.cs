using System;
using System.IO;
using Logger.Common.Enum;
using Logger.Common.Formatters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Test.IntergrationTests
{
    [TestClass]
    public class DateTimeFormatterTests
    {
        [TestInitialize]
        public void Initialize()
        {
            File.Delete(@"..\Log.txt");
        }

        [TestMethod]
        public void CreateDefaultFileLoggerWithDateTimeFormatter()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.FileLogger;
            LoggerFactory.Configuration.Formatter = new DateTimeFormatter();
            string inputLog = "Logs";
            string timeOfLog = DateTime.Now.ToString();
            string expected = string.Join("-", timeOfLog, inputLog + Environment.NewLine);

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
