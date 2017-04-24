using Calculator;
using System;

namespace MultiplyAndDivideCalculator
{
    public class MultiplyDivideCalculator : AbstractCalculator
    {
        protected override bool CheckForMoreThanOneOperator(string currentOperator, string nextOperator)
        {
            if (currentOperator != string.Empty)
            {
                if (nextOperator == "*" || nextOperator == "/")
                {
                    return true;
                }
            }

            return false;
        }

        protected override decimal PerformCalculation(decimal result, string currentOperator, decimal number)
        {
            switch (currentOperator)
            {
                case "+":
                    result += number;
                    break;
                case "*":
                    result *= number;
                    break;
                case "/":
                    if (number == 0)
                    {
                        throw new ArgumentException(number.ToString(), "Cannot divide by zero");
                    }
                    else
                    {
                        result /= number;
                    }
                    break;
                default:
                    throw new ArgumentException("Operator is not supported", currentOperator);
            }

            return result;
        }

        protected override string PrioritizeOperator(string currentOperator, string nextOperator)
        {
            return nextOperator;
        }
    }
}
