using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class NissanSkylineR34 : MotorVehicle
    {
        private const decimal VehiclePrice = 45999;
        private const int VehicleWeight = 1850000;
        private const int VehicleAcceleration = 50;
        private const int VehicleTopSpeed = 280;

        public NissanSkylineR34() 
            : base(NissanSkylineR34.VehiclePrice, NissanSkylineR34.VehicleWeight, NissanSkylineR34.VehicleAcceleration, NissanSkylineR34.VehicleTopSpeed)
        {
        }
    }
}
