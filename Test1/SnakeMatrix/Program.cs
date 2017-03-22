using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] values = input.Split(',');
            int rows = int.Parse(values[0]);
            int cols = int.Parse(values[1]);
            int startNumber = int.Parse(values[2]);
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int f = 0; f < matrix.GetLength(1); f++)
                {

                }
            }

        }
    }
}
