using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class AbstractCalculator
    {
        public AbstractCalculator()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
        }
        public decimal Calculate(string input)
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

        protected abstract bool CheckForMoreThanOneOperator(string currentOperator, string nextOperator);

        protected abstract string PrioritizeOperator(string currentOperator, string nextOperator);

        protected abstract decimal PerformCalculation(decimal result, string currentOperator, decimal number);

        private Queue<string> CreateQueue(string input)
        {
            Queue<string> queue = new Queue<string>();
            string tempNumber = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (IsNumber(input[i]))
                {
                    tempNumber += input[i];
                }
                else
                {
                    if (tempNumber != string.Empty)
                    {
                        queue.Enqueue(tempNumber);
                        tempNumber = string.Empty;
                    }

                    queue.Enqueue(input[i].ToString());
                }
            }

            return queue;
        }

        private bool IsNumber(char input)
        {
            switch (input)
            {
                case '0':
                    return true;
                case '1':
                    return true;
                case '2':
                    return true;
                case '3':
                    return true;
                case '4':
                    return true;
                case '5':
                    return true;
                case '6':
                    return true;
                case '7':
                    return true;
                case '8':
                    return true;
                case '9':
                    return true;
                case '.':
                    return true;
                default:
                    return false;
            }
        }
    }
}
