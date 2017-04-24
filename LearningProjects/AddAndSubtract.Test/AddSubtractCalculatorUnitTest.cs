using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddAndSubtract.Test
{
    [TestClass]
    public class AddSubtractCalculatorUnitTest
    {
        [TestMethod]
        public void CalculateSubtractWithZero()
        {
            //Arrange
            string input = "0-10=";
            decimal expected = -10;

            //Act
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateAddWithZero()
        {
            //Arrange
            string input = "0+10=";
            decimal expected = 10;

            //Act
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateSubtractWithDecimalNumbers()
        {
            //Arrange
            string input = "100.256-50.256=";
            decimal expected = 50;

            //Act
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateAddWithDecimalNumbers()
        {
            //Arrange
            string input = "100.256+500.256=";
            decimal expected = 600.512m;

            //Act
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateAddWithNegativeNumbers()
        {
            //Arrange
            string input = "-100+-500=";
            decimal expected = -600;

            //Act
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateSubtractWithPositiveNumbers()
        {
            //Arrange
            string input = "100-50=";
            decimal expected = 50;

            //Act
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateAddWithPositiveNumbers()
        {
            //Arrange
            string input = "100+500=";
            decimal expected = 600;

            //Act
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithNegativeAndPositiveNumbers()
        {
            //Arrange
            string input = "-250+100+500+-60=";
            decimal expected = 290;

            //Act
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

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
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

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
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

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
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

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
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

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
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithMoreThanTwoOperatorsInARow()
        {
            //Arrange
            string input = "-125++-0+--25-+-200---50=";
            decimal expected = 50;

            //Act
            var calculator = new AddSubtractCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
