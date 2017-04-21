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

            var obsticles = new List<Obstacle>();

            string obsticlePosition = Console.ReadLine();
            while (obsticlePosition != "END")
            {
                string[] obsticlePos = obsticlePosition.Split(',');
                Obstacle obsticle = new Obstacle()
                {
                    Row = int.Parse(obsticlePos[0]),
                    Col = int.Parse(obsticlePos[1])
                };

                obsticles.Add(obsticle);
                obsticlePosition = Console.ReadLine();
            }

            var engine = new MovementEngine(player, obsticles, row, col);

            string[,] resultMatrix = engine.Execute();

            Utility.PrintMatrix(resultMatrix);
        }
    }
}
