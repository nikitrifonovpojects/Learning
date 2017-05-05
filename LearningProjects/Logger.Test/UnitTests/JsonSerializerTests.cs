using System;
using System.Collections.Generic;
using Logger.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Logger.Test.UnitTests
{
    [TestClass]
    public class JsonSerializerTests
    {
        [TestMethod]
        public void SerializeSerializesCorrectlyClass()
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
        public void SerializeSerializesCorrectlyInt()
        {
            //Arrange
            var serializer = new Common.JsonSerializer();
            int input = 567;

            //Act
            var result = serializer.Serialize(input);
            var deserializedResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);

            //Assert
            Assert.AreEqual(input, (Int64)deserializedResult);
        }

        [TestMethod]
        public void SerializeSerializesCorrectlyList()
        {
            //Arrange
            var serializer = new Common.JsonSerializer();
            List<string> input = new List<string> { "This list was deserialized correctly" };

            //Act
            var result = serializer.Serialize(input);
            var deserializedResult = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(result);

            //Assert
            CollectionAssert.AreEqual(input, deserializedResult);
        }

        [TestMethod]
        public void SerializeSerializesCorrectlyArray()
        {
            //Arrange
            var serializer = new Common.JsonSerializer();
            int[] input = new int[] { 1, 5, 8, 4, 6, 2, 7 };

            //Act
            var result = serializer.Serialize(input);
            var deserializedResult = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(result);

            //Assert
            CollectionAssert.AreEqual(input, deserializedResult);
        }

        [TestMethod]
        public void SerializeSerializesCorrectlyMatrix()
        {
            //Arrange
            var serializer = new Common.JsonSerializer();
            int[,] input = new int[3, 4];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int f = 0; f < input.GetLength(1); f++)
                {
                    input[i, f] += 1;
                }
            }

            //Act
            var result = serializer.Serialize(input);
            var deserializedResult = Newtonsoft.Json.JsonConvert.DeserializeObject<int[,]>(result);

            //Assert
            CollectionAssert.AreEqual(input, deserializedResult);
        }
    }
}
