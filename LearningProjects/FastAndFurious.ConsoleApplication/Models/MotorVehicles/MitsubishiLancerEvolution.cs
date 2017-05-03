using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class MitsubishiLancerEvolution : MotorVehicle
    {
        private const decimal VehiclePrice = 56999;
        private const int VehicleWeight = 1780000;
        private const int VehicleAcceleration = 20;
        private const int VehicleTopSpeed = 300;

        public MitsubishiLancerEvolution() 
            : base(MitsubishiLancerEvolution.VehiclePrice, MitsubishiLancerEvolution.VehicleWeight, MitsubishiLancerEvolution.VehicleAcceleration, MitsubishiLancerEvolution.VehicleTopSpeed)
        {
        }
    }
}
