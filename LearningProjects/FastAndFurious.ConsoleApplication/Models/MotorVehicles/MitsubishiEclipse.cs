using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class MitsubishiEclipse : MotorVehicle
    {
        private const decimal VehiclePrice = 29999;
        private const int VehicleWeight = 1400000;
        private const int VehicleAcceleration = 24;
        private const int VehicleTopSpeed = 230;

        public MitsubishiEclipse() 
            : base(MitsubishiEclipse.VehiclePrice, MitsubishiEclipse.VehicleWeight, MitsubishiEclipse.VehicleAcceleration, MitsubishiEclipse.VehicleTopSpeed)
        {
        }
    }
}
