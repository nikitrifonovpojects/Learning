using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalMatrixMovement
{
    public class MovementEngine
    {
        private PlayerPosition startingPosition;
        private List<Obstacle> obstacles;
        private int matrixRow;
        private int matrixCol;

        public MovementEngine(PlayerPosition startingPosition, List<Obstacle> obstacles, int matrixRow, int matrixCol)
        {
            this.matrixRow = matrixRow;
            this.matrixCol = matrixCol;
            this.startingPosition = startingPosition;
            this.obstacles = obstacles;
        }

        public string[,] Execute()
        {
            string[,] matrix = CreateMatrix(this.obstacles, this.matrixRow, this.matrixCol);
            int row = this.startingPosition.Row;
            int col = this.startingPosition.Col;
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1) || row < 0 || col < 0)
            {
                throw new ArgumentOutOfRangeException("The player is not within the bounds of the matrix");
            }

            int startNumber = 1;
            PlayerPosition newPosition = new PlayerPosition();

            while (row - 1 != matrix.GetLength(0) && col - 1 != matrix.GetLength(1))
            {
                if (CanMove(matrix, row, col))
                {
                    matrix[row, col] = startNumber.ToString("D4");
                    startNumber++;
                    newPosition = MoveNext(row, col);
                }

                else
                {
                    newPosition = GetNextPosition(matrix, row, col);
                }

                row = newPosition.Row;
                col = newPosition.Col;
            }

            return matrix;
        }

        private PlayerPosition MoveNext(int row, int col)
        {
            return new PlayerPosition
            {
                Row = row - 1,
                Col = col + 1
            };
        }

        private PlayerPosition GetNextPosition(string[,] matrix, int row, int col)
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

        private bool CanMove(string[,] matrix, int row, int col)
        {
            bool move = false;
            if (row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1))
            {
                if (!CheckForObstacle(matrix, row, col))
                {
                    move = true;
                }
            }

            return move;
        }

        private bool CheckForObstacle(string[,] matrix, int row, int col)
        {
            bool obstacleFound = false;
            if (matrix[row, col] == "XXXX")
            {
                obstacleFound = true;
            }

            return obstacleFound;
        }
                
        private string[,] CreateMatrix(List<Obstacle> obstacles, int row, int col)
        {
            string[,] matrix = new string[row, col];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int f = 0; f < matrix.GetLength(1); f++)
                {
                    matrix[i, f] = "0000";
                }
            }
            foreach (var obstacle in obstacles)
            {
                if (obstacle.Row >= matrix.GetLength(0) || obstacle.Col >= matrix.GetLength(1) || obstacle.Row < 0 || obstacle.Col < 0)
                {
                    throw new ArgumentOutOfRangeException("The obstacle is not within the bounds of the matrix");
                }

                matrix[obstacle.Row, obstacle.Col] = "XXXX";
            }

            return matrix;
        }
    }
}
