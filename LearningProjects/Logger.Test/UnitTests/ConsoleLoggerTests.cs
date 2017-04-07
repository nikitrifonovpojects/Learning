using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Logger.Common;
using Logger.Configuration;
using Logger.Loggers;

namespace Logger.Test.UnitTests
{
    [TestClass]
    public class ConsoleLoggerTests
    {
        [TestMethod]
        public void LogStringDoesNotCallSerializer()
        {
            //Arrange
            var mockSerializer = new Mock<ISerializer>(MockBehavior.Strict);
            var serializer = mockSerializer.Object;
            var mockConsole = new Mock<IConsole>();
            var console = mockConsole.Object;
            var logger = LoggerFactory.GetLogger(LoggerType.ConsoleLogger);
            string input = "this is a string";

            //Act
            logger.Log(input);

            //Assert
            //with strict mock behavior if serializer is called an exception will be thrown
        }

        [TestMethod]
        public void LogObjectCallsSerializerCorrectly()
        {
            // Arrange
            var mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            var mockConsole = new Mock<IConsole>();
            var console = mockConsole.Object;
            var logger = new ConsoleLogger(serializer, console);
            var input = new { a = 13, b = "strings" };

            //Act
            logger.Log(input);

            //Assert
            mockSerializer.Verify(x => x.Serialize(input), Times.Once);
        }

        [TestMethod]
        public void LogStringWithConsoleOptionsForColors()
        {
            // Arrange
            var mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            var mockConsole = new Mock<IConsole>();
            var console = mockConsole.Object;
            string result = String.Empty;
            mockConsole.Setup(x => x.WriteLine(It.IsAny<string>())).Callback<string>(c => result += c + Environment.NewLine);

            var logger = new ConsoleLogger(serializer, console, ConsoleColor.DarkBlue, ConsoleColor.DarkMagenta);
            var input = "strings";
            string time = DateTime.Now.ToString();
            string expected = string.Join("-", time, input);
            //Act
            logger.Log(input);

            //Assert
            mockConsole.Verify(x => x.WriteLine(expected), Times.Once);
            mockConsole.VerifySet(x => x.BackgroundColor = ConsoleColor.DarkMagenta);
            mockConsole.VerifySet(x => x.ForegroundColor = ConsoleColor.DarkBlue);
            Assert.AreEqual(expected + Environment.NewLine, result);
        }
    }
}
