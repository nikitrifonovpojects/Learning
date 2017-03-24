using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HittingWalls
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter matrix dimensions:");
            string matrixInput = Console.ReadLine();
            Console.WriteLine("Enter initial player position:");
            string positionInput = Console.ReadLine();
            Console.WriteLine("Enter player directions:");
            string directionInput = Console.ReadLine().ToUpper();
            int directionsCount = directionInput.Length;

            string[] input = matrixInput.Split(',');
            string[] position = positionInput.Split(',');

            MatrixData model = new MatrixData()
            {
                RowCount = int.Parse(input[0]),
                ColCount = int.Parse(input[1]),
                InitialRow = int.Parse(position[0]),
                InitialCol = int.Parse(position[1]),
                Directions = directionInput
            };

            MatrixEngine engine = new MatrixEngine(model);

            engine.Execute();

        }
    }
}
