using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalMatrixMovement
{
    public class MovementEngine
    {
        private PlayerPosition player;
        private List<Obsticle> obsticles;
        private string[,] matrix;
        private bool nextMove;

        public MovementEngine(PlayerPosition playerPosition, List<Obsticle> obsticles, string[,] matrix)
        {
            this.matrix = matrix;
            this.player = playerPosition;
            this.obsticles = obsticles;
        }

        public string[,] Execute()
        {
            int row = player.Row;
            int col = player.Col;
            int startPosition = 1;
            this.nextMove = true;
            while (this.nextMove)
            {
                matrix[player.Row, player.Col] = startPosition.ToString("D4");
                startPosition++;
                if (CanMove(row, col))
                {
                    row -= 1;
                    col += 1;
                    Move(row, col);
                }
                else if (player.Col + 1 < matrix.GetLength(1) || player.Row + 1 < matrix.GetLength(0))
                {
                    PlayerPosition newPosition = GetNextStartingPosition();
                    row = newPosition.Row;
                    col = newPosition.Col;
                }
                else
                {
                    this.nextMove = false;
                }
            }
            return this.matrix;
        }

        private PlayerPosition GetNextStartingPosition()
        {
            player.Col += 1;
            while (player.Row + 1 < matrix.GetLength(0) && player.Col - 1 >= 0)
            {
                player.Row += 1;
                player.Col -= 1;
            }
            if (CheckForObsticle(player.Row, player.Col))
            {
                if (player.Col + 1 < matrix.GetLength(1))
                {
                    GetNextStartingPosition();
                }
                else
                {
                    this.nextMove = false;
                }
            }
            return player;
        }

        private void Move(int row, int col)
        {
            player.Row = row;
            player.Col = col;
        }

        private bool CanMove(int row, int col)
        {
            bool canMove = false;
            if (row - 1 >= 0 && col + 1 < matrix.GetLength(1))
            {
                if (!CheckForObsticle(row - 1, col + 1))
                {
                    canMove = true;
                }
            }
            return canMove;
        }

        private bool CheckForObsticle(int row, int col)
        {
            bool obsticleFound = false;
            foreach (var obsticle in obsticles)
            {
                if (obsticle.Row == row && obsticle.Col == col)
                {
                    matrix[row, col] = "XXXX";
                    obsticleFound = true;
                }
            }
            return obsticleFound;
        }

    }
}
