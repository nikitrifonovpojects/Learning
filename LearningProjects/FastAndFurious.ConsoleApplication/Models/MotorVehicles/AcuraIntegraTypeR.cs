using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class AcuraIntegraTypeR : MotorVehicle
    {
        private const decimal AcuraIntegraTypeRPrice = 24999;
        private const int AcuraIntegraTypeRWeight = 1700000;
        private const int AcuraIntegraTypeRAcceleration = 15;
        private const int AcuraIntegraTypeRTopSpeed = 200;

        public AcuraIntegraTypeR() 
            : base(AcuraIntegraTypeRPrice, AcuraIntegraTypeRWeight, AcuraIntegraTypeRAcceleration, AcuraIntegraTypeRTopSpeed)
        {
        }
    }
}
