using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class NissanSkylineR34 : MotorVehicle
    {
        private const decimal NissanSkylineR34Price = 45999;
        private const int NissanSkylineR34Weight = 1850000;
        private const int NissanSkylineR34Acceleration = 50;
        private const int NissanSkylineR34TopSpeed = 280;

        public NissanSkylineR34() 
            : base(NissanSkylineR34Price, NissanSkylineR34Weight, NissanSkylineR34Acceleration, NissanSkylineR34TopSpeed)
        {
        }
    }
}
