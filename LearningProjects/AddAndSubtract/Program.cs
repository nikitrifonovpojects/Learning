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
            string input = "12+12+6-10-5=";
            var calc = new AddSubtractCalculator();

            decimal result = calc.Calculate(input);
            Console.WriteLine(result);
        }
    }
}
