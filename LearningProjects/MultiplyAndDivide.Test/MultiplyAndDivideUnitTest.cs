using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace MultiplyAndDivideCalculator.Test
{
    [TestClass]
    public class MultiplyAndDivideUnitTest
    {

        [TestMethod]
        public void CalculateMultiplyWithZero()
        {
            //Arrange
            string input = "2*0=";
            decimal expected = 0;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CalculateDivideWithZero()
        {
            //Arrange
            string input = "2/0=";

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
        }

        [TestMethod]
        public void CalculateNormallySingleDigitNumbers()
        {
            //Arrange
            string input = "2*3/1*5=";
            decimal expected = 30;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithTwoOperatorsInARowSingleDigitNumbers()
        {
            //Arrange
            string input = "2/*3/1*5=";
            decimal expected = 30;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithOnlyMultiplySingleDigitNumbers()
        {
            //Arrange
            string input = "2*3*1*5=";
            decimal expected = 30;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithOnlyDivide()
        {
            //Arrange
            string input = "100/2/2/5=";
            decimal expected = 5;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void DivideDecimalNumbers()
        {
            //Arrange
            string input = "100.2/2/2/5=";
            decimal expected = 5.01m;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void DivideTwoDecimalNumbers()
        {
            //Arrange
            string input = "1010.2/2.25=";
            decimal expected = 448.97777777777777777777777778m;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void DivideManyDecimalNumbers()
        {
            //Arrange
            string input = "1010.2/1.25/56.54/2.24=";
            decimal expected = 6.3810702915761281520036383848m;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MultiplyTwoDecimalNumbers()
        {
            //Arrange
            string input = "1010.2*2.25=";
            decimal expected = 2272.95m;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MultiplyManyDecimalNumbers()
        {
            //Arrange
            string input = "1010.2*2.25*56.35*65.45=";
            decimal expected = 8382883.9421250m;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
