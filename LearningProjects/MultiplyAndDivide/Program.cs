using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyAndDivideCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "2*3/1*5=";
            var calc = new MultiplyDivideCalculator();

            decimal result = calc.Calculate(input);
            Console.WriteLine(result);
        }
    }
}
