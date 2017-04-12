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
        private List<Obsticle> obsticles;
        private string[,] matrix;

        public MovementEngine(PlayerPosition position, List<Obsticle> obsticles, string[,] matrix)
        {
            this.matrix = matrix;
            this.position = position;
            this.obsticles = obsticles;
        }

        public string[,] Execute()
        {
            int row = position.Row;
            int col = position.Col;
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1) || row < 0 || col < 0)
            {
                throw new IndexOutOfRangeException("The player is not within the bounds of the matrix");
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
    }
}
