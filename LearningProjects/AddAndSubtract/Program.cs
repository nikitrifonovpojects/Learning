using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddAndSubtract
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            decimal result = Calculate(input);
            Console.WriteLine(result);
        }

        public static decimal Calculate(string input)
        {
            Queue<string> queue = CreateQueue(input);

            decimal result = decimal.Zero;
            decimal currentNumber = decimal.Zero;
            string currentOperator = "+";
            decimal number = decimal.Zero;

            while (queue.Peek() != "=")
            {
                if (decimal.TryParse(queue.Peek(), out number))
                {
                    currentNumber = number;
                    queue.Dequeue();
                    result = PerformCalculation(result, currentOperator, currentNumber);
                    currentOperator = string.Empty;
                }
                else
                {
                    if (CheckForMoreThanOneOperator(currentOperator, queue.Peek()))
                    {
                        currentOperator = PrioritizeOperator(currentOperator, queue.Dequeue());
                    }
                    else
                    {
                        currentOperator = queue.Dequeue();
                    }
                }
            }

            return result;
        }

        private static decimal PerformCalculation(decimal result, string currentOperator, decimal currentNumber)
        {
            switch (currentOperator)
            {
                case "+":
                    result += currentNumber;
                    break;
                case "-":
                    result -= currentNumber;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            return result;
        }

        private static string PrioritizeOperator(string currentOperator, string nextoperator)
        {
            if (currentOperator == "+" && nextoperator == "+")
            {
                currentOperator = "+";
            }
            else if (currentOperator == "+" && nextoperator == "-")
            {
                currentOperator = "-";
            }
            else if (currentOperator == "-" && nextoperator == "-")
            {
                currentOperator = "+";
            }
            else if (currentOperator == "-" && nextoperator == "+")
            {
                currentOperator = "-";
            }

            return currentOperator;
        }

        private static bool CheckForMoreThanOneOperator(string currentOperator, string nextoperator)
        {
            if (currentOperator != string.Empty)
            {
                if (nextoperator == "+" || nextoperator == "-")
                {
                    return true;
                }
            }

            return false;
        }

        private static Queue<string> CreateQueue(string input)
        {
            Queue<string> queue = new Queue<string>();
            string tempNumber = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '+' || input[i] == '-' || input[i] == '=')
                {
                    if (tempNumber != string.Empty)
                    {
                        queue.Enqueue(tempNumber);
                        tempNumber = string.Empty;
                    }

                    queue.Enqueue(input[i].ToString());
                }
                else
                {
                    tempNumber += input[i];
                }
            }

            return queue;
        }
    }
}
