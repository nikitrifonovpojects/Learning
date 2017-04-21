using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyAndDivideCalculator
{
    public class MultiplyDivideCalculator : AbstractCalculator
    {
        public override bool CheckForMoreThanOneOperator(string currentOperator, string nextOperator)
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

        public override decimal PerformCalculation(decimal result, string currentOperator, decimal number)
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
                    result /= number;
                    break;
                default:
                    Console.WriteLine("Error in PerformCalculation");
                    break;
            }

            return result;
        }

        public override string PrioritizeOperator(string currentOperator, string nextOperator)
        {
            return nextOperator;
        }
    }
}
