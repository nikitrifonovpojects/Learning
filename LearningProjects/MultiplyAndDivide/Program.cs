using System;

namespace MultiplyAndDivideCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var calculator = new MultiplyDivideCalculator();
            decimal result = decimal.Zero;
            try
            {
                result = calculator.Calculate(input);
            }
            catch (Exception exception)
            {
                Console.WriteLine("An error has occured: '{0}'", exception);
            }

            Console.WriteLine(result);
        }
    }
}
