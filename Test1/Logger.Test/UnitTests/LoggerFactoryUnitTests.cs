using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger.Loggers;
using Logger.Configuration;
using Logger.Common;
using Moq;
using Newtonsoft.Json;

namespace Logger.Test.UnitTests
{
    [TestClass]
    public class LoggerFactoryUnitTests
    {
        [TestMethod]
        public void GetLoggerWithConfigurationReturnsConsoleLogger()
        {
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.ConsoleLogger;
            var logger = LoggerFactory.GetLogger();

            Assert.IsInstanceOfType(logger, typeof(ConsoleLogger));
        }

        [TestMethod]
        public void GetLoggerWithConfigurationReturnsFilelogger()
        {
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.FileLogger;
            var logger = LoggerFactory.GetLogger();

            Assert.IsInstanceOfType(logger, typeof(FileLogger));
        }

        [ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public void GetLoggerWithLoggerTypeThatDoesntExist()
        {
            //Arrange
            LoggerFactory.Configuration.DefaultLoggerType = (LoggerType)3;

            //Act
            var logger = LoggerFactory.GetLogger();

            //Assert
        }

        [TestMethod]
        public void GetLoggerReturnsFilelogger()
        {
            var logger = LoggerFactory.GetLogger(LoggerType.FileLogger);

            Assert.IsInstanceOfType(logger, typeof(FileLogger));
        }

        [TestMethod]
        public void GetLoggerReturnsConsoleLogger()
        {
            var logger = LoggerFactory.GetLogger(LoggerType.ConsoleLogger);

            Assert.IsInstanceOfType(logger, typeof(ConsoleLogger));
        }

        [TestMethod]
        public void GetLoggerCachesLoggers()
        {
            var fileLogger = LoggerFactory.GetLogger(LoggerType.FileLogger);
            var consoleLogger = LoggerFactory.GetLogger(LoggerType.ConsoleLogger);
            var fileLogger1 = LoggerFactory.GetLogger(LoggerType.FileLogger);
            var consoleLogger1 = LoggerFactory.GetLogger(LoggerType.ConsoleLogger);

            Assert.AreEqual(fileLogger, fileLogger1);
            Assert.AreEqual(consoleLogger, consoleLogger1);
        }
   
        [TestMethod]
        public void ClearLoggersClearsTheCache()
        {
            var fileLogger = LoggerFactory.GetLogger(LoggerType.FileLogger);
            var consoleLogger = LoggerFactory.GetLogger(LoggerType.ConsoleLogger);
            LoggerFactory.ClearLoggers();
            var fileLogger1 = LoggerFactory.GetLogger(LoggerType.FileLogger);
            var consoleLogger1 = LoggerFactory.GetLogger(LoggerType.ConsoleLogger);
            
            Assert.AreNotEqual(fileLogger, fileLogger1);
            Assert.AreNotEqual(consoleLogger, consoleLogger1);
        }

        [TestCleanup]
        public void Cleanup()
        {
            LoggerFactory.ClearLoggers();
        }
    }
}
