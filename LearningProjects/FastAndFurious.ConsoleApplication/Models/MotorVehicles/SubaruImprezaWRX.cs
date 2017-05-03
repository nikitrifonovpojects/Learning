using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class SubaruImprezaWRX : MotorVehicle
    {
        private const decimal VehiclePrice = 55999;
        private const int VehicleWeight = 1560000;
        private const int VehicleAcceleration = 35;
        private const int VehicleTopSpeed = 260;

        public SubaruImprezaWRX() 
            : base(SubaruImprezaWRX.VehiclePrice, SubaruImprezaWRX.VehicleWeight, SubaruImprezaWRX.VehicleAcceleration, SubaruImprezaWRX.VehicleTopSpeed)
        {
        }
    }
}
