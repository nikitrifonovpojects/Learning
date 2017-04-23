using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalMatrixMovement
{
    class Program
    {
        static void Main(string[] args)
        {
            string matrixRowCol = Console.ReadLine();
            string[] values = matrixRowCol.Split(',');
            int row = int.Parse(values[0]);
            int col = int.Parse(values[1]);

            string initialPosition = Console.ReadLine();
            string[] position = initialPosition.Split(',');
            int playerRow = int.Parse(position[0]);
            int playerCol = int.Parse(position[1]);

            PlayerPosition player = new PlayerPosition()
            {
                Row = playerRow,
                Col = playerCol
            };

            var obstacles = new List<Obstacle>();

            string obstaclePosition = Console.ReadLine();
            while (obstaclePosition != "END")
            {
                string[] obstaclePos = obstaclePosition.Split(',');
                Obstacle obstacle = new Obstacle()
                {
                    Row = int.Parse(obstaclePos[0]),
                    Col = int.Parse(obstaclePos[1])
                };

                obstacles.Add(obstacle);
                obstaclePosition = Console.ReadLine();
            }

            var engine = new MovementEngine(player, obstacles, row, col);

            string[,] resultMatrix = engine.Execute();

            Utility.PrintMatrix(resultMatrix);
        }
    }
}
