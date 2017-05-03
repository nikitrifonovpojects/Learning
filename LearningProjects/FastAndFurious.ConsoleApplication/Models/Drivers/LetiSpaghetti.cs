using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class LetiSpaghetti : Driver
    {
        private const string DriverName = "Leti Spaghetti";
        private const GenderType DriverGender = GenderType.Female;

        public LetiSpaghetti() 
            : base(LetiSpaghetti.DriverName, LetiSpaghetti.DriverGender)
        {
        }
    }
}
