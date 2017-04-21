using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncodeEncrypt;

namespace EncodeEncrypt.Test
{
    [TestClass]
    public class EncodeEncryptTests
    {
        [TestMethod]
        public void TestWithFirstExample()
        {
            //Arrange
            string message = "TELERIKACADEMY";
            string cypher = "SOFTWARE";
            var expected = @"BKOXHI\EQOGX[YSOFTWARE8";
            //Act
            var textCypher = Program.Encrypt(message, cypher) + cypher;
            var result = Program.Encode(textCypher) + cypher.Length;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithSecondExample()
        {
            //Arrange
            string message = "AAABB";
            string cypher = "BBBBBBA";
            var expected = "ABBAA6BA7";
            //Act
            var textCypher = Program.Encrypt(message, cypher) + cypher;
            var result = Program.Encode(textCypher) + cypher.Length;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithThirdExample()
        {
            //Arrange
            string message = "JOHNY";
            string cypher = "DEPPP";
            var expected = "KKICXDE3P5";
            //Act
            var textCypher = Program.Encrypt(message, cypher) + cypher;
            var result = Program.Encode(textCypher) + cypher.Length;

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
