using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace SnakeMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] values = input.Split(',');
            int n = int.Parse(values[0]);
            int m = int.Parse(values[1]);
            int startNumber = int.Parse(values[2]);
            int?[,] matrix = new int?[n, m];

            int row = 0;
            int col = 0;
            int steps = n * m;
            Directions direction = Directions.Right;

            for (int i = 1; i <= steps; i++)
            {
                if (direction == Directions.Right && (col >= m - 1|| matrix[row,col + 1] != null))
                {
                    direction = Directions.Down;
                }
                if (direction == Directions.Down && (row  >= n - 1 || matrix[row + 1, col] != null))
                {
                    direction = Directions.Left;
                }
                if (direction == Directions.Left && (col <= 0 || matrix[row, col - 1] != null))
                {
                    direction = Directions.Up;
                }
                if (direction == Directions.Up &&  matrix[row - 1, col] != null)
                {
                    direction = Directions.Right;
                }

                matrix[row, col] = startNumber;
                startNumber++;

                switch (direction)
                {
                    case Directions.Right:
                        col++;
                        break;
                    case Directions.Left:
                        col--;
                        break;
                    case Directions.Down:
                        row++;
                        break;
                    case Directions.Up:
                        row--;
                        break;
                }
            }
            Utility.PrintMatrix(matrix);
        }
    }
}
