using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalMatrixMovement
{
    public class MovementEngine
    {
        private PlayerPosition position;
        private List<Obstacle> obsticles;
        private int matrixRow;
        private int matrixCol;
        private string[,] matrix;

        public MovementEngine(PlayerPosition position, List<Obstacle> obsticles, int matrixRow, int matrixCol)
        {
            this.matrixRow = matrixRow;
            this.matrixCol = matrixCol;
            this.position = position;
            this.obsticles = obsticles;
        }

        public string[,] Execute()
        {
            this.matrix = CreateMatrix(matrixRow, matrixCol);
            InputObstacles(this.obsticles);
            int row = position.Row;
            int col = position.Col;
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1) || row < 0 || col < 0)
            {
                throw new ArgumentOutOfRangeException("The player is not within the bounds of the matrix");
            }

            int startNumber = 1;
            PlayerPosition newPosition = new PlayerPosition();

            while (row - 1 != matrix.GetLength(0) && col - 1 != matrix.GetLength(1))
            {
                if (CanMove(row, col))
                {
                    matrix[row, col] = startNumber.ToString("D4");
                    startNumber++;
                    newPosition = MoveNext(row, col);
                }

                else
                {
                    newPosition = GetNextPosition(row, col);
                }

                row = newPosition.Row;
                col = newPosition.Col;
            }

            return this.matrix;
        }

        private PlayerPosition MoveNext(int row, int col)
        {
            return new PlayerPosition
            {
                Row = row - 1,
                Col = col + 1
            };
        }

        private PlayerPosition GetNextPosition(int row, int col)
        {
            col += 1;
            while (row + 1 < matrix.GetLength(0) && col - 1 >= 0)
            {
                row += 1;
                col -= 1;
            }

            return new PlayerPosition
            {
                Row = row,
                Col = col
            };
        }

        private bool CanMove(int row, int col)
        {
            bool move = false;
            if (row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1))
            {
                if (!CheckForObsticle(row, col))
                {
                    move = true;
                }
            }

            return move;
        }

        private bool CheckForObsticle(int row, int col)
        {
            bool obsticleFound = false;
            if (matrix[row, col] == "XXXX")
            {
                obsticleFound = true;
            }

            return obsticleFound;
        }

        private string[,] CreateMatrix(int row, int col)
        {
            string[,] matrix = new string[row, col];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int f = 0; f < matrix.GetLength(1); f++)
                {
                    matrix[i, f] = "0000";
                }
            }

            return matrix;
        }

        private void InputObstacles(List<Obstacle> obsticles)
        {
            foreach (var obsticle in obsticles)
            {
                if (obsticle.Row >= matrix.GetLength(0) || obsticle.Col >= matrix.GetLength(1) || obsticle.Row < 0 || obsticle.Col < 0)
                {
                    throw new ArgumentOutOfRangeException("The obsticle is not within the bounds of the matrix");
                }

                matrix[obsticle.Row, obsticle.Col] = "XXXX";
            }
        }
    }
}
