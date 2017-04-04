using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Logger.Test.UnitTests
{
    [TestClass]
    public class LoggerFactoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            var mock = new Mock<ISerializer>();

            var test = new FileLogger(mock.Object, "Testlog", "../../");
            var model = new ConsoleLoggerOptions();

            test.Log(model);
            mock.Verify(x => x.Serialize(model),Times.Exactly(1));
        }
    }
}
