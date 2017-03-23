using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        private Direction TranslateDirection(string input)
        {
            throw new NotImplementedException();
        }

        private bool CanMove(Direction direction)
        {
            throw new NotImplementedException();
        }

        private void PrintError()
        {
            Console.WriteLine("You hit a wall at position {0},{1} this is your {2} time", this.currentPosition.Row, this.currentPosition.Col, this.colisionCount);
        }

        private void Move()
        {
            throw new NotImplementedException();
        }
    }
}
