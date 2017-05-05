using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class MitsubishiEclipse : MotorVehicle
    {
        private const decimal MitsubishiEclipsePrice = 29999;
        private const int MitsubishiEclipseWeight = 1400000;
        private const int MitsubishiEclipseAcceleration = 24;
        private const int MitsubishiEclipseTopSpeed = 230;

        public MitsubishiEclipse() 
            : base(MitsubishiEclipsePrice, MitsubishiEclipseWeight, MitsubishiEclipseAcceleration, MitsubishiEclipseTopSpeed)
        {
        }
    }
}
