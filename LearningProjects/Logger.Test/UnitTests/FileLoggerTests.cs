using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger.Loggers;
using Logger.Configuration;
using Moq;
using Logger.Common;

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
            var logger = new FileLogger(serializer, fileSystem);

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
            var serializer = mockSerializer.Object;
            var logger = new FileLogger(serializer, fileSystem);

            var a = new { a = 3, b = "asdf" };
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
            var logger = new FileLogger(serializer, fileSystem);

            var a = 1235;
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
            var logger = new FileLogger(serializer, fileSystem);

            int[] a = { 1, 2, 3, 5, };
            //Act
            logger.Log(a);

            //Assert
            mockSerializer.Verify(x => x.Serialize(a), Times.Once);
        }

        [TestMethod]
        public void LogStringUsesFilesystemCorrectlyWithDefaultFilePathAndFileName()
        {
            //Arrange
            Mock<IFileSystem> file = new Mock<IFileSystem>();
            var fileSystem = file.Object;
            Mock<ISerializer> mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            var logger = new FileLogger(serializer, fileSystem);

            string a = "this is a test";
            //Act
            logger.Log(a);

            //Assert
            file.Verify(x => x.AppendAllText("../Log.txt",It.IsAny<string>()));
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

            var logger = new FileLogger(serializer, fileSystem, fileName, filePath);

            string a = "this is a test";
            //Act
            logger.Log(a);

            //Assert
            file.Verify(x => x.AppendAllText(filePath + fileName, It.IsAny<string>()));
        }
    }
}
