using System;
using System.IO;
using Logger.Common.Enum;
using Logger.Configuration;
using Logger.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Test.IntegrationTests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            File.Delete(@"..\Log.txt");
        }

        [TestMethod]
        public void CreateFileLoggerWithDefaultOptionsAndMultipleLogs()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.FileLogger;
            string inputLog = "Logs";
            string expected = string.Empty;

            //Act
            var testFileLogger = LoggerFactory.GetLogger();
            int numberOfLogs = 7;
            for (int i = 0; i < numberOfLogs; i++)
            {
                testFileLogger.Log(inputLog);
                expected += string.Join("-", inputLog + Environment.NewLine);
            }

            //Assert
            string result = File.ReadAllText(@"..\Log.txt");
            Assert.AreEqual(expected, result);
            File.Delete(@"..\Log.txt");
        }

        [TestMethod]
        public void CreateFileLoggerWithFileNameAndFilePath()
        {
            //Arrange
            LoggerFactory.Configuration.FileOptions = new FileLoggerOptions();

            LoggerFactory.Configuration.FileOptions.FileName = "Log.txt";
            LoggerFactory.Configuration.FileOptions.FilePath = @"..\";
            
            string inputLog = "Hello";
            string expected = string.Join("-", inputLog + Environment.NewLine);

            //Act
            var testFileLogger = LoggerFactory.GetLogger(LoggerType.FileLogger);
            testFileLogger.Log(inputLog);

            //Assert
            string result = File.ReadAllText(@"..\Log.txt");
            Assert.AreEqual(expected, result);
            File.Delete(@"..\Log.txt");
        }

        [TestMethod]
        public void CreateFileLoggerWithDefaultSettings()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.FileLogger;
            string inputLog = "Hello";
            string expected = string.Join("-", inputLog + Environment.NewLine);

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
            LoggerFactory.Configuration = new FactoryOptions();
        }
    }
}
