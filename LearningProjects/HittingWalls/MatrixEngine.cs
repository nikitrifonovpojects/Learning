using Common;
using System;
using System.Linq;

namespace HittingWalls
{
    class MatrixEngine
    {
        private MatrixData model;
        private int colisionCount;
        private PlayerPosition currentPosition;

        public MatrixEngine(MatrixData model)
        {
            this.model = model;
            this.currentPosition = new PlayerPosition()
            {
                Row = model.InitialRow,
                Col = model.InitialCol
            };
        }

        public void Execute()
        {
            int[,] matrix = new int[model.RowCount, model.ColCount];
            matrix[this.currentPosition.Row, this.currentPosition.Col] = 1;
            Utility.PrintMatrix(matrix);

            for (int i = 0; i < this.model.Directions.Length; i++)
            {
                Direction direction = this.TranslateDirection(this.model.Directions, i);
                Console.WriteLine("The last command was {0}", direction);
                Console.WriteLine();

                if (this.CanMove(direction))
                {
                    this.Move(direction);                    
                    matrix[this.currentPosition.Row, this.currentPosition.Col] = 1;
                    Utility.PrintMatrix(matrix);
                    Console.WriteLine();
                }
                else
                {
                    this.colisionCount++;
                    this.PrintError();
                }                
            }
        }

        private Direction TranslateDirection(string input, int position)
        {
            if (input.ElementAt(position) == 'R')
            {
                return Direction.Right;
            }
            if (input.ElementAt(position) == 'L')
            {
                return Direction.Left;
            }
            if (input.ElementAt(position) == 'D')
            {
                return Direction.Down;
            }
            if (input.ElementAt(position) == 'U')
            {
                return Direction.Up;
            }
            if (input.ElementAt(position) == 'F')
            {
                return Direction.TopLeft;
            }
            if (input.ElementAt(position) == 'G')
            {
                return Direction.TopRight;
            }
            if (input.ElementAt(position) == 'H')
            {
                return Direction.BottomRight;
            }
            if (input.ElementAt(position) == 'J')
            {
                return Direction.BottomLeft;
            }
            else
            {
                throw new Exception("The command is not recognised in method TranslateDirection");
            }
        }

        private bool CanMove(Direction direction)
        {
            bool check = false;
            if (direction == Direction.Right)
            {
                if (this.currentPosition.Col + 1 <= model.ColCount - 1)
                {
                    check = true;
                }
            }
            if (direction == Direction.Left)
            {
                if (this.currentPosition.Col - 1 >= 0)
                {
                    check = true;
                }
            }
            if (direction == Direction.Down)
            {
                if (this.currentPosition.Row + 1 <= model.RowCount - 1)
                {
                    check = true;
                }
            }
            if (direction == Direction.Up)
            {
                if (this.currentPosition.Row - 1 >= 0)
                {
                    check = true;
                }
            }
            if (direction == Direction.TopLeft)
            {
                if (this.currentPosition.Row - 1 >= 0 && this.currentPosition.Col - 1 >= 0)
                {
                    check = true;
                }
            }
            if (direction == Direction.TopRight)
            {
                if (this.currentPosition.Row - 1 >= 0 && this.currentPosition.Col + 1 <= model.ColCount - 1)
                {
                    check = true;
                }
            }
            if (direction == Direction.BottomRight)
            {
                if (this.currentPosition.Row + 1 <= model.RowCount - 1 && this.currentPosition.Col + 1 <= model.ColCount - 1)
                {
                    check = true;
                }
            }
            if (direction == Direction.BottomLeft)
            {
                if (this.currentPosition.Row + 1 <= model.RowCount - 1 && this.currentPosition.Col - 1 >= 0)
                {
                    check = true;
                }
            }
            return check;
        }

        private void PrintError()
        {
            Console.WriteLine("You hit a wall at position {0},{1} this is your {2} time", this.currentPosition.Row, this.currentPosition.Col, this.colisionCount);
        }

        private void Move(Direction input)
        {
            switch (input)
            {
                case Direction.Up:
                    this.currentPosition.Row--;
                    break;
                case Direction.Down:
                    this.currentPosition.Row++;
                    break;
                case Direction.Left:
                    this.currentPosition.Col--;
                    break;
                case Direction.Right:
                    this.currentPosition.Col++;
                    break;
                case Direction.TopLeft:
                    this.currentPosition.Row--;
                    this.currentPosition.Col--;
                    break;
                case Direction.TopRight:
                    this.currentPosition.Row--;
                    this.currentPosition.Col++;
                    break;
                case Direction.BottomRight:
                    this.currentPosition.Row++;
                    this.currentPosition.Col++;
                    break;
                case Direction.BottomLeft:
                    this.currentPosition.Row++;
                    this.currentPosition.Col--;
                    break;
                default:
                    throw new Exception("The command is not recognised in method Move");
            }
        }
    }
}
