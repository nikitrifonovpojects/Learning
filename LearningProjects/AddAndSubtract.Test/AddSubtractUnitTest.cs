using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddAndSubtract;

namespace AddAndSubtract.Test
{
    [TestClass]
    public class AddSubtractUnitTest
    {
        [TestMethod]
        public void CalculateWithNegativeAndPositiveNumbers()
        {
            //Arrange
            string input = "-250+100+500+-60=";
            decimal expected = 290;

            //Act
            decimal result = Program.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithZero()
        {
            //Arrange
            string input = "-0+0.00001=";
            decimal expected = 0.00001m;
            //Act
            decimal result = Program.Calculate(input);
            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithPositiveNumbersOnly()
        {
            //Arrange
            string input = "1010+126+4589765.256-2563.248+365.47-0.57+1478.524785=";
            decimal expected = 4590181.432785m;
            //Act
            decimal result = Program.Calculate(input);
            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithNegativeNumbersOnly()
        {
            //Arrange
            string input = "-1010+-126+-4589765.256--2563.248+-365.47--0.57+-1478.524785=";
            decimal expected = -4590181.432785m;
            //Act
            decimal result = Program.Calculate(input);
            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithPositiveNumbersAndZero()
        {
            //Arrange
            string input = "125+0-25+200-0=";
            decimal expected = 300;
            //Act
            decimal result = Program.Calculate(input);
            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithNegativeNumbersAndZero()
        {
            //Arrange
            string input = "-125+-0--25+-200-0=";
            decimal expected = -300;
            //Act
            decimal result = Program.Calculate(input);
            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithNegativeNumbersAndZeroAndMoreThanTwoOperatorsInARow()
        {
            //Arrange
            string input = "-125++-0+--25-+-200---50=";
            decimal expected = 50;
            //Act
            decimal result = Program.Calculate(input);
            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
