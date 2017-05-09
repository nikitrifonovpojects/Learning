using System;
using Logger.Common.Formatters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Test.UnitTests
{
    [TestClass]
    public class DefaultFormatterTests
    {
        [TestMethod]
        public void DefaultFormatterWorksCorrectly()
        {
            //Arrange
            var formatter = new DefaultFormatter();
            string inputLog = "Logs";
            string expected = "Logs";

            //Act
            var result = formatter.Format(inputLog);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
