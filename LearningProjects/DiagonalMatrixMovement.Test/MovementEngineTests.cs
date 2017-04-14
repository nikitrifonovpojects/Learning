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
            Obstacle obsticle = new Obstacle() { Row = 0, Col = 0 };
            var obsticles = new List<Obstacle>();
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
            Obstacle obsticle = new Obstacle() { Row = 4, Col = 0 };
            Obstacle obsticle1 = new Obstacle() { Row = 3, Col = 1 };
            Obstacle obsticle2 = new Obstacle() { Row = 0, Col = 4 };
            var obsticles = new List<Obstacle>();
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
            Obstacle obsticle = new Obstacle() { Row = 2, Col = 0 };
            Obstacle obsticle1 = new Obstacle() { Row = 0, Col = 0 };
            Obstacle obsticle2 = new Obstacle() { Row = 3, Col = 4 };
            var obsticles = new List<Obstacle>();
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

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void ObsticleOutOfBoundsOfTheMatrixReturnsException()
        {
            //Arrange
            PlayerPosition player = new PlayerPosition() { Row = 4, Col = 0 };
            Obstacle obsticle = new Obstacle() { Row = 2, Col = 0 };
            Obstacle obsticle1 = new Obstacle() { Row = 0, Col = 0 };
            Obstacle obsticle2 = new Obstacle() { Row = 3, Col = 4 };
            Obstacle obsticle3 = new Obstacle() { Row = 5, Col = 5 };
            var obsticles = new List<Obstacle>();
            obsticles.Add(obsticle);
            obsticles.Add(obsticle1);
            obsticles.Add(obsticle2);
            obsticles.Add(obsticle3);
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
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void PlayerOutOfBoundsOfTheMatrixReturnsException()
        {
            //Arrange
            PlayerPosition player = new PlayerPosition() { Row = 5, Col = 5 };
            Obstacle obsticle = new Obstacle() { Row = 2, Col = 0 };
            Obstacle obsticle1 = new Obstacle() { Row = 0, Col = 0 };
            Obstacle obsticle2 = new Obstacle() { Row = 3, Col = 4 };
            var obsticles = new List<Obstacle>();
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
        }

        [TestMethod]
        public void PlayerStartsAtTheLastIndexOfTheMatrix()
        {
            //Arrange
            PlayerPosition player = new PlayerPosition() { Row = 4, Col = 4 };
            Obstacle obsticle = new Obstacle() { Row = 2, Col = 0 };
            Obstacle obsticle1 = new Obstacle() { Row = 0, Col = 0 };
            Obstacle obsticle2 = new Obstacle() { Row = 3, Col = 4 };
            var obsticles = new List<Obstacle>();
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
                { "XXXX", "0000", "0000", "0000", "0000", },
                { "0000", "0000", "0000", "0000", "0000", },
                { "XXXX", "0000", "0000", "0000", "0000", },
                { "0000", "0000", "0000", "0000", "XXXX", },
                { "0000", "0000", "0000", "0000", "0001", },
            };

            //Act
            var engine = new MovementEngine(player, obsticles, matrix);
            string[,] result = engine.Execute();

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PlayerStartsAtTheUpperRightCornerOfTheMatrix()
        {
            //Arrange
            PlayerPosition player = new PlayerPosition() { Row = 0, Col = 4 };
            Obstacle obsticle = new Obstacle() { Row = 2, Col = 0 };
            Obstacle obsticle1 = new Obstacle() { Row = 0, Col = 0 };
            Obstacle obsticle2 = new Obstacle() { Row = 3, Col = 4 };
            var obsticles = new List<Obstacle>();
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
                { "XXXX", "0000", "0000", "0000", "0001", },
                { "0000", "0000", "0000", "0000", "0005", },
                { "XXXX", "0000", "0000", "0004", "0008", },
                { "0000", "0000", "0003", "0007", "XXXX", },
                { "0000", "0002", "0006", "0009", "0010", },
            };

            //Act
            var engine = new MovementEngine(player, obsticles, matrix);
            string[,] result = engine.Execute();

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PlayerStartsAtTheMiddleOfTheMatrix()
        {
            //Arrange
            PlayerPosition player = new PlayerPosition() { Row = 2, Col = 2 };
            Obstacle obsticle = new Obstacle() { Row = 2, Col = 0 };
            Obstacle obsticle1 = new Obstacle() { Row = 0, Col = 0 };
            Obstacle obsticle2 = new Obstacle() { Row = 3, Col = 4 };
            var obsticles = new List<Obstacle>();
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
                { "XXXX", "0000", "0000", "0000", "0003", },
                { "0000", "0000", "0000", "0002", "0007", },
                { "XXXX", "0000", "0001", "0006", "0010", },
                { "0000", "0000", "0005", "0009", "XXXX", },
                { "0000", "0004", "0008", "0011", "0012", },
            };

            //Act
            var engine = new MovementEngine(player, obsticles, matrix);
            string[,] result = engine.Execute();

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PlayerStartsAtTheMiddleOfTheMatrixAndTheMatrixIsFullWithObsticlesReturnsOnlyObsticles()
        {
            //Arrange
            PlayerPosition player = new PlayerPosition() { Row = 2, Col = 2 };
            var obsticles = new List<Obstacle>();
            int row = 5;
            int col = 5;
            string[,] matrix = new string[row, col];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int f = 0; f < matrix.GetLength(1); f++)
                {
                    matrix[i, f] = "XXXX";
                }
            }
            
            string[,] expected = new string[,]
            {
                { "XXXX", "XXXX", "XXXX", "XXXX", "XXXX", },
                { "XXXX", "XXXX", "XXXX", "XXXX", "XXXX", },
                { "XXXX", "XXXX", "XXXX", "XXXX", "XXXX", },
                { "XXXX", "XXXX", "XXXX", "XXXX", "XXXX", },
                { "XXXX", "XXXX", "XXXX", "XXXX", "XXXX", },
            };
            //Act
            var engine = new MovementEngine(player, obsticles, matrix);
            string[,] result = engine.Execute();

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
