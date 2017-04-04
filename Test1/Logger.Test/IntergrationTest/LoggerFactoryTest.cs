using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Logger.Configuration;

namespace Logger.Test.IntegrationTest
{
    [TestClass]
    public class LoggerFactoryTest
    {
        [TestMethod]
        public void CreateConsoleLoggerWithDefaultOptions()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.ConsoleLogger;
            MockConsole console = new MockConsole();
            LoggerFactory.Configuration.ConsoleOptions = new ConsoleLoggerOptions()
            {
                Console = console
            };

            string timeOfLog = DateTime.Now.ToString();
            string inputLog = "Hello";
            string expected = string.Join("-", timeOfLog, inputLog + Environment.NewLine);

            //Act
            var testConsoleLogger = LoggerFactory.GetLogger();
            testConsoleLogger.Log(inputLog);
            string result = console.ConsoleMemory.ToString();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CreateConsoleLoggerWithDefaultOptionsAndMultipleLogs()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.ConsoleLogger;
            MockConsole console = new MockConsole();
            LoggerFactory.Configuration.ConsoleOptions = new ConsoleLoggerOptions()
            {
                Console = console
            };

            string timeOfLog = DateTime.Now.ToString();
            string inputLog = "log";


            //Act
            var testConsoleLogger = LoggerFactory.GetLogger();

            int numberOfLogs = 5;
            string expected = string.Empty;
            for (int i = 0; i < numberOfLogs; i++)
            {
                testConsoleLogger.Log(inputLog);
                expected += string.Join("-", timeOfLog, inputLog + Environment.NewLine);
            }
            string result = console.ConsoleMemory.ToString();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CreateDefaultConsoleLoggerWithDiferentColors()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.ConsoleLogger;
            MockConsole console = new MockConsole();
            LoggerFactory.Configuration.ConsoleOptions = new ConsoleLoggerOptions()
            {
                Console = console,
                BackgroundColor = ConsoleColor.DarkMagenta,
                ForegroundColor = ConsoleColor.DarkCyan
            };

            string timeOfLog = DateTime.Now.ToString();
            string inputLog = "Hello";
            string expected = string.Join("-", timeOfLog, inputLog + Environment.NewLine);

            //Act
            var testConsoleLogger = LoggerFactory.GetLogger();
            testConsoleLogger.Log(inputLog);
            string result = console.ConsoleMemory.ToString();

            //Assert
            Assert.IsTrue(console.IsBackGroundColorSet);
            Assert.IsTrue(console.IsForgroundColorSet);
            Assert.AreEqual(expected, result);
        }

        [TestCleanup]
        public void Cleanup()
        {
            LoggerFactory.ClearLoggers();
        }
    }
}
