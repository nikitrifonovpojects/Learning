using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillMatrix
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            string[] values = input.Split(',');
            int rows = int.Parse(values[0]);
            int cols = int.Parse(values[1]);
            int[,] matrix = new int[rows, cols];

            FillMatrix(matrix);

            Utility.PrintMatrix(matrix);
        }

        private static void FillMatrix(int[,] matrix)
        {
            int number = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int f = 0; f < matrix.GetLength(1); f++)
                    {
                        matrix[i, f] += number;
                        number++;
                    }
                }
                else
                {
                    for (int f = matrix.GetLength(1) - 1; f >= 0; f--)
                    {
                        matrix[i, f] += number;
                        number++;
                    }
                }
            }
        }
    }
}
