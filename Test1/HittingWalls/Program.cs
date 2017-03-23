using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HittingWalls
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter matrix dimensions:");
            string matrixInput = Console.ReadLine();
            Console.WriteLine("Enter initial player position:");
            string positionInput = Console.ReadLine();
            Console.WriteLine("Enter player directions:");
            string directionInput = Console.ReadLine().ToUpper();
            int directionsCount = directionInput.Length;

            string[] input = matrixInput.Split(',');
            string[] position = positionInput.Split(',');

            int playerRowPosition = int.Parse(position[0]);
            int playerColPosition = int.Parse(position[1]);

            int row = int.Parse(input[0]);
            int col = int.Parse(input[1]);
            int[,] matrix = new int[row, col];

            int numberOfColisions = 0;
            for (int i = 0; i < directionsCount; i++)
            {
                char direction = ReadDirection(directionInput, i);

                if (direction == 'R')
                {
                    if (playerColPosition + 1 <= col - 1)
                    {
                        playerColPosition++;
                    }
                    else
                    {
                        numberOfColisions++;
                        Console.WriteLine("You hit a wall at position {0},{1} this is your {2} time", playerRowPosition, playerColPosition, numberOfColisions);
                    }
                }
                if (direction == 'L')
                {
                    if (playerColPosition - 1 >= 0)
                    {
                        playerColPosition--;
                    }
                    else
                    {
                        numberOfColisions++;
                        Console.WriteLine("You hit a wall at position {0},{1} this is your {2} time", playerRowPosition, playerColPosition, numberOfColisions);
                    }
                }
                if (direction == 'D')
                {
                    if (playerRowPosition + 1 <= row -1)
                    {
                        playerRowPosition++;
                    }
                    else
                    {
                        numberOfColisions++;
                        Console.WriteLine("You hit a wall at position {0},{1} this is your {2} time", playerRowPosition, playerColPosition, numberOfColisions);
                    }
                }
                if (direction == 'U')
                {
                    if (playerRowPosition - 1 >= 0)
                    {
                        playerRowPosition--;
                    }
                    else
                    {
                        numberOfColisions++;
                        Console.WriteLine("You hit a wall at position {0},{1} this is your {2} time", playerRowPosition, playerColPosition, numberOfColisions);
                    }
                }
            }
        }

        private static char ReadDirection(string directions, int directionCount)
        {
            
            return directions.ElementAt(directionCount);
            
        }
    }
}
