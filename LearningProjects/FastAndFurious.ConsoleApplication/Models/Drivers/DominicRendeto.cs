using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class DominicRendeto : Driver
    {
        private const string DriverName = "Dominic Rendeto";
        private const GenderType DriverGender = GenderType.Male;

        public DominicRendeto() 
            : base(DominicRendeto.DriverName, DominicRendeto.DriverGender)
        {
        }
    }
}
