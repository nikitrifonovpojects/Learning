using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiagonalMatrixMovement;
using System.Collections.Generic;

namespace DiagonalMatrixTests
{
    [TestClass]
    public class MovementEngineTests
    {
        [TestMethod]
        public void MatrixWithPlayerAndObsticleAtTheSamePosition()
        {
            //Arrange
            PlayerPosition player = new PlayerPosition() { Row = 0, Col = 0 };
            Obsticle obsticle = new Obsticle() { Row = 0, Col = 0 };
            var obsticles = new List<Obsticle>();
            obsticles.Add(obsticle);
            int row = 5;
            int col = 5;
            string[,] matrix = new string[row, col];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int f = 0; f < matrix.GetLength(1); f++)
                {
                    matrix[i, f] = "0000";
                }
            }

            matrix[obsticle.Row, obsticle.Col] = "XXXX";

            string[,] expected = new string[,]
            {
                { "XXXX", "0002", "0005", "0009", "0014", },
                { "0001", "0004", "0008", "0013", "0018", },
                { "0003", "0007", "0012", "0017", "0021", },
                { "0006", "0011", "0016", "0020", "0023", },
                { "0010", "0015", "0019", "0022", "0024", },
            };
            //Act
            var engine = new MovementEngine(player, obsticles, matrix);
            string[,] result = engine.Execute();

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MatrixWithObsticlesAtPositionsOnTheSameDiagonal()
        {
            //Arrange
            PlayerPosition player = new PlayerPosition() { Row = 0, Col = 0 };
            Obsticle obsticle = new Obsticle() { Row = 4, Col = 0 };
            Obsticle obsticle1 = new Obsticle() { Row = 3, Col = 1 };
            Obsticle obsticle2 = new Obsticle() { Row = 0, Col = 4 };
            var obsticles = new List<Obsticle>();
            obsticles.Add(obsticle);
            obsticles.Add(obsticle1);
            obsticles.Add(obsticle2);
            int row = 5;
            int col = 5;
            string[,] matrix = new string[row, col];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int f = 0; f < matrix.GetLength(1); f++)
                {
                    matrix[i, f] = "0000";
                }
            }
            foreach (var item in obsticles)
            {
                matrix[item.Row, item.Col] = "XXXX";
            }

            string[,] expected = new string[,]
            {
                { "0001", "0003", "0006", "0010", "XXXX", },
                { "0002", "0005", "0009", "0000", "0014", },
                { "0004", "0008", "0000", "0013", "0017", },
                { "0007", "XXXX", "0012", "0016", "0019", },
                { "XXXX", "0011", "0015", "0018", "0020", },
            };
            //Act
            var engine = new MovementEngine(player, obsticles, matrix);
            string[,] result = engine.Execute();

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MatrixWithPlayerStartingAtPositionAtTheLowerLeftCorner()
        {
            //Arrange
            PlayerPosition player = new PlayerPosition() { Row = 4, Col = 0 };
            Obsticle obsticle = new Obsticle() { Row = 2, Col = 0 };
            Obsticle obsticle1 = new Obsticle() { Row = 0, Col = 0 };
            Obsticle obsticle2 = new Obsticle() { Row = 3, Col = 4 };
            var obsticles = new List<Obsticle>();
            obsticles.Add(obsticle);
            obsticles.Add(obsticle1);
            obsticles.Add(obsticle2);
            int row = 5;
            int col = 5;
            string[,] matrix = new string[row, col];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int f = 0; f < matrix.GetLength(1); f++)
                {
                    matrix[i, f] = "0000";
                }
            }
            foreach (var item in obsticles)
            {
                matrix[item.Row, item.Col] = "XXXX";
            }

            string[,] expected = new string[,]
            {
                { "XXXX", "0000", "0000", "0000", "0005", },
                { "0000", "0000", "0000", "0004", "0009", },
                { "XXXX", "0000", "0003", "0008", "0012", },
                { "0000", "0002", "0007", "0011", "XXXX", },
                { "0001", "0006", "0010", "0013", "0014", },
            };
            //Act
            var engine = new MovementEngine(player, obsticles, matrix);
            string[,] result = engine.Execute();

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
