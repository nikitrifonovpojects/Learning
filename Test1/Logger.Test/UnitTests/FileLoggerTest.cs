using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Logger.Common;
using Logger.Loggers;
using Logger.Configuration;

namespace Logger.Test.UnitTests
{
    [TestClass]
    public class FileLoggerTest
    {
        [TestMethod]
        public void CreateFileLoggerWithDefaultOptionsAndMultipleLogs()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.FileLogger;
            MockFileSystem file = new MockFileSystem();
            string timeOfLog = DateTime.Now.ToString();
            string inputLog = "Logs";
            string expected = string.Empty;

            //Act
            var testFileLogger = LoggerFactory.GetLogger();
            int numberOfLogs = 7;
            for (int i = 0; i < numberOfLogs; i++)
            {
                testFileLogger.Log(inputLog);
                expected += string.Join("-", timeOfLog, inputLog + Environment.NewLine);
            }

            //Assert
            string result = file.ReadText(@"..\Log.txt");
            Assert.AreEqual(expected, result);
            file.DeleteFile(@"..\Log.txt");
        }

        [TestMethod]
        public void CreateFIleLoggerWithFileNameAndFilePath()
        {
            //Arrange
            LoggerFactory.Configuration.FileOptions = new FileLoggerOptions();

            LoggerFactory.Configuration.FileOptions.FileName = "Log.txt";
            LoggerFactory.Configuration.FileOptions.FilePath = @"..\";

            MockFileSystem file = new MockFileSystem();
            string timeOfLog = DateTime.Now.ToString();
            string inputLog = "Hello";
            string expected = string.Join("-", timeOfLog, inputLog + Environment.NewLine);

            //Act
            var testFileLogger = LoggerFactory.GetLogger(LoggerType.FileLogger);
            testFileLogger.Log(inputLog);

            //Assert
            string result = file.ReadText(@"..\Log.txt");
            Assert.AreEqual(expected, result);
            file.DeleteFile(@"..\Log.txt");
        }

        [TestMethod]
        public void CreateFileLoggerWithDefaultSettings()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.FileLogger;
            MockFileSystem file = new MockFileSystem();

            string timeOfLog = DateTime.Now.ToString();
            string inputLog = "Hello";
            string expected = string.Join("-", timeOfLog, inputLog + Environment.NewLine);

            //Act
            var testFileLogger = LoggerFactory.GetLogger();
            testFileLogger.Log(inputLog);

            //Assert
            string result = file.ReadText(@"..\Log.txt");
            Assert.AreEqual(expected, result);
            file.DeleteFile(@"..\Log.txt");
        }

        [TestCleanup]
        public void Cleanup()
        {
            LoggerFactory.ClearLoggers();
        }
    }
}
