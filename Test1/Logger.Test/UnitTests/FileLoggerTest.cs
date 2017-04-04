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
        public void LogWithModelCallsSerialize()
        {
            
            var mock = new Mock<ISerializer>();

            var test = new FileLogger(mock.Object, "Testlog", "../../");
            var model = new ConsoleLoggerOptions();

            test.Log(model);
            mock.Verify(x => x.Serialize(model),Times.Exactly(1));
        }
    }
}
