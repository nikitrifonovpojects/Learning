using Common;
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
            int?[,] matrix = new int?[rows, cols];

            int totalSteps = rows * cols;
            int positionY = 0;
            int positionX = 0;
            Direction direction = Direction.Right;
            for (int i = 1; i <= totalSteps; i++)
            {
                if (direction == Direction.Right && (positionX >= cols - 1 || matrix[positionY, positionX + 1] != null))
                {
                    direction = Direction.Down;
                    
                }
                if (direction == Direction.Down && (positionY >= rows - 1 || matrix[positionY + 1, positionX] != null))
                {
                    direction = Direction.Left;
                    
                }
                if (direction == Direction.Left && (positionX <= 0 || matrix[positionY, positionX - 1] != null))
                {
                    direction = Direction.Up;
                    
                }
                if (direction == Direction.Up &&  matrix[positionY - 1, positionX] != null)
                {
                    direction = Direction.Right;
                    
                }
                matrix[positionY, positionX] = startNumber;
                startNumber++;

                switch (direction)
                {
                    case Direction.Right:
                        positionX++;
                        break;
                    case Direction.Down:
                        positionY++;
                        break;
                    case Direction.Left:
                        positionX--;
                        break;
                    case Direction.Up:
                        positionY--;
                        break;
                }
            }
            Utility.PrintMatrix(matrix);
        }
    }
}
