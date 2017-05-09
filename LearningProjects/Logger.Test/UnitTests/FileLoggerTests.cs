using System;
using Logger.Common.Formatters;
using Logger.Configuration;
using Logger.Contracts;
using Logger.Factory;
using Logger.Loggers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Logger.Test.UnitTests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void LogStringDoesNotCallSerializer()
        {
            //Arrange
            Mock<IFileSystem> file = new Mock<IFileSystem>();
            var fileSystem = file.Object;
            Mock<ISerializer> mockSerializer = new Mock<ISerializer>(MockBehavior.Strict);
            var serializer = mockSerializer.Object;
            var format = new Mock<IFormatter>();
            var formatter = format.Object;
            var logger = new FileLogger(serializer, formatter, fileSystem, null, null);

            var input = "this is a log";
            //Act
            logger.Log(input);

            //Assert
            //with strict mock behavior if serializer is called an exception will be thrown
        }

        [TestMethod]
        public void LogObjectCallsSerializerCorrectly()
        {
            //Arrange
            Mock<IFileSystem> file = new Mock<IFileSystem>();
            var fileSystem = file.Object;
            Mock<ISerializer> mockSerializer = new Mock<ISerializer>();
            mockSerializer.Setup(x => x.Serialize(It.IsAny<object>()));
            var serializer = mockSerializer.Object;
            var format = new Mock<IFormatter>();
            var formatter = format.Object;
            var logger = new FileLogger(serializer, formatter, fileSystem, null, null);

            var a = new { a = 3, b = "asdf" };
            mockSerializer.Setup(x => x.Serialize(a)).Returns("asdf");
            //Act
            logger.Log(a);

            //Assert
            mockSerializer.Verify(x => x.Serialize(a), Times.Once);
        }

        [TestMethod]
        public void LogIntCallsSerializerCorrectly()
        {
            //Arrange
            Mock<IFileSystem> file = new Mock<IFileSystem>();
            var fileSystem = file.Object;
            Mock<ISerializer> mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            var format = new Mock<IFormatter>();
            var formatter = format.Object;
            var logger = new FileLogger(serializer, formatter, fileSystem, null, null);

            var a = 1235;
            mockSerializer.Setup(x => x.Serialize(a)).Returns("123");
            //Act
            logger.Log(a);

            //Assert
            mockSerializer.Verify(x => x.Serialize(a), Times.Once);
        }

        [TestMethod]
        public void LogArrayCallsSerializerCorrectly()
        {
            //Arrange
            Mock<IFileSystem> file = new Mock<IFileSystem>();
            var fileSystem = file.Object;
            Mock<ISerializer> mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            var format = new Mock<IFormatter>();
            var formatter = format.Object;
            var logger = new FileLogger(serializer, formatter, fileSystem, null, null);

            int[] a = { 1, 2, 3, 5, };
            mockSerializer.Setup(x => x.Serialize(a)).Returns("123");
            //Act
            logger.Log(a);

            //Assert
            mockSerializer.Verify(x => x.Serialize(a), Times.Once);
        }

        [TestMethod]
        public void LogStringUsesFilesystemCorrectlyWithFilePathAndFileName()
        {
            //Arrange
            Mock<IFileSystem> file = new Mock<IFileSystem>();
            var fileSystem = file.Object;
            Mock<ISerializer> mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            string fileName = "Logged.txt";
            string filePath = "../../";
            var format = new Mock<IFormatter>();
            var formatter = format.Object;
            var logger = new FileLogger(serializer, formatter, fileSystem, fileName, filePath);

            string a = "this is a test";
            //Act
            logger.Log(a);

            //Assert
            file.Verify(x => x.AppendAllText(filePath + fileName, It.IsAny<string>()));
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void LogNullReturnsArgumentNullException()
        {
            //Assert
            Mock<IFileSystem> file = new Mock<IFileSystem>();
            var fileSystem = file.Object;
            Mock<ISerializer> mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            var format = new Mock<IFormatter>();
            var formatter = format.Object;
            var logger = new FileLogger(serializer, formatter, fileSystem, null, null);
            int? input = null;
            //Act
            logger.Log(input);

            //Assert
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void LogNullStringReturnsArgumentNullException()
        {
            //Assert
            Mock<IFileSystem> file = new Mock<IFileSystem>();
            var fileSystem = file.Object;
            Mock<ISerializer> mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            var format = new Mock<IFormatter>();
            var formatter = format.Object;
            var logger = new FileLogger(serializer, formatter, fileSystem, null, null);
            string input = null;
            //Act
            logger.Log(input);

            //Assert
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void LogNullClassThrowsArgumentNullException()
        {
            //Arrange
            Mock<IFileSystem> file = new Mock<IFileSystem>();
            var fileSystem = file.Object;
            Mock<ISerializer> mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            var format = new Mock<IFormatter>();
            var formatter = format.Object;
            var logger = new FileLogger(serializer, formatter, fileSystem, null, null);

            FactoryOptions input = null;
            //var input = default(FactoryOptions); alternative for null class

            //Act
            logger.Log(input);

            //Assert
        }
    }
}
