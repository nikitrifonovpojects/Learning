using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class VinBenzin : Driver
    {
        private const string DriverName = "Vin Benzin";
        private const GenderType DriverGender = GenderType.Male;

        public VinBenzin() 
            : base(VinBenzin.DriverName, VinBenzin.DriverGender)
        {
        }
    }
}
