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

            string[,] matrix = new string[row, col];
            
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
                Obstacle obsticle = new Obstacle()
                {
                    Row = int.Parse(obstaclePos[0]),
                    Col = int.Parse(obstaclePos[1])
                };

                obstacles.Add(obsticle);
                obstaclePosition = Console.ReadLine();
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int f = 0; f < matrix.GetLength(1); f++)
                {
                    matrix[i, f] = "0000";
                }
            }

            foreach (var obstacle in obstacles)
            {
                matrix[obstacle.Row, obstacle.Col] = "XXXX";
            }

            var engine = new MovementEngine(player, obstacles, matrix);

            string[,] resultMatrix = engine.Execute();

            Utility.PrintMatrix(resultMatrix);
        }
    }
}
