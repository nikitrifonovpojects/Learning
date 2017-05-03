using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class NissanGTR : MotorVehicle
    {
        private const decimal VehiclePrice = 125000;
        private const int VehicleWeight = 1850000;
        private const int VehicleAcceleration = 45;
        private const int VehicleTopSpeed = 300;

        public NissanGTR() 
            : base(NissanGTR.VehiclePrice, NissanGTR.VehicleWeight, NissanGTR.VehicleAcceleration, NissanGTR.VehicleTopSpeed)
        {
        }
    }
}
