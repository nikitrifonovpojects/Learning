using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class AcuraIntegraTypeR : MotorVehicle
    {
        private const decimal VehiclePrice = 24999;
        private const int VehicleWeight = 1700000;
        private const int VehicleAcceleration = 15;
        private const int VehicleTopSpeed = 200;

        public AcuraIntegraTypeR() 
            : base(AcuraIntegraTypeR.VehiclePrice, AcuraIntegraTypeR.VehicleWeight, AcuraIntegraTypeR.VehicleAcceleration, AcuraIntegraTypeR.VehicleTopSpeed)
        {
        }
    }
}
