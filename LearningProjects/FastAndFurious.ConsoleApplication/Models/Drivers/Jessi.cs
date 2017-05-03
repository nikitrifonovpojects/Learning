using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class Jessi : Driver
    {
        private const string DriverName = "Jessi";
        private const GenderType DriverGender = GenderType.Female;

        public Jessi() 
            : base(Jessi.DriverName, Jessi.DriverGender)
        {
        }
    }
}
