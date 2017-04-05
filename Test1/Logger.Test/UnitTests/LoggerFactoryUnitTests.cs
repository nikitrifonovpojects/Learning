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
        public void GetLoggerWithoutConfigurationReturnsFileLogger()
        {
            var logger = LoggerFactory.GetLogger();

            Assert.IsInstanceOfType(logger, typeof(FileLogger));
        }

        [TestMethod]
        public void GetLoggerWithConfigurationReturnsConsoleLogger()
        {
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.ConsoleLogger;
            var logger = LoggerFactory.GetLogger();

            Assert.IsInstanceOfType(logger, typeof(ConsoleLogger));
        }

        [TestMethod]
        public void SerializeSerializesCorrectly()
        {
            //Arrange
            var serializer = new Common.JsonSerializer();
            var input = new FileLoggerOptions()
            {
                FileName = "Logthis",
                FilePath = "../../"
            };

            //Act
            var result = serializer.Serialize(input);
            FileLoggerOptions deserializedResult = Newtonsoft.Json.JsonConvert.DeserializeObject<FileLoggerOptions>(result);

            //Assert
            Assert.AreEqual(input.File, deserializedResult.File);
            Assert.AreEqual(input.FileName, deserializedResult.FileName);
            Assert.AreEqual(input.FilePath, deserializedResult.FilePath);
        }

        [TestMethod]
        public void GetLoggerWithConfigurationReturnsFilelogger()
        {
            LoggerFactory.Configuration.DefaultLoggerType = LoggerType.FileLogger;
            var logger = LoggerFactory.GetLogger();

            Assert.IsInstanceOfType(logger, typeof(FileLogger));
        }

        [TestCleanup]
        public void Cleanup()
        {
            LoggerFactory.ClearLoggers();
        }
    }
}
