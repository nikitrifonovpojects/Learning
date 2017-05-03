using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class Nissan350Z : MotorVehicle
    {
        private const decimal VehiclePrice = 25999;
        private const int VehicleWeight = 1280000;
        private const int VehicleAcceleration = 55;
        private const int VehicleTopSpeed = 220;

        public Nissan350Z() 
            : base(Nissan350Z.VehiclePrice, Nissan350Z.VehicleWeight, Nissan350Z.VehicleAcceleration, Nissan350Z.VehicleTopSpeed)
        {
        }
    }
}
