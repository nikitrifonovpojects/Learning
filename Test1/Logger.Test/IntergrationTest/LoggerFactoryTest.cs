using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Logger.Configuration;
using Moq;
using Logger.Common;

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
            var mockConsole = new Mock<IConsole>();
            var console = mockConsole.Object;
            LoggerFactory.Configuration.ConsoleOptions = new ConsoleLoggerOptions()
            {
                Console = console
            };

            string timeOfLog = DateTime.Now.ToString();
            string inputLog = "Hello";
            string expected = string.Join("-", timeOfLog, inputLog);

            //Act
            var testConsoleLogger = LoggerFactory.GetLogger();
            testConsoleLogger.Log(inputLog);

            //Assert
            
            mockConsole.Verify(x => x.WriteLine(expected), Times.Once());
        }

        [TestMethod]
        public void CreateConsoleLoggerWithDefaultOptionsAndMultipleLogs()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.ConsoleLogger;
            var mockConsole = new Mock<IConsole>();
            var result = string.Empty;
            mockConsole.Setup(x => x.WriteLine(It.IsAny<string>())).Callback<string>(c =>
            {
                result += c + Environment.NewLine;
            });
            var console = mockConsole.Object;
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


            //Assert
            mockConsole.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(numberOfLogs));
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CreateDefaultConsoleLoggerWithDiferentColors()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.ConsoleLogger;
            var mockConsole = new Mock<IConsole>();
            var console = mockConsole.Object;
            string result = String.Empty;
            mockConsole.Setup(x => x.WriteLine(It.IsAny<string>())).Callback<string>(c => result += c + Environment.NewLine);

            LoggerFactory.Configuration.ConsoleOptions = new ConsoleLoggerOptions()
            {
                Console = console,
                BackgroundColor = ConsoleColor.DarkMagenta,
                ForegroundColor = ConsoleColor.DarkCyan
            };

            string timeOfLog = DateTime.Now.ToString();
            string inputLog = "Hello";
            string expected = string.Join("-", timeOfLog, inputLog);

            //Act
            
            var testConsoleLogger = LoggerFactory.GetLogger();
            testConsoleLogger.Log(inputLog);
            
            

            //Assert
            mockConsole.Verify(x => x.WriteLine(expected), Times.Once());
            mockConsole.VerifySet(x => x.BackgroundColor);
            mockConsole.VerifySet(x => x.ForegroundColor);
            Assert.AreEqual(expected + Environment.NewLine, result);
        }

        [TestCleanup]
        public void Cleanup()
        {
            LoggerFactory.ClearLoggers();
        }
    }
}
