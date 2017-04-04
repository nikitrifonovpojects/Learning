using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Test.IntegrationTest
{
    [TestClass]
    public class ConsoleLoggerTest
    {

        [TestMethod]
        public void CreateFIleLoggerWithFileNameAndFilePath()
        {
            //Arrange
            LoggerFactory.Configuration.FileOptions = new FileLoggerOptions();

            LoggerFactory.Configuration.FileOptions.FileName = "Log.txt";
            LoggerFactory.Configuration.FileOptions.FilePath = @"C:\Users\Nikki\Desktop\Niki zadachi\Learning\Test1\Logger.Test\";

            string timeOfLog = DateTime.Now.ToString();
            string inputLog = "Hello";
            string expected = string.Join("-", timeOfLog, inputLog + Environment.NewLine);

            //Act
            var testFileLogger = LoggerFactory.GetLogger(LoggerType.FileLogger);
            testFileLogger.Log(inputLog);

            //Assert
            string result = File.ReadAllText(@"C:\Users\Nikki\Desktop\Niki zadachi\Learning\Test1\Logger.Test\Log.txt");
            Assert.AreEqual(expected, result);
            File.Delete(@"C:\Users\Nikki\Desktop\Niki zadachi\Learning\Test1\Logger.Test\Log.txt");
        }

        [TestMethod]
        public void CreateFileLoggerWithDefaultSettings()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.FileLogger;

            string timeOfLog = DateTime.Now.ToString();
            string inputLog = "Hello";
            string expected = string.Join("-", timeOfLog, inputLog + Environment.NewLine);

            //Act
            var testFileLogger = LoggerFactory.GetLogger();
            testFileLogger.Log(inputLog);

            //Assert
            string result = File.ReadAllText(@"C:\Users\Nikki\Desktop\Niki zadachi\Learning\Test1\Logger.Test\Log.txt");
            Assert.AreEqual(expected, result);
            File.Delete(@"C:\Users\Nikki\Desktop\Niki zadachi\Learning\Test1\Logger.Test\Log.txt");
        }

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
        public void CreateFileLoggerWithDefaultOptionsAndMultipleLogs()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.FileLogger;
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
            string result = File.ReadAllText(@"C:\Users\Nikki\Desktop\Niki zadachi\Learning\Test1\Logger.Test\Log.txt");
            Assert.AreEqual(expected, result);
            File.Delete(@"C:\Users\Nikki\Desktop\Niki zadachi\Learning\Test1\Logger.Test\Log.txt");
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

        [TestMethod]
        public void CreateDefaultFileLoggerIFormatter()
        {
            var logger = LoggerFactory.GetLogger(LoggerType.FileLogger);
        }

        [TestCleanup]
        public void Cleanup()
        {
            LoggerFactory.ClearLoggers();
        }
    }
}
