using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class Vince : Driver
    {
        private const string DriverName = "Vince";
        private const GenderType DriverGender = GenderType.Male;

        public Vince() 
            : base(Vince.DriverName, Vince.DriverGender)
        {
        }
    }
}
