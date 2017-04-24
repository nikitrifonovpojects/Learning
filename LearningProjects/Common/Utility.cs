using System;

namespace Common
{
    public static class Utility
    {
        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int f = 0; f < matrix.GetLength(1); f++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, f]));
                }
                Console.WriteLine();
            }
        }

        public static void PrintMatrix (int?[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int f = 0; f < matrix.GetLength(1); f++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, f]));
                }
                Console.WriteLine();
            }
        }

        public static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int f = 0; f < matrix.GetLength(1); f++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, f]));
                }
                Console.WriteLine();
            }
        }
    }
}
